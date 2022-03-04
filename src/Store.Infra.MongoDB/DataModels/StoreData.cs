using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Store.Infra.MongoDB.Enumerators;

namespace Store.Infra.MongoDB.DataModels;

public class StoreData
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string? Name { get; set; }

    public StoreType Type { get; set; }

    public AddressData? Address { get; set; }
}