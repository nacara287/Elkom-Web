using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class KASAsController : Controller
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
                    if (alt.görme.Contains("Kasalar"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Kasalar"))
                            ekleme = true;
                        if (alt.silme.Contains("Kasalar"))
                            silme = true;
                        if (alt.degistir.Contains("Kasalar"))
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
        public class modelimiz
        {
            public KASA KASA { get; set; }
            public KASA_HAREKET Hareket { get; set; }
            public KUR_BASLIK Kur { get; set; }
            public IEnumerable<FIRMA> fIRMAs { get; set; }
            public IEnumerable<KASA> KASAs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
      
          
        }
        [HttpPost]
        public JsonResult getparabirimi(string kod)
        {



            changestring();
            var value =  db.KASA.Where(x => x.KASAKODU == kod).FirstOrDefault().PBIRIMI;

            db.Dispose();
            return Json(new { parabirimi = value }, JsonRequestBehavior.AllowGet);

        }
        public class  KasaAraviewModel
        {
            public int ID { get; set; }
            public string KASAKODU { get; set; }
            public string KASAADI { get; set; }
            public string TIPI { get; set; }
            public string TOPLAMBORC { get; set; }
            public string TOPLAMALACAK { get; set; }
            public string BAKIYE { get; set; }
            public string PBIRIMI { get; set; }
        }
        [HttpPost]
        public JsonResult aradevirolustur(string borcmiktar, string alacakmiktar, string kasakod)
        {
            changestring();
            var hareket = new KASA_HAREKET();
            var kasa = db.KASA.Where(x => x.KASAKODU == kasakod).FirstOrDefault();
            hareket.CreateDate = DateTime.Now;
            hareket.CreateUserID = userid;
       
            hareket.ACIKLAMA = "AraDevir";
            hareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.Devir;
            hareket.ILGILI = "";
            hareket.TIPI = CARI_HAREKET.tip.Devir;
            hareket.TARIHSAAT = DateTime.Now;
            hareket.S_MERKEZI = db.SORUMLULUK_MERKEZI.FirstOrDefault();
            hareket.KASAKODU = kasakod;
            hareket.KASA = kasa;
           
                hareket.BORC = double.Parse(borcmiktar.Replace(".", ","));
                hareket.ALACAK = double.Parse(alacakmiktar.Replace(".", ","));
                kasa.TOPLAMBORC += hareket.BORC;
                kasa.TOPLAMALACAK += hareket.ALACAK;
         
         
            db.KASA_HAREKET.Add(hareket);
            db.SaveChanges();

            db.Dispose();
            return Json("Başarılı", JsonRequestBehavior.AllowGet);

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
            List<KasaAraviewModel> hareketler = new List<KasaAraviewModel>();





            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "KASAKODU";
            aranacaklar[1] = "KASAADI";




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



            var v = (from a in db.KASA.Where(x => x.deleted != 1).Where(query) select a);


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


                var yenihareket = new KasaAraviewModel();

                yenihareket.ID = item.ID;
                if (!string.IsNullOrEmpty(item.KASAKODU))
                    yenihareket.KASAKODU = item.KASAKODU;
                if (!string.IsNullOrEmpty(item.KASAADI))
                    yenihareket.KASAADI = item.KASAADI;

        
                if (!string.IsNullOrEmpty(item.PBIRIMI))
                    yenihareket.PBIRIMI = item.PBIRIMI.ToString();
          
                yenihareket.TOPLAMBORC = item.TOPLAMBORC.ToString();
               
                yenihareket.TOPLAMALACAK = item.TOPLAMALACAK.ToString();
                yenihareket.TIPI = item.TIPI.ToString();
                yenihareket.BAKIYE = item.BAKIYE.ToString();



                hareketler.Add(yenihareket);



            }

            db.Dispose();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        public class select
        {
            public string id { get; set; }
            public string text { get; set; }


        }

        public JsonResult getkasa(string term, string _type, string q)
        {



            changestring();
            List<select> hareketler = new List<select>();








            var data = db.KASA.Where(x => x.KASAKODU.ToLower().Contains(term.ToLower()) || x.KASAADI.ToLower().Contains(term.ToLower())).Take(10).ToList();



            foreach (var item in data)
            {


                var yenihareket = new select();

                yenihareket.id = item.KASAKODU;
                if (!string.IsNullOrEmpty(item.KASAADI))
                    yenihareket.text = item.KASAKODU + " / " + item.KASAADI;



                hareketler.Add(yenihareket);



            }

            db.Dispose();
            return Json(hareketler, JsonRequestBehavior.AllowGet);







        }
        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }

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


        // GET: KASAs/Create
        public ActionResult Create()
        {
            changestring();
            var yenimodel = new modelimiz();
            yenimodel.KASA = new KASA();
            yenimodel.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.Aktif == true);
            yenimodel.KASAs = db.KASA.Where(x => x.deleted == null).ToList();
            yenimodel.KASA.PBIRIMI = "";
            if (ekleme == true)
            {
                return View(yenimodel);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: KASAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KASA")] modelimiz model)
        {
            changestring();
            if (ModelState.IsValid)
            {
                model.KASA.CreateUserID = userid;
                model.KASA.CreateDate = DateTime.Now;
                if (model.KASA.TOPLAMALACAK == null)
                    model.KASA.TOPLAMALACAK = 0;
                if (model.KASA.TOPLAMBORC == null)
                    model.KASA.TOPLAMBORC = 0;
                db.KASA.Add(model.KASA);
               
                db.SaveChanges();
                var hareket = new KASA_HAREKET();
                hareket.KASA = model.KASA;
                hareket.CreateUserID = userid;
                hareket.CreateDate = DateTime.Now;
                hareket.TARIHSAAT = DateTime.Now;
                hareket.TIPI = CARI_HAREKET.tip.Devir;
                hareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.Devir;
                hareket.KASAKODU = model.KASA.KASAKODU;
                hareket.ACIKLAMA = "Devir";
                hareket.S_MERKEZI = db.SORUMLULUK_MERKEZI.First();
                hareket.BAKIYE = model.KASA.BAKIYE;
                hareket.ALACAK = model.KASA.TOPLAMALACAK;
                hareket.BORC = model.KASA.TOPLAMBORC;

                db.KASA_HAREKET.Add(hareket);
                db.SaveChanges();
                db.Dispose();
                return Json("Index");
            }
            db.Dispose();
            return Json(model.KASA);
        }
        [HttpPost]
        public JsonResult kodgetir(string kod)
        {
            changestring();
            if (string.IsNullOrEmpty(kod))
            {
                int sayi = db.KASA.Where(x => x.KASAKODU.Contains("KASA")).Count() + 1;
                db.Dispose();
                return Json("KASA" + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);

            }
            else
            {
                int sayi = db.KASA.Where(x => x.KASAKODU.Contains(kod)).Count() + 1;
                db.Dispose();
                return Json(kod + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);
            }

        }

        // GET: KASAs/Edit/5
        public ActionResult Edit(int? id)
        {
            changestring();
            var yenimodel = new modelimiz();
            yenimodel.KASA = db.KASA.Where(x => x.ID == id).First();


            yenimodel.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.Aktif == true);
           

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KASA kASA = db.KASA.Find(id);
            if (kASA == null)
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

        // POST: KASAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,INDEXNO,TIPI,BAKIYE,TOPLAMBORC,TOPLAMALACAK,KASAKODU,KASAADI,BILGI,PBIRIMI,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] KASA kASA)
        {
            changestring();
            if (ModelState.IsValid)
            {
                kASA.UpdateDate = DateTime.Now;
                kASA.UpdateUserID = userid;
                db.Entry(kASA).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
                return Json("Index");
            }
            db.Dispose();
            return Json(kASA);
        }

        // GET: KASAs/Delete/5
        public ActionResult Delete(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KASA kASA = db.KASA.Find(id);
            if (kASA == null)
            {
                return HttpNotFound();
            }
            return View(kASA);
        }

        // POST: KASAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            changestring();
            KASA kASA = db.KASA.Find(id);
            db.KASA.Remove(kASA);
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
