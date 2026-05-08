using Vidrotec.Domain.Exceptions;

namespace Vidrotec.Domain.ValueObjects
{
    public sealed class Telefone
    {
        public string Numero { get; }

        public Telefone(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new DomainException("Telefone é obrigatório.");

            Numero = numero.Trim();
        }

        public override string ToString() => Numero;
    }
}
