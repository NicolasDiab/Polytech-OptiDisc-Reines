﻿namespace PolytechOptDiscReines
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.dgvBoard = new System.Windows.Forms.DataGridView();
            this.lbFit = new System.Windows.Forms.Label();
            this.lbIsRunning = new System.Windows.Forms.Label();
            this.lbTimer = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Lancer l\'algo";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgvBoard
            // 
            this.dgvBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoard.Location = new System.Drawing.Point(12, 48);
            this.dgvBoard.Name = "dgvBoard";
            this.dgvBoard.Size = new System.Drawing.Size(819, 378);
            this.dgvBoard.TabIndex = 1;
            // 
            // lbFit
            // 
            this.lbFit.AutoSize = true;
            this.lbFit.Location = new System.Drawing.Point(796, 22);
            this.lbFit.Name = "lbFit";
            this.lbFit.Size = new System.Drawing.Size(40, 13);
            this.lbFit.TabIndex = 2;
            this.lbFit.Text = "Fitness";
            // 
            // lbIsRunning
            // 
            this.lbIsRunning.AutoSize = true;
            this.lbIsRunning.Location = new System.Drawing.Point(94, 20);
            this.lbIsRunning.Name = "lbIsRunning";
            this.lbIsRunning.Size = new System.Drawing.Size(62, 13);
            this.lbIsRunning.TabIndex = 3;
            this.lbIsRunning.Text = "Not running";
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Location = new System.Drawing.Point(622, 22);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(41, 13);
            this.lbTimer.TabIndex = 4;
            this.lbTimer.Text = "TIMER";
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.Location = new System.Drawing.Point(196, 22);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(25, 13);
            this.lbState.TabIndex = 5;
            this.lbState.Text = "état";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(796, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fitness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "TIMER";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 438);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.lbTimer);
            this.Controls.Add(this.lbIsRunning);
            this.Controls.Add(this.lbFit);
            this.Controls.Add(this.dgvBoard);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvBoard;
        private System.Windows.Forms.Label lbFit;
        private System.Windows.Forms.Label lbIsRunning;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}

