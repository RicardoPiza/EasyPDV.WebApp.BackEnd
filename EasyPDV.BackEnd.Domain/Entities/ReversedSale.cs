using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    internal class ReversedSale : Sale
    {
        public string ProductChangeFrom { get; set; }
        public string ProductChangeTo { get; set; }
        public double Balance { get; set; }
        public string ChangeType { get; set; }
    }
}
