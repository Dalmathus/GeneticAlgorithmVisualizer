using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.Genetics;
using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Travelplan.Genetics
{
    internal class RoutePopulationGenerator : PopulationGenerator
    {
        public override Population GenerateRandomPopulation(RuleSet ruleSet)
        {
            RoutePopulation rPop = new RoutePopulation();
            RouteGenerator routeGenerator = new RouteGenerator();
            rPop.Add(routeGenerator.GenerateRandomChromosome(ruleSet));
            return rPop;
        }
    }
}
