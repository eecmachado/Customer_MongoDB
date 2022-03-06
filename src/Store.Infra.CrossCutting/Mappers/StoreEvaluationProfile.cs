using AutoMapper;
using Store.Domain.DomainModel;
using Store.Infra.MongoDB.DataModels;

namespace Store.Infra.CrossCutting.Mappers;

public class StoreEvaluationProfile : Profile
{
    public StoreEvaluationProfile()
    {
        CreateMap<StoreData, StoreEvaluationDomain>()
            .ForPath(d => d.Store, opt => opt.MapFrom(src => src));

        CreateMap<StoreEvaluationData, StoreEvaluationDomain>()
            .ForPath(d => d.Store, opt => opt.MapFrom(src => src.Stores.FirstOrDefault()));

    }
}