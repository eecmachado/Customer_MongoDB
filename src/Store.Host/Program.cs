using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using Store.Infra.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

builder.Services.AddServices(builder.Configuration);

builder.Host.ConfigureContainer<ContainerBuilder>(hostBuilder =>
{
    hostBuilder.RegisterModule(new ApplicationModule());
    hostBuilder.RegisterModule(new InfraModule());
});

var app = builder.Build();

app.AddApplicationBuilder();

await app.RunAsync();