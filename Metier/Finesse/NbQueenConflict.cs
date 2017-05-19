using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Finesse
{
    public class NbQueenConflict : FinesseStrategy
    {
        public int compute(Board board)
        {
            int[] positions = board.Positions;
            int fitness = 0;
            int j;
            int diff;
            for (int i = 0; i < positions.Length; i++)
            {
                for (j = i + 1; j < positions.Length; j++)
                {
                    diff = j - i;
                    if (positions[i] + diff == positions[j] ||
                        positions[i] - diff == positions[j])
                    {
                        fitness++;
                    }
                }
            }

            return fitness;
        }

        public int compute(GeneticBoard board)
        {
            /*int[] positions = board.Positions;
            int i,j,n;
            n = board.N;
            for (i = 0; i < n; i++ ) {
                for (j = 0; j < n; j++)
                {
                    int value = positions[i * n + j];
                }
            }*/
            int finesse = 0;

            for (int index = 0; index < board.N; index++)
            {
                finesse += checkLigne(board.Positions, index, board.N);
                finesse += checkDiagonal(board.Positions, index, board.N);
            }
            return finesse;

        }

        private int checkLigne(int[] position, int i, int n)
        {
            int nbQueenC = 0;
            int nbQueenL = 0;
            for (int index = 0; index < n; i++)
            {
                if (position[index + i * n] == 1)
                    nbQueenL++;
                if (position[index * n + i] == 1)
                    nbQueenC++;
            }
            
            return ((nbQueenC > 1)? nbQueenC : 0) + ((nbQueenL > 1) ? nbQueenL : 0);
        }



        private int checkDiagonal(int[] position, int i, int n) {
            int nbQueen = 0;
            int max = position.Length;
            int stepDiag1 = n + 1;
            int stepDiag2 = n - 1;
            int nbQueenR = 0;
            int nbQueenL = 0;
            int nbQueenR2 = 0;
            int nbQueenL2 = 0;


            for (int index = i; index < n; i++) {
                if (i == 0)
                {
                    if (position[index * stepDiag1] == 1)
                        nbQueenL++;
                    if (position[n + index *stepDiag2] == 1)
                        nbQueenR++;
                }
                else {
                    if (position[i + index * stepDiag1] == 1)
                        nbQueenR++;
                    if (position[n * i + index * stepDiag1] == 1)
                        nbQueenL++;
                    if (position[(n - i) + index * stepDiag2] == 1)
                        nbQueenR2++;
                    if (position[n * i + index * stepDiag2] == 1)
                        nbQueenL2++;
                }
                
            }
            return ((nbQueenR > 1) ? nbQueenR : 0) +
                ((nbQueenL > 1) ? nbQueenL : 0)  +
                ((nbQueenL2 > 1) ? nbQueenL2 : 0) +
                ((nbQueenR2 > 1) ? nbQueenR2 : 0);

        }
    }
}
