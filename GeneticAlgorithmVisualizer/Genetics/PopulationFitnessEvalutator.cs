using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Contstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Genetics
{
    public class PopulationFitnessEvalutator
    {
        public void EvaulateFitness(Population population, RuleSet rule)
        {
            foreach (Chromosome c in population.GetChromosomes())
            {
                ChromosomeFitnessCalculator.CalculateFitness(c, rule);
            }
        }
    }
}
