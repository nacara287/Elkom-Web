namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FATURA_SENARYO: EntityBaseFirma
    {
        
        
        

        [Column("FATURA_SENARYO")]
        [StringLength(50)]
        public string FATURA_SENARYO1 { get; set; }  
 public bool deleted { get; set; }
    }
}
