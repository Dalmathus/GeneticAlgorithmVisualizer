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
        private const int LOCATIONS = 8;
        private int cellSize;
        private PopulationController pc;

        public Visualizer()
        {
            InitializeComponent();
            //InitializeGrid();

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
                    //g.FillRectangle(b, location.GetX() * cellSize, location.GetY() * cellSize, cellSize, cellSize);                  
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
                    x1 = 0; //ep.GetX();
                    y1 = 0; //ep.GetY();
                          
                    x2 = 0; //dp.GetX();                    
                    y2 = 0; //dp.GetY();

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

            Location l = new Location(1);

            Location d = new Location(2);

            //pc.RunGenerationCycle();
        }
    }
}
