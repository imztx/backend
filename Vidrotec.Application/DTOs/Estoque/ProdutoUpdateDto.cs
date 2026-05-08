namespace Vidrotec.Application.DTOs.Estoque
{
    public sealed class ProdutoUpdateDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
