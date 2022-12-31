using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using And.ElkomMuhasebe.Core.Model;
using And.ElkomMuhasebe.Core.Model.Entity.Admin;
using And.ElkomMuhasebe.Core.Model.Entity.FirmaDB;
using System.Linq.Dynamic.Core;


using DbFunctions = System.Data.Entity.DbFunctions;
using EntityState = System.Data.Entity.EntityState;
using System.Globalization;
using System.Data.Entity.SqlServer;
using System.Linq.Dynamic;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class CARI_BASLIKController : Controller
    {
        private FirmaBaseDB db = new FirmaBaseDB();

        private AndDB anddb = new AndDB();
        public int userid = 0;
        public bool ekleme = false;
        public bool degistirme = false;
        public bool silme = false;
        public bool gorme = false;
        public void Disposedb()
        {
            anddb.Dispose();
            db.Dispose();
            base.Dispose(true);
        }
        public void changestring()
        {
            if ((Session["LoginUser"] == null || Session["SeciliFirma"] == null) && (Session["LoginAltUser"] == null || Session["SeciliFirma"] == null)) { Response.Redirect("/Home"); }
            else
            {
                if (Session["LoginAltUser"] != null)
                {
                    var alt = Session["LoginAltUser"] as And.ElkomMuhasebe.Core.Model.Entity.Admin.AltUser;
                    userid = alt.ID;
                    if (alt.görme.Contains("Cariler"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Cariler"))
                            ekleme = true;
                        if (alt.silme.Contains("Cariler"))
                            silme = true;
                        if (alt.degistir.Contains("Cariler"))
                            degistirme = true;

                    }

                }
                else
                {
                    gorme = true;
                    silme = true;
                    ekleme = true;
                    degistirme = true;
                    var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                    if (db.Database.Connection.State != ConnectionState.Open)
                    {
                        db.Database.Connection.Open();
                        db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                        db.SaveChanges();
                    }
                }
            }
        }
        // GET: CARI_BASLIK
        public ActionResult Index()
        {
            changestring();

            /* foreach(var item in cariler)
             {
                 if (db.CARI_BASLIK.Find(item.ID) !=null) { 
                 var sonbakiye = caribakiyehesapla(item.ID);
                 db.CARI_BASLIK.Single(x => x.ID == item.ID).BAKIYE = sonbakiye;
                 db.SaveChanges();
                 }
             }*/


            if (gorme == true)
            {
                modelimiz yenimodel = new modelimiz();
                yenimodel.cARI_KOD1s = db.CARI_KOD1.ToList();
                yenimodel.cARI_KOD2s = db.CARI_KOD2.ToList();
                Disposedb(); ;
                return View(yenimodel);
            }
            else
            {
                return Redirect("/Home");
            }
        }


        public ActionResult RadzenBlazor(string id)
        {
            changestring();

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Raporlar/"),"Report1.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;

            }
            else
            {
                return View("Index");

            }
            List<CARI_BASLIK> cm = new List<CARI_BASLIK>();
            cm = db.CARI_BASLIK.ToList();
            ReportDataSource RD = new ReportDataSource("Cariler",cm);
            lr.DataSources.Add(RD);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceinfo = @"<DeviceInfo>" + "<OutputFormat>" + id + "</OutputFormat>" + "<PageWidth>8.5in</PageWidth>" + "<PageHeight>11in</PageHeight>" + "<MarginTop>0.5in</MarginTop></DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = lr.Render(
                reportType, deviceinfo, out mimeType, out encoding, out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType);
        }
       

        public class modelimiz
        {
            public CARI_BASLIK Cari { get; set; }
            public CARI_HAREKET Hareket { get; set; }
            public KUR_BASLIK Kur { get; set; }

            public IEnumerable<CARI_BASLIK> cARI_BASLIKs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<ILILCE> ILILCEs { get; set; }
            public IEnumerable<ULKELER> ULKELERs { get; set; }
            public IEnumerable<VERGIDAIRE> vERGIDAIREs { get; set; }
            public IEnumerable<FIRMA> fIRMAs { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> SORUMLULUK_MERKEZIs { get; set; }
            public IEnumerable<STOK> STOKs { get; set; }
            public IEnumerable<CARI_FIYAT> CARI_FIYATs { get; set; }
            public IEnumerable<CARI_KOD1> cARI_KOD1s { get; set; }
            public IEnumerable<CARI_KOD2> cARI_KOD2s { get; set; }
        }

        // GET: CARI_BASLIK/Create
        public ActionResult Create()
        {
            changestring();
            var yenimodel = new modelimiz();
            yenimodel.Cari = new CARI_BASLIK();
            yenimodel.Kur = new KUR_BASLIK();
            yenimodel.ULKELERs = anddb.ULKELER.ToList();
            yenimodel.cARI_BASLIKs = db.CARI_BASLIK.Where(x => x.deleted == null && x.AKTIF == 1);
            yenimodel.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.Aktif == true);
            yenimodel.SORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.ToList();
            yenimodel.ILILCEs = anddb.ILILCE.ToList();
            yenimodel.vERGIDAIREs = anddb.VERGIDAIRE.ToList();
            yenimodel.fIRMAs = db.FIRMA.ToList();
            yenimodel.cARI_KOD1s = db.CARI_KOD1.ToList();
            yenimodel.cARI_KOD2s = db.CARI_KOD2.ToList();
            if (ekleme == true)
            {

                return View(yenimodel);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: CARI_BASLIK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        public double caribakiyehesapla(int id)
        {
            double bakiye = 0;

            var hareketliste = db.CARI_HAREKET.Where(x => x.cariID == id).ToList();

            foreach (var item in hareketliste)
            {
                if (item.ALACAK == null)
                {
                    bakiye -= 0;
                }
                else {
                    bakiye -= (double)item.ALACAK;
                }
                if (item.BORC == null)
                {
                    bakiye += 0;
                }
                else
                {
                    bakiye += (double)item.BORC;
                }

            }
            return bakiye;

        }

        public class CariAraViewModel
        {
            public int ID { get; set; }
            public string FIRMAUNVANI { get; set; }
            public string CARIKOD { get; set; }
            public string MUHATAPADI { get; set; }
            public string ISIL { get; set; }
            public string ISTEL { get; set; }
            public string BAKIYE { get; set; }
            public string DOVIZBAKIYE { get; set; }
        }
        public class OzelFiyatModel
        {


            public string STOKKOD { get; set; }
            public string FIYAT { get; set; }
            public string ORAN { get; set; }

        }
        [HttpPost]
        public JsonResult özelkodolustur(string kod, int kodtürü)
        {
            changestring();
            if (kodtürü == 1)
            {
                var kod1 = new CARI_KOD1();
                kod1.CreateDate = DateTime.Now;
                kod1.CreateUserID = userid;
                kod1.KOD = kod;
                db.CARI_KOD1.Add(kod1);
            }
            if (kodtürü == 2)
            {
                var kod2 = new CARI_KOD2();
                kod2.CreateDate = DateTime.Now;
                kod2.CreateUserID = userid;
                kod2.KOD = kod;
                db.CARI_KOD2.Add(kod2);
            }


            db.SaveChanges();

            Disposedb(); ;
            return Json("Başarılı", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult aradevirolustur(string borcmiktar, string alacakmiktar, string carikod)
        {
            changestring();
            var hareket = new CARI_HAREKET();
            var cari = db.CARI_BASLIK.Where(x => x.CARIKOD == carikod).FirstOrDefault();
            hareket.CreateDate = DateTime.Now;
            hareket.CreateUserID = userid;
            hareket.VADE = DateTime.Now;
            hareket.ACIKLAMA = "AraDevir";
            hareket.ISLEMTURU = CARI_HAREKET.tür.Devir;
            hareket.KAYITSEKLI = CARI_HAREKET_AYRINTI.detay.Nakit;
            hareket.TIPI = CARI_HAREKET.tip.Devir;
            hareket.TARIHSAAT = DateTime.Now;
            hareket.S_MERKEZIID = db.SORUMLULUK_MERKEZI.FirstOrDefault().ID;
            hareket.CARIKOD = carikod;
            hareket.cari = cari;
            if (cari.PARABIRIMI != "TRY")
            {
                hareket.DOVIZBORC = double.Parse(borcmiktar.Replace(".", ","));
                hareket.DOVIZALACAK = double.Parse(alacakmiktar.Replace(".", ","));
                cari.TOPLAMDOVIZBORC += hareket.DOVIZBORC;
                cari.TOPLAMDOVIZALACAK += hareket.DOVIZALACAK;

            }
            else
            {
                hareket.BORC = double.Parse(borcmiktar.Replace(".", ","));
                hareket.ALACAK = double.Parse(alacakmiktar.Replace(".", ","));
                cari.TOPLAMBORC += hareket.BORC;
                cari.TOPLAMALACAK += hareket.ALACAK;
            }
            db.CARI_HAREKET.Add(hareket);
            db.SaveChanges();

            Disposedb(); ;
            return Json("Başarılı", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult ozelfiyat(int CARIID, List<OzelFiyatModel> model)
        {
            changestring();
            var özelfiyat = new CARI_FIYAT();

            if (model.Count == 0)
            {
                Disposedb(); ;
                return Json("Eksik yada Hatalı Veri Girildi", JsonRequestBehavior.AllowGet);
            }
            else {
                var carikod = db.CARI_BASLIK.Find(CARIID).CARIKOD;
                db.CARI_FIYAT.RemoveRange(db.CARI_FIYAT.Where(x => x.CARI_BASLIK.ID == CARIID));
                db.CARI_BASLIK.Find(CARIID).CARI_FIYAT.Clear();
                foreach (var item in model)
                {
                    if (db.STOK.Where(x => x.STOKKODU == item.STOKKOD).FirstOrDefault().CARI_FIYAT.Where(x => x.CARIKOD == carikod).Count() > 0)
                        db.STOK.Where(x => x.STOKKODU == item.STOKKOD).FirstOrDefault().CARI_FIYAT.Remove(db.STOK.Where(x => x.STOKKODU == item.STOKKOD).FirstOrDefault().CARI_FIYAT.Where(x => x.CARIKOD == carikod).FirstOrDefault());
                    özelfiyat.CARIKOD = db.CARI_BASLIK.Find(CARIID).CARIKOD;
                    özelfiyat.CARI_BASLIK = db.CARI_BASLIK.Find(CARIID);
                    özelfiyat.FIYAT = double.Parse(item.FIYAT);
                    özelfiyat.ORAN = double.Parse(item.ORAN);
                    özelfiyat.CreateDate = DateTime.Now;
                    özelfiyat.CreateUserID = userid;
                    özelfiyat.STOKKOD = item.STOKKOD;
                    özelfiyat.STOK = db.STOK.Where(x => x.STOKKODU == item.STOKKOD).FirstOrDefault();
                    db.CARI_FIYAT.Add(özelfiyat);
                    db.CARI_BASLIK.Find(CARIID).CARI_FIYAT.Add(özelfiyat);
                    db.STOK.Where(x => x.STOKKODU == item.STOKKOD).FirstOrDefault().CARI_FIYAT.Add(özelfiyat);
                    db.SaveChanges();
                }
                Disposedb(); ;
                return Json("Başarılı", JsonRequestBehavior.AllowGet);
            }

        }



        [HttpPost]
        public JsonResult caribilgigetir(int CARIID)
        { changestring();
          var cari=  db.CARI_BASLIK.Find(CARIID);
            Disposedb();
            return Json(cari);
        }


            [HttpPost]
        public JsonResult GetData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
        {


            var start = offset;
            var length = limit;
            var sortcolumn = "";
            if (sort != null)
                sortcolumn = sort;
            var sortColumnDir = order;
            int pagesize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;
            changestring();
            List<CariAraViewModel> hareketler = new List<CariAraViewModel>();





            var arama = search.ToLower(new CultureInfo("tr-TR", false));


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "FIRMAUNVANI";
            aranacaklar[1] = "CARIKOD";

            var kultur = "tr-TR";

            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";

            int b = 0;
            if (filterler != null) {


                for (int i = 0; i < filterler.Length; i++)
                {

                    if (i == 0)
                        query += "&&(";
                    if (i > 0)
                        if (filterler[i].filtretipi != 2)
                        {
                            query += "&&";

                        }




                    if (filterler[i].filtretipi == 1)
                        query += $"{  filterler[i].verismi }.ToLower().Contains(\"{ filterler[i].deger.ToLower() }\")";
                    if (filterler[i].filtretipi == 2)
                    {
                        if (b == 0)
                        {
                            query += "&&(";
                        }
                        if (b > 0)
                            query += "||";

                        var deger = int.Parse(filterler[i].deger);
                        if (deger == 0)
                        {
                            query += $"{  filterler[i].verismi }!={1}";
                        }
                        else
                        {

                            query += $"{  filterler[i].verismi }=={ deger}";
                        }


                        b += 1;
                        if ((i + 1) < filterler.Length)
                        {
                            if (filterler[i + 1].filtretipi != 2)
                            {
                                query += ")";
                            }
                        }
                        else
                        {
                            query += ")";
                        }
                    }
                    if (filterler[i].filtretipi == 3)
                    {
                        var kucuk = double.Parse(filterler[i].deger);
                        var buyuk = double.Parse(filterler[i].deger2);
                        if (filterler[i].deger == "0" && filterler[i].deger2 == "0")
                        {
                            query += "(5==5)";
                        }
                        else {
                            query += $"{  filterler[i].verismi }>{ kucuk }&&{  filterler[i].verismi }<{ buyuk }";
                        }


                    }

                    if (filterler[i].filtretipi == 4)
                    {

                        var zaman = DateTime.ParseExact(filterler[i].deger, "MM/dd/yyyy", null);
                        var sonzaman = DateTime.ParseExact(filterler[i].deger2, "MM/dd/yyyy", null);
                        query += $"DbFunctions.TruncateTime({  filterler[i].verismi })>(\"{zaman}\")&&DbFunctions.TruncateTime({  filterler[i].verismi })<(\"{sonzaman}\")";
                    }
                    if (filterler[i].filtretipi == 5)
                    {
                        int gelen = int.Parse(filterler[i].deger);

                        switch (gelen) {
                            case 0: query += $"5==5"; break;
                            case 1: query += $"{  filterler[i].verismi }>{ 0 }"; break;
                            case 2: query += $"{  filterler[i].verismi }<{ 0 }"; break;
                            case 3: query += $"{  filterler[i].verismi }!=null"; break;
                        }




                    }

                    if (filterler[i].filtretipi == 6)
                    {
                        var deger = filterler[i].deger;
                        query += $"{filterler[i].verismi}==\"{ filterler[i].deger}\"";
                    }

                }

                query += ")";
            }



            var v = (from a in db.CARI_BASLIK.Where(x => x.deleted != 1).ToList().Where(query) select a);


            if (!(string.IsNullOrEmpty(sortcolumn)) && !(string.IsNullOrEmpty(sortColumnDir)))
            {
                v = v.OrderBy(sort + " " + sortColumnDir);
            }
            else
            {
                v = v.OrderByDescending(x => x.CreateDate);
            }

            var data = v.Skip(offset).Take(limit).ToList();
            totalRecords = v.Count();
            foreach (var item in data)
            {


                var yenihareket = new CariAraViewModel();

                yenihareket.ID = item.ID;
                if (!string.IsNullOrEmpty(item.FIRMAUNVANI))
                    yenihareket.FIRMAUNVANI = item.FIRMAUNVANI;
                if (!string.IsNullOrEmpty(item.CARIKOD))
                    yenihareket.CARIKOD = item.CARIKOD;

                if (!string.IsNullOrEmpty(item.MUHATAPADI))
                    yenihareket.MUHATAPADI = item.MUHATAPADI.ToString();
                if (!string.IsNullOrEmpty(item.ISIL))
                    yenihareket.ISIL = item.ISIL.ToString();
                if (!string.IsNullOrEmpty(item.ISTEL))
                    yenihareket.ISTEL = item.ISTEL.ToString();

                yenihareket.BAKIYE = item.BAKIYE.ToString();
                if (item.PARABIRIMI != "TRY")
                    yenihareket.DOVIZBAKIYE = item.DOVIZBAKIYE.ToString() + " " + item.PARABIRIMI;
                else
                {
                    yenihareket.DOVIZBAKIYE = "0";
                }
                hareketler.Add(yenihareket);



            }

            Disposedb(); ;
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        public class select {
            public string id { get; set; }

            public string text { get; set; }


        }
        public class selectid
        {
            public int id { get; set; }
            public string text { get; set; }
        }
        public JsonResult getcarid(string term, string _type, string q)
        {



            changestring();
            List<selectid> hareketler = new List<selectid>();









            var data = db.CARI_BASLIK.Where(x => x.AKTIF == 1 && x.deleted != 1).Where(x => x.CARIKOD.ToLower().Contains(term.ToLower()) || x.FIRMAUNVANI.ToLower().Contains(term.ToLower()) && x.AKTIF == 1).Take(10).ToList();


            foreach (var item in data)
            {


                var yenihareket = new selectid();

                yenihareket.id = item.ID;
                if (!string.IsNullOrEmpty(item.FIRMAUNVANI))
                    yenihareket.text = item.CARIKOD + " / " + item.FIRMAUNVANI;



                hareketler.Add(yenihareket);



            }
            Disposedb(); ;

            return Json(hareketler, JsonRequestBehavior.AllowGet);






        }

        public class duraganrapormodel
        {
            public List<CARI_BASLIK> cariler { get; set; }
            public List<CARI_HAREKET> hareketler { get; set; }
        }

        public ActionResult duragancarirapor()
        {
            changestring();
            var model = new duraganrapormodel();
            var cariler = new List<CARI_BASLIK>();


            var hareketler = new List<CARI_HAREKET>();
            var time = DateTime.Now.AddDays(-1);

            cariler = db.CARI_BASLIK.Where(x => x.CARI_HAREKETs.Where(c => c.TARIHSAAT >= time).Count() == 0).ToList();
            foreach (var item in cariler)
            {
                var id = item.ID;
                var hari = db.CARI_HAREKET.Where(x => x.cariID == id).ToList().OrderBy(x => x.TARIHSAAT).LastOrDefault();
                hareketler.Add(hari);
            }

            model.cariler = cariler;
            model.hareketler = hareketler;
          
                return View(model);

           
           
        }
        [HttpPost]
        public JsonResult duragancariraporjson(int gun)
        {
            changestring();

            var model = new duraganrapormodel();
            var cariler = new List<CARI_BASLIK>();


            var hareketler = new List<CARI_HAREKET>();
            var time = DateTime.Now.AddDays(-gun);

            cariler = db.CARI_BASLIK.Where(x => x.CARI_HAREKETs.Where(c => c.TARIHSAAT >= time).Count() == 0).ToList();
            foreach (var item in cariler) {
                var id = item.ID;
                var hari = db.CARI_HAREKET.Where(x => x.cariID == id).ToList().OrderBy(x => x.TARIHSAAT).LastOrDefault();
                hareketler.Add(hari);
            }

            model.cariler = cariler;
            model.hareketler = hareketler;
            Session["Rapora"] = model;
            Disposedb(); ;
            return Json("Başarılı");
        }

        public JsonResult getcari(string term, string _type, string q)
        {



            changestring();
            List<select> hareketler = new List<select>();





            var data = new List<CARI_BASLIK>();


            if (string.IsNullOrEmpty(term))
                data = db.CARI_BASLIK.Where(x => x.AKTIF == 1).Take(10).ToList();
            else
                data = db.CARI_BASLIK.Where(x => x.CARIKOD.ToLower().Contains(term.ToLower()) || x.FIRMAUNVANI.ToLower().Contains(term.ToLower()) && x.AKTIF == 1).Take(10).ToList();



            foreach (var item in data)
            {


                var yenihareket = new select();

                yenihareket.id = item.CARIKOD;
                if (!string.IsNullOrEmpty(item.FIRMAUNVANI))
                    yenihareket.text = item.CARIKOD + " / " + item.FIRMAUNVANI;



                hareketler.Add(yenihareket);



            }

            Disposedb(); ;
            return Json(hareketler, JsonRequestBehavior.AllowGet);






        }
        public class infomodel{
            public FIRMA firma { get; set; }
            public CARI_BASLIK cari { get; set; }

}

        [HttpPost]
        public JsonResult getcariinfo(int kod)
        {



            changestring();

            var model = new infomodel();



            model.cari = db.CARI_BASLIK.Find(kod);
            model.firma = db.FIRMA.FirstOrDefault();


            Disposedb();;

            return Json(model, JsonRequestBehavior.AllowGet);
         








        }
        [HttpPost]
        public JsonResult getparabirimi(int kod)
        {



            changestring();

          
            return Json(new { parabirimi=db.CARI_BASLIK.Where(x => x.ID == kod).FirstOrDefault().PARABIRIMI }, JsonRequestBehavior.AllowGet);

            
        }

        [HttpPost]
        public JsonResult getcaritipi(int kod)
        {



            changestring();
            var a = "EFATURA MÜKELLEFİ DEĞİL";
            var cari = db.CARI_BASLIK.Where(x => x.ID == kod).FirstOrDefault();
            if (!string.IsNullOrEmpty(cari.gibpk))
            {
                
                a=cari.gibpk;
              
            }
            if (cari.Mükelleftipi == CARI_BASLIK.mükelleftipi.İhracat)
                a = "İHRACAT";

            return Json( a , JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult kodgetir(string kod)
        {
            changestring();
            if (string.IsNullOrEmpty(kod))
            {
                int sayi= db.CARI_BASLIK.Where(x => x.CARIKOD.Contains("CARİ")).Count()+1;
                Disposedb();;
                return Json("CARİ"+sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);

            }
            else
            {
                int sayi = db.CARI_BASLIK.Where(x => x.CARIKOD.Contains(kod)).Count() + 1;
                Disposedb();;

                return Json( kod + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);
            }

        }

        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }






        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Cari,Hareket")] modelimiz cARI_BASLIK )
        {
           
            changestring();
            if (ModelState.IsValid&&db.CARI_BASLIK.Where(x => x.CARIKOD == cARI_BASLIK.Cari.CARIKOD).Count() == 0)
            {
               
                              cARI_BASLIK.Cari.CreateDate = DateTime.Now;
                cARI_BASLIK.Cari.CreateUserID = userid;
  
                      if (cARI_BASLIK.Hareket.KUR == null)
                {

                    cARI_BASLIK.Hareket.KUR = 0;
                }
                if (cARI_BASLIK.Hareket.ALACAK == null)
                {

                    cARI_BASLIK.Hareket.ALACAK = 0;
                }
                if (cARI_BASLIK.Hareket.BORC == null)
                {

                    cARI_BASLIK.Hareket.BORC = 0;
                }

                cARI_BASLIK.Cari.TOPLAMALACAK= cARI_BASLIK.Hareket.ALACAK;
                cARI_BASLIK.Cari.TOPLAMBORC = cARI_BASLIK.Hareket.BORC;


                if (cARI_BASLIK.Hareket.PARABIRIMI != "TRY") { 
                if (cARI_BASLIK.Hareket.BORC != 0)
                    cARI_BASLIK.Cari.TOPLAMDOVIZBORC = cARI_BASLIK.Hareket.BORC;
                else
                {
                    cARI_BASLIK.Cari.TOPLAMDOVIZBORC = 0;
                }
                if (cARI_BASLIK.Hareket.ALACAK != 0)
                    cARI_BASLIK.Cari.TOPLAMDOVIZALACAK = cARI_BASLIK.Hareket.ALACAK ;
                    else
                {
                    cARI_BASLIK.Cari.TOPLAMDOVIZALACAK = 0;
                }
                  

                    cARI_BASLIK.Hareket.DOVIZALACAK = cARI_BASLIK.Hareket.ALACAK ;
                    cARI_BASLIK.Hareket.DOVIZBORC = cARI_BASLIK.Hareket.BORC;
                    cARI_BASLIK.Hareket.ALACAK = cARI_BASLIK.Hareket.ALACAK * cARI_BASLIK.Hareket.KUR;
                    cARI_BASLIK.Hareket.BORC = cARI_BASLIK.Hareket.BORC * cARI_BASLIK.Hareket.KUR;
                }
          
                    db.CARI_BASLIK.Add(cARI_BASLIK.Cari);
                db.SaveChanges();
           
                    cARI_BASLIK.Hareket.cariID = cARI_BASLIK.Cari.ID;
                cARI_BASLIK.Hareket.CreateUserID = userid;
                cARI_BASLIK.Hareket.CreateDate= DateTime.Now;
          
                cARI_BASLIK.Hareket.TIPI = CARI_HAREKET.tip.Devir;
                cARI_BASLIK.Hareket.ISLEMTURU = CARI_HAREKET.tür.Devir;
                cARI_BASLIK.Hareket.ACIKLAMA = "Devir";
                cARI_BASLIK.Hareket.S_MERKEZIID = 1;
             cARI_BASLIK.Hareket.CARIKOD = cARI_BASLIK.Cari.CARIKOD;
           
            

                db.CARI_HAREKET.Add(cARI_BASLIK.Hareket);
                db.SaveChanges();

                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                Disposedb();; return jsonResult;
            }


            Disposedb();;
            return Json(cARI_BASLIK);
        }

        public void veritesti()
        {
            var cARI_BASLIK = new CARI_BASLIK();
            var hareket = new CARI_HAREKET();
            changestring();
            for(int i = 1017; i < 10000; i++) {

                cARI_BASLIK.CARIKOD = "Üretil" + i;
                cARI_BASLIK.CreateDate = DateTime.Now;
                cARI_BASLIK.CreateUserID = userid;
                cARI_BASLIK.FIRMAUNVANI =  i+ "'Cari";
                db.CARI_BASLIK.Add(cARI_BASLIK);
                db.SaveChanges();


              

            }
           ViewBag.Title="Başarılı";
        }

        // GET: CARI_BASLIK/Edit/5
        public ActionResult Edit(int? id)
        {
            changestring();
            var yenimodel = new modelimiz();
            yenimodel.Cari = db.CARI_BASLIK.Where(x => x.ID == id).First();
            yenimodel.Kur = new KUR_BASLIK();
            yenimodel.Hareket = db.CARI_HAREKET.Where(x => x.CARIKOD == yenimodel.Cari.CARIKOD && x.TIPI == CARI_HAREKET.tip.Devir).FirstOrDefault();
            yenimodel.cARI_BASLIKs = db.CARI_BASLIK.Where(x=>x.deleted==null&&x.AKTIF==1);
            yenimodel.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.Aktif == true);
            yenimodel.ILILCEs = anddb.ILILCE;
            yenimodel.ULKELERs = anddb.ULKELER.ToList();
            yenimodel.vERGIDAIREs = anddb.VERGIDAIRE;
            yenimodel.STOKs = db.STOK.ToList();
            yenimodel.cARI_KOD1s = db.CARI_KOD1.ToList();
            yenimodel.cARI_KOD2s = db.CARI_KOD2.ToList();
            yenimodel.CARI_FIYATs = db.CARI_FIYAT.Where(x => x.CARI_BASLIK.ID == id).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARI_BASLIK cARI_BASLIK = db.CARI_BASLIK.Find(id);

       
            if (cARI_BASLIK == null)
            {
                return HttpNotFound();
            }
            if (degistirme == true)
            {
                return View(yenimodel);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: CARI_BASLIK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cari")] modelimiz cARI_BASLIK)
        {
            changestring();
            if (ModelState.IsValid)
            {
                cARI_BASLIK.Cari.UpdateDate = DateTime.Now;
                cARI_BASLIK.Cari.UpdateUserID = userid;
                db.Entry(cARI_BASLIK.Cari).State = EntityState.Modified;
                db.SaveChanges();
                return Json("/");
            }
            return Json(cARI_BASLIK);
        }

        // GET: CARI_BASLIK/Delete/5
        public ActionResult Delete(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARI_BASLIK cARI_BASLIK = db.CARI_BASLIK.Find(id);
            if (cARI_BASLIK == null)
            {
                return HttpNotFound();
            }
            return View(cARI_BASLIK);
        }

        // POST: CARI_BASLIK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            changestring();
            CARI_BASLIK cARI_BASLIK = db.CARI_BASLIK.Find(id);
            db.CARI_BASLIK.Remove(cARI_BASLIK);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {  
            if (disposing)
            {
                Disposedb();;
            }
            base.Dispose(disposing);
        }
    }
}
