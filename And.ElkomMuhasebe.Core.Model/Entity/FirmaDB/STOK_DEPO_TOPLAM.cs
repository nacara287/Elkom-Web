namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_DEPO_TOPLAM: EntityBaseFirma
    {
        
        

        public STOK STOK { get; set; }
        public int STOKID { get; set; }
     

        
        
        
        public STOK_DEPO DEPOSU { get; set; }
        public int DEPOSUID { get; set; }
        public double? MIKTAR { get; set; }
    }
}
