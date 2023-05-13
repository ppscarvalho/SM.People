using SM.People.Core.Application.Commands.Customer.Validation;
using SM.Resource.Messagens;

namespace SM.People.Core.Application.Commands.Customer
{
    public class AddCustomerCommand : CommandHandler
    {
        public Guid Id { get; set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? CellPhone { get; private set; }
        public DateTime? Birthday { get; private set; }
        public string? EmailAddress { get; set; }
        public string? PublicPlace { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? State { get; set; }

        public AddCustomerCommand(
            Guid id,
            string? firstName,
            string? lastName,
            string? cellPhone,
            DateTime? birthday,
            string? emailAddress,
            string? publicPlace,
            string? district,
            string? city,
            string? zipCode,
            string? state)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CellPhone = cellPhone;
            Birthday = birthday;
            EmailAddress = emailAddress;
            PublicPlace = publicPlace;
            District = district;
            City = city;
            ZipCode = zipCode;
            State = state;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
