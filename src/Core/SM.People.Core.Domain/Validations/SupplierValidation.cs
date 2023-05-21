using FluentValidation;
using SM.People.Core.Domain.Entities;

namespace SM.People.Core.Domain.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O id do fornecedor não foi informado.");

            RuleFor(c => c.CorporateName)
                .NotEmpty()
                .WithMessage("A Razão Social do fornecedor não foi informada.");

            RuleFor(c => c.FantasyName)
                .NotEmpty()
                .WithMessage("O Nome de Fantasia do fornecedor não foi informado.");
        }
    }
}
