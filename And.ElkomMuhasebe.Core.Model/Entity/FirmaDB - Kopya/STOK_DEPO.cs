namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_DEPO: EntityBaseFirma
    {
        
        
        
        public int DEPONO { get; set; }  
 public bool deleted { get; set; }

        
        
        [StringLength(15)]
        public string DEPOADI { get; set; }

        public int? TIPI { get; set; }

        public int? TIPI2 { get; set; }

        public int? TIPI3 { get; set; }
    }
}
