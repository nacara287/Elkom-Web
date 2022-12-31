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
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using And.ElkomMuhasebe.Core.Model.Entity.Admin;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class SIPARIS_FISController : Controller
    {
     
        private FirmaBaseDB db = new FirmaBaseDB();
        public int userid = 0;
        public bool ekleme = false;
        public bool degistirme = false;
        public bool silme = false;
        public bool gorme = false;
        private AndDB anddb = new AndDB();
        public void Disposedb()
        {
           anddb.Dispose();
            db.Dispose();
            base.Dispose(true);
        }
        [HttpPost]
        public JsonResult siparishareketigetir(int id)
        {
            changestring();

            var list = new List<SIPARIS_FIS_HAREKET>();
            var items = db.SIPARIS_FIS_HAREKET.Include(x => x.STOK).Where(x => x.SIPARIS_FISID == id && x.KULLANIMDA != 1).ToList();
            foreach (var item in items)
            {
                var yenihareket = new SIPARIS_FIS_HAREKET();
                yenihareket.STOKID = item.STOKID;
                yenihareket.ACIKLAMA = item.ACIKLAMA;
                yenihareket.MIKTAR = item.MIKTAR;
                yenihareket.BIRIM = item.BIRIM;
                yenihareket.TOPLAMFIYAT = item.TOPLAMFIYAT;
                yenihareket.ISK1 = item.ISK1;
                yenihareket.PARABIRIMI = item.PARABIRIMI;
                yenihareket.PARAKUR = item.PARAKUR;
                yenihareket.NETFIYAT = item.NETFIYAT;
                yenihareket.KDVTUTARI = item.KDVTUTARI;
                yenihareket.SIPARISNO = item.SIPARISNO;
                yenihareket.KDV = (int)item.STOK.KDV;
                yenihareket.ID = item.ID;
                yenihareket.STOKKODU = item.STOK.STOKKODU + "/" + item.STOK.STOKAD;
                list.Add(yenihareket);
            }

            Disposedb();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public class siparishareketaraviewmodel
        {
            public string stokkod { get; set; }
            public string miktar { get; set; }
            public string birim { get; set; }
            public string fiyat { get; set; }
            public string iskonto { get; set; }
            public string iskontotutar { get; set; }
            public string kdvoranı { get; set; }
            public string kdvtutar { get; set; }
            public string toplam { get; set; }
        }
        [HttpPost]
        public JsonResult siparishareketigetirefatura(int id)
        {
            changestring();

            var hareketler = new siparishareketaraviewmodel[1];

            foreach (var item in db.SIPARIS_FIS_HAREKET.Where(x => x.SIPARIS_FISID == id).ToList())
            {
                var hareket = new siparishareketaraviewmodel();
                hareket.stokkod = item.STOKKODU;
                hareket.birim = item.BIRIM;
                hareket.fiyat = item.TOPLAMFIYAT.ToString().Replace(",", ".");
                hareket.iskonto = item.ISK1.ToString().Replace(",", ".");
                hareket.iskontotutar = ((item.MIKTAR * item.ISK1 * item.TOPLAMFIYAT) / 100).ToString().Replace(",", ".");
                hareket.miktar = item.MIKTAR.ToString();
                var stok = db.STOK.Where(x => x.STOKKODU == item.STOKKODU).First();
                hareket.kdvoranı = stok.KDV.ToString();
                hareket.kdvtutar = (item.MIKTAR / stok.KDV).ToString().Replace(",", ".");
                hareket.toplam = (item.MIKTAR * item.TOPLAMFIYAT).ToString().Replace(",", ".");
                hareketler[0] = hareket;
            }
            Disposedb();
            return Json(hareketler, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult fissil(int id)
        {
            changestring();
            var fis = db.SIPARIS_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.SIPARIS_FIS_HAREKET.Where(x => x.SIPARIS_FISID == id && x.deleted != 1);


            var cari = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();




   

            foreach (var item in fishareketleri)
            {
                item.deleted = 1;
            }
            fis.deleted = 1;
           

            db.SaveChanges();
            var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            Disposedb(); return jsonResult;

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
                    if (alt.görme.Contains("İrsaliyeler"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Stok Hareket Ve Fişleri"))
                            ekleme = true;
                        if (alt.silme.Contains("Stok Hareket Ve Fişleri"))
                            silme = true;
                        if (alt.degistir.Contains("Stok Hareket Ve Fişleri"))
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
        // GET: SIPARIS_FIS
        public ActionResult Index()
        {
            return View();
        }

        // GET: SIPARIS_FIS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIPARIS_FIS sIPARIS_FIS = db.SIPARIS_FIS.Find(id);
            if (sIPARIS_FIS == null)
            {
                return HttpNotFound();
            }
            return View(sIPARIS_FIS);
        }

        // GET: SIPARIS_FIS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SIPARIS_FIS/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TIP,deleted,CARIKOD,TARIH,OZELKOD,ACIKLAMA,DEPO,ODEMETARIHI,KDVDAHIL,IADE,MUHASEBEDURUM,TOPLAMTUTAR,KDVMATRAHI,KDVTUTARI,GENELTOPLAM,TESLIMALAN,YAZIILE,MASRAFTUTARI,ACIKKAPALI,SIPNOSOL,SIPARISNO,SIPNOSAG,PARAKUR,DOVIZ_GENELTOPLAM,PARABIRIMI,ISKTOPLAM,ISK1TOP,ISK2TOP,ARATOPLAM,DURUM,PERSONEL,TESLIMSURESI,OPSIYON,GENELACIKLAMA,KDV,TESLIM_YERI,NAKLIYESI,ISKONTO,MASRAF,FORM_NO,TEKLIF_NO,REVIZYON_NO,REVIZYON_TARIH,MUHATTAP,S_MERKEZI,KABUL,DUZLEME_ISKONTO,RED_EDILDI,RED_TARIHI,RED_ACIKLAMA,WEB_DURUM,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] SIPARIS_FIS sIPARIS_FIS)
        {
            if (ModelState.IsValid)
            {
                db.SIPARIS_FIS.Add(sIPARIS_FIS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sIPARIS_FIS);
        }

        // GET: SIPARIS_FIS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIPARIS_FIS sIPARIS_FIS = db.SIPARIS_FIS.Find(id);
            if (sIPARIS_FIS == null)
            {
                return HttpNotFound();
            }
            return View(sIPARIS_FIS);
        }

        // POST: SIPARIS_FIS/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TIP,deleted,CARIKOD,TARIH,OZELKOD,ACIKLAMA,DEPO,ODEMETARIHI,KDVDAHIL,IADE,MUHASEBEDURUM,TOPLAMTUTAR,KDVMATRAHI,KDVTUTARI,GENELTOPLAM,TESLIMALAN,YAZIILE,MASRAFTUTARI,ACIKKAPALI,SIPNOSOL,SIPARISNO,SIPNOSAG,PARAKUR,DOVIZ_GENELTOPLAM,PARABIRIMI,ISKTOPLAM,ISK1TOP,ISK2TOP,ARATOPLAM,DURUM,PERSONEL,TESLIMSURESI,OPSIYON,GENELACIKLAMA,KDV,TESLIM_YERI,NAKLIYESI,ISKONTO,MASRAF,FORM_NO,TEKLIF_NO,REVIZYON_NO,REVIZYON_TARIH,MUHATTAP,S_MERKEZI,KABUL,DUZLEME_ISKONTO,RED_EDILDI,RED_TARIHI,RED_ACIKLAMA,WEB_DURUM,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] SIPARIS_FIS sIPARIS_FIS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sIPARIS_FIS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sIPARIS_FIS);
        }

        // GET: SIPARIS_FIS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIPARIS_FIS sIPARIS_FIS = db.SIPARIS_FIS.Find(id);
            if (sIPARIS_FIS == null)
            {
                return HttpNotFound();
            }
            return View(sIPARIS_FIS);
        }

        // POST: SIPARIS_FIS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SIPARIS_FIS sIPARIS_FIS = db.SIPARIS_FIS.Find(id);
            db.SIPARIS_FIS.Remove(sIPARIS_FIS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disposedb();
            }
            base.Dispose(disposing);
        }

        public class modelimiz
        {public bool print { get; set; }
            public string firmalogo { get; set; }
            public STOK STOK { get; set; }
            public STOK_HAREKET Hareket { get; set; }
            public KUR_BASLIK Kur { get; set; }
            public IEnumerable<CARI_BASLIK> cARI_BASLIKs { get; set; }
            public IEnumerable<CARI_HAREKET> cARI_HAREKETs { get; set; }
            public IEnumerable<STOK> STOKs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<STOK_HAREKET> STOK_HAREKETs { get; set; }
            public IEnumerable<STOK_BIRIM> STOK_BIRIMLERs { get; set; }

            public SIPARIS_FIS SIPARIS { get; set; }
            public IEnumerable<SIPARIS_FIS> SIPARISLER { get; set; }
            public IEnumerable<SIPARIS_FIS_HAREKET> SIPARIS_HAREKETLERİ { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }

        }

        public class siparisfismodel
        {


            public string CARIKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string ODEMETARIHI { get; set; }
            public string TESLIMYERI { get; set; }
            public string TESLIMSURESI { get; set; }
            public string MUHATTAPADI { get; set; }
            public string NAKLIYE { get; set; }
            public bool ONAYLANDI{ get; set; }

            public bool REDDEDILDI { get; set; }
            public string REDACIKLAMA { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
            public string DEPO { get; set; }
            public List<siparismodelhareket> gelenhareket { get; set; }

            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class siparismodelhareket
        {



            public string STOKKODU { get; set; }

            public string ACIKLAMA { get; set; }

            public string EN { get; set; }
            public string BOY { get; set; }
            public string YUKSEKLIK { get; set; }
            public string RENK { get; set; }
            public string MIKTAR { get; set; }
            public string BIRIM { get; set; }
            public string TUTAR { get; set; }

            public string ISKONTO { get; set; }

            public string PARABIRIMI { get; set; }

            public string PARABIRIMIKUR { get; set; }
            public string NETTUTAR { get; set; }
            public string KDVTUTAR { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SIPARISKART(modelimiz carifis)
        {
            changestring();

            if (degistirme == true)
            {
                return View(carifis.SIPARIS);
            }
            else
            {
                return Redirect("/Home");
            }

        }
        public ActionResult SIPARISKART(int? id,bool? print)
        {
            changestring();
            var model = new modelimiz();
            model.SIPARISLER = db.SIPARIS_FIS.Where(x => x.deleted == null).ToList();
            if(print!=null)
            model.print = (bool)print;
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.Hareket = new STOK_HAREKET();
            model.cARI_HAREKETs = new List<CARI_HAREKET>();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.firmalogo = db.FIRMA.FirstOrDefault().FirmaResimUrl;
            model.STOK_BIRIMLERs = anddb.STOK_BIRIMLER.Where(x => x.deleted == null).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.SIPARIS = db.SIPARIS_FIS.Include(x=>x.CARI).SingleOrDefault(x=>x.ID==id);
            model.SIPARIS_HAREKETLERİ = db.SIPARIS_FIS_HAREKET.Where(x => x.SIPARIS_FISID == id).Include(x => x.STOK).ToList();




            if (degistirme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }

        }
        public ActionResult SIPARISOLUSTUR(string tip)
        {
            changestring();
            var model = new modelimiz();

            model.SIPARISLER = db.SIPARIS_FIS.Where(x => x.deleted == null).ToList();
       
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.Hareket = new STOK_HAREKET();
            model.cARI_HAREKETs = new List<CARI_HAREKET>();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.firmalogo = db.FIRMA.FirstOrDefault().FirmaResimUrl;
            model.STOK_BIRIMLERs = anddb.STOK_BIRIMLER.Where(x => x.deleted == null).ToList();
            if (ekleme == true)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Home");
            }
        }
        public ActionResult SIPARISLISTE()
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
        public class SIPARISARAVIEW
        {
            public int ID { get; set; }

            public string CARIKOD { get; set; }
            public string TARIH { get; set; }
            public string SIPARISNO { get; set; }
            public string TIP { get; set; }
            public string GENELTOPLAM { get; set; }
            public string GIRIS { get; set; }
            public string CIKIS { get; set; }
            public string DURUM { get; set; }

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
            if (sort == "GIRIS" || sort == "CIKIS")
                sort = "TOPLAMTUTAR";


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
            List<SIPARISARAVIEW> hareketler = new List<SIPARISARAVIEW>();
            var zaman = new DateTime();
            var sonzaman = new DateTime();


            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "CARIKOD";
            aranacaklar[1] = "SIPARISNO";




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




            var v = (from a in db.SIPARIS_FIS.Where(x => x.deleted != 1).Where(x => DbFunctions.TruncateTime(x.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);


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


                var yenihareket = new SIPARISARAVIEW();

                yenihareket.ID = item.ID;


                yenihareket.CARIKOD = item.CARIKOD;
                if (item.TIP == 1)
                {
                    yenihareket.GIRIS = item.TOPLAMTUTAR.ToString();
                    yenihareket.CIKIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-success"">Giriş</span>";
                }
                else
                {
                    yenihareket.CIKIS = item.TOPLAMTUTAR.ToString();
                    yenihareket.GIRIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-danger"">Çıkış</span>";

                }
                yenihareket.GENELTOPLAM = item.GENELTOPLAM.ToString();
                yenihareket.TARIH = item.TARIH.Value.ToShortDateString();

                if (!string.IsNullOrEmpty(item.SIPARISNO))
                    yenihareket.SIPARISNO = item.SIPARISNO;

                yenihareket.DURUM = item.DURUM.ToString();

                hareketler.Add(yenihareket);



            }

            Disposedb();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        [HttpPost]
        public JsonResult datagonder(siparisfismodel gelenveri)
        {
            changestring();





            double toplamtutar = 0;
            double toplamiktar = 0;
            double toplamdovuz = 0;

            var siparisfis = new SIPARIS_FIS();
            var carid = int.Parse(gelenveri.CARIKOD);
            var cari = db.CARI_BASLIK.Find(carid);
            siparisfis.CARI = cari;
            siparisfis.CARIKOD = siparisfis.CARI.CARIKOD;
            siparisfis.CreateDate = DateTime.Now;
            siparisfis.CreateUserID = userid;
            siparisfis.MUHATTAP = gelenveri.MUHATTAPADI;
            siparisfis.NAKLIYESI = gelenveri.NAKLIYE;
            siparisfis.TESLIMSURESI = gelenveri.TESLIMSURESI;
            siparisfis.TESLIM_YERI = gelenveri.TESLIMYERI;
            siparisfis.ONAYLANDI = gelenveri.ONAYLANDI;
            siparisfis.REDDEDILDI = gelenveri.REDDEDILDI;
            siparisfis.RED_ACIKLAMA = gelenveri.REDACIKLAMA;
            siparisfis.TIP = (int)gelenveri.TIPI;
            siparisfis.SIPARISNO = gelenveri.FISNO.ToString();
            siparisfis.ACIKLAMA = gelenveri.NOT;
            siparisfis.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
            siparisfis.TARIH = DateTime.Parse(gelenveri.TARIH);
            siparisfis.ODEMETARIHI = DateTime.Parse(gelenveri.ODEMETARIHI);
            siparisfis.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;
            db.CARI_HAREKET.RemoveRange(db.CARI_HAREKET.Where(x => x.ISLEMNO == gelenveri.FISNO));
            db.STOK_HAREKET.RemoveRange(db.STOK_HAREKET.Where(x => x.BELGENO == gelenveri.FISNO));
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
                        double tutar = 0;
                        toplamdovuz += double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ",")) / double.Parse(item.PARABIRIMIKUR.Replace(".", ","));
                        tutar = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));

                        toplamtutar += tutar;

                        toplamiktar += int.Parse(item.MIKTAR);

                        /*    var stok = db.STOK.Where(x => x.STOKKODU == item.STOKKODU).FirstOrDefault();
                          var stokhareket = new STOK_HAREKET();
                           stokhareket.STOK = stok;
                           stokhareket.STOKKODU = stokhareket.STOK.STOKKODU;
                           stokhareket.CARIKOD = db.CARI_BASLIK.Where(x => x.CARIKOD == gelenveri.CARIKOD).FirstOrDefault().CARIKOD;
                           stokhareket.BIRIM = db.STOK_BIRIMLER.Where(x => x.BIRIMADI == item.BIRIM).FirstOrDefault().ID;
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
                           stokhareket.SONMALIYET = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));




                           stokhareket.ACIKLAMA = item.ACIKLAMA;


                           db.STOK_HAREKET.Add(stokhareket);


                           db.SaveChanges();*/
                    }
                    siparisfis.TOPLAMTUTAR = toplamtutar;
                    siparisfis.GENELTOPLAM = toplamiktar;
                    var list = db.SIPARIS_FIS.SingleOrDefault(x => x.SIPARISNO == siparisfis.SIPARISNO);
                    if (list == null)
                    {
                        db.SIPARIS_FIS.Add(siparisfis);
                        db.SaveChanges();
                        foreach (var item in gelenveri.gelenhareket)
                        {
                            var fishareket = new SIPARIS_FIS_HAREKET();
                            var stokid = int.Parse(item.STOKKODU);
                            fishareket.STOK = db.STOK.Find(stokid);
                            fishareket.SIPARISNO = gelenveri.FISNO;
                            fishareket.BIRIM = item.BIRIM;
                            fishareket.SIPARIS_FISID = db.SIPARIS_FIS.Find(siparisfis.ID).ID;
                            fishareket.ACIKLAMA = item.ACIKLAMA;
                            fishareket.EN = item.EN;
                            fishareket.BOY = item.BOY;
                            fishareket.YUKSEKLIK = item.YUKSEKLIK;
                            fishareket.RENK = item.RENK;

                            fishareket.PARABIRIMI = item.PARABIRIMI;
                            fishareket.PARAKUR = double.Parse(item.PARABIRIMIKUR.Replace(".", ","));
                            fishareket.MIKTAR = double.Parse(item.MIKTAR);
                            fishareket.TOPLAMFIYAT = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                            fishareket.ISK1 = double.Parse(item.ISKONTO.Replace(",", "").Replace(".", ","));
                            fishareket.NETFIYAT = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));
                            fishareket.KDVTUTARI = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));


                            db.SIPARIS_FIS_HAREKET.Add(fishareket);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                      
                        list.UpdateDate = DateTime.Now;
                        list.UpdateUserID = 1;
                        list.S_MERKEZIID = siparisfis.S_MERKEZIID;
                        list.TARIH = siparisfis.TARIH;
                        list.ACIKLAMA = siparisfis.ACIKLAMA;
                        list.GENELTOPLAM = siparisfis.GENELTOPLAM;
                        list.TOPLAMTUTAR = siparisfis.TOPLAMTUTAR;
                        db.SaveChanges();
                        db.SIPARIS_FIS_HAREKET.RemoveRange(db.SIPARIS_FIS_HAREKET.Where(x => x.SIPARIS_FISID == list.ID));
                        foreach (var item in gelenveri.gelenhareket)
                        {

                            var fishareket = new SIPARIS_FIS_HAREKET();
                            var stokid = int.Parse(item.STOKKODU);
                            fishareket.STOK = db.STOK.Find(stokid);

                            fishareket.SIPARISNO = gelenveri.FISNO;
                            fishareket.BIRIM = item.BIRIM;
                            fishareket.SIPARIS_FISID = list.ID;
                            fishareket.ACIKLAMA = item.ACIKLAMA;
                            fishareket.EN = item.EN;
                            fishareket.BOY = item.BOY;
                            fishareket.YUKSEKLIK = item.YUKSEKLIK;
                            fishareket.RENK = item.RENK;

                            fishareket.PARABIRIMI = item.PARABIRIMI;
                            fishareket.PARAKUR = double.Parse(item.PARABIRIMIKUR.Replace(".", ","));
                            fishareket.MIKTAR = double.Parse(item.MIKTAR);
                            fishareket.TOPLAMFIYAT = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                            fishareket.ISK1 = double.Parse(item.ISKONTO.Replace(",", "").Replace(".", ","));
                            fishareket.NETFIYAT = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));
                            fishareket.KDVTUTARI = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));


                            db.SIPARIS_FIS_HAREKET.Add(fishareket);
                            db.SaveChanges();
                        }
                    }
                    ///irsaliye silme

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
                    return Json("Başarısız!");
                }


                /*      var hareket = new CARI_HAREKET();
                      hareket.cari = db.CARI_BASLIK.Where(x => x.CARIKOD == gelenveri.CARIKOD).FirstOrDefault();
                      hareket.CARIKOD = hareket.cari.CARIKOD;
                      hareket.CreateDate = DateTime.Now;

                      hareket.CreateUserID = userid;
                      hareket.ISLEMNO = gelenveri.FISNO;
                      hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                      hareket.ISLEMTURU = CARI_HAREKET.tür.Fatura;
                      hareket.S_MERKEZI = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
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
                              hareket.BORC = toplamtutar;
                              hareket.DOVIZBORC = toplamdovuz;
                              cari.TOPLAMDOVIZBORC = toplamdovuz;
                              cari.DOVIZBAKIYE = cari.TOPLAMDOVIZBORC - cari.TOPLAMDOVIZALACAK;
                              cari.TOPLAMBORC += hareket.BORC;
                              cari.BAKIYE = cari.TOPLAMBORC - cari.TOPLAMALACAK;
                              hareket.BAKIYE = eskihareket.BAKIYE + toplamtutar;
                              hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE + toplamdovuz;
                              foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                              {
                                  hareketz.BAKIYE -= toplamtutar;
                                  hareketz.DOVIZBAKIYE -= toplamdovuz;
                              }


                          }
                          else
                          {
                              hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                              hareket.ALACAK = toplamtutar;
                              hareket.DOVIZALACAK = toplamdovuz;
                              cari.TOPLAMDOVIZALACAK += toplamdovuz;
                              cari.DOVIZBAKIYE = cari.TOPLAMDOVIZBORC - cari.TOPLAMDOVIZALACAK;
                              cari.TOPLAMALACAK += hareket.ALACAK;
                              cari.BAKIYE = cari.TOPLAMBORC - cari.TOPLAMALACAK;
                              hareket.BAKIYE = eskihareket.BAKIYE - toplamtutar;
                              hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE - toplamdovuz;
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
                              hareket.BORC = toplamtutar;
                              hareket.DOVIZBORC = toplamdovuz;
                              cari.TOPLAMDOVIZBORC = toplamdovuz;
                              cari.DOVIZBAKIYE = cari.TOPLAMDOVIZBORC - cari.TOPLAMDOVIZALACAK;
                              cari.TOPLAMBORC += hareket.BORC;
                              cari.BAKIYE = cari.TOPLAMBORC - cari.TOPLAMALACAK;
                              hareket.BAKIYE = cari.BAKIYE;
                              hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;
                          }
                          else
                          {
                              hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                              hareket.ALACAK = toplamtutar;
                              hareket.DOVIZALACAK = toplamdovuz;
                              cari.TOPLAMDOVIZALACAK += toplamdovuz;
                              cari.DOVIZBAKIYE = cari.TOPLAMDOVIZBORC - cari.TOPLAMDOVIZALACAK;
                              cari.TOPLAMALACAK += hareket.ALACAK;
                              cari.BAKIYE = cari.TOPLAMBORC - cari.TOPLAMALACAK;
                              hareket.BAKIYE = cari.BAKIYE;
                              hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;


                          }
                      }



                      hareket.ACIKLAMA = gelenveri.NOT;

                      hareket.VADE = DateTime.Parse(gelenveri.ODEMETARIHI);

                      db.CARI_HAREKET.Add(hareket);*/
                
            }

        }

    }
}
