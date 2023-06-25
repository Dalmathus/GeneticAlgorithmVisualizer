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

        private Map _map;     

        public Route(Map map)
        {
            _map = map;
            _genes = new List<Gene>();
        }

        public override void GenerateRandomChromosome()
        {
            int x;
            Location lFrom, lTo;

            // LESSON: https://stackoverflow.com/questions/1785744/how-do-i-seed-a-random-class-to-avoid-getting-duplicate-random-values
            Random random = new Random(Guid.NewGuid().GetHashCode());

            List<Location> validPoints = new List<Location>();

            foreach (Location l in _map.GetDestinations()) 
            {
                validPoints.Add(l);
            }

            // Get the starting location
            x = random.Next(validPoints.Count);
            lFrom = validPoints.ElementAt(x);
            validPoints.RemoveAt(x);

            while (validPoints.Count > 0)
            {
                x = random.Next(validPoints.Count);
                lTo = validPoints.ElementAt(x);
                this._genes.Add(new Movement(lFrom, lTo));
                validPoints.RemoveAt(x);
                lFrom = lTo;
            }

            this.CalculateFitness();
        }

        /// <summary>
        /// This will be pulled into PopFitnessEval when I start writing those classes
        /// </summary>
        private void CalculateFitness()
        {
            double distance = 0;

            foreach (Movement movement in this._genes)
            {
                distance += movement.GetDistance();
            }

            this.SetFitness(distance);
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
    }
}
