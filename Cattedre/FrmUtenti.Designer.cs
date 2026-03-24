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
            this.chTipoContratto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMonteOre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataInzio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataFine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btInserisci = new System.Windows.Forms.Button();
            this.btModifica = new System.Windows.Forms.Button();
            this.btElimina = new System.Windows.Forms.Button();
            this.tbRicerca = new System.Windows.Forms.TextBox();
            this.gbContratto = new System.Windows.Forms.GroupBox();
            this.rbIndireterminato = new System.Windows.Forms.RadioButton();
            this.rbDeterminato = new System.Windows.Forms.RadioButton();
            this.gBtipoDocente = new System.Windows.Forms.GroupBox();
            this.rbPratico = new System.Windows.Forms.RadioButton();
            this.rdTeorico = new System.Windows.Forms.RadioButton();
            this.gbTipiUtenti = new System.Windows.Forms.GroupBox();
            this.cbDocente = new System.Windows.Forms.CheckBox();
            this.cbCoordinatore = new System.Windows.Forms.CheckBox();
            this.cbAmminstratore = new System.Windows.Forms.CheckBox();
            this.cbPreside = new System.Windows.Forms.CheckBox();
            this.btAnnullaFiltra = new System.Windows.Forms.Button();
            this.btFiltro = new System.Windows.Forms.Button();
            this.gbContratto.SuspendLayout();
            this.gBtipoDocente.SuspendLayout();
            this.gbTipiUtenti.SuspendLayout();
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
            this.chTipoContratto,
            this.chMonteOre,
            this.chDataInzio,
            this.chDataFine});
            this.lvUtenti.FullRowSelect = true;
            this.lvUtenti.HideSelection = false;
            this.lvUtenti.Location = new System.Drawing.Point(45, 89);
            this.lvUtenti.Name = "lvUtenti";
            this.lvUtenti.Size = new System.Drawing.Size(1286, 631);
            this.lvUtenti.TabIndex = 0;
            this.lvUtenti.UseCompatibleStateImageBehavior = false;
            this.lvUtenti.View = System.Windows.Forms.View.Details;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 100;
            // 
            // chCognome
            // 
            this.chCognome.Text = "Cognome";
            this.chCognome.Width = 100;
            // 
            // chEmail
            // 
            this.chEmail.Text = "Email";
            this.chEmail.Width = 240;
            // 
            // chTipoUtente
            // 
            this.chTipoUtente.Text = "Tipo Utente";
            this.chTipoUtente.Width = 220;
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
            this.btInserisci.Location = new System.Drawing.Point(1337, 89);
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
            this.btModifica.Location = new System.Drawing.Point(1337, 118);
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
            this.btElimina.Location = new System.Drawing.Point(1337, 147);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(118, 23);
            this.btElimina.TabIndex = 3;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // tbRicerca
            // 
            this.tbRicerca.ForeColor = System.Drawing.Color.Gray;
            this.tbRicerca.Location = new System.Drawing.Point(750, 37);
            this.tbRicerca.Name = "tbRicerca";
            this.tbRicerca.Size = new System.Drawing.Size(182, 20);
            this.tbRicerca.TabIndex = 6;
            this.tbRicerca.Text = "cognome nome";
            this.tbRicerca.Enter += new System.EventHandler(this.tbRicerca_Enter);
            this.tbRicerca.Leave += new System.EventHandler(this.tbRicerca_Leave);
            // 
            // gbContratto
            // 
            this.gbContratto.Controls.Add(this.rbIndireterminato);
            this.gbContratto.Controls.Add(this.rbDeterminato);
            this.gbContratto.Location = new System.Drawing.Point(564, 20);
            this.gbContratto.Name = "gbContratto";
            this.gbContratto.Size = new System.Drawing.Size(180, 47);
            this.gbContratto.TabIndex = 9;
            this.gbContratto.TabStop = false;
            this.gbContratto.Text = "Contratto";
            // 
            // rbIndireterminato
            // 
            this.rbIndireterminato.AutoSize = true;
            this.rbIndireterminato.Location = new System.Drawing.Point(86, 20);
            this.rbIndireterminato.Name = "rbIndireterminato";
            this.rbIndireterminato.Size = new System.Drawing.Size(89, 17);
            this.rbIndireterminato.TabIndex = 1;
            this.rbIndireterminato.TabStop = true;
            this.rbIndireterminato.Text = "Indeterminato";
            this.rbIndireterminato.UseVisualStyleBackColor = true;
            // 
            // rbDeterminato
            // 
            this.rbDeterminato.AutoSize = true;
            this.rbDeterminato.Location = new System.Drawing.Point(7, 20);
            this.rbDeterminato.Name = "rbDeterminato";
            this.rbDeterminato.Size = new System.Drawing.Size(82, 17);
            this.rbDeterminato.TabIndex = 0;
            this.rbDeterminato.TabStop = true;
            this.rbDeterminato.Text = "Determinato";
            this.rbDeterminato.UseVisualStyleBackColor = true;
            // 
            // gBtipoDocente
            // 
            this.gBtipoDocente.Controls.Add(this.rbPratico);
            this.gBtipoDocente.Controls.Add(this.rdTeorico);
            this.gBtipoDocente.Enabled = false;
            this.gBtipoDocente.Location = new System.Drawing.Point(400, 20);
            this.gBtipoDocente.Name = "gBtipoDocente";
            this.gBtipoDocente.Size = new System.Drawing.Size(158, 47);
            this.gBtipoDocente.TabIndex = 8;
            this.gBtipoDocente.TabStop = false;
            this.gBtipoDocente.Text = "Docente";
            // 
            // rbPratico
            // 
            this.rbPratico.AutoSize = true;
            this.rbPratico.Location = new System.Drawing.Point(74, 20);
            this.rbPratico.Name = "rbPratico";
            this.rbPratico.Size = new System.Drawing.Size(78, 17);
            this.rbPratico.TabIndex = 1;
            this.rbPratico.TabStop = true;
            this.rbPratico.Text = "Laboratorio";
            this.rbPratico.UseVisualStyleBackColor = true;
            // 
            // rdTeorico
            // 
            this.rdTeorico.AutoSize = true;
            this.rdTeorico.Location = new System.Drawing.Point(7, 20);
            this.rdTeorico.Name = "rdTeorico";
            this.rdTeorico.Size = new System.Drawing.Size(61, 17);
            this.rdTeorico.TabIndex = 0;
            this.rdTeorico.TabStop = true;
            this.rdTeorico.Text = "Teorico";
            this.rdTeorico.UseVisualStyleBackColor = true;
            // 
            // gbTipiUtenti
            // 
            this.gbTipiUtenti.Controls.Add(this.cbDocente);
            this.gbTipiUtenti.Controls.Add(this.cbCoordinatore);
            this.gbTipiUtenti.Controls.Add(this.cbAmminstratore);
            this.gbTipiUtenti.Controls.Add(this.cbPreside);
            this.gbTipiUtenti.Location = new System.Drawing.Point(45, 20);
            this.gbTipiUtenti.Name = "gbTipiUtenti";
            this.gbTipiUtenti.Size = new System.Drawing.Size(349, 47);
            this.gbTipiUtenti.TabIndex = 7;
            this.gbTipiUtenti.TabStop = false;
            this.gbTipiUtenti.Text = "Utente";
            // 
            // cbDocente
            // 
            this.cbDocente.AutoSize = true;
            this.cbDocente.Location = new System.Drawing.Point(277, 20);
            this.cbDocente.Name = "cbDocente";
            this.cbDocente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbDocente.Size = new System.Drawing.Size(67, 17);
            this.cbDocente.TabIndex = 7;
            this.cbDocente.Text = "Docente";
            this.cbDocente.UseVisualStyleBackColor = true;
            this.cbDocente.CheckedChanged += new System.EventHandler(this.cbDocente_CheckedChanged);
            // 
            // cbCoordinatore
            // 
            this.cbCoordinatore.AutoSize = true;
            this.cbCoordinatore.Location = new System.Drawing.Point(185, 20);
            this.cbCoordinatore.Name = "cbCoordinatore";
            this.cbCoordinatore.Size = new System.Drawing.Size(86, 17);
            this.cbCoordinatore.TabIndex = 6;
            this.cbCoordinatore.Text = "Coordinatore";
            this.cbCoordinatore.UseVisualStyleBackColor = true;
            // 
            // cbAmminstratore
            // 
            this.cbAmminstratore.AutoSize = true;
            this.cbAmminstratore.Location = new System.Drawing.Point(85, 20);
            this.cbAmminstratore.Name = "cbAmminstratore";
            this.cbAmminstratore.Size = new System.Drawing.Size(94, 17);
            this.cbAmminstratore.TabIndex = 5;
            this.cbAmminstratore.Text = "Amministratore";
            this.cbAmminstratore.UseVisualStyleBackColor = true;
            // 
            // cbPreside
            // 
            this.cbPreside.AutoSize = true;
            this.cbPreside.Location = new System.Drawing.Point(18, 20);
            this.cbPreside.Name = "cbPreside";
            this.cbPreside.Size = new System.Drawing.Size(61, 17);
            this.cbPreside.TabIndex = 4;
            this.cbPreside.Text = "Preside";
            this.cbPreside.UseVisualStyleBackColor = true;
            // 
            // btAnnullaFiltra
            // 
            this.btAnnullaFiltra.Location = new System.Drawing.Point(938, 37);
            this.btAnnullaFiltra.Name = "btAnnullaFiltra";
            this.btAnnullaFiltra.Size = new System.Drawing.Size(34, 23);
            this.btAnnullaFiltra.TabIndex = 4;
            this.btAnnullaFiltra.Text = "X";
            this.btAnnullaFiltra.UseVisualStyleBackColor = true;
            this.btAnnullaFiltra.Click += new System.EventHandler(this.btAnnullaFiltra_Click);
            // 
            // btFiltro
            // 
            this.btFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFiltro.Location = new System.Drawing.Point(1337, 35);
            this.btFiltro.Name = "btFiltro";
            this.btFiltro.Size = new System.Drawing.Size(118, 23);
            this.btFiltro.TabIndex = 2;
            this.btFiltro.Text = "Cerca";
            this.btFiltro.UseVisualStyleBackColor = true;
            this.btFiltro.Click += new System.EventHandler(this.btFiltro_Click);
            // 
            // FrmUtenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 745);
            this.Controls.Add(this.tbRicerca);
            this.Controls.Add(this.gbContratto);
            this.Controls.Add(this.gBtipoDocente);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.gbTipiUtenti);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btAnnullaFiltra);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.btFiltro);
            this.Controls.Add(this.lvUtenti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUtenti";
            this.Text = "Utenti";
            this.Load += new System.EventHandler(this.FrmUtenti_Load);
            this.gbContratto.ResumeLayout(false);
            this.gbContratto.PerformLayout();
            this.gBtipoDocente.ResumeLayout(false);
            this.gBtipoDocente.PerformLayout();
            this.gbTipiUtenti.ResumeLayout(false);
            this.gbTipiUtenti.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUtenti;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chCognome;
        private System.Windows.Forms.ColumnHeader chEmail;
        private System.Windows.Forms.ColumnHeader chTipoUtente;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.Button btModifica;
        private System.Windows.Forms.Button btElimina;
        private System.Windows.Forms.ColumnHeader chTipoContratto;
        private System.Windows.Forms.ColumnHeader chMonteOre;
        private System.Windows.Forms.ColumnHeader chDataInzio;
        private System.Windows.Forms.ColumnHeader chDataFine;
        private System.Windows.Forms.Button btFiltro;
        private System.Windows.Forms.Button btAnnullaFiltra;
        private System.Windows.Forms.GroupBox gbContratto;
        private System.Windows.Forms.RadioButton rbIndireterminato;
        private System.Windows.Forms.RadioButton rbDeterminato;
        private System.Windows.Forms.GroupBox gBtipoDocente;
        private System.Windows.Forms.RadioButton rbPratico;
        private System.Windows.Forms.RadioButton rdTeorico;
        private System.Windows.Forms.GroupBox gbTipiUtenti;
        private System.Windows.Forms.CheckBox cbDocente;
        private System.Windows.Forms.CheckBox cbCoordinatore;
        private System.Windows.Forms.CheckBox cbAmminstratore;
        private System.Windows.Forms.CheckBox cbPreside;
        private System.Windows.Forms.TextBox tbRicerca;
    }
}