namespace Vidrotec.Application.DTOs.Orcamentos
{
    public sealed class ProdutoOrcamentoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
