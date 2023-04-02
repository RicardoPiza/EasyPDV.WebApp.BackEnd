using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    internal class CashierBleed : Cashier
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    }
}
