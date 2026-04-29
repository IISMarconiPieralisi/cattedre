namespace Cattedre
{
    partial class FrmClasse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClasse));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAnno = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCoordinatore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIndirizzo = new System.Windows.Forms.ComboBox();
            this.cbClasseArticolataCon = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAnnoScolastico = new System.Windows.Forms.ComboBox();
            this.btSalva = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.mtbSezione = new Krypton.Toolkit.KryptonMaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnno)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Classe articolata con:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Sezione:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Anno:";
            // 
            // nudAnno
            // 
            this.nudAnno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAnno.Location = new System.Drawing.Point(165, 78);
            this.nudAnno.Margin = new System.Windows.Forms.Padding(4);
            this.nudAnno.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudAnno.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnno.Name = "nudAnno";
            this.nudAnno.Size = new System.Drawing.Size(79, 22);
            this.nudAnno.TabIndex = 0;
            this.nudAnno.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnno.ValueChanged += new System.EventHandler(this.nudAnno_ValueChanged);
            this.nudAnno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudAnno_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 392);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Coordinatore:";
            // 
            // cbCoordinatore
            // 
            this.cbCoordinatore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCoordinatore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoordinatore.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCoordinatore.FormattingEnabled = true;
            this.cbCoordinatore.Location = new System.Drawing.Point(166, 384);
            this.cbCoordinatore.Margin = new System.Windows.Forms.Padding(4);
            this.cbCoordinatore.Name = "cbCoordinatore";
            this.cbCoordinatore.Size = new System.Drawing.Size(221, 25);
            this.cbCoordinatore.TabIndex = 6;
            this.cbCoordinatore.DropDown += new System.EventHandler(this.cbCoordinatore_DropDown);
            this.cbCoordinatore.SelectedIndexChanged += new System.EventHandler(this.cbCoordinatore_SelectedIndexChanged);
            this.cbCoordinatore.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbCoordinatore_Format);
            this.cbCoordinatore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCoordinatore_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 330);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Indirizzo:";
            // 
            // cbIndirizzo
            // 
            this.cbIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIndirizzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndirizzo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIndirizzo.FormattingEnabled = true;
            this.cbIndirizzo.Location = new System.Drawing.Point(165, 322);
            this.cbIndirizzo.Margin = new System.Windows.Forms.Padding(4);
            this.cbIndirizzo.Name = "cbIndirizzo";
            this.cbIndirizzo.Size = new System.Drawing.Size(221, 25);
            this.cbIndirizzo.TabIndex = 4;
            this.cbIndirizzo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbIndirizzo_KeyDown);
            // 
            // cbClasseArticolataCon
            // 
            this.cbClasseArticolataCon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbClasseArticolataCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasseArticolataCon.Enabled = false;
            this.cbClasseArticolataCon.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClasseArticolataCon.FormattingEnabled = true;
            this.cbClasseArticolataCon.Location = new System.Drawing.Point(165, 260);
            this.cbClasseArticolataCon.Margin = new System.Windows.Forms.Padding(4);
            this.cbClasseArticolataCon.Name = "cbClasseArticolataCon";
            this.cbClasseArticolataCon.Size = new System.Drawing.Size(221, 25);
            this.cbClasseArticolataCon.TabIndex = 3;
            this.cbClasseArticolataCon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbClasseArticolataCon_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 205);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "Anno Scolastico:";
            // 
            // cbAnnoScolastico
            // 
            this.cbAnnoScolastico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAnnoScolastico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnnoScolastico.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAnnoScolastico.FormattingEnabled = true;
            this.cbAnnoScolastico.Location = new System.Drawing.Point(165, 198);
            this.cbAnnoScolastico.Margin = new System.Windows.Forms.Padding(4);
            this.cbAnnoScolastico.Name = "cbAnnoScolastico";
            this.cbAnnoScolastico.Size = new System.Drawing.Size(221, 25);
            this.cbAnnoScolastico.TabIndex = 2;
            this.cbAnnoScolastico.SelectedIndexChanged += new System.EventHandler(this.cbAnnoScolastico_SelectedIndexChanged);
            this.cbAnnoScolastico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAnnoScolastico_KeyDown);
            // 
            // btSalva
            // 
            this.btSalva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btSalva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalva.Location = new System.Drawing.Point(257, 438);
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
            this.btSalva.Size = new System.Drawing.Size(129, 33);
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
            this.btSalva.TabIndex = 42;
            this.btSalva.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btSalva.Values.Text = "Salva";
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonButton1.Location = new System.Drawing.Point(15, 438);
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
            this.kryptonButton1.Size = new System.Drawing.Size(127, 32);
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
            this.kryptonButton1.TabIndex = 43;
            this.kryptonButton1.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton1.Values.Text = "Annulla";
            this.kryptonButton1.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // mtbSezione
            // 
            this.mtbSezione.Location = new System.Drawing.Point(165, 137);
            this.mtbSezione.Mask = "AA";
            this.mtbSezione.Name = "mtbSezione";
            this.mtbSezione.Size = new System.Drawing.Size(79, 24);
            this.mtbSezione.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbSezione.TabIndex = 44;
            this.mtbSezione.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbSezione_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(214, 32);
            this.label10.TabIndex = 47;
            this.label10.Text = "Gestisci classe:";
            // 
            // FrmClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 487);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mtbSezione);
            this.Controls.Add(this.btSalva);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.cbAnnoScolastico);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbClasseArticolataCon);
            this.Controls.Add(this.cbIndirizzo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCoordinatore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudAnno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmClasse";
            this.Text = "Classe";
            this.Load += new System.EventHandler(this.FrmClasse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudAnno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCoordinatore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbIndirizzo;
        private System.Windows.Forms.ComboBox cbClasseArticolataCon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAnnoScolastico;
        private Krypton.Toolkit.KryptonButton btSalva;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonMaskedTextBox mtbSezione;
        private System.Windows.Forms.Label label10;
    }
}