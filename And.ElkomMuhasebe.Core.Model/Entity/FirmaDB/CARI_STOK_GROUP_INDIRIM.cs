namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_STOK_GROUP_INDIRIM: EntityBaseFirma
    {
        
        
        

        [Required]
        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public int? deleted { get; set; }

        public int STOKGRUBU { get; set; }

        public double? ALIS_ORAN { get; set; }

        public double? SATIS_ORAN { get; set; }
    }
}
