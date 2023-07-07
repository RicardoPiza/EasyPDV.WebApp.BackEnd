using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class SoldProduct 
    {
        public Guid SoldProductId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
