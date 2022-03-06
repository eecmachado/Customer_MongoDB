using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Store.Infra.MongoDB.DataModels;

public class StoreEvaluationData
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string? Id { get; set; }
    
    public double AvgStars { get; set; }
    
    public IEnumerable<StoreData>? Stores { get; set; }

    public IEnumerable<EvaluationData>? Evaluations { get; set; }
}