using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EasyPDV.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {

        private readonly ILogger<SaleController> _logger;
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _configuration;
        private readonly ISaleService _saleService;

        public SaleController(
            ILogger<SaleController> logger,
            IProductRepository productRepository,
            IProductService productService,
            IConfiguration configuration,
            ISaleService saleService 
            )
        {
            _logger = logger;
            _productService = productService;
            _productRepository = productRepository;
            _configuration = configuration;
            _saleService = saleService;
        }
        [HttpPost("MakeSale")]
        public IActionResult PostRegularSale(SaleDTO sale)
        {

            try
            {
                var _response = _saleService.PostSale(sale);
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
        [HttpPost("PrepareSale")]
        public IActionResult PrepareSale(List<ProductDTO> products)
        {

            try
            {
                var _response = _saleService.PrepareSale(products);
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