using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace surfs_up_project.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; } // Primary key

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public int CustomerId { get; set; } // Foreign key to the Customer table

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        // Additional properties for the order can be added here (like TotalPrice, OrderStatus, etc.)
    }
}
