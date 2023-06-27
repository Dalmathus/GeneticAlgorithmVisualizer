using GeneticAlgorithmVisualizer.Genetics;
using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Entities;

namespace GeneticAlgorithmVisualizerTests
{
    [TestClass]
    public class CycleCrossoverTwoTests
    {
        [TestMethod]
        public void HappyCaseCycleCrossoverTwoTest()
        {
            Route offspring1Exepected;
            Route offspring2Exepected;

            List<Gene> genesFather = new List<Gene>();
            List<Gene> genesMother = new List<Gene>();

            genesFather.Add(new Location(3, 3));
            genesFather.Add(new Location(4, 4));
            genesFather.Add(new Location(8, 8));
            genesFather.Add(new Location(2, 2));
            genesFather.Add(new Location(7, 7));
            genesFather.Add(new Location(1, 1));
            genesFather.Add(new Location(6, 6));
            genesFather.Add(new Location(5, 5));

            genesMother.Add(new Location(4, 4));
            genesMother.Add(new Location(2, 2));
            genesMother.Add(new Location(5, 5));
            genesMother.Add(new Location(1, 1));
            genesMother.Add(new Location(6, 6));
            genesMother.Add(new Location(8, 8));
            genesMother.Add(new Location(3, 3));
            genesMother.Add(new Location(7, 7));

            Route parent1Father = new Route();
            Route parent2Mother = new Route();

            parent1Father.SetGenes(genesFather);
            parent2Mother.SetGenes(genesMother);

            PopulationCrossover pc = new PopulationCrossover();

            Tuple<Route, Route> results = pc.CycleCrossoverTwoRoutes(parent1Father, parent2Mother);

            offspring1Exepected = results.Item1;
            offspring2Exepected = results.Item2;
            
            Assert.AreEqual(offspring1Exepected.ToString(), "{ 4-4 8-8 6-6 2-2 5-5 3-3 1-1 7-7 }");
            Assert.AreEqual(offspring2Exepected.ToString(), "{ 1-1 7-7 4-4 8-8 6-6 2-2 5-5 3-3 }");
        }
    }
}