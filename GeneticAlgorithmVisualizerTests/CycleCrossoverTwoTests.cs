using GeneticAlgorithmVisualizer.Genetics;
using GeneticAlgorithmVisualizer.PopulationEntities;

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

            List<Gene> genesFather = new();
            List<Gene> genesMother = new();

            genesFather.Add(new Gene(3));
            genesFather.Add(new Gene(4));
            genesFather.Add(new Gene(8));
            genesFather.Add(new Gene(2));
            genesFather.Add(new Gene(7));
            genesFather.Add(new Gene(1));
            genesFather.Add(new Gene(6));
            genesFather.Add(new Gene(5));

            genesMother.Add(new Gene(4));
            genesMother.Add(new Gene(2));
            genesMother.Add(new Gene(5));
            genesMother.Add(new Gene(1));
            genesMother.Add(new Gene(6));
            genesMother.Add(new Gene(8));
            genesMother.Add(new Gene(3));
            genesMother.Add(new Gene(7));

            Chromosome parent1Father = new Chromosome();
            Chromosome parent2Mother = new Chromosome();

            parent1Father.SetGenes(genesFather);
            parent2Mother.SetGenes(genesMother);

            Tuple<Chromosome, Chromosome> results = PopulationCrossover.CycleCrossoverTwoRoutes(parent1Father, parent2Mother);

            offspring1Exepected = results.Item1;
            offspring2Exepected = results.Item2;
            
            Assert.AreEqual("{ 4 8 6 2 5 3 1 7 }", offspring1Exepected.ToString());
            Assert.AreEqual("{ 1 7 4 8 6 2 5 3 }", offspring2Exepected.ToString());
            
            // Mess with the parents
            genesFather.Remove(genesFather.ElementAt(2));
            
            Assert.AreEqual("{ 4 8 6 2 5 3 1 7 }", offspring1Exepected.ToString());
            Assert.AreEqual("{ 1 7 4 8 6 2 5 3 }", offspring2Exepected.ToString());
        }
    }
}