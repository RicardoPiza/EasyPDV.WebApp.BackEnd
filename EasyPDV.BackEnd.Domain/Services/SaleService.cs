using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
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
        public SaleService(
            ISaleRepository saleRepository
            ) {
            _saleRepository = saleRepository;
        }

        public async Task<Sale> PostSale(SaleDTO sale)
        {
            await _saleRepository.Create(sale.Parse(sale));
            return sale.Parse(sale);
        }
        public async Task<PrepareSaleDTO> PrepareSale(List<ProductDTO> sale)
        {
            var productsTotal = new PrepareSaleDTO();
            foreach (var soldItem in sale)
            {
                productsTotal.TotalSalePrice += soldItem.Price * soldItem.productQuantity;
            }
            return productsTotal;
        }
    }
}
