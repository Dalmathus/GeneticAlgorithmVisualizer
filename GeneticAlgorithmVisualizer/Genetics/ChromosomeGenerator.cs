using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Genetics
{
    public class ChromosomeGenerator
    {
        public static Chromosome GenerateRandomIndexChromosome(RuleSet ruleSet)
        {
            Chromosome chromosome = new Chromosome();            
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int chromosomeSize = ruleSet.GetChromosomeSize();

            while (chromosome.GetGenes().Count < chromosomeSize)
            {
                Gene potentialGene = new Gene(rnd.Next(0, chromosomeSize));
                if (chromosome.GetGenes().Contains(potentialGene)) continue;
                chromosome.AddGene(potentialGene);
            }

            return chromosome;
        }

        public static Chromosome GenerateRandomBinaryChromosome(RuleSet ruleSet)
        {
            Chromosome chromosome = new Chromosome();

            return chromosome;
        }
    }
}
