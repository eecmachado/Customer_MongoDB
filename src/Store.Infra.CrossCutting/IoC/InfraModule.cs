using Autofac;
using Store.Infra.MongoDB.Repositories;

namespace Store.Infra.CrossCutting.IoC;

public class InfraModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
            .Where(w => w.BaseType is {IsGenericType: true} && 
                        w.BaseType.GetGenericTypeDefinition().IsAssignableFrom(typeof(BaseRepository<>)))
            .AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}