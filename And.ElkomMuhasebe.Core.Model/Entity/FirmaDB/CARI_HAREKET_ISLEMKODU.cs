namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_HAREKET_ISLEMKODU: EntityBaseFirma
    {
        
        
        

        [StringLength(60)]
        public string ACIKLAMA { get; set; }  
 public int? deleted { get; set; }
    }
}
