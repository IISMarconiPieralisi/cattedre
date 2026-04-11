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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiscipline));
            this.cbDipartimenti = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCerca = new System.Windows.Forms.Button();
            this.lvDiscipline = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAnno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOreLab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOreTeoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDisciplinaSpeciale = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDipartimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndirizzi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbDisciplinaSucessiva = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.btPulisciCb = new System.Windows.Forms.Button();
            this.gbAnni = new System.Windows.Forms.GroupBox();
            this.rbAnno5 = new System.Windows.Forms.RadioButton();
            this.rbAnno4 = new System.Windows.Forms.RadioButton();
            this.rbAnno3 = new System.Windows.Forms.RadioButton();
            this.rbAnno2 = new System.Windows.Forms.RadioButton();
            this.rbAnno1 = new System.Windows.Forms.RadioButton();
            this.btModifica = new Krypton.Toolkit.KryptonButton();
            this.btElimina = new Krypton.Toolkit.KryptonButton();
            this.btInserisci = new Krypton.Toolkit.KryptonButton();
            this.tbDisciplina = new Krypton.Toolkit.KryptonTextBox();
            this.gbAnni.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDipartimenti
            // 
            this.cbDipartimenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDipartimenti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDipartimenti.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDipartimenti.FormattingEnabled = true;
            this.cbDipartimenti.Location = new System.Drawing.Point(111, 27);
            this.cbDipartimenti.Name = "cbDipartimenti";
            this.cbDipartimenti.Size = new System.Drawing.Size(237, 25);
            this.cbDipartimenti.TabIndex = 5;
            this.cbDipartimenti.SelectedIndexChanged += new System.EventHandler(this.cbDipartimenti_SelectedIndexChanged);
            this.cbDipartimenti.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDipartimenti_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Dipartimento:";
            // 
            // btCerca
            // 
            this.btCerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerca.Location = new System.Drawing.Point(1065, 32);
            this.btCerca.Name = "btCerca";
            this.btCerca.Size = new System.Drawing.Size(75, 23);
            this.btCerca.TabIndex = 8;
            this.btCerca.Text = "Cerca";
            this.btCerca.UseVisualStyleBackColor = true;
            this.btCerca.Click += new System.EventHandler(this.btCerca_Click);
            // 
            // lvDiscipline
            // 
            this.lvDiscipline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDiscipline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chAnno,
            this.chNome,
            this.chOreLab,
            this.chOreTeoria,
            this.chDisciplinaSpeciale,
            this.chDipartimento,
            this.chIndirizzi,
            this.cbDisciplinaSucessiva});
            this.lvDiscipline.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDiscipline.FullRowSelect = true;
            this.lvDiscipline.HideSelection = false;
            this.lvDiscipline.Location = new System.Drawing.Point(12, 72);
            this.lvDiscipline.Name = "lvDiscipline";
            this.lvDiscipline.Size = new System.Drawing.Size(1221, 314);
            this.lvDiscipline.TabIndex = 1;
            this.lvDiscipline.UseCompatibleStateImageBehavior = false;
            this.lvDiscipline.View = System.Windows.Forms.View.Details;
            this.lvDiscipline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvDiscipline_KeyDown);
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 50;
            // 
            // chAnno
            // 
            this.chAnno.Text = "Anno";
            this.chAnno.Width = 70;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 150;
            // 
            // chOreLab
            // 
            this.chOreLab.DisplayIndex = 4;
            this.chOreLab.Text = "Ore Lab";
            this.chOreLab.Width = 77;
            // 
            // chOreTeoria
            // 
            this.chOreTeoria.DisplayIndex = 3;
            this.chOreTeoria.Text = "Ore Teoria";
            this.chOreTeoria.Width = 83;
            // 
            // chDisciplinaSpeciale
            // 
            this.chDisciplinaSpeciale.Text = "Speciale";
            this.chDisciplinaSpeciale.Width = 150;
            // 
            // chDipartimento
            // 
            this.chDipartimento.Text = "Dipartimento";
            this.chDipartimento.Width = 159;
            // 
            // chIndirizzi
            // 
            this.chIndirizzi.Text = "Indirizzi";
            this.chIndirizzi.Width = 200;
            // 
            // cbDisciplinaSucessiva
            // 
            this.cbDisciplinaSucessiva.Text = "Disciplina successiva";
            this.cbDisciplinaSucessiva.Width = 150;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(587, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Disciplina:";
            // 
            // btPulisciCb
            // 
            this.btPulisciCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPulisciCb.Enabled = false;
            this.btPulisciCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPulisciCb.ForeColor = System.Drawing.Color.DarkRed;
            this.btPulisciCb.Location = new System.Drawing.Point(808, 28);
            this.btPulisciCb.Name = "btPulisciCb";
            this.btPulisciCb.Size = new System.Drawing.Size(26, 23);
            this.btPulisciCb.TabIndex = 31;
            this.btPulisciCb.Text = "X";
            this.btPulisciCb.UseVisualStyleBackColor = true;
            this.btPulisciCb.Click += new System.EventHandler(this.btPulisciCb_Click);
            // 
            // gbAnni
            // 
            this.gbAnni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAnni.Controls.Add(this.rbAnno5);
            this.gbAnni.Controls.Add(this.rbAnno4);
            this.gbAnni.Controls.Add(this.rbAnno3);
            this.gbAnni.Controls.Add(this.rbAnno2);
            this.gbAnni.Controls.Add(this.rbAnno1);
            this.gbAnni.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAnni.Location = new System.Drawing.Point(372, 12);
            this.gbAnni.Name = "gbAnni";
            this.gbAnni.Size = new System.Drawing.Size(200, 43);
            this.gbAnni.TabIndex = 6;
            this.gbAnni.TabStop = false;
            this.gbAnni.Text = "Anno";
            // 
            // rbAnno5
            // 
            this.rbAnno5.AutoSize = true;
            this.rbAnno5.Location = new System.Drawing.Point(155, 17);
            this.rbAnno5.Name = "rbAnno5";
            this.rbAnno5.Size = new System.Drawing.Size(33, 20);
            this.rbAnno5.TabIndex = 4;
            this.rbAnno5.TabStop = true;
            this.rbAnno5.Text = "5";
            this.rbAnno5.UseVisualStyleBackColor = true;
            this.rbAnno5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnni_KeyDown);
            // 
            // rbAnno4
            // 
            this.rbAnno4.AutoSize = true;
            this.rbAnno4.Location = new System.Drawing.Point(118, 17);
            this.rbAnno4.Name = "rbAnno4";
            this.rbAnno4.Size = new System.Drawing.Size(33, 20);
            this.rbAnno4.TabIndex = 3;
            this.rbAnno4.TabStop = true;
            this.rbAnno4.Text = "4";
            this.rbAnno4.UseVisualStyleBackColor = true;
            this.rbAnno4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnni_KeyDown);
            // 
            // rbAnno3
            // 
            this.rbAnno3.AutoSize = true;
            this.rbAnno3.Location = new System.Drawing.Point(81, 17);
            this.rbAnno3.Name = "rbAnno3";
            this.rbAnno3.Size = new System.Drawing.Size(33, 20);
            this.rbAnno3.TabIndex = 2;
            this.rbAnno3.TabStop = true;
            this.rbAnno3.Text = "3";
            this.rbAnno3.UseVisualStyleBackColor = true;
            this.rbAnno3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnni_KeyDown);
            // 
            // rbAnno2
            // 
            this.rbAnno2.AutoSize = true;
            this.rbAnno2.Location = new System.Drawing.Point(44, 17);
            this.rbAnno2.Name = "rbAnno2";
            this.rbAnno2.Size = new System.Drawing.Size(33, 20);
            this.rbAnno2.TabIndex = 1;
            this.rbAnno2.TabStop = true;
            this.rbAnno2.Text = "2";
            this.rbAnno2.UseVisualStyleBackColor = true;
            this.rbAnno2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnni_KeyDown);
            // 
            // rbAnno1
            // 
            this.rbAnno1.AutoSize = true;
            this.rbAnno1.Location = new System.Drawing.Point(7, 17);
            this.rbAnno1.Name = "rbAnno1";
            this.rbAnno1.Size = new System.Drawing.Size(33, 20);
            this.rbAnno1.TabIndex = 0;
            this.rbAnno1.TabStop = true;
            this.rbAnno1.Text = "1";
            this.rbAnno1.UseVisualStyleBackColor = true;
            this.rbAnno1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnni_KeyDown);
            // 
            // btModifica
            // 
            this.btModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModifica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModifica.Location = new System.Drawing.Point(1255, 122);
            this.btModifica.Name = "btModifica";
            this.btModifica.OverrideDefault.Back.Color1 = System.Drawing.Color.OrangeRed;
            this.btModifica.OverrideDefault.Back.Color2 = System.Drawing.Color.DarkOrange;
            this.btModifica.OverrideDefault.Back.ColorAngle = 45F;
            this.btModifica.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.btModifica.OverrideDefault.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btModifica.OverrideDefault.Border.ColorAngle = 45F;
            this.btModifica.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btModifica.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btModifica.OverrideDefault.Border.Rounding = 20F;
            this.btModifica.OverrideDefault.Border.Width = 1;
            this.btModifica.Size = new System.Drawing.Size(109, 36);
            this.btModifica.StateCommon.Back.Color1 = System.Drawing.Color.Orange;
            this.btModifica.StateCommon.Back.Color2 = System.Drawing.Color.DarkOrange;
            this.btModifica.StateCommon.Back.ColorAngle = 45F;
            this.btModifica.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.btModifica.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btModifica.StateCommon.Border.ColorAngle = 45F;
            this.btModifica.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btModifica.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btModifica.StateCommon.Border.Rounding = 20F;
            this.btModifica.StateCommon.Border.Width = 1;
            this.btModifica.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btModifica.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btModifica.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModifica.StateNormal.Back.Color1 = System.Drawing.Color.Orange;
            this.btModifica.StateNormal.Back.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.btModifica.StateNormal.Border.Color1 = System.Drawing.Color.Orange;
            this.btModifica.StateNormal.Border.Color2 = System.Drawing.Color.DarkOrange;
            this.btModifica.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btModifica.StatePressed.Back.Color1 = System.Drawing.Color.Orange;
            this.btModifica.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.btModifica.StatePressed.Back.ColorAngle = 135F;
            this.btModifica.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.btModifica.StatePressed.Border.Color2 = System.Drawing.Color.DarkOrange;
            this.btModifica.StatePressed.Border.ColorAngle = 135F;
            this.btModifica.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btModifica.StatePressed.Border.Rounding = 20F;
            this.btModifica.StatePressed.Border.Width = 1;
            this.btModifica.StateTracking.Back.Color1 = System.Drawing.Color.Orange;
            this.btModifica.StateTracking.Back.Color2 = System.Drawing.Color.DarkOrange;
            this.btModifica.StateTracking.Back.ColorAngle = 45F;
            this.btModifica.StateTracking.Border.Color1 = System.Drawing.Color.DarkOrange;
            this.btModifica.StateTracking.Border.Color2 = System.Drawing.Color.Orange;
            this.btModifica.StateTracking.Border.ColorAngle = 45F;
            this.btModifica.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btModifica.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btModifica.StateTracking.Border.Rounding = 20F;
            this.btModifica.StateTracking.Border.Width = 1;
            this.btModifica.TabIndex = 36;
            this.btModifica.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btModifica.Values.Text = "Modifica";
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // btElimina
            // 
            this.btElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btElimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btElimina.Location = new System.Drawing.Point(1255, 175);
            this.btElimina.Name = "btElimina";
            this.btElimina.OverrideDefault.Back.Color1 = System.Drawing.Color.DarkRed;
            this.btElimina.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.btElimina.OverrideDefault.Back.ColorAngle = 45F;
            this.btElimina.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.btElimina.OverrideDefault.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btElimina.OverrideDefault.Border.ColorAngle = 45F;
            this.btElimina.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btElimina.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btElimina.OverrideDefault.Border.Rounding = 20F;
            this.btElimina.OverrideDefault.Border.Width = 1;
            this.btElimina.Size = new System.Drawing.Size(109, 36);
            this.btElimina.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.btElimina.StateCommon.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btElimina.StateCommon.Back.ColorAngle = 45F;
            this.btElimina.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.btElimina.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btElimina.StateCommon.Border.ColorAngle = 45F;
            this.btElimina.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btElimina.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btElimina.StateCommon.Border.Rounding = 20F;
            this.btElimina.StateCommon.Border.Width = 1;
            this.btElimina.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btElimina.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btElimina.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btElimina.StateNormal.Back.Color1 = System.Drawing.Color.Red;
            this.btElimina.StateNormal.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btElimina.StateNormal.Border.Color1 = System.Drawing.Color.DarkRed;
            this.btElimina.StateNormal.Border.Color2 = System.Drawing.Color.Red;
            this.btElimina.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btElimina.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.btElimina.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.btElimina.StatePressed.Back.ColorAngle = 135F;
            this.btElimina.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.btElimina.StatePressed.Border.Color2 = System.Drawing.Color.Red;
            this.btElimina.StatePressed.Border.ColorAngle = 135F;
            this.btElimina.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btElimina.StatePressed.Border.Rounding = 20F;
            this.btElimina.StatePressed.Border.Width = 1;
            this.btElimina.StateTracking.Back.Color1 = System.Drawing.Color.Red;
            this.btElimina.StateTracking.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btElimina.StateTracking.Back.ColorAngle = 45F;
            this.btElimina.StateTracking.Border.Color1 = System.Drawing.Color.DarkRed;
            this.btElimina.StateTracking.Border.Color2 = System.Drawing.Color.Red;
            this.btElimina.StateTracking.Border.ColorAngle = 45F;
            this.btElimina.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btElimina.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btElimina.StateTracking.Border.Rounding = 20F;
            this.btElimina.StateTracking.Border.Width = 1;
            this.btElimina.TabIndex = 35;
            this.btElimina.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btElimina.Values.Text = "Elimina";
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInserisci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btInserisci.Location = new System.Drawing.Point(1255, 72);
            this.btInserisci.Name = "btInserisci";
            this.btInserisci.OverrideDefault.Back.Color1 = System.Drawing.Color.YellowGreen;
            this.btInserisci.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btInserisci.OverrideDefault.Back.ColorAngle = 45F;
            this.btInserisci.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btInserisci.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btInserisci.OverrideDefault.Border.ColorAngle = 45F;
            this.btInserisci.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btInserisci.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btInserisci.OverrideDefault.Border.Rounding = 20F;
            this.btInserisci.OverrideDefault.Border.Width = 1;
            this.btInserisci.Size = new System.Drawing.Size(109, 36);
            this.btInserisci.StateCommon.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.btInserisci.StateCommon.Back.Color2 = System.Drawing.Color.YellowGreen;
            this.btInserisci.StateCommon.Back.ColorAngle = 45F;
            this.btInserisci.StateCommon.Border.Color1 = System.Drawing.Color.ForestGreen;
            this.btInserisci.StateCommon.Border.Color2 = System.Drawing.Color.YellowGreen;
            this.btInserisci.StateCommon.Border.ColorAngle = 45F;
            this.btInserisci.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btInserisci.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btInserisci.StateCommon.Border.Rounding = 20F;
            this.btInserisci.StateCommon.Border.Width = 1;
            this.btInserisci.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btInserisci.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btInserisci.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInserisci.StateNormal.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.btInserisci.StateNormal.Back.Color2 = System.Drawing.Color.YellowGreen;
            this.btInserisci.StateNormal.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.btInserisci.StateNormal.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.btInserisci.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btInserisci.StatePressed.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.btInserisci.StatePressed.Back.Color2 = System.Drawing.Color.ForestGreen;
            this.btInserisci.StatePressed.Back.ColorAngle = 135F;
            this.btInserisci.StatePressed.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.btInserisci.StatePressed.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.btInserisci.StatePressed.Border.ColorAngle = 135F;
            this.btInserisci.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btInserisci.StatePressed.Border.Rounding = 20F;
            this.btInserisci.StatePressed.Border.Width = 1;
            this.btInserisci.StateTracking.Back.Color1 = System.Drawing.Color.YellowGreen;
            this.btInserisci.StateTracking.Back.Color2 = System.Drawing.Color.ForestGreen;
            this.btInserisci.StateTracking.Back.ColorAngle = 45F;
            this.btInserisci.StateTracking.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.btInserisci.StateTracking.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.btInserisci.StateTracking.Border.ColorAngle = 45F;
            this.btInserisci.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btInserisci.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btInserisci.StateTracking.Border.Rounding = 20F;
            this.btInserisci.StateTracking.Border.Width = 1;
            this.btInserisci.TabIndex = 34;
            this.btInserisci.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btInserisci.Values.Text = "Inserisci";
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // tbDisciplina
            // 
            this.tbDisciplina.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisciplina.Location = new System.Drawing.Point(670, 23);
            this.tbDisciplina.Name = "tbDisciplina";
            this.tbDisciplina.Size = new System.Drawing.Size(132, 29);
            this.tbDisciplina.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbDisciplina.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbDisciplina.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbDisciplina.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbDisciplina.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbDisciplina.StateCommon.Border.Rounding = 20F;
            this.tbDisciplina.StateCommon.Border.Width = 1;
            this.tbDisciplina.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.tbDisciplina.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDisciplina.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbDisciplina.TabIndex = 37;
            // 
            // FrmDiscipline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 414);
            this.Controls.Add(this.tbDisciplina);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.gbAnni);
            this.Controls.Add(this.btPulisciCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvDiscipline);
            this.Controls.Add(this.cbDipartimenti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCerca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDiscipline";
            this.ShowInTaskbar = false;
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
        private System.Windows.Forms.ColumnHeader chIndirizzi;
        private System.Windows.Forms.ColumnHeader cbDisciplinaSucessiva;
        private System.Windows.Forms.ColumnHeader chID;
        private Krypton.Toolkit.KryptonButton btModifica;
        private Krypton.Toolkit.KryptonButton btElimina;
        private Krypton.Toolkit.KryptonButton btInserisci;
        private Krypton.Toolkit.KryptonTextBox tbDisciplina;
    }
}