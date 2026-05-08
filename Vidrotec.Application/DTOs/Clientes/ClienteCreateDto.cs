namespace Vidrotec.Application.DTOs.Clientes
{
    public sealed class ClienteCreateDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
    }
}
