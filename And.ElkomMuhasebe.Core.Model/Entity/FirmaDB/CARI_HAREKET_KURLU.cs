namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_HAREKET_KURLU: EntityBaseFirma
    {
        
        
        

        
        
        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public int? deleted { get; set; }

        
        [Column(Order = 2)]
        public DateTime TARIHSAAT { get; set; }

        
        [Column(Order = 3)]
        
        public int ISLEMKODU { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }

        public double? BORC { get; set; }

        public double? ALACAK { get; set; }

        public int? IADE { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public int? TIPI { get; set; }

        public int? ISLEMTURU { get; set; }

        public DateTime? VADE { get; set; }

        public double? BAKIYE { get; set; }

        public double? MIKTAR { get; set; }

        public double? BFIYAT { get; set; }

        public float? LINEINDEX { get; set; }

        public int? S_MERKEZI { get; set; }

        public int? RESMI { get; set; }
    }
}
