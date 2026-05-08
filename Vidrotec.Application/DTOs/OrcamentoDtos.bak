using System;
using System.Collections.Generic;

namespace Vidrotec.Application.DTOs
{
    public sealed class OrcamentoDto
    {
        public Guid Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorFinal { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<OrcamentoItemDto> Itens { get; set; } = Array.Empty<OrcamentoItemDto>();
    }

    public sealed class CreateOrcamentoDto
    {
        public string NomeCliente { get; set; } = string.Empty;
        public decimal Desconto { get; set; }
        public IEnumerable<CreateOrcamentoItemDto> Itens { get; set; } = Array.Empty<CreateOrcamentoItemDto>();
    }

    public sealed class OrcamentoItemDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Largura { get; set; }
        public decimal Altura { get; set; }
        public int Quantidade { get; set; }
        public string TipoVidro { get; set; } = string.Empty;
        public int NumeroFolhas { get; set; }
        public string Abertura { get; set; } = string.Empty;
        public string Fechadura { get; set; } = string.Empty;
        public string Mola { get; set; } = string.Empty;
    }

    public sealed class CreateOrcamentoItemDto
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal Largura { get; set; }
        public decimal Altura { get; set; }
        public string TipoVidro { get; set; } = string.Empty;
        public int NumeroFolhas { get; set; }
        public string Abertura { get; set; } = string.Empty;
        public string Fechadura { get; set; } = string.Empty;
        public string Mola { get; set; } = string.Empty;
    }
}
