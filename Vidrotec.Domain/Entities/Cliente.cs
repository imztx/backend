using System.Collections.Generic;

namespace Vidrotec.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; private set; } = string.Empty;
        public string Telefone { get; private set; } = string.Empty;
        public string Endereco { get; private set; } = string.Empty;

        public IReadOnlyCollection<Orcamento> Orcamentos => _orcamentos.AsReadOnly();
        private readonly List<Orcamento> _orcamentos = new();

        private Cliente() { }

        public Cliente(string nome, string telefone, string endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
        }

        public void Update(string nome, string telefone, string endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
        }

        public void AddOrcamento(Orcamento orcamento)
        {
            orcamento.SetCliente(this);
            _orcamentos.Add(orcamento);
        }
    }
}
