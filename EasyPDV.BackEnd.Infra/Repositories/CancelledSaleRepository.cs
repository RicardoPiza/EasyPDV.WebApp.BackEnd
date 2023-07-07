using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public class CancelledSaleRepository: ICancelledSaleRepository
    {
        public Guid CancelledSaleId { get; set; }
    }
}
