namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CEKSENET_ISLEMLERI_HAREKET: EntityBaseFirma
    {
        public float? INDEXNO { get; set; }  
 public bool deleted { get; set; }

        
        
        public float DOSYANO { get; set; }

        public int? ISLEMTIPI { get; set; }

        
        
        [StringLength(17)]
        public string PORTFOYNO { get; set; }

        public double? TUTAR { get; set; }

        public DateTime? VADE { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }

        [StringLength(15)]
        public string KASAKODU { get; set; }
    }
}
