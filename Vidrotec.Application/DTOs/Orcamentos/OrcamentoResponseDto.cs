using System;
using System.Collections.Generic;

namespace Vidrotec.Application.DTOs.Orcamentos
{
    public sealed class OrcamentoResponseDto
    {
        public Guid Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorFinal { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<OrcamentoItemResponseDto> Itens { get; set; } = Array.Empty<OrcamentoItemResponseDto>();
    }
}
