using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class Sale 
    {
        public Guid Id { get; set; }
        public List<SoldProduct> SoldProducts { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; }
        public ESaleType SaleType {get; set; }
        public string ChangeFrom { get; set; }
        public string ChangeTo { get; set; }

        public SaleDTO Parse(Sale sale)
        {
            return new SaleDTO()
            {
                Id = sale.Id,
                SalePrice = sale.SalePrice,
                SaleDate = sale.SaleDate,
                PaymentMethod = sale.PaymentMethod,
                SoldProducts = sale.SoldProducts.Select(x => x.Parse(x)).ToList()


            };
        }
        public void SetSale()
        {
            if(ChangeFrom is null && ChangeTo is null)
            {
                ChangeFrom = "none";
                ChangeTo = "none";
                SaleType = ESaleType.RegularSale;
                SoldProducts.ForEach(x =>
                {
                    x.Image = BitConverter.GetBytes(1);
                });
            }
        }

    }
}
