namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TELEFON_DEFTERI: EntityBaseFirma
    {
        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public int? deleted { get; set; }

        
        
        [StringLength(50)]
        public string FIRMAUNVANI1 { get; set; }

        [StringLength(50)]
        public string FIRMAUNVANI2 { get; set; }

        [StringLength(15)]
        public string ISTEL { get; set; }

        [StringLength(15)]
        public string ISFAX { get; set; }

        [StringLength(15)]
        public string MOBIL { get; set; }

        public int? ISIL { get; set; }

        [StringLength(35)]
        public string MUHATAPADI { get; set; }

        [StringLength(15)]
        public string MESLEGI { get; set; }

        public int? EVIL { get; set; }

        [StringLength(20)]
        public string ISILCE { get; set; }

        [StringLength(20)]
        public string EVILCE { get; set; }

        [StringLength(5)]
        public string ISPOSTAKODU { get; set; }

        [StringLength(5)]
        public string EVPOSTAKODU { get; set; }

        
        
        

        [StringLength(80)]
        public string ADISOYADI { get; set; }

        public int? HANGIADRES { get; set; }

        [StringLength(50)]
        public string ISADRES1 { get; set; }

        [StringLength(50)]
        public string ISADRES2 { get; set; }

        [StringLength(50)]
        public string EVADRES2 { get; set; }

        [StringLength(50)]
        public string EVADRES1 { get; set; }

        [StringLength(15)]
        public string EVTEL { get; set; }

        [StringLength(15)]
        public string ISTEL_2 { get; set; }

        [StringLength(20)]
        public string ISILGOS { get; set; }

        [StringLength(20)]
        public string EVILGOS { get; set; }

        [StringLength(50)]
        public string E_POSTA { get; set; }
    }
}
