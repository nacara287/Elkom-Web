namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_MAAS_TAHAKKUK_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        

        
        [Column(Order = 2)]
        
        public int ISLEMKODU { get; set; }  
 public bool deleted { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 3)]
        public double TUTARI { get; set; }

        [StringLength(10)]
        public string BIRIM { get; set; }

        public double? BIRIM_MIKTAR { get; set; }

        public double? BIRIM_UCRET { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
