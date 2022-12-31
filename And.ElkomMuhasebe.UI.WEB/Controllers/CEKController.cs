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
    public class CEKController : Controller
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
                    if (alt.görme.Contains("Çekler"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Çekler"))
                            ekleme = true;
                        if (alt.silme.Contains("Çekler"))
                            silme = true;
                        if (alt.degistir.Contains("Çekler"))
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


        public class AlınanCekvieweNodel
        {
            public string TARIH { get; set; }
            public int ID { get; set; }
            public string ALINANKISIADI { get; set; }
            public string ALINANKISIKODU { get; set; }
            public string VERILENKISIADI { get; set; }
            public string VERILENKISIKODU { get; set; }
            public string VERILENBANKADI { get; set; }
            public string VERILENBANKAKODU { get; set; }
            public string PORTFOYNO { get; set; }
            public string VADE { get; set; }
            public string CEKDURUMU { get; set; }
            public string CEKKESIDEYERI { get; set; }
            public string CEKKESIDETARIHI { get; set; }
            public string ACIKLAMA { get; set; }
            public string TUTAR { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
        }
        public class çekmodel
        {


            public string CARIKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }

            public List<cekhareket> gelenhareket { get; set; }
           


       

        }
        public class cekhareket
        {

            public  enum harekettip
            {
                ÇekÖdeme,ÇekTahsil,KarşılıksızÇek,Çekİade,CiroluÇekİade,FirmaÇekİade

            }
            public harekettip HAREKET { get; set; }

            public string KASA { get; set; }
            public string PORTFOYNO { get; set; }
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
        public class modelimiz
        {
            public CEKLER_VERILEN CEKLER_VERILEN { get; set; }
            public CEKLER_ALINAN CEKLER_ALINAN { get; set; }
            public KUR_BASLIK Kur { get; set; }

            public IEnumerable<CEKLER_ALINAN> CEKLER_ALINANs { get; set; }
            public IEnumerable<CEKLER_VERILEN> CEKLER_VERILENs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<CEKLER_ALINAN_HAREKET> CEKLER_ALINAN_HAREKETs { get; set; }
            public IEnumerable<CEKLER_VERILEN_HAREKET> CEKLER_VERILEN_HAREKETs { get; set; }
           
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }
   
        }

        [HttpPost]
        public JsonResult VERILENFISDATA(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
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
            List<AlınanCekvieweNodel> hareketler = new List<AlınanCekvieweNodel>();


            var zaman =new DateTime();
            var sonzaman = new DateTime();

            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "hareket.PORTFOYNO";
            aranacaklar[1] = "hareket.ACIKLAMA";




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
                        query += $"(5==5)";
                    }

                  

                    if (filterler[i].filtretipi == 7)
                        query += $"{  filterler[i].verismi }==(\"{ filterler[i].deger }\")";
                }

            query += ")";




            var v = (from a in db.CEKLER_VERILEN.Select(pr => new
            {
                hareket = pr,
          
                VERILENKISIADI = pr.VERILENKISI.FIRMAUNVANI,
                VERILENKISIKODU =pr.VERILENKISI.CARIKOD,
                S_MERKEZI = pr.S_MERKEZI.ACIKLAMA
            }).Where(x => x.hareket.deleted != 1).Where(x => DbFunctions.TruncateTime(x.hareket.VADE) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.VADE) <= DbFunctions.TruncateTime(sonzaman)).Where(query)
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


                var yenihareket = new AlınanCekvieweNodel();

                yenihareket.ID = item.hareket.ID;

                yenihareket.TARIH = item.hareket.KESIDETARIHI.Value.ToShortDateString();
                yenihareket.PORTFOYNO = item.hareket.PORTFOYNO;
           
                    yenihareket.VERILENKISIADI = item.VERILENKISIADI;
             
                    yenihareket.VERILENKISIKODU = item.VERILENKISIKODU;


                yenihareket.CEKKESIDETARIHI = item.hareket.KESIDETARIHI.Value.ToShortDateString();

                if (!string.IsNullOrEmpty(item.hareket.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.hareket.ACIKLAMA;



                yenihareket.CEKDURUMU = item.hareket.CEKDURUMU.ToString();
                yenihareket.VADE = item.hareket.VADE.Value.ToString("yyyy-MM-dd");

                yenihareket.CEKKESIDEYERI = "";
                yenihareket.TUTAR = item.hareket.TUTAR.ToString();

                yenihareket.SORUMLULUK_MERKEZI = item.S_MERKEZI;
                hareketler.Add(yenihareket);



            }

            db.Dispose();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);






        }

        [HttpPost]
        public JsonResult ALINANFISDATA(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
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
            List<AlınanCekvieweNodel> hareketler = new List<AlınanCekvieweNodel>();




            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "hareket.PORTFOYNO";
            aranacaklar[1] = "hareket.ACIKLAMA";
            



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
                        query += $"(5==5)";
                    }

                    if (filterler[i].filtretipi == 7)
                        query += $"{  filterler[i].verismi }==(\"{ filterler[i].deger }\")";
                }

            query += ")";




            var v = (from a in db.CEKLER_ALINAN.Select(pr => new
            {
                hareket = pr,
                VERILENBANKADI = pr.VERILENBANKAID!=null? pr.VERILENBANKA.BANKAADI : "",
                VERILENBANKAKODU = pr.VERILENBANKAID != null ? pr.VERILENBANKA.BANKAKODU : "",
                ALINANKISIADI =  pr.ALINANKISI.FIRMAUNVANI ,
                ALINANKISIKODU =pr. ALINANKISI.CARIKOD ,
                VERILENKISIADI = pr.CIROKISIID != null ? pr.CIROKISI.FIRMAUNVANI : "",
                VERILENKISIKODU = pr.CIROKISIID != null ? pr.CIROKISI.CARIKOD : "",
                S_MERKEZI = pr.S_MERKEZI.ACIKLAMA
            }).Where(x => x.hareket.deleted != 1).Where(x => DbFunctions.TruncateTime(x.hareket.VADE.Value) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.VADE.Value) <= DbFunctions.TruncateTime(sonzaman)).Where(query)
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


                var yenihareket = new AlınanCekvieweNodel();

                yenihareket.ID = item.hareket.ID;
                yenihareket.ALINANKISIADI = item.ALINANKISIADI;
                yenihareket.ALINANKISIKODU = item.ALINANKISIKODU;

            
                    yenihareket.VERILENKISIADI = item.VERILENKISIADI;
               
                    yenihareket.VERILENKISIKODU = item.VERILENKISIKODU;


                    yenihareket.VERILENBANKADI = item.VERILENBANKADI;
             
                    yenihareket.VERILENBANKAKODU = item.VERILENBANKAKODU;

                yenihareket.PORTFOYNO = item.hareket.PORTFOYNO;
                yenihareket.TARIH = item.hareket.TARIH.Value.ToShortDateString();
                yenihareket.VADE = item.hareket.VADE.Value.ToString("yyyy-MM-dd");
                yenihareket.CEKKESIDETARIHI = item.hareket.CEKKESIDETARIHI.Value.ToShortDateString(); 

                if (!string.IsNullOrEmpty(item.hareket.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.hareket.ACIKLAMA;


 
                    yenihareket.CEKDURUMU = item.hareket.CEKDURUMU.ToString();
           
                if (!string.IsNullOrEmpty(item.hareket.CEKKESIDEYERI))
                    yenihareket.CEKKESIDEYERI = item.hareket.CEKKESIDEYERI;
                yenihareket.TUTAR = item.hareket.TUTAR.ToString();

                yenihareket.SORUMLULUK_MERKEZI = item.S_MERKEZI;
                hareketler.Add(yenihareket);



            }

            db.Dispose();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        [HttpPost]
        public JsonResult datagonder(çekmodel gelenveri)
        {
            changestring();

            var cari = db.CARI_BASLIK.Where(x => x.ID.ToString()==gelenveri.CARIKOD).FirstOrDefault();
            var smerkezi = db.SORUMLULUK_MERKEZI.Where(X => X.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;


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
                        if ((int)item.HAREKET == 1 || (int)item.HAREKET == 2)
                        {
                            var alınancek = db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).First();
                            switch ((int)item.HAREKET)
                            {
                                case 1: alınancek.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.TahsilEdildi; break;
                                case 2: alınancek.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.Karşılıksız; break;
                                case 3: alınancek.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.İadeEdilenler; break;

                            }
                            alınancek.TAHSILTARIHI = DateTime.Parse(gelenveri.TARIH);
                            db.Entry(alınancek).State = EntityState.Modified;
                            var cekhareket = new CEKLER_ALINAN_HAREKET();
                            switch ((int)item.HAREKET)
                            {
                                case 1: cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.TahsilEdildi; break;
                                case 2: cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.Karşılıksız; break;
                                case 3: cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.İadeEdilenler; break;
                                case 4: cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.İadeEdilenler; break;
                            }
                            cekhareket.CEK = alınancek;

                            cekhareket.ACIKLAMA = item.ACIKLAMA;
                            cekhareket.DOSYANO = gelenveri.FISNO;
                            cekhareket.PORTFOYNO = item.PORTFOYNO;
                            cekhareket.TARIH = DateTime.Now;


                            cekhareket.CreateDate = DateTime.Now;
                            cekhareket.CreateUserID = userid;
                            db.CEKLER_ALINAN_HAREKET.Add(cekhareket);
                            if ((int)item.HAREKET == 1)
                            {

                                var kasa = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();

                                var kasahareket = new KASA_HAREKET();
                                kasahareket.KASA = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();
                                kasahareket.KASAKODU = kasahareket.KASA.KASAKODU;
                                kasahareket.ILGILI = cari.FIRMAUNVANI;
                                kasahareket.CreateDate = DateTime.Now;
                                kasahareket.CreateUserID = userid;
                                kasahareket.ISLEMNO = gelenveri.FISNO;
                                kasahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                                if ((int)item.HAREKET == 0)
                                    kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.Çek;
                                if ((int)item.HAREKET == 1)
                                    kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.TÇek;
                                if ((int)item.HAREKET == 2)
                                {

                                    kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.TKarşılıksızÇek;
                                }


                                kasahareket.S_MERKEZIID = smerkezi;
                                if ((int)item.HAREKET == 1)
                                {
                                    kasahareket.TIPI = CARI_HAREKET.tip.Giriş;

                                    kasahareket.BORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                                    kasa.TOPLAMBORC += kasahareket.BORC;
                                   
                                    kasahareket.BAKIYE = kasa.BAKIYE;
                                    if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                                    {
                                        var eskihareket = new KASA_HAREKET();
                                        if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).Count() > 0)
                                        {
                                            eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                                        }
                                        else { eskihareket.BAKIYE = 0; }




                                        kasahareket.BAKIYE = eskihareket.BAKIYE + kasahareket.BORC;

                                        foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU))
                                        {
                                            hareketz.BAKIYE += kasahareket.BORC;

                                        }



                                    }
                                    else
                                    {



                                        kasahareket.BAKIYE = kasa.BAKIYE;

                                    }



                                }

                                kasahareket.ACIKLAMA = item.ACIKLAMA;
                                db.KASA_HAREKET.Add(kasahareket);

                                var kasa2 = db.KASA.Where(x => x.KASAADI == alınancek.KASA).FirstOrDefault();

                                var kasahareket2 = new KASA_HAREKET();
                                kasahareket2.KASA = db.KASA.Where(x => x.KASAADI == alınancek.KASA).FirstOrDefault();
                                kasahareket2.KASAKODU = kasahareket2.KASA.KASAKODU;
                                kasahareket2.ILGILI = cari.FIRMAUNVANI;
                                kasahareket2.CreateDate = DateTime.Now;
                                kasahareket2.CreateUserID = userid;
                                kasahareket2.ISLEMNO = gelenveri.FISNO;
                                kasahareket2.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                                if ((int)item.HAREKET == 0)
                                    kasahareket2.ISLEMTURU = KASA_HAREKET.kasaislemtürü.Çek;
                                if ((int)item.HAREKET == 1)
                                    kasahareket2.ISLEMTURU = KASA_HAREKET.kasaislemtürü.TÇek;
                                if ((int)item.HAREKET == 2)
                                {

                                    kasahareket2.ISLEMTURU = KASA_HAREKET.kasaislemtürü.TKarşılıksızÇek;
                                }



                                if ((int)item.HAREKET == 1)
                                {
                                    kasahareket2.TIPI = CARI_HAREKET.tip.Çıkış;

                                    kasahareket2.ALACAK = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                                    kasa2.TOPLAMALACAK += kasahareket2.ALACAK;
                                   
                                    kasahareket2.BAKIYE = kasa2.BAKIYE;


                                    if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                                    {
                                        var eskihareket = new KASA_HAREKET();
                                        if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket2.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).Count() > 0)
                                        {
                                            eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket2.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                                        }
                                        else { eskihareket.BAKIYE = 0; }




                                        kasahareket2.BAKIYE = eskihareket.BAKIYE + kasahareket2.BORC;

                                        foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket2.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU))
                                        {
                                            hareketz.BAKIYE -= kasahareket2.ALACAK;

                                        }



                                    }
                                    else
                                    {



                                        kasahareket2.BAKIYE = kasa2.BAKIYE;

                                    }
                                }
                                kasahareket2.S_MERKEZIID = smerkezi;
                                kasahareket2.ACIKLAMA = item.ACIKLAMA;
                                db.KASA_HAREKET.Add(kasahareket2);




                                //////////////////////////////////////////////////////////////////////////////////////////////


                            }
                            if ((int)item.HAREKET == 2)
                            {

                                var kasa = db.KASA.Where(x => x.KASAADI == alınancek.KASA).FirstOrDefault();

                                var kasahareket = new KASA_HAREKET();
                                kasahareket.KASA = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();
                                kasahareket.KASAKODU = kasahareket.KASA.KASAKODU;
                                kasahareket.ILGILI = cari.FIRMAUNVANI;
                                kasahareket.CreateDate = DateTime.Now;
                                kasahareket.CreateUserID = userid;
                                kasahareket.ISLEMNO = gelenveri.FISNO;
                                kasahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                           
                             
                                    kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.TKarşılıksızÇek;
                              


                                kasahareket.S_MERKEZIID = smerkezi;
                           
                                    kasahareket.TIPI = CARI_HAREKET.tip.Çıkış;

                                    kasahareket.ALACAK = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                                    kasa.TOPLAMALACAK += kasahareket.ALACAK;
                                  
                                    kasahareket.BAKIYE = kasa.BAKIYE;
                                    if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                                    {
                                        var eskihareket = new KASA_HAREKET();
                                        if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).Count() > 0)
                                        {
                                            eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                                        }
                                        else { eskihareket.BAKIYE = 0; }




                                        kasahareket.BAKIYE = eskihareket.BAKIYE + kasahareket.BORC;

                                        foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU))
                                        {
                                            hareketz.BAKIYE -= kasahareket.ALACAK;

                                        }



                                    }
                                    else
                                    {



                                        kasahareket.BAKIYE = kasa.BAKIYE;

                                    }



                                kasahareket.ACIKLAMA = item.ACIKLAMA;
                                db.KASA_HAREKET.Add(kasahareket);
                                db.SaveChanges();


                            }
                        }
                        if ((int)item.HAREKET == 0 )
                        {
                            var alınancek = db.CEKLER_VERILEN.Where(x => x.PORTFOYNO == item.PORTFOYNO).First();
                            switch ((int)item.HAREKET)
                            {
                                case 0: alınancek.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.Ödenmiş; break;
                                case 4: alınancek.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.İadeAlınanlar; break;
                                case 5: alınancek.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.İadeAlınanlar; break;

                            }
                            alınancek.ODEMETARIHI = DateTime.Parse(gelenveri.TARIH);
                            db.Entry(alınancek).State = EntityState.Modified;
                            var cekhareket = new CEKLER_VERILEN_HAREKET();
                            switch ((int)item.HAREKET)
                            {
                                case 0: cekhareket.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.Ödenmiş; break;
                                case 4: cekhareket.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.İadeAlınanlar; break;
                                case 5: cekhareket.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.İadeAlınanlar; break;
                            }
                            cekhareket.CEK = alınancek;

                            cekhareket.ACIKLAMA = item.ACIKLAMA;
                            cekhareket.DOSYANO = gelenveri.FISNO;
                            cekhareket.CEKNO = item.PORTFOYNO;
                            cekhareket.TARIH = DateTime.Now;

                

                            cekhareket.CreateDate = DateTime.Now;
                            cekhareket.CreateUserID = userid;
                            db.CEKLER_VERILEN_HAREKET.Add(cekhareket);
                            if ((int)item.HAREKET == 0)
                            {

                                var kasa = db.KASA.Where(x => x.KASAADI == alınancek.KASA).FirstOrDefault();

                                var kasahareket = new KASA_HAREKET();
                                kasahareket.KASA = db.KASA.Where(x => x.KASAADI == alınancek.KASA).FirstOrDefault();
                                kasahareket.KASAKODU = kasahareket.KASA.KASAKODU;
                                kasahareket.ILGILI = cari.FIRMAUNVANI;
                                kasahareket.CreateDate = DateTime.Now;
                                kasahareket.CreateUserID = userid;
                                kasahareket.ISLEMNO = gelenveri.FISNO;
                                kasahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);

                                kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.Çek;

                                kasahareket.S_MERKEZIID = smerkezi;


                                kasahareket.TIPI = CARI_HAREKET.tip.Giriş;

                                kasahareket.BORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                                kasa.TOPLAMBORC += kasahareket.BORC;
                             
                                if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                                {
                                    var eskihareket = new KASA_HAREKET();
                                    if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).Count() > 0)
                                    {
                                        eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                                    }
                                    else { eskihareket.BAKIYE = 0; }




                                    kasahareket.BAKIYE = eskihareket.BAKIYE + kasahareket.BORC;
                                   
                                    foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU))
                                    {
                                        hareketz.BAKIYE += kasahareket.BORC;
                                      
                                    }



                                }
                                else
                                {



                                    kasahareket.BAKIYE = kasa.BAKIYE;

                                }
                             




                                kasahareket.ACIKLAMA = item.ACIKLAMA;
                                db.KASA_HAREKET.Add(kasahareket);

                                var kasa2 = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();

                                var kasahareket2 = new KASA_HAREKET();
                                kasahareket2.KASA = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();
                                kasahareket2.KASAKODU = kasahareket2.KASA.KASAKODU;
                                kasahareket2.ILGILI = cari.FIRMAUNVANI;
                                kasahareket2.CreateDate = DateTime.Now;
                                kasahareket2.CreateUserID = userid;
                                kasahareket2.ISLEMNO = gelenveri.FISNO;
                                kasahareket2.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);

                                kasahareket2.ISLEMTURU = KASA_HAREKET.kasaislemtürü.Çek;




                                kasahareket2.S_MERKEZIID = smerkezi;

                                kasahareket2.TIPI = CARI_HAREKET.tip.Çıkış;

                                kasahareket2.ALACAK = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                                kasa2.TOPLAMALACAK += kasahareket2.ALACAK;
                              



                                kasahareket2.ACIKLAMA = item.ACIKLAMA;

                                if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                                {
                                    var eskihareket = new KASA_HAREKET();
                                    if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket2.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).Count() > 0)
                                    {
                                        eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket2.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                                    }
                                    else { eskihareket.BAKIYE = 0; }




                                    kasahareket2.BAKIYE = eskihareket.BAKIYE + kasahareket2.BORC;

                                    foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket2.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU))
                                    {
                                        hareketz.BAKIYE += kasahareket2.BORC;

                                    }



                                }
                                else
                                {



                                    kasahareket2.BAKIYE = kasa2.BAKIYE;

                                }
                                db.KASA_HAREKET.Add(kasahareket2);


                            }
                        }


                        if ((int)item.HAREKET == 3 || (int)item.HAREKET == 4 || (int)item.HAREKET == 5)
                        {
                            if ((int)item.HAREKET == 3) { 
                            var alınancek = db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).First();
                         alınancek.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.İadeEdilenler;
                             
                                alınancek.VADE = DateTime.Parse(gelenveri.TARIH);
                                db.Entry(alınancek).State = EntityState.Modified;
                                db.SaveChanges();
                                var cekhareket = new CEKLER_ALINAN_HAREKET();
                            cekhareket.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.İadeEdilenler; 
                                 
                                cekhareket.CEK = alınancek;

                                cekhareket.ACIKLAMA = item.ACIKLAMA;
                                cekhareket.DOSYANO = gelenveri.FISNO;
                                cekhareket.PORTFOYNO = item.PORTFOYNO;
                                cekhareket.TARIH = DateTime.Now;



                                cekhareket.CreateDate = DateTime.Now;
                                cekhareket.CreateUserID = userid;
                                db.CEKLER_ALINAN_HAREKET.Add(cekhareket);
                                db.SaveChanges();
                            }
                            else if((int)item.HAREKET == 5)
                            {
                                var alınancek = db.CEKLER_VERILEN.Where(x => x.PORTFOYNO == item.PORTFOYNO).First();
                                alınancek.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.İadeAlınanlar; 

                                alınancek.ODEMETARIHI = DateTime.Parse(gelenveri.TARIH);
                                db.Entry(alınancek).State = EntityState.Modified;
                                db.SaveChanges();
                                var cekhareket = new CEKLER_VERILEN_HAREKET();
                                cekhareket.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.İadeAlınanlar;

                                cekhareket.CEK = alınancek;

                                cekhareket.ACIKLAMA = item.ACIKLAMA;
                                cekhareket.DOSYANO = gelenveri.FISNO;
                                cekhareket.CEKNO = item.PORTFOYNO;
                                cekhareket.TARIH = DateTime.Now;



                                cekhareket.CreateDate = DateTime.Now;
                                cekhareket.CreateUserID = userid;
                                db.CEKLER_VERILEN_HAREKET.Add(cekhareket);
                                db.SaveChanges();
                            }




                            var hareket = new CARI_HAREKET();
                            hareket.cari = cari;
                            hareket.CARIKOD = hareket.cari.CARIKOD;
                            hareket.CreateDate = DateTime.Now;

                            hareket.CreateUserID = userid;
                            hareket.ISLEMNO = item.PORTFOYNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            hareket.ISLEMTURU = CARI_HAREKET.tür.Çekİade;
                            hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                            hareket.ACIKLAMA = item.ACIKLAMA;
                            hareket.BORC = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));

                            hareket.S_MERKEZIID = smerkezi;

                         
                            cari.TOPLAMBORC += hareket.BORC;

                  
                            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new CARI_HAREKET();
                                if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).Count() > 0)
                                {
                                    eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }




                                hareket.BAKIYE = eskihareket.BAKIYE + hareket.BORC;
                                hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE + hareket.BORC;
                                foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                                {
                                    hareketz.BAKIYE += hareket.BORC;
                                    hareketz.DOVIZBAKIYE += hareket.BORC;
                                }



                            }
                            else
                            {



                                hareket.BAKIYE = cari.BAKIYE;
                                hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;
                            }
                            db.CARI_HAREKET.Add(hareket);

                        }



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
                    return Json("Başarısız!"+ex.InnerException+ex.Message);
                }


            }
        }

        public  class cekhareketi
        {
            public int ID { get; set; }
            public string PORTFOYNO { get; set; }
            public string CEKDURUMU { get; set; }
            public string TARIH { get; set; }
            public string ACIKLAMA { get; set; }
            public string HARAKET { get; set; }
       
            public string DOSYANO { get; set; }

        }


        [HttpPost]
        public JsonResult GetHareketData(string search, string order, int offset, int limit, string sort, int id, filtermodel[] filterler)
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
            List<cekhareketi> hareketler = new List<cekhareketi>();


            var zaman = new DateTime();
            var sonzaman = new DateTime();

            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "PORTFOYNO";
            aranacaklar[1] = "ACIKLAMA";




            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";
            if (id != 0)
            {
                query += $"&&({"CEKID"}=={ id })";
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




            var v = (from a in db.CEKLER_ALINAN_HAREKET.Where(x => x.deleted != 1).Where(x => DbFunctions.TruncateTime(x.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);


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


                var yenihareket = new cekhareketi();

                yenihareket.ID = item.ID;
                yenihareket.PORTFOYNO = item.PORTFOYNO;
                yenihareket.TARIH = item.TARIH.Value.ToShortDateString();
                yenihareket.HARAKET = item.HARAKET.ToString();
                if(!string.IsNullOrEmpty(item.DOSYANO))
                yenihareket.DOSYANO = item.DOSYANO;
                yenihareket.CEKDURUMU = item.CEKDURUMU.ToString();
         

                if (!string.IsNullOrEmpty(yenihareket.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.ACIKLAMA;
                else { yenihareket.ACIKLAMA = ""; }

                hareketler.Add(yenihareket);



            }

            db.Dispose();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
        [HttpPost]
        public JsonResult GetHareketVerilenData(string search, string order, int offset, int limit, string sort, int id, filtermodel[] filterler)
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
            List<cekhareketi> hareketler = new List<cekhareketi>();

            var zaman = new DateTime();
            var sonzaman = new DateTime();


            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "CEKNO";
            aranacaklar[1] = "ACIKLAMA";




            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";
            if (id != 0)
            {
                query += $"&&({"CEKID"}=={ id })";
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




            var v = (from a in db.CEKLER_VERILEN_HAREKET.Where(x => x.deleted != 1).Where(x => DbFunctions.TruncateTime(x.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);


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


                var yenihareket = new cekhareketi();

                yenihareket.ID = item.ID;
                yenihareket.PORTFOYNO = item.CEKNO;
                yenihareket.TARIH = item.TARIH.Value.ToShortDateString();
                yenihareket.HARAKET = item.HARAKET.ToString();
                if (!string.IsNullOrEmpty(item.DOSYANO))
                    yenihareket.DOSYANO = item.DOSYANO;
                yenihareket.CEKDURUMU = item.CEKDURUMU.ToString();


                if (!string.IsNullOrEmpty(yenihareket.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.ACIKLAMA;
                else { yenihareket.ACIKLAMA = ""; }

                hareketler.Add(yenihareket);



            }

            db.Dispose();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
        // GET: CEK
        public ActionResult VerilenFisler()
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
        public ActionResult AlınanFisler()
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
        public ActionResult CekIslemleri()
        {
            changestring();
            var model = new CARI_HAREKETController.modelimiz();

            model.CARI_FIs = db.CEKSENET_ISLEMLERI.Count();
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.Hareket = new CARI_HAREKET();
            model.CARI_HAREKETs = new List<CARI_HAREKET>();
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
  

        public ActionResult CekHareketleri(int id)
        {
            changestring();

            var model = new CARI_HAREKETController.yenimodel();
            model.id = id;

            model.kodu = db.CEKLER_ALINAN.Where(x => x.ID == id).FirstOrDefault().PORTFOYNO;

            if (gorme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public ActionResult CekHareketleriVerilen(int id)
        {
            changestring();

            var model = new CARI_HAREKETController.yenimodel();
            model.id = id;

            model.kodu = db.CEKLER_VERILEN.Where(x => x.ID == id).FirstOrDefault().PORTFOYNO;

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