using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.PopulationEntities
{
    public abstract class Population
    {
        //public abstract void Add(Chromosome entity);

        public abstract void Remove(Chromosome entity);

        public abstract void Clear();

        public abstract void Export();

        public abstract void Import();
    }
}
