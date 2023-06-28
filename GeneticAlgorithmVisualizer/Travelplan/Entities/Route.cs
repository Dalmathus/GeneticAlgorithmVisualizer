using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Contstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GeneticAlgorithmVisualizer.Travelplan.Entities
{
    public class Route : Chromosome, IEquatable<Route>
    {       
 
        public Route()
        {
            _genes = new List<Gene>();
        }        

        public Route(Chromosome r)
        {
            this._genes = r.GetGenes();
        }
            
        public override void CalculateFitness()
        {
            double distance = 0;

            for (int i = _genes.Count - 1; i > 0; i--)
            {
                Location ep = _genes.ElementAt(i) as Location;
                Location dp = _genes.ElementAt(i - 1) as Location;

                // Manhattan Distance |x2 - x1| + |y2 - y1|
                //TODO: Refactor this with new structure
                //distance += (Math.Abs(dp.GetX() - ep.GetX())) + (Math.Abs(dp.GetY() - ep.GetY()));
            }

            this.SetFitness(distance);
        }

        public override int CompareTo(Chromosome other)
        {
            Route comparisonRoute = other as Route;

            if (other == null) return 1;

            double x = this.GetFitness();
            double y = comparisonRoute.GetFitness();

            if (x < y) return -1;
            if (x > y) return 1;
            return 0;
        }

        public bool Equals(Route other)
        {
            
            List<Gene> currentLocation = this._genes;
            List<Gene> comparisonLocation = other.GetGenes();

            for (int i = 0; i < currentLocation.Count; i++)
            {
                if (!currentLocation.ElementAt(i).Equals(comparisonLocation.ElementAt(i))) return false;
            }

            return true;
        }

        public override string ToString()
        {
            string output = "{ ";

            foreach(Location location in this._genes) 
            {
                output += location.ToString() + " ";
            }

            output += "}";

            return output;
        }

        public override void Export()
        {
            throw new NotImplementedException();
        }

        public override void Import()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Chromosome other)
        {
            throw new NotImplementedException();
        }

    }
}
