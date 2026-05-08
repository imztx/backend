using System.Collections.Generic;

namespace Vidrotec.Application.DTOs.Orcamentos
{
    public sealed class OrcamentoCreateDto
    {
        public string NomeCliente { get; set; } = string.Empty;
        public decimal Desconto { get; set; }
        public IEnumerable<OrcamentoItemCreateDto> Itens { get; set; } = new List<OrcamentoItemCreateDto>();
    }
}
