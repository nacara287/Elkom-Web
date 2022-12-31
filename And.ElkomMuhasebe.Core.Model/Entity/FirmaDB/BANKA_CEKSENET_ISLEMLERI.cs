namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANKA_CEKSENET_ISLEMLERI: EntityBaseFirma
    {
        
        public float DOSYANO { get; set; }  
 public int? deleted { get; set; }

        [Required]
        [StringLength(17)]
        public string BANKAKOD { get; set; }

        public DateTime TARIH { get; set; }

        [StringLength(10)]
        public string OZELKOD { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? TOPLAMTUTAR { get; set; }
    }
}
