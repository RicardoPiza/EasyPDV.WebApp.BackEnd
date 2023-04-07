using EasyPDV.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    internal class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(
            ISaleRepository saleRepository
            ) { 
            _saleRepository= saleRepository;
        }

        public Task<Sale> PostSale(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
