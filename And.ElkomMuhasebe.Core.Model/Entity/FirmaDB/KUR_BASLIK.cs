namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KUR_BASLIK: EntityBaseFirma
    {
        
        
        
   

        

        public string KURADI { get; set; }  
 public int? deleted { get; set; }
        public string KURKODU { get; set; }

        public double KUR { get; set; }
        public bool Aktif { get; set; }
    }
}
