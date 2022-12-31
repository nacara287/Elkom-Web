namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_ILCE: EntityBaseFirma
    {
        
        
        
        public int ILKODU { get; set; }  
 public bool deleted { get; set; }

        
        
        [StringLength(20)]
        public string ILCEADI { get; set; }
    }
}
