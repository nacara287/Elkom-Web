namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_FIYAT: EntityBaseFirma
    {
        public int? INDEXNO { get; set; }  
 public bool deleted { get; set; }

        
        
        [StringLength(30)]
        public string STOKKODU { get; set; }

        
        
        public double X { get; set; }

        
        [Column(Order = 2)]
        public double Y { get; set; }

        
        [Column(Order = 3)]
        public double Z { get; set; }

        public double? FIYAT { get; set; }

        public double? MALIYET { get; set; }

        public virtual STOK STOK { get; set; }
    }
}
