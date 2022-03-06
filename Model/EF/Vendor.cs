namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendor")]
    public partial class Vendor
    {
        public long VendorID { get; set; }

        [StringLength(50)]
        public string VendorAccount { get; set; }

        [StringLength(50)]
        public string VendorPassword { get; set; }

        [StringLength(50)]
        public string VendorName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public int? DisplayOrder { get; set; }

        public bool Status { get; set; }
    }
}
