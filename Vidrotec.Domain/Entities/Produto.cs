using System.Collections.Generic;
using Vidrotec.Domain.Enums;

namespace Vidrotec.Domain.Entities
{
    public class Produto : EntityBase
    {
        public string Nome { get; private set; } = string.Empty;
        public string Codigo { get; private set; } = string.Empty;
        public string Cor { get; private set; } = string.Empty;
        public int Quantidade { get; private set; }
        public int QuantidadeMinima { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public IReadOnlyCollection<MovimentacaoEstoque> Movimentacoes => _movimentacoes.AsReadOnly();
        private readonly List<MovimentacaoEstoque> _movimentacoes = new();

        public decimal ValorTotal => Quantidade * ValorUnitario;
        public StatusEstoque StatusEstoque
        {
            get
            {
                if (Quantidade <= QuantidadeMinima) return StatusEstoque.Baixo;
                if (Quantidade <= QuantidadeMinima * 2) return StatusEstoque.Medio;
                return StatusEstoque.Alto;
            }
        }

        private Produto() { }

        public Produto(string nome, string codigo, string cor, int quantidade, int quantidadeMinima, decimal valorUnitario)
        {
            Nome = nome;
            Codigo = codigo;
            Cor = cor;
            Quantidade = quantidade;
            QuantidadeMinima = quantidadeMinima;
            ValorUnitario = valorUnitario;
        }

        public void Update(string nome, string codigo, string cor, int quantidade, int quantidadeMinima, decimal valorUnitario)
        {
            Nome = nome;
            Codigo = codigo;
            Cor = cor;
            Quantidade = quantidade;
            QuantidadeMinima = quantidadeMinima;
            ValorUnitario = valorUnitario;
        }

        public void AddMovimentacao(MovimentacaoEstoque movimentacao)
        {
            _movimentacoes.Add(movimentacao);
        }
    }
}
