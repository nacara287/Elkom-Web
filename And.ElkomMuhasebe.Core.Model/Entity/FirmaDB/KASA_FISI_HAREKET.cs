namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KASA_FISI_HAREKET: EntityBaseFirma
    {




        public KASA_FISI KASA_FISI { get; set; }
        public int KASA_FISIID { get; set; }
        public string HAREKET { get; set; }
        public string ILGILI { get; set; }
        public string ILGILIAD { get; set; }
        public string ACIKLAMA { get; set; }

        public string TUTAR { get; set; }
        public string PARABIRIMI { get; set; }
        public string PARAKURU { get; set; }
        public string NETTUTAR { get; set; }
        public int? deleted { get; set; }
    }
}
