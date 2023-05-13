namespace SM.People.Core.Domain.ValueObjects
{
    public sealed class Address
    {
        public string? PublicPlace { get; private set; }
        public string? District { get; private set; }
        public string? City { get; private set; }
        public string? ZipCode { get; private set; }
        public string? State { get; private set; }

        public Address(string? publicPlace, string? district, string? city, string? zipCode, string? state)
        {
            PublicPlace = publicPlace;
            District = district;
            City = city;
            ZipCode = zipCode;
            State = state;
        }
    }
}
