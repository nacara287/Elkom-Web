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
using And.ElkomMuhasebe.Core.Model.Entity.Admin;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class STOK_HAREKETController : Controller
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
        public class modelimiz
        {
            public bool print { get; set; }
            public STOK STOK { get; set; }
            public STOK_HAREKET Hareket { get; set; }
            public KUR_BASLIK Kur { get; set; }
            public IEnumerable<CARI_BASLIK> cARI_BASLIKs { get; set; }
            public IEnumerable<CARI_HAREKET> cARI_HAREKETs { get; set; }
            public IEnumerable<STOK> STOKs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<STOK_HAREKET> STOK_HAREKETs { get; set; }
            public IEnumerable<STOK_BIRIM> STOK_BIRIMLERs { get; set; }
            public string cariad { get; set; }
            public string carikod { get; set; }
            public string firmalogo { get; set; }
            public STOK_FIS fis { get; set; }
            public int STOK_FISs { get; set; }
            public IEnumerable<STOK_FIS_HAREKET> STOK_FIS_HAREKETs { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }
            public IEnumerable<STOK_DEPO> DEPOs { get; set; }

        }
        public class stokmodel{
            public int ID { get; set; }
            public string STOKKODU { get; set; }
            public string STOKADI { get; set; }
            public string STOKBIRIM1 { get; set; }
            public double MIKTAR { get; set; }
            public string ISKONTO { get; set; }
            public double TUTAR { get; set; }
            public string ORTMALIYET { get; set; }
            public int? KDV { get; set; }
            public string KDVFIYATADAHIL { get; set; }
            public string PARABIRIMI { get; set; }

        }

        [HttpPost]
        public JsonResult stokfishareketigetir(int id)
        {
            changestring();

           var fisler = new List<STOK_FIS_HAREKET>();

             foreach(var item in db.STOK_FIS_HAREKET.Include(x=>x.STOK).Where(x => x.fisid == id).ToList()){
                var fis = new STOK_FIS_HAREKET();
                double? kdvtutar = 0;
                var stok = item.STOK;
                if (stok.KDV != null && stok.KDV != 0)
                {
                    kdvtutar = (item.TOPLAMTUTAR / stok.KDV);

                }
              

                fis = item;
                fis.STOK = null;
               
                fis.STOKKODU = stok.STOKKODU + "/" + stok.STOKAD;
                fis.MASRAFTUTAR = item.TOPLAMTUTAR + kdvtutar;
                fisler.Add(fis);
                    
            }
            Disposedb();
            return Json(fisler, JsonRequestBehavior.AllowGet);

        }
        public class stokfishareketmodellii
        {
            public string fisno { get; set; }
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
        public JsonResult stokfishareketigetirefatura(int id)
        {
            changestring();

            var hareketler = new stokfishareketmodellii[1];

            foreach (var item in db.STOK_FIS_HAREKET.Where(x => x.fisid == id).ToList())
            {
                var hareket = new stokfishareketmodellii();
                hareket.stokkod = item.STOKKODU;
                hareket.birim = item.BIRIM;

                hareket.fiyat = item.FIYAT.ToString().Replace(",", ".");
                hareket.iskonto = item.ISK1.ToString().Replace(",", ".");
                hareket.iskontotutar = ((item.MIKTAR * item.ISK1 * item.FIYAT) / 100).ToString().Replace(",", ".");
                hareket.miktar = item.MIKTAR.ToString();
                var stok = db.STOK.Where(x => x.STOKKODU == item.STOKKODU).First();
                hareket.kdvoranı = stok.KDV.ToString();
                hareket.kdvtutar = (item.MIKTAR / stok.KDV).ToString().Replace(",", ".");
                hareket.toplam = (item.MIKTAR * item.FIYAT).ToString().Replace(",", ".");
                hareketler[0] = hareket;
            }
            Disposedb();
            return Json(hareketler, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult stokgetir(string search, string order, int offset, int limit, int TIPI,bool? kdvdahildegil, string sort, int carid, filtermodel[] filterler)
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
            List<StokAraViewModel> hareketler = new List<StokAraViewModel>();




            var arama = search.ToLower();


            string[] aranacaklar = new string[2];

            aranacaklar[0] = "STOKAD";
            aranacaklar[1] = "STOKKODU";




            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";









            var v = (from a in db.STOK.Where(x => x.deleted != 1).Where(query) select a);

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
                if (item.deleted == null)
                {

                    var yenihareket = new StokAraViewModel();

                    yenihareket.ID = item.ID;
                    if (!string.IsNullOrEmpty(item.STOKKODU))
                        yenihareket.STOKODU = item.STOKKODU;
                    if (!string.IsNullOrEmpty(item.STOKAD))
                        yenihareket.STOKAD = item.STOKAD;
                    yenihareket.MIKTAR = item.MIKTAR.ToString();
                    yenihareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.ID == item.BIRIM).FirstOrDefault().BIRIMADI;
                    if (TIPI == 0 )
                    {
                        yenihareket.LISTEFIYAT = (double)item.HAMALISFIYAT;
                        if (item.ALISFIYATI != null)
                        {
                            if (kdvdahildegil.HasValue)
                            {if(kdvdahildegil==true)
                                yenihareket.TUTAR = (double)item.KDV_SIZ_ALISFIYATI;
                            else
                                    yenihareket.TUTAR = (double)item.ALISFIYATI;
                            }
                            else
                                yenihareket.TUTAR = (double)item.ALISFIYATI;

                        }
                       
                        if (item.ALISISKONTOSU != null)
                            yenihareket.ISKONTO = item.ALISISKONTOSU.ToString();
                    }
                    else
                    {
                        yenihareket.LISTEFIYAT = (double)item.HAMSATISFIYAT;
                        if (db.CARI_FIYAT.Where(x => x.STOK.ID == item.ID && x.CARI_BASLIK.ID == carid).Count() > 0)
                        {
                            yenihareket.TUTAR = (double)db.CARI_FIYAT.Where(x => x.STOK.ID == item.ID && x.CARI_BASLIK.ID == carid).FirstOrDefault().FIYAT;
                            yenihareket.ISKONTO = db.CARI_FIYAT.Where(x => x.STOK.ID == item.ID && x.CARI_BASLIK.ID == carid).FirstOrDefault().ORAN.ToString();

                        }
                        else
                        {
                            if (item.SATISFIYATI1 != null)
                            {if (kdvdahildegil.HasValue)
                                {
                                    if (kdvdahildegil == true)
                                        yenihareket.TUTAR = (double)item.KDV_SIZ_SATISFIYATI1;
                                    else
                                        yenihareket.TUTAR = (double)item.SATISFIYATI1;
                                }
                             
                               else
                                    yenihareket.TUTAR = (double)item.SATISFIYATI1;
                            }
                               

                            if (item.SATISISKONTOSU != null)
                                yenihareket.ISKONTO = item.SATISISKONTOSU.ToString();
                        }
                    }
                    if (!string.IsNullOrEmpty(item.PARABIRIMI))
                        yenihareket.PARABIRIMI = item.PARABIRIMI.ToString();

             
                    yenihareket.MALIYET = item.MALIYETORT.ToString();
                    yenihareket.KDV = item.KDV.ToString();
                    yenihareket.EN = item.EN;
                    yenihareket.BOY = item.BOY;
                    yenihareket.YUKSEKLIK = item.YUKSEKLIK;
                    if (item.KDVDAHIL == 1)
                        yenihareket.KDVDAHIL = "Evet";
                    else
                        yenihareket.KDVDAHIL = "Hayır";
                    yenihareket.RENK = item.RENK;




                    hareketler.Add(yenihareket);
                }



            }
            Disposedb();

            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }


        public class StokAraViewModel
        {
            public int ID { get; set; }
            public string STOKODU { get; set; }
            public string STOKAD { get; set; }
            public string MIKTAR { get; set; }
            public string KDVDAHIL { get; set; }
            public string BIRIM { get; set; }
            public string ISKONTO { get; set; }
            public string EN { get; set; }
            public string BOY { get; set; }
            public string YUKSEKLIK { get; set; }
            public string RENK { get; set; }
            public string PARABIRIMI { get; set; }
            public double TUTAR { get; set; }
            public double LISTEFIYAT { get; set; }
            public string MALIYET { get; set; }
            public string KDV { get; set; }
            public string DEPO { get; set; }
        }
      

        [HttpPost]
        public JsonResult fissil(int id)
        {
            changestring();
            var fis = db.STOK_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.STOK_FIS_HAREKET.Where(x => x.fisid == id && x.deleted != 1);

            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1).ToList();

    
            var cari = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();
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

                    if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count()>0)
                    {
                        var eskihareket = new STOK_HAREKET();
                        if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).OrderByDescending(x => x.TARIH).FirstOrDefault();


                        }
                        else { eskihareket.STOKMIKTAR = 0; }
                        if (fis.TIP == 1)
                        {

                            stok.TOPGIREN -= stokhareket.MIKTAR;
                            stok.MIKTAR -= stokhareket.MIKTAR;
                            stok.TL_ALIS_TOPLAM -= stokhareket.TL_TUTAR;
                            stok.DOVIZ_ALIS_TOPLAM -= stokhareket.TL_TUTAR * stokhareket.KUR_FIYAT;
                        
                            foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).ToList())
                            {
                                hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;
                                hareketz.TL_STOKALIS_TOPLAM -= stokhareket.TL_TUTAR;
                                hareketz.DOVIZ_STOKALIS_TOPLAM -= stokhareket.TL_TUTAR* stokhareket.KUR_FIYAT;
                                hareketz.STOKMIKTAR_GIREN -= (float)stokhareket.MIKTAR;
                                db.Entry(hareketz).State= EntityState.Modified;
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
                        if (fis.TIP == 1)
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
                    var depotoplam = db.STOK_DEPO_TOPLAM.Where(x => x.DEPOSUID == item.DEPOSUID).Where(x => x.STOKID == item.STOKID).FirstOrDefault();


                    if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                    {
                        depotoplam.MIKTAR -= stokhareket.MIKTAR;
                    }
                    else
                    {
                        depotoplam.MIKTAR += stokhareket.MIKTAR;

                    }
                    item.deleted = 1;
                    db.SaveChanges();
              
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





        }
        [HttpPost]
        public JsonResult fisiyenile(int id)
        {
           
            var fis = db.STOK_FIS.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.STOK_FIS_HAREKET.Where(x => x.fisid == id && x.deleted != 1);

            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1).ToList();


            var cari = db.CARI_BASLIK.Where(x => x.ID == fis.CARIID).FirstOrDefault();

          

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
                if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                {
                    var eskihareket = new STOK_HAREKET();
                    if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                    {
                        eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(eskihareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).OrderByDescending(x => x.TARIH).FirstOrDefault();


                    }
                    else { eskihareket.STOKMIKTAR = 0; }
                    if (fis.TIP == 1)
                    {
                       
                        stok.TOPGIREN -= stokhareket.MIKTAR;
                        stok.MIKTAR -= stokhareket.MIKTAR;
                        stok.TL_ALIS_TOPLAM -= stokhareket.TL_TUTAR;
                        stok.DOVIZ_ALIS_TOPLAM -= stokhareket.TL_TUTAR * stokhareket.KUR_FIYAT;

                        foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).ToList())
                        {
                            hareketz.STOKMIKTAR -= (float)stokhareket.MIKTAR;
                            hareketz.TL_STOKALIS_TOPLAM -= stokhareket.TL_TUTAR;
                            hareketz.DOVIZ_STOKALIS_TOPLAM -= stokhareket.TL_TUTAR * stokhareket.KUR_FIYAT;
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
                    if (fis.TIP == 1)
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
                var depotoplam = db.STOK_DEPO_TOPLAM.Where(x => x.DEPOSUID == item.DEPOSUID).Where(x => x.STOKID == item.STOKID).FirstOrDefault();


                if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                {
                    depotoplam.MIKTAR -= stokhareket.MIKTAR;
                }
                else
                {
                    depotoplam.MIKTAR += stokhareket.MIKTAR;

                }
                item.deleted = 1;
                    db.SaveChanges();

                }


                db.STOK_FIS_HAREKET.RemoveRange(fishareketleri);


                var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.FISNO && x.deleted != 1);
                db.STOK_HAREKET.RemoveRange(stokhareketlerii);

                var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                db.CARI_HAREKET.RemoveRange(cariharetlerii);



                db.SaveChanges();
                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
              
               

                return jsonResult;
      
             




        }
        [HttpPost]
        public JsonResult datagonder(stokfismodel gelenveri)
        {
            changestring();

            var id = 0;
           


            double toplamtutar = 0;
            double toplamiktar = 0;
            double toplamdovuz = 0;
            var stokfis = new STOK_FIS();
            var carid = gelenveri.CARIID;
            var cari = db.CARI_BASLIK.Find(carid);
            stokfis.CARI = cari;
                        stokfis.CARIKOD = stokfis.CARI.CARIKOD;
                        stokfis.CreateDate = DateTime.Now;
                        stokfis.CreateUserID = userid;
           
            stokfis.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;
            stokfis.TIP = (int)gelenveri.TIPI;
                        stokfis.FISNO = gelenveri.FISNO.ToString();
                        stokfis.ACIKLAMA = gelenveri.NOT;
                        stokfis.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
                        stokfis.TARIH = DateTime.Parse(gelenveri.TARIH);
                      
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
                        toplamtutar += double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));
                        toplamiktar += double.Parse(item.MIKTAR);
                    }
                    stokfis.TOPLAMMASRAF = toplamtutar;

                    stokfis.GENELTOPLAM = toplamiktar;
                    var list = db.STOK_FIS.SingleOrDefault(x => x.FISNO == stokfis.FISNO);
                    if (list == null)
                    {
                        db.STOK_FIS.Add(stokfis);
                        db.SaveChanges();
                        id = stokfis.ID;
                    }
                    else
                    {
                        fisiyenile(list.ID);
                        stokfis.ID = list.ID;
                        list.CARI = stokfis.CARI;
                        list.CARIKOD = stokfis.CARIKOD;
                        list.UpdateDate = DateTime.Now;
                        list.UpdateUserID = 1;
                        list.S_MERKEZIID = stokfis.S_MERKEZIID;
                        list.TARIH = stokfis.TARIH;
                        list.ACIKLAMA = stokfis.ACIKLAMA;
                        list.GENELTOPLAM = stokfis.GENELTOPLAM;
                        list.TOPLAMMASRAF = stokfis.TOPLAMMASRAF;

                        db.SaveChanges();
                        id = list.ID;


                    }
                    foreach (var item in gelenveri.gelenhareket)
                    {

                        
                        var stok = db.STOK.Find(item.STOKID);
                    
                        if (item.PARABIRIMI == cari.PARABIRIMI)
                            toplamdovuz += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ",")) / double.Parse(item.PARABIRIMIKUR.ToString().Replace(".", ","));
                        else
                        {
                            toplamdovuz += double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ",")) / db.KUR_BASLIK.Where(x => x.KURKODU == cari.PARABIRIMI).FirstOrDefault().KUR;
                        }


                        toplamiktar += double.Parse(item.MIKTAR);


                        var stokhareket = new STOK_HAREKET();
                        stokhareket.STOK = stok;
                        stokhareket.STOKKODU = stokhareket.STOK.STOKKODU;
                        stokhareket.CARIID = cari.ID;
                        stokhareket.CreateDate = DateTime.Now;
                        stokhareket.CreateUserID = userid;
                        stokhareket.BELGENO = gelenveri.FISNO;
                        stokhareket.TARIH = DateTime.Parse(gelenveri.TARIH);
                        stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.StokFişi;
                        stokhareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMADI == item.BIRIM).FirstOrDefault().ID;
                        stokhareket.FIYAT = double.Parse(item.FIYAT.Replace(",", "").Replace(".", ","));
                        stokhareket.TIPI = gelenveri.TIPI;
                        stokhareket.MIKTAR = double.Parse(item.MIKTAR);
                        stokhareket.PARABIRIMI = item.PARABIRIMI;
                        stokhareket.KUR_FIYAT =(double) double.Parse(item.PARABIRIMIKUR.Replace(",", "").Replace(".", ","));
                        stokhareket.TL_FIYAT = double.Parse(item.FIYAT.Replace(",", "").Replace(".", ",")) * stokhareket.KUR_FIYAT;
                        stokhareket.DEPOSUID = item.DEPOID;
                        stokhareket.TL_TUTAR = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));
                        stokhareket.DOVIZ_TUTAR = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ",")) / stokhareket.KUR_FIYAT;
                        if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                        {
                          
                                stok.HAMALISFIYAT = stokhareket.FIYAT;
                           
                            
           ;
                            stok.TOPGIREN += stokhareket.MIKTAR;
                            var tutar = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));

                            stok.TL_ALIS_TOPLAM += tutar;
                            stok.DOVIZ_ALIS_TOPLAM += tutar / stokhareket.KUR_FIYAT;



                        }
                        else
                        {

                            
                                stok.HAMSATISFIYAT = stokhareket.FIYAT;
                           
                              
                            stok.TOPCIKAN += stokhareket.MIKTAR;
                        }





                        if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                        {
                            var eskihareket = new STOK_HAREKET();
                            if (db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).Count() > 0)
                            {
                                eskihareket = db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) < 0 && x.STOKKODU == stok.STOKKODU && x.deleted != 1).OrderByDescending(x => x.TARIH).FirstOrDefault();


                            }
                            else { eskihareket.STOKMIKTAR = 0;
                                eskihareket.STOKMIKTAR_GIREN = 0;
                                eskihareket.TL_STOKALIS_TOPLAM = 0;
                                eskihareket.DOVIZ_STOKALIS_TOPLAM = 0;
                            }
                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                stok.MIKTAR += stokhareket.MIKTAR;
                                stokhareket.STOKMIKTAR = eskihareket.STOKMIKTAR +(float)stokhareket.MIKTAR;
                                stokhareket.STOKMIKTAR_GIREN = eskihareket.STOKMIKTAR_GIREN + (float)stokhareket.MIKTAR;
                                stokhareket.TL_STOKALIS_TOPLAM = eskihareket.TL_STOKALIS_TOPLAM + (float)stokhareket.TL_TUTAR;
                                stokhareket.DOVIZ_STOKALIS_TOPLAM = eskihareket.DOVIZ_STOKALIS_TOPLAM +(float)stokhareket.DOVIZ_TUTAR;
                                foreach (var hareketz in db.STOK_HAREKET.Where(x => x.TARIH.CompareTo(stokhareket.TARIH) > 0 && x.STOKKODU == stok.STOKKODU).ToList())
                                {
                                    hareketz.STOKMIKTAR += (float)stokhareket.MIKTAR;
                                    hareketz.TL_STOKALIS_TOPLAM += stokhareket.TL_TUTAR;
                                    hareketz.DOVIZ_STOKALIS_TOPLAM += stokhareket.DOVIZ_TUTAR;
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
                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {
                                stok.MIKTAR += stokhareket.MIKTAR;
                                stokhareket.STOKMIKTAR_GIREN = (float)stok.MIKTAR;

                                stokhareket.TL_STOKALIS_TOPLAM = stok.TL_ALIS_TOPLAM;
                                stokhareket.DOVIZ_STOKALIS_TOPLAM = stok.DOVIZ_ALIS_TOPLAM;
                            }
                            else
                            {
                                stok.MIKTAR -= stokhareket.MIKTAR;

                            }
                            stokhareket.STOKMIKTAR = float.Parse(stok.MIKTAR.ToString());
                        }
                     


                        stokhareket.S_MERKEZIID = stokfis.S_MERKEZIID;
                       
                        stokhareket.ACIKLAMA = item.ACIKLAMA;
                      

                      db.STOK_HAREKET.Add(stokhareket);
                        var depotoplam = db.STOK_DEPO_TOPLAM.Where(x => x.DEPOSUID == item.DEPOID).Where(x => x.STOKID == item.STOKID).FirstOrDefault();
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
                            {if(depotoplam.MIKTAR==null)
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

                    var hareket = new CARI_HAREKET();
         
                    hareket.cari = db.CARI_BASLIK.Find(carid);
                    hareket.CARIKOD = hareket.cari.CARIKOD;
                    hareket.CreateDate = DateTime.Now;

                    hareket.CreateUserID = userid;
                    hareket.ISLEMNO = gelenveri.FISNO;
                    hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                    hareket.ISLEMTURU = CARI_HAREKET.tür.StokFişi;
                    hareket.S_MERKEZIID = stokfis.S_MERKEZIID;
                    if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new CARI_HAREKET();
                        if (db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).Count() > 0)
                        {
                            eskihareket = db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.CARIKOD == cari.CARIKOD).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }

                        if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                        {
                            hareket.TIPI = CARI_HAREKET.tip.Giriş;
                            hareket.ALACAK = toplamtutar;
                            hareket.DOVIZALACAK = toplamdovuz;
                            cari.TOPLAMDOVIZALACAK = toplamdovuz;
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
                                hareketz.BAKIYE += toplamtutar;
                                hareketz.DOVIZBAKIYE += toplamdovuz;
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
                            cari.TOPLAMDOVIZALACAK = toplamdovuz;
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
                    hareket.TIPI = gelenveri.TIPI;


                    hareket.ACIKLAMA = gelenveri.NOT;

                    hareket.VADE = DateTime.Parse(gelenveri.TARIH);

                    db.CARI_HAREKET.Add(hareket);
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var stokid = item.STOKID;
                        var fishareket = new STOK_FIS_HAREKET();
                        fishareket.fisno = gelenveri.FISNO;
                        fishareket.BIRIM = item.BIRIM;
                        fishareket.fisid = db.STOK_FIS.Find(id).ID;
                        fishareket.STOK = db.STOK.Find(stokid);
                        fishareket.ACIKLAMA = item.ACIKLAMA;
                        fishareket.DEPOSUID = item.DEPOID;
                        fishareket.PARABIRIMI = item.PARABIRIMI;
                        fishareket.PARAKUR = item.PARABIRIMIKUR;
                        fishareket.MIKTAR = double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                        fishareket.ISK1 = double.Parse(item.ISKONTO.Replace(",", "").Replace(".", ","));
                        fishareket.FIYAT = double.Parse(item.FIYAT.Replace(",","").Replace(".", ","));
                        fishareket.TOPLAMTUTAR = double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));
                   


                        db.STOK_FIS_HAREKET.Add(fishareket);
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
                    return Json("Başarısız!" + ex.InnerException);
                }


                        }
        }
        public class stokfismodel
        {


            public int CARIID { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
            public string DEPO { get; set; }
            public List<stokmodelhareket> gelenhareket { get; set; }

            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class stokmodelhareket
        {


    
            public int STOKID { get; set; }

            public string ACIKLAMA { get; set; }
          
            public string MIKTAR { get; set; }
            public string BIRIM { get; set; }
            public string FIYAT { get; set; }
            public string ISKONTO { get; set; }

            public string PARABIRIMI { get; set; }

            public string PARABIRIMIKUR { get; set; }
            public string NETTUTAR { get; set; }
            public int DEPOID { get; set; }

        }
        public class StokHareketAraViewModel
        {
            public int ID { get; set; }
            public string STOKKODU { get; set; }
            public string STOKAD { get; set; }
            public string TARIH { get; set; }
            public string BELGENO { get; set; }


            public string ISLEMTURU { get; set; }

            public string TIPI { get; set; }
            public string CARIKOD { get; set; }

            public string CARIAD { get; set; }
            public string MIKTAR { get; set; }
            public string BIRIM { get; set; }
            public string FIYAT { get; set; }


            public string STOKMIKTAR { get; set; }
            public string SMERKEZI { get; set; }

        

            public string SONMALIYET { get; set; }

            public string MALIYETORT { get; set; }
                public string DOVIZ_SONMALIYET { get; set; }

            public string DOVIZ_MALIYETORT { get; set; }
            public string TL_TUTAR { get; set; }

            public string DOVIZ_TUTAR { get; set; }

            public string KDVLIFIYAT { get; set; }

            public string DEPO { get; set; }
        }
        public class StokFisAraViewModel
        {
            public int ID { get; set; }
         
          
            public string CARIKOD { get; set; }
            public string CARIAD{ get; set; }
            public string FISNO { get; set; }
            public string DURUM { get; set; }
            public string TIP { get; set; }

            public string TARIH { get; set; }
            public string GENELTOPLAM { get; set; }
            public string GIRIS { get; set; }
            public string CIKIS { get; set; }
            public string S_MERKEZI { get; set; }
            
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
            List<StokFisAraViewModel> hareketler = new List<StokFisAraViewModel>();

            var zaman = new DateTime();
            var sonzaman = new DateTime();


            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[3];

            aranacaklar[0] = "hareket.CARIKOD";
            aranacaklar[1] = "hareket.FISNO";
            aranacaklar[2] = "CARIAD";



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




            var v = (from a in db.STOK_FIS.Select(pr => new
            {
                hareket = pr,
                CARIAD = pr.CARI.FIRMAUNVANI,

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


                var yenihareket = new StokFisAraViewModel();

                yenihareket.ID = item.hareket.ID;


                yenihareket.CARIKOD = item.hareket.CARIKOD;
                yenihareket.CARIAD = item.CARIAD;
                yenihareket.GENELTOPLAM = item.hareket.GENELTOPLAM.ToString();
                yenihareket.TARIH = item.hareket.TARIH.Value.ToShortDateString();
                yenihareket.S_MERKEZI = item.S_MERKEZI;

                if (!string.IsNullOrEmpty(item.hareket.FISNO))
                    yenihareket.FISNO = item.hareket.FISNO;
                if (item.hareket.TIP == 1)
                {
                    yenihareket.GIRIS = item.hareket.TOPLAMMASRAF.ToString();
                    yenihareket.CIKIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-success"">Giriş</span>";
                }
                else
                {
                    yenihareket.CIKIS = item.hareket.TOPLAMMASRAF.ToString();
                    yenihareket.GIRIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-danger"">Çıkış</span>";

                }
                yenihareket.DURUM = item.hareket.DURUM.ToString();
                hareketler.Add(yenihareket);



            }

            Disposedb();
            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





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
            List<StokHareketAraViewModel> hareketler = new List<StokHareketAraViewModel>();

            var zaman = new DateTime();
            var sonzaman = new DateTime();


            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[3];

            aranacaklar[0] = "hareket.STOKKODU";
            aranacaklar[1] = "CARIKOD";
            aranacaklar[2] = "STOKAD";



            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";
            if (id != 0)
            {
                query += $"&&({  "hareket.STOKID" }=={ id })";
            }
            int b = 0;
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
                        query += $"{  filterler[i].verismi }>(\"{ filterler[i].deger }\")&&{  filterler[i].verismi }<(\"{ filterler[i].deger2 }\")";
                    if (filterler[i].filtretipi == 4)
                    {

                        zaman = DateTime.ParseExact(filterler[i].deger, "MM/dd/yyyy", null);
                        sonzaman = DateTime.ParseExact(filterler[i].deger2, "MM/dd/yyyy", null);
                        query += "(5==5)";
                    }

                   
                }

            query += ")";




            var v = (from a in db.STOK_HAREKET.Select(pr => new
            {
                hareket = pr,
                STOKAD = pr.STOK.STOKAD,

               CARIAD=pr.CARIID==null?"": pr.CARI.FIRMAUNVANI,
                CARIKOD= pr.CARIID == null ? "" : pr.CARI.CARIKOD,
                DEPO =  pr.DEPOSU.DEPOADI,
                SMERKEZI = pr.S_MERKEZI.ACIKLAMA
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


                var yenihareket = new StokHareketAraViewModel();

                yenihareket.ID = item.hareket.ID;
                if (id == 0)
                {

                
                    yenihareket.STOKKODU = item.hareket.STOKKODU;
                    yenihareket.STOKAD = item.STOKAD;
               
                }
                else
                {

                    yenihareket.STOKKODU = "";
                    yenihareket.STOKAD ="";
                }

            
               
                if (item.hareket.CreateDate != null)
                    yenihareket.TARIH = item.hareket.TARIH.ToShortDateString();
                if (item.hareket.BELGENO != null)
                    yenihareket.BELGENO = item.hareket.BELGENO.ToString();
                
                if (item.hareket.TIPI == CARI_HAREKET.tip.Giriş)
                {
                    if (item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.StokFişi)
                    {
                        yenihareket.ISLEMTURU = "StokGiriş Fişi";
                    }
                   
                    
                    if (item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.Fatura)
                    {
                        yenihareket.ISLEMTURU = "AlışFaturası";
                    }
                    if (item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.İrsaliye)
                    {
                        yenihareket.ISLEMTURU = "Alışİrsaliye";
                    }
                    if (item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.Fatura)
                    {
                        yenihareket.ISLEMTURU = "Fatura";
                    }
                    if(item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.EFatura)
                        yenihareket.ISLEMTURU = "EFatura";
                    yenihareket.TIPI = @"<span class=""badge badge-success"">Giriş</span>";
                    if (item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.Üretim)
                    {
                        yenihareket.ISLEMTURU = "Üretim";
                    }
                }
                else
                {

                    if (item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.StokFişi)
                    {
                        yenihareket.ISLEMTURU = "StokÇıkış Fişi";
                    }


                    if (item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.Fatura)
                    {
                        yenihareket.ISLEMTURU = "SatışFaturası";
                    }
                    if (item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.İrsaliye)
                    {
                        yenihareket.ISLEMTURU = "Satışİrsaliye";
                    }
                    if (item.hareket.ISLEMTURU == STOK_HAREKET.stoktur.Üretim)
                    {
                        yenihareket.ISLEMTURU = "Üretim";
                    }

                    yenihareket.TIPI = @"<span class=""badge badge-danger"">Çıkış</span>";

                }
                if (item.hareket.TIPI == CARI_HAREKET.tip.Devir)
                {
                    yenihareket.TIPI = @"<span class=""badge badge-primary"">Devir</span>";
                }
                if (item.CARIKOD != null)
                    yenihareket.CARIKOD = item.CARIKOD.ToString();

                yenihareket.STOKMIKTAR = item.hareket.STOKMIKTAR.ToString();
                if (item.CARIAD != null)
                    yenihareket.CARIAD = item.CARIAD;
                if (item.hareket.MIKTAR != null)
                    yenihareket.MIKTAR = item.hareket.MIKTAR.ToString();
                if (item.hareket.BIRIM != null)
                    yenihareket.BIRIM = anddb.STOK_BIRIMLER.Find(item.hareket.BIRIM).BIRIMADI;
                if(item.hareket.FIYAT !=null)
                    yenihareket.FIYAT = item.hareket.FIYAT.ToString();
                if (item.hareket.TL_TUTAR != null)
                    yenihareket.TL_TUTAR = item.hareket.TL_TUTAR.ToString();
                if (item.hareket.DOVIZ_TUTAR != null)
                    yenihareket.DOVIZ_TUTAR = item.hareket.DOVIZ_TUTAR.ToString();

                if (item.hareket.SONMALIYET != null)
                    yenihareket.SONMALIYET = item.hareket.SONMALIYET.ToString();
                if (item.hareket.MALIYETORT != null)
                    yenihareket.MALIYETORT = item.hareket.MALIYETORT.ToString();

                if (item.hareket.DOVIZ_SONMALIYET != null)
                    yenihareket.DOVIZ_SONMALIYET = item.hareket.DOVIZ_SONMALIYET.ToString();
                if (item.hareket.DOVIZ_MALIYETORT != null)
                    yenihareket.DOVIZ_MALIYETORT = item.hareket.DOVIZ_MALIYETORT.ToString();
                if (item.hareket.KDVLIFIYAT != null)
                    yenihareket.KDVLIFIYAT = item.hareket.KDVLIFIYAT.ToString();
                yenihareket.SMERKEZI = item.SMERKEZI;
                yenihareket.DEPO = item.DEPO;

                hareketler.Add(yenihareket);


            }
            Disposedb();

            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }


        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

        }




        public ActionResult STOKFISKART(int? id,bool? print , int? tip, int? carid)
        {
            changestring();
            var model = new modelimiz();
            if (print != null)
                model.print = (bool)print;
            model.firmalogo = db.FIRMA.FirstOrDefault().FirmaResimUrl;
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.Hareket = new STOK_HAREKET();
            model.cARI_HAREKETs = new List<CARI_HAREKET>();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.DEPOs = db.STOK_DEPO.Where(x => x.deleted == null).ToList();
            model.STOK_BIRIMLERs = anddb.STOK_BIRIMLER.Where(x => x.deleted == null).ToList();
            model.STOK_FISs = db.STOK_FIS.Count();
            if (carid != null)
            {
                var cari = db.CARI_BASLIK.Find(carid);
                model.carikod = cari.ID.ToString();
                model.cariad = cari.CARIKOD + "/" + cari.FIRMAUNVANI;

            }


            if (id == null)
            {

                model.fis = new STOK_FIS();
                model.STOK_FIS_HAREKETs = new List<STOK_FIS_HAREKET>();
                if (tip != null)
                    model.fis.TIP = (int)tip;
                else
                    model.fis.TIP = 1;
            }
            else
            {
                model.fis = db.STOK_FIS.Include(x => x.CARI).SingleOrDefault(x => x.ID == id);
                model.STOK_FIS_HAREKETs = db.STOK_FIS_HAREKET.Where(x => x.fisid == id).Include(x => x.STOK).ToList();

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


   
   

        public ActionResult STOKFISLISTE()
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
       
        // GET: STOK_HAREKET
        public ActionResult Index(int? id)
        {
            changestring();
            var model = new CARI_HAREKETController.yenimodel();
            if (id != null)
            {
                var stok = db.STOK.Find(id);

                model.ismi = stok.STOKAD;
                model.kodu = stok.STOKKODU;
                model.id = stok.ID;

            }
            model.DEPOs = db.STOK_DEPO.Where(x => x.deleted == null).ToList();
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
