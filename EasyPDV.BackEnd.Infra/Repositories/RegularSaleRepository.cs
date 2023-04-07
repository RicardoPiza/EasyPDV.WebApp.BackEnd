using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Infra.Context;
using Microsoft.Extensions.Configuration;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    internal class RegularSaleRepository : IRegularSaleRepository
    {
        private readonly IConfiguration _configuration;
        private readonly PdvDbContext _pdvDbContext;
        public RegularSaleRepository(
            IConfiguration configuration,
            PdvDbContext pdvDbContext
            )
        {
            _configuration = configuration;
            _pdvDbContext = pdvDbContext;
        }

        public async Task<RegularSale> Create(RegularSale sale)
        {
            
            var _sale = await _pdvDbContext.AddAsync( sale );
            _pdvDbContext.SaveChanges();
            return sale;
        }
    }
}
