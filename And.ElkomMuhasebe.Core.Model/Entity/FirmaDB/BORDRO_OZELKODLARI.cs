namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BORDRO_OZELKODLARI: EntityBaseFirma
    {
        
        [StringLength(10)]
        public string OZELKOD { get; set; }  
 public int? deleted { get; set; }
    }
}
