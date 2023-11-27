using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities.Notifications;
using EasyPDV.BackEnd.Domain.Interfaces;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class Product
    {
        public Product() { }
        public Product(Guid id, double price, string name, byte[] image, int stockQuantity, string status, string description, string ownerUserEmail)
        {
            Id = id;
            Price = price;
            Name = name;
            Image = image;
            StockQuantity = stockQuantity;
            Status = status;
            Description = description;
            OwnerUserEmail = ownerUserEmail;
        }
        public ProductDTO Parse(Product productDTO)
        {
            var stream = new MemoryStream(productDTO.Image);
            return new ProductDTO()
            {
                Id = productDTO.Id,
                Price = productDTO.Price,
                Name = productDTO.Name,
                Image = productDTO.Image,
                StockQuantity = productDTO.StockQuantity,
                Status = productDTO.Status,
                Description = productDTO.Description,
                OwnerUserEmail= productDTO.OwnerUserEmail
            };
        }
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string OwnerUserEmail { get; set; }
        public byte[] Image { get; set; }
    }
}
