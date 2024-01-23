using Dapper;
using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Enums;
using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using EasyPDV.BackEnd.Domain.Results;
using EasyPDV.BackEnd.Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EasyPDV.BackEnd.Infra.Repositories
{
    public class EventRepository : IEventRepository
    {
        private IConfiguration _configuration;
        private PdvDbContext _context;

        public EventRepository(
            IConfiguration configuration,
            PdvDbContext dbContext

            )
        {
            _configuration = configuration;
            _context = dbContext;
        }

        public async Task<Event> StartEvent(Event Event)
        {
            var eventEntity = Event.AddEvent(Event);
            var _result = await _context.Events.AddAsync(eventEntity);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return _result.Entity;
        }

        public async Task<Event> StopEvent(Event Event)
        {
            var eventEntity = Event.StopEvent(Event);
            try
            {
                var _result = _context.Events.Update(eventEntity);
                await _context.SaveChangesAsync();
                return _result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsEventRunning(Event Event)
        {
            var _eventStatus = await _context.Events.Where(x => x.Id == Event.Id).Select(x => x.CashierStatus).FirstOrDefaultAsync();

            if (_eventStatus == ECashierStatus.Openned)
            {
                return true;
            }
            return false;
        }

        public async Task<Event> Get(string responsible)
            {
            var _event = await _context.Events.Where(x => x.CashierStatus == ECashierStatus.Openned && x.Responsible == responsible).AsNoTracking().FirstOrDefaultAsync();
            if (_event is not null)
            {
                if(await IsEventRunning(_event!) )
                return _event!;

                else
                {
                    return new Event()
                    {
                        Balance = 0,
                        CashierStatus = ECashierStatus.Closed,
                        Date = DateTime.UtcNow,
                        Duration = "00:00:00",
                        Name = "",
                        Responsible = responsible,
                        Sales = new List<Sale>()
                    };
                }

            }

            else
            {
                return new Event() {
                    Balance = 0,
                    CashierStatus = ECashierStatus.Closed,
                    Date = DateTime.UtcNow,
                    Duration = "00:00:00",
                    Name = "",
                    Responsible = responsible,
                    Sales = new List<Sale>()
                };
            }
        }
        public async Task<Event> AddSale(Event sale)
        {
            var existingEntity = await _context.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.Id);

            try
            {
                existingEntity = sale;
                existingEntity.SetSale();
                existingEntity.Sales.ForEach(x => {
                    x.SoldProducts.ForEach(y => { 
                        y.Id = Guid.Empty;
                    }); 
                });
                _context.Events.Update(existingEntity);
                await _context.SaveChangesAsync();
                return sale;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Event> GetById(Guid Id)
        {
            if (Id != Guid.Empty && !string.IsNullOrEmpty(Id.ToString()))
            {
                return await _context.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
            }
            else
            {
                return null;
            }
        }
        public async Task<EventCloseResult> GetEventResult(Guid id)
        {
            EventCloseResult _result = new();

            using (SqlConnection conn = new(
                _configuration.GetConnectionString("DefaultConnection")))
            {
                var _query = $@"select
                                    Ev.Name as EventName,
                                    Ev.Responsible,
                                    Ev.Date,
                                    isnull('R$ ' + convert(varchar(max), format(sum(S.SalePrice) ,'00.00' )), 0) as Total 
                                from Events Ev
                                    left join Sales S on S.EventId = Ev.Id
                                where Ev.Id = @Id
                                group by 
                                    EV.Name,
                                    Ev.Date,
                                    Ev.Responsible";
                _result = await conn.QueryFirstOrDefaultAsync<EventCloseResult>(_query, new
                {
                    Id = id,
                });
            }
            return _result;
        }

        public async Task<List<EventReportDTO>> GetEventReport(string responsible)
        {
            var _result = new List<EventReportDTO>();
            using (SqlConnection conn = new(
                _configuration.GetConnectionString("DefaultConnection")))
            {
                var _query = $@"select 
                                    Ev.Id,
                                    EV.Name,
                                    EV.Balance AS InitialBalance,
                                    EV.Date Created,
                                    Ev.Duration,
                                    sum(SA.SalePrice) TotalProfit
                                from Events EV 
                                left outer join Sales SA on EV.Id = SA.EventId
                                where
                                1 = 1 
                                {(string.IsNullOrEmpty(responsible) ? string.Empty : $"and EV.Responsible = '{responsible}'")}

                                group by
                                    EV.Duration,
                                    Ev.id,
                                    EV.Name,
                                    EV.Balance,
                                    EV.Date
                                ";
                _result.AddRange(await conn.QueryAsync<EventReportDTO>(_query));

            }
            return _result.ToList();
        }
        public async Task<string> SendDuration(EventDTO eventDTO)
        {
            string _result;
            using (SqlConnection conn = new(
                _configuration.GetConnectionString("DefaultConnection")))
            {
                var _query = $@"update Events set duration = '{eventDTO.Duration}'
                                where Id = '{eventDTO.Id}'
                                ";
                await conn.ExecuteScalarAsync<EventDTO>(_query);

                _result = await conn.QueryFirstOrDefaultAsync<string>($@"select Duration from Events where id = '{eventDTO.Id}'");
                

            }
            return _result;
        }
        public async Task<Event> Get(Guid eventId)
        {
            return await _context.Events
                .Include(x => x.Sales)
                .ThenInclude(x => x.SoldProducts)
                .FirstOrDefaultAsync(x => x.Id == eventId);
        }
    }
}
