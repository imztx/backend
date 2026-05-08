using System;
using FluentValidation;
using Vidrotec.Application.DTOs.Estoque;

namespace Vidrotec.Application.Validators
{
    public class CreateProdutoDtoValidator : AbstractValidator<ProdutoCreateDto>
    {
        public CreateProdutoDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome do produto é obrigatório.");
            RuleFor(x => x.Codigo).NotEmpty().WithMessage("Código do produto é obrigatório.");
            RuleFor(x => x.Quantidade).GreaterThanOrEqualTo(0);
            RuleFor(x => x.QuantidadeMinima).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ValorUnitario).GreaterThanOrEqualTo(0);
        }
    }

    public class UpdateProdutoDtoValidator : AbstractValidator<ProdutoUpdateDto>
    {
        public UpdateProdutoDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome do produto é obrigatório.");
            RuleFor(x => x.Codigo).NotEmpty().WithMessage("Código do produto é obrigatório.");
            RuleFor(x => x.Quantidade).GreaterThanOrEqualTo(0);
            RuleFor(x => x.QuantidadeMinima).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ValorUnitario).GreaterThanOrEqualTo(0);
        }
    }
}
