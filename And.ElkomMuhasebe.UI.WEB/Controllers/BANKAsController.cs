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
    public class BANKAsController : Controller
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
        // GET: BANKAs
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
        public class bankamodel
        {
        public  List<BANKA> BANKAs { get; set; }
            public BANKA BANKA { get; set; }

        }
        public class select
        {
            public string id { get; set; }
            public string text { get; set; }


        }

        public JsonResult getbank(string term, string _type, string q)
        {



            changestring();
            List<select> hareketler = new List<select>();









            var data = db.BANKA.Where(x => x.BANKAKODU.ToLower().Contains(term.ToLower()) || x.BANKAADI.ToLower().Contains(term.ToLower())).Take(10).ToList();



            foreach (var item in data)
            {


                var yenihareket = new select();

                yenihareket.id = item.BANKAKODU;
                if (!string.IsNullOrEmpty(item.BANKAADI))
                    yenihareket.text = item.BANKAKODU + " / " + item.BANKAADI;



                hareketler.Add(yenihareket);



            }
            db.Dispose();

            return Json(hareketler, JsonRequestBehavior.AllowGet);







        }
        public class BankaAraViewModel
        {
            public int ID { get; set; }

            public string BANKAKODU { get; set; }
            public string BANKAADI { get; set; }
            public string SUBEADI { get; set; }
            public string HESAPNO { get; set; }
            public string MUSTERIVISA { get; set; }
            public string FIRMACEK { get; set; }
            public string SENET_TOPLAM { get; set; }
            public string NAKIT_TOPLAM { get; set; }
            
            public string ÇEK_TOPLAM { get; set; }

            public string BAKIYE { get; set; }
      
        }
        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

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
      
            List<BankaAraViewModel> hareketler = new List<BankaAraViewModel>();





            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "BANKAADI";
            aranacaklar[1] = "BANKAKODU";




            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";

            int b = 0;
            if (filterler!=null)
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



            var v = (from a in db.BANKA.Where(x => x.deleted != 1).Where(query) select a);

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


                var yenihareket = new BankaAraViewModel();

                yenihareket.ID = item.ID;
                if (!string.IsNullOrEmpty(item.BANKAADI))
                    yenihareket.BANKAADI = item.BANKAADI;
                if (!string.IsNullOrEmpty(item.BANKAKODU))
                    yenihareket.BANKAKODU = item.BANKAKODU;

           
                    yenihareket.BAKIYE = item.BAKIYE.ToString();
       
                    yenihareket.SENET_TOPLAM = item.SENET_TOPLAM.ToString();
                yenihareket.NAKIT_TOPLAM = item.NAKIT_TOPLAM.ToString();
                if (!string.IsNullOrEmpty(item.SUBEADI))
                    yenihareket.SUBEADI = item.SUBEADI;

                yenihareket.ÇEK_TOPLAM= item.CEK_TOPLAM.ToString();
                yenihareket.MUSTERIVISA = item.VISA.ToString();
                if (!string.IsNullOrEmpty(item.HESAPNO))
                    yenihareket.HESAPNO = item.HESAPNO;

                hareketler.Add(yenihareket);



            }
            db.Dispose();

            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        public class giderler { 
           public int ID { get; set; }
            public string GIDERKODU { get; set; }
            public string GIDERAD { get; set; }


        }
        
        
        [HttpPost]
        public JsonResult GetGider(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
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

            List<giderler> hareketler = new List<giderler>();





            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "GIDERDI";
            aranacaklar[1] = "GIDERKODU";




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



            var v = (from a in db.GIDER_BASLIK.Where(x => x.deleted != 1).Where(query) select a);


            if (!(string.IsNullOrEmpty(sortcolumn)) && !(string.IsNullOrEmpty(sortColumnDir)))
            {
                v = v.OrderBy(sort + " " + sortColumnDir);
            }

            var data = v.Skip(offset).Take(limit).ToList();
            totalRecords = v.Count();
            foreach (var item in data)
            {


                var yenihareket = new giderler();

                yenihareket.ID = item.ID;
                if (!string.IsNullOrEmpty(item.GIDERAD))
                    yenihareket.GIDERAD = item.GIDERAD;
                if (!string.IsNullOrEmpty(item.GIDERKODU))
                    yenihareket.GIDERKODU = item.GIDERKODU;


               

                hareketler.Add(yenihareket);



            }
            db.Dispose();

            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

    
        [HttpPost]
        public JsonResult kodgetir(string kod)
        {
            changestring();
            if (string.IsNullOrEmpty(kod))
            {
                int sayi = db.BANKA.Where(x => x.BANKAKODU.Contains("BNK")).Count() + 1;
                db.Dispose();
                return Json("BNK" + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);

            }
            else
            {
                int sayi = db.BANKA.Where(x => x.BANKAKODU.Contains(kod)).Count() + 1;
                db.Dispose();
                return Json(kod + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);
            }

        }

        // GET: BANKAs/Create
        public ActionResult Create()
        {
            changestring();
            var model=new bankamodel();
        
            model.BANKA = new BANKA();
            if (ekleme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: BANKAs/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(bankamodel model)
        {
            changestring();
            if (ModelState.IsValid&& db.BANKA.Where(x => x.BANKAKODU == model.BANKA.BANKAKODU).Count() == 0)
            {
                model.BANKA.CreateDate = DateTime.Now;
                model.BANKA.CreateUserID = userid;
                model.BANKA.CEK_TOPLAM = 0;
                model.BANKA.SENET_TOPLAM = 0;
                model.BANKA.NAKIT_TOPLAM = 0;
           
                if (model.BANKA.TOPLAMALACAK == null)
                    model.BANKA.TOPLAMALACAK = 0;
                if (model.BANKA.TOPLAMBORC == null)
                    model.BANKA.TOPLAMBORC = 0;
                db.BANKA.Add(model.BANKA);
                db.SaveChanges();
                var hareket = new BANKA_HAREKET();
                hareket.BANKA = db.BANKA.Where(x => x.BANKAKODU == model.BANKA.BANKAKODU).FirstOrDefault();
                hareket.BANKAKODU = model.BANKA.BANKAKODU;
                hareket.TIPI = CARI_HAREKET.tip.Devir;
                hareket.ISLEMTURU = CARI_HAREKET.tür.Devir;
               

                hareket.ISLEMNO = "";
                hareket.DOSYANO = "Devir";
                if (hareket.ALACAK == null)
                {

                    hareket.ALACAK = 0;
                }
                if (hareket.BORC == null)
                {

                  hareket.BORC = 0;
                }
                hareket.ALACAK = model.BANKA.TOPLAMALACAK;
                hareket.BORC = model.BANKA.TOPLAMBORC;
                hareket.BAKIYE = model.BANKA.TOPLAMBORC- model.BANKA.TOPLAMALACAK;
                hareket.TARIHSAAT = DateTime.Now;
                hareket.CreateDate = DateTime.Now;
                hareket.CreateUserID = userid;
                hareket.S_MERKEZIID = 1;
                db.BANKA_HAREKET.Add(hareket);
                db.SaveChanges();
                db.Dispose();
                return Json("Index");
            }
            db.Dispose();
            return Json(model);
        }

        // GET: BANKAs/Edit/5
        public ActionResult Edit(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANKA bANKA = db.BANKA.Find(id);
            if (bANKA == null)
            {
                return HttpNotFound();
            }
            var bankamodel=new bankamodel();
            bankamodel.BANKA = bANKA;

            if (degistirme == true)
            {
                return View(bankamodel);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: BANKAs/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(bankamodel model)
        {
            changestring();
            if (ModelState.IsValid)
            {
                model.BANKA.UpdateDate = DateTime.Now;
                model.BANKA.UpdateUserID = userid;
                db.Entry(model.BANKA).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
                return Json("Index");
            }
            db.Dispose();
            return Json(model.BANKA);
        }

        // GET: BANKAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANKA bANKA = db.BANKA.Find(id);
            if (bANKA == null)
            {
                return HttpNotFound();
            }
            return View(bANKA);
        }

        // POST: BANKAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANKA bANKA = db.BANKA.Find(id);
            db.BANKA.Remove(bANKA);

            db.SaveChanges();
            db.Dispose();
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
