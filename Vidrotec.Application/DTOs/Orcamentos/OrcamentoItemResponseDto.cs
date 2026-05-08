namespace Vidrotec.Application.DTOs.Orcamentos
{
    public sealed class OrcamentoItemResponseDto
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
}
