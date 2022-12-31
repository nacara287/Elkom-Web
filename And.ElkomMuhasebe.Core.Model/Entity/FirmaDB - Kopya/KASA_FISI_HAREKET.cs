namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KASA_FISI_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        
        public int ISLEMKODU { get; set; }  
 public bool deleted { get; set; }

        
        [Column(Order = 2)]
        [StringLength(40)]
        public string CARI { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 3)]
        public DateTime VADE { get; set; }

        
        public double TUTARI { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        [StringLength(50)]
        public string ILGILI { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
