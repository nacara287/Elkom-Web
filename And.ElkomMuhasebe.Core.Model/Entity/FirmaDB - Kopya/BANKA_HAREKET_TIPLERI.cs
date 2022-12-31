namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANKA_HAREKET_TIPLERI: EntityBaseFirma
    {
        
        
        public int TIP { get; set; }  
 public bool deleted { get; set; }

        [StringLength(15)]
        public string ADI { get; set; }
    }
}
