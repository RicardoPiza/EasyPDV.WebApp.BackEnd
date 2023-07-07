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
        public IFormFile Image { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public string OrderByColumn { get; set; }
        public bool Desc { get; set; }
        public Termo Termo { get; set; }

        public ProductDTO() { } 
        public Product Parse(ProductDTO productDTO)
        {
            byte[] fileBytes = ConvertIFormFileToByteArray(productDTO.Image);
            return new Product()
            {
                Id = productDTO.Id,
                Price = productDTO.Price,
                Name = productDTO.Name,
                Image = fileBytes,
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
    public class Termo
    {
        public string DataField { get; set; }
        public string Value { get; set; }
        public string Operation { get; set; }
    }

}
