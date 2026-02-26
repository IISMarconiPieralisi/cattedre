namespace Cattedre
{
    partial class FrmUtente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtente));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.tbCognome = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbTipoUtente = new System.Windows.Forms.ComboBox();
            this.btAnnulla = new System.Windows.Forms.Button();
            this.btSalva = new System.Windows.Forms.Button();
            this.ckbDocenteTeorico = new System.Windows.Forms.CheckBox();
            this.ckbDocentePratico = new System.Windows.Forms.CheckBox();
            this.PnUtente = new System.Windows.Forms.Panel();
            this.pnColore = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btColore = new System.Windows.Forms.Button();
            this.cbAutoEmail = new System.Windows.Forms.CheckBox();
            this.pnCDC = new System.Windows.Forms.Panel();
            this.clbCLasseDiConcorso = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnDipartimento = new System.Windows.Forms.Panel();
            this.clbDipartimento = new System.Windows.Forms.CheckedListBox();
            this.cbDipartimentoCoordinato = new System.Windows.Forms.ComboBox();
            this.lbDcoordinato = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PnContratto = new System.Windows.Forms.Panel();
            this.dtpDataFine = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInizio = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudMonteOre = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.rbIndeterminato = new System.Windows.Forms.RadioButton();
            this.rbDeterminato = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.cldColori = new System.Windows.Forms.ColorDialog();
            this.PnUtente.SuspendLayout();
            this.pnCDC.SuspendLayout();
            this.pnDipartimento.SuspendLayout();
            this.PnContratto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonteOre)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cognome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo Utente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo Docente:";
            // 
            // tbNome
            // 
            this.tbNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNome.Location = new System.Drawing.Point(109, 40);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(219, 20);
            this.tbNome.TabIndex = 6;
            // 
            // tbCognome
            // 
            this.tbCognome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCognome.Location = new System.Drawing.Point(108, 88);
            this.tbCognome.Name = "tbCognome";
            this.tbCognome.Size = new System.Drawing.Size(219, 20);
            this.tbCognome.TabIndex = 7;
            // 
            // tbEmail
            // 
            this.tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmail.Location = new System.Drawing.Point(109, 136);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(219, 20);
            this.tbEmail.TabIndex = 8;
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Location = new System.Drawing.Point(109, 184);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbPassword.Size = new System.Drawing.Size(219, 20);
            this.tbPassword.TabIndex = 9;
            this.tbPassword.UseWaitCursor = true;
            // 
            // cbTipoUtente
            // 
            this.cbTipoUtente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoUtente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoUtente.FormattingEnabled = true;
            this.cbTipoUtente.Items.AddRange(new object[] {
            "Preside",
            "Amministratore",
            "Docente",
            "Coordinatore di dipartimento"});
            this.cbTipoUtente.Location = new System.Drawing.Point(109, 232);
            this.cbTipoUtente.Name = "cbTipoUtente";
            this.cbTipoUtente.Size = new System.Drawing.Size(219, 21);
            this.cbTipoUtente.TabIndex = 10;
            this.cbTipoUtente.SelectedIndexChanged += new System.EventHandler(this.cbTipoUtente_SelectedIndexChanged);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAnnulla.Location = new System.Drawing.Point(21, 420);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(307, 33);
            this.btAnnulla.TabIndex = 13;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // btSalva
            // 
            this.btSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSalva.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSalva.Location = new System.Drawing.Point(21, 380);
            this.btSalva.Name = "btSalva";
            this.btSalva.Size = new System.Drawing.Size(307, 34);
            this.btSalva.TabIndex = 14;
            this.btSalva.Text = "Salva";
            this.btSalva.UseVisualStyleBackColor = true;
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // ckbDocenteTeorico
            // 
            this.ckbDocenteTeorico.AutoSize = true;
            this.ckbDocenteTeorico.Location = new System.Drawing.Point(109, 296);
            this.ckbDocenteTeorico.Name = "ckbDocenteTeorico";
            this.ckbDocenteTeorico.Size = new System.Drawing.Size(58, 17);
            this.ckbDocenteTeorico.TabIndex = 15;
            this.ckbDocenteTeorico.Text = "teorico";
            this.ckbDocenteTeorico.UseVisualStyleBackColor = true;
            // 
            // ckbDocentePratico
            // 
            this.ckbDocentePratico.AutoSize = true;
            this.ckbDocentePratico.Location = new System.Drawing.Point(269, 295);
            this.ckbDocentePratico.Name = "ckbDocentePratico";
            this.ckbDocentePratico.Size = new System.Drawing.Size(58, 17);
            this.ckbDocentePratico.TabIndex = 16;
            this.ckbDocentePratico.Text = "pratico";
            this.ckbDocentePratico.UseVisualStyleBackColor = true;
            // 
            // PnUtente
            // 
            this.PnUtente.AutoSize = true;
            this.PnUtente.Controls.Add(this.pnColore);
            this.PnUtente.Controls.Add(this.label9);
            this.PnUtente.Controls.Add(this.cbAutoEmail);
            this.PnUtente.Controls.Add(this.btColore);
            this.PnUtente.Controls.Add(this.btSalva);
            this.PnUtente.Controls.Add(this.label1);
            this.PnUtente.Controls.Add(this.ckbDocentePratico);
            this.PnUtente.Controls.Add(this.label2);
            this.PnUtente.Controls.Add(this.ckbDocenteTeorico);
            this.PnUtente.Controls.Add(this.label3);
            this.PnUtente.Controls.Add(this.label4);
            this.PnUtente.Controls.Add(this.btAnnulla);
            this.PnUtente.Controls.Add(this.label5);
            this.PnUtente.Controls.Add(this.cbTipoUtente);
            this.PnUtente.Controls.Add(this.label6);
            this.PnUtente.Controls.Add(this.tbPassword);
            this.PnUtente.Controls.Add(this.tbNome);
            this.PnUtente.Controls.Add(this.tbEmail);
            this.PnUtente.Controls.Add(this.tbCognome);
            this.PnUtente.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnUtente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PnUtente.Location = new System.Drawing.Point(0, 0);
            this.PnUtente.Name = "PnUtente";
            this.PnUtente.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.PnUtente.Size = new System.Drawing.Size(346, 466);
            this.PnUtente.TabIndex = 18;
            // 
            // pnColore
            // 
            this.pnColore.Location = new System.Drawing.Point(192, 326);
            this.pnColore.Name = "pnColore";
            this.pnColore.Size = new System.Drawing.Size(24, 23);
            this.pnColore.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Seleziona colore:";
            // 
            // btColore
            // 
            this.btColore.Location = new System.Drawing.Point(112, 326);
            this.btColore.Name = "btColore";
            this.btColore.Size = new System.Drawing.Size(66, 23);
            this.btColore.TabIndex = 22;
            this.btColore.Text = "seleziona";
            this.btColore.UseVisualStyleBackColor = true;
            this.btColore.Click += new System.EventHandler(this.btColore_Click);
            // 
            // cbAutoEmail
            // 
            this.cbAutoEmail.AutoSize = true;
            this.cbAutoEmail.Location = new System.Drawing.Point(109, 259);
            this.cbAutoEmail.Name = "cbAutoEmail";
            this.cbAutoEmail.Size = new System.Drawing.Size(107, 17);
            this.cbAutoEmail.TabIndex = 18;
            this.cbAutoEmail.Text = "Email Automatica";
            this.cbAutoEmail.UseVisualStyleBackColor = true;
            this.cbAutoEmail.CheckedChanged += new System.EventHandler(this.cbAutoEmail_CheckedChanged);
            // 
            // pnCDC
            // 
            this.pnCDC.AutoSize = true;
            this.pnCDC.Controls.Add(this.clbCLasseDiConcorso);
            this.pnCDC.Controls.Add(this.label7);
            this.pnCDC.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnCDC.Location = new System.Drawing.Point(346, 0);
            this.pnCDC.Name = "pnCDC";
            this.pnCDC.Size = new System.Drawing.Size(163, 466);
            this.pnCDC.TabIndex = 19;
            this.pnCDC.Visible = false;
            // 
            // clbCLasseDiConcorso
            // 
            this.clbCLasseDiConcorso.FormattingEnabled = true;
            this.clbCLasseDiConcorso.Location = new System.Drawing.Point(3, 59);
            this.clbCLasseDiConcorso.Name = "clbCLasseDiConcorso";
            this.clbCLasseDiConcorso.Size = new System.Drawing.Size(157, 139);
            this.clbCLasseDiConcorso.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Classe di concorso:";
            // 
            // pnDipartimento
            // 
            this.pnDipartimento.AutoSize = true;
            this.pnDipartimento.Controls.Add(this.clbDipartimento);
            this.pnDipartimento.Controls.Add(this.cbDipartimentoCoordinato);
            this.pnDipartimento.Controls.Add(this.lbDcoordinato);
            this.pnDipartimento.Controls.Add(this.label8);
            this.pnDipartimento.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnDipartimento.Location = new System.Drawing.Point(509, 0);
            this.pnDipartimento.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.pnDipartimento.Name = "pnDipartimento";
            this.pnDipartimento.Size = new System.Drawing.Size(171, 466);
            this.pnDipartimento.TabIndex = 20;
            this.pnDipartimento.Visible = false;
            // 
            // clbDipartimento
            // 
            this.clbDipartimento.FormattingEnabled = true;
            this.clbDipartimento.Location = new System.Drawing.Point(6, 59);
            this.clbDipartimento.Name = "clbDipartimento";
            this.clbDipartimento.Size = new System.Drawing.Size(157, 139);
            this.clbDipartimento.TabIndex = 19;
            this.clbDipartimento.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbDipartimento_ItemCheck);
            // 
            // cbDipartimentoCoordinato
            // 
            this.cbDipartimentoCoordinato.FormattingEnabled = true;
            this.cbDipartimentoCoordinato.Location = new System.Drawing.Point(10, 248);
            this.cbDipartimentoCoordinato.Name = "cbDipartimentoCoordinato";
            this.cbDipartimentoCoordinato.Size = new System.Drawing.Size(158, 21);
            this.cbDipartimentoCoordinato.TabIndex = 19;
            this.cbDipartimentoCoordinato.Visible = false;
            this.cbDipartimentoCoordinato.DropDown += new System.EventHandler(this.cbDipartimentoCoordinato_DropDown);
            this.cbDipartimentoCoordinato.SelectedIndexChanged += new System.EventHandler(this.cbDipartimentoCoordinato_SelectedIndexChanged);
            // 
            // lbDcoordinato
            // 
            this.lbDcoordinato.AutoSize = true;
            this.lbDcoordinato.Location = new System.Drawing.Point(7, 232);
            this.lbDcoordinato.Name = "lbDcoordinato";
            this.lbDcoordinato.Size = new System.Drawing.Size(123, 13);
            this.lbDcoordinato.TabIndex = 20;
            this.lbDcoordinato.Text = "Dipartimento Coordinato:";
            this.lbDcoordinato.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Dipartimento:";
            // 
            // PnContratto
            // 
            this.PnContratto.Controls.Add(this.dtpDataFine);
            this.PnContratto.Controls.Add(this.dtpDataInizio);
            this.PnContratto.Controls.Add(this.label10);
            this.PnContratto.Controls.Add(this.label11);
            this.PnContratto.Controls.Add(this.nudMonteOre);
            this.PnContratto.Controls.Add(this.label12);
            this.PnContratto.Controls.Add(this.rbIndeterminato);
            this.PnContratto.Controls.Add(this.rbDeterminato);
            this.PnContratto.Controls.Add(this.label13);
            this.PnContratto.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnContratto.Enabled = false;
            this.PnContratto.Location = new System.Drawing.Point(688, 0);
            this.PnContratto.Name = "PnContratto";
            this.PnContratto.Size = new System.Drawing.Size(296, 466);
            this.PnContratto.TabIndex = 21;
            // 
            // dtpDataFine
            // 
            this.dtpDataFine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataFine.Location = new System.Drawing.Point(89, 232);
            this.dtpDataFine.Name = "dtpDataFine";
            this.dtpDataFine.Size = new System.Drawing.Size(195, 20);
            this.dtpDataFine.TabIndex = 21;
            // 
            // dtpDataInizio
            // 
            this.dtpDataInizio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataInizio.Location = new System.Drawing.Point(89, 185);
            this.dtpDataInizio.Name = "dtpDataInizio";
            this.dtpDataInizio.Size = new System.Drawing.Size(195, 20);
            this.dtpDataInizio.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Data fine:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Data inizio:";
            // 
            // nudMonteOre
            // 
            this.nudMonteOre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMonteOre.Location = new System.Drawing.Point(88, 138);
            this.nudMonteOre.Name = "nudMonteOre";
            this.nudMonteOre.Size = new System.Drawing.Size(196, 20);
            this.nudMonteOre.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Monte ore:";
            // 
            // rbIndeterminato
            // 
            this.rbIndeterminato.AutoSize = true;
            this.rbIndeterminato.Location = new System.Drawing.Point(201, 89);
            this.rbIndeterminato.Name = "rbIndeterminato";
            this.rbIndeterminato.Size = new System.Drawing.Size(88, 17);
            this.rbIndeterminato.TabIndex = 15;
            this.rbIndeterminato.TabStop = true;
            this.rbIndeterminato.Text = "indeterminato";
            this.rbIndeterminato.UseVisualStyleBackColor = true;
            this.rbIndeterminato.CheckedChanged += new System.EventHandler(this.rbIndeterminato_CheckedChanged);
            // 
            // rbDeterminato
            // 
            this.rbDeterminato.AutoSize = true;
            this.rbDeterminato.Location = new System.Drawing.Point(79, 89);
            this.rbDeterminato.Name = "rbDeterminato";
            this.rbDeterminato.Size = new System.Drawing.Size(80, 17);
            this.rbDeterminato.TabIndex = 14;
            this.rbDeterminato.TabStop = true;
            this.rbDeterminato.Text = "determinato";
            this.rbDeterminato.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Tipo:";
            // 
            // cldColori
            // 
            this.cldColori.FullOpen = true;
            // 
            // FrmUtente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 466);
            this.Controls.Add(this.PnContratto);
            this.Controls.Add(this.pnDipartimento);
            this.Controls.Add(this.pnCDC);
            this.Controls.Add(this.PnUtente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUtente";
            this.Text = "Utente";
            this.Load += new System.EventHandler(this.FrmUtente_Load);
            this.PnUtente.ResumeLayout(false);
            this.PnUtente.PerformLayout();
            this.pnCDC.ResumeLayout(false);
            this.pnCDC.PerformLayout();
            this.pnDipartimento.ResumeLayout(false);
            this.pnDipartimento.PerformLayout();
            this.PnContratto.ResumeLayout(false);
            this.PnContratto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonteOre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.TextBox tbCognome;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.ComboBox cbTipoUtente;
        private System.Windows.Forms.Button btAnnulla;
        private System.Windows.Forms.Button btSalva;
        private System.Windows.Forms.CheckBox ckbDocenteTeorico;
        private System.Windows.Forms.CheckBox ckbDocentePratico;
        private System.Windows.Forms.Panel PnUtente;
        private System.Windows.Forms.Panel pnCDC;
        private System.Windows.Forms.Panel pnDipartimento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox clbCLasseDiConcorso;
        private System.Windows.Forms.ComboBox cbDipartimentoCoordinato;
        private System.Windows.Forms.Label lbDcoordinato;
        private System.Windows.Forms.Panel PnContratto;
        private System.Windows.Forms.DateTimePicker dtpDataFine;
        private System.Windows.Forms.DateTimePicker dtpDataInizio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudMonteOre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rbIndeterminato;
        private System.Windows.Forms.RadioButton rbDeterminato;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckedListBox clbDipartimento;
        private System.Windows.Forms.CheckBox cbAutoEmail;
        private System.Windows.Forms.Button btColore;
        private System.Windows.Forms.ColorDialog cldColori;
        private System.Windows.Forms.Panel pnColore;
        private System.Windows.Forms.Label label9;
    }
}