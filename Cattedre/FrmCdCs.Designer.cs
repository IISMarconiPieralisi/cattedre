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
            this.brModifica = new System.Windows.Forms.Button();
            this.btInserisci = new System.Windows.Forms.Button();
            this.lvCdCs = new System.Windows.Forms.ListView();
            this.chLivello = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAbilitazioniRichieste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btElimina
            // 
            this.btElimina.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btElimina.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btElimina.Location = new System.Drawing.Point(783, 114);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(75, 23);
            this.btElimina.TabIndex = 10;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // brModifica
            // 
            this.brModifica.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.brModifica.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brModifica.Location = new System.Drawing.Point(783, 69);
            this.brModifica.Name = "brModifica";
            this.brModifica.Size = new System.Drawing.Size(75, 23);
            this.brModifica.TabIndex = 9;
            this.brModifica.Text = "Modifica";
            this.brModifica.UseVisualStyleBackColor = true;
            this.brModifica.Click += new System.EventHandler(this.brModifica_Click);
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btInserisci.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInserisci.Location = new System.Drawing.Point(783, 27);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.Size = new System.Drawing.Size(75, 23);
            this.btInserisci.TabIndex = 8;
            this.btInserisci.Text = "Inserisci";
            this.btInserisci.UseVisualStyleBackColor = true;
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // lvCdCs
            // 
            this.lvCdCs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCdCs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLivello,
            this.chNome,
            this.chAbilitazioniRichieste});
            this.lvCdCs.FullRowSelect = true;
            this.lvCdCs.HideSelection = false;
            this.lvCdCs.Location = new System.Drawing.Point(22, 27);
            this.lvCdCs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvCdCs.Name = "lvCdCs";
            this.lvCdCs.Size = new System.Drawing.Size(756, 205);
            this.lvCdCs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCdCs.TabIndex = 11;
            this.lvCdCs.UseCompatibleStateImageBehavior = false;
            this.lvCdCs.View = System.Windows.Forms.View.Details;
            // 
            // chLivello
            // 
            this.chLivello.Text = "Codice";
            this.chLivello.Width = 191;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            // 
            // chAbilitazioniRichieste
            // 
            this.chAbilitazioniRichieste.Text = "Abilitazioni Richieste";
            this.chAbilitazioniRichieste.Width = 500;
            // 
            // FrmCdCs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 254);
            this.Controls.Add(this.lvCdCs);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.brModifica);
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
        private System.Windows.Forms.Button brModifica;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.ListView lvCdCs;
        private System.Windows.Forms.ColumnHeader chLivello;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chAbilitazioniRichieste;
    }
}