using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Genetics
{
    abstract class PopulationGenerator
    {
        public abstract Population GeneratePopulation();

    }
}
