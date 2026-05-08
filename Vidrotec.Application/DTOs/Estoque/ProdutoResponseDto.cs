using System;

namespace Vidrotec.Application.DTOs.Estoque
{
    public sealed class ProdutoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public string StatusEstoque { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
    }
}
