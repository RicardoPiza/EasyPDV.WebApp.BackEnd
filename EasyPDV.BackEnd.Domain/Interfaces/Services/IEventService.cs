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
        Task<EventDTO> AddSale(EventDTO eventDTO);
        Task<EventDTO> GetEvent(string responsible);
        Task<EventDTO> StartEvent(EventDTO eventDTO);
        Task<EventDTO> StopEvent(EventDTO eventDTO);
        Task<EventCloseResult> GetEventResult(Guid id);
        Task<List<EventReportDTO>> GetEventReport(string responsible);
        Task<string> SendDuration(EventDTO eventDTO);
        Task<EventDTO> Get(Guid id);
    }
}
