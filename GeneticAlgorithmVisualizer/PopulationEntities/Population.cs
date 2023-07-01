using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.PopulationEntities
{
    public class Population
    {
        protected List<Chromosome> _chromosomes;

        public Population(List<Chromosome> chromosomes)
        {
            _chromosomes = chromosomes;
        }

        public Population() 
        { 
            _chromosomes = new List<Chromosome>();
        }

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

        public void Export()
        {
            throw new NotImplementedException();
        }

        public void Import()
        {
            throw new NotImplementedException();
        }
    }
}
