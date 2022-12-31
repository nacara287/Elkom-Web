namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_BORDRO_TOPLU: EntityBaseFirma
    {
        
        
        

        
        
        
        public int BORDROTIPI { get; set; }  
 public bool deleted { get; set; }

        [StringLength(10)]
        public string BORDRONO { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        [StringLength(10)]
        public string OZELKOD { get; set; }

        public float? FISINDEXNO { get; set; }

        [StringLength(2)]
        public string BORNOSOL { get; set; }

        public float? BORNOSAG { get; set; }

        public int? ORT_GUN { get; set; }

        public DateTime? ORT_VADE { get; set; }

        public double? CEKTOPLAM { get; set; }

        public double? SENETTOPLAM { get; set; }

        public double? NAKITTOPLAM { get; set; }

        public double? DEKONTTOPLAM { get; set; }

        public double? VISATOPLAM { get; set; }

        public double? VIRMANTOPLAM { get; set; }
    }
}
