namespace Vidrotec.Domain.Entities
{
    public class OrcamentoItem : EntityBase
    {
        public Guid OrcamentoId { get; private set; }
        public string Descricao { get; private set; } = string.Empty;
        public decimal PrecoUnitario { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Altura { get; private set; }
        public int Quantidade { get; private set; }
        public string TipoVidro { get; private set; } = string.Empty;
        public int NumeroFolhas { get; private set; }
        public string Abertura { get; private set; } = string.Empty;
        public string Fechadura { get; private set; } = string.Empty;
        public string Mola { get; private set; } = string.Empty;

        public Orcamento? Orcamento { get; private set; }

        private OrcamentoItem() { }

        public OrcamentoItem(Guid orcamentoId, string descricao, decimal precoUnitario, int quantidade, decimal largura, decimal altura, string tipoVidro, int numeroFolhas, string abertura, string fechadura, string mola)
        {
            OrcamentoId = orcamentoId;
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
            Quantidade = quantidade;
            Largura = largura;
            Altura = altura;
            TipoVidro = tipoVidro;
            NumeroFolhas = numeroFolhas;
            Abertura = abertura;
            Fechadura = fechadura;
            Mola = mola;
            ValorTotal = precoUnitario * quantidade;
        }
    }
}
