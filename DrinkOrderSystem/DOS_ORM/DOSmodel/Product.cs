namespace DOS_ORM.DOSmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }

        public decimal UnitPrice { get; set; }

        public int? UnitsMaxOrder { get; set; }

        public float? Discount { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(100)]
        public string Picture { get; set; }
    }
}
