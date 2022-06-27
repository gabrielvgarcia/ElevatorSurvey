using Elevator.Domain.Contracts;
using Elevator.Domain.Enums;
using Elevator.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator.Domain.Services
{
    public class SurveyRunnerService : ISurveyRunnerService
    {
        private readonly IElevatorService ElevatorService;
        public SurveyRunnerService(IElevatorService elevatorService)
        {
            ElevatorService = elevatorService;
        }
        public void ExecuteSurvey()
        {
            List<int> lessUsedFloors = ElevatorService.andarMenosUtilizado();

            Console.WriteLine("Least used floors (highest to lowest): ");

            lessUsedFloors.ForEach(lUF => Console.WriteLine("- " + lUF));

            Console.WriteLine("\n---------------------------------------");

            List<char> responseElevators = ElevatorService.elevadorMaisFrequentado();

            Console.WriteLine("Most used elevator (highest to lowest): ");

            responseElevators.ForEach(rE => Console.WriteLine("- " + rE));

            Console.WriteLine("\n---------------------------------------");

            responseElevators = ElevatorService.periodoMaiorFluxoElevadorMaisFrequentado();

            Console.WriteLine(" and is most used in the " + responseElevators.First().ToString().ToEnum<EnumShift>() + " shift");

            Console.WriteLine("\n---------------------------------------");

            responseElevators = ElevatorService.elevadorMenosFrequentado();

            Console.WriteLine("Less Used Elevators (highest to lowest): ");

            responseElevators.ForEach(rE => Console.WriteLine("- " + rE));

            Console.WriteLine("\n---------------------------------------");

            responseElevators = ElevatorService.periodoMenorFluxoElevadorMenosFrequentado();

            Console.WriteLine(" and is less used in the " + responseElevators.First().ToString().ToEnum<EnumShift>() + " shift");

            Console.WriteLine("\n---------------------------------------");

            responseElevators = ElevatorService.periodoMaiorUtilizacaoConjuntoElevadores();

            Console.WriteLine("Elevators are most used in the period (highest to lowest): ");

            responseElevators.ForEach(rE => Console.WriteLine("- " + rE.ToString().ToEnum<EnumShift>()));

            Console.WriteLine("\n---------------------------------------");

            float usePercentage = ElevatorService.percentualDeUsoElevadorA();
            Console.WriteLine("The percentage of elevator A use is " + usePercentage + "%");

            Console.WriteLine("\n---------------------------------------");

            usePercentage = ElevatorService.percentualDeUsoElevadorB();
            Console.WriteLine("The percentage of elevator B use is " + usePercentage + "%");

            Console.WriteLine("\n---------------------------------------");

            usePercentage = ElevatorService.percentualDeUsoElevadorC();
            Console.WriteLine("The percentage of elevator C use is " + usePercentage + "%");

            Console.WriteLine("\n---------------------------------------");

            usePercentage = ElevatorService.percentualDeUsoElevadorD();
            Console.WriteLine("The percentage of elevator D use is " + usePercentage + "%");

            Console.WriteLine("\n---------------------------------------");

            usePercentage = ElevatorService.percentualDeUsoElevadorE();
            Console.WriteLine("The percentage of elevator E use is " + usePercentage + "%");

            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine("Press any key to end");


            Console.ReadKey();
        }
    }
}
