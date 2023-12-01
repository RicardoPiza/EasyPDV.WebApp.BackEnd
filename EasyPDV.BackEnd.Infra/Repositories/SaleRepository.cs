using Dapper;
using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Results;
using EasyPDV.BackEnd.Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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

        public async Task<List<ReportDocumentDTO>> GetReport(string responsible, Guid id)
        {
            var _result = new List<ReportDocumentDTO>();
            using (SqlConnection conn = new(
                _configuration.GetConnectionString("DefaultConnection")))
            {
                var _query = $@"select 
                                    SP.Name ProductName,
                                    CAST(sp.Price AS DECIMAL(7,2)) as Price,
                                    sum(SP.ProductQuantity) as QuantitySold,
                                    CAST(SP.Price * sum(SP.ProductQuantity) AS DECIMAL(7,2))  as SaleTotal,
                                    Ev.Balance as InitialValue,
                                    CAST(Ev.Balance + (SP.Price * sum(SP.ProductQuantity)) AS DECIMAL(7,2)) as TotalWithInitialValue
                                from Events EV
                                    left join Sales S on EV.Id = S.EventId
                                    left join SoldProducts SP on S.Id = SP.SaleId
                                where 
                                1 = 1
                                {(string.IsNullOrEmpty(responsible) ? string.Empty : $"and Ev.Responsible = '{responsible}'")}
                                {(id == Guid.Empty ? string.Empty : $"and EV.Id = '{id}'")}
                                and SP.Name is not null
                                group by 
                                    Sp.Name,
                                    sp.price,
                                    Ev.Balance
                                ";
                _result.AddRange(await conn.QueryAsync<ReportDocumentDTO>(_query));

            }
            return _result.ToList();
        }
    }
}
