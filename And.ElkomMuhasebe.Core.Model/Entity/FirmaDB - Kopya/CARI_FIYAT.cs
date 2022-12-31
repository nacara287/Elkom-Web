namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_FIYAT: EntityBaseFirma
    {
        
        
        

        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public bool deleted { get; set; }

        [StringLength(30)]
        public string STOKKOD { get; set; }

        public double? FIYAT { get; set; }

        public double? ORAN { get; set; }

        public virtual CARI_BASLIK CARI_BASLIK { get; set; }

        public virtual STOK STOK { get; set; }
    }
}
