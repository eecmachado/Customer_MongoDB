namespace Store.Domain.DomainModel;

public class StoreEvaluationDomain
{
    public StoreDomain? Store { get; set; }

    public IEnumerable<EvaluationDomain>? Evaluations { get; set; }
}