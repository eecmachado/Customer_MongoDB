using AutoMapper;
using Store.Domain.DomainModel;
using Store.Infra.MongoDB.DataModels;

namespace Store.Infra.CrossCutting.Mappers;

public class EvaluationProfile : Profile
{
    public EvaluationProfile()
    {
        CreateMap<EvaluationDomain, EvaluationData>();
        CreateMap<EvaluationData, EvaluationDomain>();
    }
}