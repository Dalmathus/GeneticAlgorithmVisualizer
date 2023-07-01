using GeneticAlgorithmVisualizer.Genetics;
using GeneticAlgorithmVisualizer.PopulationEntities;

namespace GeneticAlgorithmVisualizerTests
{
    [TestClass]
    public class CycleCrossoverTests
    {
        [TestMethod]
        public void HappyCase1CycleCrossoverTest()
        {
            Chromosome p1 = new Chromosome();
            Chromosome p2 = new Chromosome();

            p1.AddGene(1);
            p1.AddGene(2);
            p1.AddGene(3);
            p1.AddGene(4);
            p1.AddGene(5);
            p1.AddGene(6);
            p1.AddGene(7);
            p1.AddGene(8);
            p1.AddGene(9);

            p2.AddGene(9);
            p2.AddGene(3);
            p2.AddGene(7);
            p2.AddGene(8);
            p2.AddGene(2);
            p2.AddGene(6);
            p2.AddGene(5);
            p2.AddGene(1);
            p2.AddGene(4);

            Tuple<Chromosome, Chromosome> offspring = PopulationCrossover.CycleCrossover(p1, p2);

            Assert.AreEqual("{ 1 3 7 4 2 6 5 8 9 }", offspring.Item1.ToString()); 
            Assert.AreEqual("{ 9 2 3 8 5 6 7 1 4 }", offspring.Item2.ToString());
            
        }
    }
}
