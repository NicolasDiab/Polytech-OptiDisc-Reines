using Metier.Finesse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class GeneticAlgo : Algo
    {

        private List<GeneticBoard> firstGeneration;
        private List<GeneticBoard> currentGeneration;
        private int nbGeneration;
        private int currentGenerationNumber;

        public GeneticAlgo(List<GeneticBoard> firstGeneration, int nbGeneration) {
            this.nbGeneration = nbGeneration;
            this.firstGeneration = firstGeneration;
            this.FinesseStrategy = new NbQueenConflict();
        }

        public override string getAdvancement()
        {
            return Math.Round(((double)this.currentGenerationNumber / (double)this.nbGeneration),3) * 100 + " % ";
        }

        protected override void algo()
        {
            List<GeneticBoard> nextGeneration;
            currentGeneration = firstGeneration;
            for (this.currentGenerationNumber = 0; this.currentGenerationNumber < this.nbGeneration; this.currentGenerationNumber++) {
                nextGeneration = new List<GeneticBoard>();
                nextGeneration.AddRange(this.reproduction(this.currentGeneration));
                nextGeneration.AddRange(this.mutation(this.currentGeneration, 0.05));
                nextGeneration.AddRange(this.crossOver(this.currentGeneration, 10));
                this.currentGeneration = nextGeneration;
            }
        }



        private List<GeneticBoard> mutation(List<GeneticBoard> x, double probability)
        {
            List<GeneticBoard> solutions = x;
            Random rand = new Random();

            foreach (GeneticBoard solution in solutions)
            {
                if (rand.Next(0, 1) <= probability)
                {
                    solution.muter();
                }
            }

            return solutions;
        }
        

        private List<GeneticBoard> reproduction(List<GeneticBoard> x)
        {
            throw new NotImplementedException();
        }
        
        private List<GeneticBoard> crossOver(List<GeneticBoard> x, int numberCrossOver)
        {
            List<GeneticBoard> solutions = x;
            Random rand = new Random();

            for (int i = 0; i < numberCrossOver; i++)
            {
                // select 2 parents
                int indexParent1 = rand.Next(0, solutions.Count);
                int indexParent2 = rand.Next(0, solutions.Count);
                GeneticBoard parent1 = solutions[indexParent1];
                GeneticBoard parent2 = solutions[indexParent2];

                // create 2 children - slice parents at the middle
                GeneticBoard children1 = parent1;
                children1.Positions = parent1.Positions.Take(parent1.Positions.Length / 2).Concat(parent2.Positions.Skip(parent2.Positions.Length / 2)).ToArray();

                GeneticBoard children2 = parent2;
                children2.Positions = parent2.Positions.Take(parent2.Positions.Length / 2).Concat(parent1.Positions.Skip(parent1.Positions.Length / 2)).ToArray();

                // in the tab, replace the parents with the children
                solutions[indexParent1] = children1;
                solutions[indexParent2] = children2;
            }

            return solutions;
        }

    }
}
