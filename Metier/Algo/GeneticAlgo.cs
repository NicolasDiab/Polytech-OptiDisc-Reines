using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class GeneticAlgo : Algo
    {
        private List<Board> x0;
        private List<Board> currentGeneration;
        private int nbGeneration;
        private int currentNumberGeneration;

        public GeneticAlgo(List<Board> x0, int nbGeneration) {
            this.nbGeneration = nbGeneration;
            this.x0 = x0;
        }

        public override string getAdvancement()
        {
            throw new NotImplementedException();
        }

        protected override void algo()
        {
            List<Board> nextGeneration;
            currentGeneration = x0;
            for (currentNumberGeneration = 0; currentNumberGeneration < nbGeneration; currentNumberGeneration++) {
                nextGeneration = new List<Board>();
                nextGeneration.AddRange(this.reproduction(currentGeneration));
                nextGeneration.AddRange(this.mutation(currentGeneration));
                nextGeneration.AddRange(this.crossing(currentGeneration));
                currentGeneration = this.naturalSelection(nextGeneration);
            }
        }

        private List<Board> mutation(List<Board> x)
        {
            throw new NotImplementedException();
        }
        

        private List<Board> reproduction(List<Board> x)
        {
            throw new NotImplementedException();
        }

        private List<Board> crossing(List<Board> x)
        {
            throw new NotImplementedException();
        }

        private List<Board> naturalSelection(List<Board> x)
        {
            throw new NotImplementedException();
        }
    }
}
