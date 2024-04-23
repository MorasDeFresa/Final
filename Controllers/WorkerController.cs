using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NightClub.Dto;
using NightClub.Models;
using NightClub.Services;

namespace NightClub.Controllers
{
    public class WorkerUpdate
    {
        public int IdWorker;
        public string? NameUser { get; set; } = null;
        public string? SurnameUser { get; set; } = null;
        public string? DocumentNumber { get; set; } = null;
        public int? IdHealthcareProviders { get; set; } = null;
        public int? IdTypesWorker { get; set; } = null;
        public int? IdStatusWorker { get; set; } = null;
        public DateOnly DateOfBirth { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _WorkerService;

        public WorkerController(IWorkerService WorkerService)
        {
            _WorkerService = WorkerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Worker>>> GetWorkers()
        {
            try
            {
                var Workers = await _WorkerService.GetWorkers();
                return Ok(Workers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las Workeres: {ex.Message}");
            }
        }

        [HttpGet("{WorkerId}")]
        public async Task<ActionResult<Worker>> GetWorker(int WorkerId)
        {
            try
            {
                var Worker = await _WorkerService.GetWorker(WorkerId);
                if (Worker == null)
                {
                    return NotFound();
                }
                return Ok(Worker);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la Workere: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Worker>> CreateWorker(WorkerDto WorkerDto)
        {
            try
            {
                var newWorker = await _WorkerService.CreateWorker(WorkerDto);
                if (newWorker == null)
                {
                    return BadRequest("No se pudo crear el Workere");
                }
                return Ok(newWorker);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el Workere: {ex.Message}");
            }
        }

        [HttpPut("{IdWorker}")]
        public async Task<ActionResult<Worker>> UpdateAttendance(int IdWorker, WorkerUpdate WorkerUpdate)
        {
            try
            {
                WorkerUpdate.IdWorker = IdWorker;
                var updatedAttendance = await _WorkerService.UpdateWorker(WorkerUpdate);
                return Ok(_WorkerService.GetWorker(IdWorker));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al editar el Workere: {ex.Message}");
            }
        }

        [HttpDelete("{IdWorker}")]
        public async Task<ActionResult<Worker>> DeleteAttendance(int IdWorker)
        {
            try
            {
                var attendance = await _WorkerService.DeleteWorker(IdWorker);
                return Ok($"Se ha eliminado el Workere con Id {IdWorker}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al editar el Workere: {ex.Message}");
            }

        }
    }
}