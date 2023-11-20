using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Interfaces;
using EasyPDV.BackEnd.Domain.Interfaces.Repositories;
using EasyPDV.BackEnd.Domain.Interfaces.Services;
using Flunt.Notifications;
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
        private readonly IEventService _eventService;
        private readonly IEventRepository _eventRepository;
        private readonly INotificationContext _notificationContext;

        public SaleController(
            ILogger<SaleController> logger,
            IProductRepository productRepository,
            IProductService productService,
            IConfiguration configuration,
            ISaleService saleService,
            IEventService eventService,
            IEventRepository eventRepository,
            INotificationContext notificationContext
            )
        {
            _logger = logger;
            _productService = productService;
            _productRepository = productRepository;
            _configuration = configuration;
            _saleService = saleService;
            _eventService = eventService;
            _eventRepository = eventRepository;
            _notificationContext = notificationContext;
        }
        [HttpPost("MakeSale")]
        public async Task<IActionResult> PostRegularSale(EventDTO _request)
        {
            try
            {
                var _response = await _eventService.AddSale(_request);
                var _notifications = new List<string>();

                if (_response is null)
                {
                    return Ok(new
                    {
                        success = false,
                        errors = _notificationContext.Notifications().Select(x => x.Message).ToList()
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
        [HttpPost("PrepareSale")]
        public IActionResult PrepareSale(List<ProductDTO> products)
        {

            try
            {
                var _response = _saleService.PrepareSale(products);

                if (_notificationContext.HasNotifications())
                {
                    return Ok(new
                    {
                        success = false,
                        errors = _notificationContext.Notifications().Select(x => x.Message).ToList()
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

    }
}