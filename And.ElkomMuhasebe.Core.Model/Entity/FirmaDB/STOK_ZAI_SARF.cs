namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_ZAI_SARF: EntityBaseFirma
    {
        
        

        public int TIP { get; set; }  
 public int? deleted { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(10)]
        public string FISNO { get; set; }

        [StringLength(15)]
        public string OZELKOD { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? GENELTOPLAM { get; set; }

        [StringLength(2)]
        public string FISSOL { get; set; }

        public float? FISSAG { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
