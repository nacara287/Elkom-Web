namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_FIS: EntityBaseFirma
    {
        
        
        

        
        
        
        public int TIP { get; set; }  
 public bool deleted { get; set; }

        
        [Column(Order = 2)]
        [StringLength(17)]
        public string CARIKOD { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(10)]
        public string FISNO { get; set; }

        [StringLength(15)]
        public string OZELKOD { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }

        public int? DEPO { get; set; }

        public float? FATURANO { get; set; }

        public int? FATURALASTIMI { get; set; }

        public double? GENELTOPLAM { get; set; }

        [StringLength(2)]
        public string FISSOL { get; set; }

        public float? FISSAG { get; set; }

        public double? TOPISKONTO { get; set; }

        public double? TOPISK1 { get; set; }

        public double? TOPISK2 { get; set; }

        public double? TOPLAMMASRAF { get; set; }

        public double? ARATOPLAM { get; set; }

        public double? CARIBAKIYE { get; set; }

        public DateTime? ODEME_TARIHI { get; set; }

        [StringLength(40)]
        public string TESLIM_ALAN { get; set; }

        public int? KAPALI { get; set; }

        [StringLength(15)]
        public string KASAKODU { get; set; }

        [StringLength(20)]
        public string PERSONEL { get; set; }

        public double? ALTMASRAF { get; set; }

        public int? IADE { get; set; }

        public double? PARAKUR { get; set; }

        public double? DOVIZ_GENELTOPLAM { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? KALANTUTAR { get; set; }

        public int? S_MERKEZI { get; set; }

        public double? DUZLEME_ISKONTO { get; set; }

        [StringLength(15)]
        public string OLUSTURAN { get; set; }
    }
}
