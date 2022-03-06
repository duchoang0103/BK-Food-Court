namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long OrderID { get; set; }

        public long VendorID { get; set; }

        public long UserID { get; set; }

        public long ProductID { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public int PaymentMethod { get; set; }

        public int PaymentStatus { get; set; }

        public int FoodStatus { get; set; }

        public bool Status { get; set; }
    }
}
