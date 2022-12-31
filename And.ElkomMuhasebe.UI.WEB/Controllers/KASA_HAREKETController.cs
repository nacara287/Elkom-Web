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
using System.Linq.Dynamic.Core;
using And.ElkomMuhasebe.UI.WEB.Controllers;
using System.Data.Entity;
using DbFunctions = System.Data.Entity.DbFunctions;
using EntityState = System.Data.Entity.EntityState;
using System.Globalization;
using System.Data.Entity.SqlServer;
namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class KASA_HAREKETController : Controller
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
                    if (alt.görme.Contains("Kasa Hareketleri Ve Fişleri"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Kasa Hareketleri Ve Fişleri"))
                            ekleme = true;
                        if (alt.silme.Contains("Kasa Hareketleri Ve Fişleri"))
                            silme = true;
                        if (alt.degistir.Contains("Kasa Hareketleri Ve Fişleri"))
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

        public class yenimodel
        {
            public string ismi { get; set; }
            public string kodu { get; set; }
            public int id { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }

        }

        public class FisaravieweNodel
        {
            public int ID { get; set; }
            public string KASAKODU { get; set; }
            public string KASAADI { get; set; }
            
            public string FISNO { get; set; }
            public string TIP { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string GIRIS { get; set; }
            public string CIKIS { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
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

        [HttpPost]
        public JsonResult RaporGetir(int? id)
        {
            changestring();
            var firma = db.FIRMA.FirstOrDefault();
            var kasa = db.KASA.Find(id);
            var hareketleri = db.KASA_HAREKET.Where(x => x.KASAID == id).OrderByDescending(p => p.CreateDate).Take(100).ToList();
            double alacak = 0;
            double borc = 0;
            double bakiye = 0;

            var sayfa = @"<html lang=""tr"">
  <head>
    <meta http-equiv=""content-type"" content=""text/html;charset=UTF-8"" />
    <meta charset=""utf-8"" />
    <title>Rapor</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no, shrink-to-fit=no"" />

   

  </head>
  <body class=""fixed-header"">

    <div class=""container-fluid"">
      <div class=""row""> 
        <div class=""col-md-12 text-center"">
          <h4 class=""m-0"">Kasa Hareket Ekstresi</h4>
          <hr>
        </div>
      </div>
     <div class=""row d-flex justify-content-between align-items-end"">
        <div class=""col"">
          <span class=""font-weight-bold"">" + firma.FIRMAADI + @"</span> <br>
          <span>" + firma.ADRESI1 + @"</span>
        </div>
        <div class=""col d-flex justify-content-end"">
          <span class=""mr-3 font-weight-bold"">" + DateTime.Now.ToShortDateString() + @"</span>
          <span class=""font-weight-bold"">Sayfa : 1</span>
        </div>
      </div>

      <hr>
      <div class=""row"">
        <div class=""col"">
          <h6 class=""my-0"">Kasa Kodu</h6> <span class=""text-muted"">" + kasa.KASAKODU + @"</span>
        </div>
        <div class=""col"">
          <h6 class=""my-0"">Kasa Adı</h6> <span class=""text-muted"">" + kasa.KASAADI + @"</span>
        </div>
        <div class=""col"">
          <h6 class=""my-0"">Kasa Tipi</h6> <span class=""text-muted"">" + kasa.TIPI.ToString() + @"</span>
        </div>
        <div class=""col"">
          <h6 class=""my-0"">Kasa Bakiye</h6> <span class=""text-muted"">" + kasa.BAKIYE + @"</span>
        </div>
        <div class=""col text-right"">
          <h6 class=""my-0"">Ortalama Vade: 46 Gün</h6>
          <h6 class=""my-0"">Normal Vade: 46 Gün</h6>
          <span class=""text-danger"">Risk: 2.950,00</span>
        </div>
      </div>
        <div class=""table-responsive"">
        <table class=""table table-striped table-sm"">
          <thead>
          <tr>
            <th>Tarih</th>
            <th>İşlem Türü</th>
  <th>İşlem Tipi</th>

            <th>Belge No</th>
           
            <th>Açıklama</th>
            <th class=""text-center"">Borç/Giriş</th>
            <th class=""text-center"">Alacak/Çıkış</th>
            <th class=""text-center"">Durum Bakiye</th>
          </tr>
          </thead>
          <tbody>";
            foreach (var item in hareketleri)
            {
                var bos = "";
                var kayıtsekli = "";
                var islemno = "";
                var altmetin = "";
                var vade = "";


                alacak += item.ALACAK ?? 0;

                borc += item.BORC ?? 0;
              
                if (item.ISLEMNO != null)
                    islemno = item.ISLEMNO.ToString();
           
                altmetin = ayrintigetirvoid(item.ISLEMNO, item.ISLEMTURU.ToString());
                sayfa += @"<tr>
<td>" + item.TARIHSAAT + @"</td>
<td>" + item.ISLEMTURU.ToString() + @"</td>
<td>" + item.TIPI.ToString() + @"</td>

<td>" + islemno + @"</td>

<td>" + item.ACIKLAMA + @"</td>
<td>" + item.BORC + @"</td>
<td>" + item.ALACAK + @"</td>
<td>" + item.BAKIYE + @"</td>
</tr><tr>" + altmetin + @"</tr>
";




            }
            sayfa += @"
          </tbody>
          <thead>
          <tr>
     <th class=""text-right"" >Toplam Kayıt</th>
            <th class=""text-right"" >Borç/Giriş</th>
            <th class=""text-center"">Alacak/Çıkış</th>
            <th class=""text-center"">Bakiye</th>
          </tr>
          </thead>
          <tfoot>
          <tr>
            <td colspan = ""2"" class=""text-muted"">Listelenen Kayıt Sayısı :" + hareketleri.Count() + @"</td>
          
            <th class=""text-right"" scope=""row"" colspan=""2"">Toplam:</th>
            <th class=""text-right"" scope=""row"" >" + borc + @"</th>
            <th class=""text-right"" scope=""row"" >" + alacak + @"</th>
            <th class=""text-right"" scope=""row"" >" + (borc - alacak) + @"</th>
          </tr>
          </tfoot>
        </table>
      </div>
</div>
</div>
  </body>
</html>
";



            return Json(sayfa, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult FisData(string search, string order, int offset, int limit, string sort, filtermodel[] filterler)
        {

            if (sort == "GIRIS" || sort == "CIKIS")
                sort = "TOPLAMTUTAR";
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

            aranacaklar[0] = "hareket.KASAKODU";
            aranacaklar[1] = "hareket.FISNO";
            aranacaklar[2] = "KASAADI";
            


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




            var v = (from a in db.KASA_FISI.Select(pr => new
            {
                hareket = pr,
                KASAADI = pr.KASA.KASAADI,
                SORUMLULUK_MERKEZI=pr.S_MERKEZI.ACIKLAMA
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


                var yenihareket = new FisaravieweNodel();

                yenihareket.ID = item.hareket.ID;


                yenihareket.KASAKODU = item.hareket.KASAKODU;
                yenihareket.KASAADI = item.KASAADI;

                yenihareket.TARIH = item.hareket.TARIH.Value.ToShortDateString();

                if (!string.IsNullOrEmpty(item.hareket.ACIKLAMA))
                    yenihareket.NOT = item.hareket.ACIKLAMA;

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

                if (!string.IsNullOrEmpty(item.hareket.FISNO))
                    yenihareket.FISNO = item.hareket.FISNO;


                yenihareket.SORUMLULUK_MERKEZI = item.SORUMLULUK_MERKEZI;
                hareketler.Add(yenihareket);



            }


            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }




        public class KasaHareketAraViewModel
        {
            public int ID { get; set; }
            public string KASAKODU { get; set; }
            public string KASADI { get; set; }
   
            public string TARIHSAAT { get; set; }
            public string ISLEMTURU { get; set; }
            
            public string TIPI { get; set; }
            public string ISLEMNO { get; set; }
            public string DOSYANO { get; set; }

            public string ACIKLAMA { get; set; }
            public string ILGILI { get; set; }
            public double? BORC { get; set; }
            public double? ALACAK { get; set; }
            public double? BAKIYE { get; set; }
            public string S_MERKEZI { get; set; }

        }
        public class carifismodel
        {


            public string CARIKOD { get; set; }
            public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }

            public List<carifismodelhareket> gelenhareket { get; set; }
         

            public CARI_HAREKET.tip TIPI { get; set; }

        }
        public class carifismodelhareket
        {


            public KASA_HAREKET.kasahareket HAREKET { get; set; }

            public string ILGILI { get; set; }
            public string ILGILIADI { get; set; }
            public string ACIKLAMA { get; set; }
    
            public string TUTAR { get; set; }


            public string PARABIRIMI { get; set; }
            public string PARAKURU { get; set; }
            public string NETTUTAR { get; set; }
        }
        public class modelimiz
        {
            public KASA Kasa { get; set; }
            public KASA_HAREKET kASA_HAREKET { get; set; }
            public KUR_BASLIK Kur { get; set; }

            public IEnumerable<KASA> KASAs { get; set; }
            public IEnumerable<KUR_BASLIK> KUR_BASLIKa { get; set; }
            public IEnumerable<KASA_HAREKET> KASA_HAREKETs { get; set; }

            public KASA_FISI fis { get; set; }
            public int KASA_FISIs { get; set; }
            public IEnumerable<KASA_FISI_HAREKET> KASA_FISI_HAREKETs { get; set; }
            public IEnumerable<SORUMLULUK_MERKEZI> sORUMLULUK_MERKEZIs { get; set; }
            public IEnumerable<CARI_BASLIK> cARIs { get; set; }
            public IEnumerable<BANKA> bANKAs { get; set; }
            public IEnumerable<PERSONEL> pERSONELs { get; set; }
            public IEnumerable<FIRMA> fIRMAs { get; set; }
            public bool print { get; set; }

        }
        public class filtermodel
        {


            public string verismi { get; set; }

            public string deger { get; set; }
            public string deger2 { get; set; }
            public int filtretipi { get; set; }

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
            List<KasaHareketAraViewModel> hareketler = new List<KasaHareketAraViewModel>();


            var zaman = new DateTime();
            var sonzaman = new DateTime();

            object sayi = 26;
            var arama = search.ToLower();


            string[] aranacaklar = new string[4];

            aranacaklar[0] = "hareket.ISLEMNO";
            aranacaklar[1] = "hareket.ACIKLAMA";
            aranacaklar[2] = "KASADI";
            aranacaklar[3] = "hareket.KASAKODU";


            var query = $"({  aranacaklar[0] }.ToLower().Contains(\"{ arama }\")";
            for (int i = 1; i < aranacaklar.Length; i++)
            {
                query += "||";
                query += $"{  aranacaklar[i] }.ToLower().Contains(\"{ arama }\")";

            }
            query += ")";
            if (id != 0)
            {
                query += $"&&({"hareket.KASAID"}=={ id })";
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




            var v = (from a in db.KASA_HAREKET.Select(pr => new
            {
                hareket = pr,
                KASADI = pr.KASA.KASAADI,

                S_MERKEZI = pr.S_MERKEZI.ACIKLAMA
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

                var yenihareket = new KasaHareketAraViewModel();

                yenihareket.ID = item.hareket.ID;
                if (id == 0)
                {

                    yenihareket.KASAKODU = item.hareket.KASAKODU;
                    yenihareket.KASADI = item.KASADI;
                }
                else
                {
                    yenihareket.KASAKODU = "";
                    yenihareket.KASADI = "";
                }
            
                yenihareket.ID = item.hareket.ID;
                yenihareket.DOSYANO = item.hareket.DOSYANO;
                yenihareket.TARIHSAAT = item.hareket.TARIHSAAT.ToShortDateString();
            

                if (item.hareket.TIPI == CARI_HAREKET.tip.Giriş)
                {
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.CariFişi)
                    {
                        yenihareket.ISLEMTURU = "Tahsilat Fişi";
                    }
                   
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.KasaFişi)
                    {
                        yenihareket.ISLEMTURU = "KasaGiriş Fişi";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.Banka)
                    {
                        yenihareket.ISLEMTURU = "BankaÇıkış Fişi";
                    }

                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.BankadanPortfoy)
                    {
                        yenihareket.ISLEMTURU = "Bankadan Portfoya Verildi";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.Gelir)
                    {
                        yenihareket.ISLEMTURU = "Gelir";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.Gider)
                    {
                        yenihareket.ISLEMTURU = "Gider";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.TÇek)
                    {
                        yenihareket.ISLEMTURU = "ÇekTahsil";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.TSenet)
                    {
                        yenihareket.ISLEMTURU = "SenetTahsil";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.Çek)
                    {
                        yenihareket.ISLEMTURU = "ÇekÖdeme";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.Senet)
                    {
                        yenihareket.ISLEMTURU = "SenetÖdeme";
                    }

                    yenihareket.TIPI = @"<span class=""badge badge-success"">Giriş</span>";
                }
                else
                {
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.BankayaTahsilat)
                    {
                        yenihareket.ISLEMTURU = "Bankadya Verildi";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.CariFişi)
                    {
                        yenihareket.ISLEMTURU = "Tediye Fişi";
                    }

                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.KasaFişi)
                    {
                        yenihareket.ISLEMTURU = "KasaÇıkış Fişi";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.Banka)
                    {
                        yenihareket.ISLEMTURU = "BankaGiriş Fişi";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.PerMaaş)
                    {
                        yenihareket.ISLEMTURU = "Personel Maaş";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.Çek)
                    {
                        yenihareket.ISLEMTURU = "ÇekÖdeme";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.Senet)
                    {
                        yenihareket.ISLEMTURU = "SenetÖdeme";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.TÇek)
                    {
                        yenihareket.ISLEMTURU = "ÇekTahsil";
                    }
                    if (item.hareket.ISLEMTURU == KASA_HAREKET.kasaislemtürü.TSenet)
                    {
                        yenihareket.ISLEMTURU = "SenetTahsil";
                    }
                    yenihareket.TIPI = @"<span class=""badge badge-danger"">Çıkış</span>";

                }
                if (item.hareket.TIPI == CARI_HAREKET.tip.Devir)
                {
                    yenihareket.ISLEMTURU = "Devir";
                    yenihareket.TIPI = @"<span class=""badge badge-primary"">Devir</span>";
                }
                yenihareket.ISLEMNO = item.hareket.ISLEMNO;

                if (item.hareket.ACIKLAMA != null)
                    yenihareket.ACIKLAMA = item.hareket.ACIKLAMA;
                else { yenihareket.ACIKLAMA = ""; }
                yenihareket.BORC = item.hareket.BORC;
                yenihareket.ALACAK = item.hareket.ALACAK;
                yenihareket.ILGILI = item.hareket.ILGILI;
  

                yenihareket.BAKIYE = item.hareket.BAKIYE;
          
                    yenihareket.S_MERKEZI = item.S_MERKEZI;

                hareketler.Add(yenihareket); ;



            }


            return Json(new { total = totalRecords, rows = hareketler }, JsonRequestBehavior.AllowGet);





        }


 
        public class filtermodelham
        {

            public int ozelgenel { get; set; }
            public string kasaid { get; set; }

        }

       
        public ActionResult KASAFISKART(int? id, bool? print, int? tip, int? carid)
        {
            changestring();
            var model = new modelimiz();
            if (print != null)
                model.print = (bool)print;
          
    
            model.KUR_BASLIKa = db.KUR_BASLIK.Where(x => x.deleted == null).ToList();
            model.kASA_HAREKET = new KASA_HAREKET();
            model.KASA_HAREKETs = new List<KASA_HAREKET>();
            model.sORUMLULUK_MERKEZIs = db.SORUMLULUK_MERKEZI.Where(x => x.deleted == null).ToList();
            model.KASA_FISIs = db.KASA_FISI.Count();
            if (carid != null)
            {
                var kasa = db.KASA.Find(carid);
                model.Kasa = kasa;
           
            }


            if (id == null)
            {

                model.fis = new KASA_FISI();
                model.KASA_FISI_HAREKETs = new List<KASA_FISI_HAREKET>();
                if (tip != null)
                    model.fis.TIP = (int)tip;
                else
                    model.fis.TIP = 1;
            }
            else
            {
                model.fis = db.KASA_FISI.Include(x => x.KASA).SingleOrDefault(x => x.ID == id);
                model.KASA_FISI_HAREKETs = db.KASA_FISI_HAREKET.Where(x => x.KASA_FISIID == id).ToList();

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


    

   
        public ActionResult KASAFISLISTE()
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
        [HttpPost]
        public JsonResult fissil(int id)
        {
            changestring();
            var fis = db.KASA_FISI.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.KASA_FISI_HAREKET.Where(x => x.KASA_FISIID == id && x.deleted != 1);

            var kasaharetleri = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var bankahareketleri = db.BANKA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var perseonelhareketler = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1).ToList();
            var giderhareketleri = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
           var gelirhareketleri = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
            var kasa = db.KASA.Where(x => x.ID == fis.KASAID).FirstOrDefault();


            var trans = db.Database.BeginTransaction();
            try
            {
                foreach (var item in kasaharetleri)
                {

                    var kasahareket = item;
                    if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new KASA_HAREKET();
                        if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 2)
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
                        if (fis.TIP == 2)
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
                foreach (var item in bankahareketleri)
                {
                    var banka = db.BANKA.Where(x => x.ID == item.BANKAID).FirstOrDefault();
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new BANKA_HAREKET();
                        if (db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 2)
                        {


                            banka.TOPLAMBORC -= carihareket.BORC;


                            foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == banka.BANKAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE -= carihareket.BORC;


                            }
                            db.SaveChanges();
                        }
                        else
                        {



                            banka.TOPLAMALACAK -= carihareket.ALACAK;


                            foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == banka.BANKAKODU && x.deleted != 1))
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


                            banka.TOPLAMBORC -= carihareket.BORC;

                            db.SaveChanges();
                        }
                        else
                        {




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
                foreach (var item in gelirhareketleri)
                {
                    var gelir = db.GELIR_BASLIK.Where(x => x.ID == item.GELIR_BASLIKKID).FirstOrDefault();





                    gelir.TOPLAMTUTAR -= item.TUTARI;


                    db.SaveChanges();
                }
                foreach (var item in giderhareketleri)
                {
                    var gider = db.GIDER_BASLIK.Where(x => x.ID == item.GIDER_BASLIKID).FirstOrDefault();





                    gider.TOPLAMTUTAR -= item.TUTARI;


                    db.SaveChanges();
                }
                foreach (var item in perseonelhareketler)
                {
                    var personel = db.PERSONEL.Where(x => x.ID == item.PERSONELID).FirstOrDefault();
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {

                        var eskihareket = new PERSONEL_HAREKET();
                        if (db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 2)
                        {


                            personel.TOPLAMBORC -= carihareket.BORC;


                            foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE -= carihareket.BORC;


                            }
                            db.SaveChanges();
                        }
                        else
                        {



                            personel.TOPLAMALACAK -= carihareket.ALACAK;


                            foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE += carihareket.ALACAK;


                            }
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (fis.TIP == 2)
                        {


                            personel.TOPLAMBORC -= carihareket.BORC;

                            db.SaveChanges();
                        }
                        else
                        {




                            personel.TOPLAMALACAK -= carihareket.ALACAK;
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
                var bankaharetlerii = db.BANKA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                foreach (var item in bankaharetlerii)
                {

                    item.deleted = 1;

                }
                var personelharetlerii = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1);
                foreach (var item in personelharetlerii)
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
        public ActionResult Rapor(int? id)
        {
            changestring();
            var rapor = new CARI_HAREKETController.rapor();
            var kasa = db.KASA.Find(id);
            var hareketler = db.KASA_HAREKET.Where(x => x.KASAID == kasa.ID).ToList();
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

            rapor.Baslıklar.Add(new CARI_HAREKETController.valler { Baslık = "Kasa Kodu/Adı", Deger = kasa.KASAKODU + "/" + kasa.KASAADI });
            rapor.Baslıklar.Add(new CARI_HAREKETController.valler { Baslık = "Kasa Tipi", Deger = kasa.TIPI.ToString() });

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

        [HttpPost]
        public JsonResult fisyenile(int id)
        {
           
            var fis = db.KASA_FISI.Where(x => x.ID == id && x.deleted != 1).FirstOrDefault();
            var fishareketleri = db.KASA_FISI_HAREKET.Where(x => x.KASA_FISIID == id );

            var kasaharetleri = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var bankahareketleri = db.BANKA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var carihareketleri = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1).ToList();
            var perseonelhareketler = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1).ToList();
            var kasa = db.KASA.Where(x => x.ID == fis.KASAID).FirstOrDefault();

            var giderhareketleri = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
            var gelirhareketleri = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1).ToList();
            

                foreach (var item in kasaharetleri)
                {

                    var kasahareket = item;
                    if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new KASA_HAREKET();
                        if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 2)
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
                        if (fis.TIP == 2)
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
                foreach (var item in bankahareketleri)
                {
                    var banka = db.BANKA.Where(x => x.ID == item.BANKAID).FirstOrDefault();
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {
                        var eskihareket = new BANKA_HAREKET();
                        if (db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 2)
                        {


                            banka.TOPLAMBORC -= carihareket.BORC;


                            foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == banka.BANKAKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE -= carihareket.BORC;


                            }
                            db.SaveChanges();
                        }
                        else
                        {



                            banka.TOPLAMALACAK -= carihareket.ALACAK;

                            foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.CARIKOD == banka.BANKAKODU && x.deleted != 1))
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


                            banka.TOPLAMBORC -= carihareket.BORC;

                            db.SaveChanges();
                        }
                        else
                        {




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

                foreach (var item in perseonelhareketler)
                {
                    var personel = db.PERSONEL.Where(x => x.ID == item.PERSONELID).FirstOrDefault();
                    var carihareket = item;
                    if (DateTime.Now.CompareTo(carihareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                    {

                        var eskihareket = new PERSONEL_HAREKET();
                        if (db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).Count() > 0)
                        {
                            eskihareket = db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                        }
                        else { eskihareket.BAKIYE = 0; }
                        if (fis.TIP == 2)
                        {


                            personel.TOPLAMBORC -= carihareket.BORC;


                            foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE -= carihareket.BORC;


                            }
                            db.SaveChanges();
                        }
                        else
                        {



                            personel.TOPLAMALACAK -= carihareket.ALACAK;


                            foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(carihareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU && x.deleted != 1))
                            {
                                hareketz.BAKIYE += carihareket.ALACAK;


                            }
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (fis.TIP == 2)
                        {


                            personel.TOPLAMBORC -= carihareket.BORC;

                            db.SaveChanges();
                        }
                        else
                        {




                            personel.TOPLAMALACAK -= carihareket.ALACAK;
                            db.SaveChanges();


                        }

                    }
                    item.deleted = 1;
                    db.SaveChanges();
                }
                foreach (var item in gelirhareketleri)
                {
                    var gelir = db.GELIR_BASLIK.Where(x => x.ID == item.GELIR_BASLIKKID).FirstOrDefault();





                    gelir.TOPLAMTUTAR -= item.TUTARI;


                    db.SaveChanges();
                }
                foreach (var item in giderhareketleri)
                {
                    var gider = db.GIDER_BASLIK.Where(x => x.ID == item.GIDER_BASLIKID).FirstOrDefault();





                    gider.TOPLAMTUTAR -= item.TUTARI;


                    db.SaveChanges();
                }
                db.KASA_FISI_HAREKET.RemoveRange(fishareketleri);
                var kasaharetlerii = db.KASA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                db.KASA_HAREKET.RemoveRange(kasaharetlerii);
                var cariharetlerii = db.CARI_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                db.CARI_HAREKET.RemoveRange(cariharetlerii);
                var bankaharetlerii = db.BANKA_HAREKET.Where(x => x.ISLEMNO == fis.FISNO && x.deleted != 1);
                db.BANKA_HAREKET.RemoveRange(bankaharetlerii);
                var personelharetlerii = db.PERSONEL_HAREKET.Where(x => x.DOSYANO == fis.FISNO && x.deleted != 1);
                db.PERSONEL_HAREKET.RemoveRange(personelharetlerii);
                var giderhareketlerii = db.GIDER_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1);
                db.GIDER_BORDRO_HAREKET.RemoveRange(giderhareketleri);
                var gelirhareketlerii = db.GELIR_BORDRO_HAREKET.Where(x => x.FISNO == fis.FISNO && x.deleted != 1);
                db.GELIR_BORDRO_HAREKET.RemoveRange(gelirhareketlerii);
                db.SaveChanges();
                var jsonResult = Json("Başarılı", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
              
              
                return jsonResult;

         




        }
        [HttpPost]
        public JsonResult datagonder(carifismodel gelenveri)
        {
            changestring();
            var id = 0;

            double toplamtutar = 0;
            double tltoplam = 0;
            double toplamdovuz = 0;
            var kasafis = new KASA_FISI();
            var kasa = db.KASA.Where(x => x.KASAKODU == gelenveri.CARIKOD).FirstOrDefault();
            kasafis.KASA = db.KASA.Where(x => x.KASAKODU == gelenveri.CARIKOD).FirstOrDefault();
            kasafis.KASAKODU = kasafis.KASA.KASAKODU;
            kasafis.CreateDate = DateTime.Now;
            kasafis.TIP = (int)gelenveri.TIPI;
            kasafis.CreateUserID = userid;
            kasafis.FISNO = gelenveri.FISNO.ToString();
            kasafis.ACIKLAMA = gelenveri.NOT;

            kasafis.S_MERKEZIID = db.SORUMLULUK_MERKEZI.Where(x => x.ACIKLAMA == gelenveri.SORUMLULUK_MERKEZI).FirstOrDefault().ID;
            kasafis.TARIH = DateTime.Parse(gelenveri.TARIH);



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
                        toplamtutar += double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                        tltoplam += double.Parse(item.NETTUTAR.Replace(",", "").Replace(".", ","));

                        toplamdovuz += double.Parse(item.TUTAR.Replace(",", "").Replace(".", ","));
                    }

                    kasafis.TOPLAMTUTAR = toplamtutar;
                    var list = db.KASA_FISI.SingleOrDefault(x => x.FISNO == kasafis.FISNO);
                    if (list == null)
                    {
                        db.KASA_FISI.Add(kasafis);
                        db.SaveChanges();
                        id = kasafis.ID;






                    }
                    else
                    {
                    
                        list.KASAKODU = kasafis.KASAKODU;
                        list.UpdateDate = DateTime.Now;
                        list.UpdateUserID = 1;
                        list.S_MERKEZIID = kasafis.S_MERKEZIID;
                        list.TARIH = kasafis.TARIH;
                        list.ACIKLAMA = kasafis.ACIKLAMA;
                        list.TOPLAMTUTAR = kasafis.TOPLAMTUTAR;
                        db.SaveChanges();
                        id = list.ID;
                        fisyenile(id);


                    }

                    foreach (var item in gelenveri.gelenhareket)
                    {


                        var kasahareket = new KASA_HAREKET();
                        kasahareket.KASA = kasa;
                        kasahareket.KASAKODU = kasahareket.KASA.KASAKODU;

                        kasahareket.ILGILI = item.ILGILI;


                        kasahareket.CreateDate = DateTime.Now;
                        kasahareket.CreateUserID = userid;
                        kasahareket.ISLEMNO = gelenveri.FISNO;
                        kasahareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);
                       
                            kasahareket.ISLEMTURU = KASA_HAREKET.kasaislemtürü.KasaFişi;
                      
                     
                        if (DateTime.Now.CompareTo(kasahareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                        {
                            var eskihareket = new KASA_HAREKET();
                            if (db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).Count() > 0)
                            {
                                eskihareket = db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) < 0 && x.KASAKODU == kasa.KASAKODU).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                            }
                            else { eskihareket.BAKIYE = 0; }
                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {

                                kasahareket.BORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                kasa.TOPLAMBORC += kasahareket.BORC;
                                kasahareket.BAKIYE = eskihareket.BAKIYE + kasahareket.BORC;
                                foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU))
                                {
                                    hareketz.BAKIYE += kasahareket.BORC;

                                }
                            }
                            else
                            {


                                kasahareket.ALACAK = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                                kasa.TOPLAMALACAK += kasahareket.ALACAK;
                                kasahareket.BAKIYE = eskihareket.BAKIYE - kasahareket.ALACAK;

                                foreach (var hareketz in db.KASA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(kasahareket.TARIHSAAT) > 0 && x.KASAKODU == kasa.KASAKODU))
                                {
                                    hareketz.BAKIYE -= kasahareket.ALACAK;

                                }
                            }
                        }
                        else
                        {
                            if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                            {

                                kasahareket.BORC = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                                kasa.TOPLAMBORC += kasahareket.BORC;
                                kasahareket.BAKIYE = kasa.BAKIYE;

                            }
                            else
                            {


                                kasahareket.ALACAK = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));

                                kasa.TOPLAMALACAK += kasahareket.ALACAK;
                                kasahareket.BAKIYE = kasa.BAKIYE;


                            }

                        }
                        kasahareket.TIPI = gelenveri.TIPI;

                        kasahareket.S_MERKEZIID = (int)kasafis.S_MERKEZIID;

                        kasahareket.ACIKLAMA = item.ACIKLAMA;


                        db.KASA_HAREKET.Add(kasahareket);




                    }
                    foreach (var item in gelenveri.gelenhareket)
                    {
                        var fishareket = new KASA_FISI_HAREKET();
                        fishareket.HAREKET = item.HAREKET.ToString();
                        fishareket.KASA_FISI = db.KASA_FISI.Find(id);
                        fishareket.ACIKLAMA = item.ACIKLAMA;
                        fishareket.ILGILI = item.ILGILI;
                        fishareket.NETTUTAR = item.NETTUTAR;

                        fishareket.ILGILIAD = item.ILGILIADI;
                        fishareket.TUTAR = item.TUTAR;
                        fishareket.PARABIRIMI = item.PARABIRIMI;
                        fishareket.PARAKURU = item.PARAKURU;
                        db.KASA_FISI_HAREKET.Add(fishareket);
                        db.SaveChanges();
                        if (item.HAREKET == KASA_HAREKET.kasahareket.Banka)
                        {
                            double tutar = 0;
                            tutar = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                            var banka = db.BANKA.Where(x => x.BANKAKODU == item.ILGILI).FirstOrDefault();
                            var hareket = new BANKA_HAREKET();
                            hareket.BANKA = db.BANKA.Where(x => x.BANKAKODU == item.ILGILI).FirstOrDefault();
                            hareket.BANKAKODU = hareket.BANKA.BANKAKODU;
                            hareket.CreateDate = DateTime.Now;
                            hareket.ISLEMTURU = CARI_HAREKET.tür.KasaFişi;
                            hareket.ISLEMNO = "";

                            hareket.CreateUserID = userid;
                            hareket.DOSYANO = gelenveri.FISNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);

                            hareket.S_MERKEZIID = (int)kasafis.S_MERKEZIID;
                            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new BANKA_HAREKET();
                                if (db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU).Count() > 0)
                                {
                                    eskihareket = db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(eskihareket.TARIHSAAT) < 0 && x.BANKAKODU == banka.BANKAKODU).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }

                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;

                                    hareket.ALACAK = tutar;
                                    banka.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = eskihareket.BAKIYE - hareket.ALACAK;
                                    foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU))
                                    {
                                        hareketz.BAKIYE -= hareket.ALACAK;

                                    }
                                }
                                else
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.BORC = tutar;
                                    banka.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = eskihareket.BAKIYE + hareket.BORC;
                                    foreach (var hareketz in db.BANKA_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.BANKAKODU == banka.BANKAKODU))
                                    {
                                        hareketz.BAKIYE += hareket.BORC;

                                    }

                                }
                            }
                            else
                            {
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {

                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    hareket.ALACAK = tutar;
                                    banka.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = banka.BAKIYE;

                                }
                                else
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.BORC = tutar;
                                    banka.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = banka.BAKIYE;


                                }
                            }


                            hareket.ACIKLAMA = gelenveri.NOT;


                            db.BANKA_HAREKET.Add(hareket);
                        }
                        if (item.HAREKET == KASA_HAREKET.kasahareket.Personel)
                        {
                            double tutar = 0;
                            tutar = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                            var personel = db.PERSONEL.Where(x => x.PERSONELKODU == item.ILGILI).FirstOrDefault();
                            var hareket = new PERSONEL_HAREKET();
                            hareket.PERSONEL = db.PERSONEL.Where(x => x.PERSONELKODU == item.ILGILI).FirstOrDefault();
                            hareket.PERSONELKODU = hareket.PERSONEL.PERSONELKODU;
                            hareket.CreateDate = DateTime.Now;
                            hareket.TURU = PERSONEL_HAREKET.personeltür.KasaFişi;


                            hareket.CreateUserID = userid;
                            hareket.DOSYANO = gelenveri.FISNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);

                            hareket.S_MERKEZIID = (int)kasafis.S_MERKEZIID;
                            if (DateTime.Now.CompareTo(hareket.TARIHSAAT.Add(new TimeSpan(2, 0, 0))) > 0)
                            {
                                var eskihareket = new PERSONEL_HAREKET();
                                if (db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU).Count() > 0)
                                {
                                    eskihareket = db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) < 0 && x.PERSONELKODU == personel.PERSONELKODU).OrderByDescending(x => x.TARIHSAAT).FirstOrDefault();


                                }
                                else { eskihareket.BAKIYE = 0; }



                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;

                                    hareket.ALACAK = tutar;
                                    personel.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = eskihareket.BAKIYE - hareket.ALACAK;
                                    foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU))
                                    {
                                        hareketz.BAKIYE -= hareket.ALACAK;
                                    }

                                }
                                else
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.BORC = tutar;
                                    personel.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = eskihareket.BAKIYE + hareket.BORC;
                                    foreach (var hareketz in db.PERSONEL_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.PERSONELKODU == personel.PERSONELKODU))
                                    {
                                        hareketz.BAKIYE += hareket.BORC;
                                    }

                                }




                            }
                            else
                            {


                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;

                                    hareket.ALACAK = tutar;
                                    personel.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = personel.BAKIYE;

                                }
                                else
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.BORC = tutar;
                                    personel.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = personel.BAKIYE;

                                }


                            }





                            hareket.ACIKLAMA = gelenveri.NOT;


                            db.PERSONEL_HAREKET.Add(hareket);
                        }
                        if (item.HAREKET == KASA_HAREKET.kasahareket.Cari)
                        {
                            double tutar = 0;
                            double doviz = 0;

                            tutar = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                            var cari = db.CARI_BASLIK.Where(x => x.CARIKOD == item.ILGILI).FirstOrDefault();
                            if (item.PARABIRIMI == cari.PARABIRIMI)
                                doviz = double.Parse(item.TUTAR.ToString().Replace(",", "").Replace(".", ","));
                            else
                            {
                                doviz = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ",")) / db.KUR_BASLIK.Where(x => x.KURKODU == cari.PARABIRIMI).FirstOrDefault().KUR;
                            }
                            var hareket = new CARI_HAREKET();
                            hareket.cari = db.CARI_BASLIK.Where(x => x.CARIKOD == item.ILGILI).FirstOrDefault();
                            hareket.CARIKOD = hareket.cari.CARIKOD;
                            hareket.CreateDate = DateTime.Now;
                            hareket.ISLEMTURU = CARI_HAREKET.tür.KasaFişi;


                            hareket.CreateUserID = userid;
                            hareket.DOSYANO = gelenveri.FISNO;
                            hareket.ISLEMNO = gelenveri.FISNO;
                            hareket.TARIHSAAT = DateTime.Parse(gelenveri.TARIH);

                            hareket.S_MERKEZIID = (int)kasafis.S_MERKEZIID;
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


                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    hareket.BORC = tutar;
                                    hareket.DOVIZBORC = doviz;
                                    cari.TOPLAMDOVIZBORC = doviz;
                                    cari.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = eskihareket.BAKIYE + tutar;
                                    hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE + doviz;
                                    foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                                    {
                                        hareketz.BAKIYE += tutar;
                                        hareketz.DOVIZBAKIYE += doviz;
                                    }
                                }
                                else
                                {

                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.ALACAK = tutar;
                                    hareket.DOVIZALACAK = doviz;
                                    cari.TOPLAMDOVIZALACAK = doviz;
                                    cari.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = eskihareket.BAKIYE - tutar;
                                    hareket.DOVIZBAKIYE = eskihareket.DOVIZBAKIYE - doviz;
                                    foreach (var hareketz in db.CARI_HAREKET.Where(x => x.TARIHSAAT.CompareTo(hareket.TARIHSAAT) > 0 && x.CARIKOD == cari.CARIKOD))
                                    {
                                        hareketz.BAKIYE -= tutar;
                                        hareketz.DOVIZBAKIYE -= doviz;
                                    }
                                   
                                }


                            }
                            else
                            {
                                if (gelenveri.TIPI == CARI_HAREKET.tip.Giriş)
                                {
                                    hareket.TIPI = CARI_HAREKET.tip.Çıkış;
                                    hareket.BORC = tutar;
                                    hareket.DOVIZBORC = doviz;
                                    cari.TOPLAMDOVIZBORC = doviz;
                                    cari.TOPLAMBORC += hareket.BORC;
                                    hareket.BAKIYE = cari.BAKIYE;
                                    hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;
                                
                                }
                                else
                                {

                                    hareket.TIPI = CARI_HAREKET.tip.Giriş;
                                    hareket.ALACAK = tutar;
                                    hareket.DOVIZALACAK = doviz;
                                    cari.TOPLAMDOVIZALACAK = doviz;
                                    cari.TOPLAMALACAK += hareket.ALACAK;
                                    hareket.BAKIYE = cari.BAKIYE;
                                    hareket.DOVIZBAKIYE = cari.DOVIZBAKIYE;
                                }
                            }



                            
                            hareket.ACIKLAMA = gelenveri.NOT;


                            db.CARI_HAREKET.Add(hareket);



                        }
                        if (item.HAREKET == KASA_HAREKET.kasahareket.Gelir)
                        {
                            double tutar = 0;
                            tutar = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                            var gelir = db.GELIR_BASLIK.Where(x => x.GELIRKODU == item.ILGILI).FirstOrDefault();
                            var hareket = new GELIR_BORDRO_HAREKET();
                            hareket.GELIRKODU = item.ILGILI;
                            hareket.GELIR_BASLIKKID = gelir.ID;
                            hareket.CreateDate = DateTime.Now;
                            hareket.TUTARI = tutar;
                            hareket.ISLEMTURU = CARI_HAREKET.tür.KasaFişi;
                            hareket.ACIKLAMA = item.ACIKLAMA;
                            hareket.PARAKUR = double.Parse(item.PARAKURU);
                            hareket.FISNO = kasafis.FISNO;
                            hareket.CreateUserID = userid;
                            hareket.PARABIRIMI = item.PARABIRIMI;
                            hareket.S_MERKEZIID = (int)kasafis.S_MERKEZIID;
                            if (gelir.TOPLAMTUTAR == null)
                                gelir.TOPLAMTUTAR = 0;
                            gelir.TOPLAMTUTAR += hareket.TUTARI;


                            hareket.ACIKLAMA = gelenveri.NOT;


                            db.GELIR_BORDRO_HAREKET.Add(hareket);
                        }
                        if (item.HAREKET == KASA_HAREKET.kasahareket.Gider)
                        {

                            double tutar = 0;
                            tutar = double.Parse(item.NETTUTAR.ToString().Replace(",", "").Replace(".", ","));
                            var gider = db.GIDER_BASLIK.Where(x => x.GIDERKODU == item.ILGILI).FirstOrDefault();
                            var hareket = new GIDER_BORDRO_HAREKET();
                            hareket.GIDERKODU = item.ILGILI;

                            hareket.GIDER_BASLIKID = gider.ID;
                            hareket.ISLEMTURU = CARI_HAREKET.tür.KasaFişi;
                            hareket.CreateDate = DateTime.Now;
                            hareket.TUTARI = tutar;
                            hareket.ACIKLAMA = item.ACIKLAMA;
                            hareket.PARAKUR = double.Parse(item.PARAKURU);
                            hareket.FISNO = kasafis.FISNO;
                            hareket.CreateUserID = userid;
                            hareket.PARABIRIMI = item.PARABIRIMI;
                            hareket.S_MERKEZIID = (int)kasafis.S_MERKEZIID;
                            if (gider.TOPLAMTUTAR == null)
                                gider.TOPLAMTUTAR = 0;
                            gider.TOPLAMTUTAR += hareket.TUTARI;

                            hareket.ACIKLAMA = gelenveri.NOT;


                            db.GIDER_BORDRO_HAREKET.Add(hareket);
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
            
        }



   
            // GET: KASA_HAREKET
            public ActionResult Index(int? id)
        {
       
                changestring();
            var model = new yenimodel();
            if (id != null)
            {
                var kasa = db.KASA.Find(id);
      
            model.ismi = kasa.KASAADI;
            model.kodu = kasa.KASAKODU;
            model.id = kasa.ID;
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
