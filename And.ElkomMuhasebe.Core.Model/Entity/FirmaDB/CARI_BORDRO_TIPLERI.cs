namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_BORDRO_TIPLERI: EntityBaseFirma
    {
        
        
        public int TIP { get; set; }  
 public int? deleted { get; set; }

        [StringLength(8)]
        public string ADI { get; set; }
    }
}
