namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FATURA_HAREKET_IRSALIYE: EntityBaseFirma
    {
        
        public double INDEXNO { get; set; }  
 public bool deleted { get; set; }

        public double FATURA_HAREKET_INDEXNO { get; set; }

        public double IRSALIYE_HAREKET_INDEXNO { get; set; }

        public double? MIKTAR { get; set; }
    }
}
