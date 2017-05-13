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

        public Board XMin { get => xMin; set => xMin = value; }
        public int FMin { get => fMin; set => fMin = value; }
        public bool IsRunning { get => isRunning; set => isRunning = value; }

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
