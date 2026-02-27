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
            this.label5 = new System.Windows.Forms.Label();
            this.nudNumCattedreDiritto = new System.Windows.Forms.NumericUpDown();
            this.nudNumCattedreFatto = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreDiritto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreFatto)).BeginInit();
            this.SuspendLayout();
            // 
            // btSava
            // 
            this.btSava.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSava.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btSava.Location = new System.Drawing.Point(196, 342);
            this.btSava.Margin = new System.Windows.Forms.Padding(2);
            this.btSava.Name = "btSava";
            this.btSava.Size = new System.Drawing.Size(174, 37);
            this.btSava.TabIndex = 19;
            this.btSava.Text = "Salva";
            this.btSava.UseVisualStyleBackColor = true;
            this.btSava.Click += new System.EventHandler(this.btSava_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btAnnulla.Location = new System.Drawing.Point(14, 342);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(178, 37);
            this.btAnnulla.TabIndex = 18;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbLivello
            // 
            this.tbLivello.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbLivello.Location = new System.Drawing.Point(138, 59);
            this.tbLivello.Margin = new System.Windows.Forms.Padding(2);
            this.tbLivello.Name = "tbLivello";
            this.tbLivello.Size = new System.Drawing.Size(232, 20);
            this.tbLivello.TabIndex = 15;
            // 
            // tbNome
            // 
            this.tbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbNome.Location = new System.Drawing.Point(138, 100);
            this.tbNome.Margin = new System.Windows.Forms.Padding(2);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(232, 20);
            this.tbNome.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(11, 145);
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
            this.label2.Location = new System.Drawing.Point(11, 62);
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
            this.label1.Location = new System.Drawing.Point(11, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome:";
            // 
            // rtbAbilitazioni
            // 
            this.rtbAbilitazioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rtbAbilitazioni.Location = new System.Drawing.Point(140, 142);
            this.rtbAbilitazioni.Margin = new System.Windows.Forms.Padding(2);
            this.rtbAbilitazioni.Name = "rtbAbilitazioni";
            this.rtbAbilitazioni.Size = new System.Drawing.Size(230, 84);
            this.rtbAbilitazioni.TabIndex = 20;
            this.rtbAbilitazioni.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Num cattedre di diritto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Num cattedre di fatto:";
            // 
            // nudNumCattedreDiritto
            // 
            this.nudNumCattedreDiritto.Location = new System.Drawing.Point(138, 251);
            this.nudNumCattedreDiritto.Name = "nudNumCattedreDiritto";
            this.nudNumCattedreDiritto.Size = new System.Drawing.Size(43, 20);
            this.nudNumCattedreDiritto.TabIndex = 23;
            // 
            // nudNumCattedreFatto
            // 
            this.nudNumCattedreFatto.Location = new System.Drawing.Point(138, 294);
            this.nudNumCattedreFatto.Name = "nudNumCattedreFatto";
            this.nudNumCattedreFatto.Size = new System.Drawing.Size(43, 20);
            this.nudNumCattedreFatto.TabIndex = 24;
            // 
            // FrmCdC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 419);
            this.Controls.Add(this.nudNumCattedreFatto);
            this.Controls.Add(this.nudNumCattedreDiritto);
            this.Controls.Add(this.label5);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreDiritto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreFatto)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudNumCattedreDiritto;
        private System.Windows.Forms.NumericUpDown nudNumCattedreFatto;
    }
}