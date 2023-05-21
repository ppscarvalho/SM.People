using FluentValidation;

namespace SM.People.Core.Application.Commands.Supplier.Validation
{
    public class AddSupplierCommandValidation : AbstractValidator<AddSupplierCommand>
    {
        public AddSupplierCommandValidation()
        {
            RuleFor(c => c.CorporateName)
                .NotEmpty()
                .WithMessage("A Razão Social do fornecedor não foi informada.");

            RuleFor(c => c.FantasyName)
                .NotEmpty()
                .WithMessage("O Nome de Fantasia do fornecedor não foi informado.");
        }
    }
}
