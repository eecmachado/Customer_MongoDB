﻿using AutoMapper;
using Store.Domain.DomainModel;
using Store.Infra.MongoDB.DataModels;

namespace Store.Infra.CrossCutting.Mappers;

public class StoreProfile: Profile
{
    public StoreProfile()
    {
        CreateMap<StoreDomain, StoreData>();
        CreateMap<StoreData, StoreDomain>();
    }
}