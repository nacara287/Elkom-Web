using And.ElkomMuhasebe.Core.Model;
using And.ElkomMuhasebe.Core.Model.Entity.Admin;
using And.ElkomMuhasebe.Core.Model.Entity.FirmaDB;
using Aspose.Zip;
using Aspose.Zip.Saving;
using ConnectorClientSampleCommon.EdmService;
using CurrentEDMConnectorClientLibrary;


using HizliTestService;
using HizliTestService.HizliService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;

using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.IO;
using System.Text;
using System.Threading;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class FATURAController : Controller
    {
        private FirmaBaseDB db = new FirmaBaseDB();
        private AndDB anddb = new AndDB();
        public int userid = 0;
        public bool ekleme = false;
        public bool degistirme = false;
        public bool silme = false;
        public bool gorme = false;
        public void Disposedb()
        {
            anddb.Dispose();
            db.Dispose();
            base.Dispose(true);
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
                    if (alt.görme.Contains("Faturalar"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Faturalar"))
                            ekleme = true;
                        if (alt.silme.Contains("Faturalar"))
                            silme = true;
                        if (alt.degistir.Contains("Faturalar"))
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
        public string portalurl= "https://portal2.edmbilisim.com.tr/EFaturaEDM/EFaturaEDM.svc";
        public void efaturachangestring()
        {
            if ((Session["LoginUser"] == null || Session["SeciliFirma"] == null) && (Session["LoginAltUser"] == null || Session["SeciliFirma"] == null)) { Response.Redirect("/Home"); }
            else
            {
                if (Session["LoginAltUser"] != null)
                {
                    var alt = Session["LoginAltUser"] as And.ElkomMuhasebe.Core.Model.Entity.Admin.AltUser;
                    userid = alt.ID;
                    if (alt.görme.Contains("E-Faturalar"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("E-Faturalar"))
                            ekleme = true;
                        if (alt.silme.Contains("E-Faturalar"))
                            silme = true;
                        if (alt.degistir.Contains("E-Faturalar"))
                            degistirme = true;

                    }
                    var firmaa = db.FIRMA.FirstOrDefault();
                    if (firmaa.DemoPortal == true)
                        portalurl = "https://test.edmbilisim.com.tr/EFaturaEDM21ea/EFaturaEDM.svc";
                    tester = new EFaturaEDMConnectorLibrary(portalurl);

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
                    var firmaa = db.FIRMA.FirstOrDefault();
                    if(firmaa.DemoPortal==true)
                    portalurl = "https://test.edmbilisim.com.tr/EFaturaEDM21ea/EFaturaEDM.svc";
                    tester = new EFaturaEDMConnectorLibrary(portalurl);
                }
            }
        }
        public class modelimiz
        {
            public int tip { get; set; }
            public int? ID { get; set; }
            public STOK STOK { get; set; }
            public STOK_HAREKET Hareket { get; set; }
            public KUR_BASLIK Kur { get; set; }
            public IEnumerable<CARI_BASLIK> cARI_BASLIKs { get; set; }
            public IEnumerable<CARI_HAREKET> cARI_HAREKETs { get; set; }
            public IEnumerable<STOK> STOKs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<STOK_HAREKET> STOK_HAREKETs { get; set; }
            public IEnumerable<STOK_BIRIM> STOK_BIRIMLERs { get; set; }

            public FATURA FATURA { get; set; }

            public int FATURALAR { get; set; }
            public string cariad { get; set; }
            public string EARSIVSERINO { get; set; }
            public string EFATURASERINO{ get; set; }
            public List<EARSIV_SERI> EARSIVSERINOLAR { get; set; }
            public List<FATURA_SERI> EFATURASERINOLAR { get; set; }
            public string carikod { get; set; }
            public efaturafismodel efatura { get; set; }
            public IEnumerable<EFATURA> EFATURAs { get; set; }

            public IEnumerable<FATURA_HAREKET> FATURA_HAREKETLERİ { get; set; }
            public EFATURAIN EFATURAIN { get; set; }
            public IEnumerable<STOK_DEPO> DEPOs { get; set; }
            public IEnumerable<EFATURAIN_HAREKET> EFATURAIN_HAREKETs { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }

            public IEnumerable<ISTISNAKODLARI> ISTISNAKODLARIs { get; set; }
            public IEnumerable<TEVFIKATKODLARI> TEVFIKATKODLARI { get; set; }
            public IEnumerable<OZELMATRAHKODLARI> OZELMATRAHKODLARI { get; set; }
            public IEnumerable<ESYANINGONDERIMSEKLI> ESYANINGONDERIMSEKLI { get; set; }
            public IEnumerable<ESYANINBULUNDUGUKABINCINSI> ESYANINBULUNDUGUKABINCINSI { get; set; }
            public IEnumerable<TESLIMSARTLARI> TESLIMSARTLARI { get; set; }
            public IEnumerable<ULKELER> ULKELER { get; set; }

        }
        public class FaturaAraViewModel
        {
            public int ID { get; set; }
            
                          public string CARIADI { get; set; }
            public string S_MERKEZI { get; set; }
            
            public string CARIKOD { get; set; }
            public string TARIH { get; set; }
            public string FATNO { get; set; }
            public string TIP { get; set; }
            public string GENELTOPLAM { get; set; }
            public string GIRIS { get; set; }
            public string CIKIS { get; set; }

        }
       [HttpPost]
        public JsonResult efatural(string type, string baslangic, string son)
        {
            efaturachangestring();
            var firma = db.FIRMA.FirstOrDefault();
            DateTime baslangıctarih, sontarih;
            baslangıctarih = DateTime.Parse(baslangic);
            sontarih = DateTime.Parse(son);
            var count = 0;
            if (firma.ENTAGRATOR == FIRMA.entegratorler.EDM)
            {
              

                tester.EDMLogin = db.FIRMA.FirstOrDefault().EFATKULLANICIADI;
                tester.EDMPassw = db.FIRMA.FirstOrDefault().EFATSİFRE;
            
                string sessionid = tester.EDMGetSession();
                EFaturaEDMConnectorLibrary.draftmodelgelen faturalar = tester.GetInvoice(DateTime.Now, DateTime.Now, baslangıctarih, sontarih, false, true, true, "XML", false, limit: 30, direction: "IN");


                if (faturalar.response != null) { 

                foreach (var item in faturalar.response)
                {
                    if (db.EFATURA.Where(x => x.ETTN == item.UUID).ToList().Count == 0)
                    {


                        var efatura = new EFATURA();
                        efatura.ETTN = item.UUID;
                        efatura.FATURANO = item.ID;

                        efatura.GIBFATURATURU = item.HEADER.INVOICE_TYPE;
                        efatura.GONDERIMTURU = item.HEADER.INVOICE_SEND_TYPE;
                        efatura.STATU = item.HEADER.STATUS;
                        efatura.TARIH = item.HEADER.ISSUE_DATE;
                        efatura.S_MERKEZIID = db.SORUMLULUK_MERKEZI.FirstOrDefault().ID;
                        string dir = Server.MapPath("~/EFATURALAR/" + firma.KISAADI.Trim());
                        // If directory does not exist, create it
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }



                        System.IO.File.WriteAllText(Server.MapPath("~/EFATURALAR/" + firma.KISAADI.Trim() + "/" + efatura.FATURANO + "_" + efatura.ETTN + ".xml"), System.Text.Encoding.UTF8.GetString(item.CONTENT.Value));
                        efatura.FATURAURL = Server.MapPath("~/EFATURALAR/" + firma.KISAADI.Trim() + "/" + efatura.FATURANO + "_" + efatura.ETTN + ".xml");
                      
                        var tür = 0;
                        if (type == "IN")
                            tür = 1;
                        if (type == "OUT")
                            tür = 2;


                        var faturaokunmus = faturaoku(System.Text.Encoding.UTF8.GetString(item.CONTENT.Value), tür);
                        efatura.FATURATUTAR = double.Parse(faturaokunmus.ODENCEKTUTAR.Replace(",", "").Replace(".", ","))*double.Parse(faturaokunmus.PARABIRIMIKUR.Replace(",", "").Replace(".", ","));
                        efatura.CARI = db.CARI_BASLIK.Where(x => x.CARIKOD == faturaokunmus.CARIKOD).FirstOrDefault();
                        efatura.CARIID = efatura.CARI.ID;
                        efatura.MUSTERI = efatura.CARI.FIRMAUNVANI;
                        efatura.CreateDate = DateTime.Now;
                        efatura.CreateUserID = userid;
                        efatura.VKN = efatura.CARI.VERGINUMARASI;
                        if (type == "IN")
                        {
                            efatura.TIP = CARI_HAREKET.tip.Giriş;
                        }
                        else
                        {
                            efatura.TIP = CARI_HAREKET.tip.Çıkış;

                        }

                        db.EFATURA.Add(efatura);
                        count += 1;
                        db.SaveChanges();


                        var carihareket = new CARI_HAREKET();

                        carihareket.cari = db.CARI_BASLIK.Find(efatura.CARIID);
                        carihareket.TARIHSAAT = (DateTime)efatura.TARIH;
                        carihareket.TIPI = (CARI_HAREKET.tip)efatura.TIP;
                        if (string.IsNullOrEmpty(efatura.FATURANO))
                            carihareket.ISLEMNO = efatura.ETTN;
                        else { carihareket.ISLEMNO = efatura.FATURANO; }

                        carihareket.CARIKOD = carihareket.cari.CARIKOD;

                        carihareket.ACIKLAMA = "";

                        carihareket.VADE = efatura.TARIH;
                        if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                        {
                            var eskihareket = new CARI_HAREKET();
                            if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == carihareket.cari.CARIKOD).Count() > 0)
                            {
                                eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == carihareket.cari.CARIKOD).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                            }
                            else { eskihareket.BAKIYE = 0; }



                            if (faturaokunmus.PARABIRIMI == carihareket.cari.PARABIRIMI && faturaokunmus.PARABIRIMI != "TRY")
                            {
                    
                                carihareket.cari.TOPLAMALACAK += efatura.FATURATUTAR;
                                carihareket.cari.TOPLAMDOVIZALACAK += double.Parse(faturaokunmus.ODENCEKTUTAR.Replace(".", ","));
                        
                                carihareket.DOVIZALACAK = double.Parse(faturaokunmus.ODENCEKTUTAR.Replace(".", ","));
                                foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == carihareket.cari.CARIKOD))
                                {

                                    hareketz.DOVIZBAKIYE -= double.Parse(faturaokunmus.ODENCEKTUTAR.Replace(".", ","));
                                }
                            }
                            else
                            {
                                carihareket.cari.TOPLAMALACAK += efatura.FATURATUTAR;
                                carihareket.BAKIYE = eskihareket.BAKIYE + efatura.FATURATUTAR;
                                foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == carihareket.cari.CARIKOD))
                                {
                                    hareketz.BAKIYE -= efatura.FATURATUTAR;

                                }
                            }


                            carihareket.ALACAK = efatura.FATURATUTAR;



                        }
                        else
                        {


                            if (faturaokunmus.PARABIRIMI == carihareket.cari.PARABIRIMI && faturaokunmus.PARABIRIMI != "TRY")
                            {
                                carihareket.cari.TOPLAMALACAK += efatura.FATURATUTAR;
                                carihareket.cari.TOPLAMDOVIZALACAK += double.Parse(faturaokunmus.ODENCEKTUTAR.Replace(".", ","));
                                carihareket.DOVIZALACAK = double.Parse(faturaokunmus.ODENCEKTUTAR.Replace(".", ","));
                               
                                carihareket.DOVIZBAKIYE = carihareket.cari.DOVIZBAKIYE;
                            }
                            else
                            {
                                carihareket.cari.TOPLAMALACAK += efatura.FATURATUTAR;


                            }

                            carihareket.ALACAK = efatura.FATURATUTAR;

                        }


                        if (efatura.GONDERIMTURU == "EARSIVFATURA")
                        {
                            carihareket.ISLEMTURU = CARI_HAREKET.tür.EArşiv;
                        }
                        else
                        {
                            carihareket.ISLEMTURU = CARI_HAREKET.tür.EFatura;
                        }
                        
                        carihareket.BAKIYE = carihareket.cari.BAKIYE;
                        carihareket.S_MERKEZIID = 1;
                        carihareket.CreateDate = DateTime.Now;
                        carihareket.CreateUserID = userid;
                        db.CARI_HAREKET.Add(carihareket);
                        db.SaveChanges();


                    }
                }
                }
                else
                {
                    return Json(faturalar.retval);
                }
                db.SaveChanges();
            }
            if (firma.ENTAGRATOR == FIRMA.entegratorler.HizliBilisim)
            {

                HizliServiceClient client = new HizliServiceClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers.Add("username", firma.EFATKULLANICIADI);
                    prop.Headers.Add("password", firma.EFATSİFRE);
                    string DateType = "IssueDate";
                    int AppType = 1;

                    OperationContext context = OperationContext.Current;
                    context.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;
                    var liste = client.GetDocumentList(AppType, DateType, baslangıctarih, sontarih, false, false, false, "ALL");
                    if (liste.IsSucceeded)
                    {
                        var faturalar = liste.documents;

                        foreach (var item in faturalar)
                        {
                            if (db.EFATURA.Where(x => x.ETTN == item.UUID).ToList().Count == 0)
                            {


                                var efatura = new EFATURA();
                                efatura.ETTN = item.UUID;
                                efatura.FATURANO = item.DocumentId;

                                efatura.GIBFATURATURU = item.ProfileId;
                                efatura.GONDERIMTURU = item.DocumentTypeCode;
                                efatura.STATU = item.StatusExp;
                                efatura.TARIH = DateTime.Parse(item.IssueDate);

                                var doc = client.GetDocumentFile(AppType, efatura.ETTN, "XML", false);
                                if (doc.IsSucceeded)
                                {

                                    efatura.FATURAURL = System.Text.Encoding.UTF8.GetString(doc.DocumentFile);

                                }

                                var tür = 0;
                                if (type == "IN")
                                    tür = 1;
                                if (type == "OUT")
                                    tür = 2;


                                var faturaokunmus = faturaoku(efatura.FATURAURL, tür);
                                efatura.FATURATUTAR = double.Parse(faturaokunmus.ODENCEKTUTAR.Replace(",", "").Replace(".", ","));
                                efatura.CARI = db.CARI_BASLIK.Where(x => x.CARIKOD == faturaokunmus.CARIKOD).FirstOrDefault();
                                efatura.CARIID = efatura.CARI.ID;
                                efatura.MUSTERI = efatura.CARI.FIRMAUNVANI;
                                efatura.CreateDate = DateTime.Now;
                                efatura.CreateUserID = userid;
                                efatura.VKN = efatura.CARI.VERGINUMARASI;
                                if (type == "IN")
                                {
                                    efatura.TIP = CARI_HAREKET.tip.Giriş;
                                }
                                else
                                {
                                    efatura.TIP = CARI_HAREKET.tip.Çıkış;

                                }

                                db.EFATURA.Add(efatura);
                                count += 1;
                                db.SaveChanges();


                                var carihareket = new CARI_HAREKET();

                                carihareket.cari = db.CARI_BASLIK.Find(efatura.CARIID);
                                carihareket.TARIHSAAT = (DateTime)efatura.TARIH;
                                carihareket.TIPI = (CARI_HAREKET.tip)efatura.TIP;
                                if (string.IsNullOrEmpty(efatura.FATURANO))
                                    carihareket.ISLEMNO = efatura.ETTN;
                                else { carihareket.ISLEMNO = efatura.FATURANO; }

                                carihareket.CARIKOD = carihareket.cari.CARIKOD;

                                carihareket.ACIKLAMA = "";

                                carihareket.VADE = efatura.TARIH;
                                if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                                {
                                    var eskihareket = new CARI_HAREKET();
                                    if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == carihareket.cari.CARIKOD).Count() > 0)
                                    {
                                        eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == carihareket.cari.CARIKOD).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                                    }
                                    else { eskihareket.BAKIYE = 0; }



                                    if (faturaokunmus.PARABIRIMI == carihareket.cari.PARABIRIMI && faturaokunmus.PARABIRIMI != "TRY")
                                    {

                                        carihareket.cari.TOPLAMALACAK += efatura.FATURATUTAR;
                                        carihareket.DOVIZBORC = efatura.FATURATUTAR;
                                     
                                        carihareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE + efatura.FATURATUTAR;
                                        foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == carihareket.cari.CARIKOD))
                                        {

                                            hareketz.DOVIZBAKIYE -= efatura.FATURATUTAR;
                                        }
                                    }
                                    else
                                    {
                                        carihareket.cari.TOPLAMALACAK += efatura.FATURATUTAR;
                                        carihareket.BAKIYE = eskihareket.BAKIYE + efatura.FATURATUTAR;
                                        foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == carihareket.cari.CARIKOD))
                                        {
                                            hareketz.BAKIYE -= efatura.FATURATUTAR;

                                        }
                                    }


                                    carihareket.ALACAK = efatura.FATURATUTAR;



                                }
                                else
                                {


                                    if (faturaokunmus.PARABIRIMI == carihareket.cari.PARABIRIMI && faturaokunmus.PARABIRIMI != "TRY")
                                    {

                                        carihareket.cari.TOPLAMDOVIZALACAK += efatura.FATURATUTAR;
                                        carihareket.DOVIZBORC = efatura.FATURATUTAR;
                                       
                                        carihareket.DOVIZBAKIYE = carihareket.cari.DOVIZBAKIYE;
                                    }
                                    else
                                    {
                                        carihareket.cari.TOPLAMALACAK += efatura.FATURATUTAR;
                                     
                                    }

                                    carihareket.ALACAK = efatura.FATURATUTAR;

                                }


                                if (efatura.GONDERIMTURU == "EARSIVFATURA")
                                {
                                    carihareket.ISLEMTURU = CARI_HAREKET.tür.EArşiv;
                                }
                                else
                                {
                                    carihareket.ISLEMTURU = CARI_HAREKET.tür.EFatura;
                                }
                                carihareket.BAKIYE = carihareket.cari.BAKIYE;
                                carihareket.S_MERKEZIID = 1;
                                carihareket.CreateDate = DateTime.Now;
                                carihareket.CreateUserID = userid;
                                db.CARI_HAREKET.Add(carihareket);
                                db.SaveChanges();


                            }
                        }
                    }
                    else
                    {
                        count = -1;
                    }

                }
            }
            Disposedb();
            return Json( count, JsonRequestBehavior.AllowGet);
        }
          [HttpPost]
