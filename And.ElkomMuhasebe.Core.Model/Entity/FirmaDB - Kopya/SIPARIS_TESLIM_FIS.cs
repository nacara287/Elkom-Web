namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SIPARIS_TESLIM_FIS: EntityBaseFirma
    {
        
        
        

        
        
        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public bool deleted { get; set; }

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

        public DateTime? ODEME_TARIHI { get; set; }

        [StringLength(40)]
        public string TESLIM_ALAN { get; set; }

        public int? KAPALI { get; set; }

        [StringLength(15)]
        public string KASAKODU { get; set; }

        [StringLength(17)]
        public string ARACI_CARIKOD { get; set; }

        public DateTime? TESLIM_TARIHI { get; set; }

        [StringLength(5)]
        public string TESLIM_SAATI { get; set; }

        [StringLength(50)]
        public string TESLIMKISI { get; set; }

        [StringLength(50)]
        public string TESLIMADRES1 { get; set; }

        [StringLength(50)]
        public string TESLIMADRES2 { get; set; }

        [StringLength(21)]
        public string TESLIMTELEFON { get; set; }

        [StringLength(255)]
        public string TESLIMNOT { get; set; }

        public int? SEHIR { get; set; }
    }
}
