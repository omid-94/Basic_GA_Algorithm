using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_GA_Algorithm
{
    public class Individual
    {
        public string Chromosome { get; set; }
        public int Fitness { get; set; }
        public Individual(string chromosome)
        {
            this.Chromosome = chromosome;
            this.Fitness = CalculateFitness();
        }
        public Individual Mate(Individual parent2)
        {
            string child_chromosome = "";

            int len = Chromosome.Length;
            for (int i = 0; i < len; i++)
            {
                // random probability
                float p = Helper.RandomNumber(0, 100) / 100;

                // if prob is less than 0.45, insert gene
                // from parent 1
                if (p < 0.45)
                    child_chromosome += Chromosome[i];

                // if prob is between 0.45 and 0.90, insert
                // gene from parent 2
                else if (p < 0.90)
                    child_chromosome += parent2.Chromosome[i];

                // otherwise insert random gene(mutate),
                // for maintaining diversity
                else
                    child_chromosome += Helper.MutatedGenes();
            }

            // create new Individual(offspring) using
            // generated chromosome for offspring
            return new Individual(child_chromosome);
        }
        public int CalculateFitness()
        {
            int len = BaseInfo.Target.Length;
            int fitness = 0;
            for (int i = 0; i < len; i++)
            {
                if (Chromosome[i] != BaseInfo.Target[i])
                    fitness++;
            }
            return fitness;
        }

        public static bool operator < (Individual ind1, Individual ind2)
        {
	        return ind1.Fitness < ind2.Fitness;
        }
        public static bool operator > (Individual ind1, Individual ind2)
        {
            return ind1.Fitness > ind2.Fitness;
        }
    }
}
