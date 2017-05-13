using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class GeneticBoard : Board
    {
        public GeneticBoard(int[] positions, int n, KeyValuePair<int, int> transition) : base(positions,n,transition)
        {
        }

        public GeneticBoard(int[] positions, int n) : base(positions, n)
        {
        }

        public GeneticBoard(int n) : base(n)
        {
        }


        protected override int[] buildSolution(int n)
        {
            int[] positions = new int[n];
            int q = 0;

            for (int i = 0; i < n * n; i++)
            {
                positions[i] = (i % (n + q) == 0) ? 1 : 0;
            }

            return positions;
        }
    }
}
