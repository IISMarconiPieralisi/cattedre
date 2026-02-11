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
            this.pnFiltra = new System.Windows.Forms.Panel();
            this.btAnnullaFiltra = new System.Windows.Forms.Button();
            this.tlpFiltri = new System.Windows.Forms.TableLayoutPanel();
            this.btFiltro = new System.Windows.Forms.Button();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnRicerca = new System.Windows.Forms.Panel();
            this.tbRicerca = new System.Windows.Forms.TextBox();
            this.btAnnullaRicerca = new System.Windows.Forms.Button();
            this.btRicerca = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnFiltra.SuspendLayout();
            this.pnRicerca.SuspendLayout();
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
            this.lvUtenti.Location = new System.Drawing.Point(45, 105);
            this.lvUtenti.Name = "lvUtenti";
            this.lvUtenti.Size = new System.Drawing.Size(1045, 542);
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
            this.btInserisci.Location = new System.Drawing.Point(1096, 105);
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
            this.btModifica.Location = new System.Drawing.Point(1096, 134);
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
            this.btElimina.Location = new System.Drawing.Point(1096, 163);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(118, 23);
            this.btElimina.TabIndex = 3;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // pnFiltra
            // 
            this.pnFiltra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnFiltra.Controls.Add(this.btAnnullaFiltra);
            this.pnFiltra.Controls.Add(this.tlpFiltri);
            this.pnFiltra.Controls.Add(this.btFiltro);
            this.pnFiltra.Controls.Add(this.cbFiltro);
            this.pnFiltra.Controls.Add(this.label1);
            this.pnFiltra.Location = new System.Drawing.Point(42, 28);
            this.pnFiltra.Name = "pnFiltra";
            this.pnFiltra.Size = new System.Drawing.Size(1048, 71);
            this.pnFiltra.TabIndex = 4;
            // 
            // btAnnullaFiltra
            // 
            this.btAnnullaFiltra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAnnullaFiltra.Enabled = false;
            this.btAnnullaFiltra.Location = new System.Drawing.Point(944, 16);
            this.btAnnullaFiltra.Name = "btAnnullaFiltra";
            this.btAnnullaFiltra.Size = new System.Drawing.Size(87, 23);
            this.btAnnullaFiltra.TabIndex = 4;
            this.btAnnullaFiltra.Text = "Annulla";
            this.btAnnullaFiltra.UseVisualStyleBackColor = true;
            this.btAnnullaFiltra.Click += new System.EventHandler(this.btAnnullaFiltra_Click);
            // 
            // tlpFiltri
            // 
            this.tlpFiltri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFiltri.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpFiltri.ColumnCount = 1;
            this.tlpFiltri.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltri.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltri.Location = new System.Drawing.Point(217, 16);
            this.tlpFiltri.Name = "tlpFiltri";
            this.tlpFiltri.RowCount = 1;
            this.tlpFiltri.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltri.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltri.Size = new System.Drawing.Size(619, 32);
            this.tlpFiltri.TabIndex = 3;
            // 
            // btFiltro
            // 
            this.btFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFiltro.Enabled = false;
            this.btFiltro.Location = new System.Drawing.Point(855, 16);
            this.btFiltro.Name = "btFiltro";
            this.btFiltro.Size = new System.Drawing.Size(83, 23);
            this.btFiltro.TabIndex = 2;
            this.btFiltro.Text = "Filtra";
            this.btFiltro.UseVisualStyleBackColor = true;
            this.btFiltro.Click += new System.EventHandler(this.btFiltro_Click);
            // 
            // cbFiltro
            // 
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Items.AddRange(new object[] {
            "Tipo Utente",
            "Tipo Docente",
            "Tipo Contratto"});
            this.cbFiltro.Location = new System.Drawing.Point(68, 18);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(130, 21);
            this.cbFiltro.TabIndex = 1;
            this.cbFiltro.SelectedIndexChanged += new System.EventHandler(this.cbFiltro_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtra per:";
            // 
            // pnRicerca
            // 
            this.pnRicerca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnRicerca.Controls.Add(this.tbRicerca);
            this.pnRicerca.Controls.Add(this.btAnnullaRicerca);
            this.pnRicerca.Controls.Add(this.btRicerca);
            this.pnRicerca.Controls.Add(this.label2);
            this.pnRicerca.Location = new System.Drawing.Point(45, 662);
            this.pnRicerca.Name = "pnRicerca";
            this.pnRicerca.Size = new System.Drawing.Size(1045, 71);
            this.pnRicerca.TabIndex = 5;
            // 
            // tbRicerca
            // 
            this.tbRicerca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRicerca.ForeColor = System.Drawing.Color.Gray;
            this.tbRicerca.Location = new System.Drawing.Point(83, 19);
            this.tbRicerca.Name = "tbRicerca";
            this.tbRicerca.Size = new System.Drawing.Size(718, 20);
            this.tbRicerca.TabIndex = 5;
            this.tbRicerca.Text = "cognome nome";
            this.tbRicerca.TextChanged += new System.EventHandler(this.tbRicerca_TextChanged);
            this.tbRicerca.Enter += new System.EventHandler(this.tbRicerca_Enter);
            this.tbRicerca.Leave += new System.EventHandler(this.tbRicerca_Leave);
            // 
            // btAnnullaRicerca
            // 
            this.btAnnullaRicerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAnnullaRicerca.Enabled = false;
            this.btAnnullaRicerca.Location = new System.Drawing.Point(941, 16);
            this.btAnnullaRicerca.Name = "btAnnullaRicerca";
            this.btAnnullaRicerca.Size = new System.Drawing.Size(87, 23);
            this.btAnnullaRicerca.TabIndex = 4;
            this.btAnnullaRicerca.Text = "Annulla";
            this.btAnnullaRicerca.UseVisualStyleBackColor = true;
            this.btAnnullaRicerca.Click += new System.EventHandler(this.btAnnullaRicerca_Click);
            // 
            // btRicerca
            // 
            this.btRicerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRicerca.Enabled = false;
            this.btRicerca.Location = new System.Drawing.Point(852, 16);
            this.btRicerca.Name = "btRicerca";
            this.btRicerca.Size = new System.Drawing.Size(83, 23);
            this.btRicerca.TabIndex = 2;
            this.btRicerca.Text = "Filtra";
            this.btRicerca.UseVisualStyleBackColor = true;
            this.btRicerca.Click += new System.EventHandler(this.btRicerca_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ricerca per:";
            // 
            // FrmUtenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 745);
            this.Controls.Add(this.pnRicerca);
            this.Controls.Add(this.pnFiltra);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.lvUtenti);
            this.Name = "FrmUtenti";
            this.Text = "Utenti";
            this.Load += new System.EventHandler(this.FrmUtenti_Load);
            this.pnFiltra.ResumeLayout(false);
            this.pnFiltra.PerformLayout();
            this.pnRicerca.ResumeLayout(false);
            this.pnRicerca.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel pnFiltra;
        private System.Windows.Forms.Button btFiltro;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tlpFiltri;
        private System.Windows.Forms.Button btAnnullaFiltra;
        private System.Windows.Forms.Panel pnRicerca;
        private System.Windows.Forms.TextBox tbRicerca;
        private System.Windows.Forms.Button btAnnullaRicerca;
        private System.Windows.Forms.Button btRicerca;
        private System.Windows.Forms.Label label2;
    }
}