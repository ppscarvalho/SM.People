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

            RuleFor(c => c.NRLE)
                .NotEmpty()
                .WithMessage("O CNPJ do fornecedor não foi informado.");

            RuleFor(c => c.CellPhone)
                .NotEmpty()
                .WithMessage("O Celular do fornecedor não foi informado.");

            RuleFor(a => a.PublicPlace)
                .NotEmpty()
                .WithMessage("O Logradouro do fornecedor não foi informado.");

            RuleFor(a => a.District)
                .NotEmpty()
                .WithMessage("O Bairro do fornecedor não foi informado.");

            RuleFor(a => a.District)
                .NotEmpty()
                .WithMessage("A Cidade do fornecedor não foi informada.");

            RuleFor(a => a.ZipCode)
                .NotEmpty()
                .WithMessage("O CEP do fornecedor não foi informado.");

            RuleFor(a => a.State)
                .NotEmpty()
                .WithMessage("O Estado do fornecedor não foi informado.");
        }
    }
}
