namespace Cattedre
{
    partial class FrmContratti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContratti));
            this.lvContratti = new System.Windows.Forms.ListView();
            this.chTipoContratto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMonteOre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataInizio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataFine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUtente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btInserisci = new System.Windows.Forms.Button();
            this.btModifica = new System.Windows.Forms.Button();
            this.btElimina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvContratti
            // 
            this.lvContratti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTipoContratto,
            this.chMonteOre,
            this.chDataInizio,
            this.chDataFine,
            this.chUtente});
            this.lvContratti.FullRowSelect = true;
            this.lvContratti.HideSelection = false;
            this.lvContratti.Location = new System.Drawing.Point(34, 75);
            this.lvContratti.Name = "lvContratti";
            this.lvContratti.Size = new System.Drawing.Size(516, 243);
            this.lvContratti.TabIndex = 0;
            this.lvContratti.UseCompatibleStateImageBehavior = false;
            this.lvContratti.View = System.Windows.Forms.View.Details;
            // 
            // chTipoContratto
            // 
            this.chTipoContratto.Text = "Tipo (tempo)";
            this.chTipoContratto.Width = 100;
            // 
            // chMonteOre
            // 
            this.chMonteOre.Text = "Monte Ore";
            this.chMonteOre.Width = 70;
            // 
            // chDataInizio
            // 
            this.chDataInizio.Text = "Data Inizio";
            this.chDataInizio.Width = 70;
            // 
            // chDataFine
            // 
            this.chDataFine.Text = "Data Fine";
            this.chDataFine.Width = 84;
            // 
            // chUtente
            // 
            this.chUtente.Text = "Utente";
            this.chUtente.Width = 188;
            // 
            // btInserisci
            // 
            this.btInserisci.Location = new System.Drawing.Point(573, 76);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.Size = new System.Drawing.Size(75, 23);
            this.btInserisci.TabIndex = 1;
            this.btInserisci.Text = "Inserisci";
            this.btInserisci.UseVisualStyleBackColor = true;
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // btModifica
            // 
            this.btModifica.Location = new System.Drawing.Point(573, 131);
            this.btModifica.Name = "btModifica";
            this.btModifica.Size = new System.Drawing.Size(75, 23);
            this.btModifica.TabIndex = 2;
            this.btModifica.Text = "Modifica";
            this.btModifica.UseVisualStyleBackColor = true;
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // btElimina
            // 
            this.btElimina.Location = new System.Drawing.Point(573, 189);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(75, 23);
            this.btElimina.TabIndex = 3;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // FrmContratti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 371);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.lvContratti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmContratti";
            this.Text = "Contratti";
            this.Load += new System.EventHandler(this.FrmContratti_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvContratti;
        private System.Windows.Forms.ColumnHeader chTipoContratto;
        private System.Windows.Forms.ColumnHeader chMonteOre;
        private System.Windows.Forms.ColumnHeader chDataInizio;
        private System.Windows.Forms.ColumnHeader chDataFine;
        private System.Windows.Forms.ColumnHeader chUtente;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.Button btModifica;
        private System.Windows.Forms.Button btElimina;
    }
}