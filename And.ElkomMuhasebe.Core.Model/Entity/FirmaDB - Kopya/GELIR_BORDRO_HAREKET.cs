namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GELIR_BORDRO_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        

        [StringLength(15)]
        public string GELIRKODU { get; set; }  
 public bool deleted { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 2)]
        public double TUTARI { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
