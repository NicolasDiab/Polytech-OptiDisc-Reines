using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Metier;

namespace PolytechOptDiscReines
{
    public partial class Form1 : Form
    {
        private int n = 10;
        private Board currentBoard;
        private Algo algo;
        private Thread thread;

        private delegate void UpdateDelegateHandler(Board board);
        private UpdateDelegateHandler UpdateDelegate;



        public Form1()
        {
            InitializeComponent();
            this.UpdateDelegate = new UpdateDelegateHandler(update);
        }

        #region Methode with Event 
        private void btnStart_Click(object sender, EventArgs e)
        {
            Board x0 = new Board(this.n, this.n, this.n);
            Double t0 = 100;
            int n1 = 1000;
            int n2 = 100;

            this.algo = new TabuMethod(x0,n1);
            //this.algo = new SimulatedAnnealing(x0, t0, n1, n2);
            this.algo.changed += this.updateEvent;
            this.thread = new Thread(new ThreadStart(this.algo.start));
            this.thread.Start();

        }

        private void updateEvent(object algo, EventArgs args)
        {
            Algo sa = (Algo)algo;
            this.Invoke(this.UpdateDelegate, new object[] { sa.XMin });
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dgvBoard.AutoGenerateColumns = false;
            dgvBoard.RowHeadersVisible = false;
            dgvBoard.ColumnHeadersVisible = false;

            for (int i = 1; i <= n; i++)
            {
                dgvBoard.Columns.Add("col" + i, "column " + i);
                dgvBoard.Columns[i - 1].Width = 40;

            }
            dgvBoard.Rows.Add(n - 1);
        }
        #endregion



        private void update(Board board)
        {
            // undraw old board
            if (this.currentBoard != null)
                this.drawDgv(this.currentBoard, true);
            // draw new board
            this.drawDgv(board);
            // Show the current fitness
            this.lbFit.Text = this.algo.FMin.ToString();
            this.currentBoard = board;
            // Update the runnin state label
            this.updateIsRunning(this.algo.IsRunning);
        }

        private void drawDgv(Board board, Boolean white = false)
        {
            int[] tab = board.Positions;
            for (int i = 0; i < tab.Count(); i++)
            {
                if (tab[i] > 0)
                {
                    this.dgvBoard.Rows[i].Cells[tab[i] - 1].Style.BackColor = (white) ? Color.White : Color.Green;
                    this.dgvBoard.Rows[i].Cells[tab[i] - 1].Style.ForeColor = (white) ? Color.White : Color.Black;
                }
            }
        }

        public void updateIsRunning(Boolean isRunning)
        {
            if (isRunning)
                this.lbIsRunning.Text = "En Cours";
            else
                this.lbIsRunning.Text = "Fini";

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.thread.Abort();
        }
    }
}
