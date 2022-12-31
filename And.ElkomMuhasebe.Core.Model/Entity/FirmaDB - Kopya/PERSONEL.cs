namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERSONEL")]
    public partial class PERSONEL: EntityBaseFirma
    {
        
        
        

        
        
        [StringLength(40)]
        public string AD { get; set; }  
 public bool deleted { get; set; }

        [StringLength(40)]
        public string SOYAD { get; set; }

        [StringLength(82)]
        public string ADISOYADI { get; set; }

        [StringLength(20)]
        public string PERSONELKODU { get; set; }

        [StringLength(15)]
        public string EVTEL { get; set; }

        [StringLength(15)]
        public string MOBIL { get; set; }

        [StringLength(15)]
        public string GOREVI { get; set; }

        public DateTime? DOGUMTARIHI { get; set; }

        public int? CINSIYET { get; set; }

        
        public byte[] ISTIHBARAT { get; set; }

        public double? TOPLAMBORC { get; set; }

        public double? TOPLAMALACAK { get; set; }

        public double? BAKIYE { get; set; }

        [StringLength(5)]
        public string EVPOSTAKODU { get; set; }

        [StringLength(50)]
        public string EVADRES2 { get; set; }

        [StringLength(50)]
        public string EVADRES1 { get; set; }

        public int? EVIL { get; set; }

        [StringLength(20)]
        public string EVILCE { get; set; }

        [StringLength(20)]
        public string EVILGOS { get; set; }

        [StringLength(50)]
        public string E_POSTA { get; set; }

        [StringLength(10)]
        public string KOD1 { get; set; }

        [StringLength(10)]
        public string KOD2 { get; set; }

        [StringLength(10)]
        public string KOD3 { get; set; }

        [StringLength(10)]
        public string KOD4 { get; set; }

        [StringLength(30)]
        public string SSKNO { get; set; }

        [StringLength(30)]
        public string KIMLIKNO { get; set; }

        public DateTime? IS_BAS_TARIHI { get; set; }

        public int? MAASGUNU { get; set; }

        public double? MAAS { get; set; }

        
        public byte[] RESIM { get; set; }

        public int? AKTIF { get; set; }

        public double? SATIS_KOTASI { get; set; }

        public DateTime? IS_AYRILMA_TARIHI { get; set; }
    }
}
