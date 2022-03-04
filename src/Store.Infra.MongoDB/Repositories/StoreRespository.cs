using AutoMapper;
using MongoDB.Driver;
using Store.Domain.DomainModel;
using Store.Domain.Enumerators;
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

    public async Task<StoreDomain> Update(string id, StoreDomain model)
    {
        var data = Mapper.Map<StoreData>(model);
        data.Id = id;
        await Collection.ReplaceOneAsync(u => u.Id == id, data);
        return Mapper.Map<StoreDomain>(data);
    }

    public async Task<StoreDomain> UpdateType(string id, StoreType type)
    {
        var dataType = Mapper.Map<Enumerators.StoreType>(type);

        var atualizacao = Builders<StoreData>.Update.Set(c => c.Type, dataType);

        await Collection.UpdateOneAsync(_ => _.Id == id, atualizacao);

        return await Get(id);
    }

    public async Task<bool> Delete(string id)
    {
        var result = await Collection.DeleteOneAsync(_ => _.Id == id);
        return result.IsAcknowledged;
    }

    public async Task<IEnumerable<StoreDomain>> Get()
    {
        var datas = await Collection.Find(_ => true).ToListAsync();
        return Mapper.Map<IEnumerable<StoreDomain>>(datas);
    }

    public async Task<StoreDomain> Get(string id)
    {
        var data = await Collection.FindAsync(_ => _.Id == id);
        return Mapper.Map<StoreDomain>(data.SingleOrDefault());
    }

    public async Task<IEnumerable<StoreDomain>> Get(StoreType type)
    {
        var dataType = Mapper.Map<Enumerators.StoreType>(type);
        var data = await Collection.Find(_ => _.Type == dataType).ToListAsync();
        return Mapper.Map<IEnumerable<StoreDomain>>(data);
    }
}