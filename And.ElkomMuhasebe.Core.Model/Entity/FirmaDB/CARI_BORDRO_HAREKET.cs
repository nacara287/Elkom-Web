namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_BORDRO_HAREKET: EntityBaseFirma
    {
        
        public CARI_BORDRO CARI_BORDRO { get; set; }  
 public int? deleted { get; set; }
        public int CARI_BORDROID { get; set; }
        public int ISLEMKODU { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 2)]
        public DateTime VADE { get; set; }

        
        [Column(Order = 3)]
        public double TUTARI { get; set; }

        [StringLength(17)]
        public string PORTFOYNO { get; set; }

        public int? BORDROTIPI { get; set; }

        public int? PARABIRIMI { get; set; }

        
        [Column(Order = 4)]
        

        public double? PARAKUR { get; set; }

        [StringLength(15)]
        public string KASAKODU { get; set; }

        public float? VISANO { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
