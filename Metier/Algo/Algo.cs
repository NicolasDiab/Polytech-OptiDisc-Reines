using Metier.Finesse;
using Metier.Neighbours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class Algo
    {
        private Board xMin;
        private int fMin;
        private Boolean isRunning;
        public event EventHandler changed;

        protected NeighboursStrategy neighboursStrategy;
        protected FinesseStrategy finesseStrategy;

        public Board XMin { get => xMin; set => xMin = value; }
        public int FMin { get => fMin; set => fMin = value; }
        public bool IsRunning { get => isRunning; set => isRunning = value; }
        public FinesseStrategy FinesseStrategy { get => finesseStrategy; set => finesseStrategy = value; }
        public NeighboursStrategy NeighboursStrategy { get => neighboursStrategy; set => neighboursStrategy = value; }

        protected void notify()
        {
            this.changed(this, EventArgs.Empty);
        }

        public void start() {
            this.IsRunning = true;
            this.algo();
            this.isRunning = false;
            this.notify();
        }

        protected abstract void algo();

        public abstract string getAdvancement();


    }
}
