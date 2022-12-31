namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_ZAI_SARF_HAREKET: EntityBaseFirma
    {
        
        

        

        [Required]
        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public int? deleted { get; set; }

        public int BIRIM { get; set; }

        public double MIKTAR { get; set; }

        public double? FIYAT { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        public int DEPONO { get; set; }

        [StringLength(30)]
        public string ACIKLAMA { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
