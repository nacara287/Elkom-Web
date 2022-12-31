namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FATURA_PARAKENDE_KISAYOLLAR: EntityBaseFirma
    {
        
      
 public bool deleted { get; set; }

        [StringLength(30)]
        public string STOKKODU { get; set; }

        public int? LISTE_SIRA_NO { get; set; }
    }
}
