namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EVET_HAYIR: EntityBaseFirma
    {
        
        
        

        [StringLength(5)]
        public string ACIKLAMA { get; set; }  
 public int? deleted { get; set; }
    }
}
