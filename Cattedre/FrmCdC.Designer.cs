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
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSava
            // 
            this.btSava.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSava.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btSava.Location = new System.Drawing.Point(39, 254);
            this.btSava.Margin = new System.Windows.Forms.Padding(2);
            this.btSava.Name = "btSava";
            this.btSava.Size = new System.Drawing.Size(175, 30);
            this.btSava.TabIndex = 19;
            this.btSava.Text = "Salva";
            this.btSava.UseVisualStyleBackColor = true;
            this.btSava.Click += new System.EventHandler(this.btSava_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btAnnulla.Location = new System.Drawing.Point(236, 254);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(169, 30);
            this.btAnnulla.TabIndex = 18;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbLivello
            // 
            this.tbLivello.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbLivello.Location = new System.Drawing.Point(141, 64);
            this.tbLivello.Margin = new System.Windows.Forms.Padding(2);
            this.tbLivello.Name = "tbLivello";
            this.tbLivello.Size = new System.Drawing.Size(264, 20);
            this.tbLivello.TabIndex = 15;
            // 
            // tbNome
            // 
            this.tbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbNome.Location = new System.Drawing.Point(141, 105);
            this.tbNome.Margin = new System.Windows.Forms.Padding(2);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(264, 20);
            this.tbNome.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(36, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Abilitazioni richeste:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(36, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Livello:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(36, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome:";
            // 
            // rtbAbilitazioni
            // 
            this.rtbAbilitazioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rtbAbilitazioni.Location = new System.Drawing.Point(143, 147);
            this.rtbAbilitazioni.Margin = new System.Windows.Forms.Padding(2);
            this.rtbAbilitazioni.Name = "rtbAbilitazioni";
            this.rtbAbilitazioni.Size = new System.Drawing.Size(262, 71);
            this.rtbAbilitazioni.TabIndex = 20;
            this.rtbAbilitazioni.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 26);
            this.label4.TabIndex = 21;
            this.label4.Text = "Inserisci CDC";
            // 
            // FrmCdC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 311);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.Label label4;
    }
}