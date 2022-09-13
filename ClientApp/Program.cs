using AreaCalculator;
using ClientApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {
        services.AddHostedService<Worker>();
        services.AddSingleton<IShapeCreator>(new ShapeCreator());
        services.AddSingleton<IAreaCalculator>(new AreaCalculator.AreaCalculator());
    })
    .Build();

await host.RunAsync();
await host.StopAsync();