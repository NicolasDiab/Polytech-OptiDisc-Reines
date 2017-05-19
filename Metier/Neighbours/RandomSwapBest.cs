using Metier.Finesse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Neighbours
{
    class RandomSwapBest : RandomSwap
    {
        private int n;
        FinesseStrategy finesse;

        public RandomSwapBest(int n, FinesseStrategy finesse) {
            this.n = n;
        }

        public new List<Board> compute(Board board, Dictionary<int, int> tabuList = null)
        {
            Board temp, best = this.getRandomNeighbours(board);           
            int tempF, bestF = finesse.compute(best);
            for (int i = 1; i < n; i++) {
                temp = this.getRandomNeighbours(board);
                tempF = finesse.compute(temp);
                if (tempF > bestF) {
                    bestF = tempF;
                    best = temp;
                }
            }
            List<Board> list = new List<Board>();
            list.Add(best);
            return list;
        }
    }
}
