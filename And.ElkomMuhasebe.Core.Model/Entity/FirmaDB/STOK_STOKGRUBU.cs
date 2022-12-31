namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_STOKGRUBU: EntityBaseFirma
    {
        
        
        
        public int STOKGRUBU { get; set; }  
 public int? deleted { get; set; }

        
        
        [StringLength(50)]
        public string GRUPADI { get; set; }
    }
}
