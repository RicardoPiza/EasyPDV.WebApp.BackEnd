using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class SaleDTO
    {
        public Guid Id { get; set; }
        public List<SoldProductDTO> SoldProducts { get; set; } = new List<SoldProductDTO>();
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.MaxValue;
        public string PaymentMethod { get; set; }
        public ESaleType SaleType { get; set; }

        public Sale Parse(SaleDTO saleDTO)
        {
            return new Sale()
            {
                Id = saleDTO.Id,
                SalePrice = saleDTO.SalePrice,
                SaleDate = saleDTO.SaleDate,
                PaymentMethod = saleDTO.PaymentMethod,
                SoldProducts = saleDTO.SoldProducts.Select(x => x.Parse(x)).ToList()
                
            };
        }
    }
}
