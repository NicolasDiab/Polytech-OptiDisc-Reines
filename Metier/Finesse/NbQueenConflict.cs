using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Finesse
{
    public class NbQueenConflict : FinesseStrategy
    {
        public int compute(Board board) {
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
            throw new NotImplementedException();
        }
    }
}
