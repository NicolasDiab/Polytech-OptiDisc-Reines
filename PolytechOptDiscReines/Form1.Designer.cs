namespace PolytechOptDiscReines
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
            this.lbFit.Location = new System.Drawing.Point(714, 21);
            this.lbFit.Name = "lbFit";
            this.lbFit.Size = new System.Drawing.Size(35, 13);
            this.lbFit.TabIndex = 2;
            this.lbFit.Text = "label1";
            // 
            // lbIsRunning
            // 
            this.lbIsRunning.AutoSize = true;
            this.lbIsRunning.Location = new System.Drawing.Point(94, 20);
            this.lbIsRunning.Name = "lbIsRunning";
            this.lbIsRunning.Size = new System.Drawing.Size(35, 13);
            this.lbIsRunning.TabIndex = 3;
            this.lbIsRunning.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 438);
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
    }
}

