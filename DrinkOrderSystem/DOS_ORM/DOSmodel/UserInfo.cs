namespace DOS_ORM.DOSmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(20)]
        public string DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Contact { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string ext { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        public int JobGrade { get; set; }

        public string Description { get; set; }

        public string ResponseSuppliers { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModified { get; set; }

        [StringLength(100)]
        public string Photo { get; set; }
    }
}
