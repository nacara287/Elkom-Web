namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IRSALIYE_MASRAF: EntityBaseFirma
    {
        
        
        

        
        
        

        
        [Column(Order = 2)]
        public float MASRAFKODU { get; set; }  
 public int? deleted { get; set; }

        public double? TOPLAMFIYAT { get; set; }

        public double? KDVMATRAHI { get; set; }

        public double? KDVTUTARI { get; set; }

        public int? KDV { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
