using System;

namespace Vidrotec.Application.DTOs.Agenda
{
    public sealed class AgendaCreateDto
    {
        public DateTime DataServico { get; set; }
        public string Turno { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Responsavel { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
