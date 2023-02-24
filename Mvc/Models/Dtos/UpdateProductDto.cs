using Mvc.Models.Entities;

namespace Mvc.Models.Dtos
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductImage { get; set; }
        public IFormFile ProductImageFile { get; set; }
        //public string ProductImageFileName { get; set; }
        public int CategoryId { get; set; }
        public IList<Category>? Categories { get; set; }
    }
}
