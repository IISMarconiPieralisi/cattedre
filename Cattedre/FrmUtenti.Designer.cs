namespace Cattedre
{
    partial class FrmUtenti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtenti));
            this.lvUtenti = new System.Windows.Forms.ListView();
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCognome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTipoUtente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTipoDocente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTipoContratto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMonteOre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataInzio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataFine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btInserisci = new System.Windows.Forms.Button();
            this.btModifica = new System.Windows.Forms.Button();
            this.btElimina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvUtenti
            // 
            this.lvUtenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUtenti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNome,
            this.chCognome,
            this.chEmail,
            this.chTipoUtente,
            this.chTipoDocente,
            this.chTipoContratto,
            this.chMonteOre,
            this.chDataInzio,
            this.chDataFine});
            this.lvUtenti.FullRowSelect = true;
            this.lvUtenti.HideSelection = false;
            this.lvUtenti.Location = new System.Drawing.Point(45, 56);
            this.lvUtenti.Name = "lvUtenti";
            this.lvUtenti.Size = new System.Drawing.Size(1008, 389);
            this.lvUtenti.TabIndex = 0;
            this.lvUtenti.UseCompatibleStateImageBehavior = false;
            this.lvUtenti.View = System.Windows.Forms.View.Details;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 84;
            // 
            // chCognome
            // 
            this.chCognome.Text = "Cognome";
            this.chCognome.Width = 82;
            // 
            // chEmail
            // 
            this.chEmail.Text = "Email";
            this.chEmail.Width = 220;
            // 
            // chTipoUtente
            // 
            this.chTipoUtente.Text = "Tipo Utente";
            this.chTipoUtente.Width = 167;
            // 
            // chTipoDocente
            // 
            this.chTipoDocente.Text = "Tipo Docente";
            this.chTipoDocente.Width = 92;
            // 
            // chTipoContratto
            // 
            this.chTipoContratto.Text = "Tipo Contratto";
            this.chTipoContratto.Width = 120;
            // 
            // chMonteOre
            // 
            this.chMonteOre.Text = "Monte ore";
            this.chMonteOre.Width = 70;
            // 
            // chDataInzio
            // 
            this.chDataInzio.Text = "Data Inizio";
            this.chDataInzio.Width = 90;
            // 
            // chDataFine
            // 
            this.chDataFine.Text = "Data Fine";
            this.chDataFine.Width = 90;
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInserisci.Location = new System.Drawing.Point(1059, 56);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.Size = new System.Drawing.Size(118, 23);
            this.btInserisci.TabIndex = 1;
            this.btInserisci.Text = "Inserisci";
            this.btInserisci.UseVisualStyleBackColor = true;
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // btModifica
            // 
            this.btModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModifica.Location = new System.Drawing.Point(1059, 85);
            this.btModifica.Name = "btModifica";
            this.btModifica.Size = new System.Drawing.Size(118, 23);
            this.btModifica.TabIndex = 2;
            this.btModifica.Text = "Modifica";
            this.btModifica.UseVisualStyleBackColor = true;
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // btElimina
            // 
            this.btElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btElimina.Location = new System.Drawing.Point(1059, 114);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(118, 23);
            this.btElimina.TabIndex = 3;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // FrmUtenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 495);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.lvUtenti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUtenti";
            this.Text = "Utenti";
            this.Load += new System.EventHandler(this.FrmUtenti_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvUtenti;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chCognome;
        private System.Windows.Forms.ColumnHeader chEmail;
        private System.Windows.Forms.ColumnHeader chTipoUtente;
        private System.Windows.Forms.ColumnHeader chTipoDocente;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.Button btModifica;
        private System.Windows.Forms.Button btElimina;
        private System.Windows.Forms.ColumnHeader chTipoContratto;
        private System.Windows.Forms.ColumnHeader chMonteOre;
        private System.Windows.Forms.ColumnHeader chDataInzio;
        private System.Windows.Forms.ColumnHeader chDataFine;
    }
}