namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SIPARIS_FIS: EntityBaseFirma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SIPARIS_FIS()
        {
            SIPARIS_FIS_HAREKET = new HashSet<SIPARIS_FIS_HAREKET>();
        }

        
        

        public int TIP { get; set; }  
 public bool deleted { get; set; }

        [Required]
        [StringLength(17)]
        public string CARIKOD { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(15)]
        public string OZELKOD { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }

        public int? DEPO { get; set; }

        public DateTime? ODEMETARIHI { get; set; }

        public int KDVDAHIL { get; set; }

        public int IADE { get; set; }

        public int MUHASEBEDURUM { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        public double? KDVMATRAHI { get; set; }

        public double? KDVTUTARI { get; set; }

        public double? GENELTOPLAM { get; set; }

        [StringLength(40)]
        public string TESLIMALAN { get; set; }

        [StringLength(150)]
        public string YAZIILE { get; set; }

        public double? MASRAFTUTARI { get; set; }

        public int? ACIKKAPALI { get; set; }

        [StringLength(2)]
        public string SIPNOSOL { get; set; }

        [StringLength(10)]
        public string SIPARISNO { get; set; }

        public double? SIPNOSAG { get; set; }

        public double? PARAKUR { get; set; }

        public double? DOVIZ_GENELTOPLAM { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? ISKTOPLAM { get; set; }

        public double? ISK1TOP { get; set; }

        public double? ISK2TOP { get; set; }

        public double? ARATOPLAM { get; set; }

        public int? DURUM { get; set; }

        [StringLength(20)]
        public string PERSONEL { get; set; }

        [StringLength(100)]
        public string TESLIMSURESI { get; set; }

        [StringLength(50)]
        public string OPSIYON { get; set; }

        [StringLength(500)]
        public string GENELACIKLAMA { get; set; }

        public int? KDV { get; set; }

        [StringLength(100)]
        public string TESLIM_YERI { get; set; }

        [StringLength(100)]
        public string NAKLIYESI { get; set; }

        public double? ISKONTO { get; set; }

        public double? MASRAF { get; set; }

        [StringLength(10)]
        public string FORM_NO { get; set; }

        [StringLength(10)]
        public string TEKLIF_NO { get; set; }

        [StringLength(10)]
        public string REVIZYON_NO { get; set; }

        public DateTime? REVIZYON_TARIH { get; set; }

        [StringLength(50)]
        public string MUHATTAP { get; set; }

        public int? S_MERKEZI { get; set; }

        public int? KABUL { get; set; }

        public double? DUZLEME_ISKONTO { get; set; }

        public int? RED_EDILDI { get; set; }

        public DateTime? RED_TARIHI { get; set; }

        [StringLength(100)]
        public string RED_ACIKLAMA { get; set; }

        public int? WEB_DURUM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SIPARIS_FIS_HAREKET> SIPARIS_FIS_HAREKET { get; set; }
    }
}
