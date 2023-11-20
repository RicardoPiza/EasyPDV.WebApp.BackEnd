using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities.Notifications;
using EasyPDV.BackEnd.Domain.Entities.Notifications.Model;
using EasyPDV.BackEnd.Domain.Enums;
using EasyPDV.BackEnd.Domain.Interfaces;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class Sale
    {
        public Sale() { }
        public Sale(
            Guid id,
            List<SoldProduct> soldProducts,
            double salePrice,
            DateTime saleDate,
            string paymentMethod,
            ESaleType saleType
            )
        {
            Id = id;
            SoldProducts = soldProducts;
            SalePrice = salePrice;
            SaleDate = saleDate;
            PaymentMethod = paymentMethod;
            SaleType = saleType;
        }
        public Guid Id { get; set; }
        public List<SoldProduct> SoldProducts { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; }
        public ESaleType SaleType { get; set; }
        public string ChangeFrom { get; set; }
        public string ChangeTo { get; set; }

        public SaleDTO Parse(Sale sale)
        {
            return new SaleDTO(
                sale.Id,
                sale.SoldProducts.Select(x => x.Parse(x)).ToList(),
                sale.SalePrice,
                sale.SaleDate,
                sale.PaymentMethod,
                sale.SaleType
                );
        }
        public void SetSale()
        {
            if (ChangeFrom is null && ChangeTo is null)
            {
                ChangeFrom = "none";
                ChangeTo = "none";
                SaleType = ESaleType.RegularSale;
                SaleDate = DateTime.Now;
                SoldProducts.ForEach(x =>
                {
                    x.Image = BitConverter.GetBytes(1);
                });
            }
        }

    }
}
