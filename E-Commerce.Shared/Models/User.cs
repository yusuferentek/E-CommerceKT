using E_Commerce.Shared.Abstract;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        [Required, MaxLength(50)]
        public string? FirstName { get; set; }
        [Required, MaxLength(50)]
        public string? LastName { get; set; }
        [Required, MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [MaxLength(200)]
        public string? Address { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
