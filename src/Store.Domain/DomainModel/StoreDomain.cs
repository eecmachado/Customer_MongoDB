using Store.Domain.Enumerators;

namespace Store.Domain.DomainModel;

public class StoreDomain
{
    public StoreDomain(string id, string name, StoreType type, AddressDomain address)
    {
        Id = id;
        Name = name;
        Type = type;
        Address = address;
    }

    public string Id { get; }

    public string Name { get; }

    public StoreType Type { get; }

    public AddressDomain Address { get; }
}