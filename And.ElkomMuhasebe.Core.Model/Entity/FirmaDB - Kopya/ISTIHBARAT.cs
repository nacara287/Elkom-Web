namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ISTIHBARAT")]
    public partial class ISTIHBARAT: EntityBaseFirma
    {
        
        
        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public bool deleted { get; set; }

        [Column("ISTIHBARAT")]
        public byte[] ISTIHBARAT1 { get; set; }

        
        
        public DateTime TARIH { get; set; }

        
        [Column(Order = 2)]
        [StringLength(15)]
        public string KULLANICI { get; set; }
    }
}
