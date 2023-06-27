using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Genetics
{
    internal class PopulationFitnessEvalutator
    {
        public void EvaulateFitness(Population population)
        {
            foreach (Chromosome c in population.GetChromosomes())
            {
                c.CalculateFitness();
            }
        }
    }
}
