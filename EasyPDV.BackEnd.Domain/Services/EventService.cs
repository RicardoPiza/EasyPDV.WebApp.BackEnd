using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using EasyPDV.BackEnd.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Services
{
    public class EventService : IEventService
    {
        private IConfiguration _configuration;
        private IEventRepository _eventrepository;

        public EventService(
            IConfiguration configuration,
            IEventRepository eventRepository
            
            ) { 
            _configuration = configuration;
            _eventrepository = eventRepository;
        }

        public async Task<EventDTO>StartEvent(EventDTO eventDTO)
        {
            var data = await _eventrepository.StartEvent(eventDTO.Parse(eventDTO));
            
            return data.Parse(data);
        }
    }
}
