namespace Cattedre
{
    partial class UcDisciplina
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
            this.lbldisciplina = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbldisciplina
            // 
            this.lbldisciplina.AutoSize = true;
            this.lbldisciplina.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldisciplina.Location = new System.Drawing.Point(83, 24);
            this.lbldisciplina.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldisciplina.Name = "lbldisciplina";
            this.lbldisciplina.Size = new System.Drawing.Size(21, 19);
            this.lbldisciplina.TabIndex = 1;
            this.lbldisciplina.Text = "...";
            this.lbldisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbldisciplina);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UcDisciplina";
            this.Size = new System.Drawing.Size(213, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbldisciplina;
    }
}
