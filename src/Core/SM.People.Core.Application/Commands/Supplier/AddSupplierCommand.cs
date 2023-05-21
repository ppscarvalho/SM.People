using SM.People.Core.Application.Commands.Supplier.Validation;
using SM.Resource.Messagens;

namespace SM.People.Core.Application.Commands.Supplier
{
    public class AddSupplierCommand : CommandHandler
    {
        public Guid? Id { get; private set; }
        public string? CorporateName { get; private set; }
        public string? FantasyName { get; private set; }
        public string? NRLE { get; private set; }
        public string? StateRegistration { get; private set; }
        public string? CellPhone { get; private set; }
        public string? EmailAddress { get; set; }
        public string? PublicPlace { get; private set; }
        public string? District { get; private set; }
        public string? City { get; private set; }
        public string? ZipCode { get; private set; }
        public string? State { get; private set; }

        public AddSupplierCommand() { }

        public AddSupplierCommand(Guid? id,
            string? corporateName,
            string? fantasyName,
            string? nrle,
            string? stateRegistration,
            string? cellPhone,
            string? emailAddress,
            string? publicPlace,
            string? district,
            string? city,
            string? zipCode,
            string? state)
        {
            Id = id;
            CorporateName = corporateName;
            FantasyName = fantasyName;
            NRLE = nrle;
            StateRegistration = stateRegistration;
            CellPhone = cellPhone;
            EmailAddress = emailAddress;
            PublicPlace = publicPlace;
            District = district;
            City = city;
            ZipCode = zipCode;
            State = state;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddSupplierCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
