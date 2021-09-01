namespace DOS_ORM.DOSmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Suger")]
    public partial class Suger
    {
        public Guid SugerID { get; set; }

        [StringLength(100)]
        public string nosugar { get; set; }

        [StringLength(100)]
        public string lightsugar { get; set; }

        [StringLength(100)]
        public string halfsugar { get; set; }

        [StringLength(100)]
        public string lesssugar { get; set; }

        [StringLength(100)]
        public string standard { get; set; }
    }
}
