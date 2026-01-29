namespace Cattedre
{
    partial class ucOreDoc
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOreDiCattedra = new System.Windows.Forms.Label();
            this.lblOreEffettive = new System.Windows.Forms.Label();
            this.lblOreTotali = new System.Windows.Forms.Label();
            this.lblDocente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudOrePot = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrePot)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOreDiCattedra
            // 
            this.lblOreDiCattedra.AutoSize = true;
            this.lblOreDiCattedra.Location = new System.Drawing.Point(146, 58);
            this.lblOreDiCattedra.Name = "lblOreDiCattedra";
            this.lblOreDiCattedra.Size = new System.Drawing.Size(16, 13);
            this.lblOreDiCattedra.TabIndex = 0;
            this.lblOreDiCattedra.Text = "...";
            // 
            // lblOreEffettive
            // 
            this.lblOreEffettive.AutoSize = true;
            this.lblOreEffettive.Location = new System.Drawing.Point(228, 58);
            this.lblOreEffettive.Name = "lblOreEffettive";
            this.lblOreEffettive.Size = new System.Drawing.Size(16, 13);
            this.lblOreEffettive.TabIndex = 1;
            this.lblOreEffettive.Text = "...";
            // 
            // lblOreTotali
            // 
            this.lblOreTotali.AutoSize = true;
            this.lblOreTotali.Location = new System.Drawing.Point(368, 58);
            this.lblOreTotali.Name = "lblOreTotali";
            this.lblOreTotali.Size = new System.Drawing.Size(16, 13);
            this.lblOreTotali.TabIndex = 3;
            this.lblOreTotali.Text = "...";
            // 
            // lblDocente
            // 
            this.lblDocente.AutoSize = true;
            this.lblDocente.Location = new System.Drawing.Point(4, 58);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(16, 13);
            this.lblDocente.TabIndex = 4;
            this.lblDocente.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Docente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ore Cattedra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ore Eff";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(287, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ore Pot";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(365, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tot";
            // 
            // nudOrePot
            // 
            this.nudOrePot.Location = new System.Drawing.Point(296, 56);
            this.nudOrePot.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudOrePot.Name = "nudOrePot";
            this.nudOrePot.Size = new System.Drawing.Size(35, 20);
            this.nudOrePot.TabIndex = 10;
            this.nudOrePot.ValueChanged += new System.EventHandler(this.nudOrePot_ValueChanged);
            // 
            // ucOreDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudOrePot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDocente);
            this.Controls.Add(this.lblOreTotali);
            this.Controls.Add(this.lblOreEffettive);
            this.Controls.Add(this.lblOreDiCattedra);
            this.Name = "ucOreDoc";
            this.Size = new System.Drawing.Size(414, 150);
            ((System.ComponentModel.ISupportInitialize)(this.nudOrePot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblOreDiCattedra;
        public System.Windows.Forms.Label lblOreEffettive;
        public System.Windows.Forms.Label lblOreTotali;
        public System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown nudOrePot;
    }
}
