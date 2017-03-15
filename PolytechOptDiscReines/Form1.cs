using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Metier;

namespace PolytechOptDiscReines
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Board x0 = new Board();
            Double t0 = 100;
            int n1 = 50;
            int n2 = 50;

            SimulatedAnnealing algo1 = new SimulatedAnnealing(x0, t0, n1, n2);
            
            Board result = algo1.start();
            var x = result.finesseNbQueensConflicting();
        }
    }
}
