using EasyPDV.BackEnd.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class SoldProduct
    {
        public SoldProduct(Guid id, double price, string name, int stockQuantity, string status, string description)
        {
            Id = id;
            Price = price;
            Name = name;
            StockQuantity = stockQuantity;
            Status = status;
            Description = description;
        }
        public SoldProduct() { }
        public SoldProductDTO Parse(Product productDTO)
        {
            var stream = new MemoryStream(productDTO.Image);
            return new SoldProductDTO()
            {
                Id = productDTO.Id,
                Price = productDTO.Price,
                Name = productDTO.Name,
                StockQuantity = productDTO.StockQuantity,
                Status = productDTO.Status,
                Description = productDTO.Description,
            };
        }
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
