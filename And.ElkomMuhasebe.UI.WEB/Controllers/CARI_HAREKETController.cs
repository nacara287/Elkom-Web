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
using Microsoft.Reporting.WebForms;
using System.IO;
namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class CARI_HAREKETController : Controller
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
                    if (alt.görme.Contains("Cari Hareketleri Ve Fişleri"))
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

        public ActionResult HareketRapor(int id)
        {
            changestring();

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Raporlar/"), "CariHareketRaporu.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;

            }
            else
            {
                return View("Index");

            }
            List<CARI_HAREKET> cm = new List<CARI_HAREKET>();
            var cari = db.CARI_BASLIK.Where(X=>X.ID==id).ToList();
            var firma = db.FIRMA.ToList();
            cm = db.CARI_HAREKET.Where(x=>x.cariID==id).ToList();
            ReportDataSource RD = new ReportDataSource("Hareketler", cm);
            ReportDataSource RDA = new ReportDataSource("Cari", cari);
            ReportDataSource RDB = new ReportDataSource("Firma", firma);
            lr.DataSources.Add(RD);
            lr.DataSources.Add(RDA);
            lr.DataSources.Add(RDB);
            string reportType =     "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceinfo = @"<DeviceInfo>" + "<OutputFormat>" + id + "</OutputFormat>" + "<PageWidth>8.5in</PageWidth>" + "<PageHeight>11in</PageHeight>" + "<MarginTop>0.5in</MarginTop></DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = lr.Render(
                reportType, deviceinfo, out mimeType, out encoding, out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType);
        }
        public class CariHareketAraViewModel
        {

            public int ID { get; set; }
            public string CARIKOD { get; set; }
            public string CARI { get; set; }
            public string TARIHSAAT { get; set; }

            public string ISLEMTURU { get; set; }
            public string KAYITSEKLI { get; set; }
            public string TIPI { get; set; }
            public string ISLEMNO { get; set; }
            public string VADE { get; set; }
            public string ACIKLAMA { get; set; }
            public double? BORC { get; set; }
            public double? ALACAK { get; set; }
            public double? BAKIYE { get; set; }
            public double? DOVIZBORC { get; set; }
            public double? DOVIZALACAK { get; set; }
            public double? DOVIZBAKIYE { get; set; }
            public string S_MERKEZI { get; set; }

        }
        public class FisaravieweNodel
        {
            public int ID { get; set; }

            public string CARIKOD { get; set; }
            public string CARIADI{ get; set; }
            public string FISNO { get; set; }
            public string TIP { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string GIRIS { get; set; }
            public string CIKIS { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
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


            public string CARIKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }

            public List<carifismodelhareket> gelenhareket { get; set; }
            public List<cekmodel> CEKLER { get; set; }
            public List<senetmodel> SENETLER { get; set; }

            public List<string> SILINCEKVISALAR { get; set; }
            public List<string> SILINCEKLER { get; set; }
            public List<string> SILINSENETLER { get; set; }



            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class carifismodelhareket
        {


            public CARI_HAREKET_AYRINTI.detay HAREKET { get; set; }

            public string KASA { get; set; }
            public string PORTFOYNO { get; set; }
            public string ACIKLAMA { get; set; }
            public string VADE { get; set; }
            public string TUTAR { get; set; }


            public string PARABIRIMI { get; set; }
            public string PARAKURU { get; set; }
            public string NETTUTAR { get; set; }
        }
        public class kasatipi
        {
            public string KASAKODU { get; set; }
            public string KASAADI { get; set; }
            public string TIPI { get; set; }

        }
     
        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }

        public class yenimodel
        {
            public string Toplamborc { get; set; }
            public string Toplamalacak { get; set; }
            public string Bakiye { get; set; }
            public string ismi { get; set; }
            public string kodu { get; set; }
            public int id { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }
            public IEnumerable<STOK_DEPO> DEPOs { get; set; }

        }

        public class valler
        {
            public string Baslık { get; set; }
            public string Deger { get; set; }
        }
        public class islem
        {
            public string Islem { get; set; }
            public List<string> Kalem { get; set; }
        }
        public class rapor
        {
            public List<valler> Baslıklar { get; set; }

            public List<valler> Toplamlar { get; set; }
            public List<string> Thler { get; set; }
            public List<islem> Tdler { get; set; }
            public FIRMA Firma { get; set; }
        }

        public class modelimiz
        {
            public CARI_BASLIK Cari { get; set; }
            public CARI_HAREKET Hareket { get; set; }
            public KUR_BASLIK Kur { get; set; }

            public IEnumerable<CARI_BASLIK> cARI_BASLIKs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<CARI_HAREKET> CARI_HAREKETs { get; set; }

            public CARI_FIS fis { get; set; }
            public int CARI_FIs { get; set; }
            public IEnumerable<CARI_FIS_HAREKET> CARI_FIS_HAREKETs { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }
            public IEnumerable<KASA> KASA { get; set; }
            public IEnumerable<FIRMA> fIRMAs { get; set; }
            public int Ceksayisi { get; set; }
            public int FirmaCeksayisi { get; set; }
            public string carikod { get; set; }
            public string firmalogo { get; set; }
            public string cariad { get; set; }
            public bool print { get; set; }
            public int Senetsayisi { get; set; }
            public int FirmaSenetsayisi { get; set; }
            public int VisaSayisi { get; set; }
        }
    
            public ActionResult CARIFISKART(int? id,bool? print, int? tip, int? carid)
            {
         
                changestring();
            var model = new modelimiz();
            model.CARI_FIs = db.CARI_FIS.Count();
            model.firmalogo = db.FIRMA.FirstOrDefault().FirmaResimUrl;
            if (print != null)
                model.print = (bool)print;

            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.Hareket = new CARI_HAREKET();
            model.CARI_HAREKETs = new List<CARI_HAREKET>();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
         
            model.Ceksayisi = db.CEKLER_ALINAN.Count();
            model.Senetsayisi = db.SENETLER_ALINAN.Count();
            model.FirmaCeksayisi = db.CEKLER_VERILEN.Count();
            model.FirmaSenetsayisi = db.SENETLER_VERILEN.Count();
            model.VisaSayisi = db.BANKA_VISA.Count();
            if (carid != null)
            {
                var cari = db.CARI_BASLIK.Find(carid);
                model.carikod = cari.ID.ToString();
                model.cariad = cari.CARIKOD + "/" + cari.FIRMAUNVANI;

            }


            if (id == null)
            {

                model.fis = new CARI_FIS();
                model.CARI_FIS_HAREKETs = new List<CARI_FIS_HAREKET>();
                if (tip != null)
                    model.fis.TIP = (int)tip;
                else
                    model.fis.TIP = 1;
            }
            else
            {
                model.fis = db.CARI_FIS.Include(x => x.Cari).SingleOrDefault(x => x.ID == id);
                model.CARI_FIS_HAREKETs = db.CARI_FIS_HAREKETs.Where(x => x.CARI_FIsID == id).ToList();
               

            }




            db.Dispose();

            if (degistirme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
      

    

        public ActionResult CARIFISLISTE()
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

     


        // GET: CARI_HAREKET
        public ActionResult Index(int?id)
        {
            changestring();
            var model = new yenimodel();
            if (id != null) { 
            var cari = db.CARI_BASLIK.Find(id);
            model.ismi = cari.FIRMAUNVANI;
            model.kodu = cari.CARIKOD;
            model.Toplamalacak = cari.TOPLAMALACAK.ToString().Replace(",",".");
            model.Toplamborc = cari.TOPLAMBORC.ToString().Replace(",", ".");
            model.Bakiye = cari.BAKIYE.ToString().Replace(",", ".");
            model.id = cari.ID;
            }
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            if (gorme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }

        }


      

        public ActionResult Rapor(int? id,DateTime ilktarih,DateTime sontarih)
        {
            changestring();
            var rapor = new rapor();
            var cari = db.CARI_BASLIK.Find(id);
            var hareketler = db.CARI_HAREKET.Where(x => x.cariID == cari.ID&& DbFunctions.TruncateTime(x.TARIHSAAT) >= DbFunctions.TruncateTime(ilktarih) && DbFunctions.TruncateTime(x.TARIHSAAT) <= DbFunctions.TruncateTime(sontarih)).ToList();
            rapor.Firma = db.FIRMA.FirstOrDefault();
            rapor.Thler = new List<string>();
            rapor.Toplamlar = new List<valler>();
            rapor.Tdler = new List<islem>();
            rapor.Baslıklar = new List<valler>();
            rapor.Thler.Add("İşlem Türü");
            rapor.Thler.Add("Ayrıntı");
            rapor.Thler.Add("Belge No");
            rapor.Thler.Add("Vade");
            rapor.Thler.Add("İade");
            rapor.Thler.Add("Açıklama");
            rapor.Thler.Add("Borç/Giriş");
            rapor.Thler.Add("Alacak/Çıkış");
            rapor.Thler.Add("Durum Bakiye");

            rapor.Baslıklar.Add(new valler { Baslık = "Cari Kodu/Adı", Deger = cari.CARIKOD + "/" + cari.FIRMAUNVANI });
            rapor.Baslıklar.Add(new valler { Baslık = "Telefon", Deger =  cari.ISTEL });
            rapor.Baslıklar.Add(new valler { Baslık = "Adres,", Deger = cari.ISADRES1 });
            var toplamalacak = hareketler.Sum(x=>x.ALACAK);
            var toplamborc = hareketler.Sum(x=>x.BORC);
            var bakiye = toplamborc - toplamalacak;
            foreach (var item in hareketler)
            {
                var yenisilem = new islem();
                yenisilem.Islem = "<td>" + item.ISLEMTURU + "</td>";
                yenisilem.Islem += "<td>" + item.ISLEMTURU+ "</td>";
                yenisilem.Islem += "<td>" + item.DOSYANO + "</td>";
                yenisilem.Islem += "<td>" + item.CreateDate.ToShortDateString() + "</td>";
                yenisilem.Islem += "<td>" + "Hayır" + "</td>";
                yenisilem.Islem += "<td>" + item.ACIKLAMA + "</td>";
                yenisilem.Islem += @"<td class=""text-end"">" + item.BORC+ "</td>";
                yenisilem.Islem +=@"<td class=""text-end"">" + item.ALACAK + "</td>";
                yenisilem.Islem += @"<td class=""text-end"">" + item.BAKIYE + "</td>";
                var althareket = ayrintigetirraporvoid(item.ISLEMNO, item.ISLEMTURU.ToString());
                yenisilem.Kalem = althareket;
                rapor.Tdler.Add(yenisilem);
            }
            rapor.Toplamlar.Add(new valler { Baslık="Borç",Deger=toplamborc.ToString() }) ;
            rapor.Toplamlar.Add(new valler { Baslık = "Alacak", Deger = toplamalacak.ToString() });
            rapor.Toplamlar.Add(new valler { Baslık = "Bakiye", Deger = bakiye.ToString() });

          Session["rapor"] = rapor;
            return View(rapor);
        }



    

        [HttpPost]
        public JsonResult GetData(string search, string order, int offset, int limit, string sort, int id, filtermodel[] filterler)
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
            List<CariHareketAraViewModel> hareketler = new List<CariHareketAraViewModel>();

            var zaman = new DateTime();
            var sonzaman = new DateTime();


            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[6];

            aranacaklar[0] = "hareket.ISLEMNO";
            aranacaklar[1] = "hareket.ACIKLAMA";
            aranacaklar[2] = "CARI";
            aranacaklar[3] = "sehir";
            aranacaklar[4] = "ozelkod1";
            aranacaklar[5] = "ozelkod2";
            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";
            if (id != 0)
            {
                query += $"&&({"hareket.cariID"}=={ id })";
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








            var v = (from a in db.CARI_HAREKET.Select(pr => new
            {
                hareket = pr,
                CARI = pr.cari.FIRMAUNVANI,
                sehir = pr.cari.ISIL,
                ozelkod1 = pr.cari.KOD1,
                ozelkod2 = pr.cari.KOD2,
                S_MERKEZI = pr.S_MERKEZI.ACIKLAMA
            }).Where(x => x.hareket.deleted != 1).Where(x => DbFunctions.TruncateTime(x.hareket.TARIHSAAT) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.TARIHSAAT) <= DbFunctions.TruncateTime(sonzaman)).Where(query)
                     select a);


            if (!(string.IsNullOrEmpty(sortcolumn)) && !(string.IsNullOrEmpty(sortColumnDir)))
            {
                v = v.OrderBy(sort + " " + sortColumnDir);
            }
            else
            {
                v = v.OrderByDescending(x => x.hareket.TARIHSAAT);
            }
            var data = v.Skip(offset).Take(limit).ToList();
            totalRecords = v.Count();
            foreach (var item in data)
            {


                var yenihareket = new CariHareketAraViewModel();

                yenihareket.ID = item.hareket.ID;
                if (id == 0)
                {

                    yenihareket.CARIKOD = item.hareket.CARIKOD;
                    yenihareket.CARI = item.CARI;
                }
                else
                {
                    yenihareket.CARI = "";
                    yenihareket.CARIKOD = "";
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
                        yenihareket.ISLEMTURU = "KasaÇıkış Fişi";
                    }
                    if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.BankaFişi)
                    {
                        yenihareket.ISLEMTURU = "BankaÇıkış Fişi";
                       
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
                        yenihareket.ISLEMTURU = "PersonelSatış";

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
                            yenihareket.ISLEMTURU = "KasaGiriş Fişi";
                         
                        }
                        if (item.hareket.ISLEMTURU == CARI_HAREKET.tür.BankaFişi)
                        {
                            yenihareket.ISLEMTURU = "BankaGiriş Fişi";

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
                            yenihareket.ISLEMTURU = "PersonelGiriş Fişi";
                        
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


                yenihareket.ISLEMNO = item.hareket.ISLEMNO;
                if (item.hareket.VADE != null)
                    yenihareket.VADE = item.hareket.VADE.Value.ToShortDateString();
                else
                {
                    yenihareket.VADE = "";

                }
                if (!string.IsNullOrEmpty(item.hareket.ACIKLAMA))
                    yenihareket.ACIKLAMA = item.hareket.ACIKLAMA;
                else { yenihareket.ACIKLAMA = ""; }

                yenihareket.BORC = item.hareket.BORC;
                yenihareket.ALACAK = item.hareket.ALACAK;
                yenihareket.BAKIYE = item.hareket.BAKIYE;
                yenihareket.DOVIZBORC = item.hareket.DOVIZBORC;
                yenihareket.DOVIZALACAK = item.hareket.DOVIZALACAK;
                yenihareket.DOVIZBAKIYE = item.hareket.DOVIZBAKIYE;
                yenihareket.S_MERKEZI = item.S_MERKEZI;
                hareketler.Add(yenihareket);



            }


            db.Dispose();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        [HttpPost]
        public JsonResult urlgetir(string belgeno, string türü)
        {
            changestring();
            var sonurl = "";
            if (türü == "Tahsilat Fişi" || türü == "Teddiye Fişi")
            {
                var id = db.CARI_FIS.Where(x => x.FISNO == belgeno).FirstOrDefault().ID;
                sonurl = "/CARI_HAREKET/CARIFISKART/" + id;
            }
            else
            if (türü == "StokGiriş Fişi" || türü == "StokÇıkış Fişi")
            {
                var id = db.STOK_FIS.Where(x => x.FISNO == belgeno).FirstOrDefault().ID;
                sonurl = "/STOK_HAREKET/STOKFISKART/" + id;
            }
            else
            if (türü == "KasaGiriş Fişi" || türü == "KasaÇıkış Fişi")
            {
                var id = db.KASA_FISI.Where(x => x.FISNO == belgeno).FirstOrDefault().ID;
                sonurl = "/KASA_HAREKET/KASAFISKART/" + id;
            }
            else
            if (türü == "PersonelGiriş Fişi" || türü == "PersonelÇıkış Fişi" || türü == "PersonelFişi")
            {
                var id = db.PERSONEL_FISI.Where(x => x.FISNO == belgeno).FirstOrDefault().ID;
                sonurl = "/PERSONEL_HAREKET/PERSONELFISKART/" + id;
            }
            else
            if (türü == "Maaşİşlemleri")
            {
                var id = db.PERSONEL_MAAS_TAHAKKUK.Where(x => x.FISNO == belgeno).FirstOrDefault().ID;
                sonurl = "/PERSONEL_HAREKET/PERSONELTAHAKKUKKART/" + id;
            }
            else
            if (türü == "BankaGiriş Fişi" || türü == "BankaÇıkış Fişi")
            {
                var id = db.BANKA_FIS.Where(x => x.FISNO == belgeno).FirstOrDefault().ID;
                sonurl = "/BANKA_HAREKET/BANKAFISKART/" + id;
            }
            else
            if (türü == "AlışFaturası" || türü == "SatışFaturası")
            {
                var id = db.FATURA.Where(x => x.FATNO == belgeno).FirstOrDefault().ID;
                sonurl = "/FATURA/FATURAKART/" + id;

            }
            else
            if (türü == "EFatura" || türü == "EFatura")
            {
                var id = db.EFATURA.Where(x => x.FATURANO == belgeno || x.ETTN == belgeno).FirstOrDefault().ID;
                sonurl = "/FATURA/EFATURAKART/" + id;
            }
            else
            if (türü == "Alışİrsaliye" || türü == "Satışİrsaliye")
            {
                var id = db.IRSALIYE.Where(x => x.IRSNO == belgeno).FirstOrDefault().ID;
                sonurl = "/IRSALIYE/IRSALIYEKART/" + id;
            }
            else
            if (türü == "Üretim")
            {
                var id = db.STOK_URETIM_FISI.Where(x => x.FISNO == belgeno).FirstOrDefault().ID;
                sonurl = "/RECETE_HAREKET/RECETEFISKART/" + id;
            }
            else
            {
                sonurl = "/CARI_BASLIK/";
            }


            var jsonResult = Json(sonurl, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            db.Dispose(); return jsonResult;
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

            aranacaklar[0] = "hareket.CariKod";
            aranacaklar[1] = "hareket.FISNO";
            aranacaklar[2] = "CARIADI";




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




            var v = (from a in db.CARI_FIS.Select(pr => new
            {
                hareket = pr,
                CARIADI = pr.Cari.FIRMAUNVANI,

                S_MERKEZI = pr.SORUMLULUK_MERKEZI.ACIKLAMA
            }).Where(x => x.hareket.deleted != 1).Where(x => DbFunctions.TruncateTime(x.hareket.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query)
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


                var yenihareket = new FisaravieweNodel();

                yenihareket.ID = item.hareket.ID;


                yenihareket.CARIKOD = item.hareket.CariKod;
                yenihareket.CARIADI = item.CARIADI;


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

        public JsonResult kasagetir(string kasatipi,int? tur)
        {
            changestring();
            List<KASA> liste;
            if (tur != null)
            {   liste = db.KASA.Where(x => x.TIPI.ToString().Contains(kasatipi) && x.deleted == null&&x.TUR==(KASA.türü) tur).ToList();

            }
         
            else
                liste = db.KASA.Where(x => x.TIPI.ToString().Contains(kasatipi) && x.deleted == null ).ToList();
            var gönderilcek = new List<kasatipi>();
            foreach (var item in liste)
            {
                var kasatipi1 = new kasatipi();
                kasatipi1.KASAADI = item.KASAADI;
                kasatipi1.KASAKODU = item.KASAKODU;
                kasatipi1.TIPI = item.TIPI.ToString();
                gönderilcek.Add(kasatipi1);
            }
            var jsonResult = Json(gönderilcek, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            db.Dispose();
            db.Dispose(); return jsonResult;
        }

        [HttpPost]
        public JsonResult fissil(int id)
        {
            changestring();
            var fis = db.CARI_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.CARI_FIS_HAREKETs.Where(x => x.CARI_FIsID == id && x.deleted != 1);

            var kasaharetleri = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var hareketler = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();

            var cari = db.CARI_BASLIK.Where(x => x.ID == fis.CariID).FirstOrDefault();



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
                        if (kasahareket.TIPI == CARI_HAREKET.tip.Giriş)
                        {
                            kasa.TOPLAMBORC -= kasahareket.BORC;

                            foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE -= kasahareket.BORC;

                            }

                        }
                        else
                        {
                            kasa.TOPLAMALACAK -= kasahareket.ALACAK;


                            foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE += kasahareket.ALACAK;

                            }



                        }
                    }
                    else
                    {
                        if (kasahareket.TIPI == CARI_HAREKET.tip.Giriş)
                        {


                            kasa.TOPLAMBORC -= kasahareket.BORC;

                        }
                        else
                        {


                            kasa.TOPLAMALACAK -= kasahareket.ALACAK;





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
                        var eskihareket = new CARI_HAREKET();
                        if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 1)
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
                        else
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
                    }
                    else
                    {
                        if (fis.TIP == 1)
                        {


                            cari.TOPLAMDOVIZALACAK -= carihareket.DOVIZALACAK;
                            cari.TOPLAMALACAK -= carihareket.ALACAK;
                            db.SaveChanges();

                        }
                        else
                        {


                            cari.TOPLAMDOVIZBORC -= carihareket.DOVIZBORC;
                            cari.TOPLAMBORC -= carihareket.BORC;

                            db.SaveChanges();

                        }

                    }
                    item.deleted = 1;
                    db.SaveChanges();
                }
                var silincekcekler = new List<string>();
                var silinceksenetler = new List<string>();
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
                var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
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
                            if (db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item).Count() > 0)
                                db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item).FirstOrDefault().CEKDURUMU = CEKLER_ALINAN.alinandurumlar.Pörtföy;
                            else
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
                            if (db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item).Count() > 0)
                                db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item).FirstOrDefault().SENETDURUMU = CEKLER_ALINAN.alinandurumlar.Pörtföy;
                            else
                                db.SENETLER_VERILEN.Where(x => x.PORTFOYNO == item).FirstOrDefault().deleted = 1;
                        }

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

            var fis = db.CARI_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.CARI_FIS_HAREKETs.Where(x => x.CARI_FIsID == id && x.deleted != 1);

            var kasaharetleri = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var hareketler = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();

            var cari = db.CARI_BASLIK.Where(x => x.ID == fis.CariID).FirstOrDefault();

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
                        kasa.TOPLAMBORC += kasahareket.BORC;

                        foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                        {
                            hareketz.BAKIYE -= kasahareket.BORC;

                        }

                    }
                    else
                    {
                        kasa.TOPLAMALACAK += kasahareket.ALACAK;


                        foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                        {
                            hareketz.BAKIYE += kasahareket.ALACAK;

                        }



                    }
                }
                else
                {
                    if (fis.TIP == 1)
                    {
                        kasa.TOPLAMBORC -= kasahareket.BORC;




                    }
                    else
                    {

                        kasa.TOPLAMALACAK -= kasahareket.ALACAK;





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
                    var eskihareket = new CARI_HAREKET();
                    if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                    {
                        eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                    }
                    else { eskihareket.BAKIYE = 0; }
                    if (fis.TIP == 1)
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
                    else
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
                }
                else
                {
                    if (fis.TIP == 1)
                    {

                        cari.TOPLAMDOVIZALACAK -= carihareket.DOVIZALACAK;
                        cari.TOPLAMALACAK -= carihareket.ALACAK;
                        db.SaveChanges();
                    }
                    else
                    {


                        cari.TOPLAMDOVIZBORC -= carihareket.DOVIZBORC;
                        cari.TOPLAMBORC -= carihareket.BORC;

                        db.SaveChanges();

                    }

                }
                item.deleted = 1;
                db.SaveChanges();
            }




            var kasaharetlerii = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO);
            db.KASA_HAREKET.RemoveRange(kasaharetlerii);
            var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO);
            db.CARI_HAREKET.RemoveRange(cariharetlerii);
            db.CARI_FIS_HAREKETs.RemoveRange(fishareketleri);

            db.SaveChanges();













        }


        [HttpPost]
        public JsonResult datagonder(carifismodel gelenveri)
        {
            changestring();


            double toplamtutar = 0;
            double toplamdovuz = 0;
            var carifis = new CARI_FIS();
            var carid = int.Parse(gelenveri.CARIKOD);
            var cari = db.CARI_BASLIK.Find(carid);

            carifis.Cari = cari;
            carifis.CariKod = carifis.Cari.CARIKOD;
            carifis.CreateDate = DateTime.Now;
            carifis.TIP = (int)gelenveri.TIPI;
            carifis.CreateUserID = userid;
            carifis.FISNO = gelenveri.FISNO.ToString();
            carifis.NOT = gelenveri.NOT;

            carifis.SORUMLULUK_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
            carifis.TARIH = DateTime.Parse(gelenveri.TARIH);
           
            if (gelenveri.gelenhareket.Count == 0)
            {
                var jsonResult = Json("Başarısız", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                db.Dispose();
                db.Dispose(); return jsonResult;
            }
            else
            {
                var trans = db.Database.BeginTransaction();
                try
                {
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        toplamtutar += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                        toplamdovuz += double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                    }
                    carifis.TUTAR = toplamtutar;
                    var list = db.CARI_FIS.SingleOrDefault(x => x.FISNO == carifis.FISNO);
                    if (list == null)
                    {
                        int i = 0;

                        db.CARI_FIS.Add(carifis);
                        list = carifis;
                        db.SaveChanges();
                        foreach (var item in gelenveri.gelenhareket)
                        {
                            i += 1;

                            var hareket = new CARI_HAREKET();
                            double doviztutar = 0;
                            if (item.PARABIRIMI == cari.PARABIRIMI)
                                doviztutar = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                            else
                            {
                                doviztutar = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ",")) / db.KUR_BASLIK.Where(x => x.KURKODU == cari.PARABIRIMI).FirstOrDefault().KUR;
                            }
                            hareket.cari = cari;
                            hareket.CARIKOD = hareket.cari.CARIKOD;
                            hareket.CreateDate = DateTime.Now;
                            hareket.KAYITSEKLI = item.HAREKET;



                            hareket.CreateUserID = userid;
                            hareket.ISLEMNO = gelenveri.FISNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            hareket.TARIHSAAT = hareket.TARIHSAAT.AddSeconds(i);
                            
                            hareket.ISLEMTURU = CARI_HAREKET.tür.CariFişi;
                            hareket.S_MERKEZIID = carifis.SORUMLULUK_MERKEZIID;
                            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new CARI_HAREKET();
                                if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                                {
                                    eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZALACAK = doviztutar;
                                    cari.TOPLAMDOVIZALACAK += doviztutar;
                                    cari.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = eskihareket.BAKIYE - double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ",")); ;
                                    hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE - doviztutar;
                                    foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE -= double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                        if (item.PARABIRIMI == cari.PARABIRIMI)
                                            hareketz.DOVIZBAKIYE -= doviztutar;
                                        else
                                        {
                                            hareketz.DOVIZBAKIYE -= doviztutar;
                                        }


                                    }

                                }
                                else
                                {

                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    hareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBORC = doviztutar;
                                    cari.TOPLAMDOVIZBORC = doviztutar;
                                    cari.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = eskihareket.BAKIYE + double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE + doviztutar;
                                    foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                        if (item.PARABIRIMI == cari.PARABIRIMI)
                                            hareketz.DOVIZBAKIYE += doviztutar;
                                        else
                                        {
                                            hareketz.DOVIZBAKIYE += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ",")) / db.KUR_BASLIK.Where(x => x.KURKODU == cari.PARABIRIMI).FirstOrDefault().KUR;
                                        }
                                    }

                                }


                            }
                            else
                            {
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZALACAK = doviztutar;
                                    cari.TOPLAMDOVIZALACAK += doviztutar;
                                    cari.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = cari.BAKIYE;
                                    hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;

                                }
                                else
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    hareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBORC = doviztutar;
                                    cari.TOPLAMDOVIZBORC += doviztutar;
                                    cari.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = cari.BAKIYE;
                                    hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;




                                }
                            }



                            hareket.ACIKLAMA = item.ACIKLAMA;

                            hareket.VADE = DateTime.Parse(item.VADE);

                            db.CARI_HAREKET.Add(hareket);

                            var fishareket = new CARI_FIS_HAREKET();
                            fishareket.HAREKET = item.HAREKET.ToString();
                            fishareket.CARI_FIs = db.CARI_FIS.Find(carifis.ID);
                            fishareket.ACIKLAMA = item.ACIKLAMA;
                            fishareket.KASA = item.KASA;
                            fishareket.NETTUTAR = item.NETTUTAR;
                            fishareket.VADE = item.VADE;
                            fishareket.PORTFÖYNO = item.PORTFOYNO;
                            fishareket.TUTAR = item.TUTAR;
                            fishareket.PARABIRIMI = item.PARABIRIMI;
                            fishareket.PARAKURU = item.PARAKURU;
                            db.CARI_FIS_HAREKETs.Add(fishareket);
                            db.SaveChanges();
                        }




                    }
                    else
                    {

                        fisiyenile(list.ID);


                        list.UpdateDate = DateTime.Now;
                        list.UpdateUserID = userid;
                        list.SORUMLULUK_MERKEZIID = carifis.SORUMLULUK_MERKEZIID;
                        list.TARIH = carifis.TARIH;
                        list.NOT = carifis.NOT;
                        list.TUTAR = carifis.TUTAR;
                        db.SaveChanges();

                        foreach (var item in gelenveri.gelenhareket)
                        {
                            double doviztutar = 0;
                            var hareket = new CARI_HAREKET();
                            if (item.PARABIRIMI == cari.PARABIRIMI)
                                doviztutar = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                            else
                            {
                                doviztutar = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ",")) / db.KUR_BASLIK.Where(x => x.KURKODU == cari.PARABIRIMI).FirstOrDefault().KUR;
                            }
                            hareket.cari = cari;
                            hareket.CARIKOD = hareket.cari.CARIKOD;
                            hareket.CreateDate = DateTime.Now;
                            hareket.KAYITSEKLI = item.HAREKET;


                            hareket.CreateUserID = userid;
                            hareket.ISLEMNO = gelenveri.FISNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                            hareket.ISLEMTURU = CARI_HAREKET.tür.CariFişi;
                            hareket.S_MERKEZIID = carifis.SORUMLULUK_MERKEZIID;
                            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new CARI_HAREKET();
                                if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                                {
                                    eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZALACAK = doviztutar;
                                    cari.TOPLAMDOVIZALACAK += doviztutar;
                                    cari.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = eskihareket.BAKIYE - double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE - doviztutar;
                                    foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE -= double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                        hareketz.DOVIZBAKIYE -= doviztutar;
                                    }



                                }
                                else
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;

                                    hareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBORC = doviztutar;
                                    cari.TOPLAMDOVIZBORC += doviztutar;
                                    cari.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = eskihareket.BAKIYE + double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE + doviztutar;
                                    foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                    {
                                        hareketz.BAKIYE -= double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                        hareketz.DOVIZBAKIYE -= doviztutar;
                                    }

                                }


                            }
                            else
                            {
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZALACAK = doviztutar;
                                    cari.TOPLAMDOVIZALACAK += doviztutar;
                                    cari.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = cari.BAKIYE;
                                    hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;

                                }
                                else
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    hareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                    hareket.DOVIZBORC = doviztutar;
                                    cari.TOPLAMDOVIZBORC += doviztutar;
                                    cari.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = cari.BAKIYE;
                                    hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;


                                }
                            }



                            hareket.ACIKLAMA = item.ACIKLAMA;

                            hareket.VADE = DateTime.Parse(item.VADE);

                            db.CARI_HAREKET.Add(hareket);


                            var fishareket = new CARI_FIS_HAREKET();
                            fishareket.HAREKET = item.HAREKET.ToString();
                            fishareket.CARI_FIs = list;
                            fishareket.ACIKLAMA = item.ACIKLAMA;
                            fishareket.KASA = item.KASA;
                            fishareket.NETTUTAR = item.NETTUTAR;
                            fishareket.VADE = item.VADE;
                            fishareket.PORTFÖYNO = item.PORTFOYNO;
                            fishareket.TUTAR = item.TUTAR;
                            fishareket.PARABIRIMI = item.PARABIRIMI;
                            fishareket.PARAKURU = item.PARAKURU;
                            db.CARI_FIS_HAREKETs.Add(fishareket);
                            db.SaveChanges();
                        }
                    }

                    foreach (var item in gelenveri.gelenhareket)
                    {

                        var kasa = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();

                        var kasahareket = new KASA_HAREKET();
                        kasahareket.KASA = db.KASA.Where(x => x.KASAADI == item.KASA).FirstOrDefault();
                        kasahareket.KASAKODU = kasahareket.KASA.KASAKODU;
                        kasahareket.ILGILI = cari.FIRMAUNVANI;
                        kasahareket.CreateDate = DateTime.Now;
                        kasahareket.CreateUserID = userid;
                        kasahareket.ISLEMNO = gelenveri.FISNO;
                        kasahareket.DOSYANO = item.PORTFOYNO;
                        kasahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                        kasahareket.S_MERKEZIID = carifis.SORUMLULUK_MERKEZIID;
                        kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.CariFişi;
                        if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                        {
                            var eskihareket = new KASA_HAREKET();
                            if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).Count() > 0)
                            {
                                eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                            }
                            else { eskihareket.BAKIYE = 0; }
                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                kasahareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                kasa.TOPLAMBORC += kasahareket.BORC;
                                kasahareket.BAKIYE = eskihareket.BAKIYE + kasahareket.BORC;
                                foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                                {
                                    hareketz.BAKIYE += kasahareket.BORC;

                                }


                            }
                            else
                            {


                                kasahareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));

                                kasa.TOPLAMALACAK += kasahareket.ALACAK;
                                kasahareket.BAKIYE = eskihareket.BAKIYE - kasahareket.ALACAK;

                                foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1))
                                {
                                    hareketz.BAKIYE -= kasahareket.ALACAK;

                                }

                            }
                        }
                        else
                        {
                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {

                                kasahareket.BORC = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                                kasa.TOPLAMBORC += kasahareket.BORC;
                                kasahareket.BAKIYE = kasa.BAKIYE;

                                kasahareket.TIPI = CARI_HAREKET.tip.Giriş;



                            }
                            else
                            {
                                kasahareket.ALACAK = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));

                                kasa.TOPLAMALACAK += kasahareket.ALACAK;
                                kasahareket.BAKIYE = kasa.BAKIYE;
                                kasahareket.TIPI = CARI_HAREKET.tip.Çıkış;

                            }

                        }




                        kasahareket.ACIKLAMA = item.ACIKLAMA;


                        db.KASA_HAREKET.Add(kasahareket);


                        db.SaveChanges();

                        if (item.HAREKET == CARI_HAREKET_AYRINTI.detay.Visa)
                        {
                            var visa = new BANKA_VISA();

                            visa.BANKAKODU = item.PORTFOYNO;
                            if (db.BANKA_VISA.Count() != 0)
                                visa.PORTFOYNO = db.BANKA_VISA.Count() + 1;
                            else
                            {
                                visa.PORTFOYNO = 1;

                            }
                            visa.TUTAR = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                            visa.VADE = DateTime.Parse(item.VADE);
                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                visa.DURUMU = BANKA_VISA.DURUMLAR.TahsilBekliyor;
                            }
                            else
                            {
                                visa.DURUMU = BANKA_VISA.DURUMLAR.Ödenmemiş;

                            }

                            visa.CARI = cari;
                            visa.CARIID = cari.ID;
                            visa.KASA = kasa.KASAKODU;
                            visa.TARIHI = carifis.TARIH;
                            visa.CreateDate = DateTime.Now;
                            visa.CreateUserID = userid;
                            visa.PARABIRIMI = db.KUR_BASLIK.Where(x => x.KURKODU == item.PARABIRIMI).FirstOrDefault().ID;
                            visa.ACIKLAMA = visa.PORTFOYNO + "Nolu Viza";
                            visa.S_MERKEZI = carifis.SORUMLULUK_MERKEZIID;
                            db.BANKA_VISA.Add(visa);

                            db.SaveChanges();
                        }
                    }

                    if (gelenveri.CEKLER != null)
                        foreach (var item in gelenveri.CEKLER)
                        {

                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {

                                var cek = new CEKLER_ALINAN();
                                cek.PORTFOYNO = item.PORTFOYNO;
                                cek.CEKBANKA = item.BANKADI;
                                cek.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.Pörtföy;
                                cek.CEKHESAPNO = item.BANKAHESAPNO;
                                cek.ACIKLAMA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().ACIKLAMA;
                                cek.VADE = DateTime.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().VADE);
                                cek.CEKNO = item.ÇEKNO;
                                cek.KASA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().KASA;
                                cek.TARIH = DateTime.Now;
                                cek.ALINANKISIID = list.CariID;
                                cek.TUTAR = double.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().NETTUTAR.Replace(",", "").Replace(".", ","));
                                cek.CEKKESIDEEDEN = item.KASIDEDEN;
                                cek.CEKKESIDEYERI = item.KASIDEYERI;
                                cek.CEKKESIDETARIHI = DateTime.Parse(item.KASIDETARIHI);
                                cek.CreateDate = DateTime.Now;
                                cek.CreateUserID = userid;
                                cek.S_MERKEZIID = carifis.SORUMLULUK_MERKEZIID;
                                db.CEKLER_ALINAN.Add(cek);
                                db.SaveChanges();
                                var cekhareket = new CEKLER_ALINAN_HAREKET();
                                cekhareket.CEK = db.CEKLER_ALINAN.Where(X => X.PORTFOYNO == cek.PORTFOYNO).FirstOrDefault();
                                cekhareket.CEKID = cekhareket.CEK.ID;
                                cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.Pörtföy;
                                cekhareket.ACIKLAMA = "CariFiş Giriş";
                                cekhareket.DOSYANO = gelenveri.FISNO;
                                cekhareket.ACIKLAMA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().ACIKLAMA;
                                cekhareket.PORTFOYNO = cek.PORTFOYNO;
                                cekhareket.TARIH = DateTime.Now;
                                cekhareket.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.Pörtföy;
                                cekhareket.CreateDate = DateTime.Now;
                                cekhareket.CreateUserID = userid;
                                db.CEKLER_ALINAN_HAREKET.Add(cekhareket);
                            }
                            else
                            {

                                if (db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).ToList().Count() > 0)
                                {

                                    var cek = db.CEKLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).First();
                                    cek.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.Ciro;
                                    cek.CIROKISIID = list.CariID;
                                    cek.ACIKLAMA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().ACIKLAMA;
                                    cek.CIROTARIHI = DateTime.Parse(gelenveri.TARIH);
                                    db.Entry(cek).State = EntityState.Modified;
                                    var cekhareket = new CEKLER_ALINAN_HAREKET();
                                    cekhareket.CEK = cek;
                                    cekhareket.HARAKET = CEKLER_ALINAN.alinandurumlar.Ciro;
                                    cekhareket.ACIKLAMA = "CariFiş Çıkış";
                                    cekhareket.DOSYANO = gelenveri.FISNO;
                                    cekhareket.PORTFOYNO = cek.PORTFOYNO;
                                    cekhareket.ACIKLAMA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().ACIKLAMA;
                                    cekhareket.TARIH = DateTime.Now;
                                    cekhareket.CEKDURUMU = CEKLER_ALINAN.alinandurumlar.Ciro;
                                    cekhareket.CreateDate = DateTime.Now;
                                    cekhareket.CreateUserID = userid;
                                    db.CEKLER_ALINAN_HAREKET.Add(cekhareket);
                                    db.SaveChanges();
                                }
                                else
                                {

                                    var cek = new CEKLER_VERILEN();
                                    cek.PORTFOYNO = item.PORTFOYNO;
                                    cek.ACIKLAMA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().ACIKLAMA;
                                    cek.VADE = DateTime.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().VADE);
                                    cek.CEKBANKA = item.BANKADI;
                                    cek.TUTAR = double.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().NETTUTAR.Replace(",", "").Replace(".", ","));
                                    cek.CEKNO = item.ÇEKNO;
                                    cek.KASA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().KASA;
                                    cek.VERILENKISIID = list.CariID;
                                    cek.KESIDETARIHI = carifis.TARIH;
                                    cek.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.Ödenmemiş;
                                    cek.S_MERKEZIID = carifis.SORUMLULUK_MERKEZIID;

                                    cek.CreateDate = DateTime.Now;
                                    cek.CreateUserID = userid;
                                    db.CEKLER_VERILEN.Add(cek);
                                    db.SaveChanges();
                                    var cekhareket = new CEKLER_VERILEN_HAREKET();
                                    cekhareket.ACIKLAMA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().ACIKLAMA;
                                    cekhareket.CEK = db.CEKLER_VERILEN.Where(X => X.PORTFOYNO == cek.PORTFOYNO).FirstOrDefault();
                                    cekhareket.CEKID = cekhareket.CEK.ID;
                                    cekhareket.HARAKET = CEKLER_VERILEN.verilendurumlar.Ödenmemiş;
                                    cekhareket.ACIKLAMA = "CariFiş Çıkış";
                                    cekhareket.DOSYANO = gelenveri.FISNO;
                                    cekhareket.CEKNO = cek.CEKNO;
                                    cekhareket.TARIH = DateTime.Now;
                                    cekhareket.CEKDURUMU = CEKLER_VERILEN.verilendurumlar.Ödenmemiş;
                                    cekhareket.CreateDate = DateTime.Now;
                                    cekhareket.CreateUserID = userid;
                                    db.CEKLER_VERILEN_HAREKET.Add(cekhareket);
                                }
                            }


                            db.SaveChanges();
                        }
                    if (gelenveri.SENETLER != null)
                        foreach (var item in gelenveri.SENETLER)
                        {

                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {

                                var senet = new SENETLER_ALINAN();
                                senet.PORTFOYNO = item.PORTFOYNO;

                                senet.SENETDURUMU = CEKLER_ALINAN.alinandurumlar.Pörtföy;

                                senet.VADE = DateTime.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().VADE);
                                senet.KASA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().KASA;
                                senet.TARIH = DateTime.Now;
                                senet.ALINANKISIID = list.CariID;
                                senet.TUTAR = double.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().NETTUTAR.Replace(",", "").Replace(".", ","));
                                senet.SENETKESIDEEDEN = item.KESIDEEDEN;
                                senet.SENETADRES1 = item.ADRES;
                                senet.SENETSEHIR = item.SEHIR;
                                senet.SENETKESIDETARIHI = DateTime.Parse(item.KESIDETARIHI);
                                senet.CreateDate = DateTime.Now;
                                senet.CreateUserID = userid;
                                senet.S_MERKEZIID = carifis.SORUMLULUK_MERKEZIID;
                                db.SENETLER_ALINAN.Add(senet);
                                db.SaveChanges();
                                var senethareket = new SENETLER_ALINAN_HAREKET();
                                senethareket.ACIKLAMA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().ACIKLAMA;
                                senethareket.SENET = db.SENETLER_ALINAN.Where(X => X.PORTFOYNO == senet.PORTFOYNO).FirstOrDefault();
                                senethareket.SENETID = senethareket.SENET.ID;
                                senethareket.HARAKET = CEKLER_ALINAN.alinandurumlar.Pörtföy;
                                senethareket.ACIKLAMA = "CariFiş Giriş";
                                senethareket.DOSYANO = gelenveri.FISNO;
                                senethareket.PORTFOYNO = senet.PORTFOYNO;
                                senethareket.TARIH = DateTime.Now;
                                senethareket.SENETDURUMU = CEKLER_ALINAN.alinandurumlar.Pörtföy;
                                senethareket.CreateDate = DateTime.Now;

                                senethareket.CreateUserID = userid;
                                db.SENETLER_ALINAN_HAREKET.Add(senethareket);
                            }
                            else
                            {

                                if (db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).ToList().Count() > 0)
                                {

                                    var senet = db.SENETLER_ALINAN.Where(x => x.PORTFOYNO == item.PORTFOYNO).First();
                                    senet.SENETDURUMU = CEKLER_ALINAN.alinandurumlar.Ciro;
                                    senet.CIROKISIID = cari.ID;
                                    senet.CIROTARIHI = DateTime.Parse(gelenveri.TARIH);
                                    senet.KASA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().KASA;
                                    db.Entry(senet).State = EntityState.Modified;
                                    var senethareket = new SENETLER_ALINAN_HAREKET();
                                    senethareket.SENET = db.SENETLER_ALINAN.Where(X => X.PORTFOYNO == senet.PORTFOYNO).FirstOrDefault();
                                    senethareket.SENETID = senethareket.SENET.ID;
                                    senethareket.HARAKET = CEKLER_ALINAN.alinandurumlar.Ciro;
                                    senethareket.ACIKLAMA = "CariFiş Çıkış";
                                    senethareket.DOSYANO = gelenveri.FISNO;
                                    senethareket.PORTFOYNO = senet.PORTFOYNO;
                                    senethareket.ACIKLAMA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().ACIKLAMA;
                                    senethareket.TARIH = DateTime.Now;
                                    senethareket.SENETDURUMU = CEKLER_ALINAN.alinandurumlar.Ciro;
                                    senethareket.CreateDate = DateTime.Now;
                                    senethareket.CreateUserID = userid;
                                    db.SENETLER_ALINAN_HAREKET.Add(senethareket);
                                    db.SaveChanges();
                                }
                                else
                                {

                                    var senet = new SENETLER_VERILEN();
                                    senet.PORTFOYNO = item.PORTFOYNO;
                                    senet.VADE = DateTime.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().VADE);

                                    senet.TUTAR = double.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().NETTUTAR.Replace(",", "").Replace(".", ","));
                                    senet.KASA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().KASA;
                                    senet.TUTAR = double.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().NETTUTAR.Replace(",", "").Replace(".", ","));
                                    senet.VERILENKISIID = list.CariID;
                                    senet.KESIDETARIHI = DateTime.Now;
                                    senet.SENETDURUMU = CEKLER_VERILEN.verilendurumlar.Ödenmemiş;
                                    senet.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).First().ID;
                                    senet.VADE = DateTime.Parse(gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().VADE);
                                    senet.CreateDate = DateTime.Now;
                                    senet.CreateUserID = userid;
                                    db.SENETLER_VERILEN.Add(senet);
                                    db.SaveChanges();
                                    var senethareket = new SENETLER_VERILEN_HAREKET();
                                    senethareket.ACIKLAMA = gelenveri.gelenhareket.Where(x => x.PORTFOYNO == item.PORTFOYNO).FirstOrDefault().ACIKLAMA;
                                    senethareket.SENET = db.SENETLER_VERILEN.Where(X => X.PORTFOYNO == senet.PORTFOYNO).FirstOrDefault();
                                    senethareket.SENETID = senethareket.SENET.ID;
                                    senethareket.HARAKET = CEKLER_VERILEN.verilendurumlar.Ödenmemiş;
                                    senethareket.ACIKLAMA = "CariFiş Çıkış";
                                    senethareket.DOSYANO = gelenveri.FISNO;

                                    senethareket.TARIH = DateTime.Now;
                                    senethareket.SENETDURUMU = CEKLER_VERILEN.verilendurumlar.Ödenmemiş;
                                    senethareket.CreateDate = DateTime.Now;
                                    senethareket.CreateUserID = userid;
                                    db.SENETLER_VERILEN_HAREKET.Add(senethareket);
                                }
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
                    return Json("Başarısız! " + ex.Message + " " + ex.InnerException);
                }

            }

        }


        [HttpPost]
        public JsonResult ayrintigetir(string belgeno, string türü)
        {

            var metin = "<table><thead>";

            changestring();

            if (türü == "Tahsilat Fişi" || türü == "Teddiye Fişi")
            {
                metin += "<td>Hareket</td><td>PortFoyNo</td><td>Açıklama</td><td>Tutar<t/d><td>ParaBirimi</td><td>ParaKuru</td><td>NetTutar</td>";
                metin += "</thead><tbody>";
                var id = db.CARI_FIS.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.CARI_FIS_HAREKETs.Where(x => x.CARI_FIsID == id))
                {
                    metin += "<tr>";
                    metin += "<td>" + item.HAREKET + "</td>";
                    metin += "<td>" + item.PORTFÖYNO + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.TUTAR + "</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKURU + "</td>";
                    metin += "<td>" + item.NETTUTAR + "</td>";
                    metin += "</tr>";
                }

            }
            if (türü == "BankaGiriş Fişi" || türü == "BankaÇıkış Fişi")
            {
                metin += "<td>Hareket</td><td>PortFoyNo</td><td>Açıklama</td><td>Tutar<t/d><td>ParaBirimi</td><td>ParaKuru</td><td>NetTutar</td>";
                metin += "</thead ><tbody>";
                var id = db.BANKA_FIS.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.BANKA_FIS_HAREKET.Where(x => x.BANKA_FISID == id))
                {
                    metin += "<tr>";
                    metin += "<td>" + item.HAREKET + "</td>";
                    metin += "<td>" + item.PORTFÖYNO + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.TUTAR + "</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKURU + "</td>";
                    metin += "<td>" + item.NETTUTAR + "</td>";
                    metin += "</tr>";
                }

            }
            if (türü == "KasaGiriş Fişi" || türü == "KasaÇıkış Fişi")
            {
                metin += "<td>Hareket</td><td>İlgili</td><td>Açıklama</td><td>Tutar<t/d><td>ParaBirimi</td><td>ParaKuru</td><td>NetTutar</td>";
                metin += "</thead ><tbody>";
                var id = db.KASA_FISI.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.KASA_FISI_HAREKET.Where(x => x.KASA_FISIID == id))
                {
                    metin += "<tr>";
                    metin += "<td>" + item.HAREKET + "</td>";
                    metin += "<td>" + item.ILGILI + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.TUTAR + "</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKURU + "</td>";
                    metin += "<td>" + item.NETTUTAR + "</td>";
                    metin += "</tr>";
                }

            }
            if (türü == "StokGiriş Fişi" || türü == "StokÇıkış Fişi")
            {
                metin += "<td>Stok Kodu</td><td>Açıklama</td><td>Miktar</td><td>Birim</td><td>Fiyat</td><td>İskonto</td><td>ParaBirimi</td><td>ParaKuru</td><td>NetTutar</td>";
                metin += "</thead ><tbody>";
                var id = db.STOK_FIS.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.STOK_FIS_HAREKET.Include("STOK").Where(x => x.fisid == id))
                {
                    metin += "<tr>";
                    metin += "<td>" + item.STOK.STOKKODU + "" + item.STOK.STOKAD + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.MIKTAR + "</td>";
                    metin += "<td>" + item.BIRIM + "</td>";
                    metin += "<td>" + item.FIYAT + "</td>";
                    if (item.ISK1 != null)
                        metin += "<td>" + item.ISK1 + "</td>";
                    else
                        metin += "<td>0</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKUR + "</td>";
                    metin += "<td>" + item.TOPLAMTUTAR + "</td>";
                    metin += "</tr>";
                }

            }
            if (türü == "AlışFaturası" || türü == "SatışFaturası")
            {
                metin += "<td>Stok Kodu</td><td>Açıklama</td><td>Miktar</td><td>Birim</td><td>Fiyat</td><td>İskonto</td><td>ParaBirimi</td><td>ParaKuru</td><td>NetTutar</td>";
                metin += "</thead><tbody>";
                var id = db.FATURA.SingleOrDefault(x => x.FATNO == belgeno).ID;
                foreach (var item in db.FATURA_HAREKET.Include("STOK").Where(x => x.FATURAID == id))
                {
                    metin += "<tr>";
                    metin += "<td>" + item.STOK.STOKKODU + "" + item.STOK.STOKAD + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.MIKTAR + "</td>";
                    metin += "<td>" + item.BIRIM + "</td>";
                    metin += "<td>" + item.FIYAT + "</td>";
                    if (item.ISK1 != null)
                        metin += "<td>" + item.ISK1 + "</td>";
                    else
                        metin += "<td>0</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKUR + "</td>";
                    metin += "<td>" + item.KDVTUTARI + "</td>";
                    metin += "</tr>";
                }

            }
            if (türü == "EFatura" || türü == "EFatura")
            {
                metin += "<td>Stok Kodu</td><td>Açıklama</td><td>Miktar</td><td>Birim</td><td>Fiyat</td><td>İskonto</td><td>ParaBirimi</td><td>ParaKuru</td><td>NetTutar</td>";
                metin += "</thead><tbody>";
                var idb = db.EFATURA.Where(x => x.FATURANO == belgeno).FirstOrDefault().ID;
                var efatura = db.EFATURAIN.Where(x => x.EFATURAID == idb).FirstOrDefault();
        
                foreach (var item in db.EFATURAIN_HAREKET.Include("STOK").Where(x => x.EFATURAINID == efatura.ID))
                {
                    metin += "<tr>";
                    metin += "<td>" + item.STOKKOD + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.MIKTAR + "</td>";
                    metin += "<td>" + item.BIRIM + "</td>";
                    metin += "<td>" + item.FIYAT + "</td>";
                    if (item.ISKONTO != null)
                        metin += "<td>" + item.ISKONTO + "</td>";
                    else
                        metin += "<td>0</td>";
                    metin += "<td>" + efatura.PARABIRIMI + "</td>";
                    metin += "<td>" + efatura.PARABIRIMIKUR + "</td>";
                    metin += "<td>" + item.TOPLAM + "</td>";
                    metin += "</tr>";
                }

            }

            if (türü == "Alışİrsaliyesi" || türü == "Satışİrsaliyesi")
            {
                metin += "<td>Stok Kodu</td><td>Açıklama</td><td>Miktar</td><td>Birim</td><td>Fiyat</td><td>İskonto</td><td>ParaBirimi</td><td>ParaKuru</td><td>NetTutar</td>";
                metin += "</thead><tbody>";
                var id = db.IRSALIYE.SingleOrDefault(x => x.IRSNO == belgeno).ID;
                foreach (var item in db.IRSALIYE_HAREKET.Include("STOK").Where(x => x.IRSALIYEID == id))
                {
                    metin += "<tr>";
                    metin += "<td>" + item.STOK.STOKKODU + "" + item.STOK.STOKAD + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.MIKTAR + "</td>";
                    metin += "<td>" + item.BIRIM + "</td>";
                    if (item.ISK1 != null)
                        metin += "<td>" + item.ISK1 + "</td>";
                    else
                        metin += "<td>0</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKUR + "</td>";
                    metin += "<td>" + item.KDVTUTARI + "</td>";
                    metin += "</tr>";
                }

            }

            metin += "</tbody></table>";

            db.Dispose();
            return Json(metin, JsonRequestBehavior.AllowGet);





        }

        public string ayrintigetirvoid(string belgeno, string türü)
        {

            var metin = "";

            changestring();

            if (türü == "CariFişi")
            {

                var id = db.CARI_FIS.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.CARI_FIS_HAREKETs.Where(x => x.CARI_FIsID == id))
                {
                    metin += @"<tr colspan=""8"">";
                    metin += "<td>" + item.HAREKET + "</td>";
                    metin += "<td>" + item.PORTFÖYNO + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.TUTAR + "</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKURU + "</td>";
                    metin += "<td>" + item.NETTUTAR + "</td>";
                    metin += "</tr>";
                }

            }
            if (türü == "BankaFişi")
            {

                var id = db.BANKA_FIS.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.BANKA_FIS_HAREKET.Where(x => x.BANKA_FISID == id))
                {
                    metin += @"<tr colspan=""8"">";
                    metin += "<td>" + item.HAREKET + "</td>";
                    metin += "<td>" + item.PORTFÖYNO + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.TUTAR + "</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKURU + "</td>";
                    metin += "<td>" + item.NETTUTAR + "</td>";
                    metin += "</tr>";
                }

            }

            if (türü == "StokFişi")
            {

                var id = db.STOK_FIS.SingleOrDefault(x => x.FISNO == belgeno).ID;
                foreach (var item in db.STOK_FIS_HAREKET.Where(x => x.fisid == id))
                {
                    metin += @"<tr colspan=""8"">";
                    metin += "<td>" + item.STOKKODU + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.BIRIM + "</td>";
                    metin += "<td>" + item.FIYAT + "</td>";
                    metin += "<td>" + item.ISK1 + "</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKUR + "</td>";
                    metin += "<td>" + item.TOPLAMTUTAR + "</td>";
                    metin += "</tr>";
                }

            }
            if (türü == "Fatura")
            {

                var id = db.FATURA.SingleOrDefault(x => x.FATNO == belgeno).ID;
                foreach (var item in db.FATURA_HAREKET.Where(x => x.FATURAID == id))
                {
                    metin += @"<tr colspan=""8"">";
                    metin += "<td>" + item.STOKKODU + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.BIRIM + "</td>";
                    metin += "<td>" + item.FIYAT + "</td>";
                    metin += "<td>" + item.ISK1 + "</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKUR + "</td>";
                    metin += "<td>" + item.KDVTUTARI + "</td>";
                    metin += "</tr>";
                }

            }

            if (türü == "İrsaliye")
            {

                var id = db.IRSALIYE.SingleOrDefault(x => x.IRSNO == belgeno).ID;
                foreach (var item in db.IRSALIYE_HAREKET.Where(x => x.IRSALIYEID == id))
                {
                    metin += @"<tr colspan=""8"">";
                    metin += "<td>" + item.STOKKODU + "</td>";
                    metin += "<td>" + item.ACIKLAMA + "</td>";
                    metin += "<td>" + item.BIRIM + "</td>";
                    metin += "<td>" + item.FIYAT + "</td>";
                    metin += "<td>" + item.ISK1 + "</td>";
                    metin += "<td>" + item.PARABIRIMI + "</td>";
                    metin += "<td>" + item.PARAKUR + "</td>";
                    metin += "<td>" + item.KDVTUTARI + "</td>";
                    metin += "</tr>";
                }

            }


            return metin;





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
