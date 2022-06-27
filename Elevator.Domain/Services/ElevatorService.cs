using Elevator.Domain.Contracts;
using Elevator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator.Domain.Services
{
    public class ElevatorService : IElevatorService
    {
        List<UserResponse> UserResponses { get; set; }
        public ElevatorService(IJsonReaderService jsonReaderService)
        {
            UserResponses = jsonReaderService.UserResponses();
        }

        public List<int> andarMenosUtilizado()
        {
            List<int> floors = new();
            UserResponses.ForEach(ur => floors.Add(ur.Andar));

            return floors.GroupBy(f => f)
                   .OrderBy(grp => grp.Count())
                   .Select(grp => grp.Key).ToList();
        }
        public List<char> elevadorMaisFrequentado()
        {
            List<char> elevators = new();
            UserResponses.ForEach(ur => elevators.Add(ur.Elevador));

            return elevators.GroupBy(e => e)
                   .OrderByDescending(grp => grp.Count())
                   .Select(grp => grp.Key).ToList();
        }
        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            char mostUsedElevator = elevadorMaisFrequentado().First();

            Console.Write("The most frequented elevator is " + mostUsedElevator);

            return (from e in UserResponses
                    where e.Elevador == mostUsedElevator
                    group e.Turno by e.Turno into grouping
                    orderby grouping.Count() descending
                    select grouping.Key).ToList();
        }
        public List<char> elevadorMenosFrequentado()
        {
            List<char> elevators = new();
            UserResponses.ForEach(uR => elevators.Add(uR.Elevador));

            return elevators.GroupBy(e => e)
                   .OrderBy(grp => grp.Count())
                   .Select(grp => grp.Key).ToList();
        }
        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            char lessUsedElevator = elevadorMenosFrequentado().FirstOrDefault();

            Console.Write("The less used elevator is " + lessUsedElevator);

            return (from s in UserResponses
                    where s.Elevador == lessUsedElevator
                    group s.Turno by s.Turno into grouping
                    orderby grouping.Count() ascending
                    select grouping.Key).ToList();
        }
        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            List<char> shifts = new();
            UserResponses.ForEach(uR => shifts.Add(uR.Turno));

            return shifts.GroupBy(t => t)
                   .OrderByDescending(grp => grp.Count())
                   .Select(grp => grp.Key).ToList();
        }
        public float percentualDeUsoElevadorA() => (float)Math.Round(CalculatePercentage('A'), 2);
        public float percentualDeUsoElevadorB() => (float)Math.Round(CalculatePercentage('B'), 2);
        public float percentualDeUsoElevadorC() => (float)Math.Round(CalculatePercentage('C'), 2);
        public float percentualDeUsoElevadorD() => (float)Math.Round(CalculatePercentage('D'), 2);
        public float percentualDeUsoElevadorE() => (float)Math.Round(CalculatePercentage('E'), 2);
        float CalculatePercentage(char elevatorName)
        {
            List<int> elevators = new();
            UserResponses.ForEach(uR => elevators.Add(uR.Elevador));

            return (float)Math.Round(((float)elevators.Count(e => e == elevatorName)) / elevators.Count * 100, 2);
        }
    }
}