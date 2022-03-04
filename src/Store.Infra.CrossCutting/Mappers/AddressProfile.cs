using AutoMapper;
using Store.Domain.DomainModel;
using Store.Infra.MongoDB.DataModels;

namespace Store.Infra.CrossCutting.Mappers;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressDomain, AddressData>();
        CreateMap<AddressData, AddressDomain>();
    }
}