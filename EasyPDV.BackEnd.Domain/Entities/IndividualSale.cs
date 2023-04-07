using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class IndividualSale : Sale
    {
        public Product Product { get; set; }
        public IndividualSale()
        {
            
        }
    }
}
