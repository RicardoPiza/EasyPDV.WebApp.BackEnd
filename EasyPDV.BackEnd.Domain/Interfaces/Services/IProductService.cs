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
    public interface IProductService
    {
        //Task<List<ProductDTO>> List(ProductDTO productDTO);
        public byte[] ConvertIFormFileToByteArray(IFormFile file);
        public IFormFile ConvertByteArrayToIFormFile(byte[] fileData, string fileName);
        public Task<Product> Add(ProductDTO productDTO);
        Task<ImageSaveResult> SaveImage(byte[] productImage, Guid id);

    }
}
