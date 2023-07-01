using GeneticAlgorithmVisualizer.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithmVisualizer.Travelplan.Contstraints
{
    internal class Map : RuleSet
    {
        private List<Tuple<int, int>> _points;              
        private int _mapSize;

        public Map(int populationSize, int chromosomeSize, int mapSize)
        {
            _populationSize = populationSize;
            _chromosomeSize = chromosomeSize;
            _mapSize = mapSize;
            _points = new List<Tuple<int, int>>();

            InstantiateGridPoints();
        }

        private void InstantiateGridPoints()
        {
            int points = _chromosomeSize;
            Random random = new Random(Guid.NewGuid().GetHashCode());

            //randomly assign spots locations until we have hit max, ignore roll if already assigned
            //I'm pretty sure unless I go insane with a million points this is faster than generating all possible
            //locations and plucking them deterministically, but I guess this is theoretically possible to never complete.
            while (points > 0)
            {
                Tuple<int, int> l = new Tuple<int, int>(random.Next(0, _mapSize), random.Next(0, _mapSize));
                if (_points.Contains(l)) continue;
                _points.Add(l);
                points--;
            }
        }

        public List<Tuple<int, int>> GetDestinations()
        {
            return _points;
        }

        public Tuple<int, int> GetDestinationByIndex(int index)
        {
            return _points.ElementAt(index);
        }

    }
}
