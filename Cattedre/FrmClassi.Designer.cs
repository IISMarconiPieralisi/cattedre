namespace Cattedre
{
    partial class FrmClassi
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
            this.cbAnnoClasse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCerca = new System.Windows.Forms.Button();
            this.btElimina = new System.Windows.Forms.Button();
            this.brModifica = new System.Windows.Forms.Button();
            this.btInserisci = new System.Windows.Forms.Button();
            this.lvClassi = new System.Windows.Forms.ListView();
            this.chSigla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAnno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSezione = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClasseArticolataCon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNomeCoordinatore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndirizzo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btRipristina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbAnnoClasse
            // 
            this.cbAnnoClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnnoClasse.FormattingEnabled = true;
            this.cbAnnoClasse.Location = new System.Drawing.Point(97, 17);
            this.cbAnnoClasse.Name = "cbAnnoClasse";
            this.cbAnnoClasse.Size = new System.Drawing.Size(38, 21);
            this.cbAnnoClasse.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filtra per anno:";
            // 
            // btCerca
            // 
            this.btCerca.Location = new System.Drawing.Point(157, 15);
            this.btCerca.Name = "btCerca";
            this.btCerca.Size = new System.Drawing.Size(75, 23);
            this.btCerca.TabIndex = 18;
            this.btCerca.Text = "Cerca";
            this.btCerca.UseVisualStyleBackColor = true;
            this.btCerca.Click += new System.EventHandler(this.btCerca_Click);
            // 
            // btElimina
            // 
            this.btElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btElimina.Location = new System.Drawing.Point(563, 152);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(75, 23);
            this.btElimina.TabIndex = 17;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // brModifica
            // 
            this.brModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.brModifica.Location = new System.Drawing.Point(563, 108);
            this.brModifica.Name = "brModifica";
            this.brModifica.Size = new System.Drawing.Size(75, 23);
            this.brModifica.TabIndex = 16;
            this.brModifica.Text = "Modifica";
            this.brModifica.UseVisualStyleBackColor = true;
            this.brModifica.Click += new System.EventHandler(this.brModifica_Click);
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInserisci.Location = new System.Drawing.Point(563, 65);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.Size = new System.Drawing.Size(75, 23);
            this.btInserisci.TabIndex = 15;
            this.btInserisci.Text = "Inserisci";
            this.btInserisci.UseVisualStyleBackColor = true;
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // lvClassi
            // 
            this.lvClassi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvClassi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSigla,
            this.chAnno,
            this.chSezione,
            this.chClasseArticolataCon,
            this.chNomeCoordinatore,
            this.chIndirizzo});
            this.lvClassi.FullRowSelect = true;
            this.lvClassi.HideSelection = false;
            this.lvClassi.Location = new System.Drawing.Point(17, 67);
            this.lvClassi.Name = "lvClassi";
            this.lvClassi.Size = new System.Drawing.Size(540, 314);
            this.lvClassi.TabIndex = 14;
            this.lvClassi.UseCompatibleStateImageBehavior = false;
            this.lvClassi.View = System.Windows.Forms.View.Details;
            // 
            // chSigla
            // 
            this.chSigla.Text = "Sigla";
            // 
            // chAnno
            // 
            this.chAnno.Text = "Anno";
            // 
            // chSezione
            // 
            this.chSezione.Text = "Sezione";
            // 
            // chClasseArticolataCon
            // 
            this.chClasseArticolataCon.Text = "Articolata Con";
            this.chClasseArticolataCon.Width = 83;
            // 
            // chNomeCoordinatore
            // 
            this.chNomeCoordinatore.Text = "Nome Coordinatore";
            this.chNomeCoordinatore.Width = 171;
            // 
            // chIndirizzo
            // 
            this.chIndirizzo.Text = "Indirizzo";
            this.chIndirizzo.Width = 102;
            // 
            // btRipristina
            // 
            this.btRipristina.Location = new System.Drawing.Point(238, 15);
            this.btRipristina.Name = "btRipristina";
            this.btRipristina.Size = new System.Drawing.Size(75, 23);
            this.btRipristina.TabIndex = 21;
            this.btRipristina.Text = "Ripristina";
            this.btRipristina.UseVisualStyleBackColor = true;
            this.btRipristina.Click += new System.EventHandler(this.btRipristina_Click);
            // 
            // FrmClassi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 396);
            this.Controls.Add(this.btRipristina);
            this.Controls.Add(this.cbAnnoClasse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCerca);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.brModifica);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.lvClassi);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmClassi";
            this.Text = "FrmClassi";
            this.Load += new System.EventHandler(this.FrmClassi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAnnoClasse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCerca;
        private System.Windows.Forms.Button btElimina;
        private System.Windows.Forms.Button brModifica;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.ListView lvClassi;
        private System.Windows.Forms.ColumnHeader chSigla;
        private System.Windows.Forms.ColumnHeader chAnno;
        private System.Windows.Forms.ColumnHeader chSezione;
        private System.Windows.Forms.ColumnHeader chClasseArticolataCon;
        private System.Windows.Forms.ColumnHeader chNomeCoordinatore;
        private System.Windows.Forms.Button btRipristina;
        private System.Windows.Forms.ColumnHeader chIndirizzo;
    }
}