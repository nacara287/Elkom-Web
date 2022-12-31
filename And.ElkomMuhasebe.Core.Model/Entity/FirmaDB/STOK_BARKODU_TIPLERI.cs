namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_BARKODU_TIPLERI: EntityBaseFirma
    {
        
        
        public int KOD { get; set; }  
 public int? deleted { get; set; }

        [StringLength(15)]
        public string BARKODTIP { get; set; }
    }
}
