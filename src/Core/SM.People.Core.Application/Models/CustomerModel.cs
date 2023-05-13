namespace SM.People.Core.Application.Models
{
    public class CustomerModel
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

        public CustomerModel(
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
    }
}
