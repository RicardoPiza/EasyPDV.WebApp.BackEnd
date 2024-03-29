﻿using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities.Notifications;
using EasyPDV.BackEnd.Domain.Enums;
using EasyPDV.BackEnd.Domain.Interfaces;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class Event
    {
        private INotificationContext _notificationContext;

        public Event(

            INotificationContext notificationContext

            )
        {
            _notificationContext = notificationContext;
        }
        public Event() { }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Responsible { get; set; }
        public ECashierStatus CashierStatus { get; set; }
        public Decimal Balance { get; set; }
        public List<Sale> Sales { get; set; } = new List<Sale>();
        public DateTime Date { get; set; }
        public string Duration { get; set; }

        public EventDTO Parse(Event eventDTO)
        {
            return new EventDTO()
            {
                Id = eventDTO.Id,
                Name = eventDTO.Name,
                CashierStatus = eventDTO.CashierStatus,
                Balance = eventDTO.Balance,
                Sales = eventDTO.Sales?.Select(x => x.Parse(x)).ToList(),
                Date = eventDTO.Date,
                Duration = eventDTO.Duration,
                Responsible = eventDTO.Responsible,
            };
        }

        public Event AddEvent(Event Event)
        {

            return new Event
            {
                Name = Event.Name,
                CashierStatus = ECashierStatus.Openned,
                Balance = Event.Balance,
                Date = DateTime.Now,
                Duration = Event.Duration,
                Responsible = Event.Responsible,
            };
        }
        public Event StopEvent(Event Event)
        {
            return new Event
            {
                Id = Event.Id,
                Name = Event.Name,
                CashierStatus = ECashierStatus.Closed,
                Balance = Event.Balance,
                Date = DateTime.Now,
                Duration = Event.Duration,
                Responsible = Event.Responsible,
            };
        }

        public void AddSale(Sale sale)
        {
            if (!string.IsNullOrEmpty(sale.PaymentMethod))
            {
                Sales.Add(sale);
            }
        }
        public void SetSale()
        {
            Sales.ForEach(x =>
            {
                x.SetSale();
            });
        }
    }
}
