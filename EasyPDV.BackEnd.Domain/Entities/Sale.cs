

namespace EasyPDV.BackEnd.Domain.Entities
{
    internal class Sale
    {
        public int ID { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.MaxValue;
        public string PaymentMethod { get; set; }
    }
}
