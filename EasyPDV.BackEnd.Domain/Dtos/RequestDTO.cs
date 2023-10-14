using EasyPDV.BackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class RequestDTO<T> 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ECashierStatus CashierStatus { get; set; }
        public Decimal Balance { get; set; }
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public T Sales { get; set; }
    }
}
