using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using And.ElkomMuhasebe.Core.Model.Entity.Admin;
using And.ElkomMuhasebe.Core.Model.Entity.FirmaDB;
//using Excel = Microsoft.Office.Interop.Excel;
namespace And.ElkomMuhasebe.Core.Model.Migrations
{
    public sealed class ConfigurationFirma : DbMigrationsConfiguration<And.ElkomMuhasebe.Core.Model.FirmaBaseDB>
    {
   
        public ConfigurationFirma()
        {

            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            //SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.EntityFramework.MySqlMigrationSqlGenerator());
        }

        public void ManualSeed(FirmaBaseDB context,string connection)
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
           // SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.EntityFramework.MySqlMigrationSqlGenerator());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FirmaBaseDB, ConfigurationFirma>());
            Seed(context);
            var configuration = new ConfigurationFirma();
            configuration.TargetDatabase = new DbConnectionInfo(
                connection,
                "Npgsql");

            var migrator = new DbMigrator(configuration);

            migrator.Update();





            context.SaveChanges();
        }


        protected override void Seed(And.ElkomMuhasebe.Core.Model.FirmaBaseDB context)
        {
         


            if (context.FIRMA.Where(x=>x.ID>0).ToList().Count==0) {

         
                var PERSONEL_HAREKETTIPLERIS = new List<PERSONEL_HAREKETTIPLERI>();

                PERSONEL_HAREKETTIPLERIS.Add(new PERSONEL_HAREKETTIPLERI() { HAREKETADI = "﻿Prim", CreateDate = DateTime.Now, CreateUserID = 0 });
                PERSONEL_HAREKETTIPLERIS.Add(new PERSONEL_HAREKETTIPLERI() { HAREKETADI = "﻿Avans", CreateDate = DateTime.Now, CreateUserID = 0 });
                PERSONEL_HAREKETTIPLERIS.Add(new PERSONEL_HAREKETTIPLERI() { HAREKETADI = "﻿İkramiye", CreateDate = DateTime.Now, CreateUserID = 0 });
                context.PERSONEL_HAREKETTIPLERI.AddRange(PERSONEL_HAREKETTIPLERIS);
                var sorumluluk = new SORUMLULUK_MERKEZI();
            sorumluluk.CreateDate = DateTime.Now;
            sorumluluk.CreateUserID = 0;
            sorumluluk.ACIKLAMA = "MERKEZ";
            context.SORUMLULUK_MERKEZI.Add(sorumluluk);
            List<KASA> kasa = new List<KASA>();
            kasa.Add(new KASA() { KASAADI = "Nakit Merkez Kasa", TIPI = KASA.kasatipi.Nakit, PBIRIMI = "TL", TUR = KASA.türü.Giriş, KASAKODU = "KASA1", CreateDate = DateTime.Now, CreateUserID = 0 ,TOPLAMALACAK=0,TOPLAMBORC=0});
            kasa.Add(new KASA() { KASAADI = "Alınan Çekler(Müşterilerden)", TIPI = KASA.kasatipi.Çek, TUR = KASA.türü.Giriş, PBIRIMI = "TL", KASAKODU = "KASA2" , CreateDate = DateTime.Now, CreateUserID = 0, TOPLAMALACAK = 0, TOPLAMBORC = 0});
            kasa.Add(new KASA() { KASAADI = "Verilen Çekler(Firmanızın)", TIPI = KASA.kasatipi.Çek, TUR = KASA.türü.Çıkış, PBIRIMI = "TL", KASAKODU = "KASA3" , CreateDate = DateTime.Now, CreateUserID =0, TOPLAMALACAK = 0, TOPLAMBORC = 0 });
            kasa.Add(new KASA() { KASAADI = "Alınan Senetler(Müşterilerden)", TIPI = KASA.kasatipi.Senet, TUR = KASA.türü.Giriş, PBIRIMI = "TL", KASAKODU = "KASA4", CreateDate = DateTime.Now, CreateUserID = 0, TOPLAMALACAK = 0, TOPLAMBORC = 0 });
            kasa.Add(new KASA() { KASAADI = "Verilen Senetler(Firmanızın)", TIPI = KASA.kasatipi.Senet, TUR = KASA.türü.Çıkış, PBIRIMI = "TL", KASAKODU = "KASA5", CreateDate = DateTime.Now, CreateUserID = 0, TOPLAMALACAK = 0, TOPLAMBORC = 0 });
            kasa.Add(new KASA() { KASAADI = "Vize Kasa(Müşterilerin)", TIPI = KASA.kasatipi.Visa, TUR = KASA.türü.Giriş, PBIRIMI = "TL", KASAKODU = "KASA6" , CreateDate = DateTime.Now, CreateUserID = 0, TOPLAMALACAK = 0, TOPLAMBORC = 0 });
            context.KASA.AddRange(kasa);

                List<GIDER_BASLIK> gIDER_BASLIKs = new List<GIDER_BASLIK>();
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "KİRA & AİDAT & YAKIT", GIDERKODU = "GM001",  CreateDate = DateTime.Now, CreateUserID = 0});
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "SSK GİDERLERİ", GIDERKODU = "GM002", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "MALİYE & VERGİ GİDERLERİ", GIDERKODU = "GM003", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "TELFON GİDERLERİ", GIDERKODU = "GM004", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "ULAŞIM GİDERLERİ", GIDERKODU = "GM005", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "BENZİN & MAZOT & LPG GİDERLERİ", GIDERKODU = "GM006", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "BÜRO İÇİ GENEL GİDER", GIDERKODU = "GM007", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "YEMEK LOKANTA GİDERLERİ", GIDERKODU = "GM008", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "ARAÇ TAMİR & SERVİS GİDERLERİ", GIDERKODU = "GM009", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "ELKTİRK & SU GİDERLERİ", GIDERKODU = "GM010", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "KIRTASİYE GİDERLERİ", GIDERKODU = "GM011", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "MUHASEBECİ GİDERLERİ", GIDERKODU = "GM012", CreateDate = DateTime.Now, CreateUserID = 0 });
                gIDER_BASLIKs.Add(new GIDER_BASLIK() { GIDERAD = "KARGO & NAKLİYE & POSTA GİDER", GIDERKODU = "GM013", CreateDate = DateTime.Now, CreateUserID = 0 });
                context.GIDER_BASLIK.AddRange(gIDER_BASLIKs);
                XmlReader xmlFile;

            DataSet ds = new DataSet();
            xmlFile = XmlReader.Create("http://www.tcmb.gov.tr/kurlar/today.xml", new XmlReaderSettings());
            ds.ReadXml(xmlFile);
            int i = 0;

            decimal b;

                var tl = new KUR_BASLIK();
                tl.CreateDate = DateTime.Now;
                tl.CreateUserID = 0;
                tl.KUR = 1;
                tl.Aktif = true;
                tl.KURADI = "TÜRK LİRASI";
                tl.KURKODU = "TRY";
                context.KUR_BASLIK.Add(tl);

                for (i = 0; i <= ds.Tables[1].Rows.Count - 2; i++)
            {
                var kur = new KUR_BASLIK();
                kur.CreateDate = DateTime.Now;
                kur.CreateUserID = 0;
                kur.KURADI = ds.Tables[1].Rows[i].ItemArray[1].ToString();
                kur.KURKODU = ds.Tables[1].Rows[i].ItemArray[10].ToString();
                string dizi = ds.Tables[1].Rows[i].ItemArray[4].ToString();
                if (dizi.Contains("."))
                {
                    dizi = dizi.Replace(".", "");

                    b = Convert.ToDecimal(dizi);
                    kur.KUR = (decimal.ToDouble(b) / 10000);
                    kur.Aktif = true;

                    context.KUR_BASLIK.Add(kur);

                }





            }
               


                var fima = new FIRMA();
                fima.USER = 0;
            fima.CreateDate = DateTime.Now;
            fima.CreateUserID = 0;
            fima.FIRMAADI = context.Database.Connection.Database;
                fima.KISAADI = context.Database.Connection.Database;
                fima.CARIGRUPKODU = "CARİ";
            fima.CARIKODUZUNLUK = 4;

            context.FIRMA.Add(fima);
                context.STOK_DEPO.Add(new STOK_DEPO() { DEPOADI = "﻿Merkez Depo", DEPONO = 1,TIPI=0, CreateDate = DateTime.Now, CreateUserID = 0 });


                context.SaveChanges();
               
              
            }
        }
    }
}

