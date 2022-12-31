namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_URETIM_RECETESI_GIDER: EntityBaseFirma
    {

        public int STOK_URETIM_RECETESIID { get; set; }
        public string RECETEKODU { get; set; }

        

   
        public string GIDERKODU { get; set; }  
 public int? deleted { get; set; }

        public double? TUTAR { get; set; }

        public virtual STOK_URETIM_RECETESI STOK_URETIM_RECETESI { get; set; }
    }
}
