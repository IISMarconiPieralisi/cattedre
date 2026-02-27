namespace Cattedre
{
    partial class FrmDipartimenti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDipartimenti));
            this.lvDipartimenti = new System.Windows.Forms.ListView();
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCoordinatore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btInserisci = new System.Windows.Forms.Button();
            this.btModifica = new System.Windows.Forms.Button();
            this.btElimina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvDipartimenti
            // 
            this.lvDipartimenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDipartimenti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNome,
            this.chCoordinatore});
            this.lvDipartimenti.FullRowSelect = true;
            this.lvDipartimenti.HideSelection = false;
            this.lvDipartimenti.Location = new System.Drawing.Point(23, 18);
            this.lvDipartimenti.Name = "lvDipartimenti";
            this.lvDipartimenti.Size = new System.Drawing.Size(374, 314);
            this.lvDipartimenti.TabIndex = 0;
            this.lvDipartimenti.UseCompatibleStateImageBehavior = false;
            this.lvDipartimenti.View = System.Windows.Forms.View.Details;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 200;
            // 
            // chCoordinatore
            // 
            this.chCoordinatore.Text = "Coordinatore";
            this.chCoordinatore.Width = 170;
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInserisci.Location = new System.Drawing.Point(403, 19);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.Size = new System.Drawing.Size(75, 23);
            this.btInserisci.TabIndex = 1;
            this.btInserisci.Text = "Inserisci";
            this.btInserisci.UseVisualStyleBackColor = true;
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // btModifica
            // 
            this.btModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModifica.Location = new System.Drawing.Point(403, 48);
            this.btModifica.Name = "btModifica";
            this.btModifica.Size = new System.Drawing.Size(75, 23);
            this.btModifica.TabIndex = 2;
            this.btModifica.Text = "Modifica";
            this.btModifica.UseVisualStyleBackColor = true;
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // btElimina
            // 
            this.btElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btElimina.Location = new System.Drawing.Point(403, 77);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(75, 23);
            this.btElimina.TabIndex = 3;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // FrmDipartimenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 358);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.lvDipartimenti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDipartimenti";
            this.Text = "Dipartimenti";
            this.Load += new System.EventHandler(this.FrmDipartimenti_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDipartimenti;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.Button btModifica;
        private System.Windows.Forms.Button btElimina;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chCoordinatore;
    }
}