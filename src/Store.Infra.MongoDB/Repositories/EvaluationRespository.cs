using AutoMapper;
using MongoDB.Driver;
using Store.Domain.DomainModel;
using Store.Domain.Repositories;
using Store.Infra.MongoDB.DataModels;

namespace Store.Infra.MongoDB.Repositories;

public class EvaluationRespository : Repository, IEvaluationRespository
{
    private const string Entity = "evaluation";

    public EvaluationRespository(IMongoDatabase database, IMapper mapper)
        : base(database, mapper)
    {
    }
    
    public async Task<EvaluationDomain> Evaluate(string storeId, EvaluationDomain model)
    {
        var data = Mapper.Map<EvaluationData>(model);
        data.StoreId = storeId;
        var collection = GetCollection<EvaluationData>(Entity);
        await collection.InsertOneAsync(data);
        return Mapper.Map<EvaluationDomain>(data);
    }
}