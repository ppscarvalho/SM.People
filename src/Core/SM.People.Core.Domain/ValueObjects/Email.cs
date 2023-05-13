namespace SM.People.Core.Domain.ValueObjects
{
    public class Email
    {
        public string? EmailAddress { get; set; }

        public Email(string? emailAddress)
        {
            EmailAddress = emailAddress;
        }

    }
}
