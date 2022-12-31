namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_HAREKET_AYRINTI_TOPLAM: EntityBaseFirma
    {
        
        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public int? deleted { get; set; }

        public double? BORC { get; set; }

        public double? ALACAK { get; set; }

        public double? BAKIYE { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? ORT_KUR { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
