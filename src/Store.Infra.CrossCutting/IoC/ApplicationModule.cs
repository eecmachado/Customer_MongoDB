using Autofac;
using Store.Application.Interfaces;

namespace Store.Infra.CrossCutting.IoC;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterAssemblyTypes(typeof(IStoreUseCase).Assembly)
            .AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}