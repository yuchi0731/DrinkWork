namespace DOS_ORM.DOSmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderList")]
    public partial class OrderList
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        [StringLength(100)]
        public string OrderNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        public DateTime OrderTime { get; set; }

        public DateTime OrderEndTime { get; set; }

        public DateTime RequiredTime { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }

        public decimal TotalPrice { get; set; }

        public int TotalCups { get; set; }

        [StringLength(50)]
        public string Established { get; set; }
    }
}
