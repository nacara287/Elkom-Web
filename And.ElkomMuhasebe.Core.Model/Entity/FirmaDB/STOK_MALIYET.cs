namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_MALIYET: EntityBaseFirma
    {
        
        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public int? deleted { get; set; }

        public double? MALIYET { get; set; }

        public int? MEVCUT { get; set; }
    }
}
