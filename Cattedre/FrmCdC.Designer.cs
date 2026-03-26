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
            this.label6 = new System.Windows.Forms.Label();
            this.cbAnnoScolastico = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreDiritto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreFatto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSava
            // 
            this.btSava.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btSava.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSava.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btSava.Location = new System.Drawing.Point(180, 2);
            this.btSava.Margin = new System.Windows.Forms.Padding(2);
            this.btSava.Name = "btSava";
            this.btSava.Size = new System.Drawing.Size(178, 37);
            this.btSava.TabIndex = 7;
            this.btSava.Text = "Salva";
            this.btSava.UseVisualStyleBackColor = true;
            this.btSava.Click += new System.EventHandler(this.btSava_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btAnnulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btAnnulla.Location = new System.Drawing.Point(0, 2);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(180, 37);
            this.btAnnulla.TabIndex = 8;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbLivello
            // 
            this.tbLivello.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLivello.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbLivello.Location = new System.Drawing.Point(138, 59);
            this.tbLivello.Margin = new System.Windows.Forms.Padding(2);
            this.tbLivello.Name = "tbLivello";
            this.tbLivello.Size = new System.Drawing.Size(232, 20);
            this.tbLivello.TabIndex = 2;
            this.tbLivello.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLivello_KeyDown);
            // 
            // tbNome
            // 
            this.tbNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbNome.Location = new System.Drawing.Point(138, 100);
            this.tbNome.Margin = new System.Windows.Forms.Padding(2);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(232, 20);
            this.tbNome.TabIndex = 3;
            this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
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
            this.rtbAbilitazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAbilitazioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rtbAbilitazioni.Location = new System.Drawing.Point(140, 142);
            this.rtbAbilitazioni.Margin = new System.Windows.Forms.Padding(2);
            this.rtbAbilitazioni.Name = "rtbAbilitazioni";
            this.rtbAbilitazioni.Size = new System.Drawing.Size(230, 84);
            this.rtbAbilitazioni.TabIndex = 4;
            this.rtbAbilitazioni.Text = "";
            this.rtbAbilitazioni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbAbilitazioni_KeyDown);
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
            this.nudNumCattedreDiritto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudNumCattedreDiritto.Location = new System.Drawing.Point(138, 251);
            this.nudNumCattedreDiritto.Name = "nudNumCattedreDiritto";
            this.nudNumCattedreDiritto.Size = new System.Drawing.Size(43, 20);
            this.nudNumCattedreDiritto.TabIndex = 5;
            this.nudNumCattedreDiritto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudNumCattedreDiritto_KeyDown);
            // 
            // nudNumCattedreFatto
            // 
            this.nudNumCattedreFatto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudNumCattedreFatto.Location = new System.Drawing.Point(138, 294);
            this.nudNumCattedreFatto.Name = "nudNumCattedreFatto";
            this.nudNumCattedreFatto.Size = new System.Drawing.Size(43, 20);
            this.nudNumCattedreFatto.TabIndex = 6;
            this.nudNumCattedreFatto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudNumCattedreFatto_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "A.S.:";
            // 
            // cbAnnoScolastico
            // 
            this.cbAnnoScolastico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAnnoScolastico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnnoScolastico.FormattingEnabled = true;
            this.cbAnnoScolastico.Location = new System.Drawing.Point(138, 19);
            this.cbAnnoScolastico.Name = "cbAnnoScolastico";
            this.cbAnnoScolastico.Size = new System.Drawing.Size(232, 21);
            this.cbAnnoScolastico.TabIndex = 1;
            this.cbAnnoScolastico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAnnoScolastico_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btAnnulla);
            this.panel1.Controls.Add(this.btSava);
            this.panel1.Location = new System.Drawing.Point(12, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 40);
            this.panel1.TabIndex = 27;
            // 
            // FrmCdC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 389);
            this.Controls.Add(this.cbAnnoScolastico);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudNumCattedreFatto);
            this.Controls.Add(this.nudNumCattedreDiritto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbAbilitazioni);
            this.Controls.Add(this.tbLivello);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmCdC";
            this.Text = "Classe di concorso";
            this.Load += new System.EventHandler(this.FrmCdC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreDiritto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreFatto)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAnnoScolastico;
        private System.Windows.Forms.Panel panel1;
    }
}