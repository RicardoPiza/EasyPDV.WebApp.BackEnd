using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Dtos
{
    public class GroupedSalesDTO
    {
        public Guid SaleId { get; set; }

        public List<SaleReportDocumentDTO> Sales { get; set; } = new();
    }
}
