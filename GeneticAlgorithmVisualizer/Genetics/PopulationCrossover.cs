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

        public Tuple<Route, Route> CycleCrossoverTwoRoutes(Route father, Route mother)
        {

            List<Gene> offspring1Genes = new List<Gene>();
            List<Gene> offspring2Genes = new List<Gene>();

            List<Gene> fatherGenes = father.GetGenes(); // parent 1
            List<Gene> motherGenes = mother.GetGenes(); // parent 2

            Location testLocation;
            Location firstBit = motherGenes.ElementAt(0) as Location;
            Location secondBit;
            Location thirdBit;

            // selected first bit of second parent for the starting point

            for (int i = 0; i < fatherGenes.Count; i++)
            {
                offspring1Genes.Add(firstBit);

                // look for this value in the first parent, save the index 
                for (int n = 0; n < fatherGenes.Count; n++)
                {
                    testLocation = fatherGenes.ElementAt(n) as Location;
                    if (testLocation.GetX() == firstBit.GetX() && testLocation.GetY() == firstBit.GetY())
                    {
                        // Once we have found the matching value in the first parent grab the value in the same index from the second parent
                        secondBit = motherGenes.ElementAt(n) as Location;

                        // look for that value in the first parent
                        for (int m = 0; m < fatherGenes.Count; m++)
                        {
                            testLocation = fatherGenes.ElementAt(m) as Location;
                            if (testLocation.GetX() == secondBit.GetX() && testLocation.GetY() == secondBit.GetY())
                            {
                                //once that value has been found store the value of the second parent in the same index to the first offspring
                                offspring2Genes.Add(motherGenes.ElementAt(m));
                                thirdBit = motherGenes.ElementAt(m) as Location;

                                for (int k = 0; k < fatherGenes.Count; k++)
                                {
                                    testLocation = fatherGenes.ElementAt(k) as Location;
                                    if (testLocation.GetX() == thirdBit.GetX() && testLocation.GetY() == thirdBit.GetY())
                                    {
                                        firstBit = motherGenes.ElementAt(k) as Location;
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

            return new Tuple<Route, Route>(offspring1, offspring2);
        } 

    }
}
