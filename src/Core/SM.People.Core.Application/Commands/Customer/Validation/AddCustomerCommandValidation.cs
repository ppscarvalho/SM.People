using FluentValidation;

namespace SM.People.Core.Application.Commands.Customer.Validation
{
    public class AddCustomerCommandValidation : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidation()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("Primeiro nome do cliente não foi informada.");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("Sobrenome do cliente não foi informado.");
        }
    }
}
