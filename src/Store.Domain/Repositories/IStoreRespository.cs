using Store.Domain.DomainModel;
using Store.Domain.Enumerators;

namespace Store.Domain.Repositories;

public interface IStoreRespository
{
    Task<StoreDomain> Post(StoreDomain model);

    Task<StoreDomain> Update(string id, StoreDomain model);

    Task<StoreDomain> UpdateType(string id, StoreType type);

    Task<bool> Delete(string id);

    Task<IEnumerable<StoreDomain>> Get();

    Task<StoreDomain> Get(string id);

    Task<IEnumerable<StoreDomain>> Get(StoreType type);
}