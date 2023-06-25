using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Travelplan.Entities
{
    internal class RoutePopulation : Population
    {
        public RoutePopulation()
        {
            this._chromosomes = new List<Chromosome>();            
        }

        public override void Add(Chromosome chromosome)
        {
            this._chromosomes.Add(chromosome);
        }

        public override void Sort()
        {
            this._chromosomes.Sort();
        }

        public List<Chromosome> GetRoutes()
        {
            return this._chromosomes;
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override void Export()
        {
            throw new NotImplementedException();
        }

        public override void Import()
        {
            throw new NotImplementedException();
        }

        public override void Remove(Chromosome entity)
        {
            throw new NotImplementedException();
        }
    }
}
