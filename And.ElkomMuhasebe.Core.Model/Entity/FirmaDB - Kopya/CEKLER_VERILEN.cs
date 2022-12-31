namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CEKLER_VERILEN: EntityBaseFirma
    {
        
        
        [StringLength(20)]
        public string CEKNO { get; set; }  
 public bool deleted { get; set; }

        
        
        
        public int CEKDURUMU { get; set; }

        public double? TUTAR { get; set; }

        public DateTime? KESIDETARIHI { get; set; }

        public DateTime? VALOR { get; set; }

        [StringLength(17)]
        public string CEKBANKA { get; set; }

        public DateTime? ODEMETARIHI { get; set; }

        public DateTime? IADETARIHI { get; set; }

        [StringLength(17)]
        public string VERILENKISI { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public DateTime? VADE { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARA { get; set; }

        [StringLength(15)]
        public string KASA { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
