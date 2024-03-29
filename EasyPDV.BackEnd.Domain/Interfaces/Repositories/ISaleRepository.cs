﻿using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> Create(Sale sale);
        Task<List<EventReportDocumentDTO>> GetSoldProductsReport(string responsible, Guid id);
        Task<List<SaleReportDocumentDTO>>GetSalesReport(string responsible, Guid id);
    }
}
