using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NightClub.Models;
using NightClub.Services;

namespace NightClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EventController : ControllerBase
    {
        private readonly IEventService _classService;
        public EventController(IEventService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetClasses()
        {
            return Ok(await _classService.GetTypesMoneyes());
        }
        [HttpGet("{IdEvent}")]
        public async Task<ActionResult<Event>> GetClass(int IdEvent)
        {
            var clase = await _classService.GetTypesMoney(IdEvent);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }
        [HttpPost]
        public async Task<ActionResult<Event>> CreateClass(string EventName, DateOnly DateEvent, int MaximumClientCapacity)
        {
            try
            {
                var createdClass = await _classService.createTypesMoney(EventName, DateEvent, MaximumClientCapacity);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la clase");
                }
                return CreatedAtAction(nameof(GetClass), new { ClassId = createdClass.IdEvent }, createdClass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la asistencia: {ex.Message}");
            }
        }


        [HttpPut("{IdEvent}")]
        public async Task<ActionResult<Event>> UpdateStudent(int IdEvent, DateOnly DateEvent, string? EventName = null, int? MaximumClientCapacity = null)
        {
            var updatedClass = await _classService.updateTypesMoney(IdEvent, DateEvent, EventName, MaximumClientCapacity);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdEvent}")]
        public async Task<ActionResult<Event>> DeleteClass(int IdEvent)
        {
            var student = await _classService.deleteTypesMoney(IdEvent);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}