using SM.People.Core.Domain.Validations;
using SM.People.Core.Domain.ValueObjects;
using SM.Resource.Domain;
using SM.Resource.Interfaces;

namespace SM.People.Core.Domain.Entities
{
    public sealed class Customer : Entity, IAggregateRoot
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? CellPhone { get; private set; }
        public DateTime? Birthday { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public Customer() { }

        public Customer(
            string? firstName,
            string? lastName,
            string? cellPhone,
            DateTime? birthday,
            Email email,
            Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            CellPhone = cellPhone;
            Birthday = birthday;
            Email = email;
            Address = address;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
