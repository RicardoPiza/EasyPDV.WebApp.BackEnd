using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class EventReportDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal InitialBalance { get; set; }
        public DateTime Created { get; set; }
        public int Duration { get; set; }
        public decimal TotalProfit { get; set; }
        public virtual string BarColor
        {
            get
            {
                var randomNumber = new Random();
                return $"rgb({randomNumber.Next(80 ,190)}, {randomNumber.Next(80, 190)}, {randomNumber.Next(80, 190)})";
            }
        }
    }
}
