namespace Cattedre
{
    partial class FrmCdC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCdC));
            this.btSava = new System.Windows.Forms.Button();
            this.btAnnulla = new System.Windows.Forms.Button();
            this.tbLivello = new System.Windows.Forms.TextBox();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbAbilitazioni = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btSava
            // 
            this.btSava.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSava.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSava.Location = new System.Drawing.Point(208, 191);
            this.btSava.Margin = new System.Windows.Forms.Padding(2);
            this.btSava.Name = "btSava";
            this.btSava.Size = new System.Drawing.Size(56, 19);
            this.btSava.TabIndex = 19;
            this.btSava.Text = "Salva";
            this.btSava.UseVisualStyleBackColor = true;
            this.btSava.Click += new System.EventHandler(this.btSava_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAnnulla.Location = new System.Drawing.Point(79, 191);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(56, 19);
            this.btAnnulla.TabIndex = 18;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbLivello
            // 
            this.tbLivello.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLivello.Location = new System.Drawing.Point(138, 11);
            this.tbLivello.Margin = new System.Windows.Forms.Padding(2);
            this.tbLivello.Name = "tbLivello";
            this.tbLivello.Size = new System.Drawing.Size(126, 21);
            this.tbLivello.TabIndex = 15;
            // 
            // tbNome
            // 
            this.tbNome.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNome.Location = new System.Drawing.Point(138, 52);
            this.tbNome.Margin = new System.Windows.Forms.Padding(2);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(232, 21);
            this.tbNome.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Abilitazioni richeste:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Livello:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome:";
            // 
            // rtbAbilitazioni
            // 
            this.rtbAbilitazioni.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAbilitazioni.Location = new System.Drawing.Point(140, 94);
            this.rtbAbilitazioni.Margin = new System.Windows.Forms.Padding(2);
            this.rtbAbilitazioni.Name = "rtbAbilitazioni";
            this.rtbAbilitazioni.Size = new System.Drawing.Size(126, 71);
            this.rtbAbilitazioni.TabIndex = 20;
            this.rtbAbilitazioni.Text = "";
            // 
            // FrmCdC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 260);
            this.Controls.Add(this.rtbAbilitazioni);
            this.Controls.Add(this.btSava);
            this.Controls.Add(this.btAnnulla);
            this.Controls.Add(this.tbLivello);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmCdC";
            this.Text = "Classe di concorso";
            this.Load += new System.EventHandler(this.FrmCdC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSava;
        private System.Windows.Forms.Button btAnnulla;
        private System.Windows.Forms.TextBox tbLivello;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbAbilitazioni;
    }
}