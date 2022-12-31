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
    public class BANKA_HAREKETController : Controller
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
                        if (alt.ekleme.Contains("Banka Hareketleri Ve Fişleri"))
                            ekleme = true;
                        if (alt.silme.Contains("Banka Hareketleri Ve Fişleri"))
                            silme = true;
                        if (alt.degistir.Contains("Banka Hareketleri Ve Fişleri"))
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
            public string BANKAKOD { get; set; }
            public string BANKAAD { get; set; }
            public int BANKAID{ get; set; }
            public IEnumerable<BANKA> BANKAs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<BANKA_HAREKET> BANKA_HAREKETs { get; set; }

            public BANKA_FIS fis { get; set; }
            public int BANKA_FIs { get; set; }
            public IEnumerable<BANKA_FIS_HAREKET> BANKA_FIS_HAREKETs { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }
            public IEnumerable<KASA> KASA { get; set; }
            public IEnumerable<FIRMA> fIRMAs { get; set; }
            public int Ceksayisi { get; set; }
            public int Senetsayisi { get; set; }
            public bool print { get; set; }
        }
        public class cekmodel
        {
            public string PORTFOYNO { get; set; }
            public string BANKADI { get; set; }
            public string BANKASUBE { get; set; }
            public string BANKAHESAPNO { get; set; }
            public string ÇEKNO { get; set; }
            public string KASIDEDEN { get; set; }
            public string KASIDEYERI { get; set; }

            public string KASIDETARIHI { get; set; }
            public string VERGINO { get; set; }
        }
        public class senetmodel
        {
            public string PORTFOYNO { get; set; }
            public string KESIDEEDEN { get; set; }
            public string ADRES { get; set; }
            public string SEHIR { get; set; }
            public string KESIDETARIHI { get; set; }
            public string VERGİNO { get; set; }
            public string VERGIDAIRESI { get; set; }


        }
        public class carifismodel
        {


            public string BANKAKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }

            public List<carifismodelhareket> gelenhareket { get; set; }
            public List<cekmodel> CEKLER { get; set; }
            public List<senetmodel> SENETLER { get; set; }
            public List<string> SILINCEKLER { get; set; }
            public List<string> SILINSENETLER { get; set; }

            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class carifismodelhareket
        {


            public BANKA_HAREKET.ayrıntı HAREKET { get; set; }

            public string KASA { get; set; }
            public string PORTFOYNO { get; set; }
            public string ACIKLAMA { get; set; }
            public string VADE { get; set; }
            public string TUTAR { get; set; }


            public string PARABIRIMI { get; set; }
            public string PARAKURU { get; set; }
            public string NETTUTAR { get; set; }
        }
        // GET: BANKA_HAREKET

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

            public enum harekettip
            {
            ÇekTahsil, SenetTahsil 

            }
            public harekettip HAREKET { get; set; }

       
            public string PORTFOYNO { get; set; }
            public string ACIKLAMA { get; set; }
            public string VADE { get; set; }
            public string TUTAR { get; set; }



        }
        public ActionResult Rapor(int? id)
        {
            changestring();
            var rapor = new CARI_HAREKETController.rapor();
            var banka = db.BANKA.Find(id);
            var hareketler = db.BANKA_HAREKET.Where(x => x.BANKAID == banka.ID).ToList();
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

            rapor.Baslıklar.Add(new CARI_HAREKETController.valler { Baslık = "Banka Kodu/Adı", Deger = banka.BANKAKODU + "/" + banka.BANKAADI });
            rapor.Baslıklar.Add(new CARI_HAREKETController.valler { Baslık = "Banka İban", Deger = banka.IBAN.ToString() });

            var toplamalacak = hareketler.Sum(x => x.ALACAK);
            var toplamborc = hareketler.Sum(x => x.BORC);
            var bakiye = toplamborc - toplamalacak;
            foreach (var item in hareketler)
            {
                var yenisilem = new CARI_HAREKETController.islem();
                yenisilem.Islem = "<td>" + item.ISLEMTURU + "</td>";
                yenisilem.Islem += "<td>" + item.ISLEMTURU + "</td>";
                yenisilem.Islem += "<td>" + item.DOSYANO + "</td>";
                yenisilem.Islem += "<td>" + item.CreateDate.ToShortDateString() + "</td>";

                yenisilem.Islem += "<td>" + item.ACIKLAMA + "</td>";
                yenisilem.Islem += @"<td class=""text-end"">" + item.BORC + "</td>";
                yenisilem.Islem += @"<td class=""text-end"">" + item.ALACAK + "</td>";
                yenisilem.Islem += @"<td class=""text-end"">" + item.BAKIYE + "</td>";

                var althareket = ayrintigetirraporvoid(item.ISLEMNO, item.ISLEMTURU.ToString());
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

        public ActionResult CekIslemleri()
        {
            changestring();
            var model = new CARI_HAREKETController.modelimiz();

            model.CARI_FIs = db.BANKA_CEKSENET_ISLEMLERI.Count();
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
        [HttpPost]
        public JsonResult datagondercek(çekmodel gelenveri)
        {
            changestring();

             var banka= db.BANKA.Where(x => x.BANKAKODU == gelenveri.CARIKOD).FirstOrDefault();


            if (gelenveri.gelenhareket.Count == 0)
            {
                var jsonResult = Json("Başarısız", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
            else
            {
                foreach (var item in gelenveri.gelenhareket)
                {
                    var cari = new CARI_BASLIK();
                    if ((int)item.HAREKET == 0 )
                    {
                        var alınancek = db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).First();
                        cari = db.CARI_BASLIK.Find(alınancek.ALINANKISIID);
                        alınancek.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.BankadanTahsilEdildi;
                        alınancek.TAHSILTARIHI = DateTime.Parse(gelenveri.TARIH);
                        alınancek.VERILENBANKAID = banka.ID;
                        db.Entry(alınancek).State = EntityState.Modified;
                        var cekhareket = new CEKLER_ALINAN_HAREKET();

                        cekhareket.CEKID = alınancek.ID;
                        cekhareket.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.BankadanTahsilEdildi;
                        cekhareket.ACIKLAMA = item.ACIKLAMA;
                        cekhareket.DOSYANO = gelenveri.FISNO;
                        cekhareket.PORTFOYNO = item.PORTFOYNO;
                        cekhareket.TARIH = DateTime.Now;


                        cekhareket.CreateDate = DateTime.Now;
                        cekhareket.CreateUserID = userid;
                        db.CEKLER_ALINAN_HAREKET.Add(cekhareket);
                    
                       
                            var hareket = new BANKA_HAREKET();
                            var tutar = alınancek.TUTAR;
                            hareket.BANKA = banka;
                            hareket.BANKAKODU = banka.BANKAKODU;
                            hareket.CreateDate = DateTime.Now;
                            hareket.ISLEMNO = "";
                            hareket.KAYITSEKLI = BANKA_HAREKET.ayrıntı.Nakit;
                            hareket.CreateUserID = userid;
                            hareket.DOSYANO = gelenveri.FISNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            hareket.ISLEMTURU = CARI_HAREKET.tür.ÇekSenet;
                            hareket.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
                            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new BANKA_HAREKET();
                                if (db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).Count() > 0)
                                {
                                    eskihareket = db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }

                               
                                    hareket.BORC = tutar;
                                    banka.TOPLAMBORC += hareket.BORC;
                                   
                                    hareket.BAKIYE = eskihareket.BAKIYE + hareket.BORC;
                                    foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE += hareket.BORC;

                                    }
                              
                             
                            }
                            else
                            {
                                

                                    hareket.BORC = tutar;
                                    banka.TOPLAMBORC += hareket.BORC;
                                   
                                    hareket.BAKIYE = banka.BAKIYE;

                            
                              
                            }


                            hareket.TIPI = CARI_HAREKET.tip.Giriş;

                        banka.CEK_TOPLAM-= alınancek.TUTAR;
                        banka.NAKIT_TOPLAM += alınancek.TUTAR;
                        hareket.ACIKLAMA = gelenveri.NOT;


                            db.BANKA_HAREKET.Add(hareket);
                        
                    }
                    if ((int)item.HAREKET == 1)
                    {
                        var alınancek = db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).First();
                        cari = db.CARI_BASLIK.Where(x => x.ID == alınancek.ALINANKISIID).FirstOrDefault();
                      alınancek.SENETDURUMU = CEKLER_ALINAN.alinandurumlar.BankadanTahsilEdildi;
                        alınancek.TAHSILTARIHI = DateTime.Parse(gelenveri.TARIH);
                        alınancek.VERILENBANKAID = banka.ID;
                        db.Entry(alınancek).State = EntityState.Modified;
                        var cekhareket = new SENETLER_ALINAN_HAREKET();
                        cekhareket.SENETDURUMU = CEKLER_ALINAN.alinandurumlar.BankadanTahsilEdildi;
                        cekhareket.SENETID = alınancek.ID;
                        cekhareket.SENETDURUMU = alınancek.SENETDURUMU;
                        cekhareket.ACIKLAMA = item.ACIKLAMA;
                        cekhareket.DOSYANO = gelenveri.FISNO;
                        cekhareket.PORTFOYNO = item.PORTFOYNO;
                        cekhareket.TARIH = DateTime.Now;


                        cekhareket.CreateDate = DateTime.Now;
                        cekhareket.CreateUserID = userid;
                        db.SENETLER_ALINAN_HAREKET.Add(cekhareket);


                        var hareket = new BANKA_HAREKET();
                        var tutar = alınancek.TUTAR;
                        hareket.BANKA = banka;
                        hareket.BANKAKODU = banka.BANKAKODU;
                        hareket.CreateDate = DateTime.Now;
                        hareket.ISLEMNO = "";
                        hareket.KAYITSEKLI = BANKA_HAREKET.ayrıntı.Nakit;
                        hareket.CreateUserID = userid;
                        hareket.DOSYANO = gelenveri.FISNO;
                        hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                        hareket.ISLEMTURU = CARI_HAREKET.tür.BankaFişi;
                        hareket.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
                        if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                        {
                            var eskihareket = new BANKA_HAREKET();
                            if (db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).Count() > 0)
                            {
                                eskihareket = db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                            }
                            else { eskihareket.BAKIYE = 0; }


                            hareket.BORC = tutar;
                            banka.TOPLAMBORC += hareket.BORC;
                           
                            hareket.BAKIYE = eskihareket.BAKIYE + hareket.BORC;
                            foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE += hareket.BORC;

                            }


                        }
                        else
                        {


                            hareket.BORC = tutar;
                            banka.TOPLAMBORC += hareket.BORC;
                         
                            hareket.BAKIYE = banka.BAKIYE;



                        }


                        hareket.TIPI = CARI_HAREKET.tip.Giriş;

                        banka.SENET_TOPLAM -= alınancek.TUTAR;
                        banka.NAKIT_TOPLAM += alınancek.TUTAR;
                        hareket.ACIKLAMA = gelenveri.NOT;


                        db.BANKA_HAREKET.Add(hareket);

                    }


                    if ((int)item.HAREKET == 2)
                    {
                        var hareket = new CARI_HAREKET();
                        hareket.cari = db.CARI_BASLIK.Where(x => x.CARIKOD == gelenveri.CARIKOD).FirstOrDefault();
                        hareket.CARIKOD = hareket.cari.CARIKOD;
                        hareket.CreateDate = DateTime.Now;

                        hareket.CreateUserID = userid;
                        hareket.ISLEMNO = item.PORTFOYNO;
                        hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                        hareket.ISLEMTURU = CARI_HAREKET.tür.Çekİade;
                        hareket.TIPI = CARI_HAREKET.tip.Giriş;
                        hareket.ACIKLAMA = item.ACIKLAMA;
                        hareket.BORC = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));

                     
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
                       

                    }



                    db.SaveChanges();
                }




                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
        }
        public ActionResult Index(int? id)
        {
            changestring();

            var model = new CARI_HAREKETController.yenimodel();
            if (id != null)
            {
                model.ismi = db.BANKA.Find(id).BANKAADI;
                model.kodu = db.BANKA.Find(id).BANKAKODU;
                model.id =  (  int)   id;
            }
    
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

        public class bankahareketaraviewmodel {
            public int ID { get; set; }
            public string BANKAKODU { get; set; }
            public string BANKAADI { get; set; }
            public string TARIHSAAT { get; set; }
            public string ISLEMTURU { get; set; }
            public string KAYITSEKLI { get; set; }
            public string TIPI { get; set; }
            public string ISLEMNO { get; set; }
            public string ACIKLAMA { get; set; }
            public double? BORC { get; set; }
            public double? ALACAK { get; set; }
            public double? BAKIYE { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
        }
    
       
     
        public ActionResult BANKAFISKART(int? id, bool? print, int? tip, int? carid)
        {
            changestring();
            var model = new modelimiz();
            if (print != null)
                model.print = (bool)print;
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
       
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.BANKA_FIs = db.BANKA_FIS.Count();

            if (carid != null)
            {
                var banka = db.BANKA.Find(carid);
                model.BANKAID = banka.ID;
                model.BANKAKOD = banka.BANKAKODU;
                model.BANKAAD = banka.BANKAADI;
            }


            if (id == null)
            {

                model.fis = new BANKA_FIS();
                model.BANKA_FIS_HAREKETs = new List<BANKA_FIS_HAREKET>();
                if (tip != null)
                    model.fis.TIP = (int)tip;
                else
                    model.fis.TIP = 1;

                model.fis.TARIH = DateTime.Now;
            
            }
            else
            {
                model.fis = db.BANKA_FIS.Include(x => x.BANKA).SingleOrDefault(x => x.ID == id);
                model.BANKA_FIS_HAREKETs = db.BANKA_FIS_HAREKET.Where(x => x.BANKA_FISID == id).ToList();


            }



            if (degistirme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public ActionResult BANKAFISLISTE()
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
            public string BANKAKODU { get; set; }
            public string BANKADI { get; set; }
            
            public string FISNO { get; set; }
            public string TIP { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string GIRIS { get; set; }
            public string CIKIS { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
        }


        [HttpPost]
        public JsonResult FisData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
        {

            if (sort == "GIRIS" || sort == "CIKIS")
                sort = "TUTAR";
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
            List<FisaravieweNodel> hareketler = new List<FisaravieweNodel>();



            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[3];

            aranacaklar[0] = "hareket.BANKAKODU";
            aranacaklar[1] = "hareket.FISNO";
            aranacaklar[2] = "BANKADI";

            

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




            var v = (from a in db.BANKA_FIS.Select(pr => new
            {
                hareket = pr,
                BANKADI = pr.BANKA.BANKAADI,

                S_MERKEZI = pr.SORUMLULUK_MERKEZI.ACIKLAMA
            }).Where(x => x.hareket.deleted != 1).Where(x => DbFunctions.TruncateTime(x.hareket.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);


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


                yenihareket.BANKAKODU = item.hareket.BANKAKODU;
                yenihareket.BANKADI = item.BANKADI;
                yenihareket.TARIH = item.hareket.TARIH.ToShortDateString();

                if (!string.IsNullOrEmpty(item.hareket.NOT))
                    yenihareket.NOT = item.hareket.NOT;
                if (item.hareket.TIP == 1)
                {
                    yenihareket.GIRIS = item.hareket.TUTAR.ToString();
                    yenihareket.CIKIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-success"">Giriş</span>";
                }
                else
                {
                    yenihareket.CIKIS = item.hareket.TUTAR.ToString();
                    yenihareket.GIRIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-danger"">Çıkış</span>";

                }

                if (!string.IsNullOrEmpty(item.hareket.FISNO))
                    yenihareket.FISNO = item.hareket.FISNO;


                yenihareket.SORUMLULUK_MERKEZI = item.S_MERKEZI;
                hareketler.Add(yenihareket);



            }

            db.Dispose();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
        [HttpPost]
        public JsonResult GetData(string search, string order, int offset, int limit, string sort, int id, filtermodel[] filterler)
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
            List<bankahareketaraviewmodel> hareketler = new List<bankahareketaraviewmodel>();




            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[4];

            aranacaklar[0] = "hareket.DOSYANO";
            aranacaklar[1] = "hareket.ACIKLAMA";
            aranacaklar[2] = "BANKAADI";
            aranacaklar[3] = "hareket.BANKAKODU";


            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";
            if (id != 0)
            {
                query += $"&&({"hareket.BANKAID"}=={ id })";
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




            var v = (from a in db.BANKA_HAREKET.Select(pr => new
            {
                hareket = pr,
                BANKAADI = pr.BANKA.BANKAADI,

                SORUMLULUK_MERKEZI = pr.S_MERKEZI.ACIKLAMA
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

                    yenihareket.BANKAKODU = item.hareket.BANKAKODU;
                    yenihareket.BANKAADI = item.BANKAADI;
                 
                }
                else
                {
                 
                    yenihareket.BANKAKODU = "";
                }
                yenihareket.TARIHSAAT = item.hareket.TARIHSAAT.ToShortDateString();
                yenihareket.ISLEMTURU = item.hareket.ISLEMTURU.ToString();
                yenihareket.KAYITSEKLI = item.hareket.KAYITSEKLI.ToString();

                if (item.hareket.TIPI == CARI_HAREKET.tip.Giriş)
                {
                    if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.CariFişi)
                    {
                        yenihareket.ISLEMTURU = "Tahsilat Fişi";
                    }
                    if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.StokFişi)
                    {
                        yenihareket.ISLEMTURU = "StokGiriş Fişi";
                    }
                    if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.KasaFişi)
                    {
                        yenihareket.ISLEMTURU = "KasaGiriş Fişi";
                    }
                    if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.BankaFişi)
                    {
                        yenihareket.ISLEMTURU = "BankaGiriş Fişi";
                    }
                    if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.Fatura)
                    {
                        yenihareket.ISLEMTURU = "AlışFaturası";
                    }
                    if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.İrsaliye)
                    {
                        yenihareket.ISLEMTURU = "Alışİrsaliye";
                    }
                    if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.PersonelFişi)
                    {
                        yenihareket.ISLEMTURU = "PersonelGiriş Fişi";
                    }
                    else
                    {
                        yenihareket.ISLEMTURU = item.hareket.ISLEMTURU.ToString();

                    }
                    yenihareket.TIPI = @"<span class=""badge badge-success"">Giriş</span>";
                }
                else
                {
                    if (item.hareket.TIPI == CARI_HAREKET.tip.Çıkış)
                    {
                        if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.CariFişi)
                        {
                            yenihareket.ISLEMTURU = "Teddiye Fişi";
                        }
                        if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.StokFişi)
                        {
                            yenihareket.ISLEMTURU = "StokÇıkış Fişi";
                            yenihareket.KAYITSEKLI = "";
                        }
                        if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.KasaFişi)
                        {
                            yenihareket.ISLEMTURU = "KasaÇıkış Fişi";
                        }
                        if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.BankaFişi)
                        {
                            yenihareket.ISLEMTURU = "BankaÇıkış Fişi";
                        }
                        if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.Fatura)
                        {
                            yenihareket.ISLEMTURU = "SatışFaturası";
                            yenihareket.KAYITSEKLI = "";
                        }
                        if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.İrsaliye)
                        {
                            yenihareket.ISLEMTURU = "Satışİrsaliye";
                            yenihareket.KAYITSEKLI = "";
                        }
                        if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.PersonelFişi)
                        {
                            yenihareket.ISLEMTURU = "PersonelSatış";
                            yenihareket.KAYITSEKLI = "";
                        }
                        
                        yenihareket.TIPI = @"<span class=""badge badge-danger"">Çıkış</span>";
                    }
                    if (item.hareket.TIPI == CARI_HAREKET.tip.Devir)
                    {
                        yenihareket.KAYITSEKLI = "";
                        yenihareket.TIPI = @"<span class=""badge badge-primary"">Devir</span>";
                    }
                }

             
                yenihareket.ISLEMNO = item.hareket.ISLEMNO.ToString();
           
                if (!string.IsNullOrEmpty(item.hareket.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.hareket.ACIKLAMA;
                else { yenihareket.ACIKLAMA = ""; }

                yenihareket.BORC = item.hareket.BORC;
                yenihareket.ALACAK = item.hareket.ALACAK;
                yenihareket.BAKIYE = item.hareket.BAKIYE;
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
            var fis = db.BANKA_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.BANKA_FIS_HAREKET.Where(x => x.BANKA_FISID == id && x.deleted != 1);

            var kasaharetleri = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var hareketler = db.BANKA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var banka = db.BANKA.Where(x => x.ID == fis.BANKAID).FirstOrDefault();

            var silincekcekler = new List<string>();
            var silinceksenetler = new List<string>();


            var trans = db.Database.BeginTransaction();
            try
            {

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
                        if (fis.TIP == 1)
                        {
                            kasa.TOPLAMALACAK += kasahareket.ALACAK;
                        

                            foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE += kasahareket.ALACAK;

                            }

                        }
                        else
                        {

                            kasa.TOPLAMBORC += kasahareket.BORC;
                           

                            foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE -= kasahareket.BORC;

                            }


                        }
                    }
                    else
                    {
                        if (fis.TIP == 1)
                        {


                            kasa.TOPLAMALACAK -= kasahareket.ALACAK;
                          

                        }
                        else
                        {


                            kasa.TOPLAMBORC -= kasahareket.BORC;
                         





                        }

                    }
                    item.deleted = 1;
                    db.SaveChanges();
                }
                foreach (var item in hareketler)
                {
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new BANKA_HAREKET();
                        if (db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 1)
                        {
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Havale)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Virman)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Personel)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Nakit)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Senet)
                            {
                                banka.SENET_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Çek)
                            {
                                banka.CEK_TOPLAM -= item.BORC;

                            }

                            banka.TOPLAMBORC -= carihareket.BORC;
                          


                            foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE -= carihareket.BORC;


                            }
                            db.SaveChanges();
                        }
                        else
                        {
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Havale)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Virman)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Personel)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Nakit)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Senet)
                            {
                                banka.SENET_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Çek)
                            {
                                banka.CEK_TOPLAM += item.BORC;

                            }

                            banka.TOPLAMALACAK -= carihareket.ALACAK;
                          

                            foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE += carihareket.ALACAK;


                            }
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (fis.TIP == 1)
                        {
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Havale)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Personel)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Virman)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Nakit)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Senet)
                            {
                                banka.SENET_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Çek)
                            {
                                banka.CEK_TOPLAM -= item.BORC;

                            }

                            banka.TOPLAMBORC -= carihareket.BORC;
                           

                            db.SaveChanges();
                        }
                        else
                        {
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Havale)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Virman)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Personel)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Nakit)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Senet)
                            {
                                banka.SENET_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Çek)
                            {
                                banka.CEK_TOPLAM += item.BORC;

                            }


                            banka.TOPLAMALACAK -= carihareket.ALACAK;
                           
                            db.SaveChanges();


                        }

                    }
                    item.deleted = 1;
                    db.SaveChanges();
                }
                foreach (var item in carihareketleri)
                {
                    var cari = db.CARI_BASLIK.Where(x => x.ID == item.cariID).FirstOrDefault();
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new CARI_HAREKET();
                        if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 2)
                        {

                            cari.TOPLAMDOVIZBORC -= carihareket.DOVIZBORC;
                            cari.TOPLAMBORC -= carihareket.BORC;
                         

                            foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                            {
                                hareketz.BAKIYE -= carihareket.BORC;

                                hareketz.DOVIZBAKIYE -= carihareket.DOVIZBORC;
                            }
                            db.SaveChanges();
                        }
                        else
                        {


                            cari.TOPLAMDOVIZALACAK -= carihareket.DOVIZALACAK;
                            cari.TOPLAMALACAK -= carihareket.ALACAK;
                           
                            foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                            {
                                hareketz.BAKIYE += carihareket.ALACAK;
                                hareketz.DOVIZBAKIYE += carihareket.ALACAK;

                            }
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (fis.TIP == 2)
                        {

                            cari.TOPLAMDOVIZBORC -= carihareket.DOVIZBORC;
                            cari.TOPLAMBORC -= carihareket.BORC;
                           
                            db.SaveChanges();
                        }
                        else
                        {



                            cari.TOPLAMDOVIZALACAK -= carihareket.DOVIZALACAK;
                            cari.TOPLAMALACAK -= carihareket.ALACAK;
                          
                            db.SaveChanges();


                        }

                    }
                    item.deleted = 1;
                    db.SaveChanges();
                }
                foreach (var item in fishareketleri)
                {

                    if (item.HAREKET == "Çek")
                    {
                        silincekcekler.Add(item.PORTFÖYNO);


                    }
                    if (item.HAREKET == "Senet")
                    {
                        silinceksenetler.Add(item.PORTFÖYNO);

                    }
                    item.deleted = 1;

                }
                fis.deleted = 1;
                var kasaharetlerii = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                foreach (var item in kasaharetleri)
                {

                    item.deleted = 1;

                }
                var cariharetlerii = db.BANKA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                foreach (var item in cariharetlerii)
                {

                    item.deleted = 1;

                }
                if (silincekcekler != null)
                    foreach (var item in silincekcekler)
                    {
                        if (fis.TIP == 1)
                            db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item).FirstOrDefault().deleted = 1;
                        else
                        {
                            db.CEKLER_VERILEN.Where(x => x.PORTFOYNO == item).FirstOrDefault().deleted = 1;
                        }

                    }
                if (silinceksenetler != null)
                    foreach (var item in silinceksenetler)
                    {
                        if (fis.TIP == 1)
                            db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item).FirstOrDefault().deleted = 1;
                        else
                        {
                            db.SENETLER_VERILEN.Where(x => x.PORTFOYNO == item).FirstOrDefault().deleted = 1;
                        }

                    }
                var carihareketlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                foreach (var item in carihareketlerii)
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
           
            var fis = db.BANKA_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.BANKA_FIS_HAREKET.Where(x => x.BANKA_FISID == id && x.deleted != 1);

            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var kasaharetleri = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var hareketler = db.BANKA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();

            var banka = db.BANKA.Where(x => x.ID == fis.BANKAID).FirstOrDefault();

            
                if (kasaharetleri.Count() > 0)
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
                            if (fis.TIP == 1)
                            {
                                kasa.TOPLAMALACAK += kasahareket.ALACAK;
                               

                                foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                                {
                                    hareketz.BAKIYE += kasahareket.ALACAK;

                                }

                            }
                            else
                            {

                                kasa.TOPLAMBORC += kasahareket.BORC;
                               
                                foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                                {
                                    hareketz.BAKIYE -= kasahareket.BORC;

                                }


                            }
                        }
                        else
                        {
                            if (fis.TIP == 1)
                            {


                                kasa.TOPLAMALACAK -= kasahareket.ALACAK;
                               
                            }
                            else
                            {


                                kasa.TOPLAMBORC -= kasahareket.BORC;
                             




                            }

                        }

                        db.SaveChanges();
                    }
                foreach (var item in hareketler)
                {
                    var bankahareket = item;

                    if (DateTime.Now.CompareTo(bankahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new BANKA_HAREKET();
                        if (db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 1)
                        {
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Nakit)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Senet)
                            {
                                banka.SENET_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Çek)
                            {
                                banka.CEK_TOPLAM -= item.BORC;

                            }

                            banka.TOPLAMBORC -= bankahareket.BORC;
                           
                            foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(bankahareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE -= bankahareket.BORC;


                            }

                        }
                        else
                        {

                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Nakit)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Senet)
                            {
                                banka.SENET_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Çek)
                            {
                                banka.CEK_TOPLAM += item.BORC;

                            }

                            banka.TOPLAMALACAK -= bankahareket.ALACAK;
                           

                            foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(bankahareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE += bankahareket.ALACAK;


                            }

                        }
                    }
                    else
                    {
                        if (fis.TIP == 1)
                        {
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Nakit)
                            {
                                banka.NAKIT_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Senet)
                            {
                                banka.SENET_TOPLAM -= item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Çek)
                            {
                                banka.CEK_TOPLAM -= item.BORC;

                            }


                            banka.TOPLAMBORC -= bankahareket.BORC;
                          

                        }
                        else
                        {

                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Nakit)
                            {
                                banka.NAKIT_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Senet)
                            {
                                banka.SENET_TOPLAM += item.BORC;

                            }
                            if (item.KAYITSEKLI == BANKA_HAREKET.ayrıntı.Çek)
                            {
                                banka.CEK_TOPLAM += item.BORC;

                            }



                            banka.TOPLAMALACAK -= bankahareket.ALACAK;
                          


                        }

                    }

                }
                if (carihareketleri.Count() > 0)
                    foreach (var item in carihareketleri)
                    {
                        var cari = db.CARI_BASLIK.Where(x => x.ID == item.cariID).FirstOrDefault();
                        var carihareket = item;
                        if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                        {
                            var eskihareket = new CARI_HAREKET();
                            if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                            {
                                eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                            }
                            else { eskihareket.BAKIYE = 0; }
                            if (fis.TIP == 2)
                            {

                                cari.TOPLAMDOVIZBORC -= carihareket.DOVIZBORC;
                                cari.TOPLAMBORC -= carihareket.BORC;
                               
                                foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                {
                                    hareketz.BAKIYE -= carihareket.BORC;

                                    hareketz.DOVIZBAKIYE -= carihareket.DOVIZBORC;
                                }
                                db.SaveChanges();
                            }
                            else
                            {


                                cari.TOPLAMDOVIZALACAK -= carihareket.DOVIZALACAK;
                                cari.TOPLAMALACAK -= carihareket.ALACAK;
                               
                                foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                {
                                    hareketz.BAKIYE += carihareket.ALACAK;
                                    hareketz.DOVIZBAKIYE += carihareket.ALACAK;

                                }
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            if (fis.TIP == 2)
                            {

                                cari.TOPLAMDOVIZBORC -= carihareket.DOVIZBORC;
                                cari.TOPLAMBORC -= carihareket.BORC;
                              
                                db.SaveChanges();
                            }
                            else
                            {



                                cari.TOPLAMDOVIZALACAK -= carihareket.DOVIZALACAK;
                                cari.TOPLAMALACAK -= carihareket.ALACAK;
                              
                                db.SaveChanges();


                            }

                        }
                        item.deleted = 1;
                        db.SaveChanges();
                    }





                var kasaharetlerii = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO);
                if (kasaharetlerii.Count() > 0)
                    db.KASA_HAREKET.RemoveRange(kasaharetlerii);
                var bankahareetleri = db.BANKA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO);
                db.BANKA_HAREKET.RemoveRange(bankahareetleri);
                var carihareketaleri = db.CARI_HAREKET.Where(x => x.CARIKOD == fis.FISNO);
                if (carihareketaleri.Count() > 0)
                    db.CARI_HAREKET.RemoveRange(carihareketaleri);

                db.BANKA_FIS_HAREKET.RemoveRange(fishareketleri);

                db.SaveChanges();


           

           



           


        }

        [HttpPost]

        public JsonResult datagonder(carifismodel gelenveri)
        {
            changestring();
            var id = 0;
            double asıltoplam = 0;
            double toplamtutar = 0;
            var bankafis = new BANKA_FIS();
            var banka = db.BANKA.Where(x => x.BANKAKODU == gelenveri.BANKAKOD).FirstOrDefault();
            bankafis.BANKA = banka;
            bankafis.BANKAKODU = gelenveri.BANKAKOD;
            bankafis.CreateDate = DateTime.Now;
            bankafis.TIP = (int)gelenveri.TIPI;
            bankafis.CreateUserID = userid;
            bankafis.FISNO = gelenveri.FISNO.ToString();
            bankafis.NOT = gelenveri.NOT;
          
            bankafis.SORUMLULUK_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
            bankafis.TARIH = DateTime.Parse(gelenveri.TARIH);
        
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




                        asıltoplam += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                        if (!(item.HAREKET == BANKA_HAREKET.ayrıntı.Çek || item.HAREKET == BANKA_HAREKET.ayrıntı.Senet))
                            toplamtutar += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                        else
                        {

                        }

                    }
                    bankafis.TUTAR = asıltoplam;

                    var list = db.BANKA_FIS.SingleOrDefault(x => x.FISNO == bankafis.FISNO);
                    if (list == null)
                    {
                        db.BANKA_FIS.Add(bankafis);
                        db.SaveChanges();
                        id = bankafis.ID;
                        list = bankafis;
                    }
                    else
                    {
                        list.BANKA = bankafis.BANKA;
                        list.BANKAKODU = bankafis.BANKAKODU;
                        list.UpdateDate = DateTime.Now;
                        list.UpdateUserID = 1;
                        list.SORUMLULUK_MERKEZIID = bankafis.SORUMLULUK_MERKEZIID;
                        list.TARIH = bankafis.TARIH;
                        list.NOT = bankafis.NOT;
                        list.TUTAR = bankafis.TUTAR;
                        db.SaveChanges();
                        fisiyenile(list.ID);
                        id = list.ID;

                    }
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        if (item.HAREKET == BANKA_HAREKET.ayrıntı.Havale)
                        {
                            var hareket = new CARI_HAREKET();
                            var cari = db.CARI_BASLIK.Where(x => x.CARIKOD == item.KASA).FirstOrDefault();


                            hareket.cari = cari;
                            hareket.CARIKOD = hareket.cari.CARIKOD;
                            hareket.CreateDate = DateTime.Now;
                            hareket.KAYITSEKLI = CARI_HAREKET_AYRINTI.detay.Nakit;
                            hareket.ACIKLAMA = item.ACIKLAMA;

                            hareket.CreateUserID = userid;
                            hareket.ISLEMNO = gelenveri.FISNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            hareket.ISLEMTURU = CARI_HAREKET.tür.Havale;
                            hareket.S_MERKEZIID = bankafis.SORUMLULUK_MERKEZIID;
                            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new CARI_HAREKET();
                                if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                                {
                                    eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Çıkış)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZALACAK = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    cari.TOPLAMDOVIZALACAK += double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                  
                                    cari.TOPLAMALACAK += hareket.ALACAK;
                                  
                                    hareket.BAKIYE = eskihareket.BAKIYE - double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ",")); ;
                                    hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE - double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ",")); ;
                                    foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE -= double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                        hareketz.DOVIZBAKIYE -= double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                                    }

                                }
                                else
                                {

                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    hareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    cari.TOPLAMDOVIZBORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                  
                                    cari.TOPLAMBORC += hareket.BORC;
                                   
                                    hareket.BAKIYE = eskihareket.BAKIYE + double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE + double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                        hareketz.DOVIZBAKIYE += double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    }

                                }


                            }
                            else
                            {
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Çıkış)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZALACAK = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    cari.TOPLAMDOVIZALACAK += double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                   
                                    cari.TOPLAMALACAK += hareket.ALACAK;
                                  
                                    hareket.BAKIYE = cari.BAKIYE;
                                    hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;

                                }
                                else
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    hareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    cari.TOPLAMDOVIZBORC += double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                   
                                    cari.TOPLAMBORC += hareket.BORC;
                               
                                    hareket.BAKIYE = cari.BAKIYE;
                                    hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;




                                }
                            }



                            hareket.ACIKLAMA = gelenveri.NOT;

                            hareket.VADE = DateTime.Parse(item.VADE);

                            db.CARI_HAREKET.Add(hareket);

                        }

                        if (item.HAREKET == BANKA_HAREKET.ayrıntı.Virman)
                        {
                            var bankaa = db.BANKA.Where(x => x.BANKAKODU == item.KASA).FirstOrDefault();
                            var hareket = new BANKA_HAREKET();
                            var tutar = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));
                            hareket.BANKA = bankaa;
                            hareket.BANKAKODU = bankaa.BANKAKODU;
                            hareket.CreateDate = DateTime.Now;
                            hareket.ISLEMNO = "";
                            hareket.KAYITSEKLI = item.HAREKET;
                            hareket.CreateUserID = userid;

                            hareket.ISLEMNO = gelenveri.FISNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            hareket.ISLEMTURU = CARI_HAREKET.tür.BankaFişi;
                            hareket.S_MERKEZIID = bankafis.SORUMLULUK_MERKEZIID;
                            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new BANKA_HAREKET();
                                if (db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == bankaa.BANKAKODU && x.deleted != 1).Count() > 0)
                                {
                                    eskihareket = db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == bankaa.BANKAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }

                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.ALACAK = tutar;
                                    bankaa.TOPLAMALACAK += hareket.ALACAK;
                                  
                                    hareket.BAKIYE = eskihareket.BAKIYE - hareket.ALACAK;
                                    foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.BANKAKODU == bankaa.BANKAKODU && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE -= hareket.ALACAK;

                                    }

                                }
                                else
                                {
                                    hareket.BORC = tutar;
                                    bankaa.TOPLAMBORC += hareket.BORC;
                                 
                                    hareket.BAKIYE = eskihareket.BAKIYE + hareket.BORC;
                                    foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.BANKAKODU == bankaa.BANKAKODU && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE += hareket.BORC;

                                    }


                                }
                            }
                            else
                            {
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.ALACAK = tutar;
                                    bankaa.TOPLAMALACAK += hareket.ALACAK;
                              
                                    hareket.BAKIYE = bankaa.BAKIYE;
                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                }
                                else
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;


                                    hareket.BORC = tutar;
                                    bankaa.TOPLAMBORC += hareket.BORC;
                                  
                                    hareket.BAKIYE = bankaa.BAKIYE;

                                }
                            }



                            hareket.ACIKLAMA = item.ACIKLAMA;


                            db.BANKA_HAREKET.Add(hareket);

                        }

                        if (item.HAREKET == BANKA_HAREKET.ayrıntı.GGiderler)
                        {
                            double tutar = 0;
                            tutar = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                            var gider = db.GIDER_BASLIK.Where(x => x.GIDERKODU == item.KASA).FirstOrDefault();
                            var hareket = new GIDER_BORDRO_HAREKET();
                            hareket.GIDERKODU = item.KASA;

                            hareket.GIDER_BASLIKID = gider.ID;
                            hareket.ISLEMTURU = CARI_HAREKET.tür.KasaFişi;
                            hareket.CreateDate = DateTime.Now;
                            hareket.TUTARI = tutar;
                            hareket.ACIKLAMA = item.ACIKLAMA;
                            hareket.PARAKUR = double.Parse(item.PARAKURU);
                            hareket.FISNO = bankafis.FISNO;
                            hareket.CreateUserID = userid;
                            hareket.PARABIRIMI = item.PARABIRIMI;
                            hareket.S_MERKEZIID = bankafis.SORUMLULUK_MERKEZIID;
                            if (gider.TOPLAMTUTAR == null)
                                gider.TOPLAMTUTAR = 0;
                            gider.TOPLAMTUTAR += hareket.TUTARI;

                            hareket.ACIKLAMA = gelenveri.NOT;


                            db.GIDER_BORDRO_HAREKET.Add(hareket);
                        }

                        if (item.HAREKET == BANKA_HAREKET.ayrıntı.Nakit || item.HAREKET == BANKA_HAREKET.ayrıntı.Çek || item.HAREKET == BANKA_HAREKET.ayrıntı.Senet)
                        {

                            var kasa = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();

                            var kasahareket = new KASA_HAREKET();
                            kasahareket.KASA = kasa;
                            kasahareket.KASAKODU = kasahareket.KASA.KASAKODU;
                            kasahareket.ILGILI = banka.BANKAADI;
                            kasahareket.CreateDate = DateTime.Now;
                            kasahareket.CreateUserID = userid;
                            kasahareket.ISLEMNO = gelenveri.FISNO;
                            kasahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.Banka;
                            kasahareket.S_MERKEZIID= bankafis.SORUMLULUK_MERKEZIID; 
                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                if (item.HAREKET == BANKA_HAREKET.ayrıntı.Senet || item.HAREKET == BANKA_HAREKET.ayrıntı.Çek)
                                {
                                    kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.BankayaTahsilat;

                                    if (item.HAREKET == BANKA_HAREKET.ayrıntı.Çek)
                                        banka.CEK_TOPLAM += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    if (item.HAREKET == BANKA_HAREKET.ayrıntı.Senet)
                                        banka.SENET_TOPLAM += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    
                                   
                                }
                             
                            }
                            else
                            {
                                if (item.HAREKET == BANKA_HAREKET.ayrıntı.Senet || item.HAREKET == BANKA_HAREKET.ayrıntı.Çek)
                                {
                                    kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.BankadanPortfoy;
                                    if (item.HAREKET == BANKA_HAREKET.ayrıntı.Çek)
                                        banka.CEK_TOPLAM -= double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    if (item.HAREKET == BANKA_HAREKET.ayrıntı.Senet)
                                        banka.SENET_TOPLAM -= double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                  
                                }
                                
                            }

                            if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new KASA_HAREKET();
                                if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).Count() > 0)
                                {
                                    eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {

                                    kasahareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    kasahareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    kasa.TOPLAMALACAK += kasahareket.ALACAK;
                                  
                                    kasahareket.BAKIYE = eskihareket.BAKIYE - kasahareket.ALACAK;

                                    foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE -= kasahareket.ALACAK;

                                    }
                                }

                                else
                                {
                                    kasahareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    kasahareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));

                                    kasa.TOPLAMBORC += kasahareket.BORC;
                                    kasahareket.BAKIYE = eskihareket.BAKIYE - kasahareket.BORC;
                                    foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE += kasahareket.BORC;

                                    }

                                }
                            }
                            else
                            {
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {

                                    kasahareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    kasahareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    kasa.TOPLAMALACAK += kasahareket.ALACAK;
                                    kasahareket.BAKIYE = kasa.BAKIYE;


                                }

                                else
                                {
                                    kasahareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    kasahareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));

                                    kasa.TOPLAMBORC += kasahareket.BORC;
                                    kasahareket.BAKIYE = kasa.BAKIYE;

                                }
                            }



                            kasahareket.ACIKLAMA = item.ACIKLAMA;


                            db.KASA_HAREKET.Add(kasahareket);


                            db.SaveChanges();
                        }
                    }

                    foreach (var item in gelenveri.gelenhareket)
                    {
                        if (item.HAREKET != BANKA_HAREKET.ayrıntı.Çek && item.HAREKET != BANKA_HAREKET.ayrıntı.Senet)
                        {
                            var hareket = new BANKA_HAREKET();
                            var tutar = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));
                            hareket.BANKA = banka;
                            hareket.BANKAKODU = banka.BANKAKODU;
                            hareket.CreateDate = DateTime.Now;
                            hareket.ISLEMNO = gelenveri.FISNO;
                            hareket.KAYITSEKLI = item.HAREKET;
                            hareket.CreateUserID = userid;
                            hareket.DOSYANO = gelenveri.FISNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            hareket.ISLEMTURU = CARI_HAREKET.tür.BankaFişi;
                            hareket.S_MERKEZIID = bankafis.SORUMLULUK_MERKEZIID;
                            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new BANKA_HAREKET();
                                if (db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).Count() > 0)
                                {
                                    eskihareket = db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }

                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {

                                    hareket.BORC = tutar;
                                    banka.TOPLAMBORC += hareket.BORC;
                                    banka.NAKIT_TOPLAM += tutar;
                                    hareket.BAKIYE = eskihareket.BAKIYE + hareket.BORC;
                                    foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE += hareket.BORC;

                                    }
                                }
                                else
                                {

                                    banka.NAKIT_TOPLAM -= tutar;
                                    hareket.ALACAK = tutar;
                                    banka.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = eskihareket.BAKIYE - hareket.ALACAK;
                                    foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE -= hareket.ALACAK;

                                    }
                                }
                            }
                            else
                            {
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    banka.NAKIT_TOPLAM += tutar;
                                    hareket.BORC = tutar;
                                    banka.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = banka.BAKIYE;

                                }
                                else
                                {

                                    banka.NAKIT_TOPLAM -= tutar;
                                    hareket.ALACAK = tutar;
                                    banka.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = banka.BAKIYE;
                                }
                            }

                            
                            hareket.TIPI = gelenveri.TIPI;


                            hareket.ACIKLAMA = gelenveri.NOT;


                            db.BANKA_HAREKET.Add(hareket);
                        }

                    }

                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var fishareket = new BANKA_FIS_HAREKET();
                        fishareket.HAREKET = item.HAREKET.ToString();
                        fishareket.BANKA_FIS = db.BANKA_FIS.Find(id);
                        fishareket.ACIKLAMA = item.ACIKLAMA;
                        fishareket.KASA = item.KASA;
                        fishareket.NETTUTAR = item.NETTUTAR;
                        fishareket.VADE = item.VADE;
                        fishareket.PORTFÖYNO = item.PORTFOYNO;
                        fishareket.TUTAR = item.TUTAR;
                        fishareket.PARABIRIMI = item.PARABIRIMI;
                        fishareket.PARAKURU = item.PARAKURU;
                        db.BANKA_FIS_HAREKET.Add(fishareket);
                        db.SaveChanges();
                    }
                    if (gelenveri.CEKLER != null)
                        foreach (var item in gelenveri.CEKLER)
                        {

                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                var cek = db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault();
                                cek.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.BankayaTahsilVerildi;
                                cek.VERILENBANKAID = banka.ID;
                                cek.VERILENBANKATARIHI = DateTime.Now;
                                var cekhareket = new CEKLER_ALINAN_HAREKET();
                                cekhareket.CEK = db.CEKLER_ALINAN.Where(X => X.PORTFOYNO == cek.PORTFOYNO).FirstOrDefault();
                                cekhareket.CEKID = cekhareket.CEK.ID;

                                cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.BankayaTahsilVerildi;

                                cekhareket.DOSYANO = gelenveri.FISNO;
                                cekhareket.PORTFOYNO = item.PORTFOYNO;
                                cekhareket.TARIH = DateTime.Now;
                            

                                cekhareket.CreateDate = DateTime.Now;
                                cekhareket.CreateUserID = userid;
                                db.Entry(cek).State = EntityState.Modified;
                                db.CEKLER_ALINAN_HAREKET.Add(cekhareket);
                                db.SaveChanges();

                            }
                            else
                            {

                                var cek = db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault();
                                cek.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.Pörtföy;
                                var cekhareket = new CEKLER_ALINAN_HAREKET();
                                cekhareket.CEK = db.CEKLER_ALINAN.Where(X => X.PORTFOYNO == cek.PORTFOYNO).FirstOrDefault();
                                cekhareket.CEKID = cekhareket.CEK.ID;

                                cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.BankadanPortfoy;

                                cekhareket.DOSYANO = gelenveri.FISNO;
                                cekhareket.PORTFOYNO = item.PORTFOYNO;
                                cekhareket.TARIH = DateTime.Now;


                                cekhareket.CreateDate = DateTime.Now;
                                cekhareket.CreateUserID = userid;
                                db.Entry(cek).State = EntityState.Modified;
                                db.CEKLER_ALINAN_HAREKET.Add(cekhareket);
                                db.SaveChanges();
                            }


                            db.SaveChanges();
                        }
                    if (gelenveri.SENETLER != null)
                        foreach (var item in gelenveri.SENETLER)
                        {


                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                var cek = db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault();
                                cek.SENETDURUMU = CEKLER_ALINAN.alinandurumlar.BankayaTahsilVerildi;
                                cek.VERILENBANKAKODU = banka.BANKAKODU;
                                cek.VERILENBANKATARIHI = DateTime.Now;
                                var cekhareket = new SENETLER_ALINAN_HAREKET();
                                cekhareket.SENET = db.SENETLER_ALINAN.Where(X => X.PORTFOYNO == cek.PORTFOYNO).FirstOrDefault();
                                cekhareket.SENETID = cekhareket.SENET.ID;

                                cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.BankayaTahsilVerildi;

                                cekhareket.DOSYANO = gelenveri.FISNO;
                                cekhareket.PORTFOYNO = item.PORTFOYNO;
                                cekhareket.TARIH = DateTime.Now;


                                cekhareket.CreateDate = DateTime.Now;
                                cekhareket.CreateUserID = userid;
                                db.Entry(cek).State = EntityState.Modified;
                                db.SENETLER_ALINAN_HAREKET.Add(cekhareket);
                                db.SaveChanges();

                            }
                            else
                            {

                                var cek = db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault();
                                cek.SENETDURUMU = CEKLER_ALINAN.alinandurumlar.Pörtföy;
                                var cekhareket = new SENETLER_ALINAN_HAREKET();
                                cekhareket.SENET = db.SENETLER_ALINAN.Where(X => X.PORTFOYNO == cek.PORTFOYNO).FirstOrDefault();
                                cekhareket.SENETID = cekhareket.SENET.ID;

                                cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.BankadanPortfoy;

                                cekhareket.DOSYANO = gelenveri.FISNO;
                                cekhareket.PORTFOYNO = item.PORTFOYNO;
                                cekhareket.TARIH = DateTime.Now;


                                cekhareket.CreateDate = DateTime.Now;
                                cekhareket.CreateUserID = userid;
                                db.Entry(cek).State = EntityState.Modified;
                                db.SENETLER_ALINAN_HAREKET.Add(cekhareket);
                                db.SaveChanges();
                            }
                            db.SaveChanges();
                        }
                    if (gelenveri.SILINCEKLER != null)
                        foreach (var item in gelenveri.SILINCEKLER)
                        {
                            if (db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item).Count() > 0)
                            {
                                db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item).FirstOrDefault().deleted = 1;

                            }
                            else
                            {
                                db.CEKLER_VERILEN.Where(x => x.PORTFOYNO == item).FirstOrDefault().deleted = 1;
                            }


                        }

                    if (gelenveri.SILINSENETLER != null)
                        foreach (var item in gelenveri.SILINSENETLER)
                        {
                            if (db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item).Count() > 0)
                            {
                                db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item).FirstOrDefault().deleted = 1;

                            }
                            else
                            {
                                db.SENETLER_VERILEN.Where(x => x.PORTFOYNO == item).FirstOrDefault().deleted = 1;
                            }


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
                    return Json("Başarısız!" + ex.InnerException);
                }


            }
        }


        [HttpPost]
        public JsonResult cekgonder(carifismodel gelenveri)
        {
            changestring();

            var cari = db.CARI_BASLIK.Where(x => x.CARIKOD == gelenveri.BANKAKOD).FirstOrDefault();


            if (gelenveri.gelenhareket.Count == 0)
            {
                var jsonResult = Json("Başarısız", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
            else
            {
                foreach (var item in gelenveri.gelenhareket)
                {
               
                    if ((int)item.HAREKET == 1 || (int)item.HAREKET == 2 || (int)item.HAREKET == 3)
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
                            kasahareket.ILGILI = db.BANKA.Where(x => x.BANKAKODU == gelenveri.BANKAKOD).FirstOrDefault().BANKAADI;
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



                            if ((int)item.HAREKET == 1)
                            {
                                kasahareket.TIPI = CARI_HAREKET.tip.Giriş;

                                kasahareket.BORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                                kasa.TOPLAMBORC += kasahareket.BORC;
                                kasahareket.BAKIYE = kasa.BAKIYE;


                            }

                            kasahareket.ACIKLAMA = item.ACIKLAMA;
                            db.KASA_HAREKET.Add(kasahareket);

                            var kasa2 = db.KASA.Where(x => x.KASAADI == alınancek.KASA).FirstOrDefault();

                            var kasahareket2 = new KASA_HAREKET();
                            kasahareket2.KASA = db.KASA.Where(x => x.KASAADI == alınancek.KASA).FirstOrDefault();
                            kasahareket2.KASAKODU = kasahareket2.KASA.KASAKODU;
                            kasahareket2.ILGILI = db.BANKA.Where(x => x.BANKAKODU == gelenveri.BANKAKOD).FirstOrDefault().BANKAADI;
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


                            }

                            kasahareket2.ACIKLAMA = item.ACIKLAMA;
                            db.KASA_HAREKET.Add(kasahareket2);


                        }
                    }
                    if ((int)item.HAREKET == 0 || (int)item.HAREKET == 4 || (int)item.HAREKET == 5)
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
                            kasahareket.ILGILI = db.BANKA.Where(x => x.BANKAKODU == gelenveri.BANKAKOD).FirstOrDefault().BANKAADI;
                            kasahareket.CreateDate = DateTime.Now;
                            kasahareket.CreateUserID = userid;
                            kasahareket.ISLEMNO = gelenveri.FISNO;
                            kasahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);

                            kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.Çek;




                            kasahareket.TIPI = CARI_HAREKET.tip.Giriş;

                            kasahareket.BORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                            kasa.TOPLAMBORC += kasahareket.BORC;
                            kasahareket.BAKIYE = kasa.BAKIYE;




                            kasahareket.ACIKLAMA = item.ACIKLAMA;
                            db.KASA_HAREKET.Add(kasahareket);

                            var kasa2 = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();

                            var kasahareket2 = new KASA_HAREKET();
                            kasahareket2.KASA = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();
                            kasahareket2.KASAKODU = kasahareket2.KASA.KASAKODU;
                            kasahareket2.ILGILI = db.BANKA.Where(x => x.BANKAKODU == gelenveri.BANKAKOD).FirstOrDefault().BANKAKODU;
                            kasahareket2.CreateDate = DateTime.Now;
                            kasahareket2.CreateUserID = userid;
                            kasahareket2.ISLEMNO = gelenveri.FISNO;
                            kasahareket2.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);

                            kasahareket2.ISLEMTURU = KASA_HAREKET.kasaislemtürü.Çek;





                            kasahareket2.TIPI = CARI_HAREKET.tip.Çıkış;

                            kasahareket2.ALACAK = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                            kasa2.TOPLAMALACAK += kasahareket2.ALACAK;
                            kasahareket2.BAKIYE = kasa2.BAKIYE;



                            kasahareket2.ACIKLAMA = item.ACIKLAMA;
                            db.KASA_HAREKET.Add(kasahareket2);


                        }
                    }


                    if ((int)item.HAREKET == 3 || (int)item.HAREKET == 4 || (int)item.HAREKET == 5)
                    {
                        var hareket = new CARI_HAREKET();
                        hareket.cari = db.CARI_BASLIK.Where(x => x.CARIKOD == gelenveri.BANKAKOD).FirstOrDefault();
                        hareket.CARIKOD = hareket.cari.CARIKOD;
                        hareket.CreateDate = DateTime.Now;

                        hareket.CreateUserID = userid;
                        hareket.ISLEMNO = item.PORTFOYNO;
                        hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                        hareket.ISLEMTURU = CARI_HAREKET.tür.Çekİade;
                        hareket.TIPI = CARI_HAREKET.tip.Giriş;
                        hareket.ACIKLAMA = item.ACIKLAMA;
                        hareket.BORC = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));

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



                db.Dispose();
                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                db.Dispose(); return jsonResult;
            }
        }

    }
}
