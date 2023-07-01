
namespace GeneticAlgorithmVisualizer.Constraints
{
    public abstract class RuleSet
    {
        protected int _populationSize;
        protected int _chromosomeSize;

        public int GetPopulationSize()
        {
            return _populationSize;
        }

        public int GetChromosomeSize()
        {
            return _chromosomeSize;
        }
    }
}
