namespace DOS_ORM.DOSmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserOrderDetail
    {
        [Key]
        public Guid OrderID { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        public DateTime OrderTime { get; set; }

        public DateTime OrderEndTime { get; set; }

        [Required]
        [StringLength(10)]
        public string RequiredTime { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        [StringLength(50)]
        public string Suger { get; set; }

        [StringLength(50)]
        public string Ice { get; set; }

        public string OtherRequest { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }
    }
}
