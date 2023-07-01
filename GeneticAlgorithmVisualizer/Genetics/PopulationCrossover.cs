using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GeneticAlgorithmVisualizer.Genetics
{
    public class PopulationCrossover
    {
                  
        public static Tuple<Chromosome, Chromosome> CycleCrossoverTwoRoutes(Chromosome father, Chromosome mother)
        {
            List<Gene> offspring1Genes = new List<Gene>();
            List<Gene> offspring2Genes = new List<Gene>();

            List<Gene> fatherGenes = father.GetGenes(); // parent 1
            List<Gene> motherGenes = mother.GetGenes(); // parent 2

            Gene firstBit = new Gene(motherGenes.ElementAt(0).GetValue());
            Gene secondBit;
            Gene thirdBit;

            // selected first bit of second parent for the starting point
            for (int i = 0; i < fatherGenes.Count; i++)
            {
                offspring1Genes.Add(firstBit);

                // look for this value in the first parent, save the index 
                for (int n = 0; n < fatherGenes.Count; n++)
                {                    
                    if (fatherGenes.ElementAt(n).Equals(firstBit))
                    {
                        // Once we have found the matching value in the first parent grab the value in the same index from the second parent
                        secondBit = new Gene(motherGenes.ElementAt(n).GetValue());

                        // look for that value in the first parent
                        for (int m = 0; m < fatherGenes.Count; m++)
                        {
                            if (fatherGenes.ElementAt(m).Equals(secondBit))
                            {
                                //once that value has been found store the value of the second parent in the same index to the first offspring
                                offspring2Genes.Add(new Gene(motherGenes.ElementAt(m).GetValue()));
                                thirdBit = new Gene(motherGenes.ElementAt(m).GetValue());

                                for (int k = 0; k < fatherGenes.Count; k++)
                                {
                                    if (fatherGenes.ElementAt(k).Equals(thirdBit))
                                    {
                                        firstBit = new Gene(motherGenes.ElementAt(k).GetValue());
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            return new Tuple<Chromosome, Chromosome>(new Chromosome(offspring1Genes), new Chromosome(offspring2Genes));
        }

        public static Tuple<Chromosome, Chromosome> CycleCrossover(Chromosome father, Chromosome mother)
        {

            List<Gene> p1 = father.GetGenes(); // parent 1
            List<Gene> p2 = mother.GetGenes(); // parent 2

            // Build a list of cycles
            List<List<int>> cycles = new List<List<int>>();
            bool buildCycle = true;

            // Each time I build a closed loop, I need to check if the next index is in any of the preceeding loops
            for (int i = 0; i < p1.Count; i++)
            {
                foreach (List<int> c in cycles)
                {
                    if(c.Contains(i))
                    {
                        buildCycle = false;
                        break;
                    }
                }

                if (buildCycle)
                {
                    List<int> cycle = new List<int>();
                    CreateCycle(p1, p2, i, cycle);
                    cycle.Sort();
                    cycles.Add(cycle);
                }

                buildCycle = true;
            }

            // We now have a list of cycles, we want to iterate through them and build a new Gene from the two parents using alternating cycles
            Chromosome o1 = new Chromosome();
            Chromosome o2 = new Chromosome();

            //Instatiate the Genes with invalid values so the array has index reference points
            for (int i = 0; i < p1.Count; i++)
            {
                o1.AddGene(-1);
                o2.AddGene(-1);
            }

            for (int i = 0; i < cycles.Count; i++)
            {
                if (i % 2 == 0) // Everyone gets their own genes
                {
                    for (int j = 0; j < cycles[i].Count; j++)
                    {
                        o1.SetGeneByIndex(cycles[i][j], p1[cycles[i][j]].GetValue());
                        o2.SetGeneByIndex(cycles[i][j], p2[cycles[i][j]].GetValue());
                    }
                } else // Give em over to the other guy
                {
                    for (int j = 0; j < cycles[i].Count; j++)
                    {
                        o1.SetGeneByIndex(cycles[i][j], p2[cycles[i][j]].GetValue());
                        o2.SetGeneByIndex(cycles[i][j], p1[cycles[i][j]].GetValue());
                    }
                }
            }

            return new Tuple<Chromosome, Chromosome>(o1, o2);
        }

        private static void CreateCycle(List<Gene> p1, List<Gene> p2, int i, List<int> cycle)
        {
            // If the cycle does not contain the current index then we are not in a closed loop yet, keep digging!
            if (!cycle.Contains(i))
            {
                // Add our index to the cycle
                cycle.Add(i);

                // Find the position of the matching gene in p2
                int elementSearch = p2[i].GetValue();   
                for (int j = 0; j < p1.Count; j++) 
                {
                    if (p1[j].GetValue() == elementSearch)
                    {
                        //We have found the matching element so call the process again
                        CreateCycle(p1, p2, j, cycle);
                    }
                }
            }
        }


    }
}
