using System;
using Vidrotec.Domain.Enums;

namespace Vidrotec.Domain.Entities
{
    public class MovimentacaoEstoque : EntityBase
    {
        public Guid ProdutoId { get; private set; }
        public MovimentacaoTipo Tipo { get; private set; }
        public int QuantidadeAnterior { get; private set; }
        public int QuantidadeNova { get; private set; }
        public decimal ValorAnterior { get; private set; }
        public decimal ValorNovo { get; private set; }
        public DateTime DataMovimentacao { get; private set; }

        public Produto? Produto { get; private set; }

        private MovimentacaoEstoque() { }

        public MovimentacaoEstoque(Guid produtoId, MovimentacaoTipo tipo, int quantidadeAnterior, int quantidadeNova, decimal valorAnterior, decimal valorNovo)
        {
            ProdutoId = produtoId;
            Tipo = tipo;
            QuantidadeAnterior = quantidadeAnterior;
            QuantidadeNova = quantidadeNova;
            ValorAnterior = valorAnterior;
            ValorNovo = valorNovo;
            DataMovimentacao = DateTime.UtcNow;
        }
    }
}
