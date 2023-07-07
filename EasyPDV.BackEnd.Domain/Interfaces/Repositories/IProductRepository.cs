using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> ReadProduct();
        Task<ProductDTO> Create(ProductDTO product);
        Task<ProductDTO> Update(ProductDTO product);
        Task<Product> Remove(Guid id);
        Task<ProductDTO> GetById(Guid id);
        Task<ProductResult> List(ProductDTOList productList);
        Task<ImageSaveResult> SaveImage(IFormFile productImage, Guid id);
    }
}
