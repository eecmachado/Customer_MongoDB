using MongoDB.Bson;
using Store.Infra.MongoDB.Enumerators;

namespace Store.Infra.MongoDB.DataModels;

public class StoreData
{
    public ObjectId Id { get; set; }

    public string? Name { get; set; }

    public StoreType Type { get; set; }

    public AddressData? Address { get; set; }
}