using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.Travelplan.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Travelplan.Contstraints
{
    internal class Map : RuleSet
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
            //I'm pretty sure unless I go insane with a million points this is faster than generating all possible
            //locations and plucking them deterministically, but I guess this is theoretically possible to never complete.
            while (points > 0)
            {
                Location l = new Location(random.Next(0, _size));
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
