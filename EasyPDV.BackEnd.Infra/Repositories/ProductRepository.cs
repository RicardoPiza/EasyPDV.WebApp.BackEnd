using Dapper;
using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using Microsoft.Data.SqlClient;
using EasyPDV.BackEnd.Domain.Results;
using EasyPDV.BackEnd.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Azure.Messaging;
using System.Globalization;

namespace EasyPDV.BackEnd.Domain.Interfaces.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly PdvDbContext _pdvDbContext;

        public ProductRepository(
            IConfiguration configuration,
            PdvDbContext pdvDbContext
            )
        {
            _configuration = configuration;
            _pdvDbContext = pdvDbContext;
        }
        public async Task<List<Product>> ReadProduct()
        {
            return await _pdvDbContext.Set<Product>()
                        .ToListAsync();
        }
        public async Task<ProductDTO> Create(ProductDTO product)
        {
            var _productParse = product.Parse(product);
            var _product = _pdvDbContext.Products.AddAsync(_productParse).Result.Entity;
            await _pdvDbContext.SaveChangesAsync();
            _pdvDbContext.ChangeTracker.Clear();
            return _product.Parse(_product);

        }
        public async Task<ProductDTO> Update(ProductDTO product)
        {
            var _productParse = product.Parse(product);
            _pdvDbContext.Update(_productParse);

            await _pdvDbContext.SaveChangesAsync();
            _pdvDbContext.ChangeTracker.Clear();
            return product;

        }
        public async Task<ProductDTO> GetById(Guid id)
        {

            try
            {
                var _product = await _pdvDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
                return _product!.Parse(_product);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Product> Remove(Guid id)
        {
            var _product = await _pdvDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (_product != null)
            {
                _product = _pdvDbContext.Products.Remove(_product).Entity;
                await _pdvDbContext.SaveChangesAsync();
                _pdvDbContext.ChangeTracker.Clear();
            }
            return _product;
        }

        public async Task<ProductResult> List(ProductDTOList productDTO)
        {
            var result = new ProductResult();
            using (SqlConnection conn = new(
                _configuration.GetConnectionString("DefaultConnection")))
            {
                var _query = $@"
                    select * from products where OwnerUserEmail = '{productDTO.OwnerUserEmail}' order by name";

                result.Products = await conn.QueryAsync<ProductDTO>(_query);

                
                var _queryTotal = $@"select count(1) from produtos";
            }
            return result;
        }

        public async Task<ImageSaveResult> SaveImage(byte[] productImage, Guid id)
            {
            var product = await _pdvDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                product.Image = productImage;

                _pdvDbContext.Entry(product).State = EntityState.Modified;

                try
                {
                    await _pdvDbContext.SaveChangesAsync();
                    _pdvDbContext.ChangeTracker.Clear();
                    return new ImageSaveResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving image to database: {ex.Message}");
                    throw;
                }
            }
            else
            {
                Console.WriteLine($"Product with ID {id} not found.");
                return null; 
            }
        }
    }
}

