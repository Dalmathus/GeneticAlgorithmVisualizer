using GeneticAlgorithmVisualizer.PopulationEntities;
using GeneticAlgorithmVisualizer.Travelplan.Genetics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmVisualizer.Genetics
{
    internal class PopulationController
    {
        protected List<Population> _populations;
        
        protected PopulationGenerator pg;        
        protected PopulationCrossover pc;
        protected PopulationMutator pm;
        protected PopulationFitnessEvalutator pfe;
        protected PopulationSelector ps;

        private int _generations;

        public PopulationController(string[] args)
        {
            _populations = new List<Population>();
            _generations = 0;

            // Instantiate the process queue,
            // possibly going to just make these all static later
            // but might want multiple threads running at once as different objects
            pg = new RoutePopulationGenerator();
            pc = new PopulationCrossover();
            pm = new PopulationMutator();
            pfe = new PopulationFitnessEvalutator();
            ps = new PopulationSelector();

            switch (args[1])
            {
                case "travelplan":
                    System.Console.WriteLine("Running the Travelling Salesman problem");
                    break;
                default: System.Console.WriteLine("No Argument Provided");
                    break;
            }
        }

        /// <summary>
        /// Will refactor this down a level to travelling salesman specific iteration 
        /// but want to build a base first to see what can be extended
        /// </summary>
        public void RunGenerationCycle()
        {
            if (_generations == 0)
            {
                // Create the first generation
                pg.GenerateRandomPopulation(null);
            } else
            {
                // Iterate on the next generation
            }

            // Perform Crossover

            // Perform Mutation

            // Evaluate the Fitness of the Generation and Individual Chromosomes

            // Sort the Population

            // Select Surviors
        }
        
    }
}
