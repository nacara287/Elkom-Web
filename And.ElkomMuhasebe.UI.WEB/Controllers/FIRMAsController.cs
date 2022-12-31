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
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Excel = Microsoft.Office.Interop.Excel;
namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class FIRMAsController : Controller
    {
        private FirmaBaseDB db = new FirmaBaseDB();
        public void changestring()
        {
            if ((Session["LoginUser"] == null || Session["SeciliFirma"] == null) && (Session["LoginAltUser"] == null || Session["SeciliFirma"] == null)) { Response.Redirect("/Home"); }
            else
            {
                if (Session["LoginAltUser"] != null)
                {
                    var alt = Session["LoginAltUser"] as And.ElkomMuhasebe.Core.Model.Entity.Admin.AltUser;
                    if (alt.görme.Contains("Firmalar"))
                    {
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }

                    }

                }
                else
                {
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
        // GET: FIRMAs
        public ActionResult Index()
        {
            changestring();
            return View(db.FIRMA.ToList());
        }

        // GET: FIRMAs/Details/5
        public ActionResult Details(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIRMA fIRMA = db.FIRMA.Find(id);
            if (fIRMA == null)
            {
                return HttpNotFound();
            }
            return View(fIRMA);
        }
        public class efaturabilgimodel
        {
            public string efaturausername { get; set; }
                public string efaturapassword { get; set; }
            public string vergino { get; set; }
            public string MERSISNO { get; set; }
            public string HIZMETNO { get; set; }
            public string TICARETSICILNO { get; set; }
            public string ADRESI1 { get; set; }
            public string ILCE { get; set; }
            public string SEHIR { get; set; }
            public string VERGIDAIRESI { get; set; }
            public string GIBBK { get; set; }
            
        }
        [HttpPost]    
        public ActionResult EFATURABILGILERI(efaturabilgimodel model)
        {
            changestring();
            var firma = db.FIRMA.First();
            firma.EFATKULLANICIADI = model.efaturausername;
            firma.EFATSİFRE = model.efaturapassword;
            firma.VERGINO = model.vergino;
            firma.VERGIDAIRESI = model.VERGIDAIRESI;
            firma.GIBBK = model.GIBBK;
            firma.HIZMETNO = model.HIZMETNO;
            firma.TICARETSICILNO = model.TICARETSICILNO;
            firma.MERSISNO = model.MERSISNO;
          
            db.Entry(firma).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        public ActionResult EFATURABILGILERI()
        {
            changestring();
            var yenimodel = new efaturabilgimodel();
            var firma = db.FIRMA.First();
            yenimodel.efaturausername = firma.EFATKULLANICIADI;
            yenimodel.efaturapassword = firma.EFATSİFRE;
            yenimodel.vergino = firma.VERGINO;
            yenimodel.VERGIDAIRESI=firma.VERGIDAIRESI;
            yenimodel.HIZMETNO = firma.HIZMETNO;
            yenimodel.MERSISNO = firma.MERSISNO;
            yenimodel.TICARETSICILNO = firma.TICARETSICILNO;
            yenimodel.MERSISNO = firma.MERSISNO;
            yenimodel.TICARETSICILNO = firma.TICARETSICILNO;
            yenimodel.ADRESI1 = firma.ADRESI1;
            yenimodel.ILCE = firma.ILCE;
            yenimodel.SEHIR = firma.SEHIR;
            yenimodel.GIBBK = firma.GIBBK;
           
            return View(yenimodel);
        }



        // GET: FIRMAs/Create
        public ActionResult Create()
        {
            changestring();
            return View();
        }
        [HttpPost]
        public JsonResult efaturaserinolustur(string serino)
        {
            changestring();
         
                var kod2 = new FATURA_SERI();
                kod2.CreateDate = DateTime.Now;
                kod2.CreateUserID = 0;
                kod2.SERI_NO = serino;
                db.FATURA_SERI.Add(kod2);
      


            db.SaveChanges();

            db.Dispose();
            return Json("Başarılı", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult earsivserinolustur(string serino)
        {
            changestring();

            var kod2 = new EARSIV_SERI();
            kod2.CreateDate = DateTime.Now;
            kod2.CreateUserID = 0;
            kod2.SERI_NO = serino;
            db.EARSIV_SERI.Add(kod2);



            db.SaveChanges();

            db.Dispose();
            return Json("Başarılı", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult efaturacheck(int carid)
        {
            changestring();
            var firma = db.FIRMA.FirstOrDefault();
            if(string.IsNullOrEmpty(firma.EFATKULLANICIADI)|| string.IsNullOrEmpty(firma.EFATSİFRE)||string.IsNullOrEmpty(firma.VERGINO)|| string.IsNullOrEmpty(firma.GIBBK)|| string.IsNullOrEmpty(firma.XSLKODUEARSIV) || string.IsNullOrEmpty(firma.XSLKODUFATURA))
            return Json("Lütfen Firma Efatura Bilgilerini  Kontrol Ediniz!", JsonRequestBehavior.AllowGet);
            else
            { var cari = db.CARI_BASLIK.Find(carid);

                if(string.IsNullOrEmpty(cari.VERGINUMARASI))
                    return Json("Lütfen Cari Kartındaki Vergi Numarasını Alanını Kontrol Ediniz!", JsonRequestBehavior.AllowGet);
                else
                {if(cari.VERGINUMARASI.Count()==11&&string.IsNullOrEmpty(cari.gibpk))
                        return Json("Lütfen Cari Kartındaki GİB PK Alanını Kontrol Ediniz!", JsonRequestBehavior.AllowGet);
                else
                        return Json("Başarılı", JsonRequestBehavior.AllowGet);
                }
            }
            db.Dispose();
        }

        // POST: FIRMAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FIRMAADI,KISAADI,ADRESI1,ADRESI2,SEHIR,VERGIDAIRESI,VERGINO,TEL,FAX,CARIYIL,CARIGRUPKODU,CARIKODUZUNLUK,STOKKODUZUNLUK,DOVIZLEISLEM,VADEFARKI,STOK_ACIKLAMA,TEL2,TEL3,FAX2,E_MAIL,WEB_SITE,TELKOD,TELDAHILI,PBIRIMI,DEVREDEN_KDV,ILKTARIH,SONTARIH,KURUMKODU,WEB_SIFRE,STOK_LISTE_ADET,FIFO_OTOMATIK_CALIS,CIROLU_SENET_DUSUM_GUN,CIROLU_CEK_DUSUM_GUN,EKSIYE_DUSMESIN,ZORUNLUMIKTAR,SMS_BASLIK,SMS_BORC_HATIRLATMA_TIPI,SMS_BORC_HATIRLATMA_GUN_SAYISI,SMS_TAHSILAT_GONDERIM_TIPI,SMS_FATURA_GONDERIM_TIPI,SMS_CEK_SENET_GONDERIM_TIPI,SMS_YONETICI_BIDIRIM_TIPI,SMS_YONETICI_BILDIRIM_1_SAAT,SMS_YONETICI_BILDIRIM_2_SAAT,YONETICI_TEL,SMS_DURUM,SMS_GONDERIM_TARIHI,SMS_ISLEM_TARIHI,KREDI_ASIMINA_IZIN_VER,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] FIRMA fIRMA)
        {
            changestring();
            if (ModelState.IsValid)
            {
               
                db.FIRMA.Add(fIRMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fIRMA);
        }


        public ActionResult VeriYukle()
        {
            

            return View();
        }
        static void ReadExcelFileSAX()
        {
     
        }

        [HttpPost] 
        public ActionResult VeriYuklee()
        {
            changestring();
            var anddb = new AndDB();
            HttpPostedFileBase cariexcel = Request.Files["CariExcellTablosu"];
            HttpPostedFileBase stokexcel = Request.Files["StokExcellTablosu"];
            if (System.IO.File.Exists(Server.MapPath("~/Assets/tasarimlar/cariexcel.xlsx")))
            {

                System.IO.File.Delete(Server.MapPath("~/Assets/tasarimlar/cariexcel.xlsx"));

            }
            if (System.IO.File.Exists(Server.MapPath("~/Assets/tasarimlar/stokexcel.xlsx")))
            {

                System.IO.File.Delete(Server.MapPath("~/Assets/tasarimlar/stokexcel.xlsx"));

            }
            cariexcel.SaveAs(Server.MapPath("~/Assets/tasarimlar/cariexcel.xlsx"));
            stokexcel.SaveAs(Server.MapPath("~/Assets/tasarimlar/stokexcel.xlsx"));
            string fileName = Server.MapPath("~/Assets/tasarimlar/cariexcel.xlsx");
            string fileNameb = Server.MapPath("~/Assets/tasarimlar/stokexcel.xlsx");
            if (cariexcel.ContentLength > 0) { 
            SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false);
            SharedStringTable sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;
            string cellValue = null;

            foreach (WorksheetPart worksheetPart in document.WorkbookPart.WorksheetParts)
            {
                foreach (SheetData sheetData in worksheetPart.Worksheet.Elements<SheetData>())
                {
                    if (sheetData.HasChildren)
                    {
                        int z = 0;
                        foreach (Row row in sheetData.Elements<Row>())
                        {
                            if (z > 0) { 
                            var cari = new CARI_BASLIK();
                            int i = 0;
                           


                            foreach (Cell cell in row.Elements<Cell>())
                            {

                                var val = "";

                             
                                cellValue = cell.InnerText;
                                if (cell.DataType != null) { 
                                if (cell.DataType == CellValues.SharedString)
                                {
                                        val = sharedStringTable.ElementAt(Int32.Parse(cellValue)).InnerText;
                                
                                    }
                                    }
                                    else
                                {
                                    val =  cellValue;
                                }
                                switch (i)
                                {
                                    case 0: cari.FIRMAUNVANI = val;break;
                                    case 1:cari.CARIKOD = val; break;
                                    case 2: cari.VERGINUMARASI = val; break;
                                    case 3: cari.ISTEL = val; break;
                                    case 4: cari.ISIL = val; break;
                                    case 5: cari.ISILCE = val; break;
                                    case 6: cari.ISADRES1 = val; break;
                                    case 7: cari.PARABIRIMI = val; break;
                                    case 8: cari.TOPLAMALACAK = double.Parse(val); break;
                                    case 9: cari.TOPLAMBORC = double.Parse(val); break;
                                }
                                  

                                i += 1;
                            }

                            cari.CreateDate = DateTime.Now;
                            cari.CreateUserID = 0;
                            cari.TOPLAMBORC = 0;

                            if (cari.VERGINUMARASI.Count() > 10)
                                cari.Mükelleftipi = CARI_BASLIK.mükelleftipi.Sahıs;
                            else
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
                            carihareket.CreateUserID = 0;
                            carihareket.DOSYANO = "000";
                            carihareket.TARIHSAAT = DateTime.Now;
                            carihareket.ISLEMTURU = CARI_HAREKET.tür.Devir;
                            carihareket.KAYITSEKLI = CARI_HAREKET_AYRINTI.detay.Nakit;
                            carihareket.VADE = DateTime.Now;

                            carihareket.DOVIZALACAK = 0;
                            carihareket.DOVIZBORC = 0;


                            carihareket.ALACAK = cari.TOPLAMALACAK;
                            carihareket.BORC = cari.TOPLAMBORC;
                            carihareket.BAKIYE = cari.BAKIYE;
                            carihareket.S_MERKEZIID = 1;
                            carihareket.ACIKLAMA = "Devir Hareketi";


                            db.CARI_HAREKET.Add(carihareket);

                            db.SaveChanges();
                            }
                            z += 1;
                        }
                      
                    }
                }
            }
            document.Close();
            }
            if (stokexcel.ContentLength > 0)
            {
                SpreadsheetDocument documenta = SpreadsheetDocument.Open(fileNameb, false);
                SharedStringTable sharedStringTablea = documenta.WorkbookPart.SharedStringTablePart.SharedStringTable;
                string cellValuea = null;

                foreach (WorksheetPart worksheetPart in documenta.WorkbookPart.WorksheetParts)
                {
                    foreach (SheetData sheetData in worksheetPart.Worksheet.Elements<SheetData>())
                    {
                        if (sheetData.HasChildren)
                        {
                            int z = 0;
                            foreach (Row row in sheetData.Elements<Row>())
                            {
                                if (z > 0)
                                {

                                    int i = 0;
                                    var stok = new STOK();
                                    string birim = "";

                                    foreach (Cell cell in row.Elements<Cell>())
                                    {

                                        var val = "";


                                        cellValuea = cell.InnerText;
                                        if (cell.DataType != null)
                                        {
                                            if (cell.DataType == CellValues.SharedString)
                                            {
                                                val = sharedStringTablea.ElementAt(Int32.Parse(cellValuea)).InnerText;

                                            }
                                        }
                                        else
                                        {
                                            val = cellValuea;
                                        }
                                        switch (i)
                                        {
                                            case 0: stok.STOKAD = val; break;
                                            case 1: stok.STOKKODU = val; break;
                                            case 2: stok.MIKTAR = double.Parse(val); break;
                                            case 3: birim = val; break;
                                            case 4: stok.KDV = int.Parse(val); break;
                                            case 5: stok.HAMSATISFIYAT = double.Parse(val); break;
                                            case 6: stok.HAMALISFIYAT = double.Parse(val); break;

                                        }


                                        i += 1;
                                    }




                                    stok.CreateDate = DateTime.Now;

                                    if (anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU.ToUpper() == birim.ToUpper()).Count() > 0)
                                        stok.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMKODU.ToUpper() == birim.ToUpper()).FirstOrDefault().ID;

                                    stok.CreateUserID = 1;

                                    stok.ALISISKONTOSU = 0;
                                    stok.SATISISKONTOSU = 0;
                                    stok.PARABIRIMI = "TRY";
                                    stok.AKTIF = 1;

                                    stok.KDVDAHIL = 1;
                                 

                                    db.STOK.Add(stok);
                                    db.SaveChanges();
                                    var stokhareket = new STOK_HAREKET();
                                    stokhareket.STOK = db.STOK.Where(x => x.STOKKODU == stok.STOKKODU).FirstOrDefault();
                                    stokhareket.STOKKODU = stokhareket.STOK.STOKKODU;

                                    stokhareket.CreateDate = DateTime.Now;
                                    stokhareket.CreateUserID = 1;
                                    stokhareket.BELGENO = "";
                                    stokhareket.TARIH = DateTime.Now;
                                    stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.Devir;

                                    stokhareket.MIKTAR = (double)stok.MIKTAR;
                                    //stokhareket.SONMALIYET = 0;
                                    stokhareket.TUTAR = 0;


                                    stokhareket.ACIKLAMA = "Devir Hareketi"; ;
                                    stokhareket.STOKMIKTAR = float.Parse(stok.MIKTAR.ToString());
                                    stokhareket.S_MERKEZIID = 1;
                                    db.STOK_HAREKET.Add(stokhareket);

                                    db.SaveChanges();
                                }
                                z += 1;
                            }

                        }
                    }
                }
                documenta.Close();
            }
            db.Dispose();
            anddb.Dispose();
            return Redirect("~/Home/");
        }

        // GET: FIRMAs/Edit/5
        public ActionResult Edit(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIRMA fIRMA = db.FIRMA.Find(id);
            if (fIRMA == null)
            {
                return HttpNotFound();
            }
            ViewBag.Efatseriler = db.FATURA_SERI.ToList();
            ViewBag.Earsivseriler = db.EARSIV_SERI.ToList();
            db.Dispose();

            return View(fIRMA);
        }

        // POST: FIRMAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FIRMA fIRMA)
        {
            changestring();
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["FaturaXslt"];
                HttpPostedFileBase filea = Request.Files["ArsivXslt"];
                HttpPostedFileBase filex = Request.Files["FirmaResim"];
                db.Entry(fIRMA).State = EntityState.Modified;
                db.SaveChanges();
                var firma = db.FIRMA.Find(fIRMA.ID);
         
                if (!string.IsNullOrEmpty(file.ToString()))
                {
                    if (file != null)
                    {
                        if (file.ContentLength > 0)
                        {
                            string dir = Server.MapPath("~/Assets/tasarimlar/" + firma.KISAADI);
                            // If directory does not exist, create it
                            if (!System.IO.Directory.Exists(dir))
                            {
                                System.IO.Directory.CreateDirectory(dir);
                            }
                            if (System.IO.File.Exists(firma.XSLKODUFATURA))
                            {

                                System.IO.File.Delete(firma.XSLKODUFATURA);
                                
                            }

                            file.SaveAs(Server.MapPath("~/Assets/tasarimlar/" + firma.KISAADI.Trim() + "/" + "FaturaXslt" + "_" + file.FileName));
                            firma.XSLKODUFATURA = (Server.MapPath("~/Assets/tasarimlar/" + firma.KISAADI.Trim() + "/"+ "FaturaXslt" + "_" + file.FileName));


                        }
                    }


                }
                if (!string.IsNullOrEmpty(filea.ToString()))
                {
                    if (filea != null)
                    {
                        if (filea.ContentLength > 0)
                        {
                            string dir = Server.MapPath("~/Assets/tasarimlar/" + firma.KISAADI);
                            // If directory does not exist, create it
                            if (!System.IO.Directory.Exists(dir))
                            {
                                System.IO.Directory.CreateDirectory(dir);
                            }
                            if (System.IO.File.Exists(firma.XSLKODUEARSIV))
                            {

                                System.IO.File.Delete( firma.XSLKODUEARSIV);
                             
                            }
                            filea.SaveAs(Server.MapPath("~/Assets/tasarimlar/" + firma.KISAADI.Trim() + "/" + "ArsivXslt" + "_" + filea.FileName));
                            firma.XSLKODUEARSIV = (Server.MapPath("~/Assets/tasarimlar/" + firma.KISAADI.Trim() + "/" + "ArsivXslt" + "_" + filea.FileName));


                        }
                    }


                }
                if (!string.IsNullOrEmpty(filex.ToString()))
                {
                    if (filex != null)
                    {
                        if (filex.ContentLength > 0)
                        {  string dir = Server.MapPath("~/Assets/tasarimlar/" + firma.KISAADI);
                            // If directory does not exist, create it
                            if (!System.IO.Directory.Exists(dir))
                            {
                                System.IO.Directory.CreateDirectory(dir);
                            }
                            if (System.IO.File.Exists(Server.MapPath("~/"+firma.FirmaResimUrl)))
                            {

                                System.IO.File.Delete(Server.MapPath("~/" + firma.FirmaResimUrl));

                            }
                            filex.SaveAs(Server.MapPath("~/Assets/tasarimlar/" + firma.KISAADI.Trim() + "/" + "Logo" + "_" + filex.FileName));
                            firma.FirmaResimUrl = ("/Assets/tasarimlar/" + firma.KISAADI.Trim() + "/" + "Logo" + "_" + filex.FileName);


                        }
                    }


                }




                db.SaveChanges();
             
                return Redirect("~/Home/");
            }
            return View(fIRMA);
        }

        // GET: FIRMAs/Delete/5
        public ActionResult Delete(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIRMA fIRMA = db.FIRMA.Find(id);
            if (fIRMA == null)
            {
                return HttpNotFound();
            }
            return View(fIRMA);
        }

        // POST: FIRMAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FIRMA fIRMA = db.FIRMA.Find(id);
            db.FIRMA.Remove(fIRMA);
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
