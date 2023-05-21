using FluentValidation;

namespace SM.People.Core.Application.Commands.Supplier.Validation
{
    public class UpdateSupplierCommandValidation : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierCommandValidation()
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
