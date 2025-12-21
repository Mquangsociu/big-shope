using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigShope.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Processing, Shipped, Delivered, Cancelled

        // Navigation property
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
