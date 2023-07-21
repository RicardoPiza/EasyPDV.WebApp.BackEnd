﻿using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ECashierStatus CashierStatus { get; set; }
        public Decimal Balance { get; set; }
        public List<Sale> Sales{ get; set; }
        public DateTime Date { get; set; }
        public double Duration { get; set; }

        public EventDTO Parse(Event eventDTO)
        {
            return new EventDTO()
            {
                Id = eventDTO.Id,
                Name = eventDTO.Name,
                CashierStatus = eventDTO.CashierStatus,
                Balance = eventDTO.Balance,
                Sales = eventDTO.Sales,
                Date = eventDTO.Date,
                Duration = eventDTO.Duration,
            };
        }

        public Event AddEvent(Event Event)
        {

            return new Event
            {
                Name = Event.Name,
                CashierStatus = Event.CashierStatus,
                Balance = Event.Balance,
                Date = DateTime.Now,
                Duration = Event.Duration,
            };

        }

        public Event() { }
    }
}
