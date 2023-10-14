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
        public SoldProductDTO Parse(SoldProduct _product)
        {
            return new SoldProductDTO()
            {
                Id = _product.Id,
                Price = _product.Price,
                Name = _product.Name,
                StockQuantity = _product.StockQuantity,
                Status = _product.Status,
                Description = _product.Description,
                ProductQuantity = _product.ProductQuantity,
            };
        }
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int ProductQuantity {get;set;}
        public virtual byte [] Image { get; set; }
    }
}
