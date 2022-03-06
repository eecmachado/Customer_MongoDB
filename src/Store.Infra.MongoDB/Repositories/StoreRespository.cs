using AutoMapper;
using MongoDB.Driver;
using Store.Domain.DomainModel;
using Store.Domain.Enumerators;
using Store.Domain.Repositories;
using Store.Infra.MongoDB.DataModels;

namespace Store.Infra.MongoDB.Repositories;

public class StoreRespository : Repository, IStoreRespository
{
    private const string Entity = "store";

    public StoreRespository(IMongoDatabase database, IMapper mapper)
        : base(database, mapper)
    {
    }

    public async Task<StoreDomain> Post(StoreDomain model)
    {
        var data = Mapper.Map<StoreData>(model);
        var collection = GetCollection<StoreData>(Entity);
        await collection.InsertOneAsync(data);
        return Mapper.Map<StoreDomain>(data);
    }

    public async Task<StoreDomain> Update(string id, StoreDomain model)
    {
        var data = Mapper.Map<StoreData>(model);
        data.Id = id;
        var collection = GetCollection<StoreData>(Entity);
        await collection.ReplaceOneAsync(u => u.Id == id, data);
        return Mapper.Map<StoreDomain>(data);
    }

    public async Task<StoreDomain> UpdateType(string id, StoreType type)
    {
        var dataType = Mapper.Map<Enumerators.StoreType>(type);

        var atualizacao = Builders<StoreData>.Update.Set(c => c.Type, dataType);
        var collection = GetCollection<StoreData>(Entity);
        await collection.UpdateOneAsync(_ => _.Id == id, atualizacao);

        return await Get(id);
    }

    public async Task<bool> Delete(string id)
    {
        var collection = GetCollection<StoreData>(Entity);
        var result = await collection.DeleteOneAsync(_ => _.Id == id);
        return result.IsAcknowledged;
    }

    public async Task<IEnumerable<StoreDomain>> Get()
    {
        var collection = GetCollection<StoreData>(Entity);
        var datas = await collection.Find(_ => true).ToListAsync();
        return Mapper.Map<IEnumerable<StoreDomain>>(datas);
    }

    public async Task<StoreDomain> Get(string id)
    {
        var collection = GetCollection<StoreData>(Entity);
        var data = await collection.FindAsync(_ => _.Id == id);
        return Mapper.Map<StoreDomain>(data.SingleOrDefault());
    }

    public async Task<IEnumerable<StoreDomain>> Get(StoreType type)
    {
        var collection = GetCollection<StoreData>(Entity);
        var dataType = Mapper.Map<Enumerators.StoreType>(type);
        var data = await collection.Find(_ => _.Type == dataType).ToListAsync();
        return Mapper.Map<IEnumerable<StoreDomain>>(data);
    }
}