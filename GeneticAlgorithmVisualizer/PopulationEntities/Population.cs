using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.PopulationEntities
{
    public abstract class Population
    {
        protected List<Chromosome> _chromosomes;

        public void Add(Chromosome chromosome)
        {
            this._chromosomes.Add(chromosome);
        }

        public void Remove(Chromosome chromosome)
        {
            this._chromosomes.Remove(chromosome);
        }

        public void Sort()
        {
            _chromosomes.Sort();
        }

        public List<Chromosome> GetChromosomes()
        {
            return this._chromosomes;
        }

        public void Clear()
        {
            _chromosomes.Clear();
        }

        public abstract void Export();

        public abstract void Import();

        
    }
}
