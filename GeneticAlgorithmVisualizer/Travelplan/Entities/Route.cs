using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Contstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GeneticAlgorithmVisualizer.Travelplan.Entities
{
    internal class Route : Chromosome
    {       
 
        public Route()
        {
            _genes = new List<Gene>();
        }        

        /// <summary>
        /// This will be pulled into PopFitnessEval when I start writing those classes
        /// </summary>
        private void CalculateFitness()
        {
            double distance = 0;

            foreach (Movement movement in this._genes)
            {
                distance += movement.GetValue();
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
