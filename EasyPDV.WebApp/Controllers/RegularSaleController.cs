using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EasyPDV.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegularSaleController : ControllerBase
    {

        private readonly ILogger<RegularSaleController> _logger;
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _configuration;
        private readonly IRegularSaleService _regularSaleService;

        public RegularSaleController(
            ILogger<RegularSaleController> logger,
            IProductRepository productRepository,
            IProductService productService,
            IConfiguration configuration,
            IRegularSaleService regularSaleService 
            )
        {
            _logger = logger;
            _productService = productService;
            _productRepository = productRepository;
            _configuration = configuration;
            _regularSaleService = regularSaleService;
        }
        [HttpPost("MakeRegularSale")]
        public IActionResult PostRegularSale(RegularSale regularSale)
        {

            try
            {
                var _response = _regularSaleService.PostRegularSale (regularSale);
                return Ok(
                   _response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}