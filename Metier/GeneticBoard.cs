using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class GeneticBoard : Board
    {
        public GeneticBoard(int[] positions, int n, KeyValuePair<int, int> transition) : base(positions,n,transition)
        {
        }

        public GeneticBoard(int[] positions, int n) : base(positions, n)
        {
        }

        public GeneticBoard(int n) : base(n)
        {
            this.Positions = buildSolution(n);
        }

        protected override int[] buildSolution(int n)
        {
            int[] positions = new int[n*n];

            for (int i = 0; i < n; i++)
            {
                positions[i * (n + 1)] = 1;
            }

            return positions;
        }

        protected int[] buildRandomSolution(int n)
        {
            int[] positions = new int[n * n];

            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                bool ok = false;
                while(!ok)
                {
                    int pos = rand.Next(0, positions.Length - 1);
                    if (positions[pos] == 0)
                    {
                        positions[pos] = 1;
                        ok = true;
                    }
                }
            }

            return positions;
        }

        public void muter()
        {
            int mutationPosition = new Random().Next(0, this.Positions.Length - 1);

            int currentValue = Positions[mutationPosition];

            this.Positions[mutationPosition] = currentValue == 1 ? 0 : 1; // reverse the int - if 1 --> return 0 else 1
            // then reverse another 1/0 to equilibrate the total number of queens

            bool ok = false;
            while (!ok)
            {
                int mutationPosition2 = new Random().Next(0, this.Positions.Length - 1);
                if (this.Positions[mutationPosition2] != currentValue)
                {
                    this.Positions[mutationPosition2] = currentValue == 1 ? 0 : 1; // reverse the int
                    ok = true;
                }
            }
        }

        public static List<GeneticBoard> getFirstGeneration(int nbSolutions, int boardSize)
        {
            List<GeneticBoard> firstGeneration = new List<GeneticBoard>();

            for (int i=0; i < nbSolutions; i++)
            {
                GeneticBoard board = new GeneticBoard(boardSize);
                int[] ret = board.buildRandomSolution(boardSize);
                board.Positions = ret;

                firstGeneration.Add(board);
            }

            return firstGeneration;
        }

    }
}
