namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_ISTIHBARAT: EntityBaseFirma
    {
        
        
        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public int? deleted { get; set; }

        
        public byte[] ISTIHBARAT { get; set; }

        
        
        public DateTime TARIH { get; set; }

        
        [Column(Order = 2)]
        [StringLength(15)]
        public string KULLANICI { get; set; }
    }
}
