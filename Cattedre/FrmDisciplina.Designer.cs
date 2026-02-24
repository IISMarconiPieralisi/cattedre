namespace Cattedre
{
    partial class FrmDisciplina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisciplina));
            this.btSalva = new System.Windows.Forms.Button();
            this.btAnnulla = new System.Windows.Forms.Button();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudOreTeoria = new System.Windows.Forms.NumericUpDown();
            this.nudOreLab = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDipartimentoAppartenente = new System.Windows.Forms.ComboBox();
            this.tbDisciplinaSpeciale = new System.Windows.Forms.TextBox();
            this.pnRB = new System.Windows.Forms.Panel();
            this.rbQuinto = new System.Windows.Forms.RadioButton();
            this.rbQuarto = new System.Windows.Forms.RadioButton();
            this.rbTerzo = new System.Windows.Forms.RadioButton();
            this.rbSecondo = new System.Windows.Forms.RadioButton();
            this.rbPrimo = new System.Windows.Forms.RadioButton();
            this.clbIndirizzi = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudOreTeoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOreLab)).BeginInit();
            this.pnRB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSalva
            // 
            this.btSalva.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSalva.Location = new System.Drawing.Point(202, 384);
            this.btSalva.Margin = new System.Windows.Forms.Padding(2);
            this.btSalva.Name = "btSalva";
            this.btSalva.Size = new System.Drawing.Size(146, 31);
            this.btSalva.TabIndex = 19;
            this.btSalva.Text = "Salva";
            this.btSalva.UseVisualStyleBackColor = true;
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Location = new System.Drawing.Point(20, 384);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(146, 31);
            this.btAnnulla.TabIndex = 18;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbNome
            // 
            this.tbNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNome.Location = new System.Drawing.Point(186, 27);
            this.tbNome.Margin = new System.Windows.Forms.Padding(2);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(162, 20);
            this.tbNome.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Anno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ore laboratorio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ore teoria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 331);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Disciplina speciale:";
            // 
            // nudOreTeoria
            // 
            this.nudOreTeoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudOreTeoria.Location = new System.Drawing.Point(186, 60);
            this.nudOreTeoria.Name = "nudOreTeoria";
            this.nudOreTeoria.Size = new System.Drawing.Size(162, 20);
            this.nudOreTeoria.TabIndex = 22;
            // 
            // nudOreLab
            // 
            this.nudOreLab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudOreLab.Location = new System.Drawing.Point(186, 97);
            this.nudOreLab.Name = "nudOreLab";
            this.nudOreLab.Size = new System.Drawing.Size(162, 20);
            this.nudOreLab.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Dipartimento appartenente:";
            // 
            // cbDipartimentoAppartenente
            // 
            this.cbDipartimentoAppartenente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDipartimentoAppartenente.FormattingEnabled = true;
            this.cbDipartimentoAppartenente.Location = new System.Drawing.Point(179, 177);
            this.cbDipartimentoAppartenente.Name = "cbDipartimentoAppartenente";
            this.cbDipartimentoAppartenente.Size = new System.Drawing.Size(169, 21);
            this.cbDipartimentoAppartenente.TabIndex = 31;
            // 
            // tbDisciplinaSpeciale
            // 
            this.tbDisciplinaSpeciale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisciplinaSpeciale.Location = new System.Drawing.Point(179, 328);
            this.tbDisciplinaSpeciale.Margin = new System.Windows.Forms.Padding(2);
            this.tbDisciplinaSpeciale.Name = "tbDisciplinaSpeciale";
            this.tbDisciplinaSpeciale.Size = new System.Drawing.Size(169, 20);
            this.tbDisciplinaSpeciale.TabIndex = 32;
            // 
            // pnRB
            // 
            this.pnRB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnRB.Controls.Add(this.rbQuinto);
            this.pnRB.Controls.Add(this.rbQuarto);
            this.pnRB.Controls.Add(this.rbTerzo);
            this.pnRB.Controls.Add(this.rbSecondo);
            this.pnRB.Controls.Add(this.rbPrimo);
            this.pnRB.Location = new System.Drawing.Point(82, 128);
            this.pnRB.Name = "pnRB";
            this.pnRB.Size = new System.Drawing.Size(266, 34);
            this.pnRB.TabIndex = 33;
            // 
            // rbQuinto
            // 
            this.rbQuinto.AutoSize = true;
            this.rbQuinto.Location = new System.Drawing.Point(220, 10);
            this.rbQuinto.Name = "rbQuinto";
            this.rbQuinto.Size = new System.Drawing.Size(35, 17);
            this.rbQuinto.TabIndex = 4;
            this.rbQuinto.TabStop = true;
            this.rbQuinto.Text = "5°";
            this.rbQuinto.UseVisualStyleBackColor = true;
            // 
            // rbQuarto
            // 
            this.rbQuarto.AutoSize = true;
            this.rbQuarto.Location = new System.Drawing.Point(167, 10);
            this.rbQuarto.Name = "rbQuarto";
            this.rbQuarto.Size = new System.Drawing.Size(35, 17);
            this.rbQuarto.TabIndex = 3;
            this.rbQuarto.TabStop = true;
            this.rbQuarto.Text = "4°";
            this.rbQuarto.UseVisualStyleBackColor = true;
            // 
            // rbTerzo
            // 
            this.rbTerzo.AutoSize = true;
            this.rbTerzo.Location = new System.Drawing.Point(114, 10);
            this.rbTerzo.Name = "rbTerzo";
            this.rbTerzo.Size = new System.Drawing.Size(35, 17);
            this.rbTerzo.TabIndex = 2;
            this.rbTerzo.TabStop = true;
            this.rbTerzo.Text = "3°";
            this.rbTerzo.UseVisualStyleBackColor = true;
            // 
            // rbSecondo
            // 
            this.rbSecondo.AutoSize = true;
            this.rbSecondo.Location = new System.Drawing.Point(61, 10);
            this.rbSecondo.Name = "rbSecondo";
            this.rbSecondo.Size = new System.Drawing.Size(35, 17);
            this.rbSecondo.TabIndex = 1;
            this.rbSecondo.TabStop = true;
            this.rbSecondo.Text = "2°";
            this.rbSecondo.UseVisualStyleBackColor = true;
            // 
            // rbPrimo
            // 
            this.rbPrimo.AutoSize = true;
            this.rbPrimo.Location = new System.Drawing.Point(8, 10);
            this.rbPrimo.Name = "rbPrimo";
            this.rbPrimo.Size = new System.Drawing.Size(35, 17);
            this.rbPrimo.TabIndex = 0;
            this.rbPrimo.TabStop = true;
            this.rbPrimo.Text = "1°";
            this.rbPrimo.UseVisualStyleBackColor = true;
            // 
            // clbIndirizzi
            // 
            this.clbIndirizzi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbIndirizzi.FormattingEnabled = true;
            this.clbIndirizzi.Location = new System.Drawing.Point(179, 217);
            this.clbIndirizzi.Name = "clbIndirizzi";
            this.clbIndirizzi.Size = new System.Drawing.Size(169, 94);
            this.clbIndirizzi.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Indirizzo:";
            // 
            // FrmDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 436);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.clbIndirizzi);
            this.Controls.Add(this.pnRB);
            this.Controls.Add(this.tbDisciplinaSpeciale);
            this.Controls.Add(this.cbDipartimentoAppartenente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudOreLab);
            this.Controls.Add(this.nudOreTeoria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btSalva);
            this.Controls.Add(this.btAnnulla);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDisciplina";
            this.Text = "Disciplina";
            this.Load += new System.EventHandler(this.FrmDisciplina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudOreTeoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOreLab)).EndInit();
            this.pnRB.ResumeLayout(false);
            this.pnRB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSalva;
        private System.Windows.Forms.Button btAnnulla;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudOreTeoria;
        private System.Windows.Forms.NumericUpDown nudOreLab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDipartimentoAppartenente;
        private System.Windows.Forms.TextBox tbDisciplinaSpeciale;
        private System.Windows.Forms.Panel pnRB;
        private System.Windows.Forms.RadioButton rbQuinto;
        private System.Windows.Forms.RadioButton rbQuarto;
        private System.Windows.Forms.RadioButton rbTerzo;
        private System.Windows.Forms.RadioButton rbSecondo;
        private System.Windows.Forms.RadioButton rbPrimo;
        private System.Windows.Forms.CheckedListBox clbIndirizzi;
        private System.Windows.Forms.Label label7;
    }
}