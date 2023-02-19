namespace Mvc.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public byte[] ProductImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
