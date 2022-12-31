namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SENETLER_VERILEN_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        
        public int SENETDURUMU { get; set; }  
 public bool deleted { get; set; }

        public DateTime? TARIH { get; set; }

        public float? SIRA { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public int? HARAKET { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }
    }
}
