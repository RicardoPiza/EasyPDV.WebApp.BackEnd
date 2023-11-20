using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Entities.Notifications;
using EasyPDV.BackEnd.Domain.Interfaces;
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
        private readonly INotificationContext _notificationContext;

        public ProductController(
            ILogger<ProductController> logger,
            IProductRepository productRepository,
            IProductService productService,
            IConfiguration configuration,
            INotificationContext notificationContext
            )
        {
            _logger = logger;
            _productService = productService;
            _productRepository = productRepository;
            _configuration = configuration;
            _notificationContext = notificationContext;
        }
        [HttpPost("Add")]
        public IActionResult AddProduct(ProductDTO product)
        {
            try
            {
                var _response = _productService.Add(product);

                if (_response is null)
                {
                    return Ok(new
                    {
                        success = false,
                        data = _notificationContext.Notifications().Select(x => x.Message).ToList()
                    });
                }
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

                var _image = _productService.ConvertIFormFileToByteArray(Image);
                var _response = await _productService.SaveImage(_image, id);
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
