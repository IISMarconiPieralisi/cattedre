namespace Cattedre
{
    partial class FrmIndirizzi
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
            this.cbIndirizzo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCerca = new System.Windows.Forms.Button();
            this.btElimina = new System.Windows.Forms.Button();
            this.brModifica = new System.Windows.Forms.Button();
            this.btInserisci = new System.Windows.Forms.Button();
            this.lvIndirizzi = new System.Windows.Forms.ListView();
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cbIndirizzo
            // 
            this.cbIndirizzo.FormattingEnabled = true;
            this.cbIndirizzo.Location = new System.Drawing.Point(103, 25);
            this.cbIndirizzo.Name = "cbIndirizzo";
            this.cbIndirizzo.Size = new System.Drawing.Size(226, 21);
            this.cbIndirizzo.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filtra per indirizzo:";
            // 
            // btCerca
            // 
            this.btCerca.Location = new System.Drawing.Point(335, 23);
            this.btCerca.Name = "btCerca";
            this.btCerca.Size = new System.Drawing.Size(75, 23);
            this.btCerca.TabIndex = 18;
            this.btCerca.Text = "Cerca";
            this.btCerca.UseVisualStyleBackColor = true;
            this.btCerca.Click += new System.EventHandler(this.btCerca_Click);
            // 
            // btElimina
            // 
            this.btElimina.Location = new System.Drawing.Point(292, 199);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(75, 23);
            this.btElimina.TabIndex = 17;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // brModifica
            // 
            this.brModifica.Location = new System.Drawing.Point(292, 144);
            this.brModifica.Name = "brModifica";
            this.brModifica.Size = new System.Drawing.Size(75, 23);
            this.brModifica.TabIndex = 16;
            this.brModifica.Text = "Modifica";
            this.brModifica.UseVisualStyleBackColor = true;
            this.brModifica.Click += new System.EventHandler(this.brModifica_Click);
            // 
            // btInserisci
            // 
            this.btInserisci.Location = new System.Drawing.Point(292, 92);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.Size = new System.Drawing.Size(75, 23);
            this.btInserisci.TabIndex = 15;
            this.btInserisci.Text = "Inserisci";
            this.btInserisci.UseVisualStyleBackColor = true;
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // lvIndirizzi
            // 
            this.lvIndirizzi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNome});
            this.lvIndirizzi.FullRowSelect = true;
            this.lvIndirizzi.HideSelection = false;
            this.lvIndirizzi.Location = new System.Drawing.Point(10, 76);
            this.lvIndirizzi.Name = "lvIndirizzi";
            this.lvIndirizzi.Size = new System.Drawing.Size(188, 314);
            this.lvIndirizzi.TabIndex = 14;
            this.lvIndirizzi.UseCompatibleStateImageBehavior = false;
            this.lvIndirizzi.View = System.Windows.Forms.View.Details;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 184;
            // 
            // FrmIndirizzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 415);
            this.Controls.Add(this.cbIndirizzo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCerca);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.brModifica);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.lvIndirizzi);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmIndirizzi";
            this.Text = "Indirizzi";
            this.Load += new System.EventHandler(this.FrmIndirizzi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIndirizzo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCerca;
        private System.Windows.Forms.Button btElimina;
        private System.Windows.Forms.Button brModifica;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.ListView lvIndirizzi;
        private System.Windows.Forms.ColumnHeader chNome;
    }
}