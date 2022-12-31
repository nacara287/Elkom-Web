namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UYARI_NOTLARI: EntityBaseFirma
    {
        
        
        [StringLength(15)]
        public string KIM { get; set; }  
 public int? deleted { get; set; }

        
        
        public DateTime TARIH { get; set; }

        
        [Column(Order = 2)]
        [StringLength(150)]
        public string MESAJ { get; set; }

        public int? OKUNDU { get; set; }
    }
}
