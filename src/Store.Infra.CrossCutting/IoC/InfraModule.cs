using Autofac;
using Store.Infra.MongoDB.Repositories;

namespace Store.Infra.CrossCutting.IoC;

public class InfraModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterAssemblyTypes(typeof(Repository).Assembly)
            .Where(w => w.BaseType != null && w.BaseType.IsAssignableFrom(typeof(Repository)))
            .AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}