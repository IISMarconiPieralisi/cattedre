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
            this.cbTipoUtente = new System.Windows.Forms.ComboBox();
            this.PnUtente = new System.Windows.Forms.Panel();
            this.pnTipoDocente = new System.Windows.Forms.Panel();
            this.rbLaboratorio = new System.Windows.Forms.RadioButton();
            this.rbTeorico = new System.Windows.Forms.RadioButton();
            this.pnColore = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbAutoEmail = new System.Windows.Forms.CheckBox();
            this.btColore = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnCDC = new System.Windows.Forms.Panel();
            this.clbDisciplina = new System.Windows.Forms.CheckedListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.clbCLasseDiConcorso = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnDipartimento = new System.Windows.Forms.Panel();
            this.clbDipartimento = new System.Windows.Forms.CheckedListBox();
            this.cbDipartimentoCoordinato = new System.Windows.Forms.ComboBox();
            this.lbDcoordinato = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PnContratto = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbDeterminato = new System.Windows.Forms.RadioButton();
            this.rbIndeterminato = new System.Windows.Forms.RadioButton();
            this.dtpDataFine = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInizio = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudMonteOre = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cldColori = new System.Windows.Forms.ColorDialog();
            this.tbNome = new Krypton.Toolkit.KryptonTextBox();
            this.tbCognome = new Krypton.Toolkit.KryptonTextBox();
            this.tbEmail = new Krypton.Toolkit.KryptonTextBox();
            this.tbPassword = new Krypton.Toolkit.KryptonTextBox();
            this.btSalva = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.PnUtente.SuspendLayout();
            this.pnTipoDocente.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnCDC.SuspendLayout();
            this.pnDipartimento.SuspendLayout();
            this.PnContratto.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonteOre)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cognome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo Utente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo Docente:";
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
            this.cbTipoUtente.Size = new System.Drawing.Size(194, 21);
            this.cbTipoUtente.TabIndex = 10;
            this.cbTipoUtente.SelectedIndexChanged += new System.EventHandler(this.cbTipoUtente_SelectedIndexChanged);
            this.cbTipoUtente.Enter += new System.EventHandler(this.cbTipoUtente_Enter);
            this.cbTipoUtente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTipoUtente_KeyDown);
            this.cbTipoUtente.Leave += new System.EventHandler(this.cbTipoUtente_Leave);
            // 
            // PnUtente
            // 
            this.PnUtente.AutoSize = true;
            this.PnUtente.Controls.Add(this.tbPassword);
            this.PnUtente.Controls.Add(this.tbEmail);
            this.PnUtente.Controls.Add(this.tbCognome);
            this.PnUtente.Controls.Add(this.tbNome);
            this.PnUtente.Controls.Add(this.pnTipoDocente);
            this.PnUtente.Controls.Add(this.pnColore);
            this.PnUtente.Controls.Add(this.label9);
            this.PnUtente.Controls.Add(this.cbAutoEmail);
            this.PnUtente.Controls.Add(this.btColore);
            this.PnUtente.Controls.Add(this.label1);
            this.PnUtente.Controls.Add(this.label2);
            this.PnUtente.Controls.Add(this.label3);
            this.PnUtente.Controls.Add(this.label4);
            this.PnUtente.Controls.Add(this.label5);
            this.PnUtente.Controls.Add(this.cbTipoUtente);
            this.PnUtente.Controls.Add(this.label6);
            this.PnUtente.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnUtente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PnUtente.Location = new System.Drawing.Point(0, 0);
            this.PnUtente.Name = "PnUtente";
            this.PnUtente.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.PnUtente.Size = new System.Drawing.Size(345, 466);
            this.PnUtente.TabIndex = 18;
            // 
            // pnTipoDocente
            // 
            this.pnTipoDocente.Controls.Add(this.rbLaboratorio);
            this.pnTipoDocente.Controls.Add(this.rbTeorico);
            this.pnTipoDocente.Location = new System.Drawing.Point(108, 270);
            this.pnTipoDocente.Name = "pnTipoDocente";
            this.pnTipoDocente.Size = new System.Drawing.Size(219, 31);
            this.pnTipoDocente.TabIndex = 25;
            // 
            // rbLaboratorio
            // 
            this.rbLaboratorio.AutoSize = true;
            this.rbLaboratorio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLaboratorio.Location = new System.Drawing.Point(115, 7);
            this.rbLaboratorio.Name = "rbLaboratorio";
            this.rbLaboratorio.Size = new System.Drawing.Size(101, 20);
            this.rbLaboratorio.TabIndex = 1;
            this.rbLaboratorio.TabStop = true;
            this.rbLaboratorio.Text = "Laboratorio";
            this.rbLaboratorio.UseVisualStyleBackColor = true;
            this.rbLaboratorio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbTipoDocente);
            // 
            // rbTeorico
            // 
            this.rbTeorico.AutoSize = true;
            this.rbTeorico.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTeorico.Location = new System.Drawing.Point(4, 7);
            this.rbTeorico.Name = "rbTeorico";
            this.rbTeorico.Size = new System.Drawing.Size(73, 20);
            this.rbTeorico.TabIndex = 0;
            this.rbTeorico.TabStop = true;
            this.rbTeorico.Text = "Teorico";
            this.rbTeorico.UseVisualStyleBackColor = true;
            this.rbTeorico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbTipoDocente);
            // 
            // pnColore
            // 
            this.pnColore.BackColor = System.Drawing.Color.White;
            this.pnColore.Location = new System.Drawing.Point(218, 326);
            this.pnColore.Name = "pnColore";
            this.pnColore.Size = new System.Drawing.Size(24, 23);
            this.pnColore.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Seleziona colore:";
            // 
            // cbAutoEmail
            // 
            this.cbAutoEmail.AutoSize = true;
            this.cbAutoEmail.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoEmail.Location = new System.Drawing.Point(109, 149);
            this.cbAutoEmail.Name = "cbAutoEmail";
            this.cbAutoEmail.Size = new System.Drawing.Size(133, 21);
            this.cbAutoEmail.TabIndex = 18;
            this.cbAutoEmail.Text = "Email Automatica";
            this.cbAutoEmail.UseVisualStyleBackColor = true;
            this.cbAutoEmail.CheckedChanged += new System.EventHandler(this.cbAutoEmail_CheckedChanged);
            this.cbAutoEmail.Enter += new System.EventHandler(this.checkBoxAutoEmail_Enter);
            this.cbAutoEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAutoEmail_KeyDown);
            this.cbAutoEmail.Leave += new System.EventHandler(this.checkBoxAutoEmail_Leave);
            // 
            // btColore
            // 
            this.btColore.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btColore.Location = new System.Drawing.Point(128, 326);
            this.btColore.Name = "btColore";
            this.btColore.Size = new System.Drawing.Size(89, 23);
            this.btColore.TabIndex = 22;
            this.btColore.Text = "seleziona";
            this.btColore.UseVisualStyleBackColor = true;
            this.btColore.Click += new System.EventHandler(this.btColore_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.kryptonButton1);
            this.panel2.Controls.Add(this.btSalva);
            this.panel2.Location = new System.Drawing.Point(3, 354);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 100);
            this.panel2.TabIndex = 26;
            // 
            // pnCDC
            // 
            this.pnCDC.AutoSize = true;
            this.pnCDC.Controls.Add(this.clbDisciplina);
            this.pnCDC.Controls.Add(this.label14);
            this.pnCDC.Controls.Add(this.clbCLasseDiConcorso);
            this.pnCDC.Controls.Add(this.label7);
            this.pnCDC.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnCDC.Location = new System.Drawing.Point(345, 0);
            this.pnCDC.Name = "pnCDC";
            this.pnCDC.Size = new System.Drawing.Size(235, 466);
            this.pnCDC.TabIndex = 19;
            this.pnCDC.Visible = false;
            // 
            // clbDisciplina
            // 
            this.clbDisciplina.Enabled = false;
            this.clbDisciplina.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbDisciplina.FormattingEnabled = true;
            this.clbDisciplina.Location = new System.Drawing.Point(3, 248);
            this.clbDisciplina.Name = "clbDisciplina";
            this.clbDisciplina.Size = new System.Drawing.Size(226, 123);
            this.clbDisciplina.TabIndex = 20;
            this.clbDisciplina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clbDisciplina_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 232);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 16);
            this.label14.TabIndex = 19;
            this.label14.Text = "Discipline:";
            // 
            // clbCLasseDiConcorso
            // 
            this.clbCLasseDiConcorso.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbCLasseDiConcorso.FormattingEnabled = true;
            this.clbCLasseDiConcorso.Location = new System.Drawing.Point(3, 59);
            this.clbCLasseDiConcorso.Name = "clbCLasseDiConcorso";
            this.clbCLasseDiConcorso.Size = new System.Drawing.Size(229, 123);
            this.clbCLasseDiConcorso.TabIndex = 18;
            this.clbCLasseDiConcorso.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCLasseDiConcorso_ItemCheck);
            this.clbCLasseDiConcorso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clbCLasseDiConcorso_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 16);
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
            this.pnDipartimento.Location = new System.Drawing.Point(580, 0);
            this.pnDipartimento.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.pnDipartimento.Name = "pnDipartimento";
            this.pnDipartimento.Size = new System.Drawing.Size(166, 466);
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
            this.clbDipartimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clbDipartimento_KeyDown);
            // 
            // cbDipartimentoCoordinato
            // 
            this.cbDipartimentoCoordinato.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDipartimentoCoordinato.FormattingEnabled = true;
            this.cbDipartimentoCoordinato.Location = new System.Drawing.Point(6, 264);
            this.cbDipartimentoCoordinato.Name = "cbDipartimentoCoordinato";
            this.cbDipartimentoCoordinato.Size = new System.Drawing.Size(157, 25);
            this.cbDipartimentoCoordinato.TabIndex = 19;
            this.cbDipartimentoCoordinato.Visible = false;
            this.cbDipartimentoCoordinato.DropDown += new System.EventHandler(this.cbDipartimentoCoordinato_DropDown);
            this.cbDipartimentoCoordinato.SelectedIndexChanged += new System.EventHandler(this.cbDipartimentoCoordinato_SelectedIndexChanged);
            this.cbDipartimentoCoordinato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDipartimentoCoordinato_KeyDown);
            // 
            // lbDcoordinato
            // 
            this.lbDcoordinato.AutoSize = true;
            this.lbDcoordinato.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDcoordinato.Location = new System.Drawing.Point(7, 229);
            this.lbDcoordinato.Name = "lbDcoordinato";
            this.lbDcoordinato.Size = new System.Drawing.Size(96, 32);
            this.lbDcoordinato.TabIndex = 20;
            this.lbDcoordinato.Text = "Dipartimento \r\nCoordinato:";
            this.lbDcoordinato.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Dipartimento:";
            // 
            // PnContratto
            // 
            this.PnContratto.Controls.Add(this.panel1);
            this.PnContratto.Controls.Add(this.dtpDataFine);
            this.PnContratto.Controls.Add(this.dtpDataInizio);
            this.PnContratto.Controls.Add(this.label10);
            this.PnContratto.Controls.Add(this.label11);
            this.PnContratto.Controls.Add(this.nudMonteOre);
            this.PnContratto.Controls.Add(this.label12);
            this.PnContratto.Controls.Add(this.label13);
            this.PnContratto.Controls.Add(this.panel2);
            this.PnContratto.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnContratto.Enabled = false;
            this.PnContratto.Location = new System.Drawing.Point(763, 0);
            this.PnContratto.Name = "PnContratto";
            this.PnContratto.Size = new System.Drawing.Size(300, 466);
            this.PnContratto.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbDeterminato);
            this.panel1.Controls.Add(this.rbIndeterminato);
            this.panel1.Location = new System.Drawing.Point(66, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 41);
            this.panel1.TabIndex = 22;
            // 
            // rbDeterminato
            // 
            this.rbDeterminato.AutoSize = true;
            this.rbDeterminato.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDeterminato.Location = new System.Drawing.Point(3, 13);
            this.rbDeterminato.Name = "rbDeterminato";
            this.rbDeterminato.Size = new System.Drawing.Size(105, 20);
            this.rbDeterminato.TabIndex = 14;
            this.rbDeterminato.TabStop = true;
            this.rbDeterminato.Text = "determinato";
            this.rbDeterminato.UseVisualStyleBackColor = true;
            this.rbDeterminato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbContratto_KeyDown);
            // 
            // rbIndeterminato
            // 
            this.rbIndeterminato.AutoSize = true;
            this.rbIndeterminato.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIndeterminato.Location = new System.Drawing.Point(109, 13);
            this.rbIndeterminato.Name = "rbIndeterminato";
            this.rbIndeterminato.Size = new System.Drawing.Size(117, 20);
            this.rbIndeterminato.TabIndex = 15;
            this.rbIndeterminato.TabStop = true;
            this.rbIndeterminato.Text = "indeterminato";
            this.rbIndeterminato.UseVisualStyleBackColor = true;
            this.rbIndeterminato.CheckedChanged += new System.EventHandler(this.rbIndeterminato_CheckedChanged);
            this.rbIndeterminato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbContratto_KeyDown);
            // 
            // dtpDataFine
            // 
            this.dtpDataFine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataFine.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataFine.Location = new System.Drawing.Point(89, 232);
            this.dtpDataFine.Name = "dtpDataFine";
            this.dtpDataFine.Size = new System.Drawing.Size(199, 22);
            this.dtpDataFine.TabIndex = 21;
            this.dtpDataFine.ValueChanged += new System.EventHandler(this.dtpDataFine_ValueChanged);
            this.dtpDataFine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDataFine_KeyDown);
            // 
            // dtpDataInizio
            // 
            this.dtpDataInizio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataInizio.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataInizio.Location = new System.Drawing.Point(89, 185);
            this.dtpDataInizio.Name = "dtpDataInizio";
            this.dtpDataInizio.Size = new System.Drawing.Size(199, 22);
            this.dtpDataInizio.TabIndex = 20;
            this.dtpDataInizio.ValueChanged += new System.EventHandler(this.dtpDataInizio_ValueChanged);
            this.dtpDataInizio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDataInizio_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Data fine:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Data inizio:";
            // 
            // nudMonteOre
            // 
            this.nudMonteOre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMonteOre.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMonteOre.Location = new System.Drawing.Point(88, 138);
            this.nudMonteOre.Name = "nudMonteOre";
            this.nudMonteOre.Size = new System.Drawing.Size(200, 22);
            this.nudMonteOre.TabIndex = 17;
            this.nudMonteOre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudMonteOre_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "Monte ore:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(21, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "Tipo:";
            // 
            // cldColori
            // 
            this.cldColori.FullOpen = true;
            // 
            // tbNome
            // 
            this.tbNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNome.Location = new System.Drawing.Point(96, 40);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(132, 29);
            this.tbNome.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbNome.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbNome.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbNome.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbNome.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbNome.StateCommon.Border.Rounding = 20F;
            this.tbNome.StateCommon.Border.Width = 1;
            this.tbNome.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.tbNome.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNome.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbNome.TabIndex = 38;
            // 
            // tbCognome
            // 
            this.tbCognome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCognome.Location = new System.Drawing.Point(95, 79);
            this.tbCognome.Name = "tbCognome";
            this.tbCognome.Size = new System.Drawing.Size(132, 29);
            this.tbCognome.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbCognome.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbCognome.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbCognome.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbCognome.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbCognome.StateCommon.Border.Rounding = 20F;
            this.tbCognome.StateCommon.Border.Width = 1;
            this.tbCognome.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.tbCognome.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCognome.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbCognome.TabIndex = 38;
            // 
            // tbEmail
            // 
            this.tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmail.Location = new System.Drawing.Point(95, 114);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(132, 29);
            this.tbEmail.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbEmail.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbEmail.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbEmail.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbEmail.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbEmail.StateCommon.Border.Rounding = 20F;
            this.tbEmail.StateCommon.Border.Width = 1;
            this.tbEmail.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.tbEmail.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbEmail.TabIndex = 39;
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Location = new System.Drawing.Point(95, 177);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(132, 29);
            this.tbPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbPassword.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbPassword.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbPassword.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbPassword.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbPassword.StateCommon.Border.Rounding = 20F;
            this.tbPassword.StateCommon.Border.Width = 1;
            this.tbPassword.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.tbPassword.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbPassword.TabIndex = 40;
            // 
            // btSalva
            // 
            this.btSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSalva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalva.Location = new System.Drawing.Point(91, 16);
            this.btSalva.Name = "btSalva";
            this.btSalva.OverrideDefault.Back.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalva.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btSalva.OverrideDefault.Back.ColorAngle = 45F;
            this.btSalva.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btSalva.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btSalva.OverrideDefault.Border.ColorAngle = 45F;
            this.btSalva.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalva.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btSalva.OverrideDefault.Border.Rounding = 20F;
            this.btSalva.OverrideDefault.Border.Width = 1;
            this.btSalva.Size = new System.Drawing.Size(130, 33);
            this.btSalva.StateCommon.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.btSalva.StateCommon.Back.Color2 = System.Drawing.Color.YellowGreen;
            this.btSalva.StateCommon.Back.ColorAngle = 45F;
            this.btSalva.StateCommon.Border.Color1 = System.Drawing.Color.ForestGreen;
            this.btSalva.StateCommon.Border.Color2 = System.Drawing.Color.YellowGreen;
            this.btSalva.StateCommon.Border.ColorAngle = 45F;
            this.btSalva.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalva.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btSalva.StateCommon.Border.Rounding = 20F;
            this.btSalva.StateCommon.Border.Width = 1;
            this.btSalva.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btSalva.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btSalva.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalva.StateNormal.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.btSalva.StateNormal.Back.Color2 = System.Drawing.Color.YellowGreen;
            this.btSalva.StateNormal.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalva.StateNormal.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalva.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalva.StatePressed.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.btSalva.StatePressed.Back.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalva.StatePressed.Back.ColorAngle = 135F;
            this.btSalva.StatePressed.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalva.StatePressed.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalva.StatePressed.Border.ColorAngle = 135F;
            this.btSalva.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalva.StatePressed.Border.Rounding = 20F;
            this.btSalva.StatePressed.Border.Width = 1;
            this.btSalva.StateTracking.Back.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalva.StateTracking.Back.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalva.StateTracking.Back.ColorAngle = 45F;
            this.btSalva.StateTracking.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalva.StateTracking.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalva.StateTracking.Border.ColorAngle = 45F;
            this.btSalva.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalva.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btSalva.StateTracking.Border.Rounding = 20F;
            this.btSalva.StateTracking.Border.Width = 1;
            this.btSalva.TabIndex = 33;
            this.btSalva.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btSalva.Values.Text = "Salva";
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonButton1.Location = new System.Drawing.Point(91, 56);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.OverrideDefault.Back.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButton1.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.kryptonButton1.OverrideDefault.Back.ColorAngle = 45F;
            this.kryptonButton1.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.kryptonButton1.OverrideDefault.Border.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButton1.OverrideDefault.Border.ColorAngle = 45F;
            this.kryptonButton1.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButton1.OverrideDefault.Border.Rounding = 20F;
            this.kryptonButton1.OverrideDefault.Border.Width = 1;
            this.kryptonButton1.Size = new System.Drawing.Size(130, 32);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButton1.StateCommon.Back.ColorAngle = 45F;
            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.kryptonButton1.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButton1.StateCommon.Border.ColorAngle = 45F;
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButton1.StateCommon.Border.Rounding = 20F;
            this.kryptonButton1.StateCommon.Border.Width = 1;
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.StateNormal.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButton1.StateNormal.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButton1.StateNormal.Border.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButton1.StateNormal.Border.Color2 = System.Drawing.Color.Red;
            this.kryptonButton1.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButton1.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.kryptonButton1.StatePressed.Back.ColorAngle = 135F;
            this.kryptonButton1.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.kryptonButton1.StatePressed.Border.Color2 = System.Drawing.Color.Red;
            this.kryptonButton1.StatePressed.Border.ColorAngle = 135F;
            this.kryptonButton1.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StatePressed.Border.Rounding = 20F;
            this.kryptonButton1.StatePressed.Border.Width = 1;
            this.kryptonButton1.StateTracking.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButton1.StateTracking.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButton1.StateTracking.Back.ColorAngle = 45F;
            this.kryptonButton1.StateTracking.Border.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButton1.StateTracking.Border.Color2 = System.Drawing.Color.Red;
            this.kryptonButton1.StateTracking.Border.ColorAngle = 45F;
            this.kryptonButton1.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButton1.StateTracking.Border.Rounding = 20F;
            this.kryptonButton1.StateTracking.Border.Width = 1;
            this.kryptonButton1.TabIndex = 34;
            this.kryptonButton1.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton1.Values.Text = "Annulla";
            this.kryptonButton1.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // FrmUtente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 466);
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
            this.pnTipoDocente.ResumeLayout(false);
            this.pnTipoDocente.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnCDC.ResumeLayout(false);
            this.pnCDC.PerformLayout();
            this.pnDipartimento.ResumeLayout(false);
            this.pnDipartimento.PerformLayout();
            this.PnContratto.ResumeLayout(false);
            this.PnContratto.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbTipoUtente;
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
        private System.Windows.Forms.CheckedListBox clbDisciplina;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnTipoDocente;
        private System.Windows.Forms.RadioButton rbLaboratorio;
        private System.Windows.Forms.RadioButton rbTeorico;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Krypton.Toolkit.KryptonTextBox tbPassword;
        private Krypton.Toolkit.KryptonTextBox tbEmail;
        private Krypton.Toolkit.KryptonTextBox tbCognome;
        private Krypton.Toolkit.KryptonTextBox tbNome;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton btSalva;
    }
}