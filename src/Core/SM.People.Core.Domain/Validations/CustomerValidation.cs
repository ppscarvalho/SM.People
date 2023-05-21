using FluentValidation;
using SM.People.Core.Domain.Entities;

namespace SM.People.Core.Domain.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
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
