using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class SimulatedAnnealing
    {
        private Board x0;
        private double t0;
        private Board xMin;
        private int fMin;
        private int i;
        private int n1;
        private int n2;
        private double t;

        public Board XMin { get => xMin; set => xMin = value; }
        public int FMin { get => fMin; set => fMin = value; }

        public event EventHandler minChanged;
        public event EventHandler haveFinish;

        public SimulatedAnnealing(Board x0, double t0, int n1, int n2)
        {
            this.x0 = x0;
            this.t0 = t0;
            this.n1 = n1;
            this.n2 = n2;
            this.t = t0;
        }

        private void init()
        {
            this.XMin = this.x0;
            this.FMin = this.XMin.finesseNbQueensConflicting();
            this.i = 0;
        }
        
        public void start()
        {
            this.init();

            Board x = this.x0;
            Random random = new Random();
            int fx = x.finesseNbQueensConflicting();

            for (int k = 0; k < this.n1; k++)
            {
                for (int l = 0; l < this.n2; l++)
                {
                    Board y = x.getRandomNeighbour(x.findNeighboursSwitch());

                    int fy = y.finesseNbQueensConflicting();

                    int delta = fy - fx;
                    if (delta <= 0)
                    {
                        x = y;
                        fx = fy;
                        if (fx < this.FMin)
                        {
                            this.FMin = fx;
                            this.XMin = x;
                            this.minChanged(this, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        double p = random.Next(0, 100) / 100;
                        if (p < Math.Exp(-delta / t))
                        {
                            x = y;
                            fx = fy;
                        }
                    }
                    i++;
                }
                t *= 0.98;
            }
            this.haveFinish(this, EventArgs.Empty);
            //return XMin;
        }
    }
}
