using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Neighbours
{
    public class Swap : NeighboursStrategy
    {
        public List<Board> compute(Board board, Dictionary<int, int> tabuList = null)
        {
            List<Board> neighbours = new List<Board>();
            int j;
            for (int i = 0; i < board.Positions.Length; i++)
            {
                for (j = i + 1; j < board.Positions.Length; j++)
                {
                    if (tabuList == null || !(tabuList[i] == j))
                        neighbours.Add(new Board(this.switchPosition(board.Positions, i, j), board.N, new KeyValuePair<int, int>(i, j)));
                }
            }
            return neighbours;
        }

        protected int[] switchPosition(int[] paramTab, int i, int j)
        {
            int[] positions = (int[])paramTab.Clone();
            int temp = positions[i];
            positions[i] = positions[j];
            positions[j] = temp;
            return positions;
        }
    }
}
