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

            RuleFor(c => c.Birthday)
                .NotEmpty()
                .WithMessage("Data de aniversário do cliente não foi informado.");

            RuleFor(c => c.CellPhone)
                .NotEmpty()
                .WithMessage("O Celular do cliente não foi informado.");

            RuleFor(a => a.PublicPlace)
                .NotEmpty()
                .WithMessage("O Logradouro do cliente não foi informado.");

            RuleFor(a => a.District)
                .NotEmpty()
                .WithMessage("O Bairro do cliente não foi informado.");

            RuleFor(a => a.District)
                .NotEmpty()
                .WithMessage("A Cidade do cliente não foi informada.");

            RuleFor(a => a.ZipCode)
                .NotEmpty()
                .WithMessage("O CEP do cliente não foi informado.");

            RuleFor(a => a.State)
                .NotEmpty()
                .WithMessage("O Estado do cliente não foi informado.")
                .MaximumLength(2)
                .WithMessage("Informe somente a sigla do Estado.");
        }
    }
}
