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

        private List<Route> _routes;

        public RoutePopulation()
        {
            this._routes = new List<Route>();
        }

        public void Add(Route entity)
        {
            this._routes.Add(entity);
        }

        public void SortRoutes()
        {
            this._routes.Sort();
        }

        public List<Route> GetRoutes()
        {
            return this._routes;
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
