namespace Store.Domain.DomainModel;

public class AddressDomain
{
    public AddressDomain(string street, string number, string city, string state, string zipCode)
    {
        Street = street;
        Number = number;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
    
    public string Street { get; }

    public string Number { get; }

    public string City { get; }

    public string State { get; }

    public string ZipCode { get; }
}