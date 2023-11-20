using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Entities.Notifications;
using EasyPDV.BackEnd.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly INotificationContext _notificationContext;

        public SaleService(
            ISaleRepository saleRepository,
            INotificationContext notificationContext
            ) {
            _saleRepository = saleRepository;
            _notificationContext = notificationContext;
        }

        public async Task<Sale> PostSale(SaleDTO sale)
        {
            await _saleRepository.Create(sale.Parse(sale));
            return sale.Parse(sale);
        }
        public async Task<PrepareSaleDTO> PrepareSale(List<ProductDTO> productsToSell)
        {
            var productsTotal = new PrepareSaleDTO();
            if (productsToSell.Any())
            {
                foreach (var soldItem in productsToSell)
                {
                    productsTotal.TotalSalePrice += soldItem.Price * soldItem.ProductQuantity;
                }
                return productsTotal;
            }
            _notificationContext.AddNotification("Sales", "Nenhum produto selecionado");

            return productsTotal;
        }

        public async Task<SaleDTO> Validate(SaleDTO sale)
        {
            if (string.IsNullOrEmpty(sale.PaymentMethod))
            {
                _notificationContext.AddNotification("Pagamento", "Escolha um método de pagamento");
            }
            return sale;
        }
    }
}
