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
            this.nudOrePot = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrePot)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOreDiCattedra
            // 
            this.lblOreDiCattedra.AutoSize = true;
            this.lblOreDiCattedra.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreDiCattedra.Location = new System.Drawing.Point(145, 9);
            this.lblOreDiCattedra.Name = "lblOreDiCattedra";
            this.lblOreDiCattedra.Size = new System.Drawing.Size(17, 16);
            this.lblOreDiCattedra.TabIndex = 0;
            this.lblOreDiCattedra.Text = "...";
            // 
            // lblOreEffettive
            // 
            this.lblOreEffettive.AutoSize = true;
            this.lblOreEffettive.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreEffettive.Location = new System.Drawing.Point(227, 9);
            this.lblOreEffettive.Name = "lblOreEffettive";
            this.lblOreEffettive.Size = new System.Drawing.Size(17, 16);
            this.lblOreEffettive.TabIndex = 1;
            this.lblOreEffettive.Text = "...";
            // 
            // lblOreTotali
            // 
            this.lblOreTotali.AutoSize = true;
            this.lblOreTotali.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreTotali.Location = new System.Drawing.Point(367, 9);
            this.lblOreTotali.Name = "lblOreTotali";
            this.lblOreTotali.Size = new System.Drawing.Size(17, 16);
            this.lblOreTotali.TabIndex = 3;
            this.lblOreTotali.Text = "...";
            // 
            // lblDocente
            // 
            this.lblDocente.AutoSize = true;
            this.lblDocente.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocente.Location = new System.Drawing.Point(8, 9);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(17, 16);
            this.lblDocente.TabIndex = 4;
            this.lblDocente.Text = "...";
            // 
            // nudOrePot
            // 
            this.nudOrePot.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudOrePot.Location = new System.Drawing.Point(295, 7);
            this.nudOrePot.Name = "nudOrePot";
            this.nudOrePot.Size = new System.Drawing.Size(35, 21);
            this.nudOrePot.TabIndex = 10;
            this.nudOrePot.ValueChanged += new System.EventHandler(this.nudOrePot_ValueChanged);
            // 
            // ucOreDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudOrePot);
            this.Controls.Add(this.lblDocente);
            this.Controls.Add(this.lblOreTotali);
            this.Controls.Add(this.lblOreEffettive);
            this.Controls.Add(this.lblOreDiCattedra);
            this.Name = "ucOreDoc";
            this.Size = new System.Drawing.Size(414, 33);
            ((System.ComponentModel.ISupportInitialize)(this.nudOrePot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblOreDiCattedra;
        public System.Windows.Forms.Label lblOreEffettive;
        public System.Windows.Forms.Label lblOreTotali;
        public System.Windows.Forms.Label lblDocente;
        public System.Windows.Forms.NumericUpDown nudOrePot;
    }
}
