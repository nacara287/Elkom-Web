namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CEKLER_VERILEN_HAREKET: EntityBaseFirma
    {

        public CEKLER_VERILEN CEK { get; set; }
        public int CEKID { get; set; }

        public string CEKNO { get; set; }  
 public int? deleted { get; set; }

        
        
        
        public CEKLER_VERILEN.verilendurumlar CEKDURUMU { get; set; }

        public DateTime? TARIH { get; set; }



        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public CEKLER_VERILEN.verilendurumlar HARAKET { get; set; }

        public string ISLEMNO { get; set; }

      
        public string DOSYANO { get; set; }
    }
}
