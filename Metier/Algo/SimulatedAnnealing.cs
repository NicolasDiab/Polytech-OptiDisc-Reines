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
        const int N2 = 10000;
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
            //this.NeighboursStrategy = new RandomSwapBest(50,this.FinesseStrategy);
            this.NeighboursStrategy = new RandomSwap();
            this.x0 = x0;
            this.t0 = this.computeInitTemperature(this.computeDeltaMax(this.x0.N),PROBA);
            this.n2 = N2;         
            this.n1 = - (int)computeStepTemperature(t0, this.computeDeltaMax(this.x0.N), PROBA, U);
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
            while (t > 1)
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
                        p = (Double)random.NextDouble();
                        if (p < Math.Exp(-delta / t))
                        {
                            x = y;
                            fx = fy;
                        }
                    }
                    i++;
                }
                t = U * t;
            }
        }

        protected void algo2()
        {
            Random random = new Random();
            double temp = 10000;
            double coolingRate = 0.003;
            Board currentBoard = this.x0, newBoard;
            int currentFinnesse = this.finesseStrategy.compute(currentBoard), newFinnesse,delta;
            XMin = currentBoard;
            FMin = currentFinnesse;
            double p;
            while (temp > 1)
            {
                newBoard = this.getRandomNeighbour(this.neighboursStrategy.compute(currentBoard));
                newFinnesse = this.finesseStrategy.compute(newBoard);

                delta = newFinnesse - currentFinnesse;



                if (delta <= 0)
                {
                    currentBoard = newBoard;
                    currentFinnesse = newFinnesse;
                    if (newFinnesse < this.FMin)
                    {
                        this.FMin = newFinnesse;
                        this.XMin = newBoard;
                        if (this.FMin == 0)
                            return;
                    }
                }
                else {
                    p = (Double)random.NextDouble();
                    if (p < Math.Exp(-delta / t))
                    {
                        currentBoard = newBoard;
                        currentFinnesse = newFinnesse;
                    }
                }               
                   
                temp *= 1 - coolingRate;
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
            return Math.Round(((double)(t0 - t) / (double)t0),3) * 100 + " % ";
        }
    }
}
