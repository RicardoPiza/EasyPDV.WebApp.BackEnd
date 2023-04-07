using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class Cashier
    {
        public Guid Id { get; set; }
        public string EventName { get; set; }
        public int CashierNumber { get; set; }
        public string CashierResponsible { get; set; }
        public DateTime Date { get; set; }
    }
}
