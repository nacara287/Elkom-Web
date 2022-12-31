namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_URETIM_FISI: EntityBaseFirma
    {
        
        
        
        

        
        
        
        public int FISNOSAG { get; set; }  
 public bool deleted { get; set; }

        
        [Column(Order = 2)]
        [StringLength(2)]
        public string FISNOSOL { get; set; }

        [Column(TypeName = "text")]
        public string FISNO { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(15)]
        public string OZELKOD { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        [StringLength(20)]
        public string PERSONEL { get; set; }

        public double? TOPLAM_TUTAR { get; set; }
    }
}
