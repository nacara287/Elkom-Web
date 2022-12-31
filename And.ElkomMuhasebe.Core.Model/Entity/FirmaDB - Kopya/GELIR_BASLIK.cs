namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GELIR_BASLIK: EntityBaseFirma
    {
        
        [StringLength(15)]
        public string GELIRKODU { get; set; }  
 public bool deleted { get; set; }

        [StringLength(30)]
        public string GELIRAD { get; set; }

        [StringLength(200)]
        public string ACIKLAMA { get; set; }

        [StringLength(10)]
        public string OZELKOD1 { get; set; }

        [StringLength(10)]
        public string OZELKOD2 { get; set; }

        public int? KDVGRUP { get; set; }

        public double? TOPLAMTUTAR { get; set; }
    }
}
