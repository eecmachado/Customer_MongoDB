using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Store.Host.Configurations;
using Store.Infra.MongoDB.Maps;

namespace Microsoft.Extensions.DependencyInjection;

public static class MongoServiceExtensions
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services,
        IConfiguration configuration)
    {
        MapConfigure.Configure();
        
        var mongoDbConfiguration = configuration.GetSection(MongoDBConfiguration.MongoDB)
            .Get<MongoDBConfiguration>();
        
        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoDbConfiguration.ConnectionString));

        services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(mongoDbConfiguration.Database);
        });
        
        services.AddScoped(c => c.GetService<IMongoClient>()?.StartSession());

        return services;
    }
}