namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_DEPO_TIPI_3: EntityBaseFirma
    {
        public int? TIPINO { get; set; }  
 public bool deleted { get; set; }

        
        [StringLength(15)]
        public string TIPIADI { get; set; }
    }
}
