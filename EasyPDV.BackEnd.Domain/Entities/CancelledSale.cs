using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class CancelledSale
    {
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.MaxValue;
        public string PaymentMethod { get; set; }
        public Guid CancelledSaleId { get; set; }
        public List<SoldProduct> CancelledSaleProducts { get; set; }
    }
}
