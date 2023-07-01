using GeneticAlgorithmVisualizer.Constraints;
using GeneticAlgorithmVisualizer.PopulationEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithmVisualizer.Genetics
{
    public class PopulationController
    {
        protected Population _previousPopulation;
        protected Population _currentPopulation;

        protected PopulationGenerator _pg;        
        protected PopulationCrossover _pc;
        //protected PopulationMutator _pm;
        protected PopulationFitnessEvalutator _pfe;
        //protected PopulationSelector _ps;

        protected RuleSet _ruleSet;

        private int _generations;

        private Random _rand;
        private double _crossoverRate = 0.3d;
        private double _mutationRate = 0.1d;

        public PopulationController(RuleSet ruleSet, string[] args)
        {
            _generations = 0;
            _ruleSet = ruleSet;
            _rand = new Random(Guid.NewGuid().GetHashCode());

            _previousPopulation = new Population();
            _currentPopulation = new Population();

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
            
            if (_generations == 0)
            {
                // Create the first generation
                _currentPopulation = _pg.GenerateRandomPopulation(_ruleSet);
            }
            else
            {
                // Iterate on the previous generation
                _currentPopulation = _pg.CopyPopulation(_previousPopulation);
            }

            List<Chromosome> newOffspring = new List<Chromosome>();

            // Perform Crossover
            foreach (Chromosome chromosome in _currentPopulation.GetChromosomes())
            {
                if (_rand.NextDouble() < _crossoverRate)
                {
                    Tuple<Chromosome, Chromosome> offspring = PopulationCrossover.CycleCrossover(chromosome, _currentPopulation.GetChromosomes().ElementAt(_rand.Next(0, _currentPopulation.GetChromosomes().Count)));
                    newOffspring.Add(offspring.Item1);
                    newOffspring.Add(offspring.Item2);
                }
            }

            // Add the new offspring
            foreach (Chromosome chromosome in newOffspring)
            {
                _currentPopulation.Add(chromosome);
            }

            // Perform Mutation
            foreach (Chromosome chromosome in _currentPopulation.GetChromosomes())
            {
                if (_rand.NextDouble() < _mutationRate)
                {
                    int index1 = _rand.Next(0, _ruleSet.GetChromosomeSize());
                    int index2 = _rand.Next(0, _ruleSet.GetChromosomeSize());

                    int holdOver = chromosome.GetGeneByIndex(index1).GetValue();
                    chromosome.SetGeneByIndex(index1, chromosome.GetGeneByIndex(index2).GetValue());
                    chromosome.SetGeneByIndex(index2, holdOver);
                }
            }

            // Evaluate the Fitness of the Individual Chromosomes within the population
            _pfe.EvaulateFitness(_currentPopulation, _ruleSet);

            // Sort the Population
            _currentPopulation.Sort();

            // Select Surviors
            if (_currentPopulation.GetChromosomes().Count - _ruleSet.GetPopulationSize() > 0)
                _currentPopulation.GetChromosomes().RemoveRange(_ruleSet.GetPopulationSize(), _currentPopulation.GetChromosomes().Count - _ruleSet.GetPopulationSize());

            // Iterate the Generation #
            _previousPopulation = _pg.CopyPopulation(_currentPopulation);
            _generations++;
        }

        public Population GetPopulations()
        {
            return this._currentPopulation;
        }

        public int GetGeneration()
        {
            return this._generations;
        }
    }
}
