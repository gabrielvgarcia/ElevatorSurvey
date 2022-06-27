using Elevator.Domain.Contracts;
using Elevator.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ElevatorSurveyResults.Ioc
{
    public static class DependencyConfiguration
    {
        public static ServiceProvider ConfigureService()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
            .AddScoped<IElevatorService, ElevatorService>()
            .AddScoped<IJsonReaderService, JsonReaderService>()
            .AddScoped<ISurveyRunnerService, SurveyRunnerService>()
            .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
