using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigShope.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.Now;

        // Navigation property
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
}
