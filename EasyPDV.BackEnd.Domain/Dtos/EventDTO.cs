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
        public string Responsible { get; set; }
        public ECashierStatus CashierStatus { get; set; }
        public Decimal Balance { get; set; }
        public List<SaleDTO> Sales { get; set; }
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
                Sales = eventDTO.Sales?.Select(x => x.Parse(x)).ToList(),
                Date= eventDTO.Date,
                Duration = eventDTO.Duration,
                Responsible = eventDTO.Responsible,

            };
        }
        public void AddSale(SaleDTO sale)
        {
            Sales.Add(sale);
        }
    }
}
