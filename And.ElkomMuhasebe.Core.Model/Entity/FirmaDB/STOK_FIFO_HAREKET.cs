namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_FIFO_HAREKET: EntityBaseFirma
    {
        
        [StringLength(50)]
        public string STOKKODU { get; set; }  
 public int? deleted { get; set; }
    }
}
