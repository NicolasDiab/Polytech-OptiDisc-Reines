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
        private int y;
        private int nbQueen;

        public int[] Positions { get => positions; }
        public int Y { get => y; }
        public int NbQueen { get => nbQueen; }

        public Board(int[] positions, int nbQueen, int y)
        {
            this.positions = positions;
            this.nbQueen = nbQueen;
        }

        public Board(int nbQueen, int x, int y)
        {
            this.positions = this.buildSolution(nbQueen,x,y);
            this.nbQueen = nbQueen;
            this.y = y;
        }

        private int[] buildSolution(int nbQueen, int x, int y) {
            int[] positions = new int[x];

            for (int i = 0; i < nbQueen; i++) {
                if (i > x)
                    throw new Exception("le nombre de dame est supérieur au nombre ligne");
                if (i > y)
                    throw new Exception("le nombre de dame est supérieur au nombre colonne");
                positions[i] = i + 1;
            }

            return positions;
        }


    }
}
