namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KASA_FISI: EntityBaseFirma
    {
        
        
        

        
        
        
        public int FISTIPI { get; set; }  
 public bool deleted { get; set; }

        [StringLength(10)]
        public string FISNO { get; set; }

        
        [Column(Order = 2)]
        [StringLength(17)]
        public string KASAKODU { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        [StringLength(10)]
        public string OZELKOD { get; set; }

        [StringLength(150)]
        public string YAZIILE { get; set; }

        public float? FISINDEXNO { get; set; }

        [StringLength(2)]
        public string FISNOSOL { get; set; }

        
        [Column(Order = 3)]
        public float FISNOSAG { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
