using Vidrotec.Domain.Exceptions;

namespace Vidrotec.Domain.ValueObjects
{
    public sealed class Endereco
    {
        public string Texto { get; }

        public Endereco(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new DomainException("Endereço é obrigatório.");

            Texto = texto.Trim();
        }

        public override string ToString() => Texto;
    }
}
