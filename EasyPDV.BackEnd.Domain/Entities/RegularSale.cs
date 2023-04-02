using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    internal class RegularSale :Sale
    {
        public List<Product> Products { get; set; }

        public RegularSale()
        {
        }
    }
}
