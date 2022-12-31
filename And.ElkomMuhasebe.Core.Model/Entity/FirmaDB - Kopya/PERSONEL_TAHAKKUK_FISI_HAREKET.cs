namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_TAHAKKUK_FISI_HAREKET: EntityBaseFirma
    {
        public float? INDEXNO { get; set; }  
 public bool deleted { get; set; }

        
        
        

        
        
        [StringLength(17)]
        public string PERSONELKODU { get; set; }

        
        [Column(Order = 2)]
        
        public int ISLEMKODU { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? TUTAR { get; set; }
    }
}
