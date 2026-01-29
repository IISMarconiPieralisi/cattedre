namespace Cattedre
{
    partial class FrmDipartimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDipartimento));
            this.label1 = new System.Windows.Forms.Label();
            this.tbNomeDipartimento = new System.Windows.Forms.TextBox();
            this.btAnnulla = new System.Windows.Forms.Button();
            this.btSalvaDipartimento = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCoordinatore = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // tbNomeDipartimento
            // 
            this.tbNomeDipartimento.Location = new System.Drawing.Point(91, 21);
            this.tbNomeDipartimento.Margin = new System.Windows.Forms.Padding(2);
            this.tbNomeDipartimento.Name = "tbNomeDipartimento";
            this.tbNomeDipartimento.Size = new System.Drawing.Size(146, 20);
            this.tbNomeDipartimento.TabIndex = 4;
            // 
            // btAnnulla
            // 
            this.btAnnulla.Location = new System.Drawing.Point(47, 138);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(56, 19);
            this.btAnnulla.TabIndex = 8;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // btSalvaDipartimento
            // 
            this.btSalvaDipartimento.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSalvaDipartimento.Location = new System.Drawing.Point(155, 138);
            this.btSalvaDipartimento.Margin = new System.Windows.Forms.Padding(2);
            this.btSalvaDipartimento.Name = "btSalvaDipartimento";
            this.btSalvaDipartimento.Size = new System.Drawing.Size(56, 19);
            this.btSalvaDipartimento.TabIndex = 9;
            this.btSalvaDipartimento.Text = "Salva";
            this.btSalvaDipartimento.UseVisualStyleBackColor = true;
            this.btSalvaDipartimento.Click += new System.EventHandler(this.btSalvaDipartimento_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Coordinatore:";
            // 
            // cbCoordinatore
            // 
            this.cbCoordinatore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoordinatore.FormattingEnabled = true;
            this.cbCoordinatore.Location = new System.Drawing.Point(91, 80);
            this.cbCoordinatore.Name = "cbCoordinatore";
            this.cbCoordinatore.Size = new System.Drawing.Size(146, 21);
            this.cbCoordinatore.TabIndex = 11;
            // 
            // FrmDipartimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 177);
            this.Controls.Add(this.cbCoordinatore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSalvaDipartimento);
            this.Controls.Add(this.btAnnulla);
            this.Controls.Add(this.tbNomeDipartimento);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDipartimento";
            this.Text = "Dipartimento";
            this.Load += new System.EventHandler(this.FrmDipartimento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNomeDipartimento;
        private System.Windows.Forms.Button btAnnulla;
        private System.Windows.Forms.Button btSalvaDipartimento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCoordinatore;
    }
}