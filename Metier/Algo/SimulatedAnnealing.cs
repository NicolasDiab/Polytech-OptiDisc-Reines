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
        const double PROBA = 0.8;
        const double U = 0.90;
        const int N2 = 1000;

        private Board x0;
        private double t0;
        private int i;
        private int n1;
        private int n2;
        private int currentN1;
        private double step;
        private double t;


        public SimulatedAnnealing(Board x0)
        {
            this.FinesseStrategy = new NbQueenConflict();
            this.NeighboursStrategy = new Swap();
            this.x0 = x0;
            this.t0 = this.computeInitTemperature(this.computeDeltaMax(this.x0.N),PROBA);
            this.n2 = N2;
            this.step = computeStepTemperature(t0, this.computeDeltaMax(this.x0.N), PROBA, U);
            this.n1 = (int)( t0 / -step);
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
            for (currentN1 = 0; currentN1 < this.n1; currentN1++)
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
                t += step;
                this.notify();
            }
        }

        public Board getRandomNeighbour(List<Board> neighbours)
        {
            int i = new Random().Next(0, neighbours.Count);
            return neighbours.ElementAt(i);
        }

        private double computeInitTemperature(int delta,double proba) {
            return -delta / Math.Log(proba);
        }

        private int computeDeltaMax(int nbDame) {
            return (nbDame * (nbDame - 1)) / 2;
        }

        private double computeStepTemperature(double t0,int delta, double proba,double u)
        {
            return Math.Log(-delta / Math.Log(proba) * t0) / Math.Log(u);
        }

        public override string getAdvancement()
        {
            return Math.Round(((double)currentN1 / (double)n1),3) * 100 + " % | t: " + Math.Round(t ,0) + " / " + Math.Round(t0, 0);
        }
    }
}
