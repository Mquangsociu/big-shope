using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigShope.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PromotionalPrice { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public int StockQuantity { get; set; } = 0;

        public bool IsNew { get; set; } = false;

        public bool IsPromotion { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Foreign key
        [Required]
        public int CategoryId { get; set; }

        // Navigation property
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
