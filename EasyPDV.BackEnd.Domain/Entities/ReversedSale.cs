using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class ReversedSale : Sale
    {
        
        public Product ProductChangeFrom { get; set; }
        public Product ProductChangeTo { get; set; }
        public double Balance { get; set; }
        public string ChangeType { get; set; }
    }
}
