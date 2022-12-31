namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UYARILAR")]
    public partial class UYARILAR: EntityBaseFirma
    {
        
        
        [StringLength(15)]
        public string KIM { get; set; }  
 public bool deleted { get; set; }

        
        
        public DateTime TARIH { get; set; }

        public int? OKUNDU { get; set; }

        [StringLength(150)]
        public string MESAJ { get; set; }

        
        [Column(Order = 2)]
        
        public int SAAT { get; set; }
    }
}
