namespace E_Commerce.Business.Dtos
{
    public class OrderDto : BaseDto
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public UserDto? User { get; set; }
        public ICollection<OrderDetailDto>? OrderDetails { get; set; }
    }
}
