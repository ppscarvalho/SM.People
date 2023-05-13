using SM.People.Core.Domain.Validations;
using SM.People.Core.Domain.ValueObjects;
using SM.Resource.Domain;
using SM.Resource.Interfaces;

namespace SM.People.Core.Domain.Entities
{
    public sealed class Supplier : Entity, IAggregateRoot
    {
        public string? CorporateName { get; private set; }
        public string? FantasyName { get; private set; }
        /// <summary>
        /// National Registry of Legal Entities >> Cadastro Nacional de Pessoa Jurídica
        /// NRLE >> CNPJ
        /// </summary>
        public string? NRLE { get; private set; }
        public string? StateRegistration { get; private set; }
        public string? CellPhone { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public Supplier() { }

        public Supplier(
            string? corporateName,
            string? fantasyName,
            string? nrle,
            string? stateRegistration,
            string? cellPhone,
            Email email,
            Address address) : this()
        {
            CorporateName = corporateName;
            FantasyName = fantasyName;
            NRLE = nrle;
            StateRegistration = stateRegistration;
            CellPhone = cellPhone;
            Address = address;
            Email = email;
        }

        public override bool IsValid()
        {
            ValidationResult = new SupplierValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
