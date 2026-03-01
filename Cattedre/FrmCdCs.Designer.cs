namespace Cattedre
{
    partial class FrmCdCs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCdCs));
            this.btElimina = new System.Windows.Forms.Button();
            this.btModifica = new System.Windows.Forms.Button();
            this.btInserisci = new System.Windows.Forms.Button();
            this.lvCdCs = new System.Windows.Forms.ListView();
            this.chCodice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAbilitazioniRichieste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumCattedreDiritto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumCattedreDiFatto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btElimina
            // 
            this.btElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btElimina.Location = new System.Drawing.Point(1330, 106);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(105, 23);
            this.btElimina.TabIndex = 10;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // btModifica
            // 
            this.btModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModifica.Location = new System.Drawing.Point(1330, 77);
            this.btModifica.Name = "btModifica";
            this.btModifica.Size = new System.Drawing.Size(105, 23);
            this.btModifica.TabIndex = 9;
            this.btModifica.Text = "Modifica";
            this.btModifica.UseVisualStyleBackColor = true;
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInserisci.Location = new System.Drawing.Point(1330, 48);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.Size = new System.Drawing.Size(105, 23);
            this.btInserisci.TabIndex = 8;
            this.btInserisci.Text = "Inserisci";
            this.btInserisci.UseVisualStyleBackColor = true;
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // lvCdCs
            // 
            this.lvCdCs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCdCs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCodice,
            this.chNome,
            this.chAbilitazioniRichieste,
            this.chNumCattedreDiritto,
            this.chNumCattedreDiFatto});
            this.lvCdCs.FullRowSelect = true;
            this.lvCdCs.HideSelection = false;
            this.lvCdCs.Location = new System.Drawing.Point(28, 35);
            this.lvCdCs.Margin = new System.Windows.Forms.Padding(2);
            this.lvCdCs.Name = "lvCdCs";
            this.lvCdCs.Size = new System.Drawing.Size(1285, 471);
            this.lvCdCs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCdCs.TabIndex = 11;
            this.lvCdCs.UseCompatibleStateImageBehavior = false;
            this.lvCdCs.View = System.Windows.Forms.View.Details;
            // 
            // chCodice
            // 
            this.chCodice.Text = "Codice";
            this.chCodice.Width = 90;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 300;
            // 
            // chAbilitazioniRichieste
            // 
            this.chAbilitazioniRichieste.Text = "Abilitazioni Richieste";
            this.chAbilitazioniRichieste.Width = 650;
            // 
            // chNumCattedreDiritto
            // 
            this.chNumCattedreDiritto.Text = "Cattedre Di Diritto";
            this.chNumCattedreDiritto.Width = 120;
            // 
            // chNumCattedreDiFatto
            // 
            this.chNumCattedreDiFatto.Text = "Cattedre Di Fatto";
            this.chNumCattedreDiFatto.Width = 120;
            // 
            // FrmCdCs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 577);
            this.Controls.Add(this.lvCdCs);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btInserisci);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FrmCdCs";
            this.Text = "Classi di concorso";
            this.Load += new System.EventHandler(this.FrmCdCs_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btElimina;
        private System.Windows.Forms.Button btModifica;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.ListView lvCdCs;
        private System.Windows.Forms.ColumnHeader chCodice;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chAbilitazioniRichieste;
        private System.Windows.Forms.ColumnHeader chNumCattedreDiritto;
        private System.Windows.Forms.ColumnHeader chNumCattedreDiFatto;
    }
}