namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CEKLER_ALINAN: EntityBaseFirma
    {
        
        
        public float PORTFOYNO { get; set; }  
 public bool deleted { get; set; }

        
        
        
        public int CEKDURUMU { get; set; }

        
        [Column(Order = 2)]
        [StringLength(20)]
        public string CEKNO { get; set; }

        [StringLength(40)]
        public string CEKKESIDEEDEN { get; set; }

        [StringLength(20)]
        public string CEKKESIDEYERI { get; set; }

        public DateTime? CEKKESIDETARIHI { get; set; }

        [StringLength(40)]
        public string CEKVERGIDAI { get; set; }

        public double? TUTAR { get; set; }

        public DateTime? VALOR { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(17)]
        public string CEKBANKA { get; set; }

        public DateTime? CIROTARIHI { get; set; }

        [StringLength(17)]
        public string CIROKISI { get; set; }

        public DateTime? TAHSILTARIHI { get; set; }

        [StringLength(17)]
        public string VERILENBANKAKODU { get; set; }

        public DateTime? VERILENBANKATARIHI { get; set; }

        public DateTime? IADETARIHI { get; set; }

        [StringLength(17)]
        public string ALINANKISI { get; set; }

        public DateTime? VADE { get; set; }

        [StringLength(15)]
        public string CEKSUBE { get; set; }

        [StringLength(20)]
        public string CEKHESAPNO { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARA { get; set; }

        [StringLength(15)]
        public string KASA { get; set; }

        public int? RISKDENDUS { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
