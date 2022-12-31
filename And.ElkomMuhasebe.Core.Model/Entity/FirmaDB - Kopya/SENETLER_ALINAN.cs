namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SENETLER_ALINAN: EntityBaseFirma
    {
        
        
        public float PORTFOYNO { get; set; }  
 public bool deleted { get; set; }

        
        
        
        public int SENETDURUMU { get; set; }

        [StringLength(40)]
        public string SENETKESIDEEDEN { get; set; }

        [StringLength(40)]
        public string SENETADRES1 { get; set; }

        [StringLength(40)]
        public string SENETADRES2 { get; set; }

        [StringLength(20)]
        public string SENETSEHIR { get; set; }

        public DateTime? SENETKESIDETARIHI { get; set; }

        [StringLength(40)]
        public string SENETVERGIDAI { get; set; }

        public double? TUTAR { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(20)]
        public string CIROKISI { get; set; }

        public DateTime? CIROTARIHI { get; set; }

        [StringLength(17)]
        public string VERILENBANKAKODU { get; set; }

        public DateTime? VERILENBANKATARIHI { get; set; }

        public DateTime? TAHSILTARIHI { get; set; }

        public DateTime? IADETARIHI { get; set; }

        [StringLength(17)]
        public string ALINANKISI { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public DateTime? VADE { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARA { get; set; }

        [StringLength(15)]
        public string KASA { get; set; }

        public int? RISKDENDUS { get; set; }

        public int? S_MERKEZI { get; set; }

        [StringLength(100)]
        public string YAZIILE { get; set; }
    }
}
