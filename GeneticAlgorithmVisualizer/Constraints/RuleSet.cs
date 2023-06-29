using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Constraints
{
    public abstract class RuleSet
    {
        protected int _populationSize;
        protected int _chromosomeSize;

        public int GetPopulationSize()
        {
            return _populationSize;
        }

        public int GetChromosomeSize()
        {
            return _chromosomeSize;
        }
    }
}
