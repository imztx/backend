using System;
using Vidrotec.Domain.Enums;

namespace Vidrotec.Domain.Entities
{
    public class AgendaServico : EntityBase
    {
        public DateTime DataServico { get; private set; }
        public Turno Turno { get; private set; }
        public string Cliente { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public string Endereco { get; private set; } = string.Empty;
        public string Responsavel { get; private set; } = string.Empty;
        public AgendaStatus Status { get; private set; }

        private AgendaServico() { }

        public AgendaServico(DateTime dataServico, Turno turno, string cliente, string descricao, string endereco, string responsavel, AgendaStatus status)
        {
            DataServico = dataServico;
            Turno = turno;
            Cliente = cliente;
            Descricao = descricao;
            Endereco = endereco;
            Responsavel = responsavel;
            Status = status;
        }

        public void Update(DateTime dataServico, Turno turno, string cliente, string descricao, string endereco, string responsavel, AgendaStatus status)
        {
            DataServico = dataServico;
            Turno = turno;
            Cliente = cliente;
            Descricao = descricao;
            Endereco = endereco;
            Responsavel = responsavel;
            Status = status;
        }
    }
}
