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
namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class PERSONELsController : Controller
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
                    if (alt.görme.Contains("Personeller"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Personeller"))
                            ekleme = true;
                        if (alt.silme.Contains("Personeller"))
                            silme = true;
                        if (alt.degistir.Contains("Personeller"))
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
        public class personelmodel
        {
            public List<PERSONEL> PERSONELs { get; set; }
            public PERSONEL PERSONEL { get; set; }

        }

        public class personelAraViewModel
        {
            public int ID { get; set; }
            public string PERSONELKODU { get; set; }
            public string ADISOYADI { get; set; }
            public string MOBIL { get; set; }
            public string EVTEL { get; set; }
            public string GOREVI { get; set; }
            public string IS_BAS_TARIHI { get; set; }
            public string IS_AYRILMA_TARIHI { get; set; }
            public string TOPLAMALACAK { get; set; }
            public string TOPLAMBORC { get; set; }
            public string BAKIYE { get; set; }

        }
        public class select
        {
            public string id { get; set; }
            public string text { get; set; }


        }
        [HttpPost]
        public JsonResult maasgetir(string kod)
        {



            changestring();
            List<select> hareketler = new List<select>();













            return Json(db.PERSONEL.Where(x=>x.ID.ToString()==kod).FirstOrDefault().MAAS.ToString().Replace(",","."), JsonRequestBehavior.AllowGet);







        }
        public JsonResult getpersonel(string term, string _type, string q)
        {



            changestring();
            List<select> hareketler = new List<select>();









            var data = db.PERSONEL.Where(x => x.PERSONELKODU.ToLower().Contains(term.ToLower()) || x.ADISOYADI.ToLower().Contains(term.ToLower())).Take(10).ToList();



            foreach (var item in data)
            {


                var yenihareket = new select();

                yenihareket.id = item.ID.ToString();
                if (!string.IsNullOrEmpty(item.ADISOYADI))
                    yenihareket.text = item.PERSONELKODU + " / " + item.ADISOYADI;



                hareketler.Add(yenihareket);



            }


            return Json(hareketler, JsonRequestBehavior.AllowGet);







        }
        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }
        [HttpPost]
        public JsonResult kodgetir(string kod)
        {
            changestring();
            if (string.IsNullOrEmpty(kod))
            {
                int sayi = db.PERSONEL.Where(x => x.PERSONELKODU.Contains("PER")).Count() + 1;

                return Json("PER" + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);

            }
            else
            {
                int sayi = db.PERSONEL.Where(x => x.PERSONELKODU.Contains(kod)).Count() + 1;

                return Json(kod + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);
            }

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

            List<personelAraViewModel> hareketler = new List<personelAraViewModel>();





            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "ADISOYADI";
            aranacaklar[1] = "PERSONELKODU";




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



            var v = (from a in db.PERSONEL.Where(x => x.deleted != 1).Where(query) select a);


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


                var yenihareket = new personelAraViewModel();

                yenihareket.ID = item.ID;
                if (!string.IsNullOrEmpty(item.ADISOYADI))
                    yenihareket.ADISOYADI = item.ADISOYADI;
                if (!string.IsNullOrEmpty(item.PERSONELKODU))
                    yenihareket.PERSONELKODU = item.PERSONELKODU;

                if (!string.IsNullOrEmpty(item.EVTEL))
                    yenihareket.EVTEL = item.EVTEL;
                if (!string.IsNullOrEmpty(item.MOBIL))
                    yenihareket.MOBIL = item.MOBIL;
                if (!string.IsNullOrEmpty(item.GOREVI))
                    yenihareket.GOREVI = item.GOREVI;
                if (item.IS_BAS_TARIHI!=null)
                    yenihareket.IS_BAS_TARIHI = item.IS_BAS_TARIHI.Value.ToShortDateString();
                if (item.IS_AYRILMA_TARIHI != null)
                    yenihareket.IS_AYRILMA_TARIHI = item.IS_AYRILMA_TARIHI.Value.ToShortDateString();
                if (item.TOPLAMALACAK != null)
                    yenihareket.TOPLAMALACAK = item.TOPLAMALACAK.ToString();
                if (item.TOPLAMBORC != null)
                    yenihareket.TOPLAMBORC = item.TOPLAMBORC.ToString();
                if (item.BAKIYE != null)
                    yenihareket.BAKIYE = item.BAKIYE.ToString();

                hareketler.Add(yenihareket);



            }


            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }




        // GET: PERSONELs
        public ActionResult Index()
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

        // GET: PERSONELs/Details/5
        public ActionResult Details(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONEL pERSONEL = db.PERSONEL.Find(id);
            if (pERSONEL == null)
            {
                return HttpNotFound();
            }
            return View(pERSONEL);
        }

        // GET: PERSONELs/Create
        public ActionResult Create()
        {
            changestring();
            var model = new personelmodel();
          
            model.PERSONEL = new PERSONEL();
            if (ekleme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }

        }

        // POST: PERSONELs/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(personelmodel model)
        {
            changestring();
            if (ModelState.IsValid)
            {
                model.PERSONEL.CreateDate = DateTime.Now;
                model.PERSONEL.CreateUserID = userid;
                db.PERSONEL.Add(model.PERSONEL);
                db.SaveChanges();
                var hareket = new PERSONEL_HAREKET();
                hareket.PERSONEL = db.PERSONEL.Where(x => x.PERSONELKODU == model.PERSONEL.PERSONELKODU).FirstOrDefault();
                hareket.PERSONELKODU = model.PERSONEL.PERSONELKODU;
                hareket.TIPI = CARI_HAREKET.tip.Devir;
                hareket.DOSYANO = " ";
                hareket.ACIKLAMA = "DEVİR";
                hareket.TURU= PERSONEL_HAREKET.personeltür.Devir;
            
                hareket.ALACAK = model.PERSONEL.TOPLAMALACAK;
                hareket.BORC = model.PERSONEL.TOPLAMBORC;
                hareket.BAKIYE = model.PERSONEL.TOPLAMBORC- model.PERSONEL.TOPLAMALACAK;
                hareket.TARIHSAAT = DateTime.Now;
                hareket.CreateDate = DateTime.Now;
                hareket.CreateUserID = userid;
                hareket.S_MERKEZIID = 1;
                db.PERSONEL_HAREKET.Add(hareket);
                db.SaveChanges();
                return Json("Index");
            }

            return Json(model.PERSONEL);
        }

        // GET: PERSONELs/Edit/5
        public ActionResult Edit(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONEL pERSONEL = db.PERSONEL.Find(id);
            if (pERSONEL == null)
            {
                return HttpNotFound();
            }
            var model = new personelmodel();
            model.PERSONEL = db.PERSONEL.Find(id);

            if (degistirme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: PERSONELs/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(personelmodel model)
        {
            changestring();
            if (ModelState.IsValid)
            {
                model.PERSONEL.UpdateDate = DateTime.Now;
                model.PERSONEL.UpdateUserID = userid;
                db.Entry(model.PERSONEL).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Index");
            }
            return Json(model);
        }

        // GET: PERSONELs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONEL pERSONEL = db.PERSONEL.Find(id);
            if (pERSONEL == null)
            {
                return HttpNotFound();
            }
            return View(pERSONEL);
        }

        // POST: PERSONELs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERSONEL pERSONEL = db.PERSONEL.Find(id);
            db.PERSONEL.Remove(pERSONEL);
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
