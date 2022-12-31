namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANKA_VISA_ISLEMLERI_H: EntityBaseFirma
    {
        public float? INDEXNO { get; set; }  
 public int? deleted { get; set; }

        public int VISAID { get; set; }
        public BANKA_VISA VISA { get; set; }

        public string  DOSYANO { get; set; }

        public int? ISLEMTIPI { get; set; }

        
        
        [StringLength(17)]
        public string PORTFOYNO { get; set; }

        public double? TUTAR { get; set; }

        public DateTime? VADE { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }

        public double? KOMISYON { get; set; }
    }
}
