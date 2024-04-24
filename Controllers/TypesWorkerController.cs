using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NightClub.Services;
using Microsoft.AspNetCore.Mvc;
using NightClub.Models;

namespace NightClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TypesWorkerController : ControllerBase
    {
        private readonly ITypesWorkerService _classService;
        public TypesWorkerController(ITypesWorkerService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypesWorker>>> GetClasses()
        {
            return Ok(await _classService.GetTypesMoneyes());
        }
        [HttpGet("{IdTypesWorker}")]
        public async Task<ActionResult<TypesWorker>> GetClass(int IdTypesWorker)
        {
            var clase = await _classService.GetTypesMoney(IdTypesWorker);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }
        [HttpPost]
        public async Task<ActionResult<TypesWorker>> CreateClass(string TypesWorkerName, int SalaryForHour, int IdTypeMoney)
        {
            try
            {
                var createdClass = await _classService.createTypesMoney(TypesWorkerName, SalaryForHour, IdTypeMoney);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la clase");
                }
                return Ok($"Se ha creado el tipo correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la asistencia: {ex.Message}");
            }
        }


        [HttpPut("{IdTypesWorker}")]
        public async Task<ActionResult<TypesWorker>> UpdateStudent(int SalaryForHour, int IdTypesWorker, string? TypesWorkerName = null)
        {
            var updatedClass = await _classService.updateTypesMoney(IdTypesWorker, TypesWorkerName, SalaryForHour);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdTypesWorker}")]
        public async Task<ActionResult<TypesWorker>> DeleteClass(int IdTypesWorker)
        {
            var student = await _classService.deleteTypesMoney(IdTypesWorker);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}