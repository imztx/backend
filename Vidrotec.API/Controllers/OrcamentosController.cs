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
    public class OrcamentosController : ControllerBase
    {
        private readonly IOrcamentoService _orcamentoService;

        public OrcamentosController(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orcamentos = await _orcamentoService.GetAllAsync();
            return Ok(orcamentos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrcamentoDto request)
        {
            var orcamento = await _orcamentoService.CreateAsync(request);
            return CreatedAtAction(nameof(GetAll), new { id = orcamento.Id }, orcamento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orcamentoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
