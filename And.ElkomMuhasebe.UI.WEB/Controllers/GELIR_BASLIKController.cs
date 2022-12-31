﻿using System;
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


namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class GELIR_BASLIKController : Controller
    {
        private FirmaBaseDB db = new FirmaBaseDB();
        public int userid = 0;
        public bool ekleme = false;
        public bool degistirme = false;
        public bool silme = false;
        public bool gorme = false;
        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

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
                    if (alt.görme.Contains("Bankalar"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Bankalar"))
                            ekleme = true;
                        if (alt.silme.Contains("Bankalar"))
                            silme = true;
                        if (alt.degistir.Contains("Bankalar"))
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
        public class gelirmodel
        {
            public int ID { get; set; }
            public string GELIRKODU { get; set; }
            public string GELIRAD { get; set; }

            public string KDVGRUP { get; set; }
            public string ACIKLAMA { get; set; }
            public double? TOPLAMTUTAR { get; set; }
        }
     
        [HttpPost]
        public JsonResult GetData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
        {
            changestring();

            var start = offset;
            var length = limit;
            var sortcolumn = "";
            if (sort != null)
                sortcolumn = sort;
            var sortColumnDir = order;
            int pagesize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;

            List<gelirmodel> hareketler = new List<gelirmodel>();





            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "GELIRKODU";
            aranacaklar[1] = "GELIRAD";




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
                        query += $"{  filterler[i].verismi }=={ deger}";

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
                        }




                    }

                }

                query += ")";
            }



            var v = (from a in db.GELIR_BASLIK.Where(x => x.deleted != 1).Where(query) select a);

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


                var yenihareket = new gelirmodel();

                yenihareket.ID = item.ID;
                if (!string.IsNullOrEmpty(item.GELIRAD))
                    yenihareket.GELIRAD = item.GELIRAD;
                if (!string.IsNullOrEmpty(item.GELIRKODU))
                    yenihareket.GELIRKODU = item.GELIRKODU;


                yenihareket.TOPLAMTUTAR = item.TOPLAMTUTAR;
                yenihareket.KDVGRUP = item.KDVGRUP.ToString();


                if (!string.IsNullOrEmpty(item.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.ACIKLAMA;

                hareketler.Add(yenihareket);



            }
            db.Dispose();

            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
        // GET: GELIR_BASLIK
        public ActionResult Index()
        {
            changestring();
            return View();
        }
        public class gelirhareketmodel
        {
            public int ID { get; set; }
            public string CreateDate { get; set; }
            public string FISNO { get; set; }
            public string ISLEMTURU { get; set; }

            public string ACIKLAMA { get; set; }
            public double? TUTARI { get; set; }
        }
        public class yenimodel
        {
            public string ismi { get; set; }
            public string kodu { get; set; }
            public int id { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }

        }
        public ActionResult GELIR_HAREKETLERI(int? id)
        {
            changestring();
            var model = new yenimodel();
            var gelir = db.GELIR_BASLIK.Find(id);
            model.ismi = gelir.GELIRAD;
            model.kodu = gelir.GELIRKODU;
            model.id = gelir.ID;
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
        [HttpPost]
        public JsonResult GetDataHareket(int id,string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
        {
            changestring();

            var start = offset;
            var length = limit;
            var sortcolumn = "";
            if (sort != null)
                sortcolumn = sort;
            var sortColumnDir = order;
            int pagesize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;

            List<gelirhareketmodel> hareketler = new List<gelirhareketmodel>();

            var zaman = new DateTime();
            var sonzaman = new DateTime();



            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "FISNO";
            aranacaklar[1] = "ACIKLAMA";




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


            var v = (from a in db.GELIR_BORDRO_HAREKET.Where(x => x.deleted != 1&&x.GELIR_BASLIKKID==id).Where(x => DbFunctions.TruncateTime(x.CreateDate) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.CreateDate) <= DbFunctions.TruncateTime(sonzaman)) select a);

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


                var yenihareket = new gelirhareketmodel();

                yenihareket.ID = item.ID;
                yenihareket.CreateDate = item.CreateDate.ToShortDateString();
                yenihareket.FISNO = item.FISNO;
                if (string.IsNullOrEmpty(item.ACIKLAMA))
                    yenihareket.ACIKLAMA = "";
                else
                yenihareket.ACIKLAMA = item.ACIKLAMA;

                yenihareket.ISLEMTURU = item.ISLEMTURU.ToString();
                yenihareket.TUTARI = item.TUTARI;



                if (!string.IsNullOrEmpty(item.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.ACIKLAMA;

                hareketler.Add(yenihareket);



            }
            db.Dispose();

            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
        // GET: GELIR_BASLIK/Details/5
        public ActionResult Details(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GELIR_BASLIK gELIR_BASLIK = db.GELIR_BASLIK.Find(id);
            if (gELIR_BASLIK == null)
            {
                return HttpNotFound();
            }
            return View(gELIR_BASLIK);
        }
        [HttpPost]
        public JsonResult kodgetir(string kod)
        {
            changestring();
            if (string.IsNullOrEmpty(kod))
            {
                int sayi = db.GELIR_BASLIK.Where(x => x.GELIRKODU.Contains("GLM")).Count() + 1;
                db.Dispose();
                return Json("GLM" + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);

            }
            else
            {
                int sayi = db.GELIR_BASLIK.Where(x => x.GELIRKODU.Contains(kod)).Count() + 1;
                db.Dispose();
                return Json(kod + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);
            }

        }

        // GET: GELIR_BASLIK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GELIR_BASLIK/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GELIRKODU,deleted,GELIRAD,ACIKLAMA,OZELKOD1,OZELKOD2,KDVGRUP,TOPLAMTUTAR,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] GELIR_BASLIK gELIR_BASLIK)
        {
            changestring();
            if (ModelState.IsValid)
            {
                gELIR_BASLIK.CreateDate = DateTime.Now;
                gELIR_BASLIK.CreateUserID = 1;
                db.GELIR_BASLIK.Add(gELIR_BASLIK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gELIR_BASLIK);
        }

        // GET: GELIR_BASLIK/Edit/5
        public ActionResult Edit(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GELIR_BASLIK gELIR_BASLIK = db.GELIR_BASLIK.Find(id);
            if (gELIR_BASLIK == null)
            {
                return HttpNotFound();
            }
            return View(gELIR_BASLIK);
        }

        // POST: GELIR_BASLIK/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GELIRKODU,deleted,GELIRAD,ACIKLAMA,OZELKOD1,OZELKOD2,KDVGRUP,TOPLAMTUTAR,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] GELIR_BASLIK gELIR_BASLIK)
        {
            changestring();
            if (ModelState.IsValid)
            {
                db.Entry(gELIR_BASLIK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gELIR_BASLIK);
        }

        // GET: GELIR_BASLIK/Delete/5
        public ActionResult Delete(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GELIR_BASLIK gELIR_BASLIK = db.GELIR_BASLIK.Find(id);
            if (gELIR_BASLIK == null)
            {
                return HttpNotFound();
            }
            return View(gELIR_BASLIK);
        }

        // POST: GELIR_BASLIK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            changestring();
            GELIR_BASLIK gELIR_BASLIK = db.GELIR_BASLIK.Find(id);
            db.GELIR_BASLIK.Remove(gELIR_BASLIK);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
