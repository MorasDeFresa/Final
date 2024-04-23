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
    public class ClientUpdate
    {
        public int IdClient;
        public string? NameUser { get; set; } = null;
        public string? SurnameUser { get; set; } = null;
        public string? DocumentNumber { get; set; } = null;
        public string? EmailClient { get; set; } = null;
        public string? PasswordClient { get; set; } = null;
        public DateOnly DateOfBirth { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            try
            {
                var Clients = await _clientService.GetClients();
                return Ok(Clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las clientes: {ex.Message}");
            }
        }

        [HttpGet("{ClientId}")]
        public async Task<ActionResult<Client>> GetClient(int ClientId)
        {
            try
            {
                var Client = await _clientService.GetClient(ClientId);
                if (Client == null)
                {
                    return NotFound();
                }
                return Ok(Client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la cliente: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(ClientDto clientDto)
        {
            try
            {
                var newClient = await _clientService.CreateClient(clientDto);
                if (newClient == null)
                {
                    return BadRequest("No se pudo crear el cliente");
                }
                return Ok(newClient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el Cliente: {ex.Message}");
            }
        }

        [HttpPut("{IdClient}")]
        public async Task<ActionResult<Client>> UpdateAttendance(int IdClient, ClientUpdate clientUpdate)
        {
            try
            {
                clientUpdate.IdClient = IdClient;
                var updatedAttendance = await _clientService.UpdateClient(clientUpdate);
                return Ok(_clientService.GetClient(IdClient));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al editar el Cliente: {ex.Message}");
            }
        }

        [HttpDelete("{IdClient}")]
        public async Task<ActionResult<Client>> DeleteAttendance(int IdClient)
        {
            try
            {
                var attendance = await _clientService.DeleteClient(IdClient);
                return Ok($"Se ha eliminado el cliente con Id {IdClient}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al editar el Cliente: {ex.Message}");
            }

        }
    }
}