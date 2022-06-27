using Elevator.Domain.Contracts;
using ElevatorSurveyResults.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace ElevatorSurveyResults
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = DependencyConfiguration.ConfigureService();

            ISurveyRunnerService getResults = serviceProvider.GetService<ISurveyRunnerService>();

            getResults.ExecuteSurvey();
        }
    }
}
