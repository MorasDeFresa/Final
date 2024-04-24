using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NightClub.Models;
using NightClub.Services;

namespace Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StatusWorkerController : ControllerBase
    {
        private readonly IStatusWorkersService _classService;
        public StatusWorkerController(IStatusWorkersService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusWorker>>> GetClasses()
        {
            return Ok(await _classService.GetTypesMoneyes());
        }
        [HttpGet("{IdTypeMoney}")]
        public async Task<ActionResult<StatusWorker>> GetClass(int IdTypeMoney)
        {
            var clase = await _classService.GetTypesMoney(IdTypeMoney);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }
        [HttpPost]
        public async Task<ActionResult<StatusWorker>> CreateClass(string StatusWorkerName)
        {
            try
            {
                var createdClass = await _classService.createTypesMoney(StatusWorkerName);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la clase");
                }
                return Ok($"Se ha creado el estatus correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la asistencia: {ex.Message}");
            }
        }


        [HttpPut("{IdTypeMoney}")]
        public async Task<ActionResult<StatusWorker>> UpdateStudent(int IdTypeMoney, string? StatusWorkerName = null)
        {
            var updatedClass = await _classService.updateTypesMoney(IdTypeMoney, StatusWorkerName);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdTypeMoney}")]
        public async Task<ActionResult<StatusWorker>> DeleteClass(int IdTypeMoney)
        {
            var student = await _classService.deleteTypesMoney(IdTypeMoney);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}