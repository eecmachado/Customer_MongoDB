using AutoMapper;
using MongoDB.Driver;
using Store.Domain.DomainModel;
using Store.Domain.Repositories;
using Store.Infra.MongoDB.DataModels;

namespace Store.Infra.MongoDB.Repositories;

public class StoreEvaluationRepository : Repository, IStoreEvaluationRepository
{
    private const string EvaluationEntity = "evaluation";
    private const string StoreEntity = "store";
    private readonly IMongoCollection<StoreData> _collectionStore;
    private readonly IMongoCollection<EvaluationData> _collectionEvaluation;

    public StoreEvaluationRepository(IMongoDatabase mongoDatabase, IMapper mapper)
        : base(mongoDatabase, mapper)
    {
        _collectionStore = GetCollection<StoreData>(StoreEntity);
        _collectionEvaluation = GetCollection<EvaluationData>(EvaluationEntity);
    }

    public async Task<StoreEvaluationDomain> GetStoreEvaluation(string storeId)
    {
        var storeData = await _collectionStore
            .Find(_ => _.Id == storeId)
            .SingleOrDefaultAsync();

        if (storeData == null)
            return Mapper.Map<StoreEvaluationDomain>(storeData);

        var storeEvaluationDomain = Mapper.Map<StoreEvaluationDomain>(storeData);

        var evaluationsDatas = await _collectionEvaluation
            .Find(_ => _.StoreId == storeId)
            .ToListAsync();

        storeEvaluationDomain.AvgStars = evaluationsDatas
            .Average(a => a.Stars);

        storeEvaluationDomain.Evaluations = Mapper.Map<IEnumerable<EvaluationDomain>>(evaluationsDatas);

        return storeEvaluationDomain;
    }

    public async Task<IEnumerable<StoreEvaluationDomain>> GetStoresEvaluation()
    {
        var storesEvaluationDomain = new List<StoreEvaluationDomain>();

        await _collectionStore.AsQueryable()
            .ForEachAsync(async storeData =>
            {
                var storeEvaluationDomain = Mapper.Map<StoreEvaluationDomain>(storeData);

                var evaluationsDatas = await _collectionEvaluation
                    .Find(_ => _.StoreId == storeData.Id)
                    .ToListAsync();
                
                storeEvaluationDomain.AvgStars = evaluationsDatas
                    .Average(a => a.Stars);
                
                storeEvaluationDomain.Evaluations = Mapper.Map<IEnumerable<EvaluationDomain>>(evaluationsDatas);

                storesEvaluationDomain.Add(storeEvaluationDomain);
            });

        return storesEvaluationDomain;
    }

    public async Task<IEnumerable<StoreEvaluationDomain>> GetBestEvaluatedPlace(int placeQuality)
    {
        // bestPlaces Linq
        var bestPlaces = _collectionEvaluation.AsQueryable()
            .GroupBy(k => k.StoreId)
            .Select(s =>
                new StoreEvaluationData
                {
                    Id = s.Key,
                    AvgStars = s.Average(a => a.Stars)
                })
            .OrderByDescending(o => o.AvgStars)
            .Take(placeQuality)
            .GroupJoin(_collectionStore.AsQueryable(), p => p.Id, s => s.Id,
                (p, stores) => new StoreEvaluationData
                {
                    Id = p.Id,
                    AvgStars = p.AvgStars,
                    Stores = stores
                })
            .GroupJoin(_collectionEvaluation.AsQueryable(), x => x.Id, s => s.StoreId,
                (x, evaluations) => new StoreEvaluationData
                {
                    Id = x.Id,
                    AvgStars = x.AvgStars,
                    Stores = x.Stores,
                    Evaluations = evaluations
                })
            .ToList();
        
        var storesEvaluationDomain = bestPlaces
            .Select(s => Mapper.Map<StoreEvaluationDomain>(s)).ToList();

        return await Task.FromResult(storesEvaluationDomain);

        // // lookup aggregate
        // var bestPlaces = _collectionEvaluation.Aggregate()
        //     .Group(_ => _.StoreId,
        //         g => new
        //         {
        //             StoreId = g.Key,
        //             AvgStars = g.Average(a => a.Stars)
        //         })
        //     .SortByDescending(s => s.AvgStars)
        //     .Limit(placeQuality)
        //     .Lookup<StoreData, StoreEvaluationData>("store", "StoreId", "Id", "Stores")
        //     .Lookup<EvaluationData, StoreEvaluationData>("evaluation", "Id", "StoreId", "Evaluations");

        //var storesEvaluationDomain = new List<StoreEvaluationDomain>();

        //await bestPlaces.ForEachAsync(f => { storesEvaluationDomain.Add(Mapper.Map<StoreEvaluationDomain>(f)); });

        //return storesEvaluationDomain;
    }
}