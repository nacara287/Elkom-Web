namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_URETIM_RECETESI_URUN: EntityBaseFirma
    {
        
        
        

        

        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public bool deleted { get; set; }

        public double MIKTAR { get; set; }

        public int? DEPO { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? FIYAT { get; set; }

        public virtual STOK_URETIM_RECETESI STOK_URETIM_RECETESI { get; set; }
    }
}
