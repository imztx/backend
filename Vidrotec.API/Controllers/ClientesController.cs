using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vidrotec.Application.DTOs;
using Vidrotec.Application.Services.Interfaces;

namespace Vidrotec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClienteDto request)
        {
            var cliente = await _clienteService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateClienteDto request)
        {
            var cliente = await _clienteService.UpdateAsync(id, request);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _clienteService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportCsv(ImportClienteCsvDto request)
        {
            var result = await _clienteService.ImportCsvAsync(request);
            return Ok(result);
        }
    }
}
