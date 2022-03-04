namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddCorrelationId(configuration);
        services.AddEndpointsApiExplorer();
        services.AddAutoMapperService();
        services.AddSwaggerGen();
        services.AddMongoDb(configuration);
        
        return services;
    }
}