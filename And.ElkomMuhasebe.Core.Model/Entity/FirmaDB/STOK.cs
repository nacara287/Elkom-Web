namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STOK")]
    public partial class STOK: EntityBaseFirma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STOK()
        {
            CARI_FIYAT = new HashSet<CARI_FIYAT>();
            STOK_FIYAT = new HashSet<STOK_FIYAT>();
        }

        [Required]
 
        public string STOKAD { get; set; }  
 public int? deleted { get; set; }

        
        [StringLength(30)]
        public string STOKKODU { get; set; }

        [StringLength(30)]
        public string URETISISTOKKODU { get; set; }

        public int? BARKODTIPI { get; set; }

        [StringLength(15)]
        public string BARKODNO { get; set; }

        [StringLength(250)]
        public string ACIKLAMA { get; set; }

        public int? BIRIM { get; set; }

        public int? AKTIF { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? SATISFIYATI1
        {
            get { if (KDVDAHIL == 1) { return HAMSATISFIYAT; } else { return HAMSATISFIYAT + ((HAMSATISFIYAT * KDV)/100); } }
            private set { /* needed for EF */ }


        }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? KDV_SIZ_SATISFIYATI1
        {
            get { if (KDVDAHIL == 1) { return HAMSATISFIYAT/((KDV / 100) + 1); } else { return HAMSATISFIYAT; } }
            private set { /* needed for EF */ }


        }
        public double? SATISFIYATI2 { get; set; }
        public double HAMALISFIYAT { get; set; }
      
     
        public double HAMSATISFIYAT { get; set; }
      
        public double? ESKSATISFIYAT { get; set; }

        public DateTime? FIYATDEGISIMTARIHI { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? MALIYETORT
        {
            get { return TL_ALIS_TOPLAM / MIKTAR; }
            private set { /* needed for EF */ }
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? DOVIZ_MALIYETORT
        {
            get { return DOVIZ_ALIS_TOPLAM / MIKTAR; }
            private set { /* needed for EF */ }
        }



        public double? MALIYETFIFO { get; set; }

        public double? MALIYETLIFO { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        public double? ALISFIYATI 
        {
            get { if (KDVDAHIL == 1) { return HAMALISFIYAT; } else { return HAMALISFIYAT + ((HAMALISFIYAT * KDV) / 100); } }
            private set { /* needed for EF */ }


        }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? KDV_SIZ_ALISFIYATI
        {
            get { if (KDVDAHIL == 1) { return HAMALISFIYAT / ((KDV / 100)+1); } else { return HAMALISFIYAT; } }
            private set { /* needed for EF */ }


        }

        public DateTime? SONALISTARIHI { get; set; }

        public double? SATISISKONTOSU { get; set; }

        public double? ALISISKONTOSU { get; set; }

        public double? MIKTAR { get; set; }

        public float? ZORUNLUMIKTAR { get; set; }

        public float? MINMIKTAR { get; set; }

        public float? MAXMIKTAR { get; set; }

        public double? ALISSIFARIS { get; set; }

        public double? SATISSIFARIS { get; set; }

        public float? REZERVE { get; set; }

        [StringLength(30)]
        public string ALISMUHKODU { get; set; }

        [StringLength(30)]
        public string SATISMUHKODU { get; set; }

        public int? URETICIKODU { get; set; }

        public int? STOKGURUBU { get; set; }

        [StringLength(15)]
        public string OZELKOD1 { get; set; }

        [StringLength(15)]
        public string OZELKOD2 { get; set; }

        [StringLength(15)]
        public string OZELKOD3 { get; set; }

        [StringLength(15)]
        public string OZELKOD4 { get; set; }

        public float? KDV { get; set; }
  

        public string PARABIRIMI { get; set; }


        public int? RAFNO { get; set; }
     

        public double KDVDAHIL { get; set; }
    

        public double? SATISFIYATI3 { get; set; }

        public double? TOPGIREN { get; set; }

        public double? TOPCIKAN { get; set; }

        public double? SONSATISFIYATI { get; set; }

        public int? BIRIM2 { get; set; }

        public int? BIRIM3 { get; set; }

        public double? BCARPAN2 { get; set; }

        public double? BCARPAN3 { get; set; }

        public double? DEVIRALISFIYATI { get; set; }

        public double? DEVIR_MIKTAR { get; set; }

        public int? OTVTIPI { get; set; }

        public double? OTVORAN { get; set; }

        public int? OTVBIRIM { get; set; }


        public STOK_DEPO DEPOSU { get; set; }
        public int DEPOSUID { get; set; }

        [StringLength(30)]
        public string RENK { get; set; }

        public double? TL_ALISFIYATI { get; set; }
        public double? TL_SATISFIYATI { get; set; }

        public double? EK_MALIYET { get; set; }
        public double? TL_ALIS_TOPLAM { get; set; }
              public double? DOVIZ_ALIS_TOPLAM { get; set; }

        public int? EKSIYE_DUSMESIN { get; set; }

        public int? WEB_DURUM { get; set; }

        public double? WEB_ID { get; set; }


        public string GTIPNO { get; set; }

        public string EN { get; set; }
        public string BOY { get; set; }
        public string YUKSEKLIK { get; set; }


        public string ESLEME_ISIMLERI { get; set; }

        public int? WEB_UPDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARI_FIYAT> CARI_FIYAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOK_HAREKET> STOK_HAREKETs { get; set; }
        public virtual ICollection<STOK_FIYAT> STOK_FIYAT { get; set; }
        public virtual List<STOK_FIS_HAREKET> STOK_FIS_HAREKET { get; set; }
        public virtual List<IRSALIYE_HAREKET> IRSALIYE_HAREKET { get; set; }
    }
}
