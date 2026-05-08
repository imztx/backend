namespace Vidrotec.Domain.Entities
{
    public class ProdutoOrcamento : EntityBase
    {
        public string Nome { get; private set; } = string.Empty;
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }

        private ProdutoOrcamento() { }

        public ProdutoOrcamento(string nome, decimal preco, bool ativo)
        {
            Nome = nome;
            Preco = preco;
            Ativo = ativo;
        }

        public void Update(string nome, decimal preco, bool ativo)
        {
            Nome = nome;
            Preco = preco;
            Ativo = ativo;
        }
    }
}
