using EasyPDV.BackEnd.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set;  }
        public byte[] Image { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public virtual int ProductQuantity { get; set; }
        public string OwnerUserEmail { get; set; }

        public ProductDTO() { } 
        public Product Parse(ProductDTO productDTO)
        {
            return new Product()
            {
                Id = productDTO.Id,
                Price = productDTO.Price,
                Name = productDTO.Name,
                Image = productDTO.Image,
                StockQuantity = productDTO.StockQuantity,
                Status = productDTO.Status,
                Description = productDTO.Description,
                OwnerUserEmail = productDTO.OwnerUserEmail,
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
