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

    public class HealthcareProviderController : ControllerBase
    {
        private readonly IHealthcareProviderService _classService;
        public HealthcareProviderController(IHealthcareProviderService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HealthcareProvider>>> GetClasses()
        {
            return Ok(await _classService.GetTypesMoneyes());
        }
        [HttpGet("{IdHealthcareProvider}")]
        public async Task<ActionResult<HealthcareProvider>> GetClass(int IdHealthcareProvider)
        {
            var clase = await _classService.GetTypesMoney(IdHealthcareProvider);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }
        [HttpPost]
        public async Task<ActionResult<HealthcareProvider>> CreateClass(string HealthcareProviderName, long PhoneEmergency)
        {
            try
            {
                var createdClass = await _classService.createTypesMoney(PhoneEmergency, HealthcareProviderName);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear el provedor");
                }
                return Ok($"Se ha creado el provedor correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la asistencia: {ex.Message}");
            }
        }


        [HttpPut("{IdHealthcareProvider}")]
        public async Task<ActionResult<HealthcareProvider>> UpdateStudent(int IdHealthcareProvider, string? HealthcareProviderName = null)
        {
            var updatedClass = await _classService.updateTypesMoney(IdHealthcareProvider, HealthcareProviderName);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdHealthcareProvider}")]
        public async Task<ActionResult<HealthcareProvider>> DeleteClass(int IdHealthcareProvider)
        {
            var student = await _classService.deleteTypesMoney(IdHealthcareProvider);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}