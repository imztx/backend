using System;

namespace Vidrotec.Application.DTOs.Clientes
{
    public sealed class ClienteResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
    }
}
