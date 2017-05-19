using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Neighbours
{
    class RandomSwap : Swap
    {
        public new List<Board> compute(Board board, Dictionary<int, int> tabuList = null)
        {
            Random random = new Random();
            int i = random.Next(board.N);
            int j = random.Next(board.N);
            while (j == i) {
                j = random.Next(board.N);
            }
            List<Board> boards = new List<Board>();
            boards.Add(getRandomNeighbours(board));
            return boards;
        }

        protected Board getRandomNeighbours(Board board) {
            Random random = new Random();
            int i = random.Next(board.N);
            int j = random.Next(board.N);
            while (j == i)
            {
                j = random.Next(board.N);
            }
            return new Board(this.switchPosition(board.Positions, i, j), board.N);
        }
    }
}
