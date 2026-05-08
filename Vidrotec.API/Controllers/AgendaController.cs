using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vidrotec.Application.DTOs.Agenda;
using Vidrotec.Application.Services.Interfaces;

namespace Vidrotec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaServicoService _agendaService;

        public AgendaController(IAgendaServicoService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agenda = await _agendaService.GetAllAsync();
            return Ok(agenda);
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<IActionResult> GetByMonth(int ano, int mes)
        {
            var agenda = await _agendaService.GetByMonthAsync(ano, mes);
            return Ok(agenda);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AgendaCreateDto request)
        {
            var agenda = await _agendaService.CreateAsync(request);
            return CreatedAtAction(nameof(GetByMonth), new { ano = agenda.DataServico.Year, mes = agenda.DataServico.Month }, agenda);
        }
    }
}
