namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_BASLIK: EntityBaseFirma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARI_BASLIK()
        {
            CARI_FIYAT = new HashSet<CARI_FIYAT>();
        
        }



        [Required]
        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public bool deleted { get; set; }

        [Required]
        [StringLength(50)]
        public string FIRMAUNVANI { get; set; }



        [StringLength(20)]
        public string ISTEL { get; set; }

        [StringLength(20)]
        public string ISFAX { get; set; }

        [StringLength(20)]
        public string MOBIL { get; set; }


        public string VERGIDAIRESI { get; set; }

        [StringLength(15)]
        public string VERGINUMARASI { get; set; }

   

        public int? ALISMUHASEBEKOD { get; set; }

        public int? SATISMUHASEBEKOD { get; set; }

        public double? KREDI { get; set; }

        public double? RISK { get; set; }

        public int? VADEOPSIYON { get; set; }

        public int? ISKONTOORAN { get; set; }

        [StringLength(35)]
        public string MUHATAPADI { get; set; }

        [StringLength(20)]
        public string BABAADI { get; set; }

        [StringLength(20)]
        public string ANAADI { get; set; }

        [StringLength(15)]
        public string MESLEGI { get; set; }

   

        public DateTime? DOGUMTARIHI { get; set; }

        public cinsiyet CINSIYET { get; set; }
        public enum cinsiyet
        {
            Erkek,Kadın

        }

        
        public byte[] ISTIHBARAT { get; set; }

        [StringLength(10)]
        public string KOD1 { get; set; }

        [StringLength(10)]
        public string KOD2 { get; set; }

        [StringLength(10)]
        public string KOD3 { get; set; }

        [StringLength(10)]
        public string KOD4 { get; set; }

        [StringLength(20)]
        public string ISILCE { get; set; }

        [StringLength(20)]
        public string EVILCE { get; set; }

        public double? TOPLAMBORC { get; set; }

        public double? TOPLAMALACAK { get; set; }

        public double? BAKIYE { get; set; }

        [StringLength(5)]
        public string ISPOSTAKODU { get; set; }

        [StringLength(5)]
        public string EVPOSTAKODU { get; set; }

        [StringLength(80)]
        public string ADISOYADI { get; set; }

        public int? HANGIADRES { get; set; }

        [StringLength(50)]
        public string ISADRES1 { get; set; }

        [StringLength(50)]
        public string ISADRES2 { get; set; }

        [StringLength(50)]
        public string EVADRES2 { get; set; }

        [StringLength(50)]
        public string EVADRES1 { get; set; }

        [StringLength(20)]
        public string BARKODU { get; set; }

        [StringLength(20)]
        public string EVTEL { get; set; }

        [StringLength(20)]
        public string ISTEL_2 { get; set; }

        [StringLength(20)]
        public string ISIL { get; set; }

        [StringLength(20)]
        public string EVIL { get; set; }

        [StringLength(50)]
        public string E_POSTA { get; set; }

        public string PARABIRIMI { get; set; }

        public double? ALISISKONTO { get; set; }

        public double? SATISISKONTO { get; set; }

        public double? VADE_FARKI { get; set; }

        public bool AKTIF { get; set; }

        [StringLength(20)]
        public string ISTEL_3 { get; set; }

        [StringLength(20)]
        public string ISTEL_4 { get; set; }

        [StringLength(20)]
        public string ISFAX2 { get; set; }

        [StringLength(20)]
        public string EVTEL2 { get; set; }

        [StringLength(50)]
        public string WEB_SITE { get; set; }

        public int? FIYATGRUBU { get; set; }

        public DateTime? ORTVADE { get; set; }

        public DateTime? ORTVADE_ALACAK { get; set; }

        public DateTime? ORTVADE_BORC { get; set; }

        public float? ORTGUN { get; set; }

        public DateTime? BORC_ORTVADE { get; set; }

        public float? BORC_ORTGUN { get; set; }

        public double? SOZ_TUTAR { get; set; }

        public DateTime? SOZ_BAS_TAR { get; set; }

        public DateTime? SOZ_BIT_TAR { get; set; }

        [Column(TypeName = "text")]
        public string SOZLESME_DURUM { get; set; }

        [StringLength(10)]
        public string WEB_SIFRE { get; set; }

        public int? RESMI { get; set; }

        public int? SMS_DURUN { get; set; }

        [StringLength(20)]
        public string SMS_TEL { get; set; }

        public int? WEB_DURUM { get; set; }

        public double? WEB_ID { get; set; }

        public int? WEB_UPDATE { get; set; }

        public int? SON_ALIS_FIYATI_GOSTER { get; set; }

        public int? SON_SATIS_FIYATI_GOSTER { get; set; }
        public mükelleftipi? Mükelleftipi { get; set; }
        public string gibpk { get; set; }
        public string not { get; set; }
        public enum mükelleftipi
        {
            Firma,
            Sahıs

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARI_FIYAT> CARI_FIYAT { get; set; }
 
        public virtual ICollection<CARI_BORDRO> CARI_BORDROs { get; set; }
        public virtual ICollection<CARI_HAREKET> CARI_HAREKETs { get; set; }
        public virtual ICollection<CARI_STOK_GROUP_INDIRIM> CARI_STOK_GROUP_INDIRIMs { get; set; }
    }
}