public JsonResult efaturagoruntulePDF(string uuid)
             {
                 efaturachangestring();
                 var tester = new EFaturaEDMConnectorLibrary(portalurl);

                 tester.EDMLogin = db.FIRMA.FirstOrDefault().EFATKULLANICIADI;
                 tester.EDMPassw = db.FIRMA.FirstOrDefault().EFATSİFRE;
                 if (System.IO.File.Exists(Path.Combine(@"C:\inetpub\wwwroot\assets\EFATURALAR\" + uuid + ".pdf")))
                 {
                Disposedb();
                return Json(uuid + ".pdf", JsonRequestBehavior.AllowGet);

                 }
                 else { 
                 var faturalar = tester.GetInvoice(DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, false, false,downloadcontent:true, contenttype: "PDF", faturano: uuid,direction:"IN");

                     var extension = ".pdf";

                    System.IO.File.WriteAllBytes(Path.Combine(@"C:\inetpub\wwwroot\assets\EFATURALAR\", faturalar.response.First().ID + extension), faturalar.response.First().CONTENT.Value);
                Disposedb();
                return Json(faturalar.response.First().ID+extension, JsonRequestBehavior.AllowGet);
                 }
             }
        [HttpPost]
        public JsonResult stokeslepost(efaturafismodel fatura)
        {
            efaturachangestring();
            
            foreach (var item in fatura.gelenhareket)
            {
                double tutar = 0;

                tutar = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));

                if (item.STOKKOD == "Yeni")
                {
                    var stoka = new STOK();
                  

                }
                if (!string.IsNullOrEmpty(item.STOKKOD)) { 
                var stok = db.STOK.Where(x => x.STOKKODU == item.STOKKOD).FirstOrDefault();
                var stokhareket = new STOK_HAREKET();
                stok.ESLEME_ISIMLERI += ","+item.MALHIZMET.Trim();
                stokhareket.STOK = stok;
                stokhareket.STOKKODU = stokhareket.STOK.STOKKODU;
                stokhareket.CARI = db.CARI_BASLIK.Where(x => x.CARIKOD == fatura.CARIKOD).FirstOrDefault();
                stokhareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMADI == item.BIRIM).FirstOrDefault().ID;
                stokhareket.CreateDate = DateTime.Now;
                stokhareket.CreateUserID = userid;
                stokhareket.BELGENO = fatura.FISNO;

                stokhareket.TARIH = DateTime.Parse(fatura.TARIH);
                stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.EFatura;
                stokhareket.MIKTAR = double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                stokhareket.FIYAT = double.Parse(item.FIYAT.Replace(",", "").Replace(".", ","));
                stokhareket.TIPI = fatura.TIPI;
                stokhareket.PARABIRIMI = fatura.PARABIRIMI;
                stokhareket.PARAKUR = double.Parse(fatura.PARABIRIMIKUR.Replace(".", ","));
                if (DateTime.Now.CompareTo(stokhareket.TARIH.Add(new TimeSpan(2, 0, 0))) > 0)
                {
                    var eskihareket = new STOK_HAREKET();
                    if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).Count() > 0)
                    {
                        eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).OrderBy(x => x.TARIH).FirstOrDefault();


                    }
                    else { eskihareket.STOKMIKTAR = 0; }

                    stok.MIKTAR += stokhareket.MIKTAR;
                    stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR - (float)stokhareket.MIKTAR;
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
                stokhareket.TUTAR = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
              //  stokhareket.SONMALIYET = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));



                stokhareket.S_MERKEZIID = 1;
                stokhareket.ACIKLAMA = fatura.NOT;


                db.STOK_HAREKET.Add(stokhareket);


                db.SaveChanges();
                }
            }
            db.EFATURA.Where(x => x.ETTN == fatura.UUID).FirstOrDefault().STOKESLENDI = true;
            db.SaveChanges();
            Disposedb();
            return Json("Başarılı", JsonRequestBehavior.AllowGet);

        }

        public class rapor {

            public List<ay> aylar {get;set;}


}
        public class ay
        {

            public string adı { get; set; }
            public double satistutari { get; set; }
            public double maliyet { get; set; }
            public double burukar { get; set; }
            public double hizmetvadefark { get; set; }
            public double genel { get; set; }
            public double personel { get; set; }
            public double giderlertoplamı { get; set; }
            public double netkaryuzde { get; set; }
            public double netkar { get; set; }


        }

        public ActionResult aylaragoremaliyet()
        {
            changestring();
            var rapor = new rapor();
            rapor.aylar = new List<ay>();
            for (int i = 1;i< 13; i++) {
                var ay = new ay();
                ay.adı = aydon(i);
                if (db.EFATURA.Where(x => x.TARIH.Value.Month == i && x.TIP == CARI_HAREKET.tip.Çıkış).Count() > 0)
                    ay.satistutari = (double)db.EFATURA.Where(x => x.TARIH.Value.Month == i && x.TIP == CARI_HAREKET.tip.Çıkış).Sum(X => X.FATURATUTAR);
                else
                    ay.satistutari = 0;
                if (db.GELIR_BORDRO_HAREKET.Where(x => x.CreateDate.Month == i ).Count() > 0)
                    ay.hizmetvadefark = (double)db.GELIR_BORDRO_HAREKET.Where(x => x.CreateDate.Month == i).Sum(X => X.TUTARI);
                else
                    ay.hizmetvadefark = 0;
                if (db.GIDER_BORDRO_HAREKET.Where(x => x.CreateDate.Month == i).Count() > 0)
                    ay.giderlertoplamı = (double)db.GIDER_BORDRO_HAREKET.Where(x => x.CreateDate.Month == i).Sum(X => X.TUTARI);
                else
                    ay.giderlertoplamı = 0;
                if (db.EFATURA.Where(x => x.TARIH.Value.Month == i && x.TIP == CARI_HAREKET.tip.Çıkış).Count() > 0)
                {
                    var efaturalar = db.EFATURA.Where(x => x.TARIH.Value.Month == i && x.TIP == CARI_HAREKET.tip.Çıkış).ToList();
                    foreach(var item in efaturalar)
                    {
                        var efaturain = db.EFATURAIN.Where(x => x.EFATURAID == item.ID).FirstOrDefault();
                        var efaturainhareketleri = db.EFATURAIN_HAREKET.Where(x => x.EFATURAINID == item.ID).ToList();
                        foreach(var hareket in efaturainhareketleri)
                        {
                            var stok = db.STOK.Find(hareket.MALHIZMET);
                            ay.maliyet +=(double) stok.MALIYETORT *double.Parse( hareket.MIKTAR.Replace(".",","));
                        }


                    }

                }
                    
          
               ay.burukar = ay.satistutari - ay.maliyet;
                if (db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.Month == i && x.TIPI == CARI_HAREKET.tip.Giriş).Count() > 0)
                    ay.personel = (double)db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.Month == i && x.TIPI==CARI_HAREKET.tip.Giriş).Sum(x => x.BORC);
                else
                    ay.personel = 0;
             
             
                  
    
                ay.netkar = ay.burukar - ay.personel;
                rapor.aylar.Add(ay);

            }
            return View(rapor);
        }
        public string aydon(int ay)
        {
            switch (ay)
            {
                case 1:return "OCAK";
                case 2: return "ŞUBAT";
                case 3: return "MART";
                case 4: return "NİSAN";
                case 5: return "MAYIS";
                case 6: return "HAZİRAN";
                case 7: return "TEMMUZ";
                case 8: return "AGUSTOS";
                case 9: return "EYLUL";
                case 10: return "EKİM";
                case 11: return "KASIM";
                case 12: return "ARALIK";

            }
            return "OCAK";
        }
        public class stokeslenenler
        {
 
            public IEnumerable<STOK> sTOKs { get; set; }
            public EFATURA EFATURA { get; set; }



        }
    
        public ActionResult stokesle(int id)
        {
            efaturachangestring();
            var fatura = db.EFATURA.Find(id);
            var efaturafismodel = new efaturafismodel();
            
            XDocument doc = XDocument.Load(fatura.FATURAURL);
            var cbc = "{urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2}";
            var cac = "{urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2}";
            var doncek = new efaturafismodel();
            doncek.GONDERIMSEKLI = fatura.GONDERIMTURU;
           
            foreach (XElement el in doc.Root.Elements())
            {
                if (el.Name == cbc + "ProfileID")
                    doncek.GONDERIMSENARYO = el.Value;
                if (el.Name == cbc + "ID")
                    doncek.FISNO = el.Value;
                if (el.Name == cbc + "UUID")
                    doncek.UUID = el.Value;
                if (el.Name == cbc + "IssueDate")
                    doncek.TARIH = el.Value;
                if (el.Name == cbc + "InvoiceTypeCode")
                    doncek.GONDERIMTIPI = el.Value;
                if (el.Name == cbc + "Note")
                    doncek.NOT = el.Value;
                if (el.Name == cbc + "DocumentCurrencyCode")
                    doncek.PARABIRIMI = el.Value;
                if(el.Name == cbc+ "CalculationRate")
                {
                    doncek.PARABIRIMIKUR = el.Value;
                }
                if (el.Name == cac + "InvoiceLine")
                {
                    var yenistok = new STOK();
                    var hareket = new efaturamodelhareket();
                    yenistok.KDVDAHIL = 0;
                        

                    foreach (XElement element in el.Elements())
                    {
                        if (element.Name == cbc + "InvoicedQuantity")
                        {
                            hareket.MIKTAR = element.Value;
                            string kod = element.Attributes().First().Value;
                            if(anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU==kod).ToList().Count>0)
                            hareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU==kod).First().BIRIMADI;
                            else
                            {
                                if (anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU == kod).ToList().Count > 0)
                                    hareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU == kod).First().BIRIMADI;
                                else
                                {
                                    hareket.BIRIM = anddb.STOK_BIRIMLER.FirstOrDefault().BIRIMADI;
                                }

                            }
                            if (anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU == kod).ToList().Count > 0)
                                yenistok.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU == kod).First().ID;
                            else
                                yenistok.BIRIM = anddb.STOK_BIRIMLER.FirstOrDefault().ID;
                        }
                        if (element.Name == cbc + "LineExtensionAmount")
                        {
                            hareket.TOPLAM = element.Value;

                        }
                        if (element.Name == cac + "AllowanceCharge")
                        {

                            hareket.ISKONTO = element.Elements().Where(x => x.Name == cbc + "MultiplierFactorNumeric").FirstOrDefault().Value;
                            hareket.ISKONTO = hareket.ISKONTO.Replace("0.", "");

                            hareket.ISKONTOTUTAR = element.Elements().Where(x => x.Name == cbc + "Amount").FirstOrDefault().Value;
                            yenistok.ALISISKONTOSU = double.Parse(hareket.ISKONTO.Replace(",", "").Replace(".", ","));

                        }
                        if (element.Name == cac + "TaxTotal")
                        {
                            hareket.KDVTUTAR = element.Elements().First().Value;
                            foreach (XElement item in element.Elements().Where(x => x.Name == cac + "TaxSubtotal").Elements())
                            {
                                if (item.Name == cbc + "TaxAmount")
                                    hareket.KDVTUTAR = item.Value;
                                if (item.Name == cbc + "Percent")
                                {
                                    hareket.KDVORANI = item.Value;
                                    yenistok.KDV = Convert.ToInt32 (float.Parse(hareket.KDVORANI.Replace(",", "").Replace(".", ",")));
                                }


                            }
                        }
                        if (element.Name == cac + "WithholdingTaxTotal")
                        {
                            foreach (XElement item in element.Elements().Where(x => x.Name == cac + "TaxSubtotal").Elements())
                            {
                                if (item.Name == cbc + "TaxAmount")
                                    hareket.TEVFIKATTUTAR = item.Value;
                                if (item.Name == cbc + "Percent")
                                    hareket.TEVFIKATORAN = item.Value;
                                if (item.Name == cac + "TaxCategory")
                                    hareket.TEVFIKAT = item.Elements().FirstOrDefault().Elements().Where(x => x.Name == cbc + "Name").FirstOrDefault().Value;
                            }
                        }
                        if (element.Name == cac + "Item")
                        {
                            hareket.MALHIZMET = element.Elements().Where(x => x.Name == cbc + "Name").First().Value;
                            if (db.STOK.Where(X => X.STOKAD.ToLower().Trim() == hareket.MALHIZMET.ToLower().Trim() || X.STOKKODU.ToLower().Trim() == hareket.MALHIZMET.ToLower().Trim()||X.ESLEME_ISIMLERI.Trim().ToLower().Contains(hareket.MALHIZMET.Trim().ToLower())).ToList().Count == 0)
                            {
                                hareket.STOKKOD = "";
                                 doncek.gelenhareket.Add(hareket);
                              
                            }
                            else
                            {
                                hareket.STOKKOD = db.STOK.Where(X => X.STOKAD.ToLower().Trim() == hareket.MALHIZMET.ToLower().Trim() || X.STOKKODU.ToLower().Trim() == hareket.MALHIZMET.ToLower().Trim() || X.ESLEME_ISIMLERI.Trim().ToLower().Contains(hareket.MALHIZMET.Trim().ToLower())).First().STOKKODU;
                                doncek.gelenhareket.Add(hareket);
                            }


                        }
                        if (element.Name == cac + "Price")
                        {
                            hareket.FIYAT = element.Elements().First().Value;
                            yenistok.HAMALISFIYAT = double.Parse(hareket.FIYAT.Replace(",", "").Replace(".", ","));
                        }

                    }

               

                }
            }
            if (doncek.PARABIRIMIKUR == null)
                doncek.PARABIRIMIKUR = "1";
            doncek.CARIKOD = db.CARI_BASLIK.Find(fatura.CARIID).CARIKOD;
            doncek.TIPI = (CARI_HAREKET.tip)fatura.TIP;
            
            if (ekleme == true)
            {
                return View(doncek);
            }
            else
            {
                return Redirect("/Home");
            }
         

        }
         [HttpPost]
            public JsonResult efaturaindir(string[] uuid)
        {
            efaturachangestring();
            var tester = new EFaturaEDMConnectorLibrary(portalurl);
            
            tester.EDMLogin = db.FIRMA.FirstOrDefault().EFATKULLANICIADI;
            tester.EDMPassw = db.FIRMA.FirstOrDefault().EFATSİFRE;
            foreach(var item in uuid) {
                if (System.IO.File.Exists(Path.Combine(@"C:\inetpub\wwwroot\assets\EFATURALAR\"+item+".pdf"))) {
                    System.IO.File.Delete(Path.Combine(@"C:\inetpub\wwwroot\assets\EFATURALAR\" + item + ".pdf"));
                }
             //   var faturalar = tester.GetInvoice(DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, false, false,contenttype:"PDF",faturano:item);
            
           var extension = ".pdf";
             
         //  System.IO.File.WriteAllBytes(Path.Combine(@"C:\inetpub\wwwroot\assets\EFATURALAR\", faturalar.First().ID + extension), faturalar.First().CONTENT.Value);
              
            }
            Disposedb();
            return Json(uuid, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult efaturayazdır(int ida)
        {
            efaturachangestring();
            
            var firma = db.FIRMA.FirstOrDefault();
            tester.EDMLogin = db.FIRMA.FirstOrDefault().EFATKULLANICIADI;
            tester.EDMPassw = db.FIRMA.FirstOrDefault().EFATSİFRE;
            var efatura = db.EFATURA.Include(x=>x.CARI).Where(x=>x.ID==ida).FirstOrDefault();
            var stringler = new string[1];
            stringler[0] = System.IO.File.ReadAllText(efatura.FATURAURL);
            var gelenefatura = db.EFATURAIN.Include(x=>x.Hareketler).Where(x => x.EFATURAID == efatura.ID).FirstOrDefault();
            var cari = db.CARI_BASLIK.Find(efatura.CARIID);
            var trans = db.Database.BeginTransaction();
            try
            {
                var cevap = Win_SendInvoice(efatura.ETTN, stringler, 1, false, invoiceID: efatura.FATURANO, efatura.CARI.gibpk, firma.GIBBK, "", "", false);

                efatura.STATU = "Gönderildi!";
                db.SaveChanges();

                var carihareket = new CARI_HAREKET();

                carihareket.cari =cari;
                carihareket.TARIHSAAT = (DateTime)efatura.TARIH;
                carihareket.TIPI = (CARI_HAREKET.tip)efatura.TIP;
                if (string.IsNullOrEmpty(efatura.FATURANO))
                    carihareket.ISLEMNO = efatura.ETTN;
                else { carihareket.ISLEMNO = efatura.FATURANO; }

                carihareket.CARIKOD = carihareket.cari.CARIKOD;

                carihareket.ACIKLAMA = "";

                carihareket.VADE = efatura.TARIH;
                if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                {
                    var eskihareket = new CARI_HAREKET();
                    if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).Count() > 0)
                    {
                        eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                    }
                    else { eskihareket.BAKIYE = 0; }



                    carihareket.TIPI = CARI_HAREKET.tip.Çıkış;
                    carihareket.BORC = efatura.FATURATUTAR;
                    carihareket.DOVIZBORC = (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".",",")));
                    cari.TOPLAMDOVIZBORC += (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ",")));
                    cari.TOPLAMBORC += carihareket.BORC;
                    carihareket.BAKIYE = eskihareket.BAKIYE - efatura.FATURATUTAR;
                    carihareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE - (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ","))); ;
                    foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                    {
                        hareketz.BAKIYE -= efatura.FATURATUTAR;
                        hareketz.DOVIZBAKIYE -= carihareket.DOVIZALACAK;
                    }




                }
                else
                {

                    carihareket.TIPI = CARI_HAREKET.tip.Çıkış;
                    carihareket.BORC = efatura.FATURATUTAR;
                    carihareket.DOVIZBORC = (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ",")));
                    cari.TOPLAMDOVIZBORC += (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ",")));
                    cari.TOPLAMBORC += carihareket.BORC;
                    carihareket.BAKIYE = cari.TOPLAMBORC - cari.TOPLAMALACAK;
                    carihareket.DOVIZBAKIYE = cari.TOPLAMDOVIZBORC - cari.TOPLAMDOVIZALACAK;


                }


                if (efatura.GONDERIMTURU == "EARSIVFATURA")
                {
                    carihareket.ISLEMTURU = CARI_HAREKET.tür.EArşiv;
                }
                else
                {
                    carihareket.ISLEMTURU = CARI_HAREKET.tür.EFatura;
                }
                carihareket.BAKIYE = carihareket.cari.BAKIYE;
                carihareket.S_MERKEZIID = efatura.S_MERKEZIID;
                carihareket.CreateDate = DateTime.Now;
                carihareket.CreateUserID = userid;
                db.CARI_HAREKET.Add(carihareket);
                db.SaveChanges();
               foreach( var item in gelenefatura.Hareketler)
                {
                    if (item.GELIRGIDER == 1)
                    {
                        var gelirhareket = new GELIR_BORDRO_HAREKET();
                        var gelirid = int.Parse(item.STOKKOD);
                        var gelir = db.GELIR_BASLIK.Find(gelirid);
                        gelirhareket.GELIR_BASLIK = gelir;
                        gelirhareket.GELIR_BASLIKKID = gelirid;
                        gelirhareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
                        gelirhareket.PARABIRIMI = gelenefatura.PARABIRIMI;
                        gelirhareket.ACIKLAMA = gelenefatura.NOT;
                        gelirhareket.FISNO = gelenefatura.FISNO;
                        gelirhareket.S_MERKEZIID = gelenefatura.S_MERKEZIID;
                        gelirhareket.CreateDate = DateTime.Now;
                        gelirhareket.CreateUserID = userid;
                        gelirhareket.PARAKUR = double.Parse(gelenefatura.PARABIRIMIKUR.Replace(".", ","));
                        gelirhareket.TUTARI = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                        gelir.TOPLAMTUTAR += gelirhareket.TUTARI;
                        db.GELIR_BORDRO_HAREKET.Add(gelirhareket);
                    }
                    else if (item.GELIRGIDER == 2)
                    {
                        var giderhareket = new GIDER_BORDRO_HAREKET();
                        var giderid = int.Parse(item.STOKKOD);
                        var gider = db.GIDER_BASLIK.Find(giderid);
                        giderhareket.GIDER_BASLIK = gider;
                        giderhareket.GIDER_BASLIKID = giderid;
                        giderhareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
                        giderhareket.PARABIRIMI = gelenefatura.PARABIRIMI;
                        giderhareket.ACIKLAMA = gelenefatura.NOT;
                        giderhareket.FISNO = gelenefatura.FISNO;
                        giderhareket.S_MERKEZIID = gelenefatura.S_MERKEZIID;
                        giderhareket.CreateDate = DateTime.Now;
                        giderhareket.CreateUserID = userid;
                        giderhareket.PARAKUR = double.Parse(gelenefatura.PARABIRIMIKUR.Replace(".", ","));
                        giderhareket.TUTARI = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                        gider.TOPLAMTUTAR += giderhareket.TUTARI;
                        db.GIDER_BORDRO_HAREKET.Add(giderhareket);
                    }
                    else
                    {
                        var stokid = item.MALHIZMET;
                        var stok = db.STOK.Where(x => x.ID == stokid).FirstOrDefault();
                        var stokhareket = new STOK_HAREKET();
                        stokhareket.STOK = stok;

                        stokhareket.STOKKODU = stokhareket.STOK.STOKKODU;
                        stokhareket.CARIID = cari.ID;
                        stokhareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMADI == item.BIRIM).FirstOrDefault().ID;
                        stokhareket.CreateDate = DateTime.Now;
                        stokhareket.CreateUserID = userid;
                        stokhareket.KUR_FIYAT = double.Parse(gelenefatura.PARABIRIMIKUR.Replace(".", ","));
                        stokhareket.BELGENO = gelenefatura.FISNO;
                        stokhareket.TARIH = DateTime.Parse(gelenefatura.TARIH);
                        stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.Fatura;
                        stokhareket.MIKTAR = double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                        stokhareket.FIYAT = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                        stokhareket.TIPI = gelenefatura.TIPI;
                        stokhareket.PARABIRIMI = gelenefatura.PARABIRIMI;
                        stokhareket.PARAKUR = double.Parse(gelenefatura.PARABIRIMIKUR.Replace(".", ","));
                        stokhareket.TUTAR = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                        stokhareket.TL_TUTAR = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ",")) +( (double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","))*stok.KDV)/100);
                        stokhareket.DOVIZ_TUTAR = stokhareket.TL_TUTAR* stokhareket.KUR_FIYAT;
                        stokhareket.DEPOSUID = item.DEPOID;
                        if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                        {
                            var eskihareket = new STOK_HAREKET();
                            if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                            {
                                eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).OrderByDescending(x => x.TARIH).FirstOrDefault();


                            }
                            else
                            {
                                eskihareket.STOKMIKTAR = 0;
                                eskihareket.STOKMIKTAR_GIREN = 0;
                                eskihareket.TL_STOKALIS_TOPLAM = 0;
                                eskihareket.DOVIZ_STOKALIS_TOPLAM = 0;
                            }
                            if (gelenefatura.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                stok.MIKTAR += stokhareket.MIKTAR;
                                stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR + (float)stokhareket.MIKTAR;
                                stokhareket.STOKMIKTAR_GIREN = eskihareket.STOKMIKTAR_GIREN + (float)stokhareket.MIKTAR;
                                stokhareket.TL_STOKALIS_TOPLAM = eskihareket.TL_STOKALIS_TOPLAM + (float)stokhareket.TUTAR;
                                stokhareket.DOVIZ_STOKALIS_TOPLAM = eskihareket.DOVIZ_STOKALIS_TOPLAM + (float)(stokhareket.TUTAR * stokhareket.KUR_FIYAT);
                                foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU).ToList())
                                {
                                    hareketz.STOKMIKTAR += (float)stokhareket.MIKTAR;

                                    hareketz.TL_STOKALIS_TOPLAM += stokhareket.TUTAR;
                                    hareketz.DOVIZ_STOKALIS_TOPLAM += stokhareket.TUTAR * stokhareket.KUR_FIYAT;
                                    hareketz.STOKMIKTAR_GIREN += (float)stokhareket.MIKTAR;
                                    db.Entry(hareketz).State = EntityState.Modified;
                                    db.SaveChanges();
                                }
                            }
                            else
                            {
                                stok.MIKTAR -= stokhareket.MIKTAR;
                                stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR - (float)stokhareket.MIKTAR;
                                foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU))
                                {
                                    hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;

                                }
                            }


                        }
                        else
                        {
                            if (gelenefatura.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                stok.MIKTAR += stokhareket.MIKTAR;
                                stokhareket.STOKMIKTAR_GIREN = (float)stok.MIKTAR;

                                stokhareket.TL_STOKALIS_TOPLAM = stok.TL_ALIS_TOPLAM;
                                stokhareket.DOVIZ_STOKALIS_TOPLAM = stok.DOVIZ_ALIS_TOPLAM;
                            }
                            else
                            {
                                stokhareket.TL_STOKALIS_TOPLAM = stok.TL_ALIS_TOPLAM;
                                stokhareket.DOVIZ_STOKALIS_TOPLAM = stok.DOVIZ_ALIS_TOPLAM;
                                stok.MIKTAR -= stokhareket.MIKTAR;

                            }
                            stokhareket.STOKMIKTAR = float.Parse(stok.MIKTAR.ToString());
                        }

                        //stokhareket.SONMALIYET = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));

                        if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                        {
                            if (stok.KDVDAHIL == 0)
                            {
                                stok.HAMALISFIYAT = stokhareket.FIYAT;
                            }
                            else
                            {
                                stok.HAMALISFIYAT = stokhareket.FIYAT + ((stokhareket.FIYAT * (int)stok.KDV) / 100);

                            }
                            stok.TOPGIREN += double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                            var tutara = stokhareket.TL_TUTAR;



                            stok.TL_ALIS_TOPLAM += tutara;
                            stok.DOVIZ_ALIS_TOPLAM += tutara / stokhareket.KUR_FIYAT;



                        }
                        else
                        {
                            if (stok.KDVDAHIL == 0)
                            {
                                stok.HAMALISFIYAT = stokhareket.FIYAT;
                            }
                            else
                            {
                                stok.HAMALISFIYAT = stokhareket.FIYAT + ((stokhareket.FIYAT * (int)stok.KDV) / 100);

                            }

                            stok.TOPCIKAN += double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                        }

                        stokhareket.ACIKLAMA = item.ACIKLAMA;
                      
                           //stokhareket.SONMALIYET = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));

                        stokhareket.S_MERKEZIID = gelenefatura.S_MERKEZIID;


                        stokhareket.ACIKLAMA = gelenefatura.NOT;
                        db.STOK_HAREKET.Add(stokhareket);

                        if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                        {
                            if (stok.KDVDAHIL == 0)
                            {
                                stok.HAMALISFIYAT = stokhareket.FIYAT;
                            }
                            else
                            {
                                stok.HAMALISFIYAT = stokhareket.FIYAT + ((stokhareket.FIYAT * (int)stok.KDV) / 100);

                            }

                            stok.TOPGIREN += double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));

                            //stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();

                        }
                        else
                        {
                            if (stok.KDVDAHIL == 0)
                            {
                                stok.HAMALISFIYAT = stokhareket.FIYAT;
                            }
                            else
                            {
                                stok.HAMALISFIYAT = stokhareket.FIYAT + ((stokhareket.FIYAT * (int)stok.KDV) / 100);

                            }


                            stok.TOPCIKAN += double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));

                        }

                        var depotoplam = db.STOK_DEPO_TOPLAM.Where(x => x.DEPOSUID == item.DEPOID).Where(x => x.STOKID == stok.ID).FirstOrDefault();
                        if (depotoplam == null)
                        {
                            var stoktoplam = new STOK_DEPO_TOPLAM();
                            stoktoplam.CreateDate = DateTime.Now;
                            stoktoplam.CreateUserID = 1;
                            stoktoplam.STOKID = stok.ID;
                            if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                stoktoplam.MIKTAR = stokhareket.MIKTAR;
                            }
                            else
                            {
                                stoktoplam.MIKTAR = stokhareket.MIKTAR;

                            }

                            stoktoplam.DEPOSUID = item.DEPOID;
                            db.STOK_DEPO_TOPLAM.Add(stoktoplam);

                        }
                        else
                        {
                            if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                if (depotoplam.MIKTAR == null)
                                    depotoplam.MIKTAR = stokhareket.MIKTAR;
                                depotoplam.MIKTAR += stokhareket.MIKTAR;
                            }
                            else
                            {
                                if (depotoplam.MIKTAR == null)
                                    depotoplam.MIKTAR = stokhareket.MIKTAR;
                                depotoplam.MIKTAR -= stokhareket.MIKTAR;

                            }

                        }


                    }


                }
                if (gelenefatura.IRSALIYELERARRAY != null)
                {
                    var aray = gelenefatura.IRSALIYELERARRAY.Split(',');
                    var res = 0;
                    if (aray.Length > 0)
                        foreach (var idac in aray)
                        {
                            if (int.TryParse(idac, out res))
                            {
                                var id = int.Parse(idac);
                                var fis = db.IRSALIYE.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();



                                var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.IRSNO && x.deleted != 1).ToList();


                                var caria = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();
                                foreach (var item in gelenefatura.Hareketler)
                                {
                                    if (item.REFERANSNO == fis.IRSNO)
                                        db.IRSALIYE_HAREKET.Find(item.REFERANSID).KULLANIMDA = 1;


                                }

                                db.SaveChanges();

                                var fishareketleri = db.IRSALIYE_HAREKET.Where(x => x.IRSALIYEID == id && x.deleted != 1);

                                var kullanılanlar = 0;
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
                                        if (fis.TIP == 1)
                                        {



                                            stok.MIKTAR -= stokhareket.MIKTAR;


                                            foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1))
                                            {
                                                hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;


                                            }
                                            db.SaveChanges();
                                        }
                                        else
                                        {


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
                                        if (fis.TIP == 1)
                                        {


                                            stok.MIKTAR -= stokhareket.MIKTAR;

                                            db.SaveChanges();
                                        }
                                        else
                                        {


                                            stok.MIKTAR += stokhareket.MIKTAR;



                                            db.SaveChanges();


                                        }

                                    }
                                    item.deleted = 1;
                                    db.SaveChanges();
                                }

                                foreach (var item in fishareketleri)
                                {
                                    if (item.KULLANIMDA == 1)
                                        kullanılanlar += 1;


                                }
                                if (kullanılanlar == 0)
                                {
                                    fis.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;
                                }
                                else
                                {
                                    if (fishareketleri.Count() == kullanılanlar)
                                    {
                                        fis.DURUM = IRSALIYE.drumlar.Faturalaştırıldı;
                                    }
                                    else if (fishareketleri.Count() > kullanılanlar)
                                    {
                                        fis.DURUM = IRSALIYE.drumlar.KısmenFaturalaştırıldı;
                                    }
                                }



                                var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.IRSNO && x.deleted != 1);
                                foreach (var item in stokhareketlerii)
                                {

                                    item.deleted = 1;

                                }
                                var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.IRSNO && x.deleted != 1);
                                foreach (var item in cariharetlerii)
                                {

                                    item.deleted = 1;

                                }

                                db.SaveChanges();
                            }


                        }
                }
        
                if (gelenefatura.SIPARISLERARRAY != null)
                {
                    var aray = gelenefatura.SIPARISLERARRAY.Split(',');
                    var res = 0;
                    if (aray.Length > 0)
                        foreach (var idac in aray)
                        {
                            if (int.TryParse(idac, out res))
                            {
                                var id = int.Parse(idac);
                                var fis = db.SIPARIS_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();


                                
                                var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.SIPARISNO && x.deleted != 1).ToList();


                                var caria = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();
                                foreach (var item in gelenefatura.Hareketler)
                                {
                                    if (item.REFERANSNO == fis.SIPARISNO)
                                        db.SIPARIS_FIS_HAREKET.Find(item.REFERANSID).KULLANIMDA = 1;


                                }

                                db.SaveChanges();

                                var fishareketleri = db.SIPARIS_FIS_HAREKET.Where(x => x.SIPARIS_FISID == id && x.deleted != 1);

                                var kullanılanlar = 0;
                          

                                foreach (var item in fishareketleri)
                                {
                                    if (item.KULLANIMDA == 1)
                                        kullanılanlar += 1;


                                }
                                if (kullanılanlar == 0)
                                {
                                    fis.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;
                                }
                                else
                                {
                                    if (fishareketleri.Count() == kullanılanlar)
                                    {
                                        fis.DURUM = IRSALIYE.drumlar.Faturalaştırıldı;
                                        fis.ONAYLANDI= true;
                                    }
                                    else if (fishareketleri.Count() > kullanılanlar)
                                    {
                                        fis.DURUM = IRSALIYE.drumlar.KısmenFaturalaştırıldı;
                                    }
                                }




                                db.SaveChanges();
                            }


                        }
                }

                db.SaveChanges();

                trans.Commit();
                Disposedb();
                return Json("Başarılı", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Disposedb();
                return Json("Başarısız! "+ex.Message+ex.InnerException+ex.Source);
            }
           
        }
        [HttpPost]
        public JsonResult fissil(int id)
        {
            changestring();
          

            var fis = db.FATURA.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.FATURA_HAREKET.Where(x => x.FATURAID == id && x.deleted != 1).ToList();

            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FATNO && x.deleted != 1).ToList();
            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FATNO && x.deleted != 1).ToList();
            var gelirhareketri = new List<GELIR_BORDRO_HAREKET>();
            var giderhareketleri = new List<GIDER_BORDRO_HAREKET>();
            var cari = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();
            if (fis.TIP == 1)
            {
                giderhareketleri = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FATNO && x.deleted != 1).ToList();
            }
            else
            {
                gelirhareketri = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FATNO && x.deleted != 1).ToList();
            }

            var trans = db.Database.BeginTransaction();
            try
            {
                foreach (var item in carihareketleri)
                {
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new CARI_HAREKET();
                        if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


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
                        if (fis.TIP == 1)
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
                        if (fis.TIP == 1)
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
                    //stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();
                    db.SaveChanges();
                }
                foreach (var item in gelirhareketri)
                {
                    var gelir = db.GELIR_BASLIK.Where(x => x.ID == item.GELIR_BASLIKKID).FirstOrDefault();
                    var gelirhareket = item;
                    gelir.TOPLAMTUTAR -= gelirhareket.TUTARI;

                    db.SaveChanges();
                }
                foreach (var item in giderhareketleri)
                {
                    var gider = db.GIDER_BASLIK.Where(x => x.ID == item.GIDER_BASLIKID).FirstOrDefault();
                    var gelirhareket = item;
                    gider.TOPLAMTUTAR -= gelirhareket.TUTARI;

                    db.SaveChanges();
                }
                foreach (var item in fishareketleri)
                {
                    if (!(string.IsNullOrEmpty(item.REFERANS)))
                    {
                        if (db.SIPARIS_FIS.Where(x => x.SIPARISNO == item.REFERANS).Count() > 0)
                        {
                            var siparisfisi = db.SIPARIS_FIS_HAREKET.Find(int.Parse(item.REFERANSID));
                            siparisfisi.BELGENO = null;
                            siparisfisi.KULLANIMDA = 0;


                        }
                        if (db.IRSALIYE_HAREKET.Where(x => x.IRSNO == item.REFERANS).Count() > 0)
                        {
                            var siparisfisi = db.IRSALIYE_HAREKET.Find(int.Parse(item.REFERANSID));
                            siparisfisi.BELGENO = null;
                            siparisfisi.KULLANIMDA = 0;


                        }

                    }
                    item.deleted = 1;
                }
                fis.deleted = 1;
                var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FATNO && x.deleted != 1);
                foreach (var item in stokhareketlerii)
                {

                    item.deleted = 1;

                }
                var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FATNO && x.deleted != 1);
                foreach (var item in cariharetlerii)
                {

                    item.deleted = 1;

                }
                if (fis.TIP == 1)
                {
                    var giderhareketleriii = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FATNO && x.deleted != 1).ToList();
                    foreach (var item in giderhareketleriii)
                    {

                        item.deleted = 1;

                    }
                }
                else
                {
                    var gelirareketleriii = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FATNO && x.deleted != 1).ToList();
                    foreach (var item in gelirareketleriii)
                    {

                        item.deleted = 1;

                    }
                }
                var siparisler = new string[50];
                if (!string.IsNullOrEmpty(fis.SPARISLER))
                    siparisler = fis.SPARISLER.Split(',');
                var irsaliyeler = new string[50];
                if (!string.IsNullOrEmpty(fis.IRSLER))
                    irsaliyeler = fis.IRSLER.Split(',');
                var stokfisleri = new string[50];
                if (!string.IsNullOrEmpty(fis.STOKFISLER))
                    stokfisleri = fis.STOKFISLER.Split(',');
                if (siparisler[0] != null)
                    foreach (var item in siparisler)
                    {
                        var siparis = db.SIPARIS_FIS.Where(x => x.SIPARISNO.Contains(item)).FirstOrDefault();
                        var fishareketleria = db.SIPARIS_FIS_HAREKET.Where(x => x.SIPARISNO == item).ToList();
                        var kullanılanlar = 0;
                        foreach (var itema in fishareketleria)
                        {
                            if (itema.KULLANIMDA == 1)
                                kullanılanlar += 1;


                        }
                        if (kullanılanlar == 0)
                        {
                            siparis.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;
                        }
                        else
                        {
                            if (fishareketleria.Count() == kullanılanlar)
                            {
                                siparis.DURUM = IRSALIYE.drumlar.Faturalaştırıldı;
                            }
                            else if (fishareketleria.Count() > kullanılanlar)
                            {
                                siparis.DURUM = IRSALIYE.drumlar.KısmenFaturalaştırıldı;
                            }
                        }





                    }
                if (irsaliyeler[0] != null)
                    foreach (var item in irsaliyeler)
                    {
                        var irsaliye = db.IRSALIYE.Where(x => x.IRSNO.Contains(item)).FirstOrDefault();
                        var fishareketleria = db.IRSALIYE_HAREKET.Where(x => x.IRSNO == item).ToList();
                        var kullanılanlar = 0;
                        foreach (var itema in fishareketleria)
                        {
                            if (itema.KULLANIMDA == 1)
                                kullanılanlar += 1;


                        }
                        if (kullanılanlar == 0)
                        {
                            irsaliye.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;
                        }
                        else
                        {
                            if (fishareketleria.Count() == kullanılanlar)
                            {
                                irsaliye.DURUM = IRSALIYE.drumlar.Faturalaştırıldı;
                            }
                            else if (fishareketleria.Count() > kullanılanlar)
                            {
                                irsaliye.DURUM = IRSALIYE.drumlar.KısmenFaturalaştırıldı;
                            }
                        }






                    }
                if (stokfisleri[0] != null)
                    foreach (var item in stokfisleri)
                    {
                        var stokfisi = db.STOK_FIS.Where(x => x.FISNO.Contains(item)).FirstOrDefault();
                        stokfisi.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;

                        var carihareket = db.CARI_HAREKET.Where(x => x.ISLEMNO == stokfisi.FISNO).FirstOrDefault();
                        if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                        {
                            var eskihareket = new CARI_HAREKET();
                            if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                            {
                                eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                            }
                            else { eskihareket.BAKIYE = 0; }
                            if (fis.TIP == 1)
                            {
                                cari.TOPLAMDOVIZALACAK += carihareket.DOVIZALACAK;
                                cari.TOPLAMALACAK += carihareket.ALACAK;

                                foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                {
                                    hareketz.BAKIYE -= carihareket.ALACAK;
                                    hareketz.DOVIZBAKIYE -= carihareket.ALACAK;

                                }
                                db.SaveChanges();
                            }
                            else
                            {


                                cari.TOPLAMDOVIZBORC += carihareket.DOVIZBORC;
                                cari.TOPLAMBORC += carihareket.BORC;

                                foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1))
                                {
                                    hareketz.BAKIYE += carihareket.BORC;

                                    hareketz.DOVIZBAKIYE += carihareket.DOVIZBORC;
                                }
                                db.SaveChanges();

                            }
                        }
                        else
                        {
                            if (fis.TIP == 1)
                            {
                                cari.TOPLAMDOVIZALACAK += carihareket.DOVIZALACAK;
                                cari.TOPLAMALACAK += carihareket.ALACAK;
                                db.SaveChanges();

                            }
                            else
                            {

                                cari.TOPLAMDOVIZBORC += carihareket.DOVIZBORC;
                                cari.TOPLAMBORC += carihareket.BORC;

                                db.SaveChanges();




                            }

                        }
                        carihareket.deleted = 0;



                    }



                db.SaveChanges();
                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
          
                trans.Commit();
                Disposedb();
                return jsonResult;
             
           
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Disposedb();
                return Json( "Başarısız!");
            }

        

        }
     
        public void fisyenile (int id)
        {
           
            var fis = db.FATURA.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.FATURA_HAREKET.Where(x => x.FATURAID == id && x.deleted != 1);

            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FATNO && x.deleted != 1).ToList();
            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FATNO && x.deleted != 1).ToList();


            var cari = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();

            var gelirhareketri = new List<GELIR_BORDRO_HAREKET>();
            var giderhareketleri = new List<GIDER_BORDRO_HAREKET>();
       
            if (fis.TIP == 1)
            {
                giderhareketleri = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FATNO && x.deleted != 1).ToList();
            }
            else
            {
                gelirhareketri = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FATNO && x.deleted != 1).ToList();
            }

          
                foreach (var item in carihareketleri)
                {
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new CARI_HAREKET();
                        if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


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
                        if (fis.TIP == 1)
                        {



                            stok.MIKTAR -= stokhareket.MIKTAR;
                            stok.TOPGIREN -= stokhareket.FIYAT;

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
                        if (fis.TIP == 1)
                        {


                            stok.MIKTAR -= stokhareket.MIKTAR;
                            stok.TOPGIREN -= stokhareket.FIYAT;
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
                    //stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();
                    db.SaveChanges();
                }
                foreach (var item in gelirhareketri)
                {
                    var gelir = db.GELIR_BASLIK.Where(x => x.ID == item.GELIR_BASLIKKID).FirstOrDefault();
                    var gelirhareket = item;
                    gelir.TOPLAMTUTAR -= gelirhareket.TUTARI;

                    db.SaveChanges();
                }
                foreach (var item in giderhareketleri)
                {
                    var gider = db.GIDER_BASLIK.Where(x => x.ID == item.GIDER_BASLIKID).FirstOrDefault();
                    var gelirhareket = item;
                    gider.TOPLAMTUTAR -= gelirhareket.TUTARI;

                    db.SaveChanges();
                }
                if (fis.TIP == 1)
                {
                    var giderhareketleriii = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FATNO && x.deleted != 1).ToList();
                    db.GIDER_BORDRO_HAREKET.RemoveRange(giderhareketleriii);
                }
                else
                {
                    var gelirareketleriii = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FATNO && x.deleted != 1).ToList();
                    db.GELIR_BORDRO_HAREKET.RemoveRange(gelirareketleriii);
                }
                db.FATURA_HAREKET.RemoveRange(fishareketleri);
                var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FATNO && x.deleted != 1);
                db.STOK_HAREKET.RemoveRange(stokhareketlerii);
                var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FATNO && x.deleted != 1);
                db.CARI_HAREKET.RemoveRange(cariharetlerii);

                db.SaveChanges();
             
               
          
            
            

        }
        public void fisyenileefatura(int id)
        {

            var fis = db.EFATURAIN.Where(x => x.ID == id ).FirstOrDefault();
            var fishareketleri = db.EFATURAIN_HAREKET.Where(x => x.EFATURAINID == id );

            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1).ToList();


            var cari = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();

            var gelirhareketri = new List<GELIR_BORDRO_HAREKET>();
            var giderhareketleri = new List<GIDER_BORDRO_HAREKET>();

            if (fis.TIPI == CARI_HAREKET.tip.Çıkış)
            {
                giderhareketleri = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
            }
            else
            {
                gelirhareketri = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
            }


            foreach (var item in carihareketleri)
            {
                var carihareket = item;
                if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                {
                    var eskihareket = new CARI_HAREKET();
                    if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                    {
                        eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                    }
                    else { eskihareket.BAKIYE = 0; }
                    if (fis.TIPI == CARI_HAREKET.tip.Giriş)
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
                    if (fis.TIPI == CARI_HAREKET.tip.Giriş)
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
          foreach (var item in hareketler)
                {
                    var stok = db.STOK.Where(x => x.ID == item.STOKID).FirstOrDefault();
                    var stokhareket = item;
                if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                {
                    var eskihareket = new STOK_HAREKET();
                    if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                    {
                        eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).OrderByDescending(x => x.TARIH).FirstOrDefault();


                    }
                    else { eskihareket.STOKMIKTAR = 0; }
                    if (fis.TIPI == CARI_HAREKET.tip.Giriş)
                    {

                        stok.TOPGIREN -= stokhareket.MIKTAR;
                        stok.MIKTAR -= stokhareket.MIKTAR;
                        stok.TL_ALIS_TOPLAM -= stokhareket.TUTAR;
                        stok.DOVIZ_ALIS_TOPLAM -= stokhareket.TUTAR * stokhareket.KUR_FIYAT;

                        foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).ToList())
                        {
                            hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;
                            hareketz.TL_STOKALIS_TOPLAM -= stokhareket.TUTAR;
                            hareketz.DOVIZ_STOKALIS_TOPLAM -= stokhareket.TUTAR * stokhareket.KUR_FIYAT;
                            hareketz.STOKMIKTAR_GIREN -= (float)stokhareket.MIKTAR;
                            db.Entry(hareketz).State = EntityState.Modified;
                            db.SaveChanges();

                        }

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
                    if (fis.TIPI == CARI_HAREKET.tip.Giriş)
                    {

                        stok.TOPGIREN -= stokhareket.MIKTAR;
                        stok.MIKTAR -= stokhareket.MIKTAR;
                        stok.TL_ALIS_TOPLAM -= stokhareket.TUTAR;
                        stok.DOVIZ_ALIS_TOPLAM -= stokhareket.DOVIZ_TUTAR;
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
                    //stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();
                    db.SaveChanges();
                }
            foreach (var item in gelirhareketri)
            {
                var gelir = db.GELIR_BASLIK.Where(x => x.ID == item.GELIR_BASLIKKID).FirstOrDefault();
                var gelirhareket = item;
                gelir.TOPLAMTUTAR -= gelirhareket.TUTARI;

                db.SaveChanges();
            }
            foreach (var item in giderhareketleri)
            {
                var gider = db.GIDER_BASLIK.Where(x => x.ID == item.GIDER_BASLIKID).FirstOrDefault();
                var gelirhareket = item;
                gider.TOPLAMTUTAR -= gelirhareket.TUTARI;

                db.SaveChanges();
            }
            if (fis.TIPI == CARI_HAREKET.tip.Çıkış)
            {
                var giderhareketleriii = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
                db.GIDER_BORDRO_HAREKET.RemoveRange(giderhareketleriii);
            }
            else
            {
                var gelirareketleriii = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
                db.GELIR_BORDRO_HAREKET.RemoveRange(gelirareketleriii);
            }
            db.EFATURAIN_HAREKET.RemoveRange(fishareketleri);
            var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1);
            db.STOK_HAREKET.RemoveRange(stokhareketlerii);
            var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
            db.CARI_HAREKET.RemoveRange(cariharetlerii);

            db.SaveChanges();






        }
        [HttpPost]
        public JsonResult fissilefatura(int id)
        {
            efaturachangestring();
            var efatura = db.EFATURA.Find(id);
            var fis = db.EFATURAIN.Where(x => x.EFATURAID == id).FirstOrDefault();
            var fishareketleri = db.EFATURAIN_HAREKET.Where(x => x.EFATURAINID == fis.ID);
            fis.FISNO = efatura.FATURANO;
            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == efatura.FATURANO && x.deleted != 1).ToList();
            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == efatura.FATURANO && x.deleted != 1).ToList();


            var cari = db.CARI_BASLIK.Where(x => x.ID == efatura.CARIID).FirstOrDefault();

            var gelirhareketri = new List<GELIR_BORDRO_HAREKET>();
            var giderhareketleri = new List<GIDER_BORDRO_HAREKET>();

            var trans = db.Database.BeginTransaction();
            try
            {
                if (fis.TIPI == CARI_HAREKET.tip.Çıkış)
            {
                giderhareketleri = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
            }
            else
            {
                gelirhareketri = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
            }


            foreach (var item in carihareketleri)
            {
                var carihareket = item;
                if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                {
                    var eskihareket = new CARI_HAREKET();
                    if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).Count() > 0)
                    {
                        eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                    }
                    else { eskihareket.BAKIYE = 0; }
                    if (fis.TIPI == CARI_HAREKET.tip.Giriş)
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
                    if (fis.TIPI == CARI_HAREKET.tip.Giriş)
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
                foreach (var item in hareketler)
                {
                    var stok = db.STOK.Where(x => x.ID == item.STOKID).FirstOrDefault();
                    var stokhareket = item;
                    if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                    {
                        var eskihareket = new STOK_HAREKET();
                        if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).OrderByDescending(x => x.TARIH).FirstOrDefault();


                        }
                        else { eskihareket.STOKMIKTAR = 0; }
                        if (fis.TIPI == CARI_HAREKET.tip.Giriş)
                        {

                            stok.TOPGIREN -= stokhareket.MIKTAR;
                            stok.MIKTAR -= stokhareket.MIKTAR;
                            stok.TL_ALIS_TOPLAM -= stokhareket.TUTAR;
                            stok.DOVIZ_ALIS_TOPLAM -= stokhareket.TUTAR * stokhareket.KUR_FIYAT;

                            foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).ToList())
                            {
                                hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;
                                hareketz.TL_STOKALIS_TOPLAM -= stokhareket.TUTAR;
                                hareketz.DOVIZ_STOKALIS_TOPLAM -= stokhareket.TUTAR * stokhareket.KUR_FIYAT;
                                hareketz.STOKMIKTAR_GIREN -= (float)stokhareket.MIKTAR;
                                db.Entry(hareketz).State = EntityState.Modified;
                                db.SaveChanges();

                            }

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
                        if (fis.TIPI == CARI_HAREKET.tip.Giriş)
                        {

                            stok.TOPGIREN -= stokhareket.MIKTAR;
                            stok.MIKTAR -= stokhareket.MIKTAR;
                            stok.TL_ALIS_TOPLAM -= stokhareket.TUTAR;
                            stok.DOVIZ_ALIS_TOPLAM -= stokhareket.DOVIZ_TUTAR;
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
                    var depotoplam = db.STOK_DEPO_TOPLAM.Where(x => x.DEPOSUID == item.DEPOSUID).Where(x => x.STOKID == item.STOKID).FirstOrDefault();


                    if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                    {
                        depotoplam.MIKTAR -= stokhareket.MIKTAR;
                    }
                    else
                    {
                        depotoplam.MIKTAR += stokhareket.MIKTAR;

                    }
                    db.SaveChanges();
                    //stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();
                    db.SaveChanges();
                }
                foreach (var item in gelirhareketri)
            {
                var gelir = db.GELIR_BASLIK.Where(x => x.ID == item.GELIR_BASLIKKID).FirstOrDefault();
                var gelirhareket = item;
                gelir.TOPLAMTUTAR -= gelirhareket.TUTARI;

                db.SaveChanges();
            }
            foreach (var item in giderhareketleri)
            {
                var gider = db.GIDER_BASLIK.Where(x => x.ID == item.GIDER_BASLIKID).FirstOrDefault();
                var gelirhareket = item;
                gider.TOPLAMTUTAR -= gelirhareket.TUTARI;

                db.SaveChanges();
            }
            if (fis.TIPI == CARI_HAREKET.tip.Çıkış)
            {
                var giderhareketleriii = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
                db.GIDER_BORDRO_HAREKET.RemoveRange(giderhareketleriii);
            }
            else
            {
                var gelirareketleriii = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
                db.GELIR_BORDRO_HAREKET.RemoveRange(gelirareketleriii);
            }
            db.EFATURAIN_HAREKET.RemoveRange(fishareketleri);
                db.SaveChanges();
                var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1);
            db.STOK_HAREKET.RemoveRange(stokhareketlerii);
            var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
            db.CARI_HAREKET.RemoveRange(cariharetlerii);
            db.EFATURAIN.Remove(fis);
                db.SaveChanges();
                db.EFATURA.Remove(efatura);
            db.SaveChanges();
                trans.Commit();
                Disposedb();
                return Json("Başarılı!");


            }
            catch (Exception ex)
            {
                trans.Rollback();
                Disposedb();
                return Json("Başarısız!");
            }




        }

        [HttpPost]
        public JsonResult datagonder(faturafismodel gelenveri)
        {
            changestring();


            var ida = 0;


            double toplamtutar = 0;
            double toplamiktar = 0;
            double toplammaliyet = 0;
            double toplamdovuz = 0;
            var fatura = new FATURA();
            var carid = int.Parse(gelenveri.CARIKOD);
            var cari = db.CARI_BASLIK.Find(carid);
            
            fatura.CARI = cari;
            fatura.CARIKOD = fatura.CARI.CARIKOD;
            fatura.CreateDate = DateTime.Now;
            fatura.CreateUserID = userid;
    
            fatura.TIP = (int)gelenveri.TIPI;
            fatura.FATNO = gelenveri.FISNO.ToString();
            fatura.ACIKLAMA = gelenveri.NOT;
            fatura.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
            fatura.TARIH = DateTime.Parse(gelenveri.TARIH);
            fatura.ODEMETARIHI = DateTime.Parse(gelenveri.ODEMETARIHI);

            if (gelenveri.gelenhareket.Count == 0)
            {
                var jsonResult = Json("Başarısız", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                Disposedb(); return jsonResult;
            }
            else
            {
                var trans = db.Database.BeginTransaction();
                try
                {
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        toplamtutar += double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));
                        toplamiktar += double.Parse(item.MIKTAR);

                        if (item.PARABIRIMI == cari.PARABIRIMI)
                            toplamdovuz += double.Parse(item.KDVTUTAR.ToString().Replace(",", "").Replace(".", ",")) / double.Parse(item.PARABIRIMIKUR.ToString().Replace(".", ","));
                        else
                        {
                            toplamdovuz += double.Parse(item.KDVTUTAR.ToString().Replace(",", "").Replace(".", ",")) / db.KUR_BASLIK.Where(x => x.KURKODU == cari.PARABIRIMI).FirstOrDefault().KUR;
                        }

                    }
                    fatura.TOPLAMSONTUTAR = toplamtutar;
                    fatura.TOPLAMMIKTAR = toplamiktar;

                    var list = db.FATURA.SingleOrDefault(x => x.FATNO == fatura.FATNO);
                    if (list == null)
                    {
                        db.FATURA.Add(fatura);
                        db.SaveChanges();
                        ida = fatura.ID;
                    }
                    else
                    {
                       
                        list.UpdateDate = DateTime.Now;
                        list.UpdateUserID = 1;
                        list.S_MERKEZIID = fatura.S_MERKEZIID;
                        list.TARIH = fatura.TARIH;
                        list.ACIKLAMA = fatura.ACIKLAMA;
                        list.TOPLAMMIKTAR = fatura.TOPLAMMIKTAR;
                        list.TOPLAMSONTUTAR = fatura.TOPLAMSONTUTAR;

                        fisyenile(list.ID);
                        ida = list.ID;

                        db.SaveChanges();
                    }
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        double tutar = 0;
                        toplamdovuz += double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ",")) / double.Parse(item.PARABIRIMIKUR.Replace(".", ","));
                        tutar = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));
                        if (!(string.IsNullOrEmpty(item.REFERANS)))
                        {
                            if (db.SIPARIS_FIS.Where(x => x.SIPARISNO == item.REFERANS).Count() > 0)
                            {
                                var siparisfisi = db.SIPARIS_FIS_HAREKET.Find(int.Parse(item.ID));
                                siparisfisi.BELGENO = fatura.FATNO;
                                siparisfisi.KULLANIMDA = 1;


                            }
                            if (db.IRSALIYE_HAREKET.Where(x => x.IRSNO == item.REFERANS).Count() > 0)
                            {
                                var siparisfisi = db.IRSALIYE_HAREKET.Find(int.Parse(item.ID));
                                siparisfisi.BELGENO = fatura.FATNO;
                                siparisfisi.KULLANIMDA = 1;


                            }

                        }

                        if (item.GELIRGIDER == 1)
                        {
                            var gelirhareket = new GELIR_BORDRO_HAREKET();
                            var gelirid = item.STOKID;
                            var gelir = db.GELIR_BASLIK.Find(gelirid);
                            gelirhareket.GELIR_BASLIK = gelir;
                            gelirhareket.GELIR_BASLIKKID = gelirid;
                            gelirhareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
                            gelirhareket.PARABIRIMI = item.PARABIRIMI;
                            gelirhareket.ACIKLAMA = item.ACIKLAMA;
                            gelirhareket.FISNO = fatura.FATNO;
                            gelirhareket.S_MERKEZI = fatura.S_MERKEZI;
                            gelirhareket.CreateDate = DateTime.Now;
                            gelirhareket.CreateUserID = userid;
                            gelirhareket.PARAKUR = double.Parse(item.PARABIRIMIKUR.Replace(".", ","));
                            gelirhareket.TUTARI = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                            gelir.TOPLAMTUTAR += gelirhareket.TUTARI;
                            db.GELIR_BORDRO_HAREKET.Add(gelirhareket);

                            db.SaveChanges();
                        }
                        else if (item.GELIRGIDER == 2)
                        {
                            var giderhareket = new GIDER_BORDRO_HAREKET();
                            var gelirid = item.STOKID;
                            var gider = db.GIDER_BASLIK.Find(gelirid);
                            giderhareket.GIDER_BASLIK = gider;
                            giderhareket.GIDER_BASLIKID = gelirid;
                            giderhareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
                            giderhareket.PARABIRIMI = item.PARABIRIMI;
                            giderhareket.ACIKLAMA = item.ACIKLAMA;
                            giderhareket.FISNO = fatura.FATNO;
                            giderhareket.S_MERKEZI = fatura.S_MERKEZI;
                            giderhareket.CreateDate = DateTime.Now;
                            giderhareket.CreateUserID = userid;
                            giderhareket.PARAKUR = double.Parse(item.PARABIRIMIKUR.Replace(".", ","));
                            giderhareket.TUTARI = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                            gider.TOPLAMTUTAR += giderhareket.TUTARI;
                            db.GIDER_BORDRO_HAREKET.Add(giderhareket);

                            db.SaveChanges();
                        }
                        else
                        {
                            var stokid = item.STOKID;
                            var stok = db.STOK.Where(x => x.ID == stokid).FirstOrDefault();
                            var stokhareket = new STOK_HAREKET();
                            stokhareket.STOK = stok;

                            stokhareket.STOKKODU = stokhareket.STOK.STOKKODU;
                            stokhareket.CARIID =cari.ID;
                            stokhareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMADI == item.BIRIM).FirstOrDefault().ID;
                            stokhareket.CreateDate = DateTime.Now;
                            stokhareket.CreateUserID = userid;
                            stokhareket.BELGENO = gelenveri.FISNO;
                            stokhareket.TARIH = DateTime.Parse(gelenveri.TARIH);
                            stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.Fatura;
                            stokhareket.MIKTAR = double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                            stokhareket.FIYAT = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                            stokhareket.TIPI = gelenveri.TIPI;
                            stokhareket.PARABIRIMI = item.PARABIRIMI;
                            stokhareket.PARAKUR = double.Parse(item.PARABIRIMIKUR.Replace(".", ","));

                            if (DateTime.Now.CompareTo(stokhareket.TARIH.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new STOK_HAREKET();
                                if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).Count() > 0)
                                {
                                    eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).OrderBy(x => x.TARIH).FirstOrDefault();


                                }
                                else { eskihareket.STOKMIKTAR = 0; }
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    stok.MIKTAR += stokhareket.MIKTAR;
                                    stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR + (float)stokhareket.MIKTAR;

                                    foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU))
                                    {
                                        hareketz.STOKMIKTAR += (float)stokhareket.MIKTAR;

                                    }
                                }
                                else
                                {
                                    stok.MIKTAR -= stokhareket.MIKTAR;
                                    stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR - (float)stokhareket.MIKTAR;
                                    foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU))
                                    {
                                        hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;

                                    }
                                }


                            }
                            else
                            {
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    stok.MIKTAR += stokhareket.MIKTAR;


                                }
                                else
                                {
                                    stok.MIKTAR -= stokhareket.MIKTAR;

                                }
                                stokhareket.STOKMIKTAR = float.Parse(stok.MIKTAR.ToString());
                            }
                            stokhareket.TUTAR = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));
                            //stokhareket.SONMALIYET = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));

                            stokhareket.S_MERKEZIID = fatura.S_MERKEZIID;


                            stokhareket.ACIKLAMA = item.ACIKLAMA;
                            db.STOK_HAREKET.Add(stokhareket);

                            db.SaveChanges();
                            if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                stok.HAMALISFIYAT = stokhareket.FIYAT;
                                stok.TOPGIREN += double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));

                                //stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();

                            }
                            else
                            {
                                stok.HAMSATISFIYAT = stokhareket.FIYAT;

                                stok.TOPCIKAN += double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));

                            }


                            toplammaliyet += (double)stok.ALISFIYATI * stokhareket.MIKTAR;
                        }



                        db.SaveChanges();
                    }
                    db.FATURA.Where(x=>x.FATNO==fatura.FATNO).FirstOrDefault().TOPLAMMALIYET = toplammaliyet;
                    var hareket = new CARI_HAREKET();
                    hareket.cari = cari;
                    hareket.CARIKOD = hareket.cari.CARIKOD;
                    hareket.CreateDate = DateTime.Now;

                    hareket.CreateUserID = userid;
                    hareket.ISLEMNO = gelenveri.FISNO;
                    hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                    hareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
                    hareket.S_MERKEZIID = fatura.S_MERKEZIID;
                    if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new CARI_HAREKET();
                        if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).Count() > 0)
                        {
                            eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }

                        if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                        {
                            hareket.TIPI = CARI_HAREKET.tip.Giriş;
                            hareket.ALACAK = toplamtutar;
                            hareket.DOVIZALACAK = toplamdovuz;
                            cari.TOPLAMDOVIZALACAK += toplamdovuz;
                            cari.TOPLAMALACAK += hareket.ALACAK;
                            hareket.BAKIYE = eskihareket.BAKIYE - toplamtutar;
                            hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE - toplamdovuz;
                            foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                            {
                                hareketz.BAKIYE -= toplamtutar;
                                hareketz.DOVIZBAKIYE -= toplamdovuz;
                            }


                        }
                        else
                        {
                            hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                            hareket.BORC = toplamtutar;
                            hareket.DOVIZBORC = toplamdovuz;
                            cari.TOPLAMDOVIZBORC = toplamdovuz;
                            cari.TOPLAMBORC += hareket.BORC;
                            hareket.BAKIYE = eskihareket.BAKIYE + toplamtutar;
                            hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE + toplamdovuz;
                            foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                            {
                                hareketz.BAKIYE -= toplamtutar;
                                hareketz.DOVIZBAKIYE -= toplamdovuz;
                            }


                        }


                    }
                    else
                    {
                        if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                        {
                            hareket.TIPI = CARI_HAREKET.tip.Giriş;
                            hareket.ALACAK = toplamtutar;
                            hareket.DOVIZALACAK = toplamdovuz;
                            cari.TOPLAMDOVIZALACAK += toplamdovuz;
                            cari.TOPLAMALACAK += hareket.ALACAK;
                            hareket.BAKIYE = cari.BAKIYE;
                            hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;

                        }
                        else
                        {
                            hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                            hareket.BORC = toplamtutar;
                            hareket.DOVIZBORC = toplamdovuz;
                            cari.TOPLAMDOVIZBORC = toplamdovuz;
                            cari.TOPLAMBORC += hareket.BORC;
                            hareket.BAKIYE = cari.BAKIYE;
                            hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;



                        }
                    }



                    hareket.ACIKLAMA = gelenveri.NOT;

                    hareket.VADE = DateTime.Parse(gelenveri.ODEMETARIHI);

                    db.CARI_HAREKET.Add(hareket);

                    db.SaveChanges();
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var fishareket = new FATURA_HAREKET();
                        var stokid = item.STOKID;


                        fishareket.Fatno = gelenveri.FISNO;
                        fishareket.BIRIM = item.BIRIM;
                        fishareket.FATURAID = db.FATURA.Find(ida).ID;
                        fishareket.ACIKLAMA = item.ACIKLAMA;
                        fishareket.STOK = db.STOK.Where(x => x.ID == stokid).FirstOrDefault();

                        fishareket.PARABIRIMI = item.PARABIRIMI;
                        fishareket.PARAKUR = double.Parse(item.PARABIRIMIKUR.Replace(".", ","));
                        fishareket.MIKTAR = double.Parse(item.MIKTAR);
                        fishareket.TOPLAMFIYAT = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                        fishareket.ISK1 = double.Parse(item.ISKONTO.Replace(",", "").Replace(".", ","));
                        fishareket.NETFIYAT = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));
                        fishareket.KDVTUTARI = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));
                        fishareket.REFERANS = item.REFERANS;
                        fishareket.REFERANSID = item.ID;

                        db.FATURA_HAREKET.Add(fishareket);
                        db.SaveChanges();
                    }
                    ///irsaliye silme
                    if (gelenveri.IRSALIYELER != null)
                        foreach (var id in gelenveri.IRSALIYELER)
                        {
                            var fis = db.IRSALIYE.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
                            var fishareketleri = db.IRSALIYE_HAREKET.Where(x => x.IRSALIYEID == id && x.deleted != 1);


                            fatura.IRSLER += "," + fis.IRSNO + ",";

                            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.IRSNO && x.deleted != 1).ToList();


                            var caria = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();



                            var kullanılanlar = 0;
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
                                    if (fis.TIP == 1)
                                    {



                                        stok.MIKTAR -= stokhareket.MIKTAR;


                                        foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1))
                                        {
                                            hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;


                                        }
                                        db.SaveChanges();
                                    }
                                    else
                                    {


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
                                    if (fis.TIP == 1)
                                    {


                                        stok.MIKTAR -= stokhareket.MIKTAR;

                                        db.SaveChanges();
                                    }
                                    else
                                    {


                                        stok.MIKTAR += stokhareket.MIKTAR;



                                        db.SaveChanges();


                                    }

                                }
                                item.deleted = 1;
                                db.SaveChanges();
                            }

                            foreach (var item in fishareketleri)
                            {
                                if (item.KULLANIMDA == 1)
                                    kullanılanlar += 1;


                            }
                            if (kullanılanlar == 0)
                            {
                                fis.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;
                            }
                            else
                            {
                                if (fishareketleri.Count() == kullanılanlar)
                                {
                                    fis.DURUM = IRSALIYE.drumlar.Faturalaştırıldı;
                                }
                                else if (fishareketleri.Count() > kullanılanlar)
                                {
                                    fis.DURUM = IRSALIYE.drumlar.KısmenFaturalaştırıldı;
                                }
                            }



                            var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.IRSNO && x.deleted != 1);
                            foreach (var item in stokhareketlerii)
                            {

                                item.deleted = 1;

                            }
                            var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.IRSNO && x.deleted != 1);
                            foreach (var item in cariharetlerii)
                            {

                                item.deleted = 1;

                            }

                            db.SaveChanges();



                        }

                    if (gelenveri.SIPARISLER != null)
                        foreach (var id in gelenveri.SIPARISLER)
                        {
                            var kullanılanlar = 0;
                            var fis = db.SIPARIS_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
                            var fishareketleri = db.SIPARIS_FIS_HAREKET.Where(x => x.SIPARIS_FISID == id && x.deleted != 1);






                            fatura.SPARISLER += "," + fis.SIPARISNO + ",";
                            foreach (var item in fishareketleri)
                            {
                                if (item.KULLANIMDA == 1)
                                    kullanılanlar += 1;
                            }
                            if (kullanılanlar == 0)
                            {
                                fis.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;
                            }
                            else
                            {
                                if (fishareketleri.Count() == kullanılanlar)
                                {
                                    fis.DURUM = IRSALIYE.drumlar.Faturalaştırıldı;
                                }
                                else if (fishareketleri.Count() > kullanılanlar)
                                {
                                    fis.DURUM = IRSALIYE.drumlar.KısmenFaturalaştırıldı;
                                }
                            }


                            db.SaveChanges();
                        }

                    if (gelenveri.STOKFISLER != null)
                        foreach (var id in gelenveri.STOKFISLER)
                        {
                            var fis = db.STOK_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
                            var fishareketleri = db.STOK_FIS_HAREKET.Where(x => x.fisid == id && x.deleted != 1);

                            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
                            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1).ToList();


                            var stokcari = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();

                            fatura.STOKFISLER += "," + fis.FISNO + ",";


                            foreach (var item in carihareketleri)
                            {
                                var carihareket = item;
                                if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                                {
                                    var eskihareket = new CARI_HAREKET();
                                    if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == stokcari.CARIKOD && x.deleted != 1).Count() > 0)
                                    {
                                        eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == stokcari.CARIKOD && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                                    }
                                    else { eskihareket.BAKIYE = 0; }
                                    if (fis.TIP == 1)
                                    {

                                        stokcari.TOPLAMDOVIZBORC -= carihareket.DOVIZBORC;
                                        stokcari.TOPLAMBORC -= carihareket.BORC;
                                        foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == stokcari.CARIKOD && x.deleted != 1))
                                        {
                                            hareketz.BAKIYE -= carihareket.BORC;

                                            hareketz.DOVIZBAKIYE -= carihareket.DOVIZBORC;
                                        }
                                        db.SaveChanges();
                                    }
                                    else
                                    {


                                        stokcari.TOPLAMDOVIZALACAK -= carihareket.DOVIZALACAK;
                                        stokcari.TOPLAMALACAK -= carihareket.ALACAK;

                                        foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == stokcari.CARIKOD && x.deleted != 1))
                                        {
                                            hareketz.BAKIYE += carihareket.ALACAK;
                                            hareketz.DOVIZBAKIYE += carihareket.ALACAK;

                                        }
                                        db.SaveChanges();
                                    }
                                }
                                else
                                {
                                    if (fis.TIP == 1)
                                    {

                                        stokcari.TOPLAMDOVIZBORC -= carihareket.DOVIZBORC;
                                        stokcari.TOPLAMBORC -= carihareket.BORC;

                                        db.SaveChanges();
                                    }
                                    else
                                    {



                                        stokcari.TOPLAMDOVIZALACAK -= carihareket.DOVIZALACAK;
                                        stokcari.TOPLAMALACAK -= carihareket.ALACAK;
                                        db.SaveChanges();


                                    }

                                }
                                item.deleted = 1;
                                db.SaveChanges();


                            }
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
                                    if (fis.TIP == 1)
                                    {



                                        stok.MIKTAR -= stokhareket.MIKTAR;


                                        foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1))
                                        {
                                            hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;


                                        }
                                        db.SaveChanges();
                                    }
                                    else
                                    {


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
                                    if (fis.TIP == 1)
                                    {


                                        stok.MIKTAR -= stokhareket.MIKTAR;

                                        db.SaveChanges();
                                    }
                                    else
                                    {


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
                            fis.DURUM = IRSALIYE.drumlar.Faturalaştırıldı;
                            db.SaveChanges();

                        }

                    var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;

            

                    trans.Commit();
                    Disposedb();
              
                    return jsonResult;

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Disposedb();
                    return Json("Başarısız! "+ ex.Message+" " + ex.InnerException);
                }
            }
            
            
         
        }
       


        [HttpPost]
        public JsonResult kurfaturasıdatagonder(kurfaturafismodel gelenveri)
        {
            changestring();



            double tutar = 0;

            var fatura = new FATURA();
            var cari = db.CARI_BASLIK.Where(x => x.ID.ToString()==gelenveri.CARIKOD).FirstOrDefault();
            fatura.CARI = db.CARI_BASLIK.Where(x => x.CARIKOD == gelenveri.CARIKOD).FirstOrDefault();
            fatura.CARIKOD = fatura.CARI.CARIKOD;
            fatura.CreateDate = DateTime.Now;
            fatura.CreateUserID = userid;

            fatura.TIP = 1;
            fatura.FATNO = gelenveri.FISNO.ToString();
            fatura.S_MERKEZIID = 1;

           
            fatura.TARIH = DateTime.Parse(gelenveri.TARIH);
     
            db.CARI_HAREKET.RemoveRange(db.CARI_HAREKET.Where(x => x.ISLEMNO == gelenveri.FISNO));
            
            if (cari.DOVIZBAKIYE == 0)
            { if (cari.BAKIYE != 0)
                {
                    tutar =(double) cari.BAKIYE;
                    if(cari.BAKIYE>0)
                    cari.TOPLAMALACAK = cari.TOPLAMBORC;
                    else
                    {
                        cari.TOPLAMBORC = cari.TOPLAMALACAK;

                    }

                }

            }
            if (cari.BAKIYE == 0)
            {
                if (cari.DOVIZBAKIYE != 0)
                {
                    tutar = (double)cari.DOVIZBAKIYE;
                    if (cari.DOVIZBAKIYE > 0)
                        cari.TOPLAMDOVIZALACAK = cari.TOPLAMDOVIZBORC;
                    else
                    {
                        cari.TOPLAMDOVIZBORC = cari.TOPLAMDOVIZALACAK;

                    }

                }

            }
            
            var hareket = new CARI_HAREKET();
                hareket.cari = cari;
                hareket.cariID = cari.ID;
            hareket.CreateDate = DateTime.Now;
            hareket.CreateUserID = userid;
            hareket.TIPI = CARI_HAREKET.tip.Devir;
            hareket.ACIKLAMA = "Kur Farkı Faturası";
            hareket.TARIHSAAT = (DateTime)fatura.TARIH;
            hareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
            hareket.ISLEMNO = gelenveri.FISNO;
                hareket.KAYITSEKLI = CARI_HAREKET_AYRINTI.detay.Nakit;
            hareket.BAKIYE = cari.BAKIYE;
            hareket.S_MERKEZIID = 1;
          
                fatura.TOPLAMMALIYET = tutar;
            db.CARI_HAREKET.Add(hareket);
         
            db.FATURA.Add(fatura);
            db.SaveChanges();
                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

 Disposedb(); Disposedb(); return jsonResult;
          
        }
       

        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }
        [HttpPost]
        public JsonResult efaturavknsorgu(string vkn)
        {
            efaturachangestring();
            var tester = new EFaturaEDMConnectorLibrary(portalurl);

            tester.EDMLogin = db.FIRMA.FirstOrDefault().EFATKULLANICIADI;
            tester.EDMPassw = db.FIRMA.FirstOrDefault().EFATSİFRE;
            string sessionid = tester.EDMGetSession();
            GIBUSER Value = tester.CheckUser_byIdentifier(vkn);
            if (Value != null)
            {
                Disposedb();
                return Json(Value.ALIAS, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Disposedb();
                return Json("NO", JsonRequestBehavior.AllowGet);
            }
        }

        public EFaturaEDMConnectorLibrary tester = new EFaturaEDMConnectorLibrary("https://test.edmbilisim.com.tr//EFaturaEDM/EFaturaEDM.svc");


        private EFaturaEDMConnectorLibrary.draftmodel Win_LoadInvoice(string fatnoa,string ublPaths, int multiplex, bool createUUID, string invoiceID, string pk, string gb, string receiverVKNTCKN, string senderVKNTCKN)
        {

           return tester.SendDraftInvoice("", ublPaths, multiplex, createUUID, invoiceID, pk, gb, receiverVKNTCKN, senderVKNTCKN);
           
        
        }

        private SendInvoiceResponse Win_SendInvoice(string fatno,string[] ublPaths, int multiplex, bool createUUID, string invoiceID, string pk, string gb, string receiverVKNTCKN, string senderVKNTCKN
           , bool generateInvoiceID)
        {

          
            bool generatuuid = false;
            string mobile = "";
            //tester = new TesterCurrentETA();

            // login..
            return  tester.SendInvoiceMultiple( fatno, ublPaths, multiplex, generatuuid, invoiceID, pk, gb, receiverVKNTCKN, senderVKNTCKN, null, mobile);
  
        
        }
        [HttpPost]
        public JsonResult fatnogetir(string seri)
        {
            changestring();
            var don = (db.EFATURA.Where(x => x.SeriNo == seri).Max(x => x.Sıra) + 1).ToString();
            if (don == "")
                don = "1";
            Disposedb();
              return Json(don);


        }


private string yaziyaCevir(double tutar,string parabirimi)
        {
            string sTutar = tutar.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "BİR", "İKİ", "Üç", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
                                //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

            lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                

                if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.
                    grupDegeri = "YÜZ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "") //binler
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.
                    grupDegeri = "BİN";

                yazi += grupDegeri;
            }

            if (yazi != "")
                yazi += " "+parabirimi+" ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0") //kuruş onlar
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0") //kuruş birler
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += " Kr.";
            else
                yazi += "SIFIR Kr.";

            return yazi;
        }

        //Bu fonkisyon efatura gönden
        [HttpPost]
        public JsonResult efaturagonder(EFATURAIN gelenefatura)
        {
            bool degistir = false;
            efaturachangestring();
            var fatno = gelenefatura.SERINO + DateTime.Now.Year + gelenefatura.FISNO.PadLeft(9, '0');
            var anddb = new AndDB();
            var uid = Guid.NewGuid().ToString();
       
            var firma = db.FIRMA.FirstOrDefault();
            var cari = db.CARI_BASLIK.Find(gelenefatura.CARIID);
            var calcitonnumeric = 0;
            var calcitonnumerictevfk = 0;
            string stoklar = "";
            var senaryo = "";
            var pk = "";
            var schemeid = "";
            var schemeidfirma = "";
            var sgk = "";
            var parabirimifarklı = false;
            if (gelenefatura.PARABIRIMI != cari.PARABIRIMI)
                parabirimifarklı = true;
            var xsltham = "";
            if (firma.ENTAGRATOR == null)
            {
                Disposedb();
                return Json("Başarısız");
            }

            


            var kdv0text = @"<cac:TaxSubtotal>
      <cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.MATRAH.Replace(",", "") + @"</cbc:TaxableAmount>
      <cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">0</cbc:TaxAmount>
      <cbc:CalculationSequenceNumeric>1</cbc:CalculationSequenceNumeric>
      <cbc:Percent>0</cbc:Percent>
      <cac:TaxCategory>";
            if(gelenefatura.KOD!="İSTİSNA KODU-AÇIKLAMA")
kdv0text+="<cbc:TaxExemptionReasonCode>" + gelenefatura.KOD + @"</cbc:TaxExemptionReasonCode>";
            ;
            if (gelenefatura.GONDERIMTIPI == "IADE" || gelenefatura.GONDERIMTIPI == "ISTISNA"|| gelenefatura.ISTISNA!= "İSTİSNA KODU-AÇIKLAMA")
                kdv0text += @" <cbc:TaxExemptionReason>" + gelenefatura.ISTISNA + @"</cbc:TaxExemptionReason>";
            kdv0text += @"
         <cac:TaxScheme>
          <cbc:Name>GERÇEK USULDE KATMA DEĞER VERGİSİ</cbc:Name>
          <cbc:TaxTypeCode>0015</cbc:TaxTypeCode>
        </cac:TaxScheme>
      </cac:TaxCategory>
    </cac:TaxSubtotal>";
            var kdv1text = "";
            var kdv8text = "";
            var kdv18text = "";
            if (gelenefatura.KDV1 != "0.00")
            {
                calcitonnumeric += 1;
                kdv1text = @"<cac:TaxSubtotal>
      <cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + ((double.Parse(gelenefatura.KDV1.Replace(",", "").Replace(".", ",")) * 100) / 1).ToString().Replace(",", ".") + @"</cbc:TaxableAmount>
      <cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.KDV1.Replace(",", "") + @"</cbc:TaxAmount>
      <cbc:CalculationSequenceNumeric>" + calcitonnumeric.ToString() + @"</cbc:CalculationSequenceNumeric>
      <cbc:Percent>1</cbc:Percent>
      <cac:TaxCategory>
         <cac:TaxScheme>
          <cbc:Name>GERÇEK USULDE KATMA DEĞER VERGİSİ</cbc:Name>
          <cbc:TaxTypeCode>0015</cbc:TaxTypeCode>
        </cac:TaxScheme>
      </cac:TaxCategory>
    </cac:TaxSubtotal>";

            }
               
            if (gelenefatura.KDV8 != "0.00")
            {
                calcitonnumeric += 1;
                kdv8text = @"<cac:TaxSubtotal>
      <cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + ((double.Parse(gelenefatura.KDV8.Replace(",", "").Replace(".", ",")) * 100) / 8).ToString().Replace(",", ".") + @"</cbc:TaxableAmount>
      <cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.KDV8.Replace(",", "") + @"</cbc:TaxAmount>
      <cbc:CalculationSequenceNumeric>"+ calcitonnumeric.ToString() + @"</cbc:CalculationSequenceNumeric>
      <cbc:Percent>8</cbc:Percent>
      <cac:TaxCategory>
          <cac:TaxScheme>
          <cbc:Name>GERÇEK USULDE KATMA DEĞER VERGİSİ</cbc:Name>
          <cbc:TaxTypeCode>0015</cbc:TaxTypeCode>
        </cac:TaxScheme>
      </cac:TaxCategory>
    </cac:TaxSubtotal>";
            }

            if (gelenefatura.KDV18 != "0.00")

            {
                calcitonnumeric += 1;
                kdv18text = @"<cac:TaxSubtotal>
      <cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + ((double.Parse(gelenefatura.KDV18.Replace(",", "").Replace(".", ",")) * 100) / 18).ToString().Replace(",", ".") + @"</cbc:TaxableAmount>
      <cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.KDV18.Replace(",", "") + @"</cbc:TaxAmount>
      <cbc:CalculationSequenceNumeric>" + calcitonnumeric.ToString() + @"</cbc:CalculationSequenceNumeric>
      <cbc:Percent>18</cbc:Percent>
      <cac:TaxCategory>
         <cac:TaxScheme>
          <cbc:Name>GERÇEK USULDE KATMA DEĞER VERGİSİ</cbc:Name>
          <cbc:TaxTypeCode>0015</cbc:TaxTypeCode>
        </cac:TaxScheme>
      </cac:TaxCategory>
    </cac:TaxSubtotal>";
            }
  


            if (!string.IsNullOrEmpty(gelenefatura.FISNO) && !string.IsNullOrEmpty(gelenefatura.UUID))
                degistir = true;

            if (degistir)
            {
                fatno = gelenefatura.FISNO;
                uid = gelenefatura.UUID;
            }

            if (gelenefatura.GONDERIMSENARYO == "IHRACAT")
            {
                senaryo = "IHRACAT";
                xsltham = firma.XSLKODUFATURA;
        
                
            }
            else
                if ((string.IsNullOrEmpty(cari.gibpk) || cari.gibpk == "EFATURA MÜKELLEFİ DEĞİL" || cari.gibpk.Contains("DEĞİL")) && gelenefatura.GONDERIMTIPI != "SGK")
            {
                senaryo = "EARSIVFATURA";
                gelenefatura.GONDERIMSEKLI = "e-Arsiv";
                if (!string.IsNullOrEmpty(cari.E_POSTA))
                    pk = cari.E_POSTA;
                else { pk = ""; }
                xsltham = firma.XSLKODUEARSIV;
            }

            else
            {
                xsltham = firma.XSLKODUFATURA;
                senaryo = gelenefatura.GONDERIMSENARYO;
                gelenefatura.GONDERIMSEKLI = "e-Fatura";
                pk = cari.gibpk;
            }

            if (firma.VERGINO.Count() > 10)
            {
                schemeidfirma = "TCKN";
            }
            else { schemeidfirma = "VKN"; }

            if (!string.IsNullOrEmpty(cari.VERGINUMARASI)) { 
            if (cari.VERGINUMARASI.Count() > 10)
            {

                schemeid = "TCKN";

                }
                else { schemeid = "VKN"; }
            }
            else { schemeid = "VKN"; }


            byte[] AsBytes = System.IO.File.ReadAllBytes(xsltham);
            var xslt = System.Convert.ToBase64String(AsBytes);

         
            var kamu = @"<cac:BuyerCustomerParty>
 <cac:Party>
 <cac:PartyIdentification>
 <cbc:ID schemeID=""VKN"">"+gelenefatura.EKVERGINO+ @"</cbc:ID>
 </cac:PartyIdentification>
<cac:PartyName>
<cbc:Name/>
</cac:PartyName>
<cac:PostalAddress>
<cbc:BuildingName/>
<cbc:CitySubdivisionName/>
<cbc:CityName/>
<cac:Country>
<cbc:Name>Türkiye</cbc:Name>
</cac:Country>
</cac:PostalAddress>
 </cac:Party>
</cac:BuyerCustomerParty>";

            if (gelenefatura.GONDERIMTIPI == "SGK")
            {
                sgk = @"<cac:InvoicePeriod>
<cbc:StartDate>2021-"+ DateTime.Now.Month.ToString("D" + 2) + @"-01</cbc:StartDate>
<cbc:EndDate>2021-" + DateTime.Now.Month.ToString("D" + 2) + @"-31</cbc:EndDate>
</cac:InvoicePeriod>
<cac:AdditionalDocumentReference>
<cbc:ID>"+uid+@"</cbc:ID>
<cbc:IssueDate>" + gelenefatura.TARIH.Substring(0, 10) + @"</cbc:IssueDate>
<cbc:DocumentTypeCode>MUKELLEF_KODU</cbc:DocumentTypeCode>
<cbc:DocumentType>" + gelenefatura.MUKELLEFKODU + @"</cbc:DocumentType>
<cbc:DocumentDescription>Eczane Sicil Numarası</cbc:DocumentDescription>
</cac:AdditionalDocumentReference>
<cac:AdditionalDocumentReference>
<cbc:ID>" + uid + @"</cbc:ID>
<cbc:IssueDate>2008-08-13</cbc:IssueDate>
<cbc:DocumentTypeCode>MUKELLEF_ADI</cbc:DocumentTypeCode>
<cbc:DocumentType>" + gelenefatura.MUKELEFADI + @"</cbc:DocumentType>
<cbc:DocumentDescription>Eczane Adı</cbc:DocumentDescription>
</cac:AdditionalDocumentReference>
<cac:AdditionalDocumentReference>
<cbc:ID>" + uid + @"</cbc:ID>
<cbc:IssueDate>2008-08-13</cbc:IssueDate>
<cbc:DocumentTypeCode>DOSYA_NO</cbc:DocumentTypeCode>
<cbc:DocumentType>" + gelenefatura.DOSYANO + @"</cbc:DocumentType>
<cbc:DocumentDescription>Döküm No</cbc:DocumentDescription>
</cac:AdditionalDocumentReference>";

            }
            var siparis = @"<cac:OrderReference>
<cbc:ID>"+gelenefatura.SIPARISNO+ @"</cbc:ID>
<cbc:IssueDate>" + gelenefatura.SIPARISTARIH + @"</cbc:IssueDate>
</cac:OrderReference>";
            var odeme = @"
<cac:PaymentMeans>
<cbc:PaymentMeansCode>"+gelenefatura.ODEMESEKLI + @"</cbc:PaymentMeansCode>
<cbc:PaymentChannelCode>" + gelenefatura.ODEMEKANALI + @"</cbc:PaymentChannelCode>
<cac:PayeeFinancialAccount>
<cbc:ID>" + gelenefatura.ODEMEHESAPNO + @"</cbc:ID>
<cbc:CurrencyCode>" + gelenefatura.PARABIRIMI + @"</cbc:CurrencyCode>
</cac:PayeeFinancialAccount>
</cac:PaymentMeans>
";
          

            var earsivek = @"
<cac:AdditionalDocumentReference>
<cbc:ID>" + uid + @"</cbc:ID>
<cbc:IssueDate>" + gelenefatura.TARIH.Substring(0, 10) + @"</cbc:IssueDate>
<cbc:DocumentType>KAGIT</cbc:DocumentType>
</cac:AdditionalDocumentReference>
";
            var ulkekodu = "";
            var ulkeadi = "";
            if (gelenefatura.GONDERIMSENARYO == "IHRACAT") {
               var ulke= anddb.ULKELER.Where(x => x.KODU == cari.ULKE).FirstOrDefault();
                ulkekodu = ulke.KODU;
                ulkeadi = ulke.ADI;
                senaryo = "IHRACAT";
            }
            else
            if ((string.IsNullOrEmpty(cari.gibpk) || cari.gibpk == "EFATURA MÜKELLEFİ DEĞİL" || cari.gibpk.Contains("DEĞİL"))&&gelenefatura.GONDERIMTIPI!="SGK")
            {
                senaryo = "EARSIVFATURA";
                gelenefatura.GONDERIMSEKLI = "e-Arsiv";
                if (!string.IsNullOrEmpty(cari.E_POSTA))
                    pk = cari.E_POSTA;
                else { pk = ""; }

            }
               
            else
            {
                senaryo = gelenefatura.GONDERIMSENARYO;
                gelenefatura.GONDERIMSEKLI = "e-Fatura";
                pk = cari.gibpk;
            }

            var istisna = @"<cbc:TaxExemptionReasonCode>" + gelenefatura.KOD + @"</cbc:TaxExemptionReasonCode>
                <cbc:TaxExemptionReason>" + gelenefatura.ISTISNA + @"</cbc:TaxExemptionReason>";
            int sira = 0;
            foreach (var item in gelenefatura.Hareketler)
            { sira += 1;
                var id = item.MALHIZMET;
                var ad = "";
                var kod = "";

                if (item.GELIRGIDER == 0)
                {
                    var stok = db.STOK.Where(x => x.ID == id).FirstOrDefault();
                    ad = stok.STOKAD;
                    kod = stok.STOKKODU;
                }
                else
                {
                    var gelir = db.GELIR_BASLIK.Where(x => x.ID == id).FirstOrDefault();
                    ad = gelir.GELIRAD;
                    kod = gelir.GELIRKODU;

                }
                var birim = anddb.STOK_BIRIMLER.Single(x => x.BIRIMADI == item.BIRIM).BIRIMKODU;
                    var stokhareketi = @"<cac:InvoiceLine>
  <cbc:ID>"+ sira +@"</cbc:ID>
    <cbc:InvoicedQuantity unitCode="""+birim+@""">"+ item.MIKTAR.Replace(",", "") + @"</cbc:InvoicedQuantity>
    <cbc:LineExtensionAmount currencyID="""+ gelenefatura.PARABIRIMI + @""">" + item.TOPLAM.Replace(",","") + @"</cbc:LineExtensionAmount>";
                    if (gelenefatura.GONDERIMSENARYO == "IHRACAT")
                    {
                        stokhareketi += @"<cac:Delivery>
			<cac:DeliveryAddress>
				<cbc:BuildingName>"+cari.ISADRES1+@"</cbc:BuildingName>
				<cbc:CitySubdivisionName></cbc:CitySubdivisionName>
				<cbc:CityName></cbc:CityName>
				<cac:Country>
					<cbc:IdentificationCode>"+ulkekodu+@"</cbc:IdentificationCode>
					<cbc:Name>"+ulkeadi+@"</cbc:Name>
				</cac:Country>
			</cac:DeliveryAddress>
			<cac:DeliveryTerms>
				<cbc:ID schemeID=""INCOTERMS"">"+item.TESLIMSARTI+@"</cbc:ID>
			</cac:DeliveryTerms>
			<cac:Shipment>
				<cbc:ID/>
				<cac:GoodsItem>
					<cbc:RequiredCustomsID>"+item.GTIP+@"</cbc:RequiredCustomsID>
				</cac:GoodsItem>
				<cac:ShipmentStage>
					<cbc:TransportModeCode>"+item.ESYANINGONDERIMSEKLI+@"</cbc:TransportModeCode>
				</cac:ShipmentStage>
				<cac:TransportHandlingUnit>
					<cac:ActualPackage>
						<cbc:Quantity>"+item.KAPADET+@"</cbc:Quantity>
					</cac:ActualPackage>
				</cac:TransportHandlingUnit>
			</cac:Shipment>
		</cac:Delivery>";
                    }
                    if(double.Parse(item.ISKONTOTUTAR.Replace(",","").Replace(".",","))>0)
                stokhareketi += @"<cac:AllowanceCharge>
    <cbc:ChargeIndicator>false</cbc:ChargeIndicator>
    <cbc:MultiplierFactorNumeric>" + "0." + item.ISKONTO.Replace(".", "") + @"</cbc:MultiplierFactorNumeric>
    <cbc:Amount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + item.ISKONTOTUTAR.Replace(",", "") + @"</cbc:Amount>
    <cbc:BaseAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + (double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ",")) * double.Parse(item.FIYAT.Replace(",", "").Replace(".", ","))).ToString().Replace(",", ".") + @"</cbc:BaseAmount>
    </cac:AllowanceCharge>";
                stokhareketi += @"
    <cac:TaxTotal>
      <cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" +item.KDVTUTAR.Replace(",", "") + @"</cbc:TaxAmount>
      <cac:TaxSubtotal>
        <cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + item.TOPLAM.Replace(",","") + @"</cbc:TaxableAmount>
        <cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + item.KDVTUTAR.Replace(",", "") + @"</cbc:TaxAmount>
        <cbc:CalculationSequenceNumeric>1</cbc:CalculationSequenceNumeric>
        <cbc:Percent>" + item.KDVORANI + @"</cbc:Percent>
        <cac:TaxCategory>";
                    if (gelenefatura.GONDERIMTIPI == "IADE" || gelenefatura.GONDERIMTIPI == "ISTISNA")
                        stokhareketi += istisna;
                    stokhareketi += @"<cac:TaxScheme>
            <cbc:Name>GERÇEK USULDE KATMA DEĞER VERGİSİ</cbc:Name>
            <cbc:TaxTypeCode>0015</cbc:TaxTypeCode>
          </cac:TaxScheme>
        </cac:TaxCategory>
      </cac:TaxSubtotal>
    </cac:TaxTotal>";
                    if (gelenefatura.GONDERIMTIPI == "TEVKIFAT")
                        stokhareketi += @"<cac:WithholdingTaxTotal>
			<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + item.TEVFIKATTUTAR.Replace(",", "") + @"</cbc:TaxAmount>
			<cac:TaxSubtotal>
				<cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + item.KDVTUTAR.Replace(",", "") + @"</cbc:TaxableAmount>
				<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + item.TEVFIKATTUTAR.Replace(",", "") + @"</cbc:TaxAmount>
				<cbc:Percent>" + item.TEVFIKATORAN + @"</cbc:Percent>
				<cac:TaxCategory>
					<cac:TaxScheme>
						<cbc:Name>" + item.TEVFIKAT + @"</cbc:Name>
						<cbc:TaxTypeCode>" + item.TEVFIKAT.Substring(0, 3) + @"</cbc:TaxTypeCode>
					</cac:TaxScheme>
				</cac:TaxCategory>
			</cac:TaxSubtotal>
	</cac:WithholdingTaxTotal>";
                    stokhareketi += @"   <cac:Item>
      <cbc:Name>" + kod + "/" + ad+" "+item.ACIKLAMA +@"</cbc:Name>
    </cac:Item>
    <cac:Price>
      <cbc:PriceAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + item.FIYAT.Replace(",", "") + @"</cbc:PriceAmount>
    </cac:Price>
  </cac:InvoiceLine>";

                    stoklar += stokhareketi;
               
              
               
                
            }



            var someString = @"<Invoice xmlns:cbc=""urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"" xmlns:cac=""urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"" xmlns:xades=""http://uri.etsi.org/01903/v1.3.2#"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:ext=""urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"" xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"" xsi:schemaLocation=""urn:oasis:names:specification:ubl:schema:xsd:Invoice-2 UBL-Invoice-2.1.xsd"" xmlns=""urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"">
   <ext:UBLExtensions>
    <ext:UBLExtension>
      <ext:ExtensionContent>
        <auto-generated-wildcard />
      </ext:ExtensionContent>
    </ext:UBLExtension>
  </ext:UBLExtensions>
  <cbc:UBLVersionID>2.1</cbc:UBLVersionID>
  <cbc:CustomizationID>TR1.2</cbc:CustomizationID>
  <cbc:ProfileID>" + senaryo + @"</cbc:ProfileID>
  <cbc:ID>" + fatno + @"</cbc:ID>
  <cbc:CopyIndicator>false</cbc:CopyIndicator>
  <cbc:UUID>" + uid + @"</cbc:UUID>
  <cbc:IssueDate>" + gelenefatura.TARIH.Substring(0, 10) + @"</cbc:IssueDate>
  <cbc:IssueTime>" + gelenefatura.TARIH.Substring(11, 5) + ":00" + @"</cbc:IssueTime>
  <cbc:InvoiceTypeCode>" + gelenefatura.GONDERIMTIPI + @"</cbc:InvoiceTypeCode>
  <cbc:Note>" + "Yanlız : " + yaziyaCevir(double.Parse(gelenefatura.ODENCEKTUTAR.Replace(",", "").Replace(".", ",")), gelenefatura.PARABIRIMI) + @"</cbc:Note>";
            if(parabirimifarklı)
                someString +="<cbc:Note>" + gelenefatura.TARIH.Substring(0, 10) +" Tarihinde 1 "+gelenefatura.PARABIRIMI+" : "+gelenefatura.PARABIRIMIKUR+" TRY olarak işlendi"+ @"</cbc:Note>";
  someString+=@"<cbc:Note>" + gelenefatura.NOT + @"</cbc:Note>
  <cbc:DocumentCurrencyCode>" + gelenefatura.PARABIRIMI + @"</cbc:DocumentCurrencyCode>
  <cbc:LineCountNumeric>"+gelenefatura.Hareketler.Count+@"</cbc:LineCountNumeric>
  <cac:AdditionalDocumentReference>
  <cbc:ID>"+uid+ @"</cbc:ID>
  <cbc:IssueDate>" + gelenefatura.TARIH.Substring(0, 10) + @"</cbc:IssueDate>
  <cbc:DocumentType>XSLT</cbc:DocumentType>
  <cbc:DocumentDescription>Otomatik üretilmiştir.</cbc:DocumentDescription>
  <cac:Attachment>
  <cbc:EmbeddedDocumentBinaryObject filename=""3992021000000003.xslt"" characterSetCode=""UTF-8"" encodingCode=""Base64"" mimeCode=""application/xml"">" + xslt+
