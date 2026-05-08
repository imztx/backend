using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vidrotec.Application.DTOs.Estoque;
using Vidrotec.Application.Services.Interfaces;

namespace Vidrotec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _produtoService.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("reposicao")]
        public async Task<IActionResult> GetReposicao()
        {
            var produtos = await _produtoService.GetReposicaoAsync();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoCreateDto request)
        {
            var produto = await _produtoService.CreateAsync(request);
            return CreatedAtAction(nameof(GetAll), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ProdutoUpdateDto request)
        {
            var produto = await _produtoService.UpdateAsync(id, request);
            return produto is null ? NotFound() : Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _produtoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
