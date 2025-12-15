
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wed_project.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        // 👇 CHO PHÉP NULL
        public string? Image { get; set; }

        // Khóa ngoại
        public int CategoryId { get; set; }

        // 👇 BẮT BUỘC PHẢI NULLABLE
        public Category? Category { get; set; }
    }
}
