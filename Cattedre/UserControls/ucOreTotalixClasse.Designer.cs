namespace Cattedre
{
    partial class UcOreTotalixClasse
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
            this.lblOreTotalixClasse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOreTotalixClasse
            // 
            this.lblOreTotalixClasse.AutoSize = true;
            this.lblOreTotalixClasse.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreTotalixClasse.Location = new System.Drawing.Point(40, 23);
            this.lblOreTotalixClasse.Name = "lblOreTotalixClasse";
            this.lblOreTotalixClasse.Size = new System.Drawing.Size(21, 19);
            this.lblOreTotalixClasse.TabIndex = 2;
            this.lblOreTotalixClasse.Text = "...";
            // 
            // UcOreTotalixClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblOreTotalixClasse);
            this.Name = "UcOreTotalixClasse";
            this.Size = new System.Drawing.Size(100, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblOreTotalixClasse;
    }
}
