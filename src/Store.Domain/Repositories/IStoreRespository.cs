using Store.Domain.DomainModel;

namespace Store.Domain.Repositories;

public interface IStoreRespository
{
    Task<StoreDomain> Post(StoreDomain model);
    
    Task<IEnumerable<StoreDomain>> Get();
}