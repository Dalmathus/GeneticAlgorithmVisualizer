using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Genetics
{
    public abstract class PopulationGenerator
    {
        public abstract Population GenerateRandomPopulation(RuleSet ruleSet);

        public abstract Population CopyPopulation(Population population);
    }
}
