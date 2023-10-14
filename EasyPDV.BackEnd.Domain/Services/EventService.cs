using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using EasyPDV.BackEnd.Domain.Interfaces.Services;
using EasyPDV.BackEnd.Domain.Results;
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
        private IEventRepository _eventRepository;

        public EventService(
            IConfiguration configuration,
            IEventRepository eventRepository
            
            ) { 
            _configuration = configuration;
            _eventRepository = eventRepository;
        }

        public async Task<EventDTO>StartEvent(EventDTO eventDTO)
        {
            var data = await _eventRepository.StartEvent(eventDTO.Parse(eventDTO));
            
            return data.Parse(data);
        }
        public async Task<EventDTO> GetEvent(string responsible)
        {
            var data = await _eventRepository.Get(responsible);

            return data.Parse(data);
        }
        public async Task<EventDTO> AddSale(EventDTO _sale)
        {
            var _result = await _eventRepository.AddSale(_sale.Parse(_sale));
            return _result.Parse(_result);
        }
        public async Task<EventDTO> StopEvent(EventDTO _event)
        {
            var _result = await _eventRepository.StopEvent(_event.Parse(_event));
            return _result.Parse( _result);

        }
        public async Task<EventCloseResult> GetEventResult(Guid id)
        {
            return await _eventRepository.GetEventResult(id);
        }
    }
}
