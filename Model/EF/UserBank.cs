namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserBank")]
    public partial class UserBank
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string BankName { get; set; }

        [Required]
        [StringLength(30)]
        public string STK { get; set; }

        [Required]
        [StringLength(30)]
        public string Pass { get; set; }
    }
}
