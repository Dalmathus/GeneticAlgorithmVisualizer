using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Genetics
{
    public class PopulationGenerator
    {
        public Population GenerateRandomPopulation(RuleSet ruleSet)
        {
            Population randomPopulation = new Population();

            for (int i = 0; i < ruleSet.GetPopulationSize(); i++)
            {
                randomPopulation.Add(ChromosomeGenerator.GenerateRandomIndexChromosome(ruleSet));
            }

            return randomPopulation;
        }

        public Population CopyPopulation(Population population)
        {
            Population copyPopulation = new Population();

            foreach (Chromosome c in population.GetChromosomes())
            {
                //copyPopulation.Add(new Chromosome(c));
            }

            return copyPopulation;
        }


    }
}
