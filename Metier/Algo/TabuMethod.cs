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
        private int nMax;
        private int currentN;
        private Dictionary<int, int> tabuList;


        internal FinesseStrategy FinesseStrategy { get => finesseStrategy; set => finesseStrategy = value; }
        internal NeighboursStrategy NeighboursStrategy { get => neighboursStrategy; set => neighboursStrategy = value; }

        public TabuMethod(Board x0, int nMax)
        {
            this.FinesseStrategy = new NbQueenConflict();
            this.NeighboursStrategy = new Swap();
            this.x0 = x0;
            this.nMax = nMax;
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
            Board x = this.x0;
            int fx = this.finesseStrategy.compute(x0);
            currentN = 0;
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
                    int fy = int.MaxValue;
                    Board y = null;
                    neighbourgs.ForEach(n =>
                    {
                        int finesseValue = this.finesseStrategy.compute(n);
                        if (finesseValue <= fy)
                        {
                            fy = finesseValue;
                            y = n;
                        }

                    });
                    int deltaf = fy - fx;
                    if (deltaf >= 0)
                    {
                        this.tabuList.Add(y.Transition.Key, y.Transition.Value);
                    }
                    if (fy < this.FMin)
                    {
                        this.XMin = y;
                        this.FMin = fy;
                    }
                    x = y;
                }
                currentN++;
            } while (!end && currentN < nMax);
        }

        public override string getAdvancement()
        {
            return Math.Round(((double)currentN / (double)nMax),3) * 100 + " % " ;
        }
    }
}
