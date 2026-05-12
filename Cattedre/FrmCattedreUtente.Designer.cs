namespace Cattedre
{
    partial class FrmCattedreUtente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvCattedreUtente = new System.Windows.Forms.ListView();
            this.btElimina = new System.Windows.Forms.Button();
            this.chClasse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDisciplina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvCattedreUtente
            // 
            this.lvCattedreUtente.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chClasse,
            this.chDisciplina,
            this.chOre});
            this.lvCattedreUtente.HideSelection = false;
            this.lvCattedreUtente.Location = new System.Drawing.Point(32, 33);
            this.lvCattedreUtente.Name = "lvCattedreUtente";
            this.lvCattedreUtente.Size = new System.Drawing.Size(226, 237);
            this.lvCattedreUtente.TabIndex = 0;
            this.lvCattedreUtente.UseCompatibleStateImageBehavior = false;
            this.lvCattedreUtente.View = System.Windows.Forms.View.Details;
            // 
            // btElimina
            // 
            this.btElimina.Location = new System.Drawing.Point(288, 33);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(75, 23);
            this.btElimina.TabIndex = 1;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            // 
            // chClasse
            // 
            this.chClasse.Text = "Classe";
            // 
            // chDisciplina
            // 
            this.chDisciplina.Text = "Disciplina";
            this.chDisciplina.Width = 102;
            // 
            // chOre
            // 
            this.chOre.Text = "Ore";
            // 
            // FrmCattedreUtente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 298);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.lvCattedreUtente);
            this.Name = "FrmCattedreUtente";
            this.Text = "Cattedre Utente";
            this.Load += new System.EventHandler(this.FrmCattedreUtente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCattedreUtente;
        private System.Windows.Forms.ColumnHeader chClasse;
        private System.Windows.Forms.ColumnHeader chDisciplina;
        private System.Windows.Forms.ColumnHeader chOre;
        private System.Windows.Forms.Button btElimina;
    }
}