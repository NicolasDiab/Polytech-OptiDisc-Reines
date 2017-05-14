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
            
            for (int i = 0; i < numberCrossOver; i++)
            {
                // select 2 parents
                int indexParent1 = 0;
                int indexParent2 = 0;
                GeneticBoard parent1 = null;
                GeneticBoard parent2 = null;
                // create 2 children
                GeneticBoard children1 = null;
                GeneticBoard children2 = null;
                // in the tab, replace the parents with the children

            }

            return solutions;
        }

    }
}
