using FluentValidation;
using Vidrotec.Application.DTOs;

namespace Vidrotec.Application.Validators
{
    public class CreateAgendaServicoDtoValidator : AbstractValidator<CreateAgendaServicoDto>
    {
        public CreateAgendaServicoDtoValidator()
        {
            RuleFor(x => x.DataServico).GreaterThan(DateTime.MinValue);
            RuleFor(x => x.Turno).NotEmpty();
            RuleFor(x => x.Cliente).NotEmpty();
            RuleFor(x => x.Descricao).NotEmpty();
            RuleFor(x => x.Endereco).NotEmpty();
            RuleFor(x => x.Responsavel).NotEmpty();
        }
    }
}
