namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_FIS_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        

        
        [Column(Order = 2)]
        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public bool deleted { get; set; }

        
        [Column(Order = 3)]
        
        public int BIRIM { get; set; }

        
        [Column(Order = 4)]
        public double MIKTAR { get; set; }

        public double? FIYAT { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        
        [Column(Order = 5)]
        
        public int DEPONO { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        public double? ISK1 { get; set; }

        public double? ISK2 { get; set; }

        public double? NETFIYAT { get; set; }

        public double? ISKTOPLAM { get; set; }

        public double? ISK1TUTAR { get; set; }

        public double? ISK2TUTAR { get; set; }

        public double? MASRAF { get; set; }

        public double? MASRAFTUTAR { get; set; }

        public double? ARATOPLAM { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }

        public float? SIP_NO { get; set; }

        public int? KAR { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
