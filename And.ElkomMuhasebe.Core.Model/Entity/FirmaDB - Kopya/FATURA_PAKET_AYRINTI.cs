namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FATURA_PAKET_AYRINTI: EntityBaseFirma
    {
        
        

        public float? LINEINDEX { get; set; }  
 public bool deleted { get; set; }

        [StringLength(30)]
        public string STOKKODU { get; set; }

        public int? ADET { get; set; }

        public double? FIYAT { get; set; }

        public int? BIRIM { get; set; }

        public int? DEPO { get; set; }

        public int? PARABIRIMI { get; set; }
    }
}
