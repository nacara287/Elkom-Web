namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANKA_HAREKET: EntityBaseFirma
    {
        
        

        [Required]
        [StringLength(17)]
        public string BANKAKODU { get; set; }  
 public bool deleted { get; set; }

        public DateTime TARIHSAAT { get; set; }

        public int ISLEMKODU { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }

        public double? BORC { get; set; }

        public double? ALACAK { get; set; }

        public int? IADE { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public int? KAYITSEKLI { get; set; }

        public int? MUHASEBEDURUM { get; set; }

        public int? TIPI { get; set; }

        public int? ISLEMTURU { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
