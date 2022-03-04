using Store.Infra.Data.DataModels;
using Store.Infra.Data.Enumerators;

namespace Store.Infra.Data.Entities;

public class StoreEntity
{
    public StoreEntity(string id, string name, StoreType type, AddressData address)
    {
        Id = id;
        Name = name;
        Type = type;
        Address = address;
    }

    public string Id { get; }

    public string Name { get; }

    public StoreType Type { get; }

    public AddressData Address { get; }
}