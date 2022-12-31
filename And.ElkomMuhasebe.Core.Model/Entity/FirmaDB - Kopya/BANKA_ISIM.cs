namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANKA_ISIM: EntityBaseFirma
    {
        
        [StringLength(17)]
        public string BANKAADI { get; set; }  
 public bool deleted { get; set; }
    }
}
