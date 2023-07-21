using EasyPDV.BackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class Sale 
    {
        public Guid Id { get; set; }
        public List<SoldProduct> Products { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; }
        public ESaleType SaleType {get; set; }
        public string ChangeFrom { get; set; }
        public string ChangeTo { get; set; }

    }
}
