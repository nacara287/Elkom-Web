namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EARSIV_SERI : EntityBaseFirma
    {
        
        [StringLength(15)]
        public string SERI_NO { get; set; }  
 public int? deleted { get; set; }
    }
}
