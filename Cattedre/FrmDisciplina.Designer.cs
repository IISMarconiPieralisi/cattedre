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
            this.ckbAnno1 = new System.Windows.Forms.CheckBox();
            this.ckbAnno2 = new System.Windows.Forms.CheckBox();
            this.ckbAnno3 = new System.Windows.Forms.CheckBox();
            this.ckbAnno4 = new System.Windows.Forms.CheckBox();
            this.ckbAnno5 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDipartimentoAppartenente = new System.Windows.Forms.ComboBox();
            this.tbDisciplinaSpeciale = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudOreTeoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOreLab)).BeginInit();
            this.SuspendLayout();
            // 
            // btSalva
            // 
            this.btSalva.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSalva.Location = new System.Drawing.Point(194, 264);
            this.btSalva.Margin = new System.Windows.Forms.Padding(2);
            this.btSalva.Name = "btSalva";
            this.btSalva.Size = new System.Drawing.Size(56, 19);
            this.btSalva.TabIndex = 19;
            this.btSalva.Text = "Salva";
            this.btSalva.UseVisualStyleBackColor = true;
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Location = new System.Drawing.Point(85, 264);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(56, 19);
            this.btAnnulla.TabIndex = 18;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(160, 27);
            this.tbNome.Margin = new System.Windows.Forms.Padding(2);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(126, 20);
            this.tbNome.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Anno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ore laboratorio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ore teoria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 176);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Disciplina speciale:";
            // 
            // nudOreTeoria
            // 
            this.nudOreTeoria.Location = new System.Drawing.Point(160, 60);
            this.nudOreTeoria.Name = "nudOreTeoria";
            this.nudOreTeoria.Size = new System.Drawing.Size(50, 20);
            this.nudOreTeoria.TabIndex = 22;
            // 
            // nudOreLab
            // 
            this.nudOreLab.Location = new System.Drawing.Point(160, 97);
            this.nudOreLab.Name = "nudOreLab";
            this.nudOreLab.Size = new System.Drawing.Size(50, 20);
            this.nudOreLab.TabIndex = 23;
            // 
            // ckbAnno1
            // 
            this.ckbAnno1.AutoSize = true;
            this.ckbAnno1.Location = new System.Drawing.Point(100, 133);
            this.ckbAnno1.Name = "ckbAnno1";
            this.ckbAnno1.Size = new System.Drawing.Size(32, 17);
            this.ckbAnno1.TabIndex = 24;
            this.ckbAnno1.Text = "1";
            this.ckbAnno1.UseVisualStyleBackColor = true;
            // 
            // ckbAnno2
            // 
            this.ckbAnno2.AutoSize = true;
            this.ckbAnno2.Location = new System.Drawing.Point(138, 133);
            this.ckbAnno2.Name = "ckbAnno2";
            this.ckbAnno2.Size = new System.Drawing.Size(32, 17);
            this.ckbAnno2.TabIndex = 25;
            this.ckbAnno2.Text = "2";
            this.ckbAnno2.UseVisualStyleBackColor = true;
            // 
            // ckbAnno3
            // 
            this.ckbAnno3.AutoSize = true;
            this.ckbAnno3.Location = new System.Drawing.Point(176, 133);
            this.ckbAnno3.Name = "ckbAnno3";
            this.ckbAnno3.Size = new System.Drawing.Size(32, 17);
            this.ckbAnno3.TabIndex = 26;
            this.ckbAnno3.Text = "3";
            this.ckbAnno3.UseVisualStyleBackColor = true;
            // 
            // ckbAnno4
            // 
            this.ckbAnno4.AutoSize = true;
            this.ckbAnno4.Location = new System.Drawing.Point(214, 133);
            this.ckbAnno4.Name = "ckbAnno4";
            this.ckbAnno4.Size = new System.Drawing.Size(32, 17);
            this.ckbAnno4.TabIndex = 27;
            this.ckbAnno4.Text = "4";
            this.ckbAnno4.UseVisualStyleBackColor = true;
            // 
            // ckbAnno5
            // 
            this.ckbAnno5.AutoSize = true;
            this.ckbAnno5.Location = new System.Drawing.Point(252, 133);
            this.ckbAnno5.Name = "ckbAnno5";
            this.ckbAnno5.Size = new System.Drawing.Size(32, 17);
            this.ckbAnno5.TabIndex = 28;
            this.ckbAnno5.Text = "5";
            this.ckbAnno5.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Dipartimento appartenente:";
            // 
            // cbDipartimentoAppartenente
            // 
            this.cbDipartimentoAppartenente.FormattingEnabled = true;
            this.cbDipartimentoAppartenente.Location = new System.Drawing.Point(201, 212);
            this.cbDipartimentoAppartenente.Name = "cbDipartimentoAppartenente";
            this.cbDipartimentoAppartenente.Size = new System.Drawing.Size(121, 21);
            this.cbDipartimentoAppartenente.TabIndex = 31;
            // 
            // tbDisciplinaSpeciale
            // 
            this.tbDisciplinaSpeciale.Location = new System.Drawing.Point(161, 173);
            this.tbDisciplinaSpeciale.Margin = new System.Windows.Forms.Padding(2);
            this.tbDisciplinaSpeciale.Name = "tbDisciplinaSpeciale";
            this.tbDisciplinaSpeciale.Size = new System.Drawing.Size(126, 20);
            this.tbDisciplinaSpeciale.TabIndex = 32;
            // 
            // FrmDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 306);
            this.Controls.Add(this.tbDisciplinaSpeciale);
            this.Controls.Add(this.cbDipartimentoAppartenente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ckbAnno5);
            this.Controls.Add(this.ckbAnno4);
            this.Controls.Add(this.ckbAnno3);
            this.Controls.Add(this.ckbAnno2);
            this.Controls.Add(this.ckbAnno1);
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
        private System.Windows.Forms.CheckBox ckbAnno1;
        private System.Windows.Forms.CheckBox ckbAnno2;
        private System.Windows.Forms.CheckBox ckbAnno3;
        private System.Windows.Forms.CheckBox ckbAnno4;
        private System.Windows.Forms.CheckBox ckbAnno5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDipartimentoAppartenente;
        private System.Windows.Forms.TextBox tbDisciplinaSpeciale;
    }
}