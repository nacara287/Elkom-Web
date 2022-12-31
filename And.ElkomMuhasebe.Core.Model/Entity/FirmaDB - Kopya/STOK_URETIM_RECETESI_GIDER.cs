namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_URETIM_RECETESI_GIDER: EntityBaseFirma
    {
        
        
        

        

        [StringLength(15)]
        public string GIDERKODU { get; set; }  
 public bool deleted { get; set; }

        public double? TUTAR { get; set; }

        public virtual STOK_URETIM_RECETESI STOK_URETIM_RECETESI { get; set; }
    }
}
