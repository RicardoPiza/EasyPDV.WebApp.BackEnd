using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ECashierStatus CashierStatus { get; set; }
        public Decimal Balance { get; set; }
        public List<Sale> Sales { get; set; }
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public Event Parse(EventDTO eventDTO)
        {
            return new Event()
            {
                Id = eventDTO.Id,
                Name = eventDTO.Name,
                CashierStatus = eventDTO.CashierStatus,
                Balance = eventDTO.Balance,
                Sales = eventDTO.Sales,
                Date= eventDTO.Date,
                Duration = eventDTO.Duration,
            };
        }
    }
}
