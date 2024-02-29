using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpeedAir;
using SpeedAir.Interactor;
using SpeedAir.Interactor.Abstraction;
using SpeedAir.Model;
using SpeedAir.Model.Builders;
using SpeedAir.Model.Builders.Abstraction;
using SpeedAir.Model.Storages;
using SpeedAir.Model.Storages.Abstraction;
using SpeedAir.Presenter;
using SpeedAir.Presenter.Abstraction;
using SpeedAir.Service;
using SpeedAir.Service.Abstraction;
using SpeedAir.Service.Commands;
using SpeedAir.Service.Commands.Abstraction;

using var host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IFlightOrderInteractor, FlightOrderInteractor>();
            services.AddSingleton<IFlightsSchedulePresenter, FlightsSchedulePresenter>();
            
            // Services
            services.AddSingleton<IAvailablePlanesService, AvailablePlanesService>();
            services.AddSingleton<IFlightsScheduleService, FlightsScheduleService>();
            services.AddSingleton<IOrderService, OrderService>();
            
            // Builders
            services.AddSingleton<IPlanesBuilder, PlanesBuilder>();
            services.AddSingleton<IOrdersBuilder, OrdersBuilder>();
            services.AddSingleton<IScheduleBuilder, ScheduleBuilder>();
            
            // Storages
            services.AddSingleton<IOrdersStorageMutable, OrdersStorage>();
            services.AddSingleton<IPlanesStorageMutable, PlanesStorage>();
            services.AddSingleton<IScheduleStorageMutable, ScheduleStorage>();
            services.AddSingleton<IFulfilledOrdersStorage, FulfilledOrdersStorage>();
            
            // Commands
            services.AddSingleton<ILoadAvailablePlanesFromJsonCommand, LoadAvailablePlanesFromJsonCommand>();
            services.AddSingleton<ILoadOrdersCommand, LoadOrdersFromJsonCommand>();
            services.AddSingleton<ILoadScheduleFromJsonCommand, LoadScheduleFromJsonCommand>();
            
            services.AddSingleton<App>();
        })
        .ConfigureAppConfiguration(app =>
        {
            app.AddJsonFile("appsettings.json");
        });
}
 