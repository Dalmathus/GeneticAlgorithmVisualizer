using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithmVisualizer.Genetics
{
    public class PopulationController
    {
        protected List<Population> _populations;
        
        protected PopulationGenerator _pg;        
        protected PopulationCrossover _pc;
        //protected PopulationMutator _pm;
        protected PopulationFitnessEvalutator _pfe;
        //protected PopulationSelector _ps;

        protected RuleSet _ruleSet;

        private int _generations;

        private Random _rand;
        private double _crossoverRate = 0.5d;

        public PopulationController(RuleSet ruleSet, string[] args)
        {
            _populations = new List<Population>();
            _generations = 0;
            _ruleSet = ruleSet;
            _rand = new Random(Guid.NewGuid().GetHashCode());

            // Instantiate the process queue,
            // possibly going to just make these all static later
            // but might want multiple threads running at once as different objects
            _pg = new PopulationGenerator();
            _pc = new PopulationCrossover();
            //_pm = new PopulationMutator();
            _pfe = new PopulationFitnessEvalutator();
            //_ps = new PopulationSelector();
        }

        /// <summary>
        /// Will refactor this down a level to travelling salesman specific iteration 
        /// but want to build a base first to see what can be extended
        /// </summary>
        public void RunGenerationCycle()
        {
            Population iterationPopulation;

            if (_generations == 0)
            {
                // Create the first generation
                iterationPopulation = _pg.GenerateRandomPopulation(_ruleSet);
            }
            else
            {
                // Iterate on the previous generation
                iterationPopulation = _pg.CopyPopulation(_populations[_generations - 1]);
            }

            List<Chromosome> newOffspring = new List<Chromosome>();

            // Perform Crossover
            foreach (Chromosome chromosome in iterationPopulation.GetChromosomes())
            {
                if (_rand.NextDouble() < _crossoverRate)
                {
                    Tuple<Chromosome, Chromosome> offspring = PopulationCrossover.CycleCrossover(chromosome, iterationPopulation.GetChromosomes().ElementAt(_rand.Next(0, iterationPopulation.GetChromosomes().Count)));
                    newOffspring.Add(offspring.Item1);
                    newOffspring.Add(offspring.Item2);
                }
            }

            // Add the new offspring
            foreach (Chromosome chromosome in newOffspring)
            {
                iterationPopulation.Add(chromosome);
            }

            // Perform Mutation

            // Evaluate the Fitness of the Individual Chromosomes within the population
            _pfe.EvaulateFitness(iterationPopulation, _ruleSet);

            // Sort the Population
            iterationPopulation.Sort();

            // Select Surviors
            if (iterationPopulation.GetChromosomes().Count - _ruleSet.GetPopulationSize() > 0)
                iterationPopulation.GetChromosomes().RemoveRange(_ruleSet.GetPopulationSize(), iterationPopulation.GetChromosomes().Count - _ruleSet.GetPopulationSize());

            // Iterate the Generation #
            _populations.Add(iterationPopulation);
            _generations++;
        }

        public List<Population> GetPopulations()
        {
            return this._populations;
        }

        public int GetGeneration()
        {
            return this._generations;
        }
    }
}
