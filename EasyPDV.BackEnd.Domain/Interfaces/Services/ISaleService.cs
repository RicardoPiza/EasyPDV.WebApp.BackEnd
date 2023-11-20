using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public interface ISaleService
    {
        Task<Sale> PostSale(SaleDTO sale);
        Task<PrepareSaleDTO> PrepareSale(List<ProductDTO> sale);
        Task<SaleDTO> Validate(SaleDTO sale);
    }
}
