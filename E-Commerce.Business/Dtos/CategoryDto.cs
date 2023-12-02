namespace E_Commerce.Business.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string? CategoryName { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
    }
}
