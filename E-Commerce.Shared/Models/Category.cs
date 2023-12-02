using E_Commerce.Shared.Abstract;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.Models
{
    public class Category :  BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Required, MaxLength(100)]
        public string? CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
