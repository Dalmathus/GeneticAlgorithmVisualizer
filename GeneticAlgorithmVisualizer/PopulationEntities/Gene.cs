using System;

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

        public void SetValue(int value)
        {
           _value = value;
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

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
