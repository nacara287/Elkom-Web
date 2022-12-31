namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SORUMLULUK_MERKEZI: EntityBaseFirma
    {
        
        
        

        [StringLength(50)]
        public string ACIKLAMA { get; set; }  
 public bool deleted { get; set; }
    }
}
