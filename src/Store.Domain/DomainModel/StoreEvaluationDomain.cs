namespace Store.Domain.DomainModel;

public class StoreEvaluationDomain
{
    public double AvgStars { get; set; }

    public StoreDomain? Store { get; set; }

    public IEnumerable<EvaluationDomain>? Evaluations { get; set; }
}