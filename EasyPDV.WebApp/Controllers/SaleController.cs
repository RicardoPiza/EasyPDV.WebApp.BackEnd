using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyPDV.WebApp.Controllers
{
    public class SaleController : Controller
    {
        private readonly ILogger<SaleController> _logger;

        public SaleController(ILogger<SaleController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/test/{num}")]
        public double Test(double num) { 
            
            return num * 3.14 ;
        }
        
    }
}