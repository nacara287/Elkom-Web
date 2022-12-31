namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_URETIM_EMRI_FISI_HAREKET: EntityBaseFirma
    {
        
        
        
        

        
        
        
        public int LINEINDEXNO { get; set; }  
 public bool deleted { get; set; }

        
        [Column(Order = 2)]
        [StringLength(10)]
        public string RECETEKODU { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 3)]
        public double MIKTAR { get; set; }

        public double? URETILEN_MIKTAR { get; set; }

        public double? BEKLEYEN_MIKTAR { get; set; }

        public int? MALIYET_TIPI { get; set; }
    }
}
