namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_SATIS: EntityBaseFirma
    {
        public float? INDEXNO { get; set; }  
 public int? deleted { get; set; }

        [StringLength(20)]
        public string PERSONELKODU { get; set; }

        
        
        [StringLength(30)]
        public string STOKKODU { get; set; }

        
        
        [StringLength(10)]
        public string BELGENO { get; set; }

        
        [Column(Order = 2)]
        

        public int? ISLEMTURU { get; set; }

        
        [Column(Order = 3)]
        public double MIKTAR { get; set; }

        
        [Column(Order = 4)]
        public double FIYAT { get; set; }

        
        [Column(Order = 5)]
        public DateTime TARIH { get; set; }

        [StringLength(17)]
        public string CARIKOD { get; set; }

        public int? DEPOKODU { get; set; }

        public int? BIRIM { get; set; }

        public int? BIRIMADET { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }
        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
    }
}
