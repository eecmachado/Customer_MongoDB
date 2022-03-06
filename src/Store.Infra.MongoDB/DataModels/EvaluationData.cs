using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Store.Infra.MongoDB.DataModels;

public class EvaluationData
{
    public ObjectId Id { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string? StoreId { get; set; }

    public int Stars { get; set; }

    public string? Commentary { get; set; }
}