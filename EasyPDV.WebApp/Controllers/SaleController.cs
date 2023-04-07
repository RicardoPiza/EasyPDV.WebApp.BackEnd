using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EasyPDV.WebApp.Controllers
{
    public class SaleController : Controller
    {
        private readonly ILogger<SaleController> _logger;
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _configuration;

        public SaleController(
            ILogger<SaleController> logger,
            IProductRepository productRepository,
            IProductService productService,
            IConfiguration configuration)
        {
            _logger = logger;
            _productService = productService;
            _productRepository = productRepository;
            _configuration = configuration;
        }

        [HttpGet("/test/{num}")]
        public double Test(double num) { 
            
            return num * 3.14 ;
        }
        
    }
}