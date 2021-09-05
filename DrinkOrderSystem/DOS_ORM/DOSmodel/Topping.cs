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
        public int ToppingsID { get; set; }

        [Required]
        [StringLength(100)]
        public string ToppingsName { get; set; }

        public decimal UnitPrice { get; set; }

        [StringLength(100)]
        public string Picture { get; set; }
    }
}
