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
        public SaleDTO(
            Guid id,
            List<SoldProductDTO> soldProductDTOs,
            double salePrice,
            DateTime saleDate,
            string paymentMethod,
            ESaleType saleType
            ) {
            Id = id;
            SoldProducts = soldProductDTOs;
            SalePrice = salePrice;
            SaleDate = saleDate;
            PaymentMethod = paymentMethod;
            SaleType = saleType;
        }
        public SaleDTO() { }
        public Guid Id { get; set; }
        public List<SoldProductDTO> SoldProducts { get; set; } = new List<SoldProductDTO>();
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.MaxValue;
        public string PaymentMethod { get; set; }
        public ESaleType SaleType { get; set; }

        public Sale Parse(SaleDTO saleDTO)
        {
            return new Sale(
                saleDTO.Id,
                saleDTO.SoldProducts.Select(x => x.Parse(x)).ToList(),
                saleDTO.SalePrice,
                saleDTO.SaleDate,
                saleDTO.PaymentMethod,
                saleDTO.SaleType
                );
        }
    }
}
