namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_STOK_GRUP_PIRIM: EntityBaseFirma
    {
        
        
        

        [Required]
        [StringLength(20)]
        public string PERSONELKODU { get; set; }  
 public bool deleted { get; set; }

        public int STOKGRUBU { get; set; }

        public double PIRIM_ORANI { get; set; }
    }
}
