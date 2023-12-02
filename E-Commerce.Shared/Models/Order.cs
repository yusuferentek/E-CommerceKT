using E_Commerce.Shared.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Shared.Models
{
    //CTRL + R + G
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();    
        }

        public int UserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
