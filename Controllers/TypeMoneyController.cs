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

    public class TypeMoneyController : ControllerBase
    {
        private readonly ITypesMoneyService _classService;
        public TypeMoneyController(ITypesMoneyService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeMoney>>> GetClasses()
        {
            return Ok(await _classService.GetTypesMoneyes());
        }
        [HttpGet("{IdTypeMoney}")]
        public async Task<ActionResult<TypeMoney>> GetClass(int IdTypeMoney)
        {
            var clase = await _classService.GetTypesMoney(IdTypeMoney);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }
        [HttpPost]
        public async Task<ActionResult<TypeMoney>> CreateClass(string TypeMoneyName)
        {
            try
            {
                var createdClass = await _classService.createTypesMoney(TypeMoneyName);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la clase");
                }
                return CreatedAtAction(nameof(GetClass), new { ClassId = createdClass.IdTypeMoney }, createdClass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la asistencia: {ex.Message}");
            }
        }


        [HttpPut("{IdTypeMoney}")]
        public async Task<ActionResult<TypeMoney>> UpdateStudent(int IdTypeMoney, string? TypeMoneyName = null)
        {
            var updatedClass = await _classService.updateTypesMoney(IdTypeMoney, TypeMoneyName);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdTypeMoney}")]
        public async Task<ActionResult<TypeMoney>> DeleteClass(int IdTypeMoney)
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