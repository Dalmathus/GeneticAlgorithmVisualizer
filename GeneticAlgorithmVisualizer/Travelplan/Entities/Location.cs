using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Travelplan.Entities
{
    public class Location : Gene, IEquatable<Location>
    {

        private Tuple<int, int> _location;

        public Location(int x, int y) 
        {
            _location = new Tuple<int, int>(x, y);
        }

        public bool Equals(Location other)
        {
            Location otherL = other;

            if (this.GetX() == otherL.GetX() && this.GetY() == otherL.GetY())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return _location.Item1.ToString() + "-" + _location.Item2.ToString();
        }

        public int GetX()
        {
            return _location.Item1;
        }

        public int GetY()
        {
            return _location.Item2;
        }
    }
}
