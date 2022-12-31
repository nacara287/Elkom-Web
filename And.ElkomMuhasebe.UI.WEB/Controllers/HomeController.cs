using And.ElkomMuhasebe.Core.Model;
using And.ElkomMuhasebe.Core.Model.Entity.Admin;
using And.ElkomMuhasebe.Core.Model.Entity.FirmaDB;
using Npgsql;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{

    public class AndDBFactory : IDbContextFactory<FirmaBaseDB>
    {


        public Core.Model.FirmaBaseDB Create()
        {
            return new Core.Model.FirmaBaseDB();
        }
    }


    public class HomeController : Controller
    {
        AndDB db = new AndDB();
        FirmaBaseDB dba = new FirmaBaseDB();
        public ActionResult Json()
        {
            var serializer = new JavaScriptSerializer();

            // For simplicity just use Int32's max value.
            // You could always read the value from the config section mentioned above.
            serializer.MaxJsonLength = Int32.MaxValue;

            var resultData = new { Value = "foo", Text = "var" };
            var result = new ContentResult
            {
                Content = serializer.Serialize(resultData),
                ContentType = "application/json"
            };
            return result;
        }
        public void changestring()
        {
            if ((Session["LoginUser"] == null || Session["SeciliFirma"] == null) && (Session["LoginAltUser"] == null || Session["SeciliFirma"] == null)) { Response.Redirect("/Home"); }
            else
            {
                var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                if(dba.Database.Connection.State==ConnectionState.Open)
                    dba.Database.Connection.Close();
                dba.Database.Connection.Open();
                dba.Database.Connection.ChangeDatabase(firma.DatabaseName);

                dba.SaveChanges();

            }
        }
        public void bildirimsorgula()
        {
            changestring();
            var bilidirmler = new List<UYARILAR>();
            var kalangün = 3;

            var stokfis = dba.STOK_FIS.Where(x => DbFunctions.DiffDays(DateTime.Now, x.ODEME_TARIHI.Value) <= kalangün && x.deleted != 1).ToList();
            var fatura = dba.FATURA.Where(x => DbFunctions.DiffDays(DateTime.Now, x.ODEMETARIHI.Value) <= kalangün && x.deleted != 1).ToList();
            var irsaliye = dba.IRSALIYE.Where(x => DbFunctions.DiffDays(DateTime.Now, x.ODEMETARIHI.Value) <= kalangün && x.deleted != 1).ToList();
            var cekalınan = dba.CEKLER_ALINAN.Where(x => DbFunctions.DiffDays(DateTime.Now, x.VADE.Value) <= kalangün && x.deleted != 1).ToList();
            var cekverilen = dba.CEKLER_VERILEN.Where(x => DbFunctions.DiffDays(DateTime.Now, x.VADE.Value) <= kalangün && x.deleted != 1).ToList();
            var senetalınan = dba.SENETLER_ALINAN.Where(x => DbFunctions.DiffDays(DateTime.Now, x.VADE.Value) <= kalangün && x.deleted != 1).ToList();
            var senetverilen = dba.SENETLER_VERILEN.Where(x => DbFunctions.DiffDays(DateTime.Now, x.VADE.Value) <= kalangün && x.deleted != 1).ToList();
            foreach (var item in fatura)
            {
                var bildirim = new UYARILAR();
                bildirim.isim = item.FATNO + " Nolu Faturanın Ödeme Tarihi Yaklaşıyor!!";
                bildirim.url = "/FATURA/FATURAKART/" + item.ID;
                bildirim.aktif = true;
                bilidirmler.Add(bildirim);

            }

            foreach (var item in irsaliye)
            {
                var bildirim = new UYARILAR();
                bildirim.isim = item.FATURANO + " Nolu İrsaliyenin Ödeme Tarihi Yaklaşıyor!!";
                bildirim.url = "/IRSALIYE/IRSALIYEKART/" + item.ID;
                bildirim.aktif = true;
                bilidirmler.Add(bildirim);

            }

            foreach (var item in stokfis)
            {
                var bildirim = new UYARILAR();
                bildirim.isim = item.FISNO + " Nolu Stok Fişinin Ödeme Tarihi Yaklaşıyor!!";
                bildirim.url = "/STOK_HAREKET/STOKFISKART/" + item.ID;
                bildirim.aktif = true;
                bilidirmler.Add(bildirim);

            }
            foreach (var item in cekalınan)
            {
                var bildirim = new UYARILAR();
                bildirim.isim = item.PORTFOYNO + " Nolu Çekin Ödeme Tarihi Yaklaşıyor!!";
                bildirim.url = "/CEK/AlınanFisler";
                bildirim.aktif = true;
                bilidirmler.Add(bildirim);

            }
            foreach (var item in cekverilen)
            {
                var bildirim = new UYARILAR();
                bildirim.isim = item.PORTFOYNO + " Nolu Çekin Ödeme Tarihi Yaklaşıyor!!";
                bildirim.url = "/CEK/VerilenFisler";
                bildirim.aktif = true;
                bilidirmler.Add(bildirim);

            }
            foreach (var item in senetalınan)
            {
                var bildirim = new UYARILAR();
                bildirim.isim = item.PORTFOYNO + " Nolu Senetin Ödeme Tarihi Yaklaşıyor!!";
                bildirim.url = "/SENET/AlınanSenetler";
                bildirim.aktif = true;
                bilidirmler.Add(bildirim);

            }
            foreach (var item in senetverilen)
            {
                var bildirim = new UYARILAR();
                bildirim.isim = item.PORTFOYNO + " Nolu Senetin Ödeme Tarihi Yaklaşıyor!!";
                bildirim.url = "/SENET/VerilenSenetler";
                bildirim.aktif = true;
                bilidirmler.Add(bildirim);

            }
            foreach (var item in bilidirmler)
            {
                if (dba.UYARILAR.Where(x => x.url == item.url || x.isim == item.isim).Count() == 0)
                    dba.UYARILAR.Add(item);

            }

            dba.SaveChanges();
            Session["Bildirimler"] = dba.UYARILAR.ToList();
        }
        [HttpPost]
        public JsonResult panelkaydet()
        {

            if (Session["Panel"] == "fixed-header windows desktop")
            {
                Session["Panel"] = "fixed-header windows desktop js-focus-visible pace-done sidebar-visible menu-pin";

            }
            else
            {
                Session["Panel"] = "fixed-header windows desktop";
            }
            db.Dispose();
            return Json("Başarılı", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult fedbackgonder(string gelenhata)
        {
            changestring();
            var hata = new Fedback();
            hata.CreateDate = DateTime.Now;
            hata.CreateUserID = 1;
            hata.Mesaj = gelenhata;
            db.Fedbacks.Add(hata);
            db.SaveChanges();
            return Json("Başarılı");
        }




        [HttpPost]
        public JsonResult bildirimtemizle()
        {
            changestring();

            foreach (var item in dba.UYARILAR)
                item.aktif = false;
            dba.SaveChanges();
            Session["Bildirimler"] = dba.UYARILAR.ToList();
            return Json("Başarılı", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult bildirimsil(int id)
        {
            changestring();

            dba.UYARILAR.Find(id).okunmus = true;
            dba.SaveChanges();
            Session["Bildirimler"] = dba.UYARILAR.ToList();
            return Json("Başarılı", JsonRequestBehavior.AllowGet);
        }

        // GET: Home
        public ActionResult Index()
        {    /*Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"D:\şuankiişler\And.ElkomMuhasebe.UI.WEB\And.ElkomMuhasebe.UI.WEB\assets\EDMPortalKodListesi.xlsx");
          
            Excel._Worksheet xlWorksheetc = xlWorkbook.Sheets[8];
            Excel.Range xlRangec = xlWorksheetc.UsedRange;
            Excel._Worksheet xlWorksheetb = xlWorkbook.Sheets[7];
            Excel.Range xlRangeb = xlWorksheetb.UsedRange;
            Excel._Worksheet xlWorksheeta = xlWorkbook.Sheets[6];
            Excel.Range xlRangea = xlWorksheeta.UsedRange;
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[5];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            for (int i = 1; i <= xlRange.Rows.Count; i++)
            {
                var ozelmatrah = new TESLIMSARTLARI();
                ozelmatrah.CreateDate = DateTime.Now;
                ozelmatrah.CreateUserID = 1;
                ozelmatrah.TESLIMSARTKODU = xlRange.Cells[i, 1].Value2.ToString();
                ozelmatrah.ACIKLAMA = xlRange.Cells[i, 2].Value2.ToString();

                db.TESLIMSARTLARI.Add(ozelmatrah);
                //add useful things here!   

            }
            for (int i = 1; i <= xlRangea.Rows.Count; i++)
            {
                var ozelmatrah = new ESYANINBULUNDUGUKABINCINSI();
                ozelmatrah.CreateDate = DateTime.Now;
                ozelmatrah.CreateUserID = 1;
                ozelmatrah.KODU = xlRangea.Cells[i, 1].Value2.ToString();
                ozelmatrah.ACIKLAMA = xlRangea.Cells[i, 2].Value2.ToString();

                db.ESYANINBULUNDUGUKABINCINSI.Add(ozelmatrah);
                //add useful things here!   

            }
            for (int i = 1; i <= xlRangeb.Rows.Count; i++)
            {
                var ozelmatrah = new ESYANINGONDERIMSEKLI();
                ozelmatrah.CreateDate = DateTime.Now;
                ozelmatrah.CreateUserID = 1;
                ozelmatrah.KODU = xlRangeb.Cells[i, 1].Value2.ToString();
                ozelmatrah.ACIKLAMA = xlRangeb.Cells[i, 2].Value2.ToString();

                db.ESYANINGONDERIMSEKLI.Add(ozelmatrah);
                //add useful things here!   

            }
            for (int i = 1; i <= xlRangec.Rows.Count; i++)
            {
                var ozelmatrah = new ULKELER();
                ozelmatrah.CreateDate = DateTime.Now;
                ozelmatrah.CreateUserID = 1;
                ozelmatrah.KODU = xlRangec.Cells[i, 1].Value2.ToString();
                ozelmatrah.ADI = xlRangec.Cells[i, 2].Value2.ToString();

                db.ULKELER.Add(ozelmatrah);
                //add useful things here!   

            }
           
            db.SaveChanges();
            Excel.Application xlAppz = new Excel.Application();
            Excel.Workbook xlWorkbookz = xlAppz.Workbooks.Open(@"D:\şuankiişler\And.ElkomMuhasebe.UI.WEB\And.ElkomMuhasebe.UI.WEB\assets\EDMPortalKodListesi.xlsx");
            Excel._Worksheet xlWorksheetz = xlWorkbookz.Sheets[3];
            Excel.Range xlRangez = xlWorksheetz.UsedRange;
            for (int i = 1; i <= xlRangez.Rows.Count; i++)
            {
                var ozelmatrah = new OZELMATRAHKODLARI();
                ozelmatrah.CreateDate = DateTime.Now;
                ozelmatrah.CreateUserID = 1;
                ozelmatrah.OZELMATRAHKODU = xlRangez.Cells[i, 1].Value2.ToString();
                ozelmatrah.ACIKLAMA = xlRangez.Cells[i, 2].Value2.ToString();

                db.OZELMATRAHKODLARI.Add(ozelmatrah);
                //add useful things here!   

            }
            db.SaveChanges();
            Excel.Application xlAppx = new Excel.Application();
            Excel.Workbook xlWorkbookx = xlAppx.Workbooks.Open(@"D:\şuankiişler\And.ElkomMuhasebe.UI.WEB\And.ElkomMuhasebe.UI.WEB\assets\EDMPortalKodListesi.xlsx");
            Excel._Worksheet xlWorksheetx = xlWorkbookx.Sheets[2];
            Excel.Range xlRangex = xlWorksheetx.UsedRange;
            for (int i = 1; i <= xlRangex.Rows.Count; i++)
            {
                var tevfikat = new TEVFIKATKODLARI();
                tevfikat.CreateDate = DateTime.Now;
                tevfikat.CreateUserID = 1;
                tevfikat.TEVFIKATKODU = xlRangex.Cells[i, 1].Value2.ToString();
                tevfikat.ACIKLAMA = xlRangex.Cells[i, 2].Value2.ToString();

                db.TEVFIKATKODLARI.Add(tevfikat);
                //add useful things here!   

            }
            db.SaveChanges();
       
            Excel.Application xlAppn = new Excel.Application();
            Excel.Workbook xlWorkbookn = xlAppn.Workbooks.Open(@"D:\şuankiişler\And.ElkomMuhasebe.UI.WEB\And.ElkomMuhasebe.UI.WEB\assets\EDMPortalKodListesi.xlsx");
            Excel._Worksheet xlWorksheetn = xlWorkbookn.Sheets[1];
            Excel.Range xlRangen = xlWorksheetn.UsedRange;
            for (int i = 1; i <= xlRangen.Rows.Count; i++)
              {
                  var istisna = new ISTISNAKODLARI();
                  istisna.CreateDate = DateTime.Now;
                  istisna.CreateUserID = 1;
                  istisna.ISTISNAKODU =xlRangen.Cells[i, 1].Value2.ToString();
                  istisna.ACIKLAMA = xlRangen.Cells[i, 2].Value2.ToString();

                  db.ISTISNAKODLARI.Add(istisna);
                  //add useful things here!   

              }db.SaveChanges();

            
                Excel.Application xlAppv = new Excel.Application();
                Excel.Workbook xlWorkbookv = xlAppv.Workbooks.Open(@"D:\şuankiişler\And.ElkomMuhasebe.UI.WEB\And.ElkomMuhasebe.UI.WEB\assets\IL_ILCE_LISTESI.xls");
                Excel._Worksheet xlWorksheetv = xlWorkbookv.Sheets[1];
                Excel.Range xlRangev = xlWorksheetv.UsedRange;

                for (int i = 2; i <= xlRangev.Rows.Count; i++)
                {
                    var ililce = new ILILCE();
                    ililce.CreateDate = DateTime.Now;
                    ililce.CreateUserID = 1;
                    ililce.ilkodu = int.Parse(xlRangev.Cells[i, 1].Value2.ToString());
                    ililce.iladi = xlRangev.Cells[i, 2].Value2.ToString();
                    ililce.ilcekodu = int.Parse(xlRangev.Cells[i, 3].Value2.ToString());
                    ililce.ilceadi = xlRangev.Cells[i, 4].Value2.ToString();
                    ililce.aktif = true;
                    db.ILILCE.Add(ililce);
                    //add useful things here!   

                }
                Excel.Application xlAppab = new Excel.Application();
                Excel.Workbook xlWorkbookab = xlAppab.Workbooks.Open(@"D:\şuankiişler\And.ElkomMuhasebe.UI.WEB\And.ElkomMuhasebe.UI.WEB\assets\VD_LISTE.xlsx");
                Excel._Worksheet xlWorksheetab = xlWorkbookab.Sheets[1];
                Excel.Range xlRangeab = xlWorksheetab.UsedRange;

                for (int c = 1; c <= xlRangeab.Rows.Count; c++)
                {
                    var vergidairesi = new VERGIDAIRE();
                    vergidairesi.CreateDate = DateTime.Now;
                    vergidairesi.CreateUserID = 1;

                    vergidairesi.il = xlRangeab.Cells[c, 2].Value2.ToString();
                    vergidairesi.ilce = xlRangeab.Cells[c, 3].Value2.ToString();
                    vergidairesi.saymanlik = int.Parse(xlRangeab.Cells[c, 4].Value2.ToString());
                    vergidairesi.ismi = xlRangeab.Cells[c, 5].Value2.ToString();

                    db.VERGIDAIRE.Add(vergidairesi);
                    db.SaveChanges();
            
                }*/
            if ((Session["LoginUser"] == null || Session["SeciliFirma"] == null) && (Session["LoginAltUser"] == null || Session["SeciliFirma"] == null))
            {

                return Redirect("/Uye-Giris");




            }
            else
            {
                changestring();
                return View();

            }


        }
        public ActionResult Panel()
        {
            changestring();

            return View(dba);
        }
        [HttpPost]
        public JsonResult sendhistory(string url)
        {

            Session["History"] = url;


            return Json("Başarılı");
        }

        [Route("Uye-Giris")]
        public ActionResult Login()
        {
            if (Session["LoginUser"] != null)
            {
                return Redirect("/Home/");

            }
            return View();
        }
        [HttpPost]
        [Route("Uye-Giris")]
        public ActionResult Login(string username, string password)
        {



            var data = db.Users.Where(x => x.username == username && x.password == password && x.IsActive == true).ToList();
            if (data.Count == 1)
            {
                //doğru giriş
                Session["LoginUser"] = data.FirstOrDefault();
                var userfirma = Session["LoginUser"] as User;
                var firma = db.userFirmas.Where(x => x.Using == true && x.UserID == userfirma.ID).ToList();
                Session["SeciliFirma"] = firma.FirstOrDefault();
                Session["FirmaAdı"] = firma.FirstOrDefault().Companyname;
                bildirimsorgula();
                Session["Panel"] = "fixed-header windows desktop";
                Session["LastPage"] = "/Home/Panel";
                changestring();
                XmlReader xmlFile;
                DataSet ds = new DataSet();
                xmlFile = XmlReader.Create("http://www.tcmb.gov.tr/kurlar/today.xml", new XmlReaderSettings());
                ds.ReadXml(xmlFile);
                int i = 0;

                decimal b;

             
                for (i = 0; i <= ds.Tables[0].Rows.Count - 2; i++)
                { var kurkodu = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                    if (dba.KUR_BASLIK.Where(x => x.KURKODU == kurkodu).ToList().Count()>0)
                    {
                        var kur = dba.KUR_BASLIK.Where(x=>x.KURKODU== kurkodu).FirstOrDefault();
                
                    string dizi = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    if (dizi.Contains("."))
                    {
                        dizi = dizi.Replace(".", "");

                        b = Convert.ToDecimal(dizi);
                        kur.KUR = (decimal.ToDouble(b) / 10000);

                        dba.SaveChanges();

                        }
                    }
                  




                }
                dba.Dispose();

                return Redirect("/Home/");
            }
            else
            {
                var datab = db.altUsers.Where(x => x.username == username && x.password == password && x.Actıve == 1).ToList();

                if (datab.Count == 1)
                {
                    //doğru giriş
                    Session["LoginAltUser"] = datab.FirstOrDefault();
                    var userfirma = Session["LoginAltUser"] as AltUser;
                    var firma = db.userFirmas.Where(x => x.Using == true && x.UserID == userfirma.UserID).ToList();
                    Session["SeciliFirma"] = firma.FirstOrDefault();
                    Session["FirmaAdı"] = firma.FirstOrDefault().Companyname;
                    Session["Panel"] = "fixed-header windows desktop";
                    Session["LastPage"] = "/Home/Panel";
                    bildirimsorgula();
                    return Redirect("/Home");
                }
                else
                {
                    //yanlış giriş
                    ViewBag.Error = "Hatalı Kullanıcı Adı Veya Parola";

                    return View();
                }
            }

        }

        [HttpPost]
        [Route("Exit")]
        public ActionResult Exit()
        {
            Session["LoginUser"] = null;
            Session["LoginAltUser"] = null;
            return Redirect("/Home");
        }
        [HttpPost]
        [Route("FirmaSec")]
        public ActionResult FirmaSec()
        {
            string sirketismi = Request.Form["firmasecim"];
            var datab = db.userFirmas.Where(x => x.Using == true).ToList();
            if (datab.Count == 1)
            {
                datab.FirstOrDefault().Using = false;

            }
            var data = db.userFirmas.Where(x => x.Companyname == sirketismi).ToList();
            if (data.Count == 1)
            {
                Session["SeciliFirma"] = data.FirstOrDefault();

                int id = data.FirstOrDefault().ID;
                db.userFirmas.Find(id).Using = true;
            }

            db.SaveChanges();

            return Redirect("/UserFirmas");
        }

        [Route("Uye-Kayit")]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Kayit")]
        public ActionResult CreateUser(Core.Model.Entity.Admin.User entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUserID = 1;
            entity.IsActive = true;
            entity.IsAdmin = false;

            var data = db.Users.Where(x => x.username == entity.username || x.mail == entity.mail).ToList();

         
                if (data.Count == 0)
                {

                


                    var tarih = DateTime.Now.Year.ToString();
                    var userFirma = new UserFirma();
                    userFirma.Companyname = entity.kullanılanfirma;
                    userFirma.DatabaseName =entity.kullanılanfirma.ToLower().Trim().Replace(" ", "")+ DateTime.Now.Year;
                   userFirma.DatabaseName = Regex.Replace(userFirma.DatabaseName, @"[^A-Za-z0-9\s-]", "");
                    entity.kullanılanfirma = userFirma.DatabaseName;
                   
                    string databasename = userFirma.DatabaseName;
                    var firmalar = db.userFirmas.Where(x => x.Companyname == userFirma.Companyname).ToList();
                    if (firmalar.Count == 0)
                    {
                        db.Users.Add(entity);
                        db.SaveChanges();

                        userFirma.CreateDate = DateTime.Now;
                        userFirma.CreateUserID = 1;

                        userFirma.Using = true;
                        userFirma.UserID = entity.ID;

                        db.userFirmas.Add(userFirma);
                    db.SaveChanges();

                    NpgsqlConnection connection = new NpgsqlConnection(@"Host=185.131.49.20;Database=ElkomAdmin;Username=postgres;Password=onjbQOfcK088!yyo");

                        NpgsqlCommand command = new NpgsqlCommand("CREATE DATABASE " + databasename + ";", connection);




                        connection.Open();
                        command.ExecuteNonQuery();

                        connection.Close();

                        var config = new And.ElkomMuhasebe.Core.Model.Migrations.ConfigurationFirma();
                        FirmaBaseDB dba = new FirmaBaseDB();

                        config.ManualSeed(dba, @"Host=185.131.49.20; Database=" + databasename + ";Username=postgres;Password=onjbQOfcK088!yyo");


                    changestring();
                  








                    return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Error = "Bu firma ismi kullanılıyor lütfen başka bir isim seçiniz";


                        return View(entity);
                    }






                }
                else
                {
                    ViewBag.Error = "Bu kullanıcı adı ve ya eposta kullanılıyor";


                    return View(entity);
                }
           

        }


    }
}