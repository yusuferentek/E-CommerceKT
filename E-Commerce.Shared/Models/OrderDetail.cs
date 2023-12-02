using E_Commerce.Shared.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Shared.Models
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }
    }
}
