namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SENETLER_VERILEN_HAREKET: EntityBaseFirma
    {



        public SENETLER_VERILEN SENET { get; set; }
        public int SENETID { get; set; }



        public CEKLER_VERILEN.verilendurumlar SENETDURUMU { get; set; }  
 public int? deleted { get; set; }

        public DateTime? TARIH { get; set; }

        public float? SIRA { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public CEKLER_VERILEN.verilendurumlar HARAKET { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }
    }
}
