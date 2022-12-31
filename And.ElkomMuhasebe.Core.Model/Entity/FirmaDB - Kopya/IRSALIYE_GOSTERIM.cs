namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IRSALIYE_GOSTERIM: EntityBaseFirma
    {
        
        

        [StringLength(30)]
        public string KODU { get; set; }  
 public bool deleted { get; set; }

        [StringLength(50)]
        public string ADI { get; set; }

        [StringLength(10)]
        public string BIRIMADI { get; set; }

        public double? FIYAT { get; set; }

        public int? KDV { get; set; }

        public double? MIKTAR { get; set; }

        public double? TOPLAMFIYAT { get; set; }
    }
}
