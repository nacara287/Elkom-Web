namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GIDER_BASLIK: EntityBaseFirma
    {
        
        [StringLength(15)]
        public string GIDERKODU { get; set; }  
 public int? deleted { get; set; }

        [StringLength(30)]
        public string GIDERAD { get; set; }

        [StringLength(200)]
        public string ACIKLAMA { get; set; }

        [StringLength(10)]
        public string OZELKOD1 { get; set; }

        [StringLength(10)]
        public string OZELKOD2 { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        public int? KDVGRUP { get; set; }
    }
}
