using EasyPDV.BackEnd.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Results
{
    public class ProductResult
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public int QuantidadeDePaginas { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalDeRegistros { get; set; }
    }
}
