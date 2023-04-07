using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class CashierOpen : Cashier
    {
        public bool Status { get; set; }
        public double InitialBalance { get; set; }
    }
}
