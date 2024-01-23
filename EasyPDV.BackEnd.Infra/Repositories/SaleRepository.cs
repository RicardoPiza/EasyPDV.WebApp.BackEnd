using Dapper;
using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Results;
using EasyPDV.BackEnd.Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<List<EventReportDocumentDTO>> GetSoldProductsReport(string responsible, Guid id)
        {
            var _result = new List<EventReportDocumentDTO>();
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
                _result.AddRange(await conn.QueryAsync<EventReportDocumentDTO>(_query));

            }
            return _result.ToList();
        }
        public async Task<List<SaleReportDocumentDTO>> GetSalesReport(string responsible, Guid id)
        {
            var _result = new List<SaleReportDocumentDTO>();
            using (SqlConnection conn = new(
                _configuration.GetConnectionString("DefaultConnection")))
            {
                var _query = @$"select 
                                SP.Name ProductName,
                                cast(SP.Price AS decimal(7,2))ProductPrice,
                                S.PaymentMethod PaymentMethod,
                                CONVERT(VARCHAR, S.SaleDate, 103) SaleDate,
                                CONVERT(VARCHAR, S.SaleDate, 108) SaleTime,
                                Ev.Name EventName,
                                Ev.Responsible Responsible,
                                S.Id SaleId
                                from sales S

                                left join SoldProducts SP on S.Id = SP.SaleId
                                left join Events EV on EV.id = S.EventId

                            where
	                            1 = 1 
	                            and	Ev.CashierStatus = 0
                                {(string.IsNullOrEmpty(responsible) ? string.Empty : $"and Ev.Responsible = '{responsible}'")}
                                {(id == Guid.Empty ? string.Empty : $"and EV.Id = '{id}'")} ";

                _result.AddRange(await conn.QueryAsync<SaleReportDocumentDTO>(_query));
            }
                return _result;
        }
    }
}
