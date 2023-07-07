using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class ReversedSale 
    {
        public Guid ReversedSaleId { get; set; }
        public SoldProduct ProductChangeFrom { get; set; }
        public Product ProductChangeTo { get; set; }
        public double Balance { get; set; }
        public string ChangeType { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.MaxValue;
        public string PaymentMethod { get; set; }
    }
}
