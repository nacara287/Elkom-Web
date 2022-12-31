using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using And.ElkomMuhasebe.Core.Model;
using And.ElkomMuhasebe.Core.Model.Entity.FirmaDB;
using System.Linq.Dynamic.Core;

using System.Data.Entity;
using DbFunctions = System.Data.Entity.DbFunctions;
using EntityState = System.Data.Entity.EntityState;
using System.Globalization;
using System.Data.Entity.SqlServer;
namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class PERSONEL_HAREKETController : Controller
    {
        private FirmaBaseDB db = new FirmaBaseDB();
        public int userid = 0;
        public bool ekleme = false;
        public bool degistirme = false;
        public bool silme = false;
        public bool gorme = false;
        public void changestring()
        {
            if ((Session["LoginUser"] == null || Session["SeciliFirma"] == null) && (Session["LoginAltUser"] == null || Session["SeciliFirma"] == null)) { Response.Redirect("/Home"); }
            else
            {
                if (Session["LoginAltUser"] != null)
                {
                    var alt = Session["LoginAltUser"] as And.ElkomMuhasebe.Core.Model.Entity.Admin.AltUser;
                    userid = alt.ID;
                    if (alt.görme.Contains("Personel Hareketleri Ve Fişleri"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Personel Hareketleri Ve Fişleri"))
                            ekleme = true;
                        if (alt.silme.Contains("Personel Hareketleri Ve Fişleri"))
                            silme = true;
                        if (alt.degistir.Contains("Personel Hareketleri Ve Fişleri"))
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
        // GET: PERSONEL_HAREKET
        public ActionResult Index(int id)
        {
            changestring();
            var model = new CARI_HAREKETController.yenimodel();
            model.ismi = db.PERSONEL.Find(id).ADISOYADI;
            model.kodu = db.PERSONEL.Find(id).PERSONELKODU;
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.ToList();
            model.id = id;
            if (gorme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        public ActionResult Genel()
        {
            changestring();
            var model = new CARI_HAREKETController.yenimodel();

            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.ToList();
            if (gorme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }

        public class bankahareketaraviewmodel
        {
            public int ID { get; set; }
            public string PERSONELKODU { get; set; }
            public string PERSONELADI { get; set; }
            public string ADSOYAD { get; set; }
            public string TARIHSAAT { get; set; }
 
            public string TURU { get; set; }
            public string DETAY { get; set; }
            public string TIPI { get; set; }
            public string DOSYANO { get; set; }
            public string ACIKLAMA { get; set; }
            public double? BORC { get; set; }
            public double? ALACAK { get; set; }
            public double? BAKIYE { get; set; }
            public string S_MERKEZI { get; set; }
        }
        public class modelimiz
        {

            public bool print { get; set; }
            public IEnumerable<PERSONEL> PERSONELS { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<PERSONEL_HAREKET> PERSONEL_HAREKETs { get; set; }
            public IEnumerable<PERSONEL_HAREKETTIPLERI> PERSONEL_HAREKETTIPLERI { get; set; }
            public PERSONEL_FISI fis { get; set; }
            public PERSONEL_MAAS_TAHAKKUK fistahakkuk { get; set; }
            public int PERSONEL_FISIS { get; set; }
            public int PERSONEL_MAAS_TAHAKKUKS { get; set; }
            public IEnumerable<PERSONEL_MAAS_TAHAKKUK_HAREKET> PERSONEL_MAAS_TAHAKKUK_HAREKETS { get; set; }
            public IEnumerable<PERSONEL_FISI_HAREKET> PERSONEL_FISI_HAREKETs { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }
            public IEnumerable<KASA> KASA { get; set; }
            public IEnumerable<FIRMA> fIRMAs { get; set; }
        }
        public class carifismodel
        {


            public string PERSONELKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string MAASTUTAR { get; set; }
            public string MAASGUNU { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }

            public List<carifismodelhareket> gelenhareket { get; set; }



        }
        public class tahakkukfismodel
        {


            public string PERSONELKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public int DONEM { get; set; }
            public string MAAS { get; set; }
            public string MAASTUTAR { get; set; }
            public string MAASGUNU { get; set; }
            public string TOPLAMTAHAKUK { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }

            public List<tahakkukmodelhareket> gelenhareket { get; set; }



        }
        public class tahakkukmodelhareket
        {


            public string HAREKET { get; set; }

      

            public string ACIKLAMA { get; set; }

            public string MIKTAR { get; set; }
            public string FIYAT { get; set; }

            public string BIRIM { get; set; }
    

 
            public string NETTUTAR { get; set; }
        }
        public class carifismodelhareket
        {


            public string HAREKET { get; set; }

            public string KASA { get; set; }
          
            public string ACIKLAMA { get; set; }

            public string TUTAR { get; set; }


            public string PARABIRIMI { get; set; }
            public string PARAKURU { get; set; }
            public string NETTUTAR { get; set; }
        }
        [HttpPost]
        public JsonResult GetData(string search, string order, int offset, int limit, string sort, int id, filtermodel[] filterler)
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
            List<bankahareketaraviewmodel> hareketler = new List<bankahareketaraviewmodel>();

            var zaman = new DateTime();
            var sonzaman = new DateTime();


            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[4];

            aranacaklar[0] = "hareket.DOSYANO";
            aranacaklar[1] = "hareket.ACIKLAMA";
            aranacaklar[2] = "hareket.PERSONELKODU";
            aranacaklar[3] = "PERSONELADI";


            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";
            if (id != 0)
            {
                query += $"&&({"hareket.PERSONELID"}=={ id })";
            }

            if (filterler.Length > 0)


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
                        if (filterler[i - 1].filtretipi != 2 || filterler[i - 1].verismi != filterler[i].verismi)
                        {
                            query += "&&(";
                        }
                        else
                        {
                            query += "||";
                        }




                        var deger = int.Parse(filterler[i].deger);
                        query += $"{  filterler[i].verismi }=={ deger}";


                        if ((i + 1) < filterler.Length)
                        {
                            if (filterler[i + 1].filtretipi != 2 || filterler[i + 1].verismi != filterler[i].verismi)
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
                            query += $"{  filterler[i].verismi }>{ -10000000 }";
                        }
                        else
                        {
                            query += $"{  filterler[i].verismi }>{ kucuk }&&{  filterler[i].verismi }<{ buyuk }";
                        }


                    }
                    if (filterler[i].filtretipi == 4)
                    {
                        zaman = DateTime.ParseExact(filterler[i].deger, "MM/dd/yyyy", null);
                        sonzaman = DateTime.ParseExact(filterler[i].deger2, "MM/dd/yyyy", null);
                        query += "(5==5)";
                    }

                   
                }

            query += ")";




            var v = (from a in db.PERSONEL_HAREKET.Select(pr => new
            {
                hareket = pr,
                PERSONELADI = pr.PERSONEL.ADISOYADI,

                S_MERKEZI = pr.S_MERKEZI.ACIKLAMA
            }).Where(x => x.hareket.deleted != 1).Where(x => DbFunctions.TruncateTime(x.hareket.TARIHSAAT) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.TARIHSAAT) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);


            if (!(string.IsNullOrEmpty(sortcolumn)) && !(string.IsNullOrEmpty(sortColumnDir)))
            {
                v = v.OrderBy(sort + " " + sortColumnDir);
            }
            else
            {
                v = v.OrderByDescending(x => x.hareket.CreateDate);
            }
            var data = v.Skip(offset).Take(limit).ToList();
            totalRecords = v.Count();
            foreach (var item in data)
            {


                var yenihareket = new bankahareketaraviewmodel();

                yenihareket.ID = item.hareket.ID;
                if (id == 0)
                {

                    yenihareket.PERSONELKODU = item.hareket.PERSONELKODU;
                    yenihareket.PERSONELADI = item.PERSONELADI;

                }
                else
                {

                    yenihareket.PERSONELKODU = "";
                }
                yenihareket.TARIHSAAT = item.hareket.TARIHSAAT.ToShortDateString();
                yenihareket.TURU = item.hareket.TURU.ToString();
                yenihareket.DETAY = item.hareket.DETAY.ToString();
                yenihareket.TIPI = item.hareket.TIPI.ToString();
                yenihareket.DOSYANO = item.hareket.DOSYANO.ToString();

                if (!string.IsNullOrEmpty(item.hareket.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.hareket.ACIKLAMA;
                else { yenihareket.ACIKLAMA = ""; }

                yenihareket.BORC = item.hareket.BORC;
                yenihareket.ALACAK = item.hareket.ALACAK;
                yenihareket.BAKIYE = item.hareket.BAKIYE;
                yenihareket.S_MERKEZI = item.S_MERKEZI;
                hareketler.Add(yenihareket);



            }

            db.Dispose();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
     
        
        public ActionResult PERSONELTAHAKUK()
        {
            changestring();
            var model = new modelimiz();
            model.PERSONEL_HAREKETTIPLERI = db.PERSONEL_HAREKETTIPLERI.ToList();
            model.PERSONEL_MAAS_TAHAKKUKS = db.PERSONEL_MAAS_TAHAKKUK.Count();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.ToList();
        
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
     
            if (ekleme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public ActionResult PERSONELTAHAKKUKKART(int id,bool? print)
        {
            changestring();
            var model = new modelimiz();
            if (print != null)
                model.print = (bool)print;
            model.PERSONEL_HAREKETTIPLERI = db.PERSONEL_HAREKETTIPLERI.ToList();


            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
       
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.fistahakkuk = db.PERSONEL_MAAS_TAHAKKUK.Include(x => x.PERSONEL).SingleOrDefault(x => x.ID == id);

            model.PERSONEL_MAAS_TAHAKKUK_HAREKETS = db.PERSONEL_MAAS_TAHAKKUK_HAREKET.Where(x => x.PERSONEL_MAAS_TAHAKKUKID == id).ToList();



            if (degistirme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public ActionResult PERSONELFIS()
        {
            changestring();
            var model = new modelimiz();
           
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.ToList();
            model.PERSONEL_FISIS = db.PERSONEL_FISI.Count();
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.PERSONEL_HAREKETTIPLERI = db.PERSONEL_HAREKETTIPLERI.ToList();
            if (ekleme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public ActionResult PERSONELFISKART(int id,bool? print)
        {
            changestring();
            var model = new modelimiz();
            if (print != null)
                model.print = (bool)print;

            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();

            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.PERSONEL_HAREKETTIPLERI = db.PERSONEL_HAREKETTIPLERI.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.fis = db.PERSONEL_FISI.Include(x => x.PERSONEL).SingleOrDefault(x => x.ID == id);
            model.PERSONEL_FISI_HAREKETs = db.PERSONEL_FISI_HAREKET.Where(x => x.PERSONELID== id).ToList();



            if (degistirme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        public ActionResult PERSONELLISTE()
        {
            changestring();
            if (gorme == true)
            {
                return View();
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public ActionResult PERSONELTAHAKKUKLISTE()
        {
            changestring();

            if (gorme == true)
            {
                return View();
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public class FisaravieweNodel
        {
            public int ID { get; set; }
            public string PERSONELKODU { get; set; }
            public string PERSONELADI { get; set; }
            
            public string FISNO { get; set; }
            public string TIP { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string TOPLAMTUTAR { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
        }
        [HttpPost]
        public JsonResult FisData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
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
            List<FisaravieweNodel> hareketler = new List<FisaravieweNodel>();
            var zaman = new DateTime();
            var sonzaman = new DateTime();



            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[3];

            aranacaklar[0] = "hareket.PERSONELKODU";
            aranacaklar[1] = "hareket.FISNO";
            aranacaklar[2] = "PERSONELADI";



            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";


            if (filterler.Length > 0)


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
                        if (filterler[i - 1].filtretipi != 2 || filterler[i - 1].verismi != filterler[i].verismi)
                        {
                            query += "&&(";
                        }
                        else
                        {
                            query += "||";
                        }




                        var deger = int.Parse(filterler[i].deger);
                        query += $"{  filterler[i].verismi }=={ deger}";


                        if ((i + 1) < filterler.Length)
                        {
                            if (filterler[i + 1].filtretipi != 2 || filterler[i + 1].verismi != filterler[i].verismi)
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
                            query += $"(5==5)";
                        }
                        else
                        {
                            query += $"{  filterler[i].verismi }>{ kucuk }&&{  filterler[i].verismi }<{ buyuk }";
                        }


                    }
                    if (filterler[i].filtretipi == 4)
                    {

                         zaman = DateTime.ParseExact(filterler[i].deger, "MM/dd/yyyy", null);
                         sonzaman = DateTime.ParseExact(filterler[i].deger2, "MM/dd/yyyy", null);
                        query += "(5==5)";
                    }

                   
                }

            query += ")";




            var v = (from a in db.PERSONEL_FISI.Select(pr => new
            {
                hareket = pr,
                PERSONELADI = pr.PERSONEL.ADISOYADI,
                SORUMLULUK_MERKEZI=pr.S_MERKEZI.ACIKLAMA

            }).Where(x => x.hareket.deleted != 1).Where(x => DbFunctions.TruncateTime(x.hareket.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query)
                     select a);


            if (!(string.IsNullOrEmpty(sortcolumn)) && !(string.IsNullOrEmpty(sortColumnDir)))
            {
                v = v.OrderBy(sort + " " + sortColumnDir);
            }
            else
            {
                v = v.OrderByDescending(x => x.hareket.CreateDate);
            }
            var data = v.Skip(offset).Take(limit).ToList();
            totalRecords = v.Count();
            foreach (var item in data)
            {


                var yenihareket = new FisaravieweNodel();

                yenihareket.ID = item.hareket.ID;

                yenihareket.PERSONELKODU = item.hareket.PERSONELKODU;
                yenihareket.PERSONELADI = item.PERSONELADI;

                yenihareket.TARIH = item.hareket.TARIH.Value.ToShortDateString();

                if (!string.IsNullOrEmpty(item.hareket.ACIKLAMA))
                    yenihareket.NOT = item.hareket.ACIKLAMA;

                    yenihareket.TIP = "Giriş";
              
              

                if (!string.IsNullOrEmpty(item.hareket.FISNO))
                    yenihareket.FISNO = item.hareket.FISNO;

                yenihareket.TOPLAMTUTAR = item.hareket.TOPLAMTUTAR.ToString();

                yenihareket.SORUMLULUK_MERKEZI = item.SORUMLULUK_MERKEZI;
                hareketler.Add(yenihareket);



            }

            db.Dispose();

            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
        [HttpPost]
        public JsonResult TahakkukFisData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
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
            List<FisaravieweNodel> hareketler = new List<FisaravieweNodel>();



            var zaman = new DateTime();
            var sonzaman = new DateTime();

            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[3];

            aranacaklar[0] = "hareket.PERSONELKODU";
            aranacaklar[1] = "hareket.FISNO";
            aranacaklar[2] = "PERSONELADI";



            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";


            if (filterler.Length > 0)


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
                        if (filterler[i - 1].filtretipi != 2 || filterler[i - 1].verismi != filterler[i].verismi)
                        {
                            query += "&&(";
                        }
                        else
                        {
                            query += "||";
                        }




                        var deger = int.Parse(filterler[i].deger);
                        query += $"{  filterler[i].verismi }=={ deger}";


                        if ((i + 1) < filterler.Length)
                        {
                            if (filterler[i + 1].filtretipi != 2 || filterler[i + 1].verismi != filterler[i].verismi)
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
                            query += $"(5==5)";
                        }
                        else
                        {
                            query += $"{  filterler[i].verismi }>{ kucuk }&&{  filterler[i].verismi }<{ buyuk }";
                        }


                    }
                    if (filterler[i].filtretipi == 4)
                    {

                        zaman = DateTime.ParseExact(filterler[i].deger, "MM/dd/yyyy", null);
                        sonzaman = DateTime.ParseExact(filterler[i].deger2, "MM/dd/yyyy", null);
                        query += "(5==5)";
                    }

                 
                }

            query += ")";




            var v = (from a in db.PERSONEL_MAAS_TAHAKKUK.Select(pr => new
            {
                hareket = pr,
                PERSONELADI = pr.PERSONEL.ADISOYADI,
                SORUMLULUK_MERKEZI = pr.S_MERKEZI.ACIKLAMA

            }).Where(x => x.hareket.deleted != 1).Where(x => DbFunctions.TruncateTime(x.hareket.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query)
                     select a);


          
                v = v.OrderBy(sort + " " + sortColumnDir);
           
            var data = v.Skip(offset).Take(limit).ToList();
            totalRecords = v.Count();
            foreach (var item in data)
            {


                var yenihareket = new FisaravieweNodel();

                yenihareket.ID = item.hareket.ID;


                yenihareket.PERSONELKODU = item.hareket.PERSONELKODU;

                yenihareket.PERSONELADI = item.PERSONELADI;

                yenihareket.TARIH = item.hareket.TARIH.Value.ToShortDateString();

                if (!string.IsNullOrEmpty(item.hareket.ACIKLAMA))
                    yenihareket.NOT = item.hareket.ACIKLAMA;

                yenihareket.TIP = "Çıkış";



                if (!string.IsNullOrEmpty(item.hareket.FISNO))
                    yenihareket.FISNO = item.hareket.FISNO;

                yenihareket.TOPLAMTUTAR = item.hareket.TOPLAMTUTAR.ToString();

                yenihareket.SORUMLULUK_MERKEZI = item.SORUMLULUK_MERKEZI;

                hareketler.Add(yenihareket);



            }
            db.Dispose();

            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
        [HttpPost]
        public JsonResult fissil(int id)
        {
            changestring();
            var fis = db.PERSONEL_FISI.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.PERSONEL_FISI_HAREKET.Where(x => x.PERSONELID == id && x.deleted != 1);

            var kasaharetleri = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
           
            var perseonelhareketler = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1).ToList();
          
            var banka = db.PERSONEL.Where(x => x.ID == fis.PERSONELID).FirstOrDefault();
            var trans = db.Database.BeginTransaction();
            try
            {
                foreach (var item in perseonelhareketler)
                {
                    var personel = db.PERSONEL.Where(x => x.ID == fis.PERSONELID).FirstOrDefault();
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {

                        var eskihareket = new PERSONEL_HAREKET();
                        if (db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }



                        personel.TOPLAMBORC -= carihareket.BORC;


                        foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1))
                        {
                            hareketz.BAKIYE -= carihareket.BORC;


                        }
                        db.SaveChanges();

                    }
                    else
                    {



                        personel.TOPLAMBORC -= carihareket.BORC;

                        db.SaveChanges();


                    }
                    item.deleted = 1;
                    db.SaveChanges();
                }



                foreach (var item in kasaharetleri)
                {
                    var kasa = db.KASA.Where(x => x.KASAKODU == item.KASAKODU).FirstOrDefault();
                    var kasahareket = item;
                    if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new KASA_HAREKET();
                        if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }

                        kasa.TOPLAMALACAK += kasahareket.ALACAK;


                        foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                        {
                            hareketz.BAKIYE += kasahareket.ALACAK;

                        }



                    }
                    else
                    {



                        kasa.TOPLAMALACAK -= kasahareket.ALACAK;



                    }
                    item.deleted = 1;
                    db.SaveChanges();
                }
                var personelharetlerii = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1);
                foreach (var item in personelharetlerii)
                {

                    item.deleted = 1;

                }


                foreach (var item in fishareketleri)
                {
                    item.deleted = 1;
                }
                fis.deleted = 1;
                var kasaharetlerii = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                foreach (var item in kasaharetleri)
                {

                    item.deleted = 1;

                }


                db.SaveChanges();
                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
             

                trans.Commit();
                db.Dispose();
                return jsonResult;

            }
            catch (Exception ex)
            {
                trans.Rollback();
                db.Dispose();
                return Json("Başarısız!");
            }



        }
    
        public void fisiyenile(int id)
        {  
            var fis = db.PERSONEL_FISI.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.PERSONEL_FISI_HAREKET.Where(x => x.PERSONELID == id && x.deleted != 1);

            var kasaharetleri = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();

            var perseonelhareketler = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1).ToList();

            var banka = db.PERSONEL.Where(x => x.ID == fis.PERSONELID).FirstOrDefault();
           
                foreach (var item in perseonelhareketler)
                {
                    var personel = db.PERSONEL.Where(x => x.ID == fis.PERSONELID).FirstOrDefault();
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {

                        var eskihareket = new PERSONEL_HAREKET();
                        if (db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }



                        personel.TOPLAMBORC -= carihareket.BORC;


                        foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1))
                        {
                            hareketz.BAKIYE -= carihareket.BORC;


                        }
                        db.SaveChanges();

                    }
                    else
                    {



                        personel.TOPLAMBORC -= carihareket.BORC;

                        db.SaveChanges();


                    }

                    db.SaveChanges();
                }



                foreach (var item in kasaharetleri)
                {
                    var kasa = db.KASA.Where(x => x.KASAKODU == item.KASAKODU).FirstOrDefault();
                    var kasahareket = item;
                    if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new KASA_HAREKET();
                        if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }

                        kasa.TOPLAMALACAK += kasahareket.ALACAK;


                        foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                        {
                            hareketz.BAKIYE += kasahareket.ALACAK;

                        }



                    }
                    else
                    {



                        kasa.TOPLAMALACAK -= kasahareket.ALACAK;



                    }
                    item.deleted = 1;
                    db.SaveChanges();
                }
                var personelharetlerii = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1);
                db.PERSONEL_HAREKET.RemoveRange(personelharetlerii);





                var kasaharetlerii = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                db.KASA_HAREKET.RemoveRange(kasaharetlerii);
                db.PERSONEL_FISI_HAREKET.RemoveRange(fishareketleri);

                db.SaveChanges();


            




        }
        [HttpPost]
        public JsonResult tahakkukfissil(int id)
        {
            changestring();
            var fis = db.PERSONEL_MAAS_TAHAKKUK.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.PERSONEL_MAAS_TAHAKKUK_HAREKET.Where(x => x.PERSONEL_MAAS_TAHAKKUKID == id && x.deleted != 1);

            var kasaharetleri = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
          
            var perseonelhareketler = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1).ToList();

            var banka = db.PERSONEL.Where(x => x.ID == fis.PERSONELID).FirstOrDefault();

            foreach (var item in perseonelhareketler)
            {
                var personel = db.PERSONEL.Where(x => x.ID == fis.PERSONELID).FirstOrDefault();
                var carihareket = item;
                if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                {

                    var eskihareket = new PERSONEL_HAREKET();
                    if (db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).Count() > 0)
                    {
                        eskihareket = db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                    }
                    else { eskihareket.BAKIYE = 0; }



                    personel.TOPLAMALACAK -= carihareket.ALACAK;


                    foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1))
                    {
                        hareketz.BAKIYE += carihareket.ALACAK;


                    }
                    db.SaveChanges();

                }
                else
                {



                    personel.TOPLAMALACAK -= carihareket.ALACAK;

                    db.SaveChanges();


                }
                item.deleted = 1;
                db.SaveChanges();
            }



            foreach (var item in kasaharetleri)
            {
                var kasa = db.KASA.Where(x => x.KASAKODU == item.KASAKODU).FirstOrDefault();
                var kasahareket = item;
                if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                {
                    var eskihareket = new KASA_HAREKET();
                    if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).Count() > 0)
                    {
                        eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                    }
                    else { eskihareket.BAKIYE = 0; }

                    kasa.TOPLAMBORC -= kasahareket.BORC;


                    foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                    {
                        hareketz.BAKIYE -= kasahareket.BORC;

                    }



                }
                else
                {


                    kasa.TOPLAMBORC -= kasahareket.BORC;



                }
                item.deleted = 1;
                db.SaveChanges();
            }
            var personelharetlerii = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1);
            foreach (var item in personelharetlerii)
            {

                item.deleted = 1;

            }


            foreach (var item in fishareketleri)
            {
                item.deleted = 1;
            }
            fis.deleted = 1;
            var kasaharetlerii = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
            foreach (var item in kasaharetleri)
            {

                item.deleted = 1;

            }


            db.SaveChanges();
            var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            db.Dispose(); return jsonResult;

        }
        [HttpPost]
        public JsonResult datagonder(carifismodel gelenveri)
        {
            changestring();

            var id = 0;
            double toplamtutar = 0;
            var personelfis = new PERSONEL_FISI();
            var personel = db.PERSONEL.Where(x => x.PERSONELKODU == gelenveri.PERSONELKOD).FirstOrDefault();
            personelfis.PERSONEL = db.PERSONEL.Where(x => x.PERSONELKODU == gelenveri.PERSONELKOD).FirstOrDefault();
            personelfis.PERSONELKODU = personelfis.PERSONEL.PERSONELKODU;
            personelfis.CreateDate = DateTime.Now;

            personelfis.CreateUserID = userid;
            personelfis.FISNO = gelenveri.FISNO.ToString();
            personelfis.ACIKLAMA = gelenveri.NOT;

            personelfis.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
            personelfis.TARIH = DateTime.Parse(gelenveri.TARIH);
           
            if (gelenveri.gelenhareket.Count == 0)
            {
                var jsonResult = Json("Başarısız", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
            else
            {
                var trans = db.Database.BeginTransaction();
                try
                {
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        toplamtutar += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                    }
                    personelfis.TOPLAMTUTAR = toplamtutar;
                    var list = db.PERSONEL_FISI.SingleOrDefault(x => x.FISNO == personelfis.FISNO);
                    if (list == null)
                    {
                        db.PERSONEL_FISI.Add(personelfis);
                        db.SaveChanges();
                        id = personelfis.ID;
                    }
                    else
                    {

                      
                     
                        list.UpdateDate = DateTime.Now;
                        list.UpdateUserID = 1;
                        list.S_MERKEZIID = personelfis.S_MERKEZIID;
                        list.TARIH = personelfis.TARIH;
                        list.ACIKLAMA = personelfis.ACIKLAMA;
                        list.TOPLAMTUTAR = personelfis.TOPLAMTUTAR;
                        db.SaveChanges();

                        fisiyenile(list.ID);
                        id = list.ID;
                    }
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var fishareket = new PERSONEL_FISI_HAREKET();
                        fishareket.PERSONEL = db.PERSONEL_FISI.Find(id);
                        fishareket.PERSONELID = fishareket.PERSONEL.ID;
                        fishareket.HAREKET = item.HAREKET;
                        fishareket.PERSONEL = list;
                        fishareket.ACIKLAMA = item.ACIKLAMA;
                        fishareket.KASA = item.KASA;
                        fishareket.NETTUTAR = item.NETTUTAR;


                        fishareket.TUTAR = item.TUTAR;
                        fishareket.PARABIRIMI = item.PARABIRIMI;
                        fishareket.PARAKURU = item.PARAKURU;
                        db.PERSONEL_FISI_HAREKET.Add(fishareket);
                        db.SaveChanges();
                        var hareket = new PERSONEL_HAREKET();
                        hareket.PERSONEL = db.PERSONEL.Where(x => x.PERSONELKODU == gelenveri.PERSONELKOD).FirstOrDefault();
                        hareket.PERSONELKODU = hareket.PERSONEL.PERSONELKODU;
                        hareket.CreateDate = DateTime.Now;
                        hareket.ACIKLAMA = gelenveri.NOT;
                        hareket.CreateUserID = userid;
                        hareket.DOSYANO = gelenveri.FISNO;
                        hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                        hareket.TURU = PERSONEL_HAREKET.personeltür.PersonelFişi;
                        hareket.S_MERKEZIID = (int)personelfis.S_MERKEZIID;


                        if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                        {
                            var eskihareket = new PERSONEL_HAREKET();
                            if (db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU).Count() > 0)
                            {
                                eskihareket = db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                            }
                            else { eskihareket.BAKIYE = 0; }


                            hareket.BORC = toplamtutar;
                            personel.TOPLAMBORC += hareket.BORC;
                            hareket.BAKIYE = eskihareket.BAKIYE - hareket.ALACAK;
                            foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU))
                            {
                                hareketz.BAKIYE += hareket.BORC;
                            }



                        }
                        else
                        {


                            hareket.BORC = toplamtutar;
                            personel.TOPLAMBORC += hareket.BORC;
                            hareket.BAKIYE = personel.BAKIYE;



                        }


                        hareket.TIPI = CARI_HAREKET.tip.Giriş;


                        hareket.ACIKLAMA = gelenveri.NOT;


                        db.PERSONEL_HAREKET.Add(hareket);

                        var kasa = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();

                        var kasahareket = new KASA_HAREKET();
                        kasahareket.KASA = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();
                        kasahareket.KASAKODU = kasahareket.KASA.KASAKODU;
                        kasahareket.ILGILI = db.PERSONEL.Where(x => x.PERSONELKODU == gelenveri.PERSONELKOD).FirstOrDefault().ADISOYADI;
                        kasahareket.CreateDate = DateTime.Now;
                        kasahareket.CreateUserID = userid;
                        kasahareket.ISLEMNO = gelenveri.FISNO;
                        kasahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                        kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.PerMaaş;
                        kasahareket.S_MERKEZIID= (int)personelfis.S_MERKEZIID;
                        if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                        {
                            var eskihareket = new KASA_HAREKET();
                            if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).Count() > 0)
                            {
                                eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                            }
                            else { eskihareket.BAKIYE = 0; }


                            kasahareket.TIPI = CARI_HAREKET.tip.Çıkış;
                            kasahareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                            kasa.TOPLAMALACAK += kasahareket.ALACAK;
                            kasahareket.BAKIYE = eskihareket.BAKIYE - kasahareket.ALACAK;

                            foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU))
                            {
                                hareketz.BAKIYE -= kasahareket.ALACAK;
                            }



                        }
                        else
                        {

                            kasahareket.TIPI = CARI_HAREKET.tip.Çıkış;
                            kasahareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                            kasa.TOPLAMALACAK += kasahareket.ALACAK;
                            kasahareket.BAKIYE = kasa.BAKIYE;



                        }




                        kasahareket.TIPI = CARI_HAREKET.tip.Çıkış;



                        kasahareket.ACIKLAMA = item.ACIKLAMA;


                        db.KASA_HAREKET.Add(kasahareket);


                        db.SaveChanges();
                    }


                    var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    trans.Commit();
                    db.Dispose();
                    return jsonResult;

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    db.Dispose();
                    return Json("Başarısız!");
                }



            }
        }


        public ActionResult Rapor(int? id)
        {
            changestring();
            var rapor = new CARI_HAREKETController.rapor();
            var peronel = db.PERSONEL.Find(id);
            var hareketler = db.PERSONEL_HAREKET.Where(x => x.PERSONELID == peronel.ID).ToList();
            rapor.Firma = db.FIRMA.FirstOrDefault();
            rapor.Thler = new List<string>();
            rapor.Toplamlar = new List<CARI_HAREKETController.valler>();
            rapor.Tdler = new List<CARI_HAREKETController.islem>();
            rapor.Baslıklar = new List<CARI_HAREKETController.valler>();
            rapor.Thler.Add("İşlem Türü");
            rapor.Thler.Add("Ayrıntı");
            rapor.Thler.Add("Belge No");
            rapor.Thler.Add("Vade");

            rapor.Thler.Add("Açıklama");
            rapor.Thler.Add("Borç/Giriş");
            rapor.Thler.Add("Alacak/Çıkış");
            rapor.Thler.Add("Durum Bakiye");

            rapor.Baslıklar.Add(new CARI_HAREKETController.valler { Baslık = "Personel Kodu/Adı", Deger = peronel.PERSONELKODU + "/" + peronel.ADISOYADI });
            rapor.Baslıklar.Add(new CARI_HAREKETController.valler { Baslık = "Personel Doğum Tarihi", Deger = peronel.DOGUMTARIHI.ToString() });
            rapor.Baslıklar.Add(new CARI_HAREKETController.valler { Baslık = "Personel Maaşı", Deger = peronel.MAAS.ToString() });
            var toplamalacak = hareketler.Sum(x => x.ALACAK);
            var toplamborc = hareketler.Sum(x => x.BORC);
            var bakiye = toplamborc - toplamalacak;
            foreach (var item in hareketler)
            {
                var yenisilem = new CARI_HAREKETController.islem();
                yenisilem.Islem = "<td>" + item.TURU + "</td>";
                yenisilem.Islem += "<td>" + item.TURU + "</td>";
                yenisilem.Islem += "<td>" + item.DOSYANO + "</td>";
                yenisilem.Islem += "<td>" + item.CreateDate.ToShortDateString() + "</td>";

                yenisilem.Islem += "<td>" + item.ACIKLAMA + "</td>";
                yenisilem.Islem += @"<td class=""text-end"">" + item.BORC + "</td>";
                yenisilem.Islem += @"<td class=""text-end"">" + item.ALACAK + "</td>";
                yenisilem.Islem += @"<td class=""text-end"">" + item.BAKIYE + "</td>";

                var althareket = ayrintigetirraporvoid(item.DOSYANO, item.TURU.ToString());
                yenisilem.Kalem = althareket;
                rapor.Tdler.Add(yenisilem);
            }
            rapor.Toplamlar.Add(new CARI_HAREKETController.valler { Baslık = "Borç", Deger = toplamborc.ToString() });
            rapor.Toplamlar.Add(new CARI_HAREKETController.valler { Baslık = "Alacak", Deger = toplamalacak.ToString() });
            rapor.Toplamlar.Add(new CARI_HAREKETController.valler { Baslık = "Bakiye", Deger = bakiye.ToString() });

            Session["rapor"] = rapor;
            return View(rapor);
        }
        public List<string> ayrintigetirraporvoid(string belgeno, string türü)
        {

            var metin = new List<string>();

            changestring();

            if (türü == "CariFişi")
            {

                var id = db.CARI_FIS.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.CARI_FIS_HAREKETs.Where(x => x.CARI_FIsID == id))
                {

                    metin.Add(item.KASA + " " + item.TUTAR + " " + item.PARABIRIMI + " " + item.HAREKET + " " + item.ACIKLAMA);

                }

            }
            if (türü == "BankaFişi")
            {

                var id = db.BANKA_FIS.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.BANKA_FIS_HAREKET.Where(x => x.BANKA_FISID == id))
                {
                    metin.Add(item.KASA + " " + item.TUTAR + " " + item.PARABIRIMI + " " + item.HAREKET + " " + item.ACIKLAMA);

                }

            }

            if (türü == "StokFişi")
            {

                var id = db.STOK_FIS.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.STOK_FIS_HAREKET.Include(x => x.STOK).Where(x => x.fisid == id))
                {
                    metin.Add(item.STOK.STOKKODU + "/" + item.STOK.STOKAD + " " + item.MIKTAR + " " + item.BIRIM + " Fiyat:" + item.FIYAT + " " + item.PARABIRIMI + " " + item.ACIKLAMA);



                }

            }
            if (türü == "Fatura")
            {

                var id = db.FATURA.SingleOrDefault(x => x.FATNO == belgeno).ID;
                foreach (var item in db.FATURA_HAREKET.Include(x => x.STOK).Where(x => x.FATURAID == id))
                {

                    metin.Add(item.STOK.STOKKODU + "/" + item.STOK.STOKAD + " " + item.MIKTAR + " " + item.BIRIM + " Fiyat:" + item.FIYAT + " " + item.PARABIRIMI + " " + item.ACIKLAMA);


                }

            }

            if (türü == "İrsaliye")
            {

                var id = db.IRSALIYE.SingleOrDefault(x => x.IRSNO == belgeno).ID;
                foreach (var item in db.IRSALIYE_HAREKET.Include(x => x.STOK).Where(x => x.IRSALIYEID == id))
                {

                    metin.Add(item.STOK.STOKKODU + "/" + item.STOK.STOKAD + " " + item.MIKTAR + " " + item.BIRIM + " Fiyat:" + item.FIYAT + " " + item.PARABIRIMI + " " + item.ACIKLAMA);



                }

            }


            return metin;





        }


        [HttpPost]
        public JsonResult tahakukdatagonder(tahakkukfismodel gelenveri)
        {
            changestring();


            double toplamtutar = 0;
            var personelfis = new PERSONEL_MAAS_TAHAKKUK();
            var id = int.Parse(gelenveri.PERSONELKOD);
            var personel = db.PERSONEL.Find(id);
       
            personelfis.CreateDate = DateTime.Now;
            personelfis.DONEM = gelenveri.DONEM;
            personelfis.MAAS = double.Parse(gelenveri.MAAS.Replace(".", ","));
            personelfis.GUN_CALIS = int.Parse(gelenveri.MAASGUNU);
            personelfis.MAASTUTARI = double.Parse(gelenveri.MAASTUTAR.Replace(",", "").Replace(".", ","));
            personelfis.CreateUserID = userid;
            personelfis.FISNO = gelenveri.FISNO.ToString();
            personelfis.ACIKLAMA = gelenveri.NOT;
            toplamtutar = double.Parse( gelenveri.TOPLAMTAHAKUK.Replace(",","").Replace(".",","));
            personelfis.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
            personelfis.TARIH = DateTime.Parse(gelenveri.TARIH);
            personelfis.PERSONELID = personel.ID;
            if ((db.PERSONEL_HAREKET.Where(x => x.DOSYANO == gelenveri.FISNO).Count()>0))
            db.PERSONEL_HAREKET.RemoveRange(db.PERSONEL_HAREKET.Where(x => x.DOSYANO == gelenveri.FISNO));
            var hareket = new PERSONEL_HAREKET();
            hareket.PERSONEL = db.PERSONEL.Where(x => x.ID.ToString() == gelenveri.PERSONELKOD).FirstOrDefault();
            hareket.PERSONELKODU = hareket.PERSONEL.PERSONELKODU;
            hareket.CreateDate = DateTime.Now;
            hareket.ACIKLAMA = gelenveri.DONEM + "'ıncı Ayın Maaş Tahakkuku";
            hareket.CreateUserID = userid;
            hareket.DOSYANO = gelenveri.FISNO;
            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
            hareket.TURU = PERSONEL_HAREKET.personeltür.Maaşİşlemleri;
            hareket.S_MERKEZIID = personelfis.S_MERKEZIID;


            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
            {
                var eskihareket = new PERSONEL_HAREKET();
                if (db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.PERSONELKODU == hareket.PERSONELKODU).Count() > 0)
                {
                    eskihareket = db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.PERSONELKODU == hareket.PERSONELKODU).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                }
                else { eskihareket.BAKIYE = 0; }


                hareket.ALACAK = toplamtutar;
                personel.TOPLAMALACAK += hareket.ALACAK;
                hareket.BAKIYE = eskihareket.BAKIYE - hareket.ALACAK;
                foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU))
                {
                    hareketz.BAKIYE -= hareket.ALACAK;
                }



            }
            else
            {


                hareket.ALACAK = toplamtutar;
                personel.TOPLAMALACAK += hareket.ALACAK;
                hareket.BAKIYE = personel.BAKIYE;



            }


            hareket.TIPI = CARI_HAREKET.tip.Çıkış;

            hareket.S_MERKEZIID= personelfis.S_MERKEZIID;
            hareket.ACIKLAMA = gelenveri.NOT;

            db.PERSONEL_HAREKET.Add(hareket);



            if (gelenveri.gelenhareket!=null)
            {
                personelfis.TOPLAMTUTAR = toplamtutar;
                var list = db.PERSONEL_MAAS_TAHAKKUK.SingleOrDefault(x => x.FISNO == personelfis.FISNO);
                if (list == null)
                {
                    db.PERSONEL_MAAS_TAHAKKUK.Add(personelfis);
                    db.SaveChanges();
                    
                }
                else
                {
                    
           
                    list.UpdateDate = DateTime.Now;
                    list.UpdateUserID = 1;
                    list.S_MERKEZIID = personelfis.S_MERKEZIID;
                    list.TARIH = personelfis.TARIH;
                    list.ACIKLAMA = personelfis.ACIKLAMA;
                    list.TOPLAMTUTAR = personelfis.TOPLAMTUTAR;
                    db.SaveChanges();
                
                }


                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
            else
            {
               
             
                personelfis.TOPLAMTUTAR = toplamtutar;
                var list = db.PERSONEL_MAAS_TAHAKKUK.SingleOrDefault(x => x.FISNO == personelfis.FISNO);
                if (list == null)
                {
                    db.PERSONEL_MAAS_TAHAKKUK.Add(personelfis);
                    db.SaveChanges();
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var fishareket = new PERSONEL_MAAS_TAHAKKUK_HAREKET();
                        fishareket.PERSONEL_MAAS_TAHAKKUK = db.PERSONEL_MAAS_TAHAKKUK.Find(personelfis.ID); 
                        fishareket.PERSONEL_MAAS_TAHAKKUKID = fishareket.PERSONEL_MAAS_TAHAKKUK.ID;
                        fishareket.HAREKET = item.HAREKET.ToString();
                        fishareket.BIRIM = item.BIRIM;

                        fishareket.BIRIM_MIKTAR = double.Parse(item.MIKTAR.Replace(".", ","));

                        fishareket.BIRIM_UCRET = double.Parse(item.FIYAT.Replace(".", ","));
                        fishareket.ACIKLAMA = item.ACIKLAMA;
                     
                        fishareket.TUTARI = double.Parse(item.NETTUTAR.Replace(".",","));


                        db.PERSONEL_MAAS_TAHAKKUK_HAREKET.Add(fishareket);
                        db.SaveChanges();
                    }
                }
                else
                {
                   
                
                    list.UpdateDate = DateTime.Now;
                    list.UpdateUserID = 1;
                    list.S_MERKEZIID = personelfis.S_MERKEZIID;
                    list.TARIH = personelfis.TARIH;
                    list.ACIKLAMA = personelfis.ACIKLAMA;
                    list.TOPLAMTUTAR = personelfis.TOPLAMTUTAR;
                    db.SaveChanges();
                    db.PERSONEL_MAAS_TAHAKKUK_HAREKET.RemoveRange( db.PERSONEL_MAAS_TAHAKKUK_HAREKET.Where(x=>x.PERSONEL_MAAS_TAHAKKUKID==list.ID));
                    db.SaveChanges();
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var fishareket = new PERSONEL_MAAS_TAHAKKUK_HAREKET();
                        fishareket.PERSONEL_MAAS_TAHAKKUK = list;
                        fishareket.PERSONEL_MAAS_TAHAKKUKID = list.ID;
                        fishareket.HAREKET = item.HAREKET.ToString();
                        fishareket.BIRIM = item.BIRIM;

                        fishareket.BIRIM_MIKTAR = double.Parse(item.MIKTAR.Replace(".", ","));

                        fishareket.BIRIM_UCRET = double.Parse(item.FIYAT.Replace(".", ","));
                        fishareket.ACIKLAMA = item.ACIKLAMA;

                        fishareket.TUTARI = double.Parse(item.NETTUTAR.Replace(".", ","));


                        db.PERSONEL_MAAS_TAHAKKUK_HAREKET.Add(fishareket);
                        db.SaveChanges();
                    }
                }


                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
          
         
        }
    }
}
