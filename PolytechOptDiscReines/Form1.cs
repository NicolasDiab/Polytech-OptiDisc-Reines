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
        private int n = 8;
        private int m = 8;
        private Board currentBoard;

        private delegate void UpdateDGVDelegateHandler(Board board);
        private UpdateDGVDelegateHandler UpdateDGVDelegate;

        private delegate void updateIsRunningDelegateHandler(Boolean isRunning);
        private updateIsRunningDelegateHandler updateIsRunningDelegate;


        public Form1()
        {
            InitializeComponent();
            this.UpdateDGVDelegate = new UpdateDGVDelegateHandler(updateDgv);
            this.updateIsRunningDelegate = new updateIsRunningDelegateHandler(updateIsRunning);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Board x0 = new Board();
            Double t0 = 100;
            int n1 = 40000;
            int n2 = 50;

            SimulatedAnnealing algo1 = new SimulatedAnnealing(x0, t0, n1, n2);
            algo1.minChanged += this.updateEvent;
            algo1.haveFinish += this.updateIsRunningEvent;
            Thread demoThread =
                new Thread(new ThreadStart(algo1.start));
            this.updateIsRunning(true);
            demoThread.Start();

            /*Board result = algo1.start();
            this.updateDgv(result);
            this.lbFit.Text =  result.finesseNbQueensConflicting().ToString();*/
        }
        
        private void updateEvent(object algo, EventArgs args)
        {
            SimulatedAnnealing sa = (SimulatedAnnealing)algo;
            this.Invoke(this.UpdateDGVDelegate, new object[] { sa.XMin });
        }

        private void updateIsRunningEvent(object algo, EventArgs args)
        {
            this.updateEvent(algo, args);
            this.Invoke(this.updateIsRunningDelegate, new object[] { false });
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
            dgvBoard.Rows.Add(m-1);
        }

        private void updateDgv(Board board) {
            if(this.currentBoard != null)
                this.drawDgv(this.currentBoard, true);
            this.drawDgv(board);
            this.lbFit.Text = board.finesseNbQueensConflicting().ToString();
            this.currentBoard = board;          
        }

        private void drawDgv(Board board, Boolean white = false) {
            int[] tab = board.getPositions();
            for (int i = 0; i < tab.Count(); i++)
            {
                if (white)
                {
                    this.dgvBoard.Rows[i].Cells[tab[i] - 1].Style.BackColor = Color.White;
                    this.dgvBoard.Rows[i].Cells[tab[i] - 1].Style.ForeColor = Color.White;
                }
                else
                {
                    this.dgvBoard.Rows[i].Cells[tab[i] - 1].Style.BackColor = Color.Green;
                    this.dgvBoard.Rows[i].Cells[tab[i] - 1].Style.ForeColor = Color.Black;
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
    }
}
