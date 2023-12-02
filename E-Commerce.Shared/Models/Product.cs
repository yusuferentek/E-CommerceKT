using E_Commerce.Shared.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Shared.Models
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required, MaxLength(500)]
        public string? Description { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}
