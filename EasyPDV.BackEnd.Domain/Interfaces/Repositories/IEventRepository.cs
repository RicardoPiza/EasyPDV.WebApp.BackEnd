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
        public Task<Event> AddSale(Event Event);
        public Task<Event> Get(string responsible);
        public Task<Event> StartEvent(Event Event);
        public Task<Event> StopEvent(Event Event);
        public Task<Event> GetById(Guid Id);
        public Task<EventCloseResult> GetEventResult(Guid id);
        public Task<List<EventReportDTO>> GetEventReport(string responsible);
        public Task<string> SendDuration(EventDTO eventDTO);


    }
}
