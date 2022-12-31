namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CEKLER_ALINAN_HAREKET: EntityBaseFirma
    {
        public CEKLER_ALINAN CEK { get; set; }
        public int CEKID { get; set; }


        public string PORTFOYNO { get; set; }  
 public int? deleted { get; set; }




        public CEKLER_ALINAN.alinandurumlar CEKDURUMU { get; set; }

        public DateTime? TARIH { get; set; }

       
        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public CEKLER_ALINAN.alinandurumlar HARAKET { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }
    }
}
