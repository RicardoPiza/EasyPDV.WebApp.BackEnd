using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class SaleReportDocumentDTO
    {
        public string ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string SaleDate { get; set; }
        public string SaleTime { get; set; }
        public string EventName { get; set; }
        public string Responsible { get; set; }
        public Guid SaleId { get; set; }    
    }
}
