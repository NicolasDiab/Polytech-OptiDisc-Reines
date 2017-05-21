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
        private Board currentBoard;
        private Algo algo;
        private Thread thread;
        private DateTime time;
        private System.Windows.Forms.Timer timer;


        private const int NUMBER_QUEENS = 8;


        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 200; // 5 secs
            timer.Tick += this.timer_Tick;
                
            
        }

        #region Methode with Event 
        private void btnStart_Click(object sender, EventArgs e)
        {
            Board x0 = new Board(NUMBER_QUEENS);

            this.time = DateTime.Now;
            //this.algo = new TabuMethod(x0,1000);

            //this.algo = new SimulatedAnnealing(x0);
            
            this.algo = new GeneticAlgo(GeneticBoard.getFirstGeneration(10, NUMBER_QUEENS), 100);
            this.thread = new Thread(new ThreadStart(this.algo.start));
            this.thread.Start();
            timer.Start();
            this.update();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (!algo.IsRunning)
                timer.Stop();

            this.update();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dgvBoard.AutoGenerateColumns = false;
            dgvBoard.RowHeadersVisible = false;
            dgvBoard.ColumnHeadersVisible = false;


            dgvBoard.Columns.Add("col" + 0, "column " + 0);
            dgvBoard.Columns[0].Width = 20;
            dgvBoard.Rows.Add(NUMBER_QUEENS-1);
            dgvBoard.Rows[0].Height = 20;
            for (int i = 2; i <= NUMBER_QUEENS; i++)
            {
                dgvBoard.Columns.Add("col" + i, "column " + i);
                dgvBoard.Columns[i - 1].Width = 20;
                dgvBoard.Rows[i - 1].Height = 20;
            }
            

        }
        #endregion



        private void update()
        {
            this.updateLabel();
            this.updateDGV();
        }

        public void updateDGV()
        {
            // draw new board
            if (this.algo.XMin != null && !this.algo.XMin.Equals(this.currentBoard))
            {
                if (this.algo.XMin is GeneticBoard)
                    this.drawDgv((GeneticBoard)this.algo.XMin, (GeneticBoard)this.currentBoard);
                else
                    this.drawDgv(this.algo.XMin, this.currentBoard);


                this.currentBoard = this.algo.XMin;
            }
        }

        private void drawDgv(Board board, Board old)
        {
            int[] tab = board.Positions;
            int[] tab2 = (old !=null)? old.Positions:null;           

            for (int i = 0; i < tab.Count(); i++)
            {
                if (tab[i] > 0)
                {
                    if (tab2 != null)
                    {
                        this.dgvBoard.Rows[i].Cells[tab2[i] - 1].Style.BackColor = Color.White;
                        this.dgvBoard.Rows[i].Cells[tab2[i] - 1].Style.ForeColor = Color.White;
                    }
                    this.dgvBoard.Rows[i].Cells[tab[i] - 1].Style.BackColor =  Color.Green;
                    this.dgvBoard.Rows[i].Cells[tab[i] - 1].Style.ForeColor =  Color.Black;
                }
            }
        }

        private void drawDgv(GeneticBoard board, GeneticBoard old)
        {
            int[] tab = board.Positions;
            int[] tab2 = (old != null) ? old.Positions : null;
            int i=0, j =0;
            for (int index = 0; index < tab.Count(); index++)
            {
                i = index / board.N;
                j = index % board.N;


                if (tab2 != null && tab2[i] > 0)
                {
                    this.dgvBoard.Rows[i].Cells[j].Style.BackColor = Color.White;
                    this.dgvBoard.Rows[i].Cells[j].Style.ForeColor = Color.White;
                }
                if (tab[i] > 0)
                {
                    this.dgvBoard.Rows[i].Cells[j].Style.BackColor = Color.Green;
                    this.dgvBoard.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
        }



        public void updateLabel()
        {
            this.lbTimer.Text = (DateTime.Now - this.time).TotalSeconds.ToString();
            if (this.algo.IsRunning)
                this.lbIsRunning.Text = "En Cours";
            else
            {
                this.lbIsRunning.Text = "Fini";
            }
            // Show the current fitness
            this.lbFit.Text = this.algo.FMin.ToString();
            this.lbState.Text = this.algo.getAdvancement();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(thread != null) this.thread.Abort();
        }

    }
}
