using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Entities.Notifications;
using EasyPDV.BackEnd.Domain.Results;
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
        private INotificationContext _notificationContext;
        private IProductRepository _productRepository;

        public ProductService(
            INotificationContext notificationContext,
            IProductRepository productRepository

            )
        {
            _notificationContext = notificationContext;
            _productRepository = productRepository;
        }

        public async Task<Product> Add(ProductDTO productDTO)
        {

            Validate(productDTO);

            if (!_notificationContext.HasNotifications())
            {
                var _result = await _productRepository.Create(productDTO);
                return _result.Parse(_result);
            }

            return null;
        }
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

        public void Validate(ProductDTO produto)
        {
            if (string.IsNullOrEmpty(produto.Name))
            {
                _notificationContext.AddNotification("Produto", "Produto deve ter um nome");
            }

            if (string.IsNullOrEmpty(produto.Status))
            {
                _notificationContext.AddNotification("Produto", "Produto deve ter um status ('Ativo' ou 'Inativo')");
            }

            if (produto.Price <= 0)
            {
                _notificationContext.AddNotification("Produto", "Valor do produto deve ser informado");
            }

            if (produto.StockQuantity <= 0)
            {
                _notificationContext.AddNotification("Produto", "Quantidade em estoque deve ser informada");
            }
        }

        public async Task<ImageSaveResult> SaveImage(byte[] productImage, Guid id)
        {
            return await _productRepository.SaveImage(productImage, id);
        }
    }
}
