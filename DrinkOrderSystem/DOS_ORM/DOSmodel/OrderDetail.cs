namespace DOS_ORM.DOSmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        public Guid OrderDetailsID { get; set; }

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
        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        [StringLength(100)]
        public string Toppings { get; set; }

        public decimal? ToppingsUnitPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string Suger { get; set; }

        [Required]
        [StringLength(50)]
        public string Ice { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }

        public int Quantity { get; set; }

        public decimal SubtotalAmount { get; set; }

        public string OtherRequest { get; set; }

        [StringLength(50)]
        public string Established { get; set; }
    }
}
