using GeneticAlgorithmVisualizer.Genetics;
using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Contstraints;
using GeneticAlgorithmVisualizer.Travelplan.Entities;
using GeneticAlgorithmVisualizer.Travelplan.Genetics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GeneticAlgorithmVisualizer
{
    public partial class Visualizer : Form
    {

        private Map _map;
        private const int SIZE = 5;
        private const int LOCATIONS = 4;
        private int cellSize;
        private PopulationController pc;

        public Visualizer()
        {
            InitializeComponent();
            InitializeGrid();

            string[] args = { "travelplan" };
            pc = new PopulationController(_map, args);
        }

        private void InitializeGrid()
        {
            _map = new Map(SIZE);
            cellSize = (this.TravelMap.Size.Width - 1) / SIZE;
            _map.InstantiateGridPoints(LOCATIONS);           
        }

        private void DrawGrid()
        {
            using (Graphics g = this.TravelMap.CreateGraphics())
            {
                Pen p = new Pen(Color.Black, 1);

                for (int i = 0; i <= SIZE; i++)
                {
                    // Vertical
                    g.DrawLine(p, i * cellSize, 0, i * cellSize, SIZE * cellSize);
                    // Horizontal
                    g.DrawLine(p, 0, i * cellSize, SIZE * cellSize, i * cellSize);
                }
            }
        }

        private void DrawLocations()
        {          
            using (Graphics g = this.TravelMap.CreateGraphics())
            {
                SolidBrush b = new SolidBrush(Color.Red);
                List<Location> locations = _map.GetDestinations();

                // print all rectangles that have been designated as location
                foreach (Location location in locations) 
                {
                    g.FillRectangle(b, location.GetX() * cellSize, location.GetY() * cellSize, cellSize, cellSize);                  
                }
            }
        }

        private void ResetGrid()
        {
            this.TravelMap.Refresh();            
            DrawGrid();
            DrawLocations();
            labelBDText.Text = "";
        }

        private void DrawRoute(Route route, Color c)
        {

            List<Gene> itinerary = route.GetGenes();

            int offset = cellSize / 2;

            using (Graphics g = this.TravelMap.CreateGraphics())
            {
                Pen p = new Pen(c, 2);

                for (int i = itinerary.Count - 1; i > 0; i--) {

                    int x1, x2, y1, y2;

                    Location ep = itinerary.ElementAt(i) as Location;
                    Location dp = itinerary.ElementAt(i - 1) as Location;

                    // Redundant assignment but might refactor this in a more complicated way later
                    x1 = ep.GetX();
                    y1 = ep.GetY();

                    x2 = dp.GetX();                    
                    y2 = dp.GetY();

                    g.DrawLine(p,
                               x1 * cellSize + offset,
                               y1 * cellSize + offset,
                               x2 * cellSize + offset,
                               y2 * cellSize + offset);


                }
            }
        }

        private void buttonMapCreate_Click(object sender, EventArgs e)
        {
            DrawGrid();
        }

        private void buttonDotPoints_Click(object sender, EventArgs e)
        {
            DrawLocations();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetGrid();
        }

        private void buttonRandRoute_Click(object sender, EventArgs e)
        {
            DrawRandomRoute();
        }

        private void buttonRouteMap_Click(object sender, EventArgs e)
        {            
            EstablishRandomRoutesAndDraw();
        }

        private void DrawRandomRoute()
        {
            RouteGenerator routeGenerator = new RouteGenerator();
            Route r = routeGenerator.GenerateRandomChromosome(_map) as Route;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            DrawRoute(r, randomColor);
            r.CalculateFitness();
            labelBDText.Text = r.GetFitness().ToString();
        }

        private void EstablishRandomRoutesAndDraw()
        {
            RoutePopulationGenerator rg = new RoutePopulationGenerator();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            RoutePopulation rpop = rg.GenerateRandomPopulation(_map) as RoutePopulation;
            rpop.Sort();

            ResetGrid();
            rpop.GetChromosomes().ElementAt(0).CalculateFitness();
            labelBDText.Text = rpop.GetChromosomes().ElementAt(0).GetFitness().ToString();
            DrawRoute(rpop.GetChromosomes().ElementAt(0) as Route, Color.Black);
        }

        /// <summary>
        /// This will be deleted later, its just for having an easy place to test code for compilation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFuncTest_Click(object sender, EventArgs e)
        {
            //pc.RunGenerationCycle();

            //Step 3. The selected bit from Step  2 would be found in first parent
            //and pick the exact same position bit which is in second parent
            //and that bit would be found again in the first parent and,
            //finally, the exact same position bit which is in second parent will be selected for 1st bit of second offspring.

            //Step 4.The selected bit from Step 3 would be found in first parent
            //and pick the exact same position bit which is in second parent as the next bit for first offspring.
            //(Note: for the first offspring, we choose bits only with one move and two moves for second offspring’s bits.)

            // 1, 2, 3, 4
            // 3, 1, 4, 2

            // O1: 3, 1, 2, 4
            // O2: 2, 4, 3, 1

            // 3, 4, 8, 2, 7, 1, 6, 5
            // 4, 2, 5, 1, 6, 8, 3, 7

            // O1: 4, 8, 6, 2 
            // O2: 1, 7, 4

            int[] parent1 = { 3, 4, 8, 2, 7, 1, 6, 5 };
            int[] parent2 = { 4, 2, 5, 1, 6, 8, 3, 7 };

            int[] offspring1 = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] offspring2 = { 0, 0, 0, 0, 0, 0, 0, 0 };


            int firstBit = parent2[0];
            int secondBit;
            int thirdBit;

            // selected first bit of second parent for the starting point
            
            for (int i = 0; i < parent1.Length; i++)
            {
                offspring1[i] = firstBit;

                // look for this value in the first parent, save the index 
                for (int n = 0; n < 8; n++)
                {
                    if (parent1[n] == firstBit)
                    {
                        // Once we have found the matching value in the first parent grab the value in the same index from the second parent
                        secondBit = parent2[n];

                        // look for that value in the first parent
                        for (int m = 0; m < 8; m++)
                        {
                            if (parent1[m] == secondBit)
                            {
                                //once that value has been found store the value of the second parent in the same index to the first offspring
                                offspring2[i] = parent2[m];                               
                                thirdBit = parent2[m];

                                for (int k = 0; k < 8; k++)
                                {
                                    if (parent1[k] == thirdBit)
                                    {
                                        firstBit = parent2[k];
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

            firstBit = 2;

            // O1: 4, 
            // O2: 1

        }
    }
}
