using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.PopulationEntities;

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
