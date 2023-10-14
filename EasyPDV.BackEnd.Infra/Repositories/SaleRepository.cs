using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IConfiguration _configuration;
        private readonly PdvDbContext _pdvDbContext;
        public SaleRepository(
            IConfiguration configuration,
            PdvDbContext pdvDbContext
            )
        {
            _configuration = configuration;
            _pdvDbContext = pdvDbContext;
        }

        public async Task<Sale> Create(Sale sale)
        {
            
            var _sale = await _pdvDbContext.AddAsync(sale);
            _pdvDbContext.SaveChanges();
            _pdvDbContext.ChangeTracker.Clear();
            return sale;
        }
    }
}
