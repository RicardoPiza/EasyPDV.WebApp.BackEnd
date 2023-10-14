using EasyPDV.BackEnd.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class SoldProductDTO
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int ProductQuantity { get; set; }
        public virtual byte[] Image { get; set; }

        public SoldProductDTO() { }
        public SoldProduct Parse(SoldProductDTO productDTO)
        {
            return new SoldProduct()
            {
                Id = productDTO.Id,
                Price = productDTO.Price,
                Name = productDTO.Name,
                StockQuantity = productDTO.StockQuantity,
                Status = productDTO.Status,
                Description = productDTO.Description,
                ProductQuantity = productDTO.ProductQuantity,
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