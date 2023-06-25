using GeneticAlgorithmVisualizer.Travelplan.Contstraints;
using GeneticAlgorithmVisualizer.Travelplan.Entities;
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
        private const int SIZE = 20;
        private const int LOCATIONS = 10;
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
            List<Movement> itinerary = route.GetLocations();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            int offset = cellSize / 2;

            using (Graphics g = this.TravelMap.CreateGraphics())
            {
                Pen p = new Pen(randomColor, 2);

                for (int i = 0; i < itinerary.Count; i++)
                {

                    int x1, x2, y1, y2;

                    // Redundant assignment but might refactor this in a more complicated way later
                    x1 = itinerary[i].GetPoint1().GetX();
                    x2 = itinerary[i].GetPoint2().GetX();
                    y1 = itinerary[i].GetPoint1().GetY();
                    y2 = itinerary[i].GetPoint2().GetY();

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
            Route route = new Route(_map);
            route.GenerateRandomRoute();
            DrawRoute(route);
            labelBDText.Text = route.GetDistance().ToString();  
        }

        private void buttonRouteMap_Click(object sender, EventArgs e)
        {            
            EstablishRandomRoutesAndDraw();
        }

        private void EstablishRandomRoutesAndDraw()
        {
            RoutePopulation rpop = new RoutePopulation();

            for (int x = 0; x < 100; x++)
            {
                Route r = new Route(_map);
                r.GenerateRandomRoute();
                rpop.Add(r);
            }

            rpop.SortRoutes();

            labelBDText.Text = rpop.GetRoutes().ElementAt(0).GetDistance().ToString();

            foreach (Route rq in rpop.GetRoutes())
            {
                DrawRoute(rq);
            }
        }
    }
}
