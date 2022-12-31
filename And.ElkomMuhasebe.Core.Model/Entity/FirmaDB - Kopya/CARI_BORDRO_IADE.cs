namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_BORDRO_IADE: EntityBaseFirma
    {
        
        
        

        
        
        
        public int BORDROTIPI { get; set; }  
 public bool deleted { get; set; }

        [StringLength(10)]
        public string BORDRONO { get; set; }

        
        [Column(Order = 2)]
        [StringLength(17)]
        public string CARIKOD { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        [StringLength(10)]
        public string OZELKOD { get; set; }

        [StringLength(150)]
        public string YAZIILE { get; set; }

        [StringLength(2)]
        public string BORNOSOL { get; set; }

        public float? BORNOSAG { get; set; }

        public double? CEKTOPLAM { get; set; }

        public double? SENETTOPLAM { get; set; }

        public double? NAKITTOPLAM { get; set; }
    }
}
