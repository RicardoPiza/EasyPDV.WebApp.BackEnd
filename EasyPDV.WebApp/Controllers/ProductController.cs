using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPDV.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _configuration;

        public ProductController(
            ILogger<ProductController> logger,
            IProductRepository productRepository,
            IProductService productService,
            IConfiguration configuration
            )
        {
            _logger = logger;
            _productService = productService;
            _productRepository = productRepository;
            _configuration = configuration;
        }
        [HttpPost("Add")]
        public IActionResult AddProduct(ProductDTO product)
        {
            try
            {
                var _response = _productRepository.Create(product);
                return Ok(new
                {
                    success = true,
                    data = _response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(ProductDTO product)
        {
            try
            {
                var _response = _productRepository.Update(product);
                return Ok(new
                {
                    success = true,
                    data = _response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var _response = await _productRepository.GetById(id);
                return Ok(new
                {
                    success = true,
                    data = _response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("List")]
        public IActionResult List(ProductDTOList productDTOList)
        {
            try
            {
                var _response = _productRepository.List(productDTOList);
                return Ok(new
                {
                    success = true,
                    data = _response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            try
            {
                var _response = _productRepository.Remove(id);
                return Ok(new
                {
                    success = true,
                    data = _response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SaveImage/{id}")]
        public async Task<IActionResult> SaveImage(IFormFile Image, Guid id)
        {
            try
            {
                
                var _response = await _productRepository.SaveImage(Image, id);
                return Ok(new
                {
                    success = true,
                    data = _response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
