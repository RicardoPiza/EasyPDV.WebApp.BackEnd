using EasyPDV.BackEnd.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public class ProductService : IProductService
    {
        private IConfiguration _configuration;

        public ProductService(
            IConfiguration configuration
            
            ) 
        {
            configuration = _configuration;
        }
        //public async Task<List<ProductDTO>> List(ProductDTO productDTO)
        //{
        //    var prod = productDTO.Parse(productDTO);
        //    var _products = await _productRepository.List(prod);
        //    return _products.Products.ToList();
        //}
        public byte[] ConvertIFormFileToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public IFormFile ConvertByteArrayToIFormFile(byte[] fileData, string fileName)
        {
            // Create a new MemoryStream using the byte array
            using (var memoryStream = new MemoryStream(fileData))
            {
                // Create a new FormFile using the MemoryStream and file name
                var formFile = new FormFile(memoryStream, 0, fileData.Length, null, fileName);
                return formFile;
            }
        }
    }
}
