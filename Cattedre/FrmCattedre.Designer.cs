namespace Cattedre
{
    partial class FrmCattedre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCattedre));
            this.pnlOreDoc = new System.Windows.Forms.Panel();
            this.lblOreEff = new System.Windows.Forms.Label();
            this.lblDocente = new System.Windows.Forms.Label();
            this.lblOreTot = new System.Windows.Forms.Label();
            this.lblOrePot = new System.Windows.Forms.Label();
            this.lblOreCattedra = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlCentrale = new System.Windows.Forms.Panel();
            this.pnlDipartimento = new System.Windows.Forms.Panel();
            this.pnlClassi = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlDiscipline = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btGeneraWord = new Krypton.Toolkit.KryptonButton();
            this.cbDipartimenti = new System.Windows.Forms.ComboBox();
            this.btGeneraASsucc = new Krypton.Toolkit.KryptonButton();
            this.cbAnniScolastici = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlOreDoc.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlCentrale.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOreDoc
            // 
            this.pnlOreDoc.Controls.Add(this.lblOreEff);
            this.pnlOreDoc.Controls.Add(this.lblDocente);
            this.pnlOreDoc.Controls.Add(this.lblOreTot);
            this.pnlOreDoc.Controls.Add(this.lblOrePot);
            this.pnlOreDoc.Controls.Add(this.lblOreCattedra);
            this.pnlOreDoc.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOreDoc.Location = new System.Drawing.Point(1007, 0);
            this.pnlOreDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOreDoc.MaximumSize = new System.Drawing.Size(533, 0);
            this.pnlOreDoc.MinimumSize = new System.Drawing.Size(400, 0);
            this.pnlOreDoc.Name = "pnlOreDoc";
            this.pnlOreDoc.Size = new System.Drawing.Size(533, 846);
            this.pnlOreDoc.TabIndex = 4;
            // 
            // lblOreEff
            // 
            this.lblOreEff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOreEff.AutoSize = true;
            this.lblOreEff.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreEff.Location = new System.Drawing.Point(277, 11);
            this.lblOreEff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOreEff.Name = "lblOreEff";
            this.lblOreEff.Size = new System.Drawing.Size(63, 19);
            this.lblOreEff.TabIndex = 12;
            this.lblOreEff.Tag = "header";
            this.lblOreEff.Text = "Ore Eff";
            // 
            // lblDocente
            // 
            this.lblDocente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocente.AutoSize = true;
            this.lblDocente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocente.Location = new System.Drawing.Point(8, 11);
            this.lblDocente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(79, 19);
            this.lblDocente.TabIndex = 10;
            this.lblDocente.Tag = "header";
            this.lblDocente.Text = "Docente";
            // 
            // lblOreTot
            // 
            this.lblOreTot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOreTot.AutoSize = true;
            this.lblOreTot.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreTot.Location = new System.Drawing.Point(481, 11);
            this.lblOreTot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOreTot.Name = "lblOreTot";
            this.lblOreTot.Size = new System.Drawing.Size(31, 19);
            this.lblOreTot.TabIndex = 14;
            this.lblOreTot.Tag = "header";
            this.lblOreTot.Text = "Tot";
            // 
            // lblOrePot
            // 
            this.lblOrePot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrePot.AutoSize = true;
            this.lblOrePot.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrePot.Location = new System.Drawing.Point(381, 11);
            this.lblOrePot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrePot.Name = "lblOrePot";
            this.lblOrePot.Size = new System.Drawing.Size(69, 19);
            this.lblOrePot.TabIndex = 13;
            this.lblOrePot.Tag = "header";
            this.lblOrePot.Text = "Ore Pot";
            // 
            // lblOreCattedra
            // 
            this.lblOreCattedra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOreCattedra.AutoSize = true;
            this.lblOreCattedra.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreCattedra.Location = new System.Drawing.Point(140, 11);
            this.lblOreCattedra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOreCattedra.Name = "lblOreCattedra";
            this.lblOreCattedra.Size = new System.Drawing.Size(114, 19);
            this.lblOreCattedra.TabIndex = 11;
            this.lblOreCattedra.Tag = "header";
            this.lblOreCattedra.Text = "Ore Cattedra";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlCentrale);
            this.pnlLeft.Controls.Add(this.pnlTop);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(1007, 846);
            this.pnlLeft.TabIndex = 5;
            // 
            // pnlCentrale
            // 
            this.pnlCentrale.Controls.Add(this.pnlDipartimento);
            this.pnlCentrale.Controls.Add(this.pnlClassi);
            this.pnlCentrale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentrale.Location = new System.Drawing.Point(0, 123);
            this.pnlCentrale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCentrale.Name = "pnlCentrale";
            this.pnlCentrale.Size = new System.Drawing.Size(1007, 723);
            this.pnlCentrale.TabIndex = 8;
            // 
            // pnlDipartimento
            // 
            this.pnlDipartimento.AutoScroll = true;
            this.pnlDipartimento.BackColor = System.Drawing.Color.Transparent;
            this.pnlDipartimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDipartimento.Location = new System.Drawing.Point(225, 0);
            this.pnlDipartimento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDipartimento.Name = "pnlDipartimento";
            this.pnlDipartimento.Size = new System.Drawing.Size(782, 723);
            this.pnlDipartimento.TabIndex = 2;
            // 
            // pnlClassi
            // 
            this.pnlClassi.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlClassi.Location = new System.Drawing.Point(0, 0);
            this.pnlClassi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlClassi.Name = "pnlClassi";
            this.pnlClassi.Size = new System.Drawing.Size(225, 723);
            this.pnlClassi.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlDiscipline);
            this.pnlTop.Controls.Add(this.pnlButtons);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1007, 123);
            this.pnlTop.TabIndex = 7;
            // 
            // pnlDiscipline
            // 
            this.pnlDiscipline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDiscipline.Location = new System.Drawing.Point(225, 0);
            this.pnlDiscipline.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDiscipline.Name = "pnlDiscipline";
            this.pnlDiscipline.Size = new System.Drawing.Size(782, 123);
            this.pnlDiscipline.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btGeneraWord);
            this.pnlButtons.Controls.Add(this.cbDipartimenti);
            this.pnlButtons.Controls.Add(this.btGeneraASsucc);
            this.pnlButtons.Controls.Add(this.cbAnniScolastici);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(225, 123);
            this.pnlButtons.TabIndex = 0;
            // 
            // btGeneraWord
            // 
            this.btGeneraWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGeneraWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGeneraWord.Location = new System.Drawing.Point(121, 48);
            this.btGeneraWord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btGeneraWord.Name = "btGeneraWord";
            this.btGeneraWord.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btGeneraWord.OverrideDefault.Back.Color2 = System.Drawing.Color.Yellow;
            this.btGeneraWord.OverrideDefault.Back.ColorAngle = 45F;
            this.btGeneraWord.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btGeneraWord.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btGeneraWord.OverrideDefault.Border.ColorAngle = 45F;
            this.btGeneraWord.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraWord.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btGeneraWord.OverrideDefault.Border.Rounding = 20F;
            this.btGeneraWord.OverrideDefault.Border.Width = 1;
            this.btGeneraWord.Size = new System.Drawing.Size(99, 53);
            this.btGeneraWord.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btGeneraWord.StateCommon.Back.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.btGeneraWord.StateCommon.Back.ColorAngle = 45F;
            this.btGeneraWord.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btGeneraWord.StateCommon.Border.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.btGeneraWord.StateCommon.Border.ColorAngle = 45F;
            this.btGeneraWord.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraWord.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btGeneraWord.StateCommon.Border.Rounding = 20F;
            this.btGeneraWord.StateCommon.Border.Width = 1;
            this.btGeneraWord.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btGeneraWord.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btGeneraWord.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGeneraWord.StateCommon.Content.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btGeneraWord.StateCommon.Content.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btGeneraWord.StateNormal.Back.Color1 = System.Drawing.Color.Orange;
            this.btGeneraWord.StateNormal.Back.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.btGeneraWord.StateNormal.Border.Color1 = System.Drawing.Color.Orange;
            this.btGeneraWord.StateNormal.Border.Color2 = System.Drawing.Color.DarkOrange;
            this.btGeneraWord.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraWord.StatePressed.Back.Color1 = System.Drawing.Color.Orange;
            this.btGeneraWord.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.btGeneraWord.StatePressed.Back.ColorAngle = 135F;
            this.btGeneraWord.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.btGeneraWord.StatePressed.Border.Color2 = System.Drawing.Color.DarkOrange;
            this.btGeneraWord.StatePressed.Border.ColorAngle = 135F;
            this.btGeneraWord.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraWord.StatePressed.Border.Rounding = 20F;
            this.btGeneraWord.StatePressed.Border.Width = 1;
            this.btGeneraWord.StateTracking.Back.Color1 = System.Drawing.Color.Orange;
            this.btGeneraWord.StateTracking.Back.Color2 = System.Drawing.Color.DarkOrange;
            this.btGeneraWord.StateTracking.Back.ColorAngle = 45F;
            this.btGeneraWord.StateTracking.Border.Color1 = System.Drawing.Color.DarkOrange;
            this.btGeneraWord.StateTracking.Border.Color2 = System.Drawing.Color.Orange;
            this.btGeneraWord.StateTracking.Border.ColorAngle = 45F;
            this.btGeneraWord.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraWord.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btGeneraWord.StateTracking.Border.Rounding = 20F;
            this.btGeneraWord.StateTracking.Border.Width = 1;
            this.btGeneraWord.TabIndex = 52;
            this.btGeneraWord.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btGeneraWord.Values.Text = "Stampa\r\n  Word";
            this.btGeneraWord.Click += new System.EventHandler(this.btGeneraWord_Click);
            // 
            // cbDipartimenti
            // 
            this.cbDipartimenti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDipartimenti.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDipartimenti.FormattingEnabled = true;
            this.cbDipartimenti.Location = new System.Drawing.Point(8, 11);
            this.cbDipartimenti.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDipartimenti.Name = "cbDipartimenti";
            this.cbDipartimenti.Size = new System.Drawing.Size(132, 27);
            this.cbDipartimenti.TabIndex = 1;
            this.cbDipartimenti.SelectedIndexChanged += new System.EventHandler(this.btCaricaDipartimento_Click_1);
            // 
            // btGeneraASsucc
            // 
            this.btGeneraASsucc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGeneraASsucc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGeneraASsucc.Location = new System.Drawing.Point(8, 47);
            this.btGeneraASsucc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btGeneraASsucc.Name = "btGeneraASsucc";
            this.btGeneraASsucc.OverrideDefault.Back.Color1 = System.Drawing.Color.Purple;
            this.btGeneraASsucc.OverrideDefault.Back.Color2 = System.Drawing.Color.BlueViolet;
            this.btGeneraASsucc.OverrideDefault.Back.ColorAngle = 45F;
            this.btGeneraASsucc.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btGeneraASsucc.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btGeneraASsucc.OverrideDefault.Border.ColorAngle = 45F;
            this.btGeneraASsucc.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraASsucc.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btGeneraASsucc.OverrideDefault.Border.Rounding = 20F;
            this.btGeneraASsucc.OverrideDefault.Border.Width = 1;
            this.btGeneraASsucc.Size = new System.Drawing.Size(105, 54);
            this.btGeneraASsucc.StateCommon.Back.Color1 = System.Drawing.Color.Purple;
            this.btGeneraASsucc.StateCommon.Back.Color2 = System.Drawing.Color.Fuchsia;
            this.btGeneraASsucc.StateCommon.Back.ColorAngle = 45F;
            this.btGeneraASsucc.StateCommon.Border.Color1 = System.Drawing.Color.MediumPurple;
            this.btGeneraASsucc.StateCommon.Border.Color2 = System.Drawing.Color.Plum;
            this.btGeneraASsucc.StateCommon.Border.ColorAngle = 45F;
            this.btGeneraASsucc.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraASsucc.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btGeneraASsucc.StateCommon.Border.Rounding = 20F;
            this.btGeneraASsucc.StateCommon.Border.Width = 1;
            this.btGeneraASsucc.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btGeneraASsucc.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btGeneraASsucc.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGeneraASsucc.StateNormal.Back.Color1 = System.Drawing.Color.DarkOrchid;
            this.btGeneraASsucc.StateNormal.Back.Color2 = System.Drawing.Color.Violet;
            this.btGeneraASsucc.StateNormal.Border.Color1 = System.Drawing.Color.Orchid;
            this.btGeneraASsucc.StateNormal.Border.Color2 = System.Drawing.Color.BlueViolet;
            this.btGeneraASsucc.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraASsucc.StatePressed.Back.Color1 = System.Drawing.Color.Purple;
            this.btGeneraASsucc.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btGeneraASsucc.StatePressed.Back.ColorAngle = 135F;
            this.btGeneraASsucc.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btGeneraASsucc.StatePressed.Border.Color2 = System.Drawing.Color.Purple;
            this.btGeneraASsucc.StatePressed.Border.ColorAngle = 135F;
            this.btGeneraASsucc.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraASsucc.StatePressed.Border.Rounding = 20F;
            this.btGeneraASsucc.StatePressed.Border.Width = 1;
            this.btGeneraASsucc.StateTracking.Back.Color1 = System.Drawing.Color.BlueViolet;
            this.btGeneraASsucc.StateTracking.Back.Color2 = System.Drawing.Color.Violet;
            this.btGeneraASsucc.StateTracking.Back.ColorAngle = 45F;
            this.btGeneraASsucc.StateTracking.Border.Color1 = System.Drawing.Color.MediumOrchid;
            this.btGeneraASsucc.StateTracking.Border.Color2 = System.Drawing.Color.Violet;
            this.btGeneraASsucc.StateTracking.Border.ColorAngle = 45F;
            this.btGeneraASsucc.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btGeneraASsucc.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btGeneraASsucc.StateTracking.Border.Rounding = 20F;
            this.btGeneraASsucc.StateTracking.Border.Width = 1;
            this.btGeneraASsucc.TabIndex = 51;
            this.btGeneraASsucc.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btGeneraASsucc.Values.Text = "  Genera\r\nann. succ.\r\n";
            this.btGeneraASsucc.Click += new System.EventHandler(this.btGeneraASsucc_Click);
            // 
            // cbAnniScolastici
            // 
            this.cbAnniScolastici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnniScolastici.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAnniScolastici.FormattingEnabled = true;
            this.cbAnniScolastici.Location = new System.Drawing.Point(148, 11);
            this.cbAnniScolastici.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAnniScolastici.Name = "cbAnniScolastici";
            this.cbAnniScolastici.Size = new System.Drawing.Size(71, 27);
            this.cbAnniScolastici.TabIndex = 2;
            this.cbAnniScolastici.SelectedIndexChanged += new System.EventHandler(this.cbAnniScolastici_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(1004, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 846);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // FrmCattedre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1540, 846);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlOreDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmCattedre";
            this.Tag = "header";
            this.Text = "Cattedre";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCattedre_Load);
            this.Shown += new System.EventHandler(this.FrmCattedre_Shown);
            this.pnlOreDoc.ResumeLayout(false);
            this.pnlOreDoc.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlCentrale.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlOreDoc;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlCentrale;
        private System.Windows.Forms.Panel pnlClassi;

        private System.Windows.Forms.ComboBox cbDipartimenti;
        private System.Windows.Forms.ComboBox cbAnniScolastici;
        private System.Windows.Forms.Label lblOreTot;
        private System.Windows.Forms.Label lblOrePot;
        private System.Windows.Forms.Label lblOreEff;
        private System.Windows.Forms.Label lblOreCattedra;
        private System.Windows.Forms.Label lblDocente;
        private Krypton.Toolkit.KryptonButton btGeneraASsucc;
        private Krypton.Toolkit.KryptonButton btGeneraWord;
        private System.Windows.Forms.Panel pnlDiscipline;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlDipartimento;
        private System.Windows.Forms.Splitter splitter1;
    }
}