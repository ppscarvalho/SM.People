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

            RuleFor(c => c.NRLE)
                .NotEmpty()
                .WithMessage("O CNPJ do fornecedor não foi informado.");

            RuleFor(c => c.CellPhone)
                .NotEmpty()
                .WithMessage("O Celular do fornecedor não foi informado.");

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
