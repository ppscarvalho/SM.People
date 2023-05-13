namespace SM.People.Core.Application.Models
{
    public class SupplierModel
    {
        public Guid Id { get; set; }
        public string? CorporateName { get; set; }
        public string? FantasyName { get; set; }
        public string? NRLE { get; set; }
        public string? StateRegistration { get; set; }
        public string? CellPhone { get; set; }
        public string? EmailAddress { get; set; }
        public string? PublicPlace { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? State { get; set; }

        public SupplierModel(Guid id, string? corporateName, string? fantasyName, string? nRLE, string? stateRegistration, string? cellPhone, string? emailAddress, string? publicPlace, string? district, string? city, string? zipCode, string? state)
        {
            Id = id;
            CorporateName = corporateName;
            FantasyName = fantasyName;
            NRLE = nRLE;
            StateRegistration = stateRegistration;
            CellPhone = cellPhone;
            EmailAddress = emailAddress;
            PublicPlace = publicPlace;
            District = district;
            City = city;
            ZipCode = zipCode;
            State = state;
        }

    }
}
