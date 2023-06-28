using GeneticAlgorithmVisualizer.Travelplan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.PopulationEntities
{
    public abstract class Chromosome : IEquatable<Chromosome>, IComparable<Chromosome>
    {
        protected List<Gene> _genes;
        protected double _fitness; 

        public abstract void Export();

        public abstract void Import();

        public abstract int CompareTo(Chromosome other);

        public abstract bool Equals(Chromosome other);

        public abstract void CalculateFitness();

        public void SetFitness(double fitness)
        {
            this._fitness = fitness;
        }

        public double GetFitness()
        { 
            return this._fitness;
        }

        public void SetGenes(List<Gene> genes)
        {
            this._genes = genes;
        }

        public List<Gene> GetGenes()
        {
            return this._genes;
        }
    }
}
