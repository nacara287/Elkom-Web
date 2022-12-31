namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FIRMA")]
    public partial class FIRMA: EntityBaseFirma
    {
        
        [StringLength(99)]
        public string FIRMAADI { get; set; }  
 public bool deleted { get; set; }

        [StringLength(25)]
        public string KISAADI { get; set; }

        [StringLength(40)]
        public string ADRESI1 { get; set; }

        [StringLength(40)]
        public string ADRESI2 { get; set; }

        [StringLength(25)]
        public string SEHIR { get; set; }

        [StringLength(15)]
        public string VERGIDAIRESI { get; set; }

        [StringLength(13)]
        public string VERGINO { get; set; }

        [StringLength(20)]
        public string TEL { get; set; }

        [StringLength(20)]
        public string FAX { get; set; }

        public int? CARIYIL { get; set; }

        [StringLength(10)]
        public string CARIGRUPKODU { get; set; }

        public int? CARIKODUZUNLUK { get; set; }

        public int? STOKKODUZUNLUK { get; set; }

        public int? DOVIZLEISLEM { get; set; }

        public double? VADEFARKI { get; set; }

        public int? STOK_ACIKLAMA { get; set; }

        [StringLength(20)]
        public string TEL2 { get; set; }

        [StringLength(20)]
        public string TEL3 { get; set; }

        [StringLength(20)]
        public string FAX2 { get; set; }

        [StringLength(50)]
        public string E_MAIL { get; set; }

        [StringLength(50)]
        public string WEB_SITE { get; set; }

        [StringLength(6)]
        public string TELKOD { get; set; }

        [StringLength(6)]
        public string TELDAHILI { get; set; }

        [StringLength(5)]
        public string PBIRIMI { get; set; }

        public double? DEVREDEN_KDV { get; set; }

        public DateTime? ILKTARIH { get; set; }

        public DateTime? SONTARIH { get; set; }

        public int? KURUMKODU { get; set; }

        [StringLength(20)]
        public string WEB_SIFRE { get; set; }

        public int? STOK_LISTE_ADET { get; set; }

        public int? FIFO_OTOMATIK_CALIS { get; set; }

        public int? CIROLU_SENET_DUSUM_GUN { get; set; }

        public int? CIROLU_CEK_DUSUM_GUN { get; set; }

        public int? EKSIYE_DUSMESIN { get; set; }

        public float? ZORUNLUMIKTAR { get; set; }

        [StringLength(11)]
        public string SMS_BASLIK { get; set; }

        public int? SMS_BORC_HATIRLATMA_TIPI { get; set; }

        public int? SMS_BORC_HATIRLATMA_GUN_SAYISI { get; set; }

        public int? SMS_TAHSILAT_GONDERIM_TIPI { get; set; }

        public int? SMS_FATURA_GONDERIM_TIPI { get; set; }

        public int? SMS_CEK_SENET_GONDERIM_TIPI { get; set; }

        public int? SMS_YONETICI_BIDIRIM_TIPI { get; set; }

        public DateTime? SMS_YONETICI_BILDIRIM_1_SAAT { get; set; }

        public DateTime? SMS_YONETICI_BILDIRIM_2_SAAT { get; set; }

        [StringLength(250)]
        public string YONETICI_TEL { get; set; }

        public int? SMS_DURUM { get; set; }

        public DateTime? SMS_GONDERIM_TARIHI { get; set; }

        public DateTime? SMS_ISLEM_TARIHI { get; set; }

        public int? KREDI_ASIMINA_IZIN_VER { get; set; }
    }
}
