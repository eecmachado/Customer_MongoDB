using AutoMapper;
using MongoDB.Driver;
using Store.Domain.DomainModel;
using Store.Domain.Repositories;
using Store.Infra.MongoDB.DataModels;

namespace Store.Infra.MongoDB.Repositories;

public class StoreRespository : BaseRepository<StoreData>, IStoreRespository
{
    private const string Entity = "store";

    public StoreRespository(IMongoDatabase database, IMapper mapper)
        : base(database, mapper, Entity)
    {
    }
    
    public async Task<StoreDomain> Post(StoreDomain model)
    {
        var data = Mapper.Map<StoreData>(model);
        await Collection.InsertOneAsync(data);
        return Mapper.Map<StoreDomain>(data);
    }

    public async Task<IEnumerable<StoreDomain>> Get()
    {
        var datas = await Collection.Find(_ => true).ToListAsync();
        return Mapper.Map<IEnumerable<StoreDomain>>(datas);
    }
}