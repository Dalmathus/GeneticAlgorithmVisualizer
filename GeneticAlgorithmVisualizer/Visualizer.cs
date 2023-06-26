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
        private const int SIZE = 50;
        private const int LOCATIONS = 75;
        private int cellSize;

        public Visualizer()
        {
            InitializeComponent();
            InitializeGrid();
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
            _map = new Map(SIZE);
            _map.InstantiateGridPoints(LOCATIONS);
            DrawGrid();
            DrawLocations();
            labelBDText.Text = "";
        }

        private void DrawRoute(Route route)
        {
            Random rnd = new Random();            
            List<Gene> itinerary = route.GetGenes();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            int offset = cellSize / 2;

            using (Graphics g = this.TravelMap.CreateGraphics())
            {
                Pen p = new Pen(randomColor, 2);

                foreach (Movement gene in itinerary)
                {
                    int x1, x2, y1, y2;

                    // Redundant assignment but might refactor this in a more complicated way later
                    x1 = gene.GetPoint1().GetX();
                    x2 = gene.GetPoint2().GetX();
                    y1 = gene.GetPoint1().GetY();
                    y2 = gene.GetPoint2().GetY();

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
            DrawRoute(r);
            labelBDText.Text = r.GetFitness().ToString();
        }

        private void EstablishRandomRoutesAndDraw()
        {
            //RoutePopulation rpop = new RoutePopulation();
            //
            //for (int x = 0; x < 100; x++)
            //{
            //    Route r = new Route();
            //    r.GenerateRandomChromosome();
            //    rpop.Add(r);
            //}
            //
            //rpop.Sort();
            //labelBDText.Text = rpop.GetPopulation().ElementAt(0).GetFitness().ToString();
            //
            //foreach (Route rq in rpop.GetPopulation())
            //{
            //    DrawRoute(rq);
            //}
        }

        /// <summary>
        /// This will be deleted later, its just for having an easy place to test code for compilation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFuncTest_Click(object sender, EventArgs e)
        {
            //List<Chromosome> testList = new List<Chromosome>();
            //Route route = new Route();
            //route.GenerateRandomChromosome();
            //testList.Add(route);
        }
    }
}