@"</cbc:EmbeddedDocumentBinaryObject>
</cac:Attachment>
</cac:AdditionalDocumentReference>
";
            if(gelenefatura.GONDERIMTIPI=="SGK")
            { someString += "<cbc:AccountingCost>" + gelenefatura.ILAVEFATURATIPI + @"</cbc:AccountingCost>";

            }

            someString += @"<cbc:LineCountNumeric>1</cbc:LineCountNumeric>";
            if (senaryo == "EARSIVFATURA")
            {
                someString += earsivek;

            }
            if (!string.IsNullOrEmpty(gelenefatura.SIPARISNO) && !string.IsNullOrEmpty(gelenefatura.SIPARISTARIH))
                someString += siparis;
                
                someString += sgk;
            someString += @"  
       <cac:Signature>
        <cbc:ID schemeID=""VKN_TCKN"">" + firma.VERGINO + @"</cbc:ID>
        <cac:SignatoryParty>
            <cac:PartyIdentification>
                <cbc:ID schemeID=""" + schemeidfirma + @""">" + firma.VERGINO + @"</cbc:ID>
            </cac:PartyIdentification>
            <cac:PostalAddress>
                 <cbc:BuildingName>" + firma.ADRESI1 + @"</cbc:BuildingName>
        <cbc:CitySubdivisionName>" + firma.ILCE + @"</cbc:CitySubdivisionName>
        <cbc:CityName>" + firma.SEHIR + @"</cbc:CityName>
            
                <cbc:Region>ad</cbc:Region>
                <cac:Country>
                    <cbc:Name>Türkiye</cbc:Name>
                </cac:Country>
            </cac:PostalAddress>
        </cac:SignatoryParty>
        <cac:DigitalSignatureAttachment>
            <cac:ExternalReference>
                <cbc:URI>#Signature_" + fatno + @"</cbc:URI>
            </cac:ExternalReference>
        </cac:DigitalSignatureAttachment>
    </cac:Signature>";


            someString += @"<cac:AccountingSupplierParty>";
            if (!string.IsNullOrEmpty(firma.WEB_SITE))
                someString += "<cbc:WebsiteURI>"+firma.WEB_SITE+"</cbc:WebsiteURI>";
            someString+=@"
    <cac:Party>
      <cac:PartyIdentification>
        <cbc:ID schemeID=""" + schemeidfirma + @""">" + firma.VERGINO + @"</cbc:ID>
      </cac:PartyIdentification>
      <cac:PartyIdentification>
        <cbc:ID schemeID=""MERSISNO"">" + firma.MERSISNO + @"</cbc:ID>
      </cac:PartyIdentification>
      <cac:PartyIdentification>
        <cbc:ID schemeID=""HIZMETNO"">" + firma.HIZMETNO + @"</cbc:ID>
      </cac:PartyIdentification>
      <cac:PartyIdentification>
        <cbc:ID schemeID=""TICARETSICILNO"">" + firma.TICARETSICILNO + @"</cbc:ID>
      </cac:PartyIdentification>";
            if(schemeidfirma=="VKN")
            someString += @"
      <cac:PartyName>
        <cbc:Name>" + firma.KISAADI + @"</cbc:Name>
      </cac:PartyName>";
            someString+=@"
      <cac:PostalAddress>
        <cbc:BuildingName>" + firma.ADRESI1 + @"</cbc:BuildingName>
        <cbc:CitySubdivisionName>" + firma.ILCE + @"</cbc:CitySubdivisionName>
        <cbc:CityName>" + firma.SEHIR + @"</cbc:CityName>
        <cac:Country>
          <cbc:IdentificationCode>TR</cbc:IdentificationCode>
          <cbc:Name>Türkiye</cbc:Name>
        </cac:Country>
      </cac:PostalAddress>
      <cac:PartyTaxScheme>
        <cac:TaxScheme>
          <cbc:Name>" + firma.VERGIDAIRESI + @"</cbc:Name>
        </cac:TaxScheme>
      </cac:PartyTaxScheme>
      <cac:Contact>
      <cbc:Telephone>"+firma.TEL+@"</cbc:Telephone>       
      <cbc:Telefax>"+firma.FAX+@"</cbc:Telefax>
      <cbc:ElectronicMail>"+firma.E_MAIL+@"</cbc:ElectronicMail>
</cac:Contact>
";
                 

            if(schemeidfirma=="TCKN")     
                    someString += @"<cac:Person>
				<cbc:FirstName>"+firma.ADI+ @"</cbc:FirstName>
				<cbc:FamilyName>" + firma.SOYADI + @"</cbc:FamilyName>
			</cac:Person>";
               
            someString +=@"
    </cac:Party>
  </cac:AccountingSupplierParty>";
if(gelenefatura.GONDERIMSENARYO== "IHRACAT")
            {
                someString += @"<cac:AccountingCustomerParty>
		<cac:Party>
			<cac:PartyIdentification>
				<cbc:ID schemeID=""VKN"">1460415308</cbc:ID>
			</cac:PartyIdentification>
			<cac:PartyName>
				<cbc:Name>Gümrük ve Ticaret Bakanlığı</cbc:Name>
			</cac:PartyName>
			<cac:PostalAddress>
				<cbc:BuildingName>Üniversiteler Mahallesi Dumlupınar Bulvarı No:151</cbc:BuildingName>
				<cbc:CitySubdivisionName>Çankaya</cbc:CitySubdivisionName>
				<cbc:CityName>Ankara</cbc:CityName>
				<cac:Country>
					<cbc:Name>Türkiye</cbc:Name>
				</cac:Country>
			</cac:PostalAddress>
			<cac:PartyTaxScheme>
				<cac:TaxScheme>
					<cbc:Name>Ulus</cbc:Name>
				</cac:TaxScheme>
			</cac:PartyTaxScheme>
		</cac:Party>
	</cac:AccountingCustomerParty>
<cac:BuyerCustomerParty>
		<cac:Party>
			<cac:PartyIdentification>
				<cbc:ID schemeID=""PARTYTYPE"">EXPORT</cbc:ID>
			</cac:PartyIdentification>
			<cac:PartyName>
				<cbc:Name>"+cari.FIRMAUNVANI+@"</cbc:Name>
			</cac:PartyName>
			<cac:PostalAddress>
				<cbc:BuildingName>"+cari.ISADRES1+ @"</cbc:BuildingName>
				<cbc:CitySubdivisionName></cbc:CitySubdivisionName>
				<cbc:CityName></cbc:CityName>
				<cac:Country>
				<cbc:IdentificationCode>" + ulkekodu + @"</cbc:IdentificationCode>
					<cbc:Name>" + ulkeadi + @"</cbc:Name>
				</cac:Country>
			</cac:PostalAddress>
			<cac:PartyTaxScheme>
				<cac:TaxScheme>
					<cbc:Name></cbc:Name>
				</cac:TaxScheme>
			</cac:PartyTaxScheme>
			<cac:PartyLegalEntity>
				<cbc:RegistrationName>" + cari.FIRMAUNVANI+@"</cbc:RegistrationName>
				<cbc:CompanyID>"+cari.VERGINUMARASI+@"</cbc:CompanyID>
			</cac:PartyLegalEntity>
		</cac:Party>
	</cac:BuyerCustomerParty>";

            }
            else {
                if (gelenefatura.GONDERIMTIPI == "SGK")
                {
                  
                    someString += @"
<cac:AccountingCustomerParty>
<cac:Party>
<cac:PartyIdentification>
<cbc:ID schemeID=""VKN"">7750409379</cbc:ID>
</cac:PartyIdentification>
<cac:PartyIdentification>
<cbc:ID schemeID=""SUBENO""/>
</cac:PartyIdentification>
<cac:PartyName>
<cbc:Name>Sosyal Güvenlik Kurumu Başkanlığı</cbc:Name>
</cac:PartyName>
<cac:PostalAddress>
<cbc:BuildingName>Çankaya - Ankara</cbc:BuildingName>
<cbc:CitySubdivisionName>Çankaya</cbc:CitySubdivisionName>
<cbc:CityName>Ankara</cbc:CityName>
<cac:Country>
<cbc:IdentificationCode>TR</cbc:IdentificationCode>
<cbc:Name>Türkiye</cbc:Name>
</cac:Country>
</cac:PostalAddress>
<cac:PartyTaxScheme>
<cac:TaxScheme>
<cbc:Name>Çankaya</cbc:Name>
</cac:TaxScheme>
</cac:PartyTaxScheme>
<cac:Contact>
<cbc:Telephone/>
<cbc:ElectronicMail/>
</cac:Contact>
</cac:Party>
</cac:AccountingCustomerParty>";
             
                }
                else
                {
                    someString += @"<cac:AccountingCustomerParty>";
                    if (!string.IsNullOrEmpty(cari.WEB_SITE))
                        someString += "<cbc:WebsiteURI>" + cari.WEB_SITE + "</cbc:WebsiteURI>";
                    someString +=@"
    <cac:Party>
      <cac:PartyIdentification>
        <cbc:ID schemeID=""" + schemeid + @""">" + cari.VERGINUMARASI + @"</cbc:ID>
      </cac:PartyIdentification>";
        if (!(cari.VERGINUMARASI.Count() > 10))
                        someString += @"<cac:PartyName>
        <cbc:Name>" + cari.FIRMAUNVANI + @"</cbc:Name>
      </cac:PartyName>";
                    someString+=@"
      <cac:PostalAddress>
        <cbc:BuildingName>" + cari.ISADRES1 + @"</cbc:BuildingName>
        <cbc:CitySubdivisionName>" + cari.ISILCE + @"</cbc:CitySubdivisionName>
        <cbc:CityName>" + cari.ISIL + @"</cbc:CityName>
        <cac:Country>
          <cbc:IdentificationCode>TR</cbc:IdentificationCode>
          <cbc:Name>Türkiye</cbc:Name>
        </cac:Country>
      </cac:PostalAddress>
      <cac:PartyTaxScheme>
        <cac:TaxScheme>
          <cbc:Name>" + cari.VERGIDAIRESI + @"</cbc:Name>
        </cac:TaxScheme>
      </cac:PartyTaxScheme>
  <cac:Contact>
      <cbc:Telephone>" + cari.ISTEL + @"</cbc:Telephone>       
      <cbc:Telefax>" + cari.ISFAX + @"</cbc:Telefax>
      <cbc:ElectronicMail>" + cari.E_POSTA + @"</cbc:ElectronicMail>
</cac:Contact>"; if (cari.VERGINUMARASI.Count() > 10)
                    {

                        someString += @"<cac:Person>
				<cbc:FirstName>" + cari.ADI + @"</cbc:FirstName>
				<cbc:FamilyName>" + cari.SOYADI + @"</cbc:FamilyName>
			</cac:Person>";
                    }

                    someString += @" </cac:Party>
  </cac:AccountingCustomerParty>";

                }
            }
            if (!string.IsNullOrEmpty(gelenefatura.EKVERGINO))
                someString += kamu;

