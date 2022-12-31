namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANKA_CEKSENET_ISLEMLERI_H: EntityBaseFirma
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

        public int? S_MERKEZI { get; set; }
    }
}
