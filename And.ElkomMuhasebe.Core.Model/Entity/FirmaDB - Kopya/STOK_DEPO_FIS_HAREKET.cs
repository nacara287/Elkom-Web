namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_DEPO_FIS_HAREKET: EntityBaseFirma
    {
        
        

        [Required]
        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public bool deleted { get; set; }

        public int BASLANGICDEPO { get; set; }

        public int HEDEFDEPO { get; set; }

        public double? MIKTAR { get; set; }

        public float? LINEINDEX { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? FIYAT { get; set; }

        public int? BIRIM { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        public double? TUTAR { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
