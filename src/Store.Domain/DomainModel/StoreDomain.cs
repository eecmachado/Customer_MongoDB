using Store.Domain.Enumerators;

namespace Store.Domain.DomainModel;

public class StoreDomain
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public StoreType Type { get; set; }

    public AddressDomain? Address { get; set; }
}