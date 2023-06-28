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

        public Location(int value) : base(value)
        {
            _value = value;
        }

        public bool Equals(Location other)
        {
            Location otherL = other;

            if (this._value == other.GetValue())
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
            return _value.ToString();
        }
    }
}
