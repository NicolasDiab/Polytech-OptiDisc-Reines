using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class SimulatedAnnealing
    {
        Board x0;
        double t0;
        Board xMin;
        int fMin;
        int i;
        int n1;
        int n2;
        double t;

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
            this.xMin = this.x0;
            this.fMin = this.xMin.finesseNbQueensConflicting();
            this.i = 0;
        }
        
        public Board start()
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
                        if (fx < this.fMin)
                        {
                            this.fMin = fx;
                            this.xMin = x; 
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

            return xMin;
        }
    }
}
