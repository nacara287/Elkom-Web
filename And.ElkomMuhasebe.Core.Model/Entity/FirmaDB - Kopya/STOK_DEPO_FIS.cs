namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_DEPO_FIS: EntityBaseFirma
    {
        
        

        public DateTime TARIH { get; set; }  
 public bool deleted { get; set; }

        public int BASLANGICDEPO { get; set; }

        [StringLength(10)]
        public string FISNO { get; set; }

        [StringLength(45)]
        public string ACIKLAMA { get; set; }

        public float? FISSAG { get; set; }

        [StringLength(2)]
        public string FISSOL { get; set; }

        public int? HEDEFDEPO { get; set; }

        public int? TESLIM_ALAN { get; set; }

        public int? TESLIM_EDEN { get; set; }

        public double? TOPLAM_TUTAR { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
