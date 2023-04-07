

namespace EasyPDV.BackEnd.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.MaxValue;
        public string PaymentMethod { get; set; }

    }
}
