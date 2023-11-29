using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities.Notifications;
using EasyPDV.BackEnd.Domain.Interfaces;
using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using EasyPDV.BackEnd.Domain.Interfaces.Services;
using EasyPDV.BackEnd.Domain.Results;
using Microsoft.Extensions.Configuration;

namespace EasyPDV.BackEnd.Domain.Services
{
    public class EventService : IEventService
    {
        private IConfiguration _configuration;
        private IEventRepository _eventRepository;
        private INotificationContext _notificationContext;
        private ISaleService _saleService;

        public EventService(
            IConfiguration configuration,
            IEventRepository eventRepository,
            INotificationContext notificationContext,
            ISaleService saleService

            )
        {
            _configuration = configuration;
            _eventRepository = eventRepository;
            _notificationContext = notificationContext;
            _saleService = saleService;
        }

        public async Task<EventDTO> StartEvent(EventDTO eventDTO)
        {
            var data = await _eventRepository.StartEvent(eventDTO.Parse(eventDTO));

            return data.Parse(data);
        }
        public async Task<EventDTO> GetEvent(string responsible)
        {
            var data = await _eventRepository.Get(responsible);

            return data.Parse(data);
        }
        public async Task<EventDTO> AddSale(EventDTO _eventDTO)
        {

            foreach (var sale in _eventDTO.Sales)
            {
                await _saleService.Validate(sale);

                if (!_notificationContext.HasNotifications())
                {
                    var _result = await _eventRepository.AddSale(_eventDTO.Parse(_eventDTO));
                    return _result.Parse(_result);
                }
            }
            return null;
        }
        public async Task<EventDTO> StopEvent(EventDTO _event)
        {
            var _result = await _eventRepository.StopEvent(_event.Parse(_event));
            return _result.Parse(_result);

        }
        public async Task<EventCloseResult> GetEventResult(Guid id)
        {
            return await _eventRepository.GetEventResult(id);
        }
        public async Task<List<EventReportDTO>> GetEventReport(EventDTO eventDTO)
        {
            return await _eventRepository.GetEventReport(eventDTO);
        }
    }
}
