using System;
using FluentValidation;
using Vidrotec.Application.DTOs.Clientes;

namespace Vidrotec.Application.Validators
{
    public class CreateClienteDtoValidator : AbstractValidator<ClienteCreateDto>
    {
        public CreateClienteDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome do cliente é obrigatório.");
            RuleFor(x => x.Telefone).NotEmpty().WithMessage("Telefone do cliente é obrigatório.");
            RuleFor(x => x.Endereco).NotEmpty().WithMessage("Endereço do cliente é obrigatório.");
        }
    }

    public class UpdateClienteDtoValidator : AbstractValidator<ClienteUpdateDto>
    {
        public UpdateClienteDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome do cliente é obrigatório.");
            RuleFor(x => x.Telefone).NotEmpty().WithMessage("Telefone do cliente é obrigatório.");
            RuleFor(x => x.Endereco).NotEmpty().WithMessage("Endereço do cliente é obrigatório.");
        }
    }
}
