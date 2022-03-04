using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Store.Infra.MongoDB.Enumerators;
using Store.Infra.MongoDB.DataModels;

namespace Store.Infra.MongoDB.Maps;

public class StoreMap
{
    public static void Confgure()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(StoreData)))
        {
            BsonClassMap.RegisterClassMap<StoreData>(i =>
            {
                i.AutoMap();
                i.MapIdMember(c => c.Id);
                i.MapMember(c => c.Type).SetSerializer(new EnumSerializer<StoreType>(BsonType.Int32));
                i.SetIgnoreExtraElements(true);
            });
        }
    }
}