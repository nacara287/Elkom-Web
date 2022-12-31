namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_FISI_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        
        public int ISLEMKODU { get; set; }  
 public bool deleted { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 2)]
        public DateTime VADE { get; set; }

        
        [Column(Order = 3)]
        public double TUTARI { get; set; }

        public int? BORDROTIPI { get; set; }

        
        [Column(Order = 4)]
        

        [StringLength(15)]
        public string KASAKODU { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
