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
        private int n = 8;
        private int m = 8;


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
            this.updateDgv(result);
            var x = result.finesseNbQueensConflicting();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvBoard.AutoGenerateColumns = false;
            for (int i = 1; i <= n; i++)
            {
                dgvBoard.Columns.Add("col" + i, "column " + i);
                dgvBoard.Columns[i - 1].FillWeight = 1;
            }
            for (int j = 0; j < m; j++)
                dgvBoard.Rows.Add();
            dgvBoard.Rows.Add(m);
        }

        private void updateDgv(Board board) {
            int[] tab = board.getPositions();
            for (int i = 0; i < tab.Count(); i++)
            {
                this.dgvBoard.Rows[i].Cells[tab[i] -1].Style.BackColor = Color.Green;
                this.dgvBoard.Rows[i].Cells[tab[i] -1].Style.ForeColor = Color.Green;
            }
        }
    }
}
