namespace E_Commerce.Business.Dtos
{
    public class OrderDetailDto : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public ProductDto? Product { get; set; }
        public OrderDto? Order { get; set; }
    }
}
