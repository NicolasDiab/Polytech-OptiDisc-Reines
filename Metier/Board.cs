using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Board
    {
        // Tableau de 8 valeurs, où positions[0] donne la valeur de la colonne pour la ligne 0
        private int[] positions;

        public Board(int[] positions)
        {
            this.positions = positions;
        }

        public Board()
        {
            // génére soluce
            this.positions = new int[] { 1,2,3,4,5,6,7,8 };
        }

        public int[] getPositions()
        {
            return positions;
        }

        public bool checkSolution()
        {
            return true;
        }

        //idée 1 : échanger 2 cases du tableau
        public List<Board> findNeighboursSwitch()
        {
            List<Board> neighbours = new List<Board>();
            for (int i = 0; i < this.positions.Length; i++)
            {
                for (int j = i + 1; j < this.positions.Length; j++)
                {
                    neighbours.Add(new Board(this.switchPosition(this.positions, i, j)));
                }
            }
            return neighbours;
        }

        public int[] switchPosition(int[] paramTab, int i, int j)
        {
            int[] positions = (int[])paramTab.Clone();
            int temp = positions[i];
            positions[i] = positions[j];
            positions[j] = temp;
            return positions;
        }

        public int finesseNbSquaresConflicting()
        {
            int fitness = 0;
            
            return fitness;
        }

        public int finesseNbQueensConflicting()
        {
            int fitness = 0;

            for (int i = 0; i < this.positions.Length; i++)
            {
                for (int j = i + 1; j < this.positions.Length; j++)
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

        public Board getRandomNeighbour(List<Board> neighbours)
        {
            int i = new Random().Next(0, neighbours.Count);
            return neighbours.ElementAt(i);
        } 
    }
}
