using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using EasyPDV.BackEnd.Infra.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Infra.Repositories
{
    public class EventRepository : IEventRepository
    {
        private IConfiguration _configuration;
        private PdvDbContext _context;

        public EventRepository(
            IConfiguration configuration,
            PdvDbContext dbContext

            ) { 
            _configuration  = configuration;
            _context = dbContext;
        }

        public async Task<Event> StartEvent(Event Event)
        {
            var eventEntity = Event.AddEvent(Event);
            return _context.Events.AddAsync(eventEntity).Result.Entity;

        }
    }
}
