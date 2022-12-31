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
    public class IRSALIYEController : Controller
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
                        if (alt.ekleme.Contains("İrsaliyeler"))
                            ekleme = true;
                        if (alt.silme.Contains("İrsaliyeler"))
                            silme = true;
                        if (alt.degistir.Contains("İrsaliyeler"))
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
            public STOK STOK { get; set; }
            public STOK_HAREKET Hareket { get; set; }
            public KUR_BASLIK Kur { get; set; }
            public IEnumerable<CARI_BASLIK> cARI_BASLIKs { get; set; }
            public IEnumerable<CARI_HAREKET> cARI_HAREKETs { get; set; }
            public IEnumerable<STOK> STOKs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<STOK_HAREKET> STOK_HAREKETs { get; set; }
            public IEnumerable<STOK_BIRIM> STOK_BIRIMLERs { get; set; }

            public IRSALIYE IRSALIYE { get; set; }
            public int IRSALIYELER { get; set; }
            public IEnumerable<IRSALIYE_HAREKET> IRSALIYE_HAREKETLERİ { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }
            public IEnumerable<STOK_DEPO> DEPOs { get; set; }

        }
        [HttpPost]
        public JsonResult fissil(int id)
        {
            changestring();
            var fis = db.IRSALIYE.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.IRSALIYE_HAREKET.Where(x => x.IRSALIYEID == id && x.deleted != 1);

            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.IRSNO && x.deleted != 1).ToList();
            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.IRSNO && x.deleted != 1).ToList();


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
                    item.deleted = 1;

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
                }

                foreach (var item in fishareketleri)
                {
                    item.deleted = 1;
                }
                fis.deleted = 1;
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
    
        public void fisyenile(int id)
        {
            
            var fis = db.IRSALIYE.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.IRSALIYE_HAREKET.Where(x => x.IRSALIYEID == id && x.deleted != 1);

            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.IRSNO && x.deleted != 1).ToList();
            var hareketler = db.STOK_HAREKET.Where(x => x.BELGENO == fis.IRSNO && x.deleted != 1).ToList();


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
                item.deleted = 1;
                var depotoplam = db.STOK_DEPO_TOPLAM.Where(x => x.DEPOSUID == item.DEPOSUID).Where(x => x.STOKID == item.STOKID).FirstOrDefault();


                if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                {
                    depotoplam.MIKTAR -= stokhareket.MIKTAR;
                }
                else
                {
                    depotoplam.MIKTAR += stokhareket.MIKTAR;

                }
                //stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();
                db.SaveChanges();
                }


                var stokhareketlerii = db.STOK_HAREKET.Where(x => x.BELGENO == fis.IRSNO && x.deleted != 1);
                db.STOK_HAREKET.RemoveRange(stokhareketlerii);
                var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.IRSNO && x.deleted != 1);
                db.CARI_HAREKET.RemoveRange(cariharetlerii);
                db.IRSALIYE_HAREKET.RemoveRange(fishareketleri);
                db.SaveChanges();

            






        }

        [HttpPost]
        public JsonResult datagonder(irsaliyefismodel gelenveri)
        {
            changestring();



            var id = 0;

            double toplamtutar = 0;
            double toplamiktar = 0;
            double toplamdovuz = 0;
            var irsaliye = new IRSALIYE();
            var carid = int.Parse(gelenveri.CARIKOD);
            var cari = db.CARI_BASLIK.Find(carid);
         
            irsaliye.CARI = cari;
            irsaliye.CARIKOD = irsaliye.CARI.CARIKOD;
            irsaliye.CreateDate = DateTime.Now;
            irsaliye.CreateUserID =userid;
            irsaliye.DURUM = IRSALIYE.drumlar.Faturalaştırılmadı;
            irsaliye.TIP = (int)gelenveri.TIPI;
            irsaliye.IRSNO = gelenveri.FISNO.ToString();
            irsaliye.ACIKLAMA = gelenveri.NOT;
            irsaliye.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
            irsaliye.TARIH = DateTime.Parse(gelenveri.TARIH);
            irsaliye.ODEMETARIHI = DateTime.Parse(gelenveri.ODEMETARIH);
            irsaliye.KDVDAHIL = gelenveri.KDVDAHIL;
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
                        toplamtutar += double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                        toplamiktar += double.Parse(item.MIKTAR);

                        toplamdovuz += double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ",")) / double.Parse(item.PARABIRIMIKUR.Replace(".", ","));
                    }

                    irsaliye.TOPLAMTUTAR = toplamtutar;
                    irsaliye.GENELTOPLAM = toplamiktar;
                    var list = db.IRSALIYE.SingleOrDefault(x => x.IRSNO == irsaliye.IRSNO);
                    if (list == null)
                    {
                        db.IRSALIYE.Add(irsaliye);
                        db.SaveChanges();
                        id = irsaliye.ID;

                    }
                    else
                    {
                    
                        list.UpdateDate = DateTime.Now;
                        list.UpdateUserID = 1;
                        list.S_MERKEZIID = irsaliye.S_MERKEZIID;
                        list.TARIH = irsaliye.TARIH;
                        list.ACIKLAMA = irsaliye.ACIKLAMA;
                        list.GENELTOPLAM = irsaliye.GENELTOPLAM;
                        list.TOPLAMTUTAR = irsaliye.TOPLAMTUTAR;
                        db.SaveChanges();
                        fisyenile(list.ID);
                        id = list.ID;
                    }

                    foreach (var item in gelenveri.gelenhareket)
                    {
                        double tutar = 0;

                        tutar = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));


                        var stokid = item.STOKID;

                        var stok = db.STOK.Where(x => x.ID == stokid).FirstOrDefault();
                        var stokhareket = new STOK_HAREKET();
                        stokhareket.STOK = stok;
                        stokhareket.STOKKODU = stokhareket.STOK.STOKKODU;
                        stokhareket.CARIID = cari.ID;
                        stokhareket.BIRIM = anddb.STOK_BIRIMLER.Where(x => x.BIRIMADI == item.BIRIM).FirstOrDefault().ID;
                        stokhareket.CreateDate = DateTime.Now;
                        stokhareket.CreateUserID = userid;
                        stokhareket.BELGENO = gelenveri.FISNO;
                        stokhareket.TARIH = DateTime.Parse(gelenveri.TARIH);
                        stokhareket.ISLEMTURU = STOK_HAREKET.stoktur.İrsaliye;
                        stokhareket.MIKTAR = double.Parse(item.MIKTAR.Replace(".", ","));
                        stokhareket.FIYAT = double.Parse(item.FIYAT.Replace(",", "").Replace(".", ","));
                        stokhareket.TIPI = gelenveri.TIPI;
                        stokhareket.S_MERKEZIID = irsaliye.S_MERKEZIID;
                        stokhareket.PARABIRIMI = item.PARABIRIMI;
                        stokhareket.KUR_FIYAT = (double)double.Parse(item.PARABIRIMIKUR.Replace(",", "").Replace(".", ","));
                        stokhareket.TL_FIYAT = double.Parse(item.FIYAT.Replace(",", "").Replace(".", ",")) * stokhareket.KUR_FIYAT;
                        stokhareket.TUTAR = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                        stokhareket.TL_TUTAR = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                        stokhareket.DOVIZ_TUTAR = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ",")) / stokhareket.KUR_FIYAT;
                        stokhareket.KDVLIFIYAT = stokhareket.FIYAT+((stokhareket.FIYAT*(double)stok.KDV)/100);


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
                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
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
                                    hareketz.DOVIZ_STOKALIS_TOPLAM += stokhareket.TUTAR* stokhareket.KUR_FIYAT;
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

                        //stokhareket.SONMALIYET = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));

                        if (stokhareket.TIPI == CARI_HAREKET.tip.Giriş)
                        {

                            
                                stok.HAMALISFIYAT = stokhareket.FIYAT ;

                           
                           
                            stok.TOPGIREN += double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                            var tutara = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));


                            stok.TL_ALIS_TOPLAM += tutara;
                            stok.DOVIZ_ALIS_TOPLAM += tutara / stokhareket.KUR_FIYAT;



                        }
                        else
                        {
                           
                                stok.HAMSATISFIYAT = stokhareket.FIYAT;
                          
                        
                            stok.TOPCIKAN += double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                        }

                        stokhareket.ACIKLAMA = item.ACIKLAMA;
                        stokhareket.DEPOSUID = item.DEPOID;


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
                        ////stok.MALIYETORT = stok.TOPGIREN / db.STOK_HAREKET.Where(x => x.STOKID == stok.ID && x.TIPI != CARI_HAREKET.tip.Devir && x.deleted != 1).Count();
                        db.SaveChanges();
                    }

                    db.SaveChanges();
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var fishareket = new IRSALIYE_HAREKET();
                        var stokid = item.STOKID;

                        fishareket.IRSNO = gelenveri.FISNO;
                        fishareket.BIRIM = item.BIRIM;
                        fishareket.IRSALIYEID = db.IRSALIYE.Find(id).ID;
                        fishareket.ACIKLAMA = item.ACIKLAMA;
                        fishareket.STOK = db.STOK.Find(stokid);
                        fishareket.NETFIYAT = double.Parse(item.KFIYAT.Replace(",", "").Replace(".", ","));
                        fishareket.PARABIRIMI = item.PARABIRIMI;
                        fishareket.PARAKUR = double.Parse(item.PARABIRIMIKUR.Replace(",", "").Replace(".", ","));
                        fishareket.MIKTAR = double.Parse(item.MIKTAR.Replace(",", "").Replace(".", ","));
                        fishareket.FIYAT = double.Parse(item.FIYAT.Replace(",", "").Replace(".", ","));
                        fishareket.ISK1 = double.Parse(item.ISKONTO.Replace(".", ","));
                        fishareket.TUTAR = double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                        fishareket.KDVTUTARI = double.Parse(item.KDVTUTAR.Replace(",", "").Replace(".", ","));
                        fishareket.TOPLAMFIYAT = double.Parse(item.TOPLAM.Replace(",", "").Replace(".", ","));
                        

                        db.IRSALIYE_HAREKET.Add(fishareket);
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
                    return Json("Başarısız!");
                }


             
            }
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
            List<İrsaliyeAraViewModel> hareketler = new List<İrsaliyeAraViewModel>();
            var zaman = new DateTime();
            var sonzaman = new DateTime();



            object sayi = 26;
            var arama = search.ToLower();
      

            string[] aranacaklar = new string[3];

            aranacaklar[0] = "hareket.CARIKOD";
            aranacaklar[1] = "hareket.IRSNO";
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




            var v = (from a in db.IRSALIYE.Select(pr => new
            {
                hareket = pr,
                CARIADI = pr.CARI.FIRMAUNVANI,

                S_MERKEZI = pr.S_MERKEZI.ACIKLAMA
            }).Where(x=>x.hareket.deleted != 1).Where(x => DbFunctions.TruncateTime(x.hareket.TARIH) >= DbFunctions.TruncateTime(zaman) && DbFunctions.TruncateTime(x.hareket.TARIH) <= DbFunctions.TruncateTime(sonzaman)).Where(query) select a);


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


                var yenihareket = new İrsaliyeAraViewModel();

                yenihareket.ID = item.hareket.ID;
                yenihareket.S_MERKEZI = item.S_MERKEZI;

                yenihareket.CARIKOD = item.hareket.CARIKOD;
                yenihareket.CARIADI = item.CARIADI;
                if (item.hareket.TIP == 1)
                {
                    yenihareket.GIRIS = item.hareket.TOPLAMTUTAR.ToString();
                    yenihareket.CIKIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-success"">Giriş</span>";
                }
                else
                {
                    yenihareket.CIKIS = item.hareket.TOPLAMTUTAR.ToString();
                    yenihareket.GIRIS = "";
                    yenihareket.TIP = @"<span class=""badge badge-danger"">Çıkış</span>";

                }
                yenihareket.GENELTOPLAM = item.hareket.GENELTOPLAM.ToString();
                yenihareket.TARIH = item.hareket.TARIH.Value.ToShortDateString();
                yenihareket.DURUM = item.hareket.DURUM.ToString();
                if (!string.IsNullOrEmpty(item.hareket.IRSNO))
                    yenihareket.IRSNO = item.hareket.IRSNO;

      

                hareketler.Add(yenihareket);



            }


            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }

        [HttpPost]
        public JsonResult irsaliyehareketigetir(int id)
        {
            changestring();
            var list = new List<IRSALIYE_HAREKET>();
            var items = db.IRSALIYE_HAREKET.Include(x => x.STOK).Where(x => x.IRSALIYEID == id && x.KULLANIMDA != 1).ToList();
            foreach(var item in items)
            {
                var yenihareket =new IRSALIYE_HAREKET();
                yenihareket.IRSNO = item.IRSNO;
                yenihareket.ID = item.ID;
                yenihareket.STOKID = item.STOKID;
                yenihareket.ACIKLAMA = item.ACIKLAMA;
                yenihareket.MIKTAR = item.MIKTAR;
                yenihareket.BIRIM = item.BIRIM;
                yenihareket.TOPLAMFIYAT = item.TOPLAMFIYAT;
                     yenihareket.ISK1 = item.ISK1;
                     yenihareket.PARABIRIMI = item.PARABIRIMI;
                     yenihareket.PARAKUR = item.PARAKUR;
                     yenihareket.TUTAR = item.TUTAR;
                     yenihareket.KDVTUTARI = item.KDVTUTARI;
                yenihareket.STOKKODU = item.STOK.STOKKODU+"/"+item.STOK.STOKAD;
               list.Add(yenihareket);
            }


                

            return Json( list , JsonRequestBehavior.AllowGet);

        }
        public class irsaliyehareketimodel
        {
            public int id { get; set; }
            public string stokkod { get; set; }
            public string irsno { get; set; }
            public string irsid { get; set; }
            public string stokad{ get; set; }
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
        public JsonResult irsaliyehareketigetirefatura(int id)
        {
            changestring();

            var hareketler = new List<irsaliyehareketimodel>();
            var irs = db.IRSALIYE.Find(id);
            foreach (var item in db.IRSALIYE_HAREKET.Where(x => x.IRSALIYEID == id).ToList())
            {
                var hareket = new irsaliyehareketimodel();
                hareket.irsno = irs.IRSNO;
                hareket.irsid = item.ID.ToString();
                hareket.birim = item.BIRIM;
                hareket.fiyat = item.TOPLAMFIYAT.ToString().Replace(",",".");
                hareket.iskonto = item.ISK1.ToString().Replace(",", ".");
                var iskonto = ((item.MIKTAR * item.ISK1 * item.TOPLAMFIYAT) / 100);
                var toplam = (item.MIKTAR * item.TOPLAMFIYAT)- iskonto;
                hareket.iskontotutar = ((item.MIKTAR*item.ISK1 * item.TOPLAMFIYAT)/100).ToString().Replace(",", ".");
                hareket.miktar = item.MIKTAR.ToString();
              var stok=  db.STOK.Where(x => x.ID == item.STOKID).First();
                hareket.stokkod = stok.STOKKODU;
                hareket.stokad = stok.STOKAD;
                hareket.id = stok.ID;
                hareket.kdvoranı = stok.KDV.ToString(); 
                hareket.kdvtutar=((toplam * stok.KDV)/100).ToString().Replace(",",".");
                hareket.toplam= (toplam).ToString().Replace(",", ".");
                hareketler.Add(hareket) ;
            }
            return Json(hareketler, JsonRequestBehavior.AllowGet);

        }
        
        public class irsaliyefismodel
        {


            public string CARIKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string ODEMETARIH { get; set; }
            public string NOT { get; set; }
            public int KDVDAHIL { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
            public string DEPO { get; set; }
            public List<irsaliyemodelhareket> gelenhareket { get; set; }

            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class irsaliyemodelhareket
        {



            public int STOKID { get; set; }
            public string ACIKLAMA { get; set; }

            public string MIKTAR { get; set; }
            public string BIRIM { get; set; }
            public string KFIYAT { get; set; }
            public string FIYAT { get; set; }
            public string ISKONTO { get; set; }

            public string PARABIRIMI { get; set; }

            public string PARABIRIMIKUR { get; set; }
            public string TUTAR { get; set; }
            public string TOPLAM { get; set; }
            public string KDVTUTAR { get; set; }
            public int DEPOID { get; set; }

        }
        public class İrsaliyeAraViewModel
        {
            public int ID { get; set; }
            
                  public string CARIADI { get; set; }
            public string S_MERKEZI { get; set; }
            public string CARIKOD { get; set; }
            public string TARIH { get; set; }
            public string IRSNO { get; set; }
            public string TIP { get; set; }
            public string GENELTOPLAM { get; set; }
            public string DURUM { get; set; }
            public string GIRIS { get; set; }
            public string CIKIS { get; set; }
        }
        public class İrsaliyeHareketAraViewModel
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

        public ActionResult IRSALIYEKART(int? id, int? tip)
        {
            changestring();
            var model = new modelimiz();
           
       
           
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
          
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.STOK_BIRIMLERs = anddb.STOK_BIRIMLER.Where(x => x.deleted == null).ToList();
            model.DEPOs = db.STOK_DEPO.Where(x => x.deleted == null).ToList();
            model.IRSALIYELER = db.IRSALIYE.Where(x => x.deleted == null).Count();
            if (id == null)
            {

                model.IRSALIYE = new IRSALIYE();
                model.IRSALIYE_HAREKETLERİ = new List<IRSALIYE_HAREKET>();
                if (tip != null)
                    model.IRSALIYE.TIP = (int)tip;
                else
                    model.IRSALIYE.TIP = 1;
            }
            else
            {
                model.IRSALIYE = db.IRSALIYE.Include(x => x.CARI).SingleOrDefault(x => x.ID == id);
                model.IRSALIYE_HAREKETLERİ = db.IRSALIYE_HAREKET.Where(x => x.IRSALIYEID == id).Include(x => x.STOK).ToList();

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
   
        public ActionResult IRSALIYELISTE()
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
