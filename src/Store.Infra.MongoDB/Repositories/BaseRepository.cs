using AutoMapper;
using MongoDB.Driver;

namespace Store.Infra.MongoDB.Repositories;

public abstract class BaseRepository<TDataModel>
    where TDataModel : class
{
    protected BaseRepository(IMongoDatabase database, IMapper mapper, string collection)
    {
        Collection = database.GetCollection<TDataModel>(collection);
        Mapper = mapper;
    }

    protected IMongoCollection<TDataModel> Collection { get; }

    protected IMapper Mapper { get; }
}