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
            FinesseStrategy = new NbQueenConflict();
        }

        public override string getAdvancement()
        {
            return Math.Round(((double)currentGenerationNumber / (double)nbGeneration),3) * 100 + " % ";
        }

        protected override void algo()
        {
            List<GeneticBoard> nextGeneration;
            currentGeneration = firstGeneration;
            for (currentGenerationNumber = 0; currentGenerationNumber < nbGeneration; currentGenerationNumber++) {
                nextGeneration = new List<GeneticBoard>();
                nextGeneration.AddRange(this.reproduction(currentGeneration));
                nextGeneration.AddRange(this.mutation(currentGeneration));
                nextGeneration.AddRange(this.crossing(currentGeneration));
                currentGeneration = nextGeneration;
            }
        }



        private List<GeneticBoard> mutation(List<GeneticBoard> x)
        {
            throw new NotImplementedException();
        }
        

        private List<GeneticBoard> reproduction(List<GeneticBoard> x)
        {
            throw new NotImplementedException();
        }

        private List<GeneticBoard> crossing(List<GeneticBoard> x)
        {
            throw new NotImplementedException();
        }

    }
}
