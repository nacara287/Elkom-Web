namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ARAC_KARTI: EntityBaseFirma
    {
       

        
        
        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public bool deleted { get; set; }

        
        
        [StringLength(10)]
        public string PLAKA { get; set; }

        public int? MODEL { get; set; }

        [StringLength(10)]
        public string ARAC_TIPI { get; set; }

        [StringLength(10)]
        public string RENK { get; set; }

        public double? TOPLAM_SERVIS { get; set; }

        public double? TOPLAM_PARCA { get; set; }

        [StringLength(150)]
        public string ACIKLAMA { get; set; }

        [StringLength(10)]
        public string KOD1 { get; set; }

        [StringLength(10)]
        public string KOD2 { get; set; }

        [StringLength(10)]
        public string KOD3 { get; set; }

        [StringLength(10)]
        public string KOD4 { get; set; }
    }
}
