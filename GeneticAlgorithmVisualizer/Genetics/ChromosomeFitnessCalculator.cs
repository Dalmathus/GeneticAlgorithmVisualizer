using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Contstraints;
using System;

namespace GeneticAlgorithmVisualizer.Genetics
{
    public class ChromosomeFitnessCalculator
    {
        // This should be in its own rule specific class, need to find the right way to do that.
        public static void CalculateFitness(Chromosome c, RuleSet rule)
        {
            double distance = 0;
            Map map = rule as Map;

            for (int i = c.GetGenes().Count - 1; i > 0; i--)
            {
                Tuple<int, int> startPoint = map.GetDestinationByIndex(c.GetGeneByIndex(i).GetValue());
                Tuple<int, int> endPoint = map.GetDestinationByIndex(c.GetGeneByIndex(i - 1).GetValue());

                // Manhattan Distance |x2 - x1| + |y2 - y1|
                distance += (Math.Abs(endPoint.Item1 - startPoint.Item1)) + (Math.Abs(endPoint.Item2 - startPoint.Item2));
            }

            c.SetFitness(distance);
        }
    }
}
