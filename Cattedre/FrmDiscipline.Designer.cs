namespace Cattedre
{
    partial class FrmDiscipline
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
            this.cbDipartimenti = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCerca = new System.Windows.Forms.Button();
            this.btElimina = new System.Windows.Forms.Button();
            this.btModifica = new System.Windows.Forms.Button();
            this.btInserisci = new System.Windows.Forms.Button();
            this.lvDiscipline = new System.Windows.Forms.ListView();
            this.chAnno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOreLab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOreTeoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDisciplinaSpeciale = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDipartimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.btPulisciCb = new System.Windows.Forms.Button();
            this.gbAnni = new System.Windows.Forms.GroupBox();
            this.rbAnno5 = new System.Windows.Forms.RadioButton();
            this.rbAnno4 = new System.Windows.Forms.RadioButton();
            this.rbAnno3 = new System.Windows.Forms.RadioButton();
            this.rbAnno2 = new System.Windows.Forms.RadioButton();
            this.rbAnno1 = new System.Windows.Forms.RadioButton();
            this.tbDisciplina = new System.Windows.Forms.TextBox();
            this.gbAnni.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDipartimenti
            // 
            this.cbDipartimenti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDipartimenti.FormattingEnabled = true;
            this.cbDipartimenti.Location = new System.Drawing.Point(87, 31);
            this.cbDipartimenti.Name = "cbDipartimenti";
            this.cbDipartimenti.Size = new System.Drawing.Size(226, 21);
            this.cbDipartimenti.TabIndex = 27;
            this.cbDipartimenti.SelectedIndexChanged += new System.EventHandler(this.cbDipartimenti_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Dipartimento:";
            // 
            // btCerca
            // 
            this.btCerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerca.Location = new System.Drawing.Point(761, 32);
            this.btCerca.Name = "btCerca";
            this.btCerca.Size = new System.Drawing.Size(75, 23);
            this.btCerca.TabIndex = 25;
            this.btCerca.Text = "Cerca";
            this.btCerca.UseVisualStyleBackColor = true;
            this.btCerca.Click += new System.EventHandler(this.btCerca_Click);
            // 
            // btElimina
            // 
            this.btElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btElimina.Location = new System.Drawing.Point(761, 130);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(75, 23);
            this.btElimina.TabIndex = 24;
            this.btElimina.Text = "Elimina";
            this.btElimina.UseVisualStyleBackColor = true;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // btModifica
            // 
            this.btModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModifica.Location = new System.Drawing.Point(761, 101);
            this.btModifica.Name = "btModifica";
            this.btModifica.Size = new System.Drawing.Size(75, 23);
            this.btModifica.TabIndex = 23;
            this.btModifica.Text = "Modifica";
            this.btModifica.UseVisualStyleBackColor = true;
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInserisci.Location = new System.Drawing.Point(761, 72);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.Size = new System.Drawing.Size(75, 23);
            this.btInserisci.TabIndex = 22;
            this.btInserisci.Text = "Inserisci";
            this.btInserisci.UseVisualStyleBackColor = true;
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // lvDiscipline
            // 
            this.lvDiscipline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDiscipline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAnno,
            this.chNome,
            this.chOreLab,
            this.chOreTeoria,
            this.chDisciplinaSpeciale,
            this.chDipartimento});
            this.lvDiscipline.FullRowSelect = true;
            this.lvDiscipline.HideSelection = false;
            this.lvDiscipline.Location = new System.Drawing.Point(12, 72);
            this.lvDiscipline.Name = "lvDiscipline";
            this.lvDiscipline.Size = new System.Drawing.Size(743, 314);
            this.lvDiscipline.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDiscipline.TabIndex = 28;
            this.lvDiscipline.UseCompatibleStateImageBehavior = false;
            this.lvDiscipline.View = System.Windows.Forms.View.Details;
            // 
            // chAnno
            // 
            this.chAnno.Text = "Anno";
            this.chAnno.Width = 76;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 127;
            // 
            // chOreLab
            // 
            this.chOreLab.DisplayIndex = 3;
            this.chOreLab.Text = "Ore Lab";
            this.chOreLab.Width = 77;
            // 
            // chOreTeoria
            // 
            this.chOreTeoria.DisplayIndex = 2;
            this.chOreTeoria.Text = "Ore Teoria";
            this.chOreTeoria.Width = 83;
            // 
            // chDisciplinaSpeciale
            // 
            this.chDisciplinaSpeciale.Text = "Speciale";
            // 
            // chDipartimento
            // 
            this.chDipartimento.Text = "Dipartimento";
            this.chDipartimento.Width = 159;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Disciplina:";
            // 
            // btPulisciCb
            // 
            this.btPulisciCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPulisciCb.ForeColor = System.Drawing.Color.DarkRed;
            this.btPulisciCb.Location = new System.Drawing.Point(729, 32);
            this.btPulisciCb.Name = "btPulisciCb";
            this.btPulisciCb.Size = new System.Drawing.Size(26, 23);
            this.btPulisciCb.TabIndex = 31;
            this.btPulisciCb.Text = "X";
            this.btPulisciCb.UseVisualStyleBackColor = true;
            this.btPulisciCb.Click += new System.EventHandler(this.btPulisciCb_Click);
            // 
            // gbAnni
            // 
            this.gbAnni.Controls.Add(this.rbAnno5);
            this.gbAnni.Controls.Add(this.rbAnno4);
            this.gbAnni.Controls.Add(this.rbAnno3);
            this.gbAnni.Controls.Add(this.rbAnno2);
            this.gbAnni.Controls.Add(this.rbAnno1);
            this.gbAnni.Location = new System.Drawing.Point(523, 19);
            this.gbAnni.Name = "gbAnni";
            this.gbAnni.Size = new System.Drawing.Size(200, 43);
            this.gbAnni.TabIndex = 32;
            this.gbAnni.TabStop = false;
            this.gbAnni.Text = "Anno";
            // 
            // rbAnno5
            // 
            this.rbAnno5.AutoSize = true;
            this.rbAnno5.Location = new System.Drawing.Point(155, 17);
            this.rbAnno5.Name = "rbAnno5";
            this.rbAnno5.Size = new System.Drawing.Size(31, 17);
            this.rbAnno5.TabIndex = 4;
            this.rbAnno5.TabStop = true;
            this.rbAnno5.Text = "5";
            this.rbAnno5.UseVisualStyleBackColor = true;
            // 
            // rbAnno4
            // 
            this.rbAnno4.AutoSize = true;
            this.rbAnno4.Location = new System.Drawing.Point(118, 17);
            this.rbAnno4.Name = "rbAnno4";
            this.rbAnno4.Size = new System.Drawing.Size(31, 17);
            this.rbAnno4.TabIndex = 3;
            this.rbAnno4.TabStop = true;
            this.rbAnno4.Text = "4";
            this.rbAnno4.UseVisualStyleBackColor = true;
            // 
            // rbAnno3
            // 
            this.rbAnno3.AutoSize = true;
            this.rbAnno3.Location = new System.Drawing.Point(81, 17);
            this.rbAnno3.Name = "rbAnno3";
            this.rbAnno3.Size = new System.Drawing.Size(31, 17);
            this.rbAnno3.TabIndex = 2;
            this.rbAnno3.TabStop = true;
            this.rbAnno3.Text = "3";
            this.rbAnno3.UseVisualStyleBackColor = true;
            // 
            // rbAnno2
            // 
            this.rbAnno2.AutoSize = true;
            this.rbAnno2.Location = new System.Drawing.Point(44, 17);
            this.rbAnno2.Name = "rbAnno2";
            this.rbAnno2.Size = new System.Drawing.Size(31, 17);
            this.rbAnno2.TabIndex = 1;
            this.rbAnno2.TabStop = true;
            this.rbAnno2.Text = "2";
            this.rbAnno2.UseVisualStyleBackColor = true;
            // 
            // rbAnno1
            // 
            this.rbAnno1.AutoSize = true;
            this.rbAnno1.Location = new System.Drawing.Point(7, 17);
            this.rbAnno1.Name = "rbAnno1";
            this.rbAnno1.Size = new System.Drawing.Size(31, 17);
            this.rbAnno1.TabIndex = 0;
            this.rbAnno1.TabStop = true;
            this.rbAnno1.Text = "1";
            this.rbAnno1.UseVisualStyleBackColor = true;
            // 
            // tbDisciplina
            // 
            this.tbDisciplina.Location = new System.Drawing.Point(391, 32);
            this.tbDisciplina.Name = "tbDisciplina";
            this.tbDisciplina.Size = new System.Drawing.Size(124, 20);
            this.tbDisciplina.TabIndex = 30;
            // 
            // FrmDiscipline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 414);
            this.Controls.Add(this.gbAnni);
            this.Controls.Add(this.btPulisciCb);
            this.Controls.Add(this.tbDisciplina);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvDiscipline);
            this.Controls.Add(this.cbDipartimenti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCerca);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btInserisci);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDiscipline";
            this.Text = "Discipline";
            this.Load += new System.EventHandler(this.FrmDiscipline_Load);
            this.gbAnni.ResumeLayout(false);
            this.gbAnni.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDipartimenti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCerca;
        private System.Windows.Forms.Button btElimina;
        private System.Windows.Forms.Button btModifica;
        private System.Windows.Forms.Button btInserisci;
        private System.Windows.Forms.ListView lvDiscipline;
        private System.Windows.Forms.ColumnHeader chAnno;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chOreLab;
        private System.Windows.Forms.ColumnHeader chOreTeoria;
        private System.Windows.Forms.ColumnHeader chDisciplinaSpeciale;
        private System.Windows.Forms.ColumnHeader chDipartimento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btPulisciCb;
        private System.Windows.Forms.GroupBox gbAnni;
        private System.Windows.Forms.RadioButton rbAnno5;
        private System.Windows.Forms.RadioButton rbAnno4;
        private System.Windows.Forms.RadioButton rbAnno3;
        private System.Windows.Forms.RadioButton rbAnno2;
        private System.Windows.Forms.RadioButton rbAnno1;
        private System.Windows.Forms.TextBox tbDisciplina;
    }
}