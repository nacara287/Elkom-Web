namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UYARILAR")]
    public partial class UYARILAR: EntityBaseFirma
    {

        public bool okunmus { get; set; }
        public bool aktif { get; set; }
        public string isim { get; set; }
        public string url { get; set; }
    }
}
