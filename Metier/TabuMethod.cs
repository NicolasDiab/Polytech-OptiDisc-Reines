using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.Finesse;
using Metier.Neighbours;

namespace Metier
{
    public class TabuMethod : Algo
    {
        private NeighboursStrategy neighboursStrategy;
        private FinesseStrategy finesseStrategy;
        private Board x0;
        private int n1;
        private int n2;
        private Dictionary<int, int> tabuList;


        internal FinesseStrategy FinesseStrategy { get => finesseStrategy; set => finesseStrategy = value; }
        internal NeighboursStrategy NeighboursStrategy { get => neighboursStrategy; set => neighboursStrategy = value; }

        public TabuMethod(Board x0, int n1, int n2)
        {
            this.FinesseStrategy = new NbQueenConflict();
            this.NeighboursStrategy = new Swap();
            this.x0 = x0;
            this.n1 = n1;
            this.n2 = n2;
        }

        private void init()
        {
            this.tabuList = new Dictionary<int, int>();
            this.XMin = x0;
            this.FMin = finesseStrategy.compute(this.XMin);
            notify();
        }

        protected override void algo()
        {
            Board x = x0;
            int fx = this.finesseStrategy.compute(x0);
            int i = 0;
            bool end = false;
            do
            {
                List<Board> neighbourgs = this.neighboursStrategy.compute(x);
                if (neighbourgs.Count == 0)
                {
                    end = true;
                }
                else
                {
                    int fy = 0;
                    Board y = null;
                    neighbourgs.ForEach(n =>
                    {
                        int finesseValue = this.finesseStrategy.compute(n);
                        if (fy > finesseValue)
                        {
                            fy = finesseValue;
                            y = n;
                        }

                    });
                    int deltaf = fy - fx;
                    if(deltaf >= 0)
                    {

                    }

                }

            } while (!end);

        }
    }
}
