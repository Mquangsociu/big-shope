using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wed_project.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Image { get; set; }   // ảnh category
    }
}

