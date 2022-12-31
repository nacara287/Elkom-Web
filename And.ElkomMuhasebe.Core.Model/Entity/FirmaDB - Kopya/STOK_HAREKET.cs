namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        

        
        [Column(Order = 2)]
        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public bool deleted { get; set; }

        
        [Column(Order = 3)]
        [StringLength(10)]
        public string BELGENO { get; set; }

        public int? ISLEMTURU { get; set; }

        
        [Column(Order = 4)]
        public double MIKTAR { get; set; }

        
        [Column(Order = 5)]
        public double FIYAT { get; set; }

        
        [Column(Order = 6)]
        
        public int TIPI { get; set; }

        
        [Column(Order = 7)]
        public DateTime TARIH { get; set; }

        [StringLength(17)]
        public string CARIKOD { get; set; }

        public int? DEPOKODU { get; set; }

        public int? BIRIM { get; set; }

        public int? BIRIMADET { get; set; }

        public double? MALIYETORT { get; set; }

        public double? MALIYETFIFO { get; set; }

        public double? MALIYETLIFO { get; set; }

        public double? TUTAR { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        public float? LIFOADET { get; set; }

        public float? FIFOADET { get; set; }

        public double? SONMALIYET { get; set; }

        public double? TL_FIYAT { get; set; }

        public double? TL_TUTAR { get; set; }

        public double? KUR_FIYAT { get; set; }

        public double? DOVIZ_TUTAR { get; set; }

        public float? STOKMIKTAR { get; set; }

        public double? EK_MALIYET { get; set; }

        public int? IADE { get; set; }

        public double? DOVIZ_MALIYETORT { get; set; }

        public double? DOVIZ_SONMALIYET { get; set; }

        public int? KAR { get; set; }

        public int? S_MERKEZI { get; set; }

        public double? ISK1 { get; set; }

        public double? ISK2 { get; set; }

        public double? Y_ORT_MALIYET { get; set; }

        public double? MALIYETFIFO_DEPO { get; set; }
    }
}
