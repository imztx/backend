using System;

namespace Vidrotec.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime DataCadastro { get; protected set; } = DateTime.UtcNow;
        public bool Excluido { get; protected set; }

        public void SetExcluido() => Excluido = true;
    }
}
