using FluentValidation;
using Vidrotec.Application.DTOs;

namespace Vidrotec.Application.Validators
{
    public class CreateOrcamentoDtoValidator : AbstractValidator<CreateOrcamentoDto>
    {
        public CreateOrcamentoDtoValidator()
        {
            RuleFor(x => x.NomeCliente).NotEmpty().WithMessage("Nome do cliente é obrigatório para orçamentos.");
            RuleFor(x => x.Desconto).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Itens).NotNull();
            RuleForEach(x => x.Itens).SetValidator(new CreateOrcamentoItemDtoValidator());
        }
    }

    public class CreateOrcamentoItemDtoValidator : AbstractValidator<CreateOrcamentoItemDto>
    {
        public CreateOrcamentoItemDtoValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("Descrição do item é obrigatória.");
            RuleFor(x => x.PrecoUnitario).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Quantidade).GreaterThan(0);
        }
    }
}
