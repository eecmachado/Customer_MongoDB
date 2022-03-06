using Store.Domain.DomainModel;

namespace Store.Domain.Repositories;

public interface IEvaluationRespository
{
    Task<EvaluationDomain> Evaluate(string storeId, EvaluationDomain model);
}