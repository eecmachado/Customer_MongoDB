using Store.Domain.DomainModel;

namespace Store.Domain.Repositories;

public interface IStoreEvaluationRepository
{
    Task<StoreEvaluationDomain> GetStoreEvaluation(string storeId);
    
    Task<IEnumerable<StoreEvaluationDomain>> GetStoresEvaluation();
}