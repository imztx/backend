using FluentValidation;
using Vidrotec.Application.DTOs;

namespace Vidrotec.Application.Validators
{
    public class CreateProdutoDtoValidator : AbstractValidator<CreateProdutoDto>
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

    public class UpdateProdutoDtoValidator : AbstractValidator<UpdateProdutoDto>
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
