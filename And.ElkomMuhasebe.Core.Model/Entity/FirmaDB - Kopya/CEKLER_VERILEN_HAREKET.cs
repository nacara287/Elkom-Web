namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CEKLER_VERILEN_HAREKET: EntityBaseFirma
    {
        
        
        [StringLength(20)]
        public string CEKNO { get; set; }  
 public bool deleted { get; set; }

        
        
        
        public int CEKDURUMU { get; set; }

        public DateTime? TARIH { get; set; }

        public float? INDEXNO { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public int? HARAKET { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }
    }
}
