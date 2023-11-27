using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class ReportDocumentDTO
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string QuantitySold { get; set; }
        public decimal SaleTotal { get; set; }
        public decimal InitialValue { get; set; }
        public decimal TotalWithInitialValue { get; set; }
        public virtual string BarColor
        {
            get
            {
                var randomNumber = new Random();
                return $"rgb({randomNumber.Next(50 ,200)}, {randomNumber.Next(50, 200)}, {randomNumber.Next(50, 200)})";
            }
        }
    }
}
