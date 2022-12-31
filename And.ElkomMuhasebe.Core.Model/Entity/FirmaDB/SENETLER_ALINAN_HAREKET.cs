namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SENETLER_ALINAN_HAREKET: EntityBaseFirma
    {
        public SENETLER_ALINAN SENET { get; set; }
        public int SENETID { get; set; }

        public string PORTFOYNO { get; set; }  
 public int? deleted { get; set; }

        
        
        
        public CEKLER_ALINAN.alinandurumlar SENETDURUMU { get; set; }

        public DateTime? TARIH { get; set; }

        public float? INDEXNO { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public CEKLER_ALINAN.alinandurumlar HARAKET { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }
    }
}
