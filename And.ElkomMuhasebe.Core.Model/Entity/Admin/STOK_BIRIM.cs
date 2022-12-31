namespace And.ElkomMuhasebe.Core.Model.Entity.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_BIRIM 
    {



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string BIRIMADI { get; set; }
        public int? deleted { get; set; }



        public string BIRIMKODU { get; set; }


    }
}
