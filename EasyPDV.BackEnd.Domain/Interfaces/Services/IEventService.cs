using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Services
{
    public interface IEventService
    {
        public Task<EventDTO> AddSale(EventDTO eventDTO);
        public Task<EventDTO> GetEvent(string responsible);
        public Task<EventDTO> StartEvent(EventDTO eventDTO);
        public Task<EventDTO> StopEvent(EventDTO eventDTO);
        public Task<EventCloseResult> GetEventResult(Guid id);
        public Task<List<EventReportDTO>> GetEventReport(EventDTO eventDTO);
    }
}
