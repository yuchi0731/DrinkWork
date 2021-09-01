namespace DOS_ORM.DOSmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ice
    {
        public Guid iceID { get; set; }

        [StringLength(100)]
        public string noice { get; set; }

        [StringLength(100)]
        public string lightice { get; set; }

        [StringLength(100)]
        public string lessice { get; set; }

        [StringLength(100)]
        public string normal { get; set; }

        [StringLength(100)]
        public string extraice { get; set; }

        [StringLength(100)]
        public string roomtemperature { get; set; }

        [StringLength(100)]
        public string hot { get; set; }
    }
}
