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
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClasse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDisciplina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOreSpeciali = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOreTot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btElimina = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAnniScolastici = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lvCattedreUtente
            // 
            this.lvCattedreUtente.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chClasse,
            this.chDisciplina,
            this.chOreSpeciali,
            this.chOre,
            this.chOreTot});
            this.lvCattedreUtente.FullRowSelect = true;
            this.lvCattedreUtente.HideSelection = false;
            this.lvCattedreUtente.Location = new System.Drawing.Point(28, 95);
            this.lvCattedreUtente.Name = "lvCattedreUtente";
            this.lvCattedreUtente.Size = new System.Drawing.Size(406, 237);
            this.lvCattedreUtente.TabIndex = 0;
            this.lvCattedreUtente.UseCompatibleStateImageBehavior = false;
            this.lvCattedreUtente.View = System.Windows.Forms.View.Details;
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 36;
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
            // chOreSpeciali
            // 
            this.chOreSpeciali.Text = "Ore Speciali";
            this.chOreSpeciali.Width = 71;
            // 
            // chOre
            // 
            this.chOre.Text = "Ore";
            this.chOre.Width = 73;
            // 
            // chOreTot
            // 
            this.chOreTot.Text = "Ore Tot";
            // 
            // btElimina
            // 
            this.btElimina.Location = new System.Drawing.Point(450, 95);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(75, 23);
            this.btElimina.TabIndex = 1;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Anno Scolastico:";
            // 
            // cbAnniScolastici
            // 
            this.cbAnniScolastici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnniScolastici.FormattingEnabled = true;
            this.cbAnniScolastici.Location = new System.Drawing.Point(118, 41);
            this.cbAnniScolastici.Name = "cbAnniScolastici";
            this.cbAnniScolastici.Size = new System.Drawing.Size(60, 21);
            this.cbAnniScolastici.TabIndex = 3;
            this.cbAnniScolastici.SelectedIndexChanged += new System.EventHandler(this.cbAnniScolastici_SelectedIndexChanged);
            // 
            // FrmCattedreUtente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 374);
            this.Controls.Add(this.cbAnniScolastici);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.lvCattedreUtente);
            this.Name = "FrmCattedreUtente";
            this.Text = "Cattedre Utente";
            this.Load += new System.EventHandler(this.FrmCattedreUtente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvCattedreUtente;
        private System.Windows.Forms.ColumnHeader chClasse;
        private System.Windows.Forms.ColumnHeader chDisciplina;
        private System.Windows.Forms.ColumnHeader chOreSpeciali;
        private System.Windows.Forms.Button btElimina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAnniScolastici;
        private System.Windows.Forms.ColumnHeader chOre;
        private System.Windows.Forms.ColumnHeader chOreTot;
        private System.Windows.Forms.ColumnHeader chID;
    }
}