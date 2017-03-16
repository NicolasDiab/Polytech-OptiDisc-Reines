using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Neighbours
{
    class Swap : NeighboursStrategy
    {
        public List<Board> compute(Board board) {
            List<Board> neighbours = new List<Board>();
            for (int i = 0; i < board.Positions.Length; i++)
            {
                for (int j = i + 1; j < board.Positions.Length; j++)
                {
                    neighbours.Add(new Board(this.switchPosition(board.Positions, i, j),board.NbQueen,board.Y));
                }
            }
            return neighbours;
        }

        private int[] switchPosition(int[] paramTab, int i, int j)
        {
            int[] positions = (int[])paramTab.Clone();
            int temp = positions[i];
            positions[i] = positions[j];
            positions[j] = temp;
            return positions;
        }
    }
}
