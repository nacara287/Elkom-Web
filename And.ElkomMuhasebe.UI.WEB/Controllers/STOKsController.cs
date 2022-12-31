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

using DbFunctions = System.Data.Entity.DbFunctions;
using EntityState = System.Data.Entity.EntityState;
using System.Globalization;
using System.Data.Entity.SqlServer;
using And.ElkomMuhasebe.Core.Model.Entity.Admin;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class STOKsController : Controller
    {
        private FirmaBaseDB db = new FirmaBaseDB();
        public int userid = 0;
        public bool ekleme = false;
        public bool degistirme = false;
        public bool silme = false;
        public bool gorme = false;
        private AndDB anddb = new AndDB();
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
                    if (alt.görme.Contains("Stoklar"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Stoklar"))
                            ekleme = true;
                        if (alt.silme.Contains("Stoklar"))
                            silme = true;
                        if (alt.degistir.Contains("Stoklar"))
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
        public double stokmiktarhesapla(int id)
        {
            double miktar = 0;

            var hareketliste = db.STOK_HAREKET.Where(x => x.STOKID == id).ToList();

            foreach (var item in hareketliste)
            {
                if (item.TIPI == CARI_HAREKET.tip.Giriş)
                {
                    miktar += item.MIKTAR;
                }

                if (item.TIPI == CARI_HAREKET.tip.Çıkış)
                {
                    miktar -= item.MIKTAR;
                }


            }
            return miktar;

        }
        public class modelimiz
        {
            public STOK Stok { get; set; }
            public STOK_HAREKET Hareket { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<STOK_BIRIM> sTOK_BIRIMLERs { get; set; }
            public IEnumerable<STOK_KOD1> STOK_KOD1s { get; set; }
            public IEnumerable<STOK_KOD2> STOK_KOD2s { get; set; }
            public IEnumerable<STOK> STOKs { get; set; }
            public IEnumerable<STOK_DEPO> DEPOs { get; set; }
            public IEnumerable<STOK_HAREKET> Harekets { get; set; }
   
        }
        public class StokAraViewModel
        {
            public int ID { get; set; }
            public string STOKODU { get; set; }
            public string STOKAD { get; set; }
            public string MIKTAR { get; set; }
            public string BIRIM { get; set; }
            public string HAMALISFIYAT { get; set; }
            public string HAMSATISFIYAT { get; set; }
            
            public string ALISFIYATI { get; set; }
            public string KDV_SIZ_ALISFIYATI { get; set; }
            
            public string PARABIRIMI { get; set; }
            public string SATISFIYATI { get; set; }
            public string KDV_SIZ_SATISFIYATI1 { get; set; }
            public string MALIYET { get; set; }
            public string KDV { get; set; }
            public string DEPO { get; set; }
        }

        [HttpPost]
        public JsonResult GetData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler,int depoid )
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
            List<StokAraViewModel> hareketler = new List<StokAraViewModel>();





            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "STOKAD";
            aranacaklar[1] = "STOKKODU";




            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";

            int b = 0;
            if (filterler.Length > 0)
            {


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
                        else
                        {
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

                        switch (gelen)
                        {
                            case 0: query += $"5==5"; break;
                            case 1: query += $"{  filterler[i].verismi }>{ 0 }"; break;
                            case 2: query += $"{  filterler[i].verismi }<{ 0 }"; break;
                            case 3: query += $"{  filterler[i].verismi }!=null"; break;
                            case 4: query += $"{  filterler[i].verismi }=={ 0 }"; break;
                            case 5: query += $"{  filterler[i].verismi }=={ 1 }"; break;
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



            var v = (from a in db.STOK.Include(x=>x.DEPOSU).Where(x => x.deleted != 1).Where(query) select a);


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
                var miktar = item.MIKTAR;
                if (depoid != 0)
                {if (db.STOK_DEPO_TOPLAM.Where(x => x.DEPOSUID == depoid && x.STOKID == item.ID).Count()>0)
                    miktar = db.STOK_DEPO_TOPLAM.Where(x => x.DEPOSUID == depoid && x.STOKID == item.ID).FirstOrDefault().MIKTAR;
                    else
                        miktar = 0;
                }
                if (item.deleted == null) { 
               
                var yenihareket = new StokAraViewModel();
                
                yenihareket.ID = item.ID;
                    if(!string.IsNullOrEmpty(item.STOKKODU))
                yenihareket.STOKODU = item.STOKKODU;
                    if (!string.IsNullOrEmpty(item.STOKAD))
                        yenihareket.STOKAD = item.STOKAD;
                yenihareket.MIKTAR = miktar.ToString();
                    yenihareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.ID == item.BIRIM).FirstOrDefault().BIRIMADI;
                yenihareket.ALISFIYATI = item.ALISFIYATI.ToString();
                    if (!string.IsNullOrEmpty(item.PARABIRIMI))
                        yenihareket.PARABIRIMI = item.PARABIRIMI.ToString();
                yenihareket.SATISFIYATI = item.SATISFIYATI1.ToString();
                yenihareket.MALIYET = item.MALIYETORT.ToString();
                    yenihareket.HAMALISFIYAT = item.HAMALISFIYAT.ToString();
                    yenihareket.HAMSATISFIYAT = item.HAMSATISFIYAT.ToString();
                    yenihareket.KDV_SIZ_ALISFIYATI = item.KDV_SIZ_ALISFIYATI.ToString();
                    yenihareket.KDV_SIZ_SATISFIYATI1 = item.KDV_SIZ_SATISFIYATI1.ToString();
                    yenihareket.KDV = item.KDV.ToString();
                    if(item.DEPOSUID!=0)
                    yenihareket.DEPO = item.DEPOSU.DEPOADI; 





                    hareketler.Add(yenihareket);
                }



            }

            Disposedb();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }


        [HttpPost]
        public JsonResult özelkodolustur(string kod, int kodtürü)
        {
            changestring();
            if (kodtürü == 1)
            {
                var kod1 = new STOK_KOD1();
                kod1.CreateDate = DateTime.Now;
                kod1.CreateUserID = userid;
                kod1.KOD = kod;
                db.STOK_KOD1.Add(kod1);
            }
            if (kodtürü == 2)
            {
                var kod2 = new STOK_KOD2();
                kod2.CreateDate = DateTime.Now;
                kod2.CreateUserID = userid;
                kod2.KOD = kod;
                db.STOK_KOD2.Add(kod2);
            }


            db.SaveChanges();

            Disposedb();
            return Json("Başarılı", JsonRequestBehavior.AllowGet);

        }

        // GET: STOKs

        [HttpPost]
        public JsonResult kodgetir(string kod)
        {
            changestring();
            if (string.IsNullOrEmpty(kod))
            {
                int sayi = db.STOK.Where(x => x.STOKKODU.Contains("STK")).Count() + 1;
                Disposedb();
                return Json("STK" + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);

            }
            else
            {
                int sayi = db.STOK.Where(x => x.STOKKODU.Contains(kod)).Count() + 1;
                Disposedb();
                return Json(kod + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);
            }

        }



        public ActionResult Index()
        {
            changestring();
        
            if (gorme == true)
            {
                modelimiz yenimodel = new modelimiz();
                yenimodel.STOK_KOD1s = db.STOK_KOD1.ToList();
                yenimodel.STOK_KOD2s = db.STOK_KOD2.ToList();
                yenimodel.DEPOs = db.STOK_DEPO.ToList();
                return View(yenimodel);
        
            }
            else
            {
                return Redirect("/Home");
            }
        }

      
    

        // GET: STOKs/Create
        public ActionResult Create()
        {
            changestring();
            var model = new modelimiz();
            model.sTOK_BIRIMLERs = anddb.STOK_BIRIMLER.Where(x => x.deleted == null).ToList();
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null & x.Aktif == true).ToList();
            model.Harekets = db.STOK_HAREKET.Where(x=>x.deleted==null).ToList();
            model.STOKs = db.STOK.Where(x => x.deleted == null).ToList();
            model.Stok = new STOK();
            model.STOK_KOD1s = db.STOK_KOD1.ToList();
            model.STOK_KOD2s = db.STOK_KOD2.ToList();
            model.DEPOs = db.STOK_DEPO.ToList();
            if (ekleme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: STOKs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(modelimiz model)
        {
            changestring();
            if (ModelState.IsValid)
            {
                model.Stok.CreateDate = DateTime.Now;
                model.Stok.CreateUserID = userid;
                var kur = db.KUR_BASLIK.Where(x => x.KURKODU == model.Stok.PARABIRIMI).FirstOrDefault();
                if (model.Stok.HAMALISFIYAT == 0 && model.Hareket.FIYAT!=0)
                {
                    model.Stok.HAMALISFIYAT = model.Hareket.FIYAT;
                }


                    model.Stok.TL_ALISFIYATI = model.Stok.HAMALISFIYAT * kur.KUR;
                model.Stok.TL_SATISFIYATI = model.Stok.HAMSATISFIYAT * kur.KUR;
                
                
                double alisfiyat = 0;
                double satisfiyat = 0;
                if (model.Stok.KDVDAHIL == 1) {

                    

                    alisfiyat = model.Stok.HAMALISFIYAT / (((float)model.Stok.KDV / 100) + 1);
                    satisfiyat = model.Stok.HAMSATISFIYAT / (((float)model.Stok.KDV / 100) + 1);


                }

                else
                {
                    alisfiyat = model.Stok.HAMALISFIYAT;
                    satisfiyat = model.Stok.HAMSATISFIYAT;
                }
                  

                model.Stok.TL_ALIS_TOPLAM = model.Hareket.FIYAT * model.Hareket.MIKTAR * kur.KUR;
                model.Stok.DOVIZ_ALIS_TOPLAM = model.Hareket.FIYAT * model.Hareket.MIKTAR ;
                model.Stok.MIKTAR = model.Hareket.MIKTAR;

            
                model.Stok.TOPGIREN = model.Stok.MIKTAR;
                model.Stok.TOPCIKAN = 0;
                db.STOK.Add(model.Stok);
                db.SaveChanges();
                model.Hareket.CARIID =null;
                model.Hareket.TARIH = DateTime.Now;
                model.Hareket.CreateDate = DateTime.Now;
                model.Hareket.CreateUserID = userid;
                model.Hareket.STOK = db.STOK.Where(x => x.STOKKODU == model.Stok.STOKKODU).FirstOrDefault();
                model.Hareket.S_MERKEZIID = 1;
                model.Hareket.TIPI = CARI_HAREKET.tip.Devir;
                model.Hareket.ISLEMTURU = STOK_HAREKET.stoktur.Devir;
                model.Hareket.STOKKODU = model.Stok.STOKKODU;
                model.Hareket.BIRIM = model.Stok.BIRIM;
                model.Hareket.FIYAT = model.Hareket.FIYAT;
                model.Hareket.MIKTAR =(double) model.Stok.MIKTAR;
                model.Hareket.KUR_FIYAT = kur.KUR;
                model.Hareket.PARABIRIMI = model.Stok.PARABIRIMI;
                model.Hareket.DEPOSUID = model.Stok.DEPOSUID;

                model.Hareket.TL_TUTAR = (double)model.Stok.TL_ALIS_TOPLAM;

                model.Hareket.DOVIZ_TUTAR = (double)model.Stok.DOVIZ_ALIS_TOPLAM;
                model.Hareket.TL_STOKALIS_TOPLAM= (double)model.Stok.TL_ALIS_TOPLAM;
                model.Hareket.DOVIZ_STOKALIS_TOPLAM = (double)model.Stok.DOVIZ_ALIS_TOPLAM;
                model.Hareket.STOKMIKTAR_GIREN = (float)model.Stok.TOPGIREN;
                model.Hareket.STOKMIKTAR = (float)model.Stok.MIKTAR;
                model.Hareket.PARABIRIMI = model.Stok.PARABIRIMI;
                model.Hareket.ACIKLAMA = "Devir";
                db.STOK_HAREKET.Add(model.Hareket);
                var depotoplam = new STOK_DEPO_TOPLAM();
                depotoplam.CreateDate = DateTime.Now;
                depotoplam.CreateUserID = 1;
                depotoplam.STOKID = model.Stok.ID;
                depotoplam.MIKTAR = model.Stok.MIKTAR;
                depotoplam.DEPOSUID = model.Stok.DEPOSUID;
               db.STOK_DEPO_TOPLAM.Add(depotoplam);

                
                db.SaveChanges();
                Disposedb();
                return Json("Index");
            }
            Disposedb();
            return Json(model);
        }

        // GET: STOKs/Edit/5
        public ActionResult Edit(int? id)
        {
            changestring();
            var model = new modelimiz();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Stok = db.STOK.Find(id);
            if (model.Stok == null)
            {
                return HttpNotFound();
            }

            if (degistirme == true)
            {
                model.STOK_KOD1s = db.STOK_KOD1.ToList();
                model.STOK_KOD2s = db.STOK_KOD2.ToList();
                model.sTOK_BIRIMLERs = anddb.STOK_BIRIMLER.ToList();
                model.DEPOs = db.STOK_DEPO.ToList();
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: STOKs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(modelimiz model)
        {
            changestring();
            if (ModelState.IsValid)
            {
                model.Stok.UpdateDate = DateTime.Now;
                model.Stok.UpdateUserID = userid;
                db.Entry(model.Stok).State = EntityState.Modified;
                db.SaveChanges();
                Disposedb();
                return Json("Index");
            }
            Disposedb();
            return Json(model.Stok);
        }

        // GET: STOKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOK sTOK = db.STOK.Find(id);
            if (sTOK == null)
            {
                return HttpNotFound();
            }
            return View(sTOK);
        }

        // POST: STOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STOK sTOK = db.STOK.Find(id);
            db.STOK.Remove(sTOK);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disposedb();
            }
            base.Dispose(disposing);
        }
    }
}
