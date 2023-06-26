using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.PopulationEntities
{
    public abstract class Gene
    {
        protected int _value;

        public int GetValue()
        {
            return _value;
        }

    }
}
