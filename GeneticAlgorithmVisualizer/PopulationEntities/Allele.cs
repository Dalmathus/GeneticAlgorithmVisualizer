using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.PopulationEntities
{
    public abstract class Allele : IEquatable<Allele>
    {
        public abstract bool Equals(Allele other);

    }
}
