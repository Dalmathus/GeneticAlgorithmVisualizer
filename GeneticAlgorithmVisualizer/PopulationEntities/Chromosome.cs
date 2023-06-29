using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.PopulationEntities
{
    public class Chromosome : IEquatable<Chromosome>, IComparable<Chromosome>
    {
        protected List<Gene> _genes;
        protected double _fitness;

        public Chromosome()
        {
            _genes = new List<Gene>();
        }            

        public int CompareTo(Chromosome other)
        {
            Chromosome comparisonRoute = other;

            if (other == null) return 1;

            double x = this.GetFitness();
            double y = comparisonRoute.GetFitness();

            if (x < y) return -1;
            if (x > y) return 1;
            return 0;
        }

        public void AddGene(Gene gene)
        {
            _genes.Add(gene);
        }

        public void AddGene(int gene)
        {
            _genes.Add(new Gene(gene));
        }

        public bool Equals(Chromosome other)
        {

            List<Gene> currentLocation = this._genes;
            List<Gene> comparisonLocation = other.GetGenes();

            for (int i = 0; i < currentLocation.Count; i++)
            {
                if (!currentLocation.ElementAt(i).Equals(comparisonLocation.ElementAt(i))) return false;
            }

            return true;
        }

        public void CalculateFitness()
        {
            //throw new NotImplementedException();
        }

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

        public Gene GetGeneByIndex(int index)
        {
            return this._genes.ElementAt(index);
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
