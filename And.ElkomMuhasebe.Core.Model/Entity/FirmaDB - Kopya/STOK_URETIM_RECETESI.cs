namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_URETIM_RECETESI: EntityBaseFirma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STOK_URETIM_RECETESI()
        {
            STOK_URETIM_RECETESI_GIDER = new HashSet<STOK_URETIM_RECETESI_GIDER>();
            STOK_URETIM_RECETESI_STOK = new HashSet<STOK_URETIM_RECETESI_STOK>();
            STOK_URETIM_RECETESI_URUN = new HashSet<STOK_URETIM_RECETESI_URUN>();
        }

        
        
        

        [Required]
        [StringLength(10)]
        public string RECETEKODU { get; set; }  
 public bool deleted { get; set; }

        [Required]
        [StringLength(40)]
        public string RECETEADI { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(20)]
        public string OZELKOD { get; set; }

        [StringLength(120)]
        public string ACIKLAMA { get; set; }

        public int? MALIYETTURU { get; set; }

        public DateTime? SON_URETIM_TARIHI { get; set; }

        public double? URETIM_ADET { get; set; }

        public int? URETIM_TIPI { get; set; }

        public int? URETIM_GURUBU { get; set; }

        public double? SON_URETIM_MALIYET { get; set; }

        public int? KDV_EKLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOK_URETIM_RECETESI_GIDER> STOK_URETIM_RECETESI_GIDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOK_URETIM_RECETESI_STOK> STOK_URETIM_RECETESI_STOK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOK_URETIM_RECETESI_URUN> STOK_URETIM_RECETESI_URUN { get; set; }
    }
}
