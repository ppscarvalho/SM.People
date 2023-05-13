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

            RuleFor(c => c.Birthday)
                .NotEmpty()
                .WithMessage("Data de aniversário do cliente não foi informado.");

            RuleFor(c => c.CellPhone)
                .NotEmpty()
                .WithMessage("O Celular do cliente não foi informado.");

            RuleFor(a => a.Address.PublicPlace)
                .NotEmpty()
                .WithMessage("O Logradouro do fornecedor não foi informado.");

            RuleFor(a => a.Address.District)
                .NotEmpty()
                .WithMessage("O Bairro do fornecedor não foi informado.");

            RuleFor(a => a.Address.District)
                .NotEmpty()
                .WithMessage("A Cidade do fornecedor não foi informada.");

            RuleFor(a => a.Address.ZipCode)
                .NotEmpty()
                .WithMessage("O CEP do fornecedor não foi informado.");

            RuleFor(a => a.Address.State)
                .NotEmpty()
                .WithMessage("O Estado do fornecedor não foi informado.");
        }
    }
}
