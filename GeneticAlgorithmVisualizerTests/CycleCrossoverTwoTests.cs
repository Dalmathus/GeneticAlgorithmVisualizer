using GeneticAlgorithmVisualizer.Genetics;
using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Entities;

namespace GeneticAlgorithmVisualizerTests
{
    [TestClass]
    public class CycleCrossoverTwoTests
    {
        [TestMethod]
        public void HappyCase1CycleCrossoverTwoTest()
        {
            Chromosome offspring1Exepected;
            Chromosome offspring2Exepected;

            List<Gene> genesFather = new List<Gene>();
            List<Gene> genesMother = new List<Gene>();

            genesFather.Add(new Location(3));
            genesFather.Add(new Location(4));
            genesFather.Add(new Location(8));
            genesFather.Add(new Location(2));
            genesFather.Add(new Location(7));
            genesFather.Add(new Location(1));
            genesFather.Add(new Location(6));
            genesFather.Add(new Location(5));

            genesMother.Add(new Location(4));
            genesMother.Add(new Location(2));
            genesMother.Add(new Location(5));
            genesMother.Add(new Location(1));
            genesMother.Add(new Location(6));
            genesMother.Add(new Location(8));
            genesMother.Add(new Location(3));
            genesMother.Add(new Location(7));

            Route parent1Father = new Route();
            Route parent2Mother = new Route();

            parent1Father.SetGenes(genesFather);
            parent2Mother.SetGenes(genesMother);

            PopulationCrossover pc = new PopulationCrossover();
            //Tuple<Chromosome, Chromosome> results = pc.CycleCrossoverTwoRoutes(parent1Father, parent2Mother);

            //offspring1Exepected = results.Item1;
            //offspring2Exepected = results.Item2;
            //
            //Assert.AreEqual("{ 4 8 6 2 5 3 1 7 }", offspring1Exepected.ToString());
            //Assert.AreEqual("{ 1 7 4 8 6 2 5 3 }", offspring2Exepected.ToString());
            //
            //// Mess with the parents
            //genesFather.Remove(genesFather.ElementAt(2));
            //
            //Assert.AreEqual("{ 4 8 6 2 5 3 1 7 }", offspring1Exepected.ToString());
            //Assert.AreEqual("{ 1 7 4 8 6 2 5 3 }", offspring2Exepected.ToString());

        }
    }
}