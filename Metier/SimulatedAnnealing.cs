using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.Finesse;
using Metier.Neighbours;

namespace Metier
{
    public class SimulatedAnnealing : Algo
    {
        private NeighboursStrategy neighboursStrategy;
        private FinesseStrategy finesseStrategy;
        private Board x0;
        private double t0;
        private int i;
        private int n1;
        private int n2;
        private double t;

        internal FinesseStrategy FinesseStrategy { get => finesseStrategy; set => finesseStrategy = value; }
        internal NeighboursStrategy NeighboursStrategy { get => neighboursStrategy; set => neighboursStrategy = value; }

        public SimulatedAnnealing(Board x0, double t0, int n1, int n2)
        {
            this.FinesseStrategy = new NbQueenConflict();
            this.NeighboursStrategy = new Swap();
            this.x0 = x0;
            this.t0 = t0;
            this.n1 = n1;
            this.n2 = n2;
            this.t = t0;
        }

        private void init()
        {
            this.XMin = this.x0;
            this.FMin = this.FinesseStrategy.compute(this.XMin);
            this.i = 0;
        }

        protected override void algo()
        {
            this.init();
            Board x = this.x0;
            Random random = new Random();
            int fx = this.FinesseStrategy.compute(x);
            int l;
            Board y;
            int fy;
            int delta;
            double p;
            for (int k = 0; k < this.n1; k++)
            {
                for (l = 0; l < this.n2; l++)
                {
                    y = this.getRandomNeighbour(this.NeighboursStrategy.compute(x));
                    fy = this.FinesseStrategy.compute(y);
                    delta = fy - fx;
                    if (delta <= 0)
                    {
                        x = y;
                        fx = fy;
                        if (fx < this.FMin)
                        {
                            this.FMin = fx;
                            this.XMin = x;
                            if (this.FMin == 0)
                                return;
                            this.notify();
                        }
                    }
                    else
                    {
                        p = random.Next(0, 10000) / 10000;
                        if (p < Math.Exp(-delta / t))
                        {
                            x = y;
                            fx = fy;
                        }
                    }
                    i++;
                }
                t *= 0.8;
            }
        }
        public Board getRandomNeighbour(List<Board> neighbours)
        {
            int i = new Random().Next(0, neighbours.Count);
            return neighbours.ElementAt(i);
        }
    }
}
