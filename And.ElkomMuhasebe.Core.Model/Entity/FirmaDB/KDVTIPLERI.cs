namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KDVTIPLERI")]
    public partial class KDVTIPLERI: EntityBaseFirma
    {
        
        
        
        public int KDVORAN { get; set; }  
 public int? deleted { get; set; }

        
        
        
        public int KDVGRUP { get; set; }

        
        [Column(Order = 2)]
        [StringLength(40)]
        public string KDVACIKLAMA { get; set; }

        public int? MUHASEBEALIS { get; set; }

        public int? MUHASEBESATIS { get; set; }

        public int? MUHASEBEIADEALIS { get; set; }

        public int? MUHASEBEIADESATIS { get; set; }
    }
}
