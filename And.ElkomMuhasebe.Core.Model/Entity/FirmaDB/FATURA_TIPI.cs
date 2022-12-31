namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FATURA_TIPI: EntityBaseFirma
    {
        
        
        

        [Column("FATURA_TIPI")]
        [StringLength(30)]
        public string FATURA_TIPI1 { get; set; }  
 public int? deleted { get; set; }
    }
}
