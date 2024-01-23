using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<Event> AddSale(Event Event);
        Task<Event> Get(string responsible);
        Task<Event> StartEvent(Event Event);
        Task<Event> StopEvent(Event Event);
        Task<Event> GetById(Guid Id);
        Task<EventCloseResult> GetEventResult(Guid id);
        Task<List<EventReportDTO>> GetEventReport(string responsible);
        Task<string> SendDuration(EventDTO eventDTO);
        Task<Event> Get(Guid eventId);


    }
}
