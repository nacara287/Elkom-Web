namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANKA_VISA: EntityBaseFirma
    {
        public float? INDEXNO { get; set; }  
 public bool deleted { get; set; }

        
        
        [StringLength(17)]
        public string BANKAKODU { get; set; }

        
        
        public float PORTFOYNO { get; set; }

        
        [Column(Order = 2)]
        
        public int DURUMU { get; set; }

        [StringLength(40)]
        public string CARI { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public DateTime? TARIHI { get; set; }

        public DateTime? VADE { get; set; }

        public double? TUTAR { get; set; }

        public double? KOMISYON { get; set; }

        public DateTime? TAHSILTARIHI { get; set; }

        public int? PARABIRIMI { get; set; }

        [StringLength(15)]
        public string KASA { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
