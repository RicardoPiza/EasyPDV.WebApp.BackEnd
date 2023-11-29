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
                var _response = await _eventService.StartEvent(eventDTO);
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
        [HttpPost("StopEvent")]
        public async Task<IActionResult> StopEvent(EventDTO eventDTO)
        {
            try
            {
                var _response = await _eventService.StopEvent(eventDTO);
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
        [HttpGet("GetEvent/{responsible}")]
        public async Task<IActionResult> GetEvent(string responsible)
        {
            try
            {
                var _response = _eventService.GetEvent(responsible);
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
        [HttpGet("GetEventResult/{id}")]
        public async Task<IActionResult> GetEventResult(Guid id)
        {
            try
            {
                var _response =  await _eventService.GetEventResult(id);
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
        [HttpPost("GetEventReport")]
        public async Task<IActionResult> GetEventReport(EventDTO eventDTO)
        {
            try
            {
                var _response = await _eventService.GetEventReport(eventDTO);
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
