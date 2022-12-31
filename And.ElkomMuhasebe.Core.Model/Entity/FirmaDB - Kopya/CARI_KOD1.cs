namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_KOD1: EntityBaseFirma
    {
        
        [StringLength(10)]
        public string KOD { get; set; }  
 public bool deleted { get; set; }
    }
}
