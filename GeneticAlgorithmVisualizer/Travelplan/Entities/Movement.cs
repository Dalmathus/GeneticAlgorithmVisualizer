using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Travelplan.Entities
{
    internal class Movement : Gene
    {
        private int _distance; //Allele
        private Location _point1, _point2;

        public Movement(Location p1, Location p2) 
        {
            _point1 = p1;
            _point2 = p2;

            // Manhattan Distance |x2 - x1| + |y2 - y1|
            _distance = (Math.Abs(p2.GetX() - p1.GetX())) + (Math.Abs(p2.GetY() - p1.GetY()));
        }

        public int GetDistance()
        {
            return _distance;
        }

        public Location GetPoint1()
        {
            return _point1;
        }
        
        public Location GetPoint2()
        {
            return _point2;
        }
    }
}
