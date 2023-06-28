using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace GeneticAlgorithmVisualizer.Genetics
{
    public class PopulationCrossover
    {
        //TODO: REFACTOR THIS TO SUPPORT NEW MODEL
        /*          
        public Tuple<Chromosome, Chromosome> CycleCrossoverTwoRoutes(Chromosome father, Chromosome mother)
        {
            List<Gene> offspring1Genes = new List<Gene>();
            List<Gene> offspring2Genes = new List<Gene>();

            List<Gene> fatherGenes = father.GetGenes(); // parent 1
            List<Gene> motherGenes = mother.GetGenes(); // parent 2

            Location firstBit = new Location(((Location)motherGenes.ElementAt(0)).GetX(), ((Location)motherGenes.ElementAt(0)).GetY());
            Location secondBit;
            Location thirdBit;

            // selected first bit of second parent for the starting point
            for (int i = 0; i < fatherGenes.Count; i++)
            {
                offspring1Genes.Add(firstBit);

                // look for this value in the first parent, save the index 
                for (int n = 0; n < fatherGenes.Count; n++)
                {                    
                    if (((Location)fatherGenes.ElementAt(n)).Equals(firstBit))
                    {
                        // Once we have found the matching value in the first parent grab the value in the same index from the second parent
                        secondBit = new Location(((Location)motherGenes.ElementAt(n)).GetX(), ((Location)motherGenes.ElementAt(n)).GetY());

                        // look for that value in the first parent
                        for (int m = 0; m < fatherGenes.Count; m++)
                        {
                            if (((Location)fatherGenes.ElementAt(m)).Equals(secondBit))
                            {
                                //once that value has been found store the value of the second parent in the same index to the first offspring
                                offspring2Genes.Add(new Location(((Location)motherGenes.ElementAt(m)).GetX(), ((Location)motherGenes.ElementAt(m)).GetY()));
                                thirdBit = new Location(((Location)motherGenes.ElementAt(m)).GetX(), ((Location)motherGenes.ElementAt(m)).GetY());

                                for (int k = 0; k < fatherGenes.Count; k++)
                                {
                                    if (((Location)fatherGenes.ElementAt(k)).Equals(thirdBit))
                                    {
                                        firstBit = new Location(((Location)motherGenes.ElementAt(k)).GetX(), ((Location)motherGenes.ElementAt(k)).GetY());
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

            Route offspring1 = new Route();
            Route offspring2 = new Route();
            offspring1.SetGenes(offspring1Genes);
            offspring2.SetGenes(offspring2Genes);

            return new Tuple<Chromosome, Chromosome>(offspring1, offspring2);
        } 
        */
    }
}
