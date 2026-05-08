using System.Collections.Generic;

namespace Vidrotec.Domain.Entities
{
    public class Orcamento : EntityBase
    {
        public Guid? ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }
        public string NomeCliente { get; private set; } = string.Empty;
        public decimal Subtotal { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorFinal { get; private set; }

        public IReadOnlyCollection<OrcamentoItem> Itens => _itens.AsReadOnly();
        private readonly List<OrcamentoItem> _itens = new();

        private Orcamento() { }

        public Orcamento(string nomeCliente, decimal desconto)
        {
            NomeCliente = nomeCliente;
            Desconto = desconto;
            Subtotal = 0;
            ValorFinal = 0;
        }

        internal void SetCliente(Cliente cliente)
        {
            Cliente = cliente;
            ClienteId = cliente.Id;
        }

        public void AddItem(OrcamentoItem item)
        {
            _itens.Add(item);
            Recalculate();
        }

        public void RemoveItem(OrcamentoItem item)
        {
            _itens.Remove(item);
            Recalculate();
        }

        public void Recalculate()
        {
            Subtotal = 0;
            foreach (var item in _itens)
            {
                Subtotal += item.ValorTotal;
            }
            ValorFinal = Subtotal - Desconto;
        }
    }
}
