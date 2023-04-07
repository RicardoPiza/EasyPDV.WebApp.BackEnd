using EasyPDV.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        public Task<Product> ReadProduct()
        {
            throw new NotImplementedException();
        }
    }
}
