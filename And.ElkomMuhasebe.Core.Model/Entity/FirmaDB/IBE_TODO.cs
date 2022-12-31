namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IBE_TODO: EntityBaseFirma
    {
        
        
        public int ITEM_ID { get; set; }  
 public int? deleted { get; set; }

        [StringLength(64)]
        public string OBJECT_NAME { get; set; }

        public int? OBJECT_TYPE { get; set; }

        public int ITEM_PRIORITY { get; set; }

        public int ITEM_STATE { get; set; }

        [Required]
        [StringLength(255)]
        public string ITEM_CAPTION { get; set; }

        [Column(TypeName = "text")]
        public string ITEM_DESCRIPTION { get; set; }

        [StringLength(64)]
        public string RESPONSIBLE_PERSON { get; set; }

        public DateTime ITEM_TIMESTAMP { get; set; }

        public DateTime? ITEM_DEADLINE { get; set; }

        [StringLength(64)]
        public string ITEM_CATEGORY { get; set; }

        [Required]
        [StringLength(64)]
        public string ITEM_OWNER { get; set; }
    }
}
