using FluentValidation;

namespace SM.People.Core.Application.Commands.Customer.Validation
{
    public class UpdateCustomerCommandValidation : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O id do cliente não foi informado.");

            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("Primeiro nome do cliente não foi informada.");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("Sobrenome do cliente não foi informado.");
        }
    }
}
