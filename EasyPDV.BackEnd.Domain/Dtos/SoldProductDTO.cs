using EasyPDV.BackEnd.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class SoldProductDTO
    {
        public Guid SoldProductId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public virtual int productQuantity { get; set; }

        public SoldProductDTO() { }
        public Product Parse(SoldProductDTO productDTO)
        {
            return new Product()
            {
                Id = productDTO.SoldProductId,
                Price = productDTO.Price,
                Name = productDTO.Name,
                Image = productDTO.Image,
                StockQuantity = productDTO.StockQuantity,
                Status = productDTO.Status,
                Description = productDTO.Description,
            };
        }
        public byte[] ConvertIFormFileToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}