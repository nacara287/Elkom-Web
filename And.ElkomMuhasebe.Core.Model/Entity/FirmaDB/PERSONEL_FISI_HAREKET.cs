namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_FISI_HAREKET: EntityBaseFirma
    {






        public PERSONEL_FISI PERSONEL { get; set; }
        public int PERSONELID { get; set; }
        public string HAREKET { get; set; }
        public string KASA { get; set; }

        public string ACIKLAMA { get; set; }
 
        public string TUTAR { get; set; }
        public string PARABIRIMI { get; set; }
        public string PARAKURU { get; set; }
        public string NETTUTAR { get; set; }
        public int? deleted { get; set; }
    }
}
