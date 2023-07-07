using EasyPDV.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public class RegularSaleService : IRegularSaleService
    {
        private readonly IRegularSaleRepository _regularSaleRepository;
        public RegularSaleService(
            IRegularSaleRepository regularSaleRepository
            ) {
            _regularSaleRepository = regularSaleRepository;
        }

        public async Task<RegularSale> PostRegularSale(RegularSale regularSale)
        {
            await _regularSaleRepository.Create(regularSale);
            return regularSale;
        }
    }
}
