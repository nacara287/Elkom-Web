namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_DEPO_TOPLAM: EntityBaseFirma
    {
        
        
        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public bool deleted { get; set; }

        
        
        
        public int DEPONO { get; set; }

        public double? MIKTAR { get; set; }
    }
}
