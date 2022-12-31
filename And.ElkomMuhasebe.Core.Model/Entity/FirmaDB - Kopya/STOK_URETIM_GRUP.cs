namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_URETIM_GRUP: EntityBaseFirma
    {
        
        
        

        [Required]
        [StringLength(20)]
        public string GRUP { get; set; }  
 public bool deleted { get; set; }
    }
}
