namespace Mvc.Models.Dtos
{
    public class GetProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductImage { get; set; }
        public string CategoryName { get; set; }
    }
}
