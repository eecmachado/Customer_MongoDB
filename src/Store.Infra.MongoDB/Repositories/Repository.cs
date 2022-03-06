using AutoMapper;
using MongoDB.Driver;

namespace Store.Infra.MongoDB.Repositories;

public abstract class Repository
{
    private readonly IMongoDatabase _mongoDatabase;
    
    protected Repository(IMongoDatabase mongoDatabase, IMapper mapper)
    {
        _mongoDatabase = mongoDatabase;
        Mapper = mapper;
    }

    protected IMongoCollection<TDataModel> GetCollection<TDataModel>(string entity)
        where TDataModel : class
    {
        return _mongoDatabase.GetCollection<TDataModel>(entity);
    }
    protected IMapper Mapper { get; }
}