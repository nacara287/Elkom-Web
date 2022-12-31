namespace And.ElkomMuhasebe.Core.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using And.ElkomMuhasebe.Core.Model.Entity.FirmaDB;
    using System.Collections.Generic;
    using System.Xml;
    using System.Data;

    public partial class FirmaBaseDB : DbContext
    {
        public FirmaBaseDB()
           : base("name =postgrestest")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
        public FirmaBaseDB(string connection)
          : base(connection)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
        public virtual DbSet<ADISYON_ODEME_TIPLERI> ADISYON_ODEME_TIPLERI { get; set; }
        public virtual DbSet<BANKA_CEKSENET_ISLEMLERI> BANKA_CEKSENET_ISLEMLERI { get; set; }
        public virtual DbSet<BANKA_HAREKET> BANKA_HAREKET { get; set; }
        public virtual DbSet<BANKA_FIS> BANKA_FIS { get; set; }
        public virtual DbSet<BANKA_FIS_HAREKET> BANKA_FIS_HAREKET { get; set; }
        public virtual DbSet<CARI_BASLIK> CARI_BASLIK { get; set; }
        public virtual DbSet<CARI_FIYAT> CARI_FIYAT { get; set; }
        public virtual DbSet<CARI_HAREKET_ISLEMKODU> CARI_HAREKET_ISLEMKODU { get; set; }
        public virtual DbSet<CARI_HAREKET_ISLEMTURU> CARI_HAREKET_ISLEMTURU { get; set; }
        public virtual DbSet<CARI_HAREKET_TIPI> CARI_HAREKET_TIPI { get; set; }
        public virtual DbSet<CARI_FIS> CARI_FIS { get; set; }
        public virtual DbSet<CARI_FIS_HAREKET> CARI_FIS_HAREKETs { get; set; }
        public virtual DbSet<CARI_STOK_GROUP_INDIRIM> CARI_STOK_GROUP_INDIRIM { get; set; }
        public virtual DbSet<EVET_HAYIR> EVET_HAYIR { get; set; }
        public virtual DbSet<EFATURA> EFATURA { get; set; }
        public virtual DbSet<EFATURAIN> EFATURAIN { get; set; }
        public virtual DbSet<EFATURAIN_HAREKET> EFATURAIN_HAREKET { get; set; }
        public virtual DbSet<FATURA> FATURA { get; set; }
        public virtual DbSet<FATURA_HAREKET_IRSALIYE> FATURA_HAREKET_IRSALIYE { get; set; }
        public virtual DbSet<FATURA_PAKET_AYRINTI> FATURA_PAKET_AYRINTI { get; set; }
        public virtual DbSet<FATURA_PARAKENDE_AYARLAR> FATURA_PARAKENDE_AYARLAR { get; set; }
        public virtual DbSet<FATURA_PARAKENDE_KISAYOLLAR> FATURA_PARAKENDE_KISAYOLLAR { get; set; }
        public virtual DbSet<FATURA_SENARYO> FATURA_SENARYO { get; set; }
        public virtual DbSet<FATURA_SERI> FATURA_SERI { get; set; }
        public virtual DbSet<EARSIV_SERI> EARSIV_SERI { get; set; }
        public virtual DbSet<EIRS_SERI> EIRS_SERI { get; set; }
        public virtual DbSet<FATURA_TIPI> FATURA_TIPI { get; set; }
        public virtual DbSet<GIDER_BASLIK> GIDER_BASLIK { get; set; }
        public virtual DbSet<IBE_TODO> IBE_TODO { get; set; }
     
        public virtual DbSet<KASA> KASA { get; set; }
        public virtual DbSet<PERSONEL_STOK_GRUP_PIRIM> PERSONEL_STOK_GRUP_PIRIM { get; set; }
        public virtual DbSet<SIPARIS_FIS> SIPARIS_FIS { get; set; }
        public virtual DbSet<SIPARIS_FIS_HAREKET> SIPARIS_FIS_HAREKET { get; set; }
        public virtual DbSet<SMS_BASLIK> SMS_BASLIK { get; set; }
        public virtual DbSet<SMS_DURUM> SMS_DURUM { get; set; }
        public virtual DbSet<SMS_MESAJ> SMS_MESAJ { get; set; }
        public virtual DbSet<SORUMLULUK_MERKEZI> SORUMLULUK_MERKEZI { get; set; }
        public virtual DbSet<STOK> STOK { get; set; }
        public virtual DbSet<STOK_KOD1> STOK_KOD1 { get; set; }
        public virtual DbSet<STOK_KOD2> STOK_KOD2 { get; set; }
    
        public virtual DbSet<STOK_FIFO_HAREKET> STOK_FIFO_HAREKET { get; set; }
        public virtual DbSet<STOK_FIYAT> STOK_FIYAT { get; set; }
        public virtual DbSet<STOK_URETIM_GRUP> STOK_URETIM_GRUP { get; set; }
        public virtual DbSet<STOK_URETIM_RECETESI> STOK_URETIM_RECETESI { get; set; }
        public virtual DbSet<STOK_URETIM_RECETESI_GIDER> STOK_URETIM_RECETESI_GIDER { get; set; }
        public virtual DbSet<STOK_URETIM_RECETESI_STOK> STOK_URETIM_RECETESI_STOK { get; set; }
        public virtual DbSet<STOK_URETIM_RECETESI_URUN> STOK_URETIM_RECETESI_URUN { get; set; }
        public virtual DbSet<STOK_URETIM_TIPI> STOK_URETIM_TIPI { get; set; }
        public virtual DbSet<STOK_ZAI_SARF> STOK_ZAI_SARF { get; set; }
        public virtual DbSet<STOK_ZAI_SARF_HAREKET> STOK_ZAI_SARF_HAREKET { get; set; }
       
        public virtual DbSet<ARAC_KARTI> ARAC_KARTI { get; set; }
        public virtual DbSet<BANKA> BANKA { get; set; }
        public virtual DbSet<BANKA_BORDRO> BANKA_BORDRO { get; set; }
        public virtual DbSet<BANKA_BORDRO_HAREKET> BANKA_BORDRO_HAREKET { get; set; }
        public virtual DbSet<BANKA_CEKSENET_ISLEMLERI_H> BANKA_CEKSENET_ISLEMLERI_H { get; set; }
        public virtual DbSet<BANKA_HAREKET_TIPLERI> BANKA_HAREKET_TIPLERI { get; set; }
        public virtual DbSet<BANKA_ISIM> BANKA_ISIM { get; set; }
        public virtual DbSet<BANKA_VISA> BANKA_VISA { get; set; }
        public virtual DbSet<BANKA_VISA_ISLEMLERI> BANKA_VISA_ISLEMLERI { get; set; }
        public virtual DbSet<BANKA_VISA_ISLEMLERI_H> BANKA_VISA_ISLEMLERI_H { get; set; }
        public virtual DbSet<BORDRO_OZELKODLARI> BORDRO_OZELKODLARI { get; set; }
        public virtual DbSet<CARI_BORDRO> CARI_BORDRO { get; set; }
        public virtual DbSet<CARI_BORDRO_HAREKET> CARI_BORDRO_HAREKET { get; set; }
        public virtual DbSet<CARI_BORDRO_IADE> CARI_BORDRO_IADE { get; set; }
        public virtual DbSet<CARI_BORDRO_IADE_HAREKET> CARI_BORDRO_IADE_HAREKET { get; set; }
        public virtual DbSet<CARI_BORDRO_TIPLERI> CARI_BORDRO_TIPLERI { get; set; }
        public virtual DbSet<CARI_BORDRO_TOPLU> CARI_BORDRO_TOPLU { get; set; }
        public virtual DbSet<CARI_BORDRO_TOPLU_HAREKET> CARI_BORDRO_TOPLU_HAREKET { get; set; }
        public virtual DbSet<CARI_HAREKET> CARI_HAREKET { get; set; }
        public virtual DbSet<CARI_HAREKET_AYRINTI> CARI_HAREKET_AYRINTI { get; set; }
        public virtual DbSet<CARI_HAREKET_AYRINTI_TOPLAM> CARI_HAREKET_AYRINTI_TOPLAM { get; set; }
        public virtual DbSet<CARI_HAREKET_ISTIHBARAT> CARI_HAREKET_ISTIHBARAT { get; set; }
        public virtual DbSet<CARI_HAREKET_KURLU> CARI_HAREKET_KURLU { get; set; }
        public virtual DbSet<CARI_IL> CARI_IL { get; set; }
        public virtual DbSet<CARI_ILCE> CARI_ILCE { get; set; }
        public virtual DbSet<CARI_ISTIHBARAT> CARI_ISTIHBARAT { get; set; }
        public virtual DbSet<CARI_KOD1> CARI_KOD1 { get; set; }
        public virtual DbSet<CARI_KOD2> CARI_KOD2 { get; set; }
        public virtual DbSet<CARI_KOD3> CARI_KOD3 { get; set; }
        public virtual DbSet<CARI_KOD4> CARI_KOD4 { get; set; }
        public virtual DbSet<CEKLER_ALINAN> CEKLER_ALINAN { get; set; }
        public virtual DbSet<CEKLER_ALINAN_HAREKET> CEKLER_ALINAN_HAREKET { get; set; }
        public virtual DbSet<CEKLER_VERILEN> CEKLER_VERILEN { get; set; }
        public virtual DbSet<CEKLER_VERILEN_HAREKET> CEKLER_VERILEN_HAREKET { get; set; }
        public virtual DbSet<CEKSENET_HAREKET_TIPLERI> CEKSENET_HAREKET_TIPLERI { get; set; }
        public virtual DbSet<CEKSENET_ISLEMLERI> CEKSENET_ISLEMLERI { get; set; }
        public virtual DbSet<CEKSENET_ISLEMLERI_HAREKET> CEKSENET_ISLEMLERI_HAREKET { get; set; }
        public virtual DbSet<CEKSENET_ISLEMLERI_TOP_HAREKET> CEKSENET_ISLEMLERI_TOP_HAREKET { get; set; }
        public virtual DbSet<CEKSENET_ISLEMLERI_TOPLU> CEKSENET_ISLEMLERI_TOPLU { get; set; }
        public virtual DbSet<FATURA_HAREKET> FATURA_HAREKET { get; set; }
        public virtual DbSet<FATURA_MASRAF> FATURA_MASRAF { get; set; }
        public virtual DbSet<FIRMA> FIRMA { get; set; }
        public virtual DbSet<GELIR_BASLIK> GELIR_BASLIK { get; set; }
        public virtual DbSet<GELIR_BORDRO> GELIR_BORDRO { get; set; }
        public virtual DbSet<GELIR_BORDRO_HAREKET> GELIR_BORDRO_HAREKET { get; set; }
        public virtual DbSet<GIDER_BORDRO> GIDER_BORDRO { get; set; }
        public virtual DbSet<GIDER_BORDRO_HAREKET> GIDER_BORDRO_HAREKET { get; set; }
        public virtual DbSet<IRSALIYE> IRSALIYE { get; set; }
        public virtual DbSet<IRSALIYE_GOSTERIM> IRSALIYE_GOSTERIM { get; set; }
        public virtual DbSet<IRSALIYE_HAREKET> IRSALIYE_HAREKET { get; set; }
        public virtual DbSet<IRSALIYE_MASRAF> IRSALIYE_MASRAF { get; set; }
        public virtual DbSet<ISTIHBARAT> ISTIHBARAT { get; set; }
        public virtual DbSet<KASA_FISI> KASA_FISI { get; set; }
        public virtual DbSet<KASA_FISI_HAREKET> KASA_FISI_HAREKET { get; set; }
        public virtual DbSet<KASA_HAREKET> KASA_HAREKET { get; set; }
        public virtual DbSet<KDVTIPLERI> KDVTIPLERI { get; set; }
        public virtual DbSet<KUR_BASLIK> KUR_BASLIK { get; set; }
        public virtual DbSet<KUR_HAREKET> KUR_HAREKET { get; set; }
        public virtual DbSet<PERSONEL> PERSONEL { get; set; }
        public virtual DbSet<PERSONEL_FISI> PERSONEL_FISI { get; set; }
        public virtual DbSet<PERSONEL_FISI_HAREKET> PERSONEL_FISI_HAREKET { get; set; }
        public virtual DbSet<PERSONEL_HAREKET> PERSONEL_HAREKET { get; set; }
        public virtual DbSet<PERSONEL_MAAS_FISI_HAREKET> PERSONEL_MAAS_FISI_HAREKET { get; set; }
        public virtual DbSet<PERSONEL_MAAS_TAHAKKUK> PERSONEL_MAAS_TAHAKKUK { get; set; }
        public virtual DbSet<PERSONEL_MAAS_TAHAKKUK_HAREKET> PERSONEL_MAAS_TAHAKKUK_HAREKET { get; set; }
        public virtual DbSet<PERSONEL_ODEME_FISI_HAREKET> PERSONEL_ODEME_FISI_HAREKET { get; set; }
        public virtual DbSet<PERSONEL_SATIS> PERSONEL_SATIS { get; set; }
        public virtual DbSet<PERSONEL_TAHAKKUK_FISI_HAREKET> PERSONEL_TAHAKKUK_FISI_HAREKET { get; set; }
        public virtual DbSet<PERSONEL_HAREKETTIPLERI> PERSONEL_HAREKETTIPLERI { get; set; }
        public virtual DbSet<SENETLER_ALINAN> SENETLER_ALINAN { get; set; }
        public virtual DbSet<SENETLER_ALINAN_HAREKET> SENETLER_ALINAN_HAREKET { get; set; }
        public virtual DbSet<SENETLER_VERILEN> SENETLER_VERILEN { get; set; }
        public virtual DbSet<SENETLER_VERILEN_HAREKET> SENETLER_VERILEN_HAREKET { get; set; }
        public virtual DbSet<SIPARIS_TESLIM_FIS> SIPARIS_TESLIM_FIS { get; set; }
        public virtual DbSet<SIPARIS_TESLIM_FIS_HAREKET> SIPARIS_TESLIM_FIS_HAREKET { get; set; }
        public virtual DbSet<STOK_BARKODU_TIPLERI> STOK_BARKODU_TIPLERI { get; set; }
       
        public virtual DbSet<STOK_DEPO> STOK_DEPO { get; set; }
        public virtual DbSet<STOK_DEPO_TIPI_1> STOK_DEPO_TIPI_1 { get; set; }
        public virtual DbSet<STOK_DEPO_TIPI_2> STOK_DEPO_TIPI_2 { get; set; }
        public virtual DbSet<STOK_DEPO_TIPI_3> STOK_DEPO_TIPI_3 { get; set; }
        public virtual DbSet<STOK_DEPO_TOPLAM> STOK_DEPO_TOPLAM { get; set; }
        public virtual DbSet<STOK_FIS> STOK_FIS { get; set; }
        public virtual DbSet<STOK_FIS_HAREKET> STOK_FIS_HAREKET { get; set; }
        public virtual DbSet<STOK_HAREKET> STOK_HAREKET { get; set; }
        public virtual DbSet<STOK_MALIYET> STOK_MALIYET { get; set; }
        public virtual DbSet<STOK_RAF> STOK_RAF { get; set; }
        public virtual DbSet<STOK_STOKGRUBU> STOK_STOKGRUBU { get; set; }
        public virtual DbSet<STOK_URETICI_FIRMA> STOK_URETICI_FIRMA { get; set; }
        public virtual DbSet<STOK_URETIM_EMRI_FISI> STOK_URETIM_EMRI_FISI { get; set; }
        public virtual DbSet<STOK_URETIM_EMRI_FISI_HAREKET> STOK_URETIM_EMRI_FISI_HAREKET { get; set; }
        public virtual DbSet<STOK_URETIM_FISI> STOK_URETIM_FISI { get; set; }
        public virtual DbSet<STOK_URETIM_FISI_HAREKET> STOK_URETIM_FISI_HAREKET { get; set; }
        public virtual DbSet<STOK_URETIM_FISI_OZELKOD> STOK_URETIM_FISI_OZELKOD { get; set; }
        public virtual DbSet<STOK_URETIM_RECETESI_OZELKOD> STOK_URETIM_RECETESI_OZELKOD { get; set; }
        public virtual DbSet<TELEFON_DEFTERI> TELEFON_DEFTERI { get; set; }
     
        public virtual DbSet<UYARI_NOTLARI> UYARI_NOTLARI { get; set; }
        public virtual DbSet<UYARILAR> UYARILAR { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
