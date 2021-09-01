namespace DOS_ORM.DOSmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Topping
    {
        [Key]
        public Guid ToppingsID { get; set; }

        [StringLength(100)]
        public string bubble { get; set; }

        [StringLength(100)]
        public string grassjelly { get; set; }

        [StringLength(100)]
        public string coffeejelly { get; set; }

        [StringLength(100)]
        public string coconutjelly { get; set; }

        [StringLength(100)]
        public string pudding { get; set; }

        [StringLength(100)]
        public string aloe { get; set; }

        [StringLength(100)]
        public string taroballs { get; set; }

        [StringLength(100)]
        public string konjacjelly { get; set; }
    }
}
