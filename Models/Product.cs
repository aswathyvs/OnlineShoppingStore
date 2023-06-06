using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShoppingStore.CrossCuttingConcerns.Shared.General.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnlineShoppingStore.Infrastructure.Validation;

namespace OnlineShoppingStore.Models
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Please enter a value")]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required, MinLength(4, ErrorMessage = "Minimum length is 2")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "You must choose a category")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public string Image { get; set; } = "noimage.png";

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
