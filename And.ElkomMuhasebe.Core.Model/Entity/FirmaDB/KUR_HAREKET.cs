namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KUR_HAREKET: EntityBaseFirma
    {
        
        
        public DateTime TARIH { get; set; }  
 public int? deleted { get; set; }

        
        
        
        public int KURNO { get; set; }

        public double? KUR { get; set; }
    }
}
