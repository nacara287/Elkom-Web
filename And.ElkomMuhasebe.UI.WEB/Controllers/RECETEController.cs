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
    public class RECETEController : Controller
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
                    if (alt.görme.Contains("Stok Hareketleri Ve Fişleri"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Stok Hareketleri Ve Fişleri"))
                            ekleme = true;
                        if (alt.silme.Contains("Stok Hareketleri Ve Fişleri"))
                            silme = true;
                        if (alt.degistir.Contains("Stok Hareketleri Ve Fişleri"))
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
        public class stokmodel
        {


            public string STOKKOD { get; set; }
            public string STOKAD { get; set; }
            public string MIKTAR { get; set; }
            public string FIYAT { get; set; }
            public string TUTAR { get; set; }
        }

            public class recetefismodel
        {


            public string RECETEKODU { get; set; }
            public string RECETEADI { get; set; }
            public string ACIKLAMA { get; set; }
            public string OZELKOD { get; set; }
            public string TOPLAMKALEM { get; set; }
            public string TOPLAMMASRAF { get; set; }
            public string TARIH { get; set; }
            public List<stokmodel> KULLANILANSTOKLAR { get; set; }
            public List<stokmodel> MASRAFLAR { get; set; }
            public List<stokmodel> URETILENSTOKLAR { get; set; }

            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class recetemodel
        {
            public int ID { get; set; }
            public string RECETEKODU { get; set; }

            public string RECETEADI { get; set; }
            public string TARIH { get; set; }
            public string ACIKLAMA { get; set; }
           
            public string URETIM_ADET { get; set; }
            public string SON_URETIM_MALIYET { get; set; }


        }

        public class model
        {
            public List<STOK_URETIM_RECETESI> RECETES { get; set; }
            public List<STOK_URETIM_RECETESI_OZELKOD> kods { get; set; }
            public List<GIDER_BASLIK> GIDERLER { get; set; }
            public STOK_URETIM_RECETESI RECETE { get; set; }
            public List<STOK_URETIM_RECETESI_STOK> sTOK_URETIM_RECETESI_STOKs { get; set; }
            public List<STOK_URETIM_RECETESI_GIDER> sTOK_URETIM_RECETESI_GIDERs { get; set; }
            public List<STOK_URETIM_RECETESI_URUN> sTOK_URETIM_RECETESI_URUNs { get; set; }
        }

        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }
        [HttpPost]
        public JsonResult FisData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
        {
            var zaman = new DateTime();
            var sonzaman = new DateTime();
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
            List<recetemodel> hareketler = new List<recetemodel>();




            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "RECETEKODU";
            aranacaklar[1] = "RECETEADI";




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




            var v = (from a in db.STOK_URETIM_RECETESI.Where(x => x.deleted != 1).Where(x => DbFunctions.TruncateTime(x.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);


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


                var yenihareket = new recetemodel();

                yenihareket.ID = item.ID;


                yenihareket.RECETEADI = item.RECETEADI;

                yenihareket.RECETEKODU = item.RECETEKODU;
                yenihareket.TARIH = item.TARIH.Value.ToShortDateString();
                yenihareket.SON_URETIM_MALIYET = item.SON_URETIM_MALIYET.ToString();
                yenihareket.URETIM_ADET = item.URETIM_ADET.ToString(); 
               

                yenihareket.ACIKLAMA = item.ACIKLAMA;
                hareketler.Add(yenihareket);



            }


            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
        [HttpPost]
        public JsonResult datagonder(recetefismodel gelenveri)
        {
            changestring();

       
            var recete = new STOK_URETIM_RECETESI();
           
          
            recete.CreateDate = DateTime.Now;
            recete.CreateUserID = userid;
   
            recete.RECETEADI = gelenveri.RECETEADI;
            recete.RECETEKODU = gelenveri.RECETEKODU;
            recete.ACIKLAMA = gelenveri.ACIKLAMA;
            recete.OZELKOD = gelenveri.OZELKOD;
            recete.TARIH = DateTime.Parse(gelenveri.TARIH);
            recete.URETIM_ADET = double.Parse(gelenveri.TOPLAMKALEM);
            recete.SON_URETIM_MALIYET = double.Parse(gelenveri.TOPLAMMASRAF.Replace(",", "").Replace(".", ","));
            db.STOK_URETIM_RECETESI.Add(recete);
            db.SaveChanges();
            if (gelenveri.URETILENSTOKLAR.Count == 0)
            {
                var jsonResult = Json("Başarısız", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
            else
            {


                if (gelenveri.KULLANILANSTOKLAR.Count() != 0)
                {
                    foreach (var item in gelenveri.KULLANILANSTOKLAR)
                    {
                        var fishareket = new STOK_URETIM_RECETESI_STOK();
                        fishareket.RECETEKODU = gelenveri.RECETEKODU;
                        fishareket.STOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Where(x => x.RECETEKODU == gelenveri.RECETEKODU).FirstOrDefault();
                        fishareket.STOK_URETIM_RECETESIID = fishareket.STOK_URETIM_RECETESI.ID;
                        fishareket.CreateDate = DateTime.Now;
                        fishareket.CreateUserID = userid;
                        fishareket.STOKKODU = item.STOKKOD;

                        fishareket.MIKTAR = double.Parse(item.MIKTAR);

                        fishareket.FIYAT = double.Parse(item.FIYAT);
                        fishareket.TUTAR = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));



                        db.STOK_URETIM_RECETESI_STOK.Add(fishareket);
                        db.SaveChanges();
                    }
                }

                if (gelenveri.URETILENSTOKLAR.Count() != 0)
                {
                    foreach (var item in gelenveri.URETILENSTOKLAR)
                    {
                        var fishareket = new STOK_URETIM_RECETESI_URUN();
                        fishareket.RECETEKODU = gelenveri.RECETEKODU;
                        fishareket.STOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Where(x => x.RECETEKODU == gelenveri.RECETEKODU).FirstOrDefault();
                        fishareket.STOK_URETIM_RECETESIID = fishareket.STOK_URETIM_RECETESI.ID;
                        fishareket.CreateDate = DateTime.Now;
                        fishareket.CreateUserID = userid;
                        fishareket.STOKKODU = item.STOKKOD;

                        fishareket.MIKTAR = double.Parse(item.MIKTAR);



                        db.STOK_URETIM_RECETESI_URUN.Add(fishareket);
                        db.SaveChanges();
                    }
                }
                if (gelenveri.MASRAFLAR!=null&&gelenveri.MASRAFLAR.Count()>0)
                {
                    foreach (var item in gelenveri.MASRAFLAR)
                    {
                        var fishareket = new STOK_URETIM_RECETESI_GIDER();
                        fishareket.RECETEKODU = gelenveri.RECETEKODU;
                        fishareket.STOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Where(x => x.RECETEKODU == gelenveri.RECETEKODU).FirstOrDefault();
                        fishareket.STOK_URETIM_RECETESIID = fishareket.STOK_URETIM_RECETESI.ID;
                        fishareket.CreateDate = DateTime.Now;
                        fishareket.CreateUserID = userid;
                        fishareket.GIDERKODU = item.STOKKOD;

                        fishareket.TUTAR = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));




                        db.STOK_URETIM_RECETESI_GIDER.Add(fishareket);
                        db.SaveChanges();
                    }
                }
                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
        }

        [HttpPost]
        public JsonResult datagonderguncelle(recetefismodel gelenveri)
        {
            changestring();


            var recete = db.STOK_URETIM_RECETESI.Where(x=>x.RECETEKODU==gelenveri.RECETEKODU).FirstOrDefault();


            recete.UpdateDate = DateTime.Now;
            recete.UpdateUserID = userid;

            recete.RECETEADI = gelenveri.RECETEADI;
            recete.RECETEKODU = gelenveri.RECETEKODU;
            recete.ACIKLAMA = gelenveri.ACIKLAMA;
            recete.OZELKOD = gelenveri.OZELKOD;
            recete.TARIH = DateTime.Parse(gelenveri.TARIH);
            recete.URETIM_ADET = double.Parse(gelenveri.TOPLAMKALEM);
            recete.SON_URETIM_MALIYET = double.Parse(gelenveri.TOPLAMMASRAF.Replace(",", "").Replace(".", ","));
          
            db.SaveChanges();
            if (gelenveri.URETILENSTOKLAR.Count == 0)
            {
                var jsonResult = Json("Başarısız", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
            else
            {
                db.STOK_URETIM_RECETESI_URUN.RemoveRange(db.STOK_URETIM_RECETESI_URUN.Where(x => x.STOK_URETIM_RECETESIID == recete.ID));
                db.STOK_URETIM_RECETESI_GIDER.RemoveRange(db.STOK_URETIM_RECETESI_GIDER.Where(x => x.STOK_URETIM_RECETESIID == recete.ID));
                db.STOK_URETIM_RECETESI_STOK.RemoveRange(db.STOK_URETIM_RECETESI_STOK.Where(x => x.STOK_URETIM_RECETESIID == recete.ID));
    
                if (gelenveri.KULLANILANSTOKLAR.Count() != 0)
                {
                    foreach (var item in gelenveri.KULLANILANSTOKLAR)
                    {
                        var fishareket = new STOK_URETIM_RECETESI_STOK();
                        fishareket.RECETEKODU = gelenveri.RECETEKODU;
                        fishareket.STOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Where(x => x.RECETEKODU == gelenveri.RECETEKODU).FirstOrDefault();
                        fishareket.CreateDate = DateTime.Now;
                        fishareket.CreateUserID = userid;
                        fishareket.STOKKODU = item.STOKKOD;

                        fishareket.MIKTAR = double.Parse(item.MIKTAR);

                        fishareket.FIYAT = double.Parse(item.FIYAT);
                        fishareket.TUTAR = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));



                        db.STOK_URETIM_RECETESI_STOK.Add(fishareket);
                        db.SaveChanges();
                    }
                }
   
                if (gelenveri.URETILENSTOKLAR.Count() != 0)
                {
                    foreach (var item in gelenveri.URETILENSTOKLAR)
                    {
                        var fishareket = new STOK_URETIM_RECETESI_URUN();
                        fishareket.RECETEKODU = gelenveri.RECETEKODU;
                        fishareket.STOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Where(x => x.RECETEKODU == gelenveri.RECETEKODU).FirstOrDefault();
                        fishareket.CreateDate = DateTime.Now;
                        fishareket.CreateUserID = userid;
                        fishareket.STOKKODU = item.STOKKOD;

                        fishareket.MIKTAR = double.Parse(item.MIKTAR);



                        db.STOK_URETIM_RECETESI_URUN.Add(fishareket);
                        db.SaveChanges();
                    }
                }

                if (gelenveri.MASRAFLAR.Count() != 0)
                {
                    foreach (var item in gelenveri.MASRAFLAR)
                    {
                        var fishareket = new STOK_URETIM_RECETESI_GIDER();
                        fishareket.RECETEKODU = gelenveri.RECETEKODU;
                        fishareket.STOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Where(x => x.RECETEKODU == gelenveri.RECETEKODU).FirstOrDefault();
                        fishareket.CreateDate = DateTime.Now;
                        fishareket.CreateUserID = userid;
                        fishareket.GIDERKODU = item.STOKKOD;

                        fishareket.TUTAR = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));




                        db.STOK_URETIM_RECETESI_GIDER.Add(fishareket);
                        db.SaveChanges();
                    }
                }
                db.SaveChanges();
                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
        }
        [HttpPost]
        public JsonResult kodgetir(string kod)
        {
            changestring();
            if (string.IsNullOrEmpty(kod))
            {
                int sayi = db.STOK_URETIM_RECETESI.Where(x => x.RECETEKODU.Contains("REC")).Count() + 1;

                return Json("REC" + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);

            }
            else
            {
                int sayi = db.STOK_URETIM_RECETESI.Where(x => x.RECETEKODU.Contains(kod)).Count() + 1;

                return Json(kod + sayi.ToString().PadLeft(4, '0'), JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult özelkodolustur(string kod, int kodtürü)
        {
            changestring();
            if (kodtürü == 1)
            {
                var kod1 = new STOK_URETIM_RECETESI_OZELKOD();
                kod1.CreateDate = DateTime.Now;
                kod1.CreateUserID = userid;
                kod1.OZELKOD = kod;
                db.STOK_URETIM_RECETESI_OZELKOD.Add(kod1);
            }
           


            db.SaveChanges();


            return Json("Başarılı", JsonRequestBehavior.AllowGet);

        }
     
        // GET: RECETE
        public ActionResult Index()
        {
            return View();
        }
        // GET: BANKAs/Create
        public ActionResult Create()
        {
            changestring();
            var model = new model();
         
            if (ekleme == true)
            {
                model.kods = db.STOK_URETIM_RECETESI_OZELKOD.ToList();
                model.GIDERLER = db.GIDER_BASLIK.ToList();
                model.RECETE = new STOK_URETIM_RECETESI();
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
     

        // GET: BANKAs/Edit/5
        public ActionResult Edit(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOK_URETIM_RECETESI bANKA = db.STOK_URETIM_RECETESI.Find(id);
            if (bANKA == null)
            {
                return HttpNotFound();
            }
     

            if (degistirme == true)
            {
                var RECETEMODEL = new model();
                RECETEMODEL.RECETE = bANKA;
                RECETEMODEL.kods = db.STOK_URETIM_RECETESI_OZELKOD.ToList();
                RECETEMODEL.GIDERLER = db.GIDER_BASLIK.ToList();
                RECETEMODEL.sTOK_URETIM_RECETESI_GIDERs = db.STOK_URETIM_RECETESI_GIDER.Where(X => X.STOK_URETIM_RECETESIID == id).ToList();
                RECETEMODEL.sTOK_URETIM_RECETESI_STOKs = db.STOK_URETIM_RECETESI_STOK.Where(X => X.STOK_URETIM_RECETESIID == id).ToList();
                RECETEMODEL.sTOK_URETIM_RECETESI_URUNs = db.STOK_URETIM_RECETESI_URUN.Where(X => X.STOK_URETIM_RECETESIID == id).ToList();
                return View(RECETEMODEL);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        // POST: BANKAs/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        
    }
}