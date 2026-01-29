namespace Cattedre
{
    partial class FrmAnniScolastici
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnniScolastici));
            this.lvAnniScolastici = new System.Windows.Forms.ListView();
            this.chSigla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataInizio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataFine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btInserisci = new System.Windows.Forms.Button();
            this.btModifica = new System.Windows.Forms.Button();
            this.btElimina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvAnniScolastici
            // 
            this.lvAnniScolastici.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSigla,
            this.chDataInizio,
            this.chDataFine});
            this.lvAnniScolastici.FullRowSelect = true;
            this.lvAnniScolastici.HideSelection = false;
            this.lvAnniScolastici.Location = new System.Drawing.Point(28, 42);
            this.lvAnniScolastici.Name = "lvAnniScolastici";
            this.lvAnniScolastici.Size = new System.Drawing.Size(247, 169);
            this.lvAnniScolastici.TabIndex = 0;
            this.lvAnniScolastici.UseCompatibleStateImageBehavior = false;
            this.lvAnniScolastici.View = System.Windows.Forms.View.Details;
            // 
            // chSigla
            // 
            this.chSigla.Text = "Sigla";
            // 
            // chDataInizio
            // 
            this.chDataInizio.Text = "Data Inizio";
            this.chDataInizio.Width = 100;
            // 
            // chDataFine
            // 
            this.chDataFine.Text = "Data Fine";
            this.chDataFine.Width = 100;
            // 
            // btInserisci
            // 
            this.btInserisci.Location = new System.Drawing.Point(328, 60);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.Size = new System.Drawing.Size(75, 23);
            this.btInserisci.TabIndex = 1;
            this.btInserisci.Text = "Inserisci";
            this.btInserisci.UseVisualStyleBackColor = true;
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // btModifica
            // 
            this.btModifica.Location = new System.Drawing.Point(328, 101);
            this.btModifica.Name = "btModifica";
            this.btModifica.Size = new System.Drawing.Size(75, 23);
            this.btModifica.TabIndex = 2;
            this.btModifica.Text = "Modifica";
            this.btModifica.UseVisualStyleBackColor = true;
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // btElimina
            // 
            this.btElimina.Location = new System.Drawing.Point(328, 144);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(75, 23);
            this.btElimina.TabIndex = 3;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // FrmAnniScolastici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 258);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.lvAnniScolastici);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAnniScolastici";
            this.Text = "Anni Scolastici";
            this.Load += new System.EventHandler(this.FrmAnniScolastici_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvAnniScolastici;
        private System.Windows.Forms.ColumnHeader chSigla;
        private System.Windows.Forms.ColumnHeader chDataInizio;
        private System.Windows.Forms.ColumnHeader chDataFine;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.Button btModifica;
        private System.Windows.Forms.Button btElimina;
    }
}