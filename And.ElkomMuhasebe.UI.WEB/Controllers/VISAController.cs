using System;
using System.Collections.Generic;
using System.Data;

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
    public class VISAController : Controller
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
                    if (alt.görme.Contains("Banka Hareketleri Ve Fişleri"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Cari Hareketleri Ve Fişleri"))
                            ekleme = true;
                        if (alt.silme.Contains("Cari Hareketleri Ve Fişleri"))
                            silme = true;
                        if (alt.degistir.Contains("Cari Hareketleri Ve Fişleri"))
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
        public class visamodel
        {


            public string BANKAKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }

            public List<visahareket> gelenhareket { get; set; }





        }
        public class visahareket
        {

          
            public string HAREKET { get; set; }

        
            public string PORTFOYNO { get; set; }
            public string KOMISYON { get; set; }
            public string ACIKLAMA { get; set; }
            public string VADE { get; set; }
            public string TUTAR { get; set; }



        }
        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }

        // GET: VISA
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisaIslemleri()
        {
            changestring();
            var model = new CARI_HAREKETController.modelimiz();

            model.CARI_FIs = db.BANKA_VISA_ISLEMLERI.Count();
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
       
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
        [HttpPost]
        public JsonResult datagonder(visamodel gelenveri)
        {
            changestring();

            var banka = db.BANKA.Where(x => x.BANKAKODU == gelenveri.BANKAKOD).FirstOrDefault();
            var bankviseislemi = new BANKA_VISA_ISLEMLERI();
            bankviseislemi.ACIKLAMA = gelenveri.NOT;
            bankviseislemi.DOSYANO = gelenveri.FISNO;
            bankviseislemi.CreateDate = DateTime.Now;
            bankviseislemi.CreateUserID = userid;
            bankviseislemi.BANKAKOD = gelenveri.BANKAKOD;
            double toplam = 0;
           
            if (gelenveri.gelenhareket.Count == 0)
            {
                var jsonResult = Json("Başarısız", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
            else
            {
                foreach (var item in gelenveri.gelenhareket)
                {toplam+=  double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ",")); 
                   var no = int.Parse(item.PORTFOYNO);
                        var visa = db.BANKA_VISA.Where(x => x.PORTFOYNO == no).First();
    
                     
                        var hareket = new BANKA_VISA_ISLEMLERI_H();
                    
                        hareket.VISAID= visa.ID;

                        hareket.ACIKLAMA = item.ACIKLAMA;
                        hareket.DOSYANO = gelenveri.FISNO;
                        hareket.PORTFOYNO = item.PORTFOYNO;
                        hareket.KOMISYON = double.Parse(item.KOMISYON.ToString().Replace(",", "").Replace(".", ","));
                        hareket.TUTAR = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                        hareket.CreateDate = DateTime.Now;
                        hareket.CreateUserID = userid;
                        db.BANKA_VISA_ISLEMLERI_H.Add(hareket);
                        db.SaveChanges();
                        if (item.HAREKET == "VisaTahsil")
                        {
                            visa.DURUMU = BANKA_VISA.DURUMLAR.TahsilEdildi;
                            var bankahareket = new BANKA_HAREKET();
                            bankahareket.BANKA = banka;
                            bankahareket.BANKAKODU = banka.BANKAKODU;
                            bankahareket.BORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                            bankahareket.ALACAK = 0;
                            banka.TOPLAMBORC += bankahareket.BORC;
                            bankahareket.BAKIYE = banka.BAKIYE;
                          
                            bankahareket.ISLEMTURU = CARI_HAREKET.tür.Visa;
                            bankahareket.CreateDate = DateTime.Now;
                            bankahareket.CreateUserID = userid;
                            bankahareket.ACIKLAMA = item.ACIKLAMA;
                            bankahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            bankahareket.DOSYANO = gelenveri.FISNO;
                            bankahareket.ISLEMNO = gelenveri.FISNO;
                            bankahareket.S_MERKEZIID = 1;
                            bankahareket.TIPI = CARI_HAREKET.tip.Giriş;

                            db.BANKA_HAREKET.Add(bankahareket);
                            db.SaveChanges();
                            var kasa2 = db.KASA.Where(x => x.KASAKODU == visa.KASA).FirstOrDefault();

                            var kasahareket2 = new KASA_HAREKET();
                            kasahareket2.KASA = db.KASA.Where(x => x.KASAKODU == visa.KASA).FirstOrDefault();
                            kasahareket2.KASAKODU = kasahareket2.KASA.KASAKODU;
                            kasahareket2.ILGILI = banka.BANKAKODU;
                            kasahareket2.CreateDate = DateTime.Now;
                            kasahareket2.CreateUserID = userid;
                            kasahareket2.ISLEMNO = gelenveri.FISNO;
                            kasahareket2.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);

                            kasahareket2.ISLEMTURU = KASA_HAREKET.kasaislemtürü.VisaTahsili;




                          
                                kasahareket2.TIPI = CARI_HAREKET.tip.Çıkış;

                                kasahareket2.ALACAK = bankahareket.BORC;
                            kasahareket2.BORC = 0;
                            kasa2.TOPLAMALACAK += kasahareket2.ALACAK;
                                kasahareket2.BAKIYE = kasa2.BAKIYE;



                        kasahareket2.S_MERKEZIID =db.SORUMLULUK_MERKEZI.Where(x=>x.ACIKLAMA== gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
                            kasahareket2.ACIKLAMA = item.ACIKLAMA;
                            db.KASA_HAREKET.Add(kasahareket2);
                            db.SaveChanges();
                        }
                        else
                        {
                            visa.DURUMU = BANKA_VISA.DURUMLAR.Ödenmiş;
                            var bankahareket = new BANKA_HAREKET();
                            bankahareket.BANKA = banka;
                            bankahareket.BANKAKODU = banka.BANKAKODU;
                            bankahareket.ALACAK = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                            bankahareket.BORC = 0;
                            banka.TOPLAMALACAK += bankahareket.ALACAK;
                            bankahareket.BAKIYE = banka.BAKIYE;

                            bankahareket.ISLEMTURU = CARI_HAREKET.tür.Visa;
                            bankahareket.CreateDate = DateTime.Now;
                            bankahareket.CreateUserID = userid;
                            bankahareket.ACIKLAMA = item.ACIKLAMA;
                            bankahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            bankahareket.DOSYANO = gelenveri.FISNO;
                            bankahareket.ISLEMNO = gelenveri.FISNO;
                            bankahareket.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;

                        bankahareket.TIPI = CARI_HAREKET.tip.Çıkış;

                            db.BANKA_HAREKET.Add(bankahareket);
                            db.SaveChanges();
                            var kasa2 = db.KASA.Where(x => x.KASAKODU == visa.KASA).FirstOrDefault();

                            var kasahareket2 = new KASA_HAREKET();
                            kasahareket2.KASA = db.KASA.Where(x => x.KASAKODU == visa.KASA).FirstOrDefault();
                            kasahareket2.KASAKODU = kasahareket2.KASA.KASAKODU;
                            kasahareket2.ILGILI = banka.BANKAKODU;
                            kasahareket2.CreateDate = DateTime.Now;
                            kasahareket2.CreateUserID = userid;
                            kasahareket2.ISLEMNO = gelenveri.FISNO;
                            kasahareket2.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);

                            kasahareket2.ISLEMTURU = KASA_HAREKET.kasaislemtürü.VisaÖdeme;





                            kasahareket2.TIPI = CARI_HAREKET.tip.Giriş;

                            kasahareket2.BORC = bankahareket.ALACAK;
                            kasahareket2.ALACAK = 0;
                            kasa2.TOPLAMBORC += kasahareket2.BORC;
                            kasahareket2.BAKIYE = kasa2.BAKIYE;



                        kasahareket2.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
                        kasahareket2.ACIKLAMA = item.ACIKLAMA;
                            db.KASA_HAREKET.Add(kasahareket2);
                            db.SaveChanges();

                        }
                        if (double.Parse(item.KOMISYON.Replace(".", ","))>0)
                        {
                            var bankahareket = new BANKA_HAREKET();
                            bankahareket.BANKA = banka;
                            bankahareket.BANKAKODU = banka.BANKAKODU;
                            bankahareket.ALACAK = double.Parse(item.KOMISYON.Replace(".", ","));
                            bankahareket.BORC = 0;
                            banka.TOPLAMALACAK += bankahareket.ALACAK;
                            bankahareket.BAKIYE = banka.BAKIYE;

                            bankahareket.ISLEMTURU = CARI_HAREKET.tür.VisaKomisyon;
                            bankahareket.CreateDate = DateTime.Now;
                            bankahareket.CreateUserID = userid;
                            bankahareket.ACIKLAMA = item.ACIKLAMA;
                            bankahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            bankahareket.DOSYANO = gelenveri.FISNO;
                            bankahareket.ISLEMNO = gelenveri.FISNO;
                            bankahareket.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
                        bankahareket.TIPI = CARI_HAREKET.tip.Çıkış;
                       
                            db.BANKA_HAREKET.Add(bankahareket);
                            db.SaveChanges();

                        }
                      
                    }
                 


                    db.SaveChanges();
                

                bankviseislemi.TOPLAMTUTAR = toplam;
                db.BANKA_VISA_ISLEMLERI.Add(bankviseislemi);
                db.SaveChanges();

                               var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
        }

        public class VisaModel
        {
            public string TARIH { get; set; }
            public int ID { get; set; }
            public string CARIID { get; set; }
     
            public string PORTFOYNO { get; set; }
            public string VADE { get; set; }
            public string DURUMU { get; set; }
            public string BANKAKODU { get; set; }
            public string TARIHI { get; set; }
            public string ACIKLAMA { get; set; }
            public string TUTAR { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
        }
        [HttpPost]
        public JsonResult GETVISA(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
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
            List<VisaModel> hareketler = new List<VisaModel>();
            var zaman = new DateTime();
            var sonzaman = new DateTime();



            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[1];

            
            aranacaklar[0] = "ACIKLAMA";




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

                    

                    if (filterler[i].filtretipi == 7)
                        query += $"{  filterler[i].verismi }==(\"{ filterler[i].deger }\")";
                }

            query += ")";




            var v = (from a in db.BANKA_VISA.Where(x => x.deleted != 1).Where(x => DbFunctions.TruncateTime(x.TARIHI) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.TARIHI) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);


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


                var yenihareket = new VisaModel();

                yenihareket.ID = item.ID;

                yenihareket.TARIH = item.TARIHI.Value.ToShortDateString();
                yenihareket.PORTFOYNO = item.PORTFOYNO.ToString();
                yenihareket.CARIID = db.CARI_BASLIK.Find(item.CARIID).CARIKOD;

                yenihareket.TARIHI = item.TARIHI.Value.ToShortDateString();

                if (!string.IsNullOrEmpty(item.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.ACIKLAMA;



                yenihareket.DURUMU = item.DURUMU.ToString();
                yenihareket.VADE = item.VADE.Value.ToString("yyyy-MM-dd");

                yenihareket.BANKAKODU = item.BANKAKODU;
                yenihareket.TUTAR = item.TUTAR.ToString();

                yenihareket.SORUMLULUK_MERKEZI = db.SORUMLULUK_MERKEZI.Find(item.S_MERKEZI).ACIKLAMA;
                hareketler.Add(yenihareket);



            }


            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);






        }
    }
}