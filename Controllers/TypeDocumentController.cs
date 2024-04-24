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

    public class TypeDocumentController : ControllerBase
    {
        private readonly ITypeDocumentService _classService;
        public TypeDocumentController(ITypeDocumentService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeDocument>>> GetClasses()
        {
            return Ok(await _classService.GetTypesMoneyes());
        }
        [HttpGet("{IdTypeDocument}")]
        public async Task<ActionResult<TypeDocument>> GetClass(int IdTypeDocument)
        {
            var clase = await _classService.GetTypesMoney(IdTypeDocument);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }
        [HttpPost]
        public async Task<ActionResult<TypeDocument>> CreateClass(string TypeDocumentName)
        {
            try
            {
                var createdClass = await _classService.createTypesMoney(TypeDocumentName);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la el tipo de documento");
                }
                return Ok($"Se ha creado el tipo correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la asistencia: {ex.Message}");
            }
        }


        [HttpPut("{IdTypeDocument}")]
        public async Task<ActionResult<TypeDocument>> UpdateStudent(int IdTypeDocument, string? TypeDocumentName = null)
        {
            var updatedClass = await _classService.updateTypesMoney(IdTypeDocument, TypeDocumentName);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdTypeDocument}")]
        public async Task<ActionResult<TypeDocument>> DeleteClass(int IdTypeDocument)
        {
            var student = await _classService.deleteTypesMoney(IdTypeDocument);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}