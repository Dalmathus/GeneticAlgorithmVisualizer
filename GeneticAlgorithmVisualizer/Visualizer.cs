using GeneticAlgorithmVisualizer.Genetics;
using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Contstraints;
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
        private const int POPULATION = 50000;
        private const int LOCATIONS = 25;
        private int cellSize;
        private PopulationController pc;

        public Visualizer()
        {
            InitializeComponent();
            InitializeGrid();

            string[] args = { "travelplan" }; // This does nothing.
            pc = new PopulationController(_map, args);
        }

        private void InitializeGrid()
        {
            _map = new Map(POPULATION, LOCATIONS, SIZE);
            cellSize = (this.TravelMap.Size.Width - 1) / SIZE;        
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
                List<Tuple<int, int>> points = _map.GetDestinations();

                // print all rectangles that have been designated as location
                foreach (Tuple<int, int> point in points) 
                {
                    g.FillRectangle(b, point.Item1 * cellSize, point.Item2 * cellSize, cellSize, cellSize);                  
                }
            }
        }

        private void ResetGrid()
        {
            this.SuspendLayout();
            this.TravelMap.Refresh();            
            DrawGrid();
            DrawLocations();
            labelBDText.Text = "";
            this.ResumeLayout();
        }

        private void DrawRoute(Chromosome route, Color c)
        {
            this.SuspendLayout();

            List<Tuple<int, int>> points = _map.GetDestinations();

            int offset = cellSize / 2;

            using (Graphics g = this.TravelMap.CreateGraphics())
            {

                Pen p = new Pen(c, 2);

                for (int i = route.GetGenes().Count - 1; i > 0; i--) {

                    Tuple<int, int> startPoint = _map.GetDestinationByIndex(route.GetGeneByIndex(i).GetValue());
                    Tuple<int, int> endPoint = _map.GetDestinationByIndex(route.GetGeneByIndex(i - 1).GetValue());

                    g.DrawLine(p,
                               startPoint.Item1 * cellSize + offset,
                               startPoint.Item2 * cellSize + offset,
                               endPoint.Item1 * cellSize + offset,
                               endPoint.Item2 * cellSize + offset);

                }

            }

            this.ResumeLayout();
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
            Chromosome r = ChromosomeGenerator.GenerateRandomIndexChromosome(_map);
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            DrawRoute(r, randomColor);
            ChromosomeFitnessCalculator.CalculateFitness(r, _map);
            labelBDText.Text = r.GetFitness().ToString();
        }

        private void EstablishRandomRoutesAndDraw()
        {
            PopulationGenerator rg = new PopulationGenerator();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            Population rpop = rg.GenerateRandomPopulation(_map);
            rpop.Sort();
            ResetGrid();

            ChromosomeFitnessCalculator.CalculateFitness(rpop.GetChromosomes().ElementAt(0), _map);
            labelBDText.Text = rpop.GetChromosomes().ElementAt(0).GetFitness().ToString();
            DrawRoute(rpop.GetChromosomes().ElementAt(0), Color.Black);
        }

        /// <summary>
        /// This will be deleted later, its just for having an easy place to test code for compilation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFuncTest_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                pc.RunGenerationCycle();

                Population population = pc.GetPopulations();
                Chromosome bestRoute = population.GetChromosomes()[0];
                ResetGrid();
                labelGeneration.Text = pc.GetGeneration().ToString();
                labelBDText.Text = bestRoute.GetFitness().ToString();
                DrawRoute(bestRoute, Color.Black);

            }         
        }
    }
}
