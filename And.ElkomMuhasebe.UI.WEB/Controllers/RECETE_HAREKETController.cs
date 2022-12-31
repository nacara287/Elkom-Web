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
    public class RECETE_HAREKETController : Controller
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
        [HttpPost]
        public JsonResult fissil(int id)
        {
            changestring();
            var fis = db.STOK_URETIM_FISI.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.STOK_URETIM_FISI_HAREKET.Where(x => x.FISID == id && x.deleted != 1);


            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1).ToList();

            foreach (var item in hareketler)
            {
                var stok = db.STOK.Where(x => x.ID == item.STOKID).FirstOrDefault();
                var stokhareket = item;
                if (DateTime.Now.CompareTo(stokhareket.TARIH.Add(new TimeSpan(2, 0, 0))) > 0)
                {
                    var eskihareket = new STOK_HAREKET();
                    if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                    {
                        eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).OrderByDescending(x => x.TARIH).FirstOrDefault();


                    }
                    else { eskihareket.STOKMIKTAR = 0; }
                    if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                    {

                        stok.TOPGIREN -= stokhareket.FIYAT;

                        stok.MIKTAR -= stokhareket.MIKTAR;


                        foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1))
                        {
                            hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;


                        }
                        db.SaveChanges();
                    }
                    else
                    {

                        stok.TOPCIKAN -= stokhareket.FIYAT;
                        stok.MIKTAR += stokhareket.MIKTAR;


                        foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1))
                        {
                            hareketz.STOKMIKTAR += (float)stokhareket.MIKTAR;


                        }
                        db.SaveChanges();
                    }
                }
                else
                {
                    if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                    {

                        stok.TOPGIREN -= stokhareket.FIYAT;
                        stok.MIKTAR -= stokhareket.MIKTAR;

                        db.SaveChanges();
                    }
                    else
                    {

                        stok.TOPCIKAN -= stokhareket.FIYAT;
                        stok.MIKTAR += stokhareket.MIKTAR;



                        db.SaveChanges();


                    }

                }
                item.deleted = 1;
              
                db.SaveChanges();
            }

            foreach (var item in fishareketleri)
            {
                item.deleted = 1;
            }
            fis.deleted = 1;
            var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1);
            foreach (var item in stokhareketlerii)
            {

                item.deleted = 1;

            }
            var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
            foreach (var item in cariharetlerii)
            {

                item.deleted = 1;

            }

            db.SaveChanges();
            var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            db.Dispose(); return jsonResult;

        }
        [HttpPost]
        public JsonResult fisiyenile(int id)
        {
            changestring();
            var fis = db.STOK_URETIM_FISI.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.STOK_URETIM_FISI_HAREKET.Where(x => x.FISID == id && x.deleted != 1);

      
            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1).ToList();

          
                foreach (var item in hareketler)
                {
                    var stok = db.STOK.Where(x => x.ID == item.STOKID).FirstOrDefault();
                    var stokhareket = item;
                    if (DateTime.Now.CompareTo(stokhareket.TARIH.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new STOK_HAREKET();
                        if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).OrderByDescending(x => x.TARIH).FirstOrDefault();


                        }
                        else { eskihareket.STOKMIKTAR = 0; }
                        if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                        {


                            stok.TOPGIREN -= stokhareket.FIYAT;
                            stok.MIKTAR -= stokhareket.MIKTAR;


                            foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1))
                            {
                                hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;


                            }
                            db.SaveChanges();
                        }
                        else
                        {

                            stok.TOPCIKAN -= stokhareket.FIYAT;
                            stok.MIKTAR += stokhareket.MIKTAR;


                            foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1))
                            {
                                hareketz.STOKMIKTAR += (float)stokhareket.MIKTAR;


                            }
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                        {

                            stok.TOPGIREN -= stokhareket.FIYAT;
                            stok.MIKTAR -= stokhareket.MIKTAR;

                            db.SaveChanges();
                        }
                        else
                        {

                            stok.TOPCIKAN -= stokhareket.FIYAT;
                            stok.MIKTAR += stokhareket.MIKTAR;



                            db.SaveChanges();


                        }

                    }
                    item.deleted = 1;
                    db.SaveChanges();
                   // stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();
                    db.SaveChanges();
                }


                db.STOK_URETIM_FISI_HAREKET.RemoveRange(fishareketleri);


                var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1);
                db.STOK_HAREKET.RemoveRange(stokhareketlerii);




                db.SaveChanges();
                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                

               
              
                return jsonResult;





        }
        public class modelimiz
        {
     
            public KUR_BASLIK Kur { get; set; }
        

         

            public STOK_URETIM_FISI fis { get; set; }
            public string STOK_URETIM_FISIS { get; set; }
            public IEnumerable<STOK_URETIM_FISI_HAREKET> STOK_URETIM_FISI_HAREKETS { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }

        }
        public class stokfismodel
        {



            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }

            public string TUTAR { get; set; }
            public List<stokmodelhareket> gelenhareket { get; set; }

            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class stokmodelhareket
        {



            public string RECETEKODU { get; set; }
            public string ACIKLAMA { get; set; }

            public string MIKTAR { get; set; }
            public string BIRIM { get; set; }
     
    
            public string NETTUTAR { get; set; }

        }
        [HttpPost]
        public JsonResult datagonder(stokfismodel gelenveri)
        {
            changestring();

            var id = 0;



            var stokfis = new STOK_URETIM_FISI();
           

            stokfis.CreateDate = DateTime.Now;
            stokfis.CreateUserID = userid;

            stokfis.FISNO = gelenveri.FISNO.ToString();
            stokfis.ACIKLAMA = gelenveri.NOT;
            stokfis.TOPLAM_TUTAR = double.Parse(gelenveri.TUTAR.Replace(",", "").Replace(".", ","));
            stokfis.TARIH = DateTime.Parse(gelenveri.TARIH);

            if (gelenveri.gelenhareket.Count == 0)
            {
                var jsonResult = Json("Başarısız", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
            else
            {
               
                    var list = db.STOK_URETIM_FISI.SingleOrDefault(x => x.FISNO == gelenveri.FISNO);
                    if (list == null)
                    {
                        db.STOK_URETIM_FISI.Add(stokfis);
                        db.SaveChanges();
                        id = stokfis.ID;
                    }
                    else
                    {
                        fisiyenile(list.ID);
                        stokfis.ID = list.ID;

                        list.UpdateDate = DateTime.Now;
                        list.UpdateUserID = 1;

                        list.TARIH = stokfis.TARIH;
                        list.ACIKLAMA = stokfis.ACIKLAMA;
                        db.Entry(list).State = EntityState.Modified;


                        db.SaveChanges();
                        id = list.ID;


                    }
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var oran = double.Parse(item.MIKTAR);
                        var recete = db.STOK_URETIM_RECETESI.Where(x => x.RECETEKODU == item.RECETEKODU).FirstOrDefault();
                        var kullanılanstoklar = db.STOK_URETIM_RECETESI_STOK.Where(x => x.RECETEKODU == item.RECETEKODU).ToList();
                        var üretilenstoklar = db.STOK_URETIM_RECETESI_URUN.Where(x => x.RECETEKODU == item.RECETEKODU).ToList();
                        foreach (var kullanılanstok in kullanılanstoklar)
                        {
                            var stok = db.STOK.Where(x => x.STOKKODU == kullanılanstok.STOKKODU).FirstOrDefault();



                            var stokhareket = new STOK_HAREKET();
                            stokhareket.STOK = stok;
                            stokhareket.STOKKODU = stok.STOKKODU;
                         
                            stokhareket.CreateDate = DateTime.Now;
                            stokhareket.CreateUserID = userid;
                            stokhareket.BELGENO = gelenveri.FISNO;
                            stokhareket.TARIH = DateTime.Parse(gelenveri.TARIH);
                            stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.Üretim;
                            stokhareket.BIRIM = 1;
                            stokhareket.FIYAT = (double)kullanılanstok.FIYAT;
                            stokhareket.TIPI = CARI_HAREKET.tip.Çıkış;
                            stokhareket.MIKTAR = kullanılanstok.MIKTAR * oran;

                            if (DateTime.Now.CompareTo(stokhareket.TARIH.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new STOK_HAREKET();
                                if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).Count() > 0)
                                {
                                    eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).OrderByDescending(x => x.TARIH).FirstOrDefault();


                                }
                                else { eskihareket.STOKMIKTAR = 0; }

                                stok.MIKTAR -= stokhareket.MIKTAR;
                                stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR - (float)stokhareket.MIKTAR;
                                foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU))
                                {
                                    hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;

                                }



                            }
                            else
                            {

                                stok.MIKTAR -= stokhareket.MIKTAR;


                                stokhareket.STOKMIKTAR = float.Parse(stok.MIKTAR.ToString());
                            }

                        if (stok.KDVDAHIL == 1)
                        {
                            stok.HAMSATISFIYAT = stokhareket.FIYAT;
                        }
                        else
                        {
                            stok.HAMSATISFIYAT = stokhareket.FIYAT * ((int)stok.KDV / 100);

                        }

                     ////   stok.SATISFIYATI1 = stokhareket.FIYAT;
                            stok.TOPCIKAN += stokhareket.FIYAT;



                            //stokhareket.SONMALIYET = kullanılanstok.TUTAR * oran;



                      
                            stokhareket.ACIKLAMA = item.ACIKLAMA;
                            stokhareket.S_MERKEZIID = 1;

                            db.STOK_HAREKET.Add(stokhareket);
                            db.SaveChanges();
                            //stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();
                            db.SaveChanges();


                        }
                        foreach (var üretilenstok in üretilenstoklar)
                        {
                            var stok = db.STOK.Where(x => x.STOKKODU == üretilenstok.STOKKODU).FirstOrDefault();



                            var stokhareket = new STOK_HAREKET();
                            stokhareket.STOK = stok;
                            stokhareket.STOKKODU = stok.STOKKODU;
                        
                            stokhareket.CreateDate = DateTime.Now;
                            stokhareket.CreateUserID = userid;
                            stokhareket.BELGENO = gelenveri.FISNO;
                            stokhareket.TARIH = DateTime.Parse(gelenveri.TARIH);
                            stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.Üretim;
                            stokhareket.BIRIM = 1;
                            stokhareket.FIYAT = (double)stok.SATISFIYATI1;
                            stokhareket.TIPI = CARI_HAREKET.tip.Giriş;
                            stokhareket.MIKTAR = üretilenstok.MIKTAR * oran;
                            //stok.MALIYETORT = stokfis.TOPLAM_TUTAR;
                            if (DateTime.Now.CompareTo(stokhareket.TARIH.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new STOK_HAREKET();
                                if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).Count() > 0)
                                {
                                    eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).OrderByDescending(x => x.TARIH).FirstOrDefault();


                                }
                                else { eskihareket.STOKMIKTAR = 0; }

                                stok.MIKTAR += stokhareket.MIKTAR;
                                stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR + (float)stokhareket.MIKTAR;
                                foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU))
                                {
                                    hareketz.STOKMIKTAR += (float)stokhareket.MIKTAR;

                                }



                            }
                            else
                            {

                                stok.MIKTAR += stokhareket.MIKTAR;


                                stokhareket.STOKMIKTAR = float.Parse(stok.MIKTAR.ToString());
                            }

                        if (stok.KDVDAHIL == 1)
                        {
                            stok.HAMSATISFIYAT = stokhareket.FIYAT;
                        }
                        else
                        {
                            stok.HAMSATISFIYAT = stokhareket.FIYAT * ((int)stok.KDV / 100);

                        }
                        //kontroledilcek
                      //  stok.SATISFIYATI1 = stokhareket.FIYAT;
                            stok.TOPGIREN += stokhareket.FIYAT;



                            //stokhareket.SONMALIYET = recete.SON_URETIM_MALIYET;




                            stokhareket.ACIKLAMA = item.ACIKLAMA;
                            stokhareket.S_MERKEZIID = 1;

                            db.STOK_HAREKET.Add(stokhareket);
                            db.SaveChanges();
                         
                     

                        }
                    }
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var fishareket = new STOK_URETIM_FISI_HAREKET();
                        fishareket.FISNO = gelenveri.FISNO;
                        fishareket.FIS = stokfis;
                        fishareket.FISID = stokfis.ID;

                        fishareket.ACIKLAMA = item.ACIKLAMA;
                        fishareket.RECETEKODU = item.RECETEKODU;

                        fishareket.MIKTAR = double.Parse(item.MIKTAR);
                        fishareket.BIRIM_FIYATI = double.Parse(item.BIRIM);

                        fishareket.STOK_MALIYET = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));

                  

                        db.STOK_URETIM_FISI_HAREKET.Add(fishareket);
                        db.SaveChanges();
                    }
                    var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                  
                    db.Dispose();
                    return jsonResult;

               
               




            
            }
        }
        // GET: RECETE_HAREKET
        public ActionResult Index()
        {
            return View();
        }
        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }
        public class üretimfişi
        {
            public int ID { get; set; }


            public string FISNO { get; set; }
     
            public string TARIH { get; set; }
            public string ACIKLAMA { get; set; }
            public string TOPLAM_TUTAR { get; set; }
     

        }
        public ActionResult RECETEFISKART(int? id)
        {
            changestring();
            var model = new modelimiz();



            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        




            if (degistirme == true)
            {
                model.fis = db.STOK_URETIM_FISI.Find(id);
                model.STOK_URETIM_FISI_HAREKETS = db.STOK_URETIM_FISI_HAREKET.Where(x => x.FISID == id);
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }

        }

        [HttpPost]
        public JsonResult FisData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
        {
            if (sort == "GIRIS" || sort == "CIKIS")
                sort = "TOPLAMMASRAF";

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
            List<üretimfişi> hareketler = new List<üretimfişi>();

            var zaman = new DateTime();
            var sonzaman = new DateTime();


            object sayi = 26;
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




            var v = (from a in db.STOK_URETIM_FISI.Where(x => x.deleted != 1).Where(x => DbFunctions.TruncateTime(x.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);


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


                var yenihareket = new üretimfişi();

                yenihareket.ID = item.ID;

                yenihareket.TARIH = item.TARIH.Value.ToShortDateString();
                yenihareket.FISNO = item.FISNO;

                yenihareket.TOPLAM_TUTAR = item.TOPLAM_TUTAR.ToString();
                yenihareket.ACIKLAMA = item.ACIKLAMA;



                hareketler.Add(yenihareket);



            }

            db.Dispose();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RECETEFISKART(modelimiz carifis)
        {
            changestring();

            if (degistirme == true)
            {
                return View(carifis.fis);
            }
            else
            {
                return Redirect("/Home");
            }

        }

        public ActionResult RECETEFIS(string tip)
        {
            changestring();
            var model = new modelimiz();

            model.STOK_URETIM_FISIS = (db.STOK_URETIM_FISI.Count()+1).ToString().PadLeft(4, '0');
         

            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();

     
            if (ekleme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public ActionResult RECETEFISLISTE()
        {
            changestring();


            var model = new modelimiz();
     
            if (gorme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
    }
}