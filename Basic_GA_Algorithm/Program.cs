using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_GA_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int generation = 0;

            var population = new List<Individual>();
            bool found = false;

            // create initial population
            for (int i = 0; i < BaseInfo.PopulationSize; i++)
            {
                string gnome = Helper.CreateGnome();
                population.Add(new Individual(gnome));
            }

            while (!found)
            {
                bool stopCriterion = (population[0].Fitness >= BaseInfo.Target.Length);
                // sort the population in increasing order of fitness score
                population = population.OrderByDescending(x => x.Fitness).ToList();

                // if the individual having lowest fitness score ie.
                // 0 then we know that we have reached to the target
                // and break the loop
                if (stopCriterion)
                {
                    found = true;
                    break;
                }

                // Otherwise generate new offsprings for new generation
                var new_generation = new List<Individual>();

                // Perform Elitism, that mean 10% of fittest population
                // goes to the next generation
                int s = (10 * BaseInfo.PopulationSize) / 100;
                for (int i = 0; i < s; i++)
                    new_generation.Add(population[i]);

                // From 50% of fittest population, Individuals
                // will mate to produce offspring
                s = (90 * BaseInfo.PopulationSize) / 100;
                for (int i = 0; i < s; i++)
                {
                    int len = population.Count();
                    int r = Helper.RandomNumber(0, 50);
                    Individual parent1 = population[r];

                    r = Helper.RandomNumber(0, 50);
                    Individual parent2 = population[r];

                    Individual offspring = parent1.Mate(parent2);
                    new_generation.Add(offspring);
                }
                population = new_generation;

                Console.WriteLine(string.Format("Generation: {1}{0}String: {2}{0}Fitness: {3}{0}---------------",
                                    Environment.NewLine,generation, population[0].
                                    Chromosome, population[0].Fitness));
                generation++;
            }
            Console.WriteLine(string.Format("Generation: {1}{0}String: {2}{0}Fitness: {3}{0}",
                                Environment.NewLine,generation , population[0].
                                Chromosome , population[0].Fitness));

            Console.ReadKey();
        }
    }
}
