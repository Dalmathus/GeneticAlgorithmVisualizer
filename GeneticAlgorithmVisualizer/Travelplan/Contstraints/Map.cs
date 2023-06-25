using GeneticAlgorithmVisualizer.Travelplan.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Travelplan.Contstraints
{
    internal class Map
    {
        private int _size;
        private List<Location> _locations;

        public Map(int size)
        {
            _size = size;
            _locations = new List<Location>();
        }

        public void InstantiateGridPoints(int locations)
        {
            int points = locations;
            Random random = new Random(Guid.NewGuid().GetHashCode());

            //randomly assign spots locations until we have hit max, ignore roll if already assigned
            while (points > 0)
            {
                Location l = new Location(random.Next(0, _size), random.Next(0, _size));
                if (_locations.Contains(l)) continue;
                _locations.Add(l);
                points--;
            }
        }

        public List<Location> GetDestinations()
        {
            return _locations;
        }

    }
}
