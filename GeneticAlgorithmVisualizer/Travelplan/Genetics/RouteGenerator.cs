using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.Genetics;
using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Contstraints;
using GeneticAlgorithmVisualizer.Travelplan.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Travelplan.Genetics
{
    internal class RouteGenerator : ChromosomeGenerator
    {
        public override Chromosome GenerateRandomChromosome(RuleSet ruleSet)
        {
            int x;
            Location lFrom, lTo;

            Map map = ruleSet as Map;

            Random random = new Random(Guid.NewGuid().GetHashCode());

            List<Location> validPoints = new List<Location>();
            List<Gene> movements = new List<Gene>();

            foreach (Location l in map.GetDestinations())
            {
                validPoints.Add(l);
            }

            // Get the starting location
            x = random.Next(validPoints.Count);
            lFrom = validPoints.ElementAt(x);
            validPoints.RemoveAt(x);

            while (validPoints.Count > 0)
            {
                x = random.Next(validPoints.Count);
                lTo = validPoints.ElementAt(x);
                movements.Add(new Movement(lFrom, lTo));
                validPoints.RemoveAt(x);
                lFrom = lTo;
            }

            Route route = new Route();
            route.SetGenes(movements);

            return route;
        }
    }
}
