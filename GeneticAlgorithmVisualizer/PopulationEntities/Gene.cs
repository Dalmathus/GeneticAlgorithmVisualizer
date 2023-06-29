using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.PopulationEntities
{
    public class Gene : IEquatable<Gene>
    {
        protected int _value;

        public Gene(int value)
        {
            _value = value;
        }

        public int GetValue()
        {
            return _value;
        }

        public bool Equals(Gene other)
        {
            if (this._value == other.GetValue())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