if(!string.IsNullOrEmpty(gelenefatura.ODEMEHESAPNO)&& !string.IsNullOrEmpty(gelenefatura.ODEMEKANALI) && !string.IsNullOrEmpty(gelenefatura.ODEMESEKLI))
            someString += odeme;

            someString += @"<cac:PaymentTerms>
		<cbc:PaymentDueDate>" + gelenefatura.ODEMETARIHI + @"</cbc:PaymentDueDate>
	</cac:PaymentTerms>";
            if (double.Parse(gelenefatura.ISKONTOTOPLAM.Replace(",", "").Replace(".", ",")) > 0)
                someString += @"
<cac:AllowanceCharge>
<cbc:ChargeIndicator>false</cbc:ChargeIndicator>
<cbc:Amount currencyID="""+gelenefatura.PARABIRIMI+@""">"+gelenefatura.ISKONTOTOPLAM.Replace(",", "") + @"</cbc:Amount>
</cac:AllowanceCharge>";
            if(gelenefatura.PARABIRIMI!="TRY")
            someString += @"
<cac:PricingExchangeRate>
<cbc:SourceCurrencyCode>" + gelenefatura.PARABIRIMI + @"</cbc:SourceCurrencyCode>
<cbc:TargetCurrencyCode>TRY</cbc:TargetCurrencyCode>
<cbc:CalculationRate>" + gelenefatura.PARABIRIMIKUR.Replace(",", ".") + @"</cbc:CalculationRate>
<cbc:Date>"+ gelenefatura.TARIH.Substring(0, 10) + @"</cbc:Date>
</cac:PricingExchangeRate>";
            someString += @"
  <cac:TaxTotal>
    <cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">"+(double.Parse(gelenefatura.KDV1.Replace(",", "").Replace(".",","))+ double.Parse(gelenefatura.KDV8.Replace(",", "").Replace(".", ",")) + double.Parse(gelenefatura.KDV18.Replace(",", "").Replace(".", ","))).ToString().Replace(",",".") + @"</cbc:TaxAmount>
    "; if (gelenefatura.KDV1 != "0.00")
                someString += kdv1text;
            if (gelenefatura.KDV8 != "0.00")
                someString += kdv8text;
            if (gelenefatura.KDV18 != "0.00")
                someString += kdv18text;
            if (gelenefatura.Hareketler.First().KDVORANI=="0"|| gelenefatura.Hareketler.First().KDVORANI == "0.00")
                someString += kdv0text;
            someString += @"      
  </cac:TaxTotal>";
            if (gelenefatura.GONDERIMTIPI == "TEVKIFAT") { 
                someString += @"<cac:WithholdingTaxTotal>
<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + (double.Parse(gelenefatura.TEVFIKAT3.Replace(",", "").Replace(".",","))+ double.Parse(gelenefatura.TEVFIKAT5.Replace(",", "").Replace(".", ","))+ double.Parse(gelenefatura.TEVFIKAT7.Replace(",", "").Replace(",", "").Replace(".", ","))+ double.Parse(gelenefatura.TEVFIKAT9.Replace(",", "").Replace(".", ","))).ToString().Replace(",",".")+ @"</cbc:TaxAmount>";
                if (gelenefatura.TEVFIKAT3 != "0.00")
                {
                    calcitonnumerictevfk += 1;
                       someString += @"<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.TEVFIKAT3.Replace(",", "") + @"</cbc:TaxAmount>
		<cac:TaxSubtotal>
			<cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" +((double.Parse(gelenefatura.TEVFIKAT3.Replace(",", "").Replace(".",",")) /30)*100).ToString().Replace(",",".")+ @"</cbc:TaxableAmount>
			<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.TEVFIKAT3.Replace(",", "") + @"</cbc:TaxAmount>
			<cbc:CalculationSequenceNumeric>"+ calcitonnumerictevfk + @"</cbc:CalculationSequenceNumeric>
			<cbc:Percent>30</cbc:Percent>
			<cac:TaxCategory>
				<cac:TaxScheme>
					<cbc:Name>" + gelenefatura.Hareketler.Where(x=>x.TEVFIKATORAN=="30").First().TEVFIKAT + @"</cbc:Name>
					<cbc:TaxTypeCode>" + gelenefatura.Hareketler.Where(x => x.TEVFIKATORAN == "30").First().TEVFIKAT.Substring(0, 3) + @"</cbc:TaxTypeCode>
				</cac:TaxScheme>
			</cac:TaxCategory>
		</cac:TaxSubtotal>";

                }
                if (gelenefatura.TEVFIKAT5 != "0.00")
                {
                    calcitonnumerictevfk += 1;
                    someString += @"
		<cac:TaxSubtotal>
			<cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + ((double.Parse(gelenefatura.TEVFIKAT5.Replace(",", "").Replace(".", ",")) / 50) * 100).ToString().Replace(",", ".") + @"</cbc:TaxableAmount>
			<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.TEVFIKAT5.Replace(",", "") + @"</cbc:TaxAmount>
			<cbc:CalculationSequenceNumeric>" + calcitonnumerictevfk + @"</cbc:CalculationSequenceNumeric>
			<cbc:Percent>50</cbc:Percent>
			<cac:TaxCategory>
				<cac:TaxScheme>
					<cbc:Name>" + gelenefatura.Hareketler.Where(x => x.TEVFIKATORAN == "50").First().TEVFIKAT + @"</cbc:Name>
					<cbc:TaxTypeCode>" + gelenefatura.Hareketler.Where(x => x.TEVFIKATORAN == "50").First().TEVFIKAT.Substring(0, 3) + @"</cbc:TaxTypeCode>
				</cac:TaxScheme>
			</cac:TaxCategory>
		</cac:TaxSubtotal>";

                }
                if (gelenefatura.TEVFIKAT7 != "0.00")
                {
                    calcitonnumerictevfk += 1;
                    someString += @"<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.TEVFIKAT7 + @"</cbc:TaxAmount>
		<cac:TaxSubtotal>
			<cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + ((double.Parse(gelenefatura.TEVFIKAT7.Replace(",", "").Replace(".", ",")) / 70) * 100).ToString().Replace(",", ".") + @"</cbc:TaxableAmount>
			<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.TEVFIKAT7 + @"</cbc:TaxAmount>
			<cbc:CalculationSequenceNumeric>" + calcitonnumerictevfk + @"</cbc:CalculationSequenceNumeric>
			<cbc:Percent>70</cbc:Percent>
			<cac:TaxCategory>
				<cac:TaxScheme>
					<cbc:Name>" + gelenefatura.Hareketler.Where(x => x.TEVFIKATORAN == "70").First().TEVFIKAT + @"</cbc:Name>
					<cbc:TaxTypeCode>" + gelenefatura.Hareketler.Where(x => x.TEVFIKATORAN == "70").First().TEVFIKAT.Substring(0, 3) + @"</cbc:TaxTypeCode>
				</cac:TaxScheme>
			</cac:TaxCategory>
		</cac:TaxSubtotal>";

                }
                if (gelenefatura.TEVFIKAT9 != "0.00")
                {
                    calcitonnumerictevfk += 1;
                    someString += @"<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.TEVFIKAT9.Replace(",", "") + @"</cbc:TaxAmount>
		<cac:TaxSubtotal>
			<cbc:TaxableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + ((double.Parse(gelenefatura.TEVFIKAT9.Replace(",", "").Replace(".", ",")) / 90) * 100).ToString().Replace(",", ".") + @"</cbc:TaxableAmount>
			<cbc:TaxAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.TEVFIKAT9 + @"</cbc:TaxAmount>
			<cbc:CalculationSequenceNumeric>" + calcitonnumerictevfk + @"</cbc:CalculationSequenceNumeric>
			<cbc:Percent>90</cbc:Percent>
			<cac:TaxCategory>
				<cac:TaxScheme>
					<cbc:Name>" + gelenefatura.Hareketler.Where(x => x.TEVFIKATORAN == "90").First().TEVFIKAT + @"</cbc:Name>
					<cbc:TaxTypeCode>" + gelenefatura.Hareketler.Where(x => x.TEVFIKATORAN == "90").First().TEVFIKAT.Substring(0, 3) + @"</cbc:TaxTypeCode>
				</cac:TaxScheme>
			</cac:TaxCategory>
		</cac:TaxSubtotal>";

                }
                someString +="</cac:WithholdingTaxTotal>";
            }
            someString += @"<cac:LegalMonetaryTotal>
    <cbc:LineExtensionAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.MALHIZMET.Replace(",","") + @"</cbc:LineExtensionAmount>
    <cbc:TaxExclusiveAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.MATRAH.Replace(",", "") + @"</cbc:TaxExclusiveAmount>
    <cbc:TaxInclusiveAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.ODENCEKTUTAR.Replace(",", "") + @"</cbc:TaxInclusiveAmount>
    <cbc:AllowanceTotalAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.ISKONTOTOPLAM.Replace(",", "") + @"</cbc:AllowanceTotalAmount>
    <cbc:PayableAmount currencyID=""" + gelenefatura.PARABIRIMI + @""">" + gelenefatura.ODENCEKTUTAR.Replace(",", "") + @"</cbc:PayableAmount>
  </cac:LegalMonetaryTotal>" + stoklar + "</Invoice>";
            string path = @"c:\ElkomCache\lastinvoice.xml";
        System.IO.File.WriteAllText(path,someString);
    

            var stringler = new string[1];

         
            stringler[0] = someString;

            var trans = db.Database.BeginTransaction();
            try
            {
                if (firma.ENTAGRATOR == FIRMA.entegratorler.EDM)
                {
                    tester.EDMLogin = firma.EFATKULLANICIADI;
                    tester.EDMPassw = firma.EFATSİFRE;
                    string sessionid = tester.EDMGetSession();
                    EFaturaEDMConnectorLibrary.draftmodel response = tester.SendDraftInvoice(someString,someString,1,false, fatno, cari.gibpk,firma.GIBBK,cari.E_POSTA,cari.VERGINUMARASI,firma.VERGINO,generateInvoiceID:false);
                    if (response.retval != "0")
                        return Json(response.retval);
  
                   
                }


                if (firma.ENTAGRATOR == FIRMA.entegratorler.HizliBilisim)
                {
                  

                   
                    HizliServiceClient client = new HizliServiceClient();
                    using (var scope = new OperationContextScope(client.InnerChannel))
                    {
                        var prop = new HttpRequestMessageProperty();
                        prop.Headers.Add("username", firma.EFATKULLANICIADI);
                        prop.Headers.Add("password", firma.EFATSİFRE);
                        OperationContext context = OperationContext.Current;
                        context.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;
                        var tpye = 1;
                        if (senaryo == "EARSIVFATURA")
                        {
                            tpye = 3;
                        }
                        var musteriadres = client.GetGibUserList(tpye, "PK", cari.VERGINUMARASI);

                        var random = new Random();
                        XmlDocument documenx = new XmlDocument();
                        var fatnı = "0012021" + random.Next(0, 999999999).ToString("D9");
                        fatno = fatnı;
                        documenx.LoadXml(someString);

                        List<InputDocument> liste = new List<InputDocument>();
                        liste.Add(new InputDocument
                        {
                            AppType = tpye,
                            DestinationIdentifier = cari.VERGINUMARASI,
                            DestinationUrn = pk,
                            SourceUrn = "urn:mail:defaultgb@hizlibilisimteknolojileri.net",
                            DocumentDate = gelenefatura.TARIH,
                            DocumentId = fatnı,
                            DocumentUUID = uid,
                            IsDraft = false,
                            IsDraftSend = false,
                            LocalId = "0" + fatnı,
                            UpdateDocument = false,
                            XmlContent = documenx.OuterXml
                        });
                        string postData = JsonConvert.SerializeObject(liste);
                        var ss = client.SendDocument(liste.ToArray());
                        if (ss[0].IsSucceeded)
                        {

                        }
                        else
                        {
                            Disposedb();
                            return Json(ss[0].Message);
                        }
                    }


                }
                if (degistir == false)
                {
                    var efatura = new EFATURA();
                    efatura.PK = pk;
                    string dir = Server.MapPath("~/EFATURALAR/" + firma.KISAADI);
                    // If directory does not exist, create it
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }


                    efatura.PK = pk;

                    System.IO.File.WriteAllText(Server.MapPath("~/EFATURALAR/" + firma.KISAADI + "/" + fatno + "_" + uid + ".xml"), someString);
                    efatura.FATURAURL = Server.MapPath("~/EFATURALAR/" + firma.KISAADI + "/" + fatno + "_" + uid + ".xml");
                    efatura.CreateDate = DateTime.Now;
                    efatura.CreateUserID = userid;
                    efatura.GONDERIMTURU = gelenefatura.GONDERIMSEKLI;
                    efatura.GIBFATURATURU = gelenefatura.GONDERIMTIPI + "-" + gelenefatura.GONDERIMSENARYO;
                    efatura.FATURATUTAR = double.Parse(gelenefatura.ODENCEKTUTAR.Replace(",", "").Replace(".", ",")) * double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ","));

                    efatura.TARIH = DateTime.Parse(gelenefatura.TARIH);
                    efatura.VKN = cari.VERGINUMARASI;
                    efatura.MUSTERI = cari.FIRMAUNVANI;

                    efatura.ETTN = uid;
                    efatura.FATURANO = fatno;
                    efatura.SeriNo = gelenefatura.SERINO;
                    efatura.Sıra = int.Parse(gelenefatura.FISNO);
                    efatura.STATU = "Gönderim(Taslak)";
                    efatura.TIP = CARI_HAREKET.tip.Çıkış;
                    efatura.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenefatura.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
                    efatura.CARIID = cari.ID;
                    db.EFATURA.Add(efatura);

                    db.SaveChanges();
                   
                    gelenefatura.CreateDate = DateTime.Now;
                    gelenefatura.CreateUserID = userid;
                    gelenefatura.S_MERKEZIID = efatura.S_MERKEZIID;
                    gelenefatura.EFATURAID = db.Entry(efatura).Entity.ID;
                    gelenefatura.FISNO = fatno;
                    gelenefatura.UUID = uid;
                    if(gelenefatura.IRSALIYELER!=null)
                    foreach (var item in gelenefatura.IRSALIYELER)
                        gelenefatura.IRSALIYELERARRAY += (item.ToString() + ",");

                    if (gelenefatura.SIPARISLER != null)
                        foreach (var item in gelenefatura.SIPARISLER)
                            gelenefatura.SIPARISLERARRAY += (item.ToString() + ",");

                    db.EFATURAIN.Add(gelenefatura);
                    db.SaveChanges();
                    var id = db.Entry(gelenefatura).Entity.ID;
                    foreach (var item in gelenefatura.Hareketler)
                    {
                        var ida = item.MALHIZMET;
                        var stok = db.STOK.Find(ida);
                        item.STOKKOD = stok.STOKKODU + "/" + stok.STOKAD;
                        item.CreateDate = DateTime.Now;
                        item.CreateUserID = userid;
                        item.EFATURAINID = id;
                     
                    }
                    


                    db.SaveChanges();
                }
                else
                {
                    var efatura = db.EFATURA.Where(x => x.ID==gelenefatura.ID).FirstOrDefault();
                    efatura.PK = pk;
                    string dir = Server.MapPath("~/EFATURALAR/" + firma.KISAADI);
                    // If directory does not exist, create it
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }


                    efatura.PK = pk;
                    if (System.IO.File.Exists( efatura.FATURAURL))
                    {

                        System.IO.File.Delete( efatura.FATURAURL);

                    }
                    System.IO.File.WriteAllText(Server.MapPath("~/EFATURALAR/" + firma.KISAADI + "/" + fatno + "_" + uid + ".xml"), someString);
                    efatura.FATURAURL = Server.MapPath("~/EFATURALAR/" + firma.KISAADI + "/" + fatno + "_" + uid + ".xml");
                    efatura.UpdateDate = DateTime.Now;
                    efatura.UpdateUserID = userid;
                    efatura.GONDERIMTURU = gelenefatura.GONDERIMSEKLI;
                    efatura.GIBFATURATURU = gelenefatura.GONDERIMTIPI + "-" + gelenefatura.GONDERIMSENARYO;
           
                    efatura.TARIH = DateTime.Parse(gelenefatura.TARIH);
                    efatura.VKN = cari.VERGINUMARASI;
                    efatura.MUSTERI = cari.FIRMAUNVANI;
                    efatura.FATURATUTAR = double.Parse(gelenefatura.ODENCEKTUTAR.Replace(",", "").Replace(".", ","))* double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ","));
                   
                    efatura.STATU = "Gönderim(Taslak)";
                    efatura.TIP = CARI_HAREKET.tip.Çıkış;
                    efatura.S_MERKEZIID = db.SORUMLULUK_MERKEZI.FirstOrDefault().ID;
                    efatura.CARIID = cari.ID;
                  

                    db.SaveChanges();
                    var efaturain = db.EFATURAIN.Where(x => x.EFATURAID == efatura.ID).FirstOrDefault();
                    db.EFATURAIN_HAREKET.RemoveRange(db.EFATURAIN_HAREKET.Where(x=>x.EFATURAINID==efaturain.ID).ToList());
                    db.EFATURAIN.Remove(efaturain);

                    db.SaveChanges();
                    gelenefatura.CreateDate = DateTime.Now;
                    gelenefatura.CreateUserID = userid;
                    gelenefatura.S_MERKEZIID = efatura.S_MERKEZIID;
                    gelenefatura.EFATURAID = efatura.ID;
                    if (gelenefatura.IRSALIYELER != null)
                        foreach (var item in gelenefatura.IRSALIYELER)
                            gelenefatura.IRSALIYELERARRAY += (item.ToString() + ",");

                    if (gelenefatura.SIPARISLER != null)
                        foreach (var item in gelenefatura.SIPARISLERARRAY)
                            gelenefatura.SIPARISLERARRAY += (item.ToString() + ",");

                  

                    db.EFATURAIN.Add(gelenefatura);


                    db.SaveChanges();

                    var id = db.Entry(gelenefatura).Entity.ID;
                    foreach (var item in gelenefatura.Hareketler)
                    {
                        var ida = item.MALHIZMET;
                        var stok = db.STOK.Find(ida);
                        item.STOKKOD = stok.STOKKODU + "/" + stok.STOKAD;
                        item.CreateDate = DateTime.Now;
                        item.CreateUserID = userid;
                        item.EFATURAINID = id;
                        item.DEPOID = item.DEPOID;
                    
                    }
                   
                    db.SaveChanges();

                }
              
                   
                trans.Commit();
                Disposedb();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Disposedb();
                return Json("Başarısız! " + ex.Message +" " + ex.InnerException);
            }
            Disposedb();
            return Json("Başarılı!", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult efaturagonderalis(EFATURAIN gelenefatura)
        {
         
            efaturachangestring();
          
            var anddb = new AndDB();

            bool degis = false;
            var firma = db.FIRMA.FirstOrDefault();
            var cari = db.CARI_BASLIK.Find(gelenefatura.CARIID);
         
            var parabirimifarklı = false;
            if (gelenefatura.PARABIRIMI != cari.PARABIRIMI)
                parabirimifarklı = true;
            var xsltham = "";

            gelenefatura.TIPI = CARI_HAREKET.tip.Giriş;





            var trans = db.Database.BeginTransaction();
            try
            {
                var id = 0;
           
                EFATURA efatura;
                if (gelenefatura.ID!=0) {
                    id = db.EFATURAIN.Where(x=>x.EFATURAID== gelenefatura.ID).FirstOrDefault().ID;
                    fisyenileefatura(id);
       
                    efatura = db.EFATURA.Find(gelenefatura.ID);
                    efatura.FATURATUTAR =double.Parse( gelenefatura.ODENCEKTUTAR.Replace(",","").Replace(".",","));
                    db.SaveChanges();
                    degis = true;
                } else
                {
                     efatura = new EFATURA();
                   
                    string dir = Server.MapPath("~/EFATURALAR/" + firma.KISAADI);
                    // If directory does not exist, create it
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }




                    efatura.CreateDate = DateTime.Now;
                    efatura.CreateUserID = userid;
                    efatura.GONDERIMTURU = gelenefatura.GONDERIMSEKLI;
                    efatura.GIBFATURATURU = gelenefatura.GONDERIMTIPI + "-" + gelenefatura.GONDERIMSENARYO;
                    efatura.FATURATUTAR = double.Parse(gelenefatura.ODENCEKTUTAR.Replace(",", "").Replace(".", ",")) * double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ","));

                    efatura.TARIH = DateTime.Parse(gelenefatura.TARIH);
                    efatura.VKN = cari.VERGINUMARASI;
                    efatura.MUSTERI = cari.FIRMAUNVANI;

                    efatura.ETTN = gelenefatura.UUID;
                    efatura.FATURANO = gelenefatura.FISNO;
                    efatura.SeriNo = "";
                    efatura.Sıra = 0;
                    efatura.STATU = "AlışFaturası(Elle Girilen)";
                    efatura.TIP = CARI_HAREKET.tip.Giriş;
                    efatura.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenefatura.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
                    efatura.CARIID = cari.ID;
                    db.EFATURA.Add(efatura);

                    db.SaveChanges();

                    gelenefatura.CreateDate = DateTime.Now;
                    gelenefatura.CreateUserID = userid;
                    gelenefatura.S_MERKEZIID = efatura.S_MERKEZIID;
                    gelenefatura.EFATURAID = db.Entry(efatura).Entity.ID;
                    gelenefatura.FISNO = gelenefatura.FISNO;
                    gelenefatura.TIPI =  CARI_HAREKET.tip.Giriş;

                    if (gelenefatura.IRSALIYELER != null)
                        foreach (var item in gelenefatura.IRSALIYELER)
                            gelenefatura.IRSALIYELERARRAY += (item.ToString() + ",");

                    if (gelenefatura.SIPARISLER != null)
                        foreach (var item in gelenefatura.SIPARISLERARRAY)
                            gelenefatura.SIPARISLERARRAY += (item.ToString() + ",");
                    db.EFATURAIN.Add(gelenefatura);
                    db.SaveChanges();
                    id = db.Entry(gelenefatura).Entity.ID;
                }


                  
            
                    foreach (var item in gelenefatura.Hareketler)
                    {
                        var ida = item.MALHIZMET;
                        var stok = db.STOK.Find(ida);
                        item.STOKKOD = stok.STOKKODU + "/" + stok.STOKAD;
                        item.CreateDate = DateTime.Now;
                        item.CreateUserID = userid;
                        item.EFATURAINID = id;
                    if (degis)
                        db.EFATURAIN_HAREKET.Add(item);
                    }



                    db.SaveChanges();
                 
                    

                    var carihareket = new CARI_HAREKET();

                    carihareket.cari = cari;
                    carihareket.TARIHSAAT = (DateTime)efatura.TARIH;
                    carihareket.TIPI = (CARI_HAREKET.tip)efatura.TIP;
                    if (string.IsNullOrEmpty(efatura.FATURANO))
                        carihareket.ISLEMNO = efatura.ETTN;
                    else { carihareket.ISLEMNO = efatura.FATURANO; }

                    carihareket.CARIKOD = carihareket.cari.CARIKOD;

                    carihareket.ACIKLAMA = "";

                    carihareket.VADE = efatura.TARIH;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new CARI_HAREKET();
                        if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).Count() > 0)
                        {
                            eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }



                        carihareket.TIPI = CARI_HAREKET.tip.Giriş;
                        carihareket.ALACAK = efatura.FATURATUTAR;
                        carihareket.DOVIZALACAK = (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ",")));
                        cari.TOPLAMDOVIZALACAK += (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ",")));
                        cari.TOPLAMALACAK += carihareket.ALACAK;
                        carihareket.BAKIYE = eskihareket.BAKIYE - efatura.FATURATUTAR;
                        carihareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE - (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ","))); ;
                        foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                        {
                            hareketz.BAKIYE += efatura.FATURATUTAR;
                            hareketz.DOVIZBAKIYE += carihareket.DOVIZBORC;
                        }




                    }
                    else
                    {

                        carihareket.TIPI = CARI_HAREKET.tip.Giriş;
                        carihareket.ALACAK = efatura.FATURATUTAR;
                        carihareket.DOVIZALACAK = (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ",")));
                        cari.TOPLAMDOVIZALACAK += (efatura.FATURATUTAR / double.Parse(gelenefatura.PARABIRIMIKUR.Replace(",", "").Replace(".", ",")));
                        cari.TOPLAMALACAK += carihareket.ALACAK;
                        carihareket.BAKIYE = cari.TOPLAMBORC - cari.TOPLAMALACAK;
                        carihareket.DOVIZBAKIYE = cari.TOPLAMDOVIZBORC - cari.TOPLAMDOVIZALACAK;


                    }


                    if (efatura.GONDERIMTURU == "EARSIVFATURA")
                    {
                        carihareket.ISLEMTURU = CARI_HAREKET.tür.EArşiv;
                    }
                    else
                    {
                        carihareket.ISLEMTURU = CARI_HAREKET.tür.EFatura;
                    }
                    carihareket.BAKIYE = carihareket.cari.BAKIYE;
                    carihareket.S_MERKEZIID = efatura.S_MERKEZIID;
                    carihareket.CreateDate = DateTime.Now;
                    carihareket.CreateUserID = userid;
                    db.CARI_HAREKET.Add(carihareket);
                    db.SaveChanges();
                    foreach (var item in gelenefatura.Hareketler)
                    {
                        if (item.GELIRGIDER == 1)
                        {
                            var gelirhareket = new GELIR_BORDRO_HAREKET();
                            var gelirid = int.Parse(item.STOKKOD);
                            var gelir = db.GELIR_BASLIK.Find(gelirid);
                            gelirhareket.GELIR_BASLIK = gelir;
                            gelirhareket.GELIR_BASLIKKID = gelirid;
                            gelirhareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
                            gelirhareket.PARABIRIMI = gelenefatura.PARABIRIMI;
                            gelirhareket.ACIKLAMA = gelenefatura.NOT;
                            gelirhareket.FISNO = gelenefatura.FISNO;
                            gelirhareket.S_MERKEZIID = gelenefatura.S_MERKEZIID;
                            gelirhareket.CreateDate = DateTime.Now;
                            gelirhareket.CreateUserID = userid;
                            gelirhareket.PARAKUR = double.Parse(gelenefatura.PARABIRIMIKUR.Replace(".", ","));
                            gelirhareket.TUTARI = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                            gelir.TOPLAMTUTAR += gelirhareket.TUTARI;
                            db.GELIR_BORDRO_HAREKET.Add(gelirhareket);
                        }
                        else if (item.GELIRGIDER == 2)
                        {
                            var giderhareket = new GIDER_BORDRO_HAREKET();
                            var giderid = int.Parse(item.STOKKOD);
                            var gider = db.GIDER_BASLIK.Find(giderid);
                            giderhareket.GIDER_BASLIK = gider;
                            giderhareket.GIDER_BASLIKID = giderid;
                            giderhareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
                            giderhareket.PARABIRIMI = gelenefatura.PARABIRIMI;
                            giderhareket.ACIKLAMA = gelenefatura.NOT;
                            giderhareket.FISNO = gelenefatura.FISNO;
                            giderhareket.S_MERKEZIID = gelenefatura.S_MERKEZIID;
                            giderhareket.CreateDate = DateTime.Now;
                            giderhareket.CreateUserID = userid;
                            giderhareket.PARAKUR = double.Parse(gelenefatura.PARABIRIMIKUR.Replace(".", ","));
                            giderhareket.TUTARI = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                            gider.TOPLAMTUTAR += giderhareket.TUTARI;
                            db.GIDER_BORDRO_HAREKET.Add(giderhareket);
                        }
                        else
                        {
                            var stokid = item.MALHIZMET;
                            var stok = db.STOK.Where(x => x.ID == stokid).FirstOrDefault();
                            var stokhareket = new STOK_HAREKET();
                            stokhareket.STOK = stok;

                            stokhareket.STOKKODU = stokhareket.STOK.STOKKODU;
                            stokhareket.CARIID = cari.ID;
                            stokhareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMADI == item.BIRIM).FirstOrDefault().ID;
                            stokhareket.CreateDate = DateTime.Now;
                            stokhareket.CreateUserID = userid;
                            stokhareket.BELGENO = gelenefatura.FISNO;
                            stokhareket.TARIH = DateTime.Parse(gelenefatura.TARIH);
                            stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.Fatura;
                            stokhareket.MIKTAR = double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                            stokhareket.FIYAT = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                            stokhareket.TIPI = gelenefatura.TIPI;
                            stokhareket.PARABIRIMI = gelenefatura.PARABIRIMI;
                            stokhareket.PARAKUR = double.Parse(gelenefatura.PARABIRIMIKUR.Replace(".", ","));
                        stokhareket.DEPOSUID = item.DEPOID;
                        if (DateTime.Now.CompareTo(stokhareket.TARIH.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new STOK_HAREKET();
                                if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).Count() > 0)
                                {
                                    eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU).OrderBy(x => x.TARIH).FirstOrDefault();


                                }
                                else { eskihareket.STOKMIKTAR = 0; }
                                if (gelenefatura.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    stok.MIKTAR += stokhareket.MIKTAR;
                                    stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR + (float)stokhareket.MIKTAR;

                                    foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU))
                                    {
                                        hareketz.STOKMIKTAR += (float)stokhareket.MIKTAR;

                                    }
                                }
                                else
                                {
                                    stok.MIKTAR -= stokhareket.MIKTAR;
                                    stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR - (float)stokhareket.MIKTAR;
                                    foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU))
                                    {
                                        hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;

                                    }
                                }


                            }
                            else
                            {
                                if (gelenefatura.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    stok.MIKTAR += stokhareket.MIKTAR;


                                }
                                else
                                {
                                    stok.MIKTAR -= stokhareket.MIKTAR;

                                }
                                stokhareket.STOKMIKTAR = float.Parse(stok.MIKTAR.ToString());
                            }
                            stokhareket.TUTAR = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                            //stokhareket.SONMALIYET = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));
               
                            stokhareket.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x=>x.ACIKLAMA==gelenefatura.SORUMLULUK_MERKEZI).FirstOrDefault().ID;


                            stokhareket.ACIKLAMA = gelenefatura.NOT;
                            db.STOK_HAREKET.Add(stokhareket);
                            if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                            
                                stok.HAMALISFIYAT = stokhareket.FIYAT;
                           
                            stok.TOPGIREN += double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));

                                //stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();

                            }
                            else
                            {

                                stok.HAMSATISFIYAT = stokhareket.FIYAT;
                           
                          

                            stok.TOPCIKAN += double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));

                            }
                        var depotoplam = db.STOK_DEPO_TOPLAM.Where(x => x.DEPOSUID == item.DEPOID).Where(x => x.STOKID == stok.ID).FirstOrDefault();
                        if (depotoplam == null)
                        {
                            var stoktoplam = new STOK_DEPO_TOPLAM();
                            stoktoplam.CreateDate = DateTime.Now;
                            stoktoplam.CreateUserID = 1;
                            stoktoplam.STOKID = stok.ID;
                            if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                stoktoplam.MIKTAR = stokhareket.MIKTAR;
                            }
                            else
                            {
                                stoktoplam.MIKTAR = stokhareket.MIKTAR;

                            }

                            stoktoplam.DEPOSUID = item.DEPOID;
                            db.STOK_DEPO_TOPLAM.Add(stoktoplam);

                        }
                        else
                        {
                            if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                if (depotoplam.MIKTAR == null)
                                    depotoplam.MIKTAR = stokhareket.MIKTAR;
                                depotoplam.MIKTAR += stokhareket.MIKTAR;
                            }
                            else
                            {
                                if (depotoplam.MIKTAR == null)
                                    depotoplam.MIKTAR = stokhareket.MIKTAR;
                                depotoplam.MIKTAR -= stokhareket.MIKTAR;

                            }

                        }


                        db.SaveChanges();


                    }


                    }
      
                    db.SaveChanges();

          


                trans.Commit();
                Disposedb();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Disposedb();
                return Json("Başarısız! " + ex.Message + " " + ex.InnerException);
            }
            Disposedb();
            return Json("Başarılı!", JsonRequestBehavior.AllowGet);
        }


        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
     [HttpPost]
     public JsonResult efaturadurumkontrol()
        {
            efaturachangestring();
            tester.EDMLogin = db.FIRMA.FirstOrDefault().EFATKULLANICIADI;
            tester.EDMPassw = db.FIRMA.FirstOrDefault().EFATSİFRE;
            string  statusDirection = "Entegrator";
            var kontroledilcekfaturalar = db.EFATURA.Where(x => x.STATU != "Gönderim(Taslak)"&&x.STATU!= "SUCCEED");
            foreach(var fatura in kontroledilcekfaturalar)
            {
                GetInvoiceStatusResponseINVOICE_STATUS getValue = tester.CheckInvoiceStatus(fatura.ETTN, statusDirection);

                if (getValue != null)
                {
                    string jsonstring = getValue.STATUS_DESCRIPTION.ToString();
                    fatura.STATU = jsonstring;
                   
                }
            
            }
            db.SaveChanges();
            Disposedb();
            return Json("Başarılı");
        }
        [HttpPost]
        public JsonResult efaturagoruntule(int id)
        {
            changestring();
            var fatura = db.EFATURA.Find(id);
          
             AndDB dba = new AndDB();
        
            XSD_UBLInvoice.InvoiceType invoice = new XSD_UBLInvoice.InvoiceType();

            StreamReader streamb = new StreamReader(fatura.FATURAURL);

            byte[] data = System.IO.File.ReadAllBytes(fatura.FATURAURL);
            MemoryStream stream = new MemoryStream(data);
         
            string fat = streamb.ReadToEnd();
            System.Xml.Serialization.XmlSerializer SerializerObj = new System.Xml.Serialization.XmlSerializer(typeof(XSD_UBLInvoice.InvoiceType));
            invoice = (XSD_UBLInvoice.InvoiceType)SerializerObj.Deserialize(stream);
         

            MemoryStream msa = new MemoryStream(invoice.AdditionalDocumentReference.FirstOrDefault().Attachment.EmbeddedDocumentBinaryObject.Value);
            StreamReader streama = new StreamReader(msa);
            string responseString = streama.ReadToEnd();
    
            Disposedb();
            return Json(CreateTransformation(responseString, fat), JsonRequestBehavior.AllowGet);
     
        }

        [HttpPost]
        public JsonResult efaturagoruntulegiden(int id)
        {
            changestring();
            var fatura = db.EFATURA.Find(id);
         
            var xsl= db.FIRMA.FirstOrDefault().XSLKODUFATURA;
            if (fatura.GONDERIMTURU== "e-Arsiv")
                 xsl = db.FIRMA.FirstOrDefault().XSLKODUEARSIV;
            StreamReader streama = new StreamReader(xsl);
            string responseString = streama.ReadToEnd();
            StreamReader streamb = new StreamReader(fatura.FATURAURL);
            string fat = streamb.ReadToEnd();
            streama.Close();
            streamb.Close();
            Disposedb();

            return Json(CreateTransformation(responseString, fat), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult efaturataslaksil(int id)
        {
            changestring();
            var fatura = db.EFATURA.Find(id);
            var kart = db.EFATURAIN.Where(X => X.EFATURAID == id).FirstOrDefault();
            var hareketleri = db.EFATURAIN_HAREKET.Where(X => X.EFATURAINID == kart.ID);
            db.EFATURAIN_HAREKET.RemoveRange(hareketleri);
            db.EFATURAIN.Remove(kart);
            db.EFATURA.Remove(fatura);
            db.SaveChanges();
            Disposedb();
            return Json("Başarılı!", JsonRequestBehavior.AllowGet);
        }
        private static string LoadTransformations(string context, XslCompiledTransform cc,string fatura)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(context)))
            {
                cc.Load(reader);
            }
           

            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(new StringReader(fatura)))
            {
                cc.Transform(reader, null, results);
            }
            return results.ToString();
        }

        private static string CreateTransformation(string contexts,string xml)
        {
            var cc = new XslCompiledTransform();
            var str = "";
            // Since our templates are most likely poorly written it takes
            // unusual amount of memory for a thread to handle the transformation
            // leaving the application throwing StackOverflow Exception.

            // This code creates different thread with 8MB stack size which actually succeeds in
            // transforming all the templates.

            // Creates custom thread and start it.  
            Thread t = new Thread(() => str = LoadTransformations(contexts, cc, xml), 8 * 1024 * 1024);
            t.Start();

            // Ensure our transformation thread is finished before doing anything.
            t.Join();

            return str;
        }
        public static string TransformXMLToHTML(string inputXml, string xsltString)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ProhibitDtd = false;
            settings.ValidationType = ValidationType.DTD;
         
            using (XmlReader reader = XmlReader.Create(new StringReader(xsltString), settings))
            {
                transform.Load(reader);
            }

            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(new StringReader(inputXml)))
            {
                transform.Transform(reader, null, results);
            }
            return results.ToString();
        }
        public class efaturaramodel
        {
            public int ID { get; set; }
            public CARI_BASLIK CARI { get; set; }

        public int CARIID { get; set; }
        public string GONDERIMTURU { get; set; }
        public string GIBFATURATURU { get; set; }
        public string VKN { get; set; }
        public string STATU { get; set; }
        public string TUTAR { get; set; }
        public string FATURANO { get; set; }
        public string ETTN { get; set; }
        public string MUSTERI { get; set; }
            public string CARIKOD { get; set; }
            
        public string TARIH { get; set; }
        public string FATURA { get; set; }
            public string STOKESLENDI  { get; set; }
            public string S_MERKEZI { get; set; }

        }


    [HttpPost]
        public JsonResult FisData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
        {
            if (sort == "GIRIS" || sort == "CIKIS")
                sort = "TOPLAMMASRAF";

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
            List<FaturaAraViewModel> hareketler = new List<FaturaAraViewModel>();
         


            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[3];

            aranacaklar[0] = "hareket.CARIKOD";
            aranacaklar[1] = "hareket.FATNO";
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




            var v = (from a in db.FATURA.Select(pr => new
            {
                hareket = pr,
                CARIADI = pr.CARI.FIRMAUNVANI,
           
                S_MERKEZI = pr.S_MERKEZI.ACIKLAMA
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


                var yenihareket = new FaturaAraViewModel();

                yenihareket.ID= item.hareket.ID;
                yenihareket.CARIADI = item.CARIADI;
                yenihareket.S_MERKEZI = item.S_MERKEZI;

                yenihareket.CARIKOD = item.hareket.CARIKOD;
                if (item.hareket.TIP == 1)
                {
                    yenihareket.GIRIS = item.hareket.TOPLAMSONTUTAR.ToString();
                    yenihareket.CIKIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-success"">Giriş</span>";
                }
                else
                {
                    yenihareket.CIKIS = item.hareket.TOPLAMSONTUTAR.ToString();
                    yenihareket.GIRIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-danger"">Çıkış</span>";

                }
                yenihareket.GENELTOPLAM = item.hareket.TOPLAMMIKTAR.ToString();
                yenihareket.TARIH = item.hareket.TARIH.Value.ToShortDateString();

                if (!string.IsNullOrEmpty(item.hareket.FATNO))
                    yenihareket.FATNO = item.hareket.FATNO;

           

                hareketler.Add(yenihareket);



            }

            Disposedb();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }
        [HttpPost]
        public JsonResult EFisData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
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
            List<efaturaramodel> hareketler = new List<efaturaramodel>();



            var zaman = new DateTime();
            var sonzaman = new DateTime();
            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[3];

            aranacaklar[0] = "MUSTERI";
            aranacaklar[1] = "hareket.FATURANO";
            aranacaklar[2] = "CARIKOD";



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
                    if (filterler[i].filtretipi == 5)
                    {

                        query += $"{  filterler[i].verismi }==(\"{ filterler[i].deger.ToLower() }\")";
                    }
                    if (filterler[i].filtretipi ==6)
                    {

                        query += $"(!{  filterler[i].verismi }.ToLower().Contains(\"{ filterler[i].deger.ToLower() }\"))";
                    }
                }

            query += ")";




            var v = (from a in db.EFATURA.Select(pr => new
            {
                hareket = pr,
                CARIKOD = pr.CARI.CARIKOD,
                MUSTERI = pr.CARI.FIRMAUNVANI,
                S_MERKEZI = pr.S_MERKEZI.ACIKLAMA
            }).Where(x => DbFunctions.TruncateTime(x.hareket.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);
           

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
       
            foreach(var item in data) {
                
                var efatura = new efaturaramodel();
               
                efatura.ID = item.hareket.ID;
                efatura.MUSTERI = item.MUSTERI;
                efatura.ETTN = item.hareket.ETTN;
                efatura.FATURA = item.hareket.FATURAURL;
                efatura.FATURANO = item.hareket.FATURANO;
                efatura.GIBFATURATURU = item.hareket.GIBFATURATURU;
                efatura.GONDERIMTURU = item.hareket.GONDERIMTURU;
                efatura.CARIKOD = item.CARIKOD;
                if (item.hareket.STOKESLENDI == true)
                    efatura.STOKESLENDI = "Eşlendi";
                else
                    efatura.STOKESLENDI = "Eşlenmedi";
                efatura.S_MERKEZI = item.S_MERKEZI;
                efatura.STATU = item.hareket.STATU;
                efatura.TARIH = item.hareket.TARIH.Value.ToShortDateString();
                efatura.TUTAR = item.hareket.FATURATUTAR.ToString();
                efatura.VKN = item.hareket.VKN;
                hareketler.Add(efatura);
            }
            Disposedb();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        public class kurfaturafismodel
        {


            public string CARIKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
         

        }

        public class faturafismodel
        {


            public string CARIKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string ODEMETARIHI { get; set; }
            public int[] IRSALIYELER { get; set; }
            public int[] SIPARISLER { get; set; }
            public int[] STOKFISLER { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
            public string DEPO { get; set; }
            public List<faturamodelhareket> gelenhareket { get; set; }

            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class efaturafismodel
        {
            public efaturafismodel()
            {

                this.gelenhareket = new List<efaturamodelhareket>();
            }

            public string SERINO { get; set; }
            public string GONDERIMTIPI { get; set; }
            public string GONDERIMSEKLI { get; set; }
            public string GONDERIMSENARYO { get; set; }
            public string UUID { get; set; }
            public string KOD { get; set; }

            
                  public string EKVERGINO { get; set; }
            public string MUKELLEFKODU { get; set; }

            public string MUKELEFADI { get; set; }
            public string DOSYANO { get; set; }
            public string ILAVEFATURATIPI { get; set; }

            public string MALHIZMET { get; set; }

            public string TEVFIKAT3 { get; set; }
            public string TEVFIKAT5 { get; set; }
            public string TEVFIKAT7 { get; set; }
            public string TEVFIKAT9 { get; set; }
            public string ISTISNA { get; set; }
            
            public string KDV1 { get; set; }
            public string KDV8 { get; set; }
            public string KDV18 { get; set; }
            public string MATRAH { get; set; }
            public int[] IRSALIYELER{ get; set; }
            public string TOPLAMKDV { get; set; }
            public string ISKONTOTOPLAM { get; set; }

          
            public string ODENCEKTUTAR { get; set; }

          
            public string CARIKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string ODEMETARIHI { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
            public string DEPO { get; set; }
            public string PARABIRIMI { get; set; }

            public string PARABIRIMIKUR { get; set; }

            public string ODEMESEKLI { get; set; }
            public string ODEMEKANALI { get; set; }
            public string ODEMEHESAPNO { get; set; }
            public string SIPARISNO { get; set; }
            public string SIPARISTARIH { get; set; }
            public List<efaturamodelhareket> gelenhareket { get; set; }

            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class efaturamodelhareket
        {

            public string STOKKOD { get; set; }
            public int GELIRGIDER { get; set; }
            public string MALHIZMET { get; set; }
            public string ACIKLAMA { get; set; }

            public string MIKTAR { get; set; }
            public string BIRIM { get; set; }
 
    

            public string FIYAT { get; set; }
            public string ISKONTO { get; set; }
            public string ISKONTOTUTAR { get; set; }
            public string KDVORANI { get; set; }
            public string KDVTUTAR { get; set; }

            public string TEVFIKAT { get; set; }
            public string TEVFIKATORAN { get; set; }
            public string TEVFIKATTUTAR{ get; set; }
            public string TESLIMSARTI { get; set; }
            public string GTIP { get; set; }
            public string ESYANINGONDERIMSEKLI { get; set; }
            public string ESYANINBULUNDUGUKAP { get; set; }
            public string KAPADET { get; set; }
            public string TOPLAM { get; set; }

        }
        public class faturamodelhareket
        {


            public int GELIRGIDER { get; set; }
            public int STOKID { get; set; }
            public int DEPOSUID { get; set; }

            public string ACIKLAMA { get; set; }

            public string MIKTAR { get; set; }
            public string BIRIM { get; set; }
            public string TUTAR { get; set; }
 
            public string ISKONTO { get; set; }

            public string PARABIRIMI { get; set; }

            public string PARABIRIMIKUR { get; set; }
            public string NETTUTAR { get; set; }
            public string KDVTUTAR { get; set; }
            public string REFERANS { get; set; }
            public string ID { get; set; }



        }
        public class FaturaHareketAraViewModel
        {
            public int ID { get; set; }
            public string TARIH { get; set; }
            public string BELGENO { get; set; }


            public string ISLEMTURU { get; set; }

            public string TIPI { get; set; }
            public string CARIKOD { get; set; }

            public string CARIAD { get; set; }
            public string MIKTAR { get; set; }
            public string BIRIM { get; set; }
            public string KDVLIFIYAT { get; set; }
       
     

            public string GIRISTOPLAM { get; set; }
            public string CIKISTOPLAM { get; set; }
            public string SBFTUTAR { get; set; }
        }
        public void veritesti()
        {



            double toplamtutar = 100;
            double toplamiktar = 10;

           
                var cari = new CARI_BASLIK();
            var caridi = db.CARI_BASLIK.Count();
            caridi += 1;
                cari.FIRMAUNVANI = "Test Carisi "+ caridi;
                cari.CARIKOD = "Test"+ caridi;
                cari.CreateDate = DateTime.Now;
                cari.CreateUserID = userid;
                cari.TOPLAMBORC = 0;
                cari.ISTEL = "232323232";
                cari.Mükelleftipi = CARI_BASLIK.mükelleftipi.Firma;
                cari.TOPLAMALACAK = 0;
                cari.TOPLAMDOVIZALACAK = 0;
                cari.TOPLAMDOVIZBORC = 0;
                cari.AKTIF = 1;
                db.CARI_BASLIK.Add(cari);
                db.SaveChanges();
                var carihareket = new CARI_HAREKET();
                carihareket.cari = db.CARI_BASLIK.Where(x => x.CARIKOD == cari.CARIKOD).FirstOrDefault();
                carihareket.CARIKOD = carihareket.cari.CARIKOD;
           
                carihareket.CreateDate = DateTime.Now;
                carihareket.CreateUserID = userid;
                carihareket.DOSYANO = "asdasd";
                carihareket.TARIHSAAT = DateTime.Now;
                carihareket.ISLEMTURU = CARI_HAREKET.tür.Devir;
                carihareket.KAYITSEKLI = CARI_HAREKET_AYRINTI.detay.Nakit;
                carihareket.VADE = DateTime.Now;
                carihareket.DOVIZALACAK = 0;
                carihareket.DOVIZBORC = 0;
                carihareket.ALACAK = 0;
                carihareket.BORC = 0;
                carihareket.BAKIYE = 0;
            carihareket.S_MERKEZIID = 1;
                carihareket.ACIKLAMA = "Devir Hareketi"; ;


                db.CARI_HAREKET.Add(carihareket);

                db.SaveChanges();




            if (db.STOK.Count() < 30)
            {

                for (int i = 0; i <= 30; i++)
                {
                    var stok = new STOK();
                    var stokid = db.STOK.Count();
                    stokid += 1;
                    stok.STOKAD = "Test Stoğu " + stokid;
                    stok.STOKKODU = "Test" + +stokid;
                    stok.CreateDate = DateTime.Now;
                    stok.CreateUserID = userid;
                    stok.HAMSATISFIYAT = 10;
                    stok.HAMALISFIYAT = 10;
                    stok.ALISISKONTOSU = 0;
                    stok.SATISISKONTOSU = 0;
                    stok.MIKTAR = 0;
                    stok.AKTIF = 1;
                    stok.KDV = 0;
                    stok.KDVDAHIL = 1;
                    //stok.MALIYETORT = 0;
                    stok.BIRIM = 39;
                    db.STOK.Add(stok);
                    db.SaveChanges();
                    var stokhareket = new STOK_HAREKET();
                    stokhareket.STOK = db.STOK.Where(x => x.STOKKODU == stok.STOKKODU).FirstOrDefault();
                    stokhareket.STOKKODU = stokhareket.STOK.STOKKODU;

                    stokhareket.CreateDate = DateTime.Now;
                    stokhareket.CreateUserID = userid;
                    stokhareket.BELGENO = "test";
                    stokhareket.TARIH = DateTime.Now;
                    stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.Devir;

                    stokhareket.MIKTAR = 0;
                    //stokhareket.SONMALIYET = 0;
                    stokhareket.TUTAR = 0;


                    stokhareket.ACIKLAMA = "Devir Hareketi"; ;
                    stokhareket.STOKMIKTAR = 0;
                    stokhareket.S_MERKEZIID = 1;
                    db.STOK_HAREKET.Add(stokhareket);

                    db.SaveChanges();



                }


            }





            for (int i = 0; i <= 10000; i++) {
                var fatura = new FATURA();

                fatura.CARI = db.CARI_BASLIK.Where(x=>x.CARIKOD==cari.CARIKOD).FirstOrDefault();
                fatura.CARIKOD =cari.CARIKOD;
                fatura.CreateDate = DateTime.Now;
                fatura.CreateUserID = userid;
                var fatid = db.FATURA.Count() ;
                fatid += 1;
                fatura.TIP = (int)1;
                fatura.FATNO = "USF" + fatid;
                fatura.ACIKLAMA = "Test Faturasıdır";
               fatura.S_MERKEZIID = db.SORUMLULUK_MERKEZI.FirstOrDefault().ID;
                fatura.TARIH = DateTime.Now;

                fatura.ODEMETARIHI = DateTime.Now; 

                var random = new Random();
           
              

                fatura.TOPLAMSONTUTAR = toplamtutar;
                fatura.TOPLAMMALIYET = 0;
                fatura.TOPLAMMIKTAR = toplamiktar;
                db.FATURA.Add(fatura);

                db.SaveChanges();
            
              



                db.SaveChanges();
                for(int a = 0; a < 10; a++)
                {
                    var stokhareketi = new STOK_HAREKET();
                    var stokida = random.Next(1, 30);
                    var stoka = db.STOK.Find(stokida);
                    var fishareket = new FATURA_HAREKET();
                    fishareket.FATURA = db.FATURA.Where(x => x.FATNO == fatura.FATNO).FirstOrDefault();
                    fishareket.Fatno = fatura.FATNO;
                    fishareket.BIRIM = "ADET";
                    fishareket.STOKID =stokida;
                    fishareket.ACIKLAMA = "Veri Testi İçin Üretildi";
                    fishareket.STOKKODU = stoka.STOKKODU;
                    fishareket.PARABIRIMI = "TL";
                    fishareket.PARAKUR = 1;
                    fishareket.MIKTAR = 1;
                    fishareket.TOPLAMFIYAT = 10;
                    fishareket.NETFIYAT = 10;
                    fishareket.KDVTUTARI = 10;


                    db.FATURA_HAREKET.Add(fishareket);

               
                    stokhareketi.STOK = db.STOK.Where(x => x.ID == stokida).FirstOrDefault();
                    stokhareketi.STOKKODU = stoka.STOKKODU;
                    stokhareketi.CARIID = cari.ID;
                    stokhareketi.CreateDate = DateTime.Now;
                    stokhareketi.CreateUserID = userid;
                    stokhareketi.BELGENO = fatura.FATNO;
                    stokhareketi.TARIH = DateTime.Now;
                    stokhareketi.ISLEMTURU = STOK_HAREKET.stoktur.Fatura;


                    stokhareketi.TIPI = CARI_HAREKET.tip.Giriş;
                    stokhareketi.MIKTAR = 1;

                    stokhareketi.TUTAR = 10;




                    stokhareketi.ACIKLAMA = "Fatura Veri Testi Hareketi"; ;


                    db.STOK_HAREKET.Add(stokhareketi);

                    db.SaveChanges();
                }

                var gelenveri = new faturafismodel();
                gelenveri.CARIKOD = cari.ID.ToString();
                gelenveri.NOT = "asdasd";
                gelenveri.ODEMETARIHI = DateTime.Now.ToString();
                gelenveri.FISNO = fatura.FATNO;
                gelenveri.TARIH = DateTime.Now.ToString();
                gelenveri.TIPI = CARI_HAREKET.tip.Giriş;
                var toplamdovuz = 100;

                var hareket = new CARI_HAREKET();
                hareket.cari = db.CARI_BASLIK.Where(x => x.CARIKOD == gelenveri.CARIKOD).FirstOrDefault();
                hareket.CARIKOD = hareket.cari.CARIKOD;
                hareket.CreateDate = DateTime.Now;

                hareket.CreateUserID = userid;
                hareket.ISLEMNO = fatura.FATNO;
                hareket.TARIHSAAT = fatura.TARIH.Value;
                hareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
         hareket.S_MERKEZIID = fatura.S_MERKEZIID;
                if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                {
                    var eskihareket = new CARI_HAREKET();
                    if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).Count() > 0)
                    {
                        eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).OrderBy(x => x.TARIHSAAT).FirstOrDefault();


                    }
                    else { eskihareket.BAKIYE = 0; }

                    if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                    {
                        hareket.TIPI = CARI_HAREKET.tip.Giriş;
                        hareket.ALACAK = toplamtutar;
                        hareket.DOVIZALACAK = 100;
                        cari.TOPLAMDOVIZALACAK += 100;
                        cari.TOPLAMALACAK += hareket.ALACAK;
                        hareket.BAKIYE = eskihareket.BAKIYE - toplamtutar;
                        hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE - 100;
                        foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                        {
                            hareketz.BAKIYE -= toplamtutar;
                            hareketz.DOVIZBAKIYE -= 100;
                        }


                    }
                    else
                    {
                        hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                        hareket.BORC = toplamtutar;
                        hareket.DOVIZBORC = toplamdovuz;
                        cari.TOPLAMDOVIZBORC = toplamdovuz;
                        cari.TOPLAMBORC += hareket.BORC;
                        hareket.BAKIYE = eskihareket.BAKIYE + toplamtutar;
                        hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE + toplamdovuz;
                        foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                        {
                            hareketz.BAKIYE -= toplamtutar;
                            hareketz.DOVIZBAKIYE -= toplamdovuz;
                        }


                    }


                }
                else
                {
                    if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                    {
                        hareket.TIPI = CARI_HAREKET.tip.Giriş;
                        hareket.ALACAK = toplamtutar;
                        hareket.DOVIZALACAK = toplamdovuz;
                        cari.TOPLAMDOVIZALACAK += toplamdovuz;
                        cari.TOPLAMALACAK += hareket.ALACAK;
                        hareket.BAKIYE = cari.BAKIYE;
                        hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;

                    }
                    else
                    {
                        hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                        hareket.BORC = toplamtutar;
                        hareket.DOVIZBORC = toplamdovuz;
                        cari.TOPLAMDOVIZBORC = toplamdovuz;
                        cari.TOPLAMBORC += hareket.BORC;
                        hareket.BAKIYE = cari.BAKIYE;
                        hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;



                    }
                }



                hareket.ACIKLAMA = gelenveri.NOT;

                hareket.VADE = DateTime.Parse(gelenveri.ODEMETARIHI);

                db.CARI_HAREKET.Add(hareket);

                db.SaveChanges();
            }



        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FATURAKART(modelimiz carifis)
        {
            changestring();

            if (degistirme == true)
            {
                return View(carifis.FATURA);
            }
            else
            {
                return Redirect("/Home");
            }
          
        }
        public class faturasablonmodel{
public   FATURA FATURA { get; set; }
            public List<FATURA_HAREKET> FATURA_HAREKETS { get; set; }
            public CARI_BASLIK CARI_BASLIK { get; set; }
            public FIRMA FIRMA { get; set; }


        }
        public ActionResult faturayazdır(int id)
        {
            changestring();
            var model = new faturasablonmodel();
            model.FATURA = db.FATURA.Find(id);
            model.CARI_BASLIK = db.CARI_BASLIK.Find(model.FATURA.CARIID);
            model.FIRMA = db.FIRMA.First();
            model.FATURA_HAREKETS = db.FATURA_HAREKET.Where(x => x.FATURAID == id).ToList();
            return View(model);
        }
        public ActionResult test()
        {
            changestring();
            veritesti();

            return View("Başarılı");
        }
        public ActionResult FATURAKART(int? id)
        {
            changestring();
            var model = new modelimiz();

            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.Hareket = new STOK_HAREKET();
            model.cARI_HAREKETs = new List<CARI_HAREKET>();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
     
            model.STOK_BIRIMLERs = anddb.STOK_BIRIMLER.Where(x => x.deleted == null).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.FATURA = db.FATURA.Include(x=>x.CARI).SingleOrDefault(x=>x.ID==id);
            model.FATURA_HAREKETLERİ = db.FATURA_HAREKET.Where(x => x.FATURAID == id).Include(x => x.STOK).ToList();




            if (degistirme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }

        }
   
        public ActionResult EFATURAKART(int? id,int? tip,int? carid)
        {
            efaturachangestring();
        

            var model = new modelimiz();
            var andb = new AndDB();
            var efatura = db.EFATURA.Find(id);
       
  
            var firma = new FIRMA();
            if (carid != null)
            {
                var cari = db.CARI_BASLIK.Find(carid);
                model.carikod = cari.ID.ToString();
                model.cariad = cari.CARIKOD + "/" + cari.FIRMAUNVANI;

            }
            if (id != null)
            {
                var cari = db.CARI_BASLIK.Find(efatura.CARIID);
                model.ID = id;
                model.cariad = cari.CARIKOD + "/" + cari.FIRMAUNVANI;
                model.carikod = cari.ID.ToString();
                model.EFATURAIN = db.EFATURAIN.Where(x => x.EFATURAID == id).FirstOrDefault();
                model.EFATURAIN_HAREKETs = db.EFATURAIN_HAREKET.Where(x => x.EFATURAINID == model.EFATURAIN.ID).ToList();

            }
            else
            {
                model.EFATURAIN =new EFATURAIN();
                model.EFATURAIN_HAREKETs = new List<EFATURAIN_HAREKET>();
                model.EFATURAIN.TIPI = (CARI_HAREKET.tip)tip;
            }
          
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.Hareket = new STOK_HAREKET();
            model.cARI_HAREKETs = new List<CARI_HAREKET>();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.DEPOs = db.STOK_DEPO.Where(x => x.deleted == null).ToList();

            model.STOK_BIRIMLERs = anddb.STOK_BIRIMLER.Where(x => x.deleted == null).ToList();
            model.ISTISNAKODLARIs = andb.ISTISNAKODLARI.ToList();
            model.TEVFIKATKODLARI = andb.TEVFIKATKODLARI.ToList();
            model.OZELMATRAHKODLARI = andb.OZELMATRAHKODLARI.ToList();
            model.TESLIMSARTLARI = andb.TESLIMSARTLARI.ToList();
            model.ESYANINBULUNDUGUKABINCINSI = andb.ESYANINBULUNDUGUKABINCINSI.ToList();
            model.ESYANINGONDERIMSEKLI = andb.ESYANINGONDERIMSEKLI.ToList();
            model.ULKELER = andb.ULKELER.ToList();
            model.EARSIVSERINO = firma.EARSIVSERINO;
            model.EFATURASERINO = firma.EFATSERINO;
            model.EARSIVSERINOLAR = db.EARSIV_SERI.ToList();
            model.EFATURASERINOLAR = db.FATURA_SERI.ToList();
          


            if (degistirme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public efaturafismodel faturaoku(string faturastring, int? type)
        {

            var fatura = new efaturafismodel();
            type = 1;
            var yenicari = new CARI_BASLIK();
            bool yenicariacb = false;
            bool yenicariaca = false;
          
            var cari = new CARI_BASLIK();
            XDocument doc = XDocument.Parse(faturastring);
            var cbc = "{urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2}";
            var cac = "{urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2}";

            foreach (XElement el in doc.Root.Elements())
            {
                if (el.Name == cbc + "ProfileID")
                    fatura.GONDERIMSENARYO = el.Value;
                if (el.Name == cbc + "ID")
                    fatura.FISNO = el.Value;
                if (el.Name == cbc + "UUID")
                    fatura.UUID = el.Value;
                if (el.Name == cbc + "IssueDate")
                    fatura.TARIH = el.Value;
                if (el.Name == cbc + "IssueTime")
                    fatura.TARIH += "T"+el.Value;
                if (el.Name == cbc + "InvoiceTypeCode")
                    fatura.GONDERIMTIPI = el.Value;
                if (el.Name == cbc + "Note")
                    fatura.NOT = el.Value;
                if (el.Name == cbc + "DocumentCurrencyCode")
                    fatura.PARABIRIMI = el.Value;
           
                if (el.Name == cac + "AccountingSupplierParty" && type == 1)
                {
                  


                    foreach (XElement element in el.Elements().First().Elements())
                    {


                        if (element.Name == cac + "PartyIdentification" && (element.Elements().First().Attributes().First().Value == "VKN" || element.Elements().First().Attributes().First().Value == "TCKN"))
                        {
                            var vergino = element.Elements().First().Value;
                            if (db.CARI_BASLIK.Where(x => x.VERGINUMARASI == vergino).ToList().Count() > 0)
                            {
                                cari = db.CARI_BASLIK.Where(x => x.VERGINUMARASI == vergino).FirstOrDefault();
                                fatura.CARIKOD = cari.CARIKOD;
                            }
                            else
                            {


                                fatura.TIPI = CARI_HAREKET.tip.Giriş;
                                yenicari.VERGINUMARASI = vergino;
                                yenicariaca = true;

                                if (element.Elements().First().Attributes().First().Value == "VKN")
                                    yenicari.Mükelleftipi = CARI_BASLIK.mükelleftipi.Firma;
                                else
                                    yenicari.Mükelleftipi = CARI_BASLIK.mükelleftipi.Sahıs;

                            }

                        }
                        if (element.Name == cac + "PartyName")
                        {
                            if (yenicari.Mükelleftipi == CARI_BASLIK.mükelleftipi.Firma)
                            yenicari.FIRMAUNVANI = element.Elements().First().Value;

                        }
                        if (element.Name == cac + "Person")
                        {
                            if (yenicari.Mükelleftipi == CARI_BASLIK.mükelleftipi.Sahıs) { 
                                yenicari.FIRMAUNVANI = element.Elements().First().Value+" "+ element.Elements().Last().Value;
                                yenicari.ADI = element.Elements().First().Value;
                                yenicari.SOYADI= element.Elements().Last().Value;
                            }
                        }
                        if (element.Name == cac + "PostalAddress")
                        {
                            if (element.Elements().Where(X => X.Name == cbc + "BuildingName").Count() > 0)
                                yenicari.ISADRES1 = element.Elements().Where(X => X.Name == cbc + "BuildingName").First().Value;
                            if (element.Elements().Where(X => X.Name == cbc + "CitySubdivisionName").Count() > 0)
                                yenicari.ISILCE = element.Elements().Where(X => X.Name == cbc + "CitySubdivisionName").First().Value;
                            if (element.Elements().Where(X => X.Name == cbc + "CityName").Count() > 0)
                                yenicari.ISIL = element.Elements().Where(X => X.Name == cbc + "CityName").First().Value;

                        }
                        if (element.Name == cac + "PartyTaxScheme")
                        {
                            yenicari.VERGIDAIRESI = element.Elements().First().Elements().First().Value;
                        }
                    }
                  



                }
         /*       if (el.Name == cac + "AccountingCustomerParty" && type == 2)
                {
                   
                    foreach (XElement element in el.Elements().First().Elements())
                    {
                    

                        if (element.Name == cac + "PartyIdentification" && (element.Elements().First().Attributes().First().Value == "VKN"|| element.Elements().First().Attributes().First().Value == "TCKN"))
                        {

                            var vergino = element.Elements().First().Value;
                            if (db.CARI_BASLIK.Where(x => x.VERGINUMARASI == vergino).ToList().Count() > 0)
                            {
                                cari = db.CARI_BASLIK.Where(x => x.VERGINUMARASI == vergino).FirstOrDefault();
                                fatura.CARIKOD = cari.CARIKOD;
                            }
                            else
                            {

                                if (element.Elements().First().Attributes().First().Value == "VKN")
                                    yenicari.Mükelleftipi = CARI_BASLIK.mükelleftipi.Firma;
                                else
                                    yenicari.Mükelleftipi = CARI_BASLIK.mükelleftipi.Sahıs;
                                fatura.TIPI = CARI_HAREKET.tip.Çıkış;
                                yenicari.VERGINUMARASI = vergino;
                                yenicariacb = true;



                            }

                        }
                       else
                        {
                            fatura.CARIKOD = "girmedi;";
                        }
                        if (element.Name == cac + "PartyName")
                        {
                            yenicari.FIRMAUNVANI = element.Elements().First().Value;

                        }
                        if (element.Name == cac + "PostalAddress")
                        {if(element.Elements().Where(X => X.Name == cbc + "BuildingName").Count()>0)
                            yenicari.ISADRES1 = element.Elements().Where(X => X.Name == cbc + "BuildingName").First().Value;
                            if (element.Elements().Where(X => X.Name == cbc + "CitySubdivisionName").Count() > 0)
                                yenicari.ISILCE = element.Elements().Where(X => X.Name == cbc + "CitySubdivisionName").First().Value;
                            if (element.Elements().Where(X => X.Name == cbc + "CityName").Count() > 0)
                                yenicari.ISIL = element.Elements().Where(X => X.Name == cbc + "CityName").First().Value;

                        }
                        if (element.Name == cac + "PartyTaxScheme")
                        {
                            yenicari.VERGIDAIRESI = element.Elements().First().Elements().First().Value;
                        }
                    }
                 
                }*/
                if (el.Name == cac + "PricingExchangeRate")
                {
                    fatura.PARABIRIMIKUR = el.Elements().Where(x => x.Name == cbc + "CalculationRate").First().Value;
                }
                if (fatura.PARABIRIMI == "TRY")
                {
                    fatura.PARABIRIMIKUR = "1";
                }
                if (el.Name == cac + "PaymentTerms")
                {
                    //fatura.ODEMETARIHI = el.Elements().First().Value;
                }
                if (el.Name == cac + "TaxTotal")
                {
                    foreach (var item in el.Elements())
                    {
                        if (item.Name == cac + "TaxSubtotal")
                        {
                            if (item.Elements().Where(x => x.Name == cbc + "Percent" && x.Value == "1").Count() > 0)
                            {
                                fatura.KDV1 = item.Elements().Where(x => x.Name == cbc + "TaxAmount").First().Value;

                            }
                            if (item.Elements().Where(x => x.Name == cbc + "Percent" && x.Value == "8").Count() > 0)
                            {
                                fatura.KDV8 = item.Elements().Where(x => x.Name == cbc + "TaxAmount").First().Value;

                            }
                            if (item.Elements().Where(x => x.Name == cbc + "Percent" && x.Value == "18").Count() > 0)
                            {
                                fatura.KDV18 = item.Elements().Where(x => x.Name == cbc + "TaxAmount").First().Value;

                            }
                            if (item.Elements().Where(x => x.Name == cbc + "TaxExemptionReasonCode").ToList().Count > 0)
                            {
                                fatura.ISTISNA = item.Elements().Where(x => x.Name == cbc + "TaxExemptionReason").First().Value;
                                fatura.KOD = item.Elements().Where(x => x.Name == cbc + "TaxExemptionReasonCode").First().Value;

                            }

                        }

                    }

                }
                if (el.Name == cac + "LegalMonetaryTotal")
                {
                    foreach (XElement element in el.Elements())
                    {
                        if (element.Name == cbc + "LineExtensionAmount")
                            fatura.MALHIZMET = element.Value;
                        if (element.Name == cbc + "TaxExclusiveAmount")
                            fatura.MATRAH = element.Value;
                        if (element.Name == cbc + "TaxInclusiveAmount")
                            fatura.ODENCEKTUTAR = element.Value;
                        if (element.Name == cbc + "AllowanceTotalAmount")
                            fatura.ISKONTOTOPLAM = element.Value;
                        if (element.Name == cbc + "PayableAmount")
                            fatura.ODENCEKTUTAR = element.Value;

                    }
                }
                if (el.Name == cac + "WithholdingTaxTotal")
                {
                    foreach (var item in el.Elements())
                    {
                        if (item.Name == cac + "TaxSubtotal")
                        {
                            if (item.Elements().Where(x => x.Name == cbc + "Percent" && x.Value == "30").Count() > 0)
                            {
                                fatura.TEVFIKAT3 = item.Elements().Where(x => x.Name == cbc + "TaxAmount").First().Value;

                            }
                            if (item.Elements().Where(x => x.Name == cbc + "Percent" && x.Value == "50").Count() > 0)
                            {
                                fatura.TEVFIKAT5 = item.Elements().Where(x => x.Name == cbc + "TaxAmount").First().Value;

                            }
                            if (item.Elements().Where(x => x.Name == cbc + "Percent" && x.Value == "70").Count() > 0)
                            {
                                fatura.TEVFIKAT7 = item.Elements().Where(x => x.Name == cbc + "TaxAmount").First().Value;

                            }
                            if (item.Elements().Where(x => x.Name == cbc + "Percent" && x.Value == "90").Count() > 0)
                            {
                                fatura.TEVFIKAT9 = item.Elements().Where(x => x.Name == cbc + "TaxAmount").First().Value;

                            }
                        }
                    }
                }
                if (el.Name == cac + "InvoiceLine")
                {

                    var hareket = new efaturamodelhareket();

                    foreach (XElement element in el.Elements())
                    {
                        if (element.Name == cbc + "InvoicedQuantity")
                        {
                            string kod = element.Attributes().First().Value;
                            hareket.MIKTAR = element.Value;
                            if (anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU == kod).ToList().Count > 0)
                                hareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU == kod).First().BIRIMADI;
                            else
                            {
                                hareket.BIRIM = "";

                            }



                        }
                        if (element.Name == cbc + "LineExtensionAmount")
                        {
                            hareket.TOPLAM = element.Value;

                        }
                        if (element.Name == cac + "AllowanceCharge")
                        {
if(element.Elements().Where(x => x.Name == cbc + "MultiplierFactorNumeric").Count() > 0) { 
                            hareket.ISKONTO = element.Elements().Where(x => x.Name == cbc + "MultiplierFactorNumeric").FirstOrDefault().Value;
                            hareket.ISKONTO = hareket.ISKONTO.Replace("0.", "");

                            hareket.ISKONTOTUTAR = element.Elements().Where(x => x.Name == cbc + "Amount").FirstOrDefault().Value;
                            }

                        }
                        if (element.Name == cac + "TaxTotal")
                        {
                            hareket.KDVTUTAR = element.Elements().First().Value;
                            foreach (XElement item in element.Elements().Where(x => x.Name == cac + "TaxSubtotal").Elements())
                            {
                                if (item.Name == cbc + "TaxAmount")
                                    hareket.KDVTUTAR = item.Value;
                                if (item.Name == cbc + "Percent")
                                {
                                    hareket.KDVORANI = item.Value;

                                }


                            }
                        }
                        if (element.Name == cac + "WithholdingTaxTotal")
                        {
                            foreach (XElement item in element.Elements().Where(x => x.Name == cac + "TaxSubtotal").Elements())
                            {
                                if (item.Name == cbc + "TaxAmount")
                                    hareket.TEVFIKATTUTAR = item.Value;
                                if (item.Name == cbc + "Percent")
                                    hareket.TEVFIKATORAN = item.Value;
                                if (item.Name == cac + "TaxCategory")
                                    hareket.TEVFIKAT = item.Elements().FirstOrDefault().Elements().Where(x => x.Name == cbc + "Name").FirstOrDefault().Value;
                            }
                        }
                        if (element.Name == cac + "Item")
                        {
                            hareket.MALHIZMET = element.Elements().Where(x => x.Name == cbc + "Name").First().Value;


                        }
                        if (element.Name == cac + "Price")
                        {
                            hareket.FIYAT = element.Elements().First().Value;

                        }

                    }


                    db.SaveChanges();
                    fatura.gelenhareket.Add(hareket);

                }
               
            }
          
            if (yenicariaca)
            {
                yenicari.AKTIF = 1;
                yenicari.CARIKOD = "CARİ" + (db.CARI_BASLIK.Count() + 1).ToString().PadLeft(4, '0');
                yenicari.CreateDate = DateTime.Now;
                yenicari.CreateUserID = userid;
                yenicari.TOPLAMALACAK = 0;
                yenicari.TOPLAMBORC = 0;
           
                yenicari.TOPLAMDOVIZBORC = 0;
                yenicari.TOPLAMDOVIZALACAK = 0;
                yenicari.PARABIRIMI = fatura.PARABIRIMI;
                fatura.CARIKOD = yenicari.CARIKOD;
                db.CARI_BASLIK.Add(yenicari);

                db.SaveChanges();
                var devirhareket = new CARI_HAREKET();
                devirhareket.cari = db.CARI_BASLIK.Where(x => x.CARIKOD == yenicari.CARIKOD).FirstOrDefault();

                devirhareket.CreateUserID = userid;
                devirhareket.CreateDate = DateTime.Now;
                devirhareket.TARIHSAAT = DateTime.Now;
                devirhareket.TIPI = CARI_HAREKET.tip.Devir;
                devirhareket.ISLEMTURU = CARI_HAREKET.tür.Devir;
                devirhareket.ACIKLAMA = "Devir";
                devirhareket.S_MERKEZIID = 1;
                devirhareket.CARIKOD = devirhareket.cari.CARIKOD;
                devirhareket.BORC = 0;
                devirhareket.ALACAK = 0;
                devirhareket.DOVIZBORC = 0;
                devirhareket.DOVIZALACAK = 0;
                devirhareket.DOVIZBAKIYE = 0;
                devirhareket.BAKIYE = 0;
                db.CARI_HAREKET.Add(devirhareket);
                db.SaveChanges();
            }
            if (yenicariacb)
            {
                yenicari.AKTIF = 1;
                yenicari.CARIKOD = "CARİ" + (db.CARI_BASLIK.Count() + 1).ToString().PadLeft(4, '0');
                yenicari.CreateDate = DateTime.Now;
                yenicari.CreateUserID = userid;
                yenicari.TOPLAMALACAK = 0;
                yenicari.TOPLAMBORC = 0;
                yenicari.TOPLAMDOVIZBORC = 0;
                yenicari.TOPLAMDOVIZALACAK = 0;
            
                yenicari.PARABIRIMI = fatura.PARABIRIMI;
                fatura.CARIKOD = yenicari.CARIKOD;
                db.CARI_BASLIK.Add(yenicari);

                db.SaveChanges();
                var devirhareket = new CARI_HAREKET();
                devirhareket.cari = db.CARI_BASLIK.Where(x => x.CARIKOD == yenicari.CARIKOD).FirstOrDefault();

                devirhareket.CreateUserID = userid;
                devirhareket.CreateDate = DateTime.Now;
                devirhareket.TARIHSAAT = DateTime.Now;
                devirhareket.TIPI = CARI_HAREKET.tip.Devir;
                devirhareket.ISLEMTURU = CARI_HAREKET.tür.Devir;
                devirhareket.ACIKLAMA = "Devir";
                devirhareket.S_MERKEZIID = 1;
                devirhareket.CARIKOD = devirhareket.cari.CARIKOD;
                devirhareket.BORC = 0;
                devirhareket.ALACAK = 0;
                devirhareket.DOVIZBORC = 0;
                devirhareket.DOVIZALACAK = 0;
                devirhareket.DOVIZBAKIYE = 0;
                devirhareket.BAKIYE = 0;
                db.CARI_HAREKET.Add(devirhareket);
                db.SaveChanges();
            }
            if (string.IsNullOrEmpty(fatura.CARIKOD))
            {
                yenicari.FIRMAUNVANI = "farklıcari";

                yenicari.VERGINUMARASI = "111111";
                yenicari.AKTIF = 1;
                yenicari.CARIKOD = "CARİ" + (db.CARI_BASLIK.Count() + 1).ToString().PadLeft(4, '0');
                yenicari.CreateDate = DateTime.Now;
                yenicari.CreateUserID = userid;
                yenicari.TOPLAMALACAK = 0;
                yenicari.TOPLAMBORC = 0;

                yenicari.TOPLAMDOVIZBORC = 0;
                yenicari.TOPLAMDOVIZALACAK = 0;
                yenicari.PARABIRIMI = fatura.PARABIRIMI;
                fatura.CARIKOD = yenicari.CARIKOD;
                db.CARI_BASLIK.Add(yenicari);

                db.SaveChanges();
                var devirhareket = new CARI_HAREKET();
                devirhareket.cari = db.CARI_BASLIK.Where(x => x.CARIKOD == yenicari.CARIKOD).FirstOrDefault();

                devirhareket.CreateUserID = userid;
                devirhareket.CreateDate = DateTime.Now;
                devirhareket.TARIHSAAT = DateTime.Now;
                devirhareket.TIPI = CARI_HAREKET.tip.Devir;
                devirhareket.ISLEMTURU = CARI_HAREKET.tür.Devir;
                devirhareket.ACIKLAMA = "Devir";
                devirhareket.S_MERKEZIID = 1;
                devirhareket.CARIKOD = devirhareket.cari.CARIKOD;
                devirhareket.BORC = 0;
                devirhareket.ALACAK = 0;
                devirhareket.DOVIZBORC = 0;
                devirhareket.DOVIZALACAK = 0;
                devirhareket.DOVIZBAKIYE = 0;
                devirhareket.BAKIYE = 0;
                db.CARI_HAREKET.Add(devirhareket);
                db.SaveChanges();
            }
            return fatura;
        }

        public ActionResult EFATURALISTESI(int tip)
        {
            efaturachangestring();

            var model = new modelimiz();

            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.Hareket = new STOK_HAREKET();
            model.cARI_HAREKETs = new List<CARI_HAREKET>();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.tip = tip;
            model.STOK_BIRIMLERs = anddb.STOK_BIRIMLER.Where(x => x.deleted == null).ToList();
            if (gorme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
       
        public ActionResult KURFARKIFATURASI()
        {

            changestring();

            var model = new modelimiz();

            model.FATURALAR = db.FATURA.Count();
            model.cARI_BASLIKs = db.CARI_BASLIK.Where(x => x.deleted == null && x.AKTIF == 1).ToList();
           
            if (ekleme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }

        public ActionResult FATURAOLUSTUR(string tip,int? carid)
        {
         
            changestring();
         
            var model = new modelimiz();

            model.FATURALAR = db.FATURA.Count();
            model.cARI_BASLIKs = db.CARI_BASLIK.Where(x => x.deleted == null && x.AKTIF == 1).ToList();
            model.STOKs = db.STOK.Where(x => x.deleted == null).ToList();
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.Hareket = new STOK_HAREKET();
            model.cARI_HAREKETs = new List<CARI_HAREKET>();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.FATURA_HAREKETLERİ = db.FATURA_HAREKET.Where(x => x.deleted == null).ToList();
            model.STOK_BIRIMLERs = anddb.STOK_BIRIMLER.Where(x => x.deleted == null).ToList();
            if (carid != null)
            {
                var cari = db.CARI_BASLIK.Find(carid);
                model.carikod = cari.ID.ToString();
                model.cariad = cari.CARIKOD + "/" + cari.FIRMAUNVANI;

            }
            if (ekleme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public ActionResult FATURALISTE()
        {
            changestring();

           
            var model = new modelimiz();
            model.cARI_BASLIKs = db.CARI_BASLIK.ToList();
            model.STOKs = db.STOK.ToList();


            if (gorme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
     
       public byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            fs.Close();
            return data;
        }
        public ActionResult ReadFile(string filePath)
        {
            string fullName = Server.MapPath("~" + filePath);

            byte[] fileBytes = GetFile(fullName);
            /* return File(
                 fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filePath);*/
            return File(fileBytes, "application/pdf");
        }
        public ActionResult DownloadFile(string files)
        {
            var filePath = files.Split(',');
     
            byte[] fileBytes;
            if (System.IO.File.Exists(@"C:\inetpub\wwwroot\assets\EFATURALAR\compressed_files.zip"))
                System.IO.File.Delete(@"C:\inetpub\wwwroot\assets\EFATURALAR\compressed_files.zip");
            using (FileStream zipFile = System.IO.File.Open(@"C:\inetpub\wwwroot\assets\EFATURALAR\compressed_files.zip", FileMode.Create))
            {

                using (var archive = new Archive())
                {
                    // Add files to the archive
                    foreach(var item in filePath)
                    archive.CreateEntry(item.Substring(19), Server.MapPath("~" + item));
                    // ZIP the files
                    archive.Save(zipFile, new ArchiveSaveOptions() { Encoding = Encoding.UTF8, ArchiveComment = "two files are compressed in this archive" });

                }
                zipFile.Close();
            }
            fileBytes = GetFile(@"C:\inetpub\wwwroot\assets\EFATURALAR\compressed_files.zip");

            return File(
                    fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, DateTime.Now.ToShortDateString()+".zip");



        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disposedb();
            }
            base.Dispose(disposing);
        }
    }
}
