using EasyPDV.BackEnd.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Services
{
    public interface IEventService
    {
        public Task<EventDTO> StartEvent(EventDTO eventDTO); 
    }
}
