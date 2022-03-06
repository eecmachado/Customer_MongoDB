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

                storeEvaluationDomain.Evaluations = Mapper.Map<IEnumerable<EvaluationDomain>>(evaluationsDatas);

                storesEvaluationDomain.Add(storeEvaluationDomain);
            });

        return storesEvaluationDomain;
    }
}