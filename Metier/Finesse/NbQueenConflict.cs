using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Finesse
{
    class NbQueenConflict : FinesseStrategy
    {
        public int compute(Board board) {
            int[] positions = board.Positions;
            int fitness = 0;

            for (int i = 0; i < positions.Length; i++)
            {
                for (int j = i + 1; j < positions.Length; j++)
                {
                    int diff = j - i;
                    if (positions[i] + diff == positions[j] ||
                        positions[i] - diff == positions[j])
                    {
                        fitness++;
                    }
                }
            }

            return fitness;
        }
    }
}
