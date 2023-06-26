﻿using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Travelplan.Entities
{
    internal class Location : Allele
    {

        Tuple<int, int> _location;

        public Location(int x, int y) 
        {
            _location = new Tuple<int, int>(x, y);
        }

        public override bool Equals(Allele other)
        {
            Location otherL = other as Location; 

            if (this.GetX() == otherL.GetX() && this.GetY() == otherL.GetY())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetX()
        {
            return _location.Item1;
        }

        public int GetY()
        {
            return _location.Item2;
        }
    }
}
