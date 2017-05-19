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
        private int n;
        private KeyValuePair<int, int> transition;

        public int[] Positions { get => positions; set => positions = value; }
        public int N { get => n; }
        public KeyValuePair<int, int> Transition { get => transition; set => transition = value; }

        public Board(int[] positions, int n, KeyValuePair<int,int> transition)
        {
            this.positions = positions;
            this.n = n;
            this.Transition = transition;
        }

        public Board(int[] positions, int n)
        {
            this.positions = positions;
            this.n = n;
        }

        public Board(int n)
        {
            this.positions = this.buildSolution(n);
            this.n = n;

        }

        protected virtual int[] buildSolution(int n) {
            int[] positions = new int[n];

            for (int i = 0; i < n; i++)
            {
                positions[i] = i + 1;
            }

            return positions;
        }




    }
}
