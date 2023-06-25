using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Contstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmVisualizer.Travelplan.Entities
{
    internal class Route : Chromosome, IEquatable<Route>, IComparable<Route>
    {

        private Map _map;
        private List<Movement> _itinerary;
        private int _distance;

        public Route(Map map)
        {
            _map = map;
            _itinerary = new List<Movement>();
        }

        public void GenerateRandomRoute()
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
                this._itinerary.Add(new Movement(lFrom, lTo));
                validPoints.RemoveAt(x);
                lFrom = lTo;
            }

            this.SetDistance();
        }

        public int GetDistance()
        { 
            return this._distance;
        }

        private void SetDistance()
        {
            int distance = 0;

            foreach (Movement movement in this._itinerary)
            {
                distance += movement.GetDistance();
            }

            this._distance = distance;
        }

        public List<Movement> GetLocations()
        {
            return this._itinerary;
        }

        public override void Export()
        {
            throw new NotImplementedException();
        }

        public override void Import()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Route other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Route other)
        {
            if (other == null) return 1;

            int x = this.GetDistance();
            int y = other.GetDistance();
            
            if (x < y) return -1;
            if (x > y) return 1;
            return 0;
        }
    }
}
