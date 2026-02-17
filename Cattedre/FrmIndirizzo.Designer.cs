namespace Cattedre
{
    partial class FrmIndirizzo
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
            this.btSalvaIndirizzo = new System.Windows.Forms.Button();
            this.btAnnulla = new System.Windows.Forms.Button();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSalvaIndirizzo
            // 
            this.btSalvaIndirizzo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSalvaIndirizzo.Location = new System.Drawing.Point(132, 94);
            this.btSalvaIndirizzo.Margin = new System.Windows.Forms.Padding(2);
            this.btSalvaIndirizzo.Name = "btSalvaIndirizzo";
            this.btSalvaIndirizzo.Size = new System.Drawing.Size(116, 25);
            this.btSalvaIndirizzo.TabIndex = 19;
            this.btSalvaIndirizzo.Text = "Salva";
            this.btSalvaIndirizzo.UseVisualStyleBackColor = true;
            this.btSalvaIndirizzo.Click += new System.EventHandler(this.btSalvaIndirizzo_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Location = new System.Drawing.Point(12, 94);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(116, 25);
            this.btAnnulla.TabIndex = 18;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(95, 21);
            this.tbNome.Margin = new System.Windows.Forms.Padding(2);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(153, 20);
            this.tbNome.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome:";
            // 
            // FrmIndirizzo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 142);
            this.Controls.Add(this.btSalvaIndirizzo);
            this.Controls.Add(this.btAnnulla);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmIndirizzo";
            this.Text = "FrmIndirizzo";
            this.Load += new System.EventHandler(this.FrmIndirizzo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSalvaIndirizzo;
        private System.Windows.Forms.Button btAnnulla;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.Label label1;
    }
}