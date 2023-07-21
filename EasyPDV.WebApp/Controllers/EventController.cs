using EasyPDV.BackEnd.Domain.Dtos;
using EasyPDV.BackEnd.Domain.Entities;
using EasyPDV.BackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyPDV.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private IEventService _eventService;

        public EventController(
            IEventService eventService
            )
        {
            _eventService = eventService;
        }

        [HttpPost("StartEvent")]
        public async Task<IActionResult> StartEvent(EventDTO eventDTO)
        {
            try
            {
                var _response = _eventService.StartEvent(eventDTO);
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
