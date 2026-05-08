using FluentValidation;
using Vidrotec.Application.DTOs;

namespace Vidrotec.Application.Validators
{
    public class CreateClienteDtoValidator : AbstractValidator<CreateClienteDto>
    {
        public CreateClienteDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome do cliente é obrigatório.");
            RuleFor(x => x.Telefone).NotEmpty().WithMessage("Telefone do cliente é obrigatório.");
            RuleFor(x => x.Endereco).NotEmpty().WithMessage("Endereço do cliente é obrigatório.");
        }
    }

    public class UpdateClienteDtoValidator : AbstractValidator<UpdateClienteDto>
    {
        public UpdateClienteDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome do cliente é obrigatório.");
            RuleFor(x => x.Telefone).NotEmpty().WithMessage("Telefone do cliente é obrigatório.");
            RuleFor(x => x.Endereco).NotEmpty().WithMessage("Endereço do cliente é obrigatório.");
        }
    }
}
