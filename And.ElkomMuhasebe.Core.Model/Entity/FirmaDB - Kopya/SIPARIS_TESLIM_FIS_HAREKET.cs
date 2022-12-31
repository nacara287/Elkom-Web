namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SIPARIS_TESLIM_FIS_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        

        
        [Column(Order = 2)]
        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public bool deleted { get; set; }

        
        [Column(Order = 3)]
        
        public int BIRIM { get; set; }

        public double? FIYAT { get; set; }

        
        [Column(Order = 4)]
        public double MIKTAR { get; set; }

        
        [Column(Order = 5)]
        
        public int DEPONO { get; set; }

        public double? TOPLAMTUTAR { get; set; }
    }
}
