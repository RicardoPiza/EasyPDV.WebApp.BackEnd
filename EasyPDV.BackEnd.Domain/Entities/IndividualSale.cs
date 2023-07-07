using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class IndividualSale
    {
        public Guid IndividualSaleId { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.MaxValue;
        public string PaymentMethod { get; set; }
        public SoldProduct SoldProduct { get; set; }
        public IndividualSale()
        {
            
        }
    }
}
