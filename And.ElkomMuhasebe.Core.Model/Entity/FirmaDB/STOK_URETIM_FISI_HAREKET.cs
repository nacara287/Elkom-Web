namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_URETIM_FISI_HAREKET: EntityBaseFirma
    {

        public  virtual STOK_URETIM_FISI FIS{ get; set; }
        public int FISID { get; set; }

        public string FISNO { get; set; }
        public int? deleted { get; set; }

        
        [Column(Order = 2)]
        [StringLength(10)]
        public string RECETEKODU { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 3)]
        public double MIKTAR { get; set; }

        public double? BIRIM_FIYATI { get; set; }

        public int? MALIYET_TIPI { get; set; }

        public int? URETIM_INDEXNO { get; set; }

        public double? STOK_MALIYET { get; set; }

        public double? GIDER_MALIYET { get; set; }
    }
}
