namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANKA_BORDRO: EntityBaseFirma
    {
        
        
        

        
        
        
        public int BORDROTIPI { get; set; }  
 public int? deleted { get; set; }

        [StringLength(10)]
        public string BORDRONO { get; set; }

        
        [Column(Order = 2)]
        [StringLength(17)]
        public string BANKAKOD { get; set; }

        public DateTime? TARIH { get; set; }

        public int? AYLIKVADE { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        [StringLength(10)]
        public string OZELKOD { get; set; }

        public int? IADE { get; set; }

        public double? KALANTUTAR { get; set; }

        [StringLength(150)]
        public string YAZIILE { get; set; }

        public float? FISINDEXNO { get; set; }

        [StringLength(2)]
        public string BORNOSOL { get; set; }

        public float? BORNOSAG { get; set; }

        public int? ORT_GUN { get; set; }

        public DateTime? ORT_VADE { get; set; }
    }
}
