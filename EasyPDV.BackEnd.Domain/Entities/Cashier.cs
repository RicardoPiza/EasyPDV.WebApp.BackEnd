using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    internal class Cashier
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public int Number { get; set; }
        public string Responsible { get; set; }
        public DateTime Date { get; set; }
    }
}
