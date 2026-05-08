using System;
using System.Collections.Generic;

namespace Vidrotec.Application.DTOs
{
    public sealed class ClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
    }

    public sealed class CreateClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
    }

    public sealed class UpdateClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
    }

    public sealed class ImportClienteCsvDto
    {
        public string CsvContent { get; set; } = string.Empty;
    }

    public sealed class ClienteImportResultDto
    {
        public int TotalClientes { get; set; }
        public int TotalOrcamentos { get; set; }
        public int TotalItens { get; set; }
    }
}
