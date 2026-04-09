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
            this.kryptonButtonLogOut = new Krypton.Toolkit.KryptonButton();
            this.btSalva = new Krypton.Toolkit.KryptonButton();
            this.tbLivello = new Krypton.Toolkit.KryptonTextBox();
            this.tbNome = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreDiritto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCattedreFatto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Abilitazioni richeste:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Livello:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome:";
            // 
            // rtbAbilitazioni
            // 
            this.rtbAbilitazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAbilitazioni.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAbilitazioni.Location = new System.Drawing.Point(140, 142);
            this.rtbAbilitazioni.Margin = new System.Windows.Forms.Padding(2);
            this.rtbAbilitazioni.Name = "rtbAbilitazioni";
            this.rtbAbilitazioni.Size = new System.Drawing.Size(370, 84);
            this.rtbAbilitazioni.TabIndex = 4;
            this.rtbAbilitazioni.Text = "";
            this.rtbAbilitazioni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbAbilitazioni_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Num cattedre di diritto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Num cattedre di fatto:";
            // 
            // nudNumCattedreDiritto
            // 
            this.nudNumCattedreDiritto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudNumCattedreDiritto.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumCattedreDiritto.Location = new System.Drawing.Point(184, 250);
            this.nudNumCattedreDiritto.Name = "nudNumCattedreDiritto";
            this.nudNumCattedreDiritto.Size = new System.Drawing.Size(37, 21);
            this.nudNumCattedreDiritto.TabIndex = 5;
            this.nudNumCattedreDiritto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudNumCattedreDiritto_KeyDown);
            // 
            // nudNumCattedreFatto
            // 
            this.nudNumCattedreFatto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudNumCattedreFatto.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumCattedreFatto.Location = new System.Drawing.Point(184, 293);
            this.nudNumCattedreFatto.Name = "nudNumCattedreFatto";
            this.nudNumCattedreFatto.Size = new System.Drawing.Size(37, 21);
            this.nudNumCattedreFatto.TabIndex = 6;
            this.nudNumCattedreFatto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudNumCattedreFatto_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "A.S.:";
            // 
            // cbAnnoScolastico
            // 
            this.cbAnnoScolastico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAnnoScolastico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnnoScolastico.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAnnoScolastico.FormattingEnabled = true;
            this.cbAnnoScolastico.Location = new System.Drawing.Point(80, 18);
            this.cbAnnoScolastico.Name = "cbAnnoScolastico";
            this.cbAnnoScolastico.Size = new System.Drawing.Size(110, 24);
            this.cbAnnoScolastico.TabIndex = 1;
            this.cbAnnoScolastico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAnnoScolastico_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.kryptonButtonLogOut);
            this.panel1.Controls.Add(this.btSalva);
            this.panel1.Location = new System.Drawing.Point(12, 346);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 57);
            this.panel1.TabIndex = 27;
            // 
            // kryptonButtonLogOut
            // 
            this.kryptonButtonLogOut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.kryptonButtonLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonButtonLogOut.Location = new System.Drawing.Point(78, 13);
            this.kryptonButtonLogOut.Name = "kryptonButtonLogOut";
            this.kryptonButtonLogOut.OverrideDefault.Back.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButtonLogOut.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.OverrideDefault.Back.ColorAngle = 45F;
            this.kryptonButtonLogOut.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.OverrideDefault.Border.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonLogOut.OverrideDefault.Border.ColorAngle = 45F;
            this.kryptonButtonLogOut.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonLogOut.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButtonLogOut.OverrideDefault.Border.Rounding = 20F;
            this.kryptonButtonLogOut.OverrideDefault.Border.Width = 1;
            this.kryptonButtonLogOut.Size = new System.Drawing.Size(152, 32);
            this.kryptonButtonLogOut.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.StateCommon.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonLogOut.StateCommon.Back.ColorAngle = 45F;
            this.kryptonButtonLogOut.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonLogOut.StateCommon.Border.ColorAngle = 45F;
            this.kryptonButtonLogOut.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonLogOut.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButtonLogOut.StateCommon.Border.Rounding = 20F;
            this.kryptonButtonLogOut.StateCommon.Border.Width = 1;
            this.kryptonButtonLogOut.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButtonLogOut.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButtonLogOut.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonLogOut.StateNormal.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.StateNormal.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonLogOut.StateNormal.Border.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButtonLogOut.StateNormal.Border.Color2 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonLogOut.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.kryptonButtonLogOut.StatePressed.Back.ColorAngle = 135F;
            this.kryptonButtonLogOut.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.kryptonButtonLogOut.StatePressed.Border.Color2 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.StatePressed.Border.ColorAngle = 135F;
            this.kryptonButtonLogOut.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonLogOut.StatePressed.Border.Rounding = 20F;
            this.kryptonButtonLogOut.StatePressed.Border.Width = 1;
            this.kryptonButtonLogOut.StateTracking.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.StateTracking.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonLogOut.StateTracking.Back.ColorAngle = 45F;
            this.kryptonButtonLogOut.StateTracking.Border.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButtonLogOut.StateTracking.Border.Color2 = System.Drawing.Color.Red;
            this.kryptonButtonLogOut.StateTracking.Border.ColorAngle = 45F;
            this.kryptonButtonLogOut.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonLogOut.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButtonLogOut.StateTracking.Border.Rounding = 20F;
            this.kryptonButtonLogOut.StateTracking.Border.Width = 1;
            this.kryptonButtonLogOut.TabIndex = 28;
            this.kryptonButtonLogOut.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButtonLogOut.Values.Text = "Annulla";
            this.kryptonButtonLogOut.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // btSalva
            // 
            this.btSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSalva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalva.Location = new System.Drawing.Point(266, 12);
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
            this.btSalva.Size = new System.Drawing.Size(154, 33);
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
            this.btSalva.TabIndex = 23;
            this.btSalva.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btSalva.Values.Text = "Salva";
            this.btSalva.Click += new System.EventHandler(this.btSava_Click);
            // 
            // tbLivello
            // 
            this.tbLivello.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLivello.Location = new System.Drawing.Point(80, 62);
            this.tbLivello.Name = "tbLivello";
            this.tbLivello.Size = new System.Drawing.Size(132, 29);
            this.tbLivello.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbLivello.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbLivello.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbLivello.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbLivello.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbLivello.StateCommon.Border.Rounding = 20F;
            this.tbLivello.StateCommon.Border.Width = 1;
            this.tbLivello.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.tbLivello.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLivello.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbLivello.TabIndex = 28;
            // 
            // tbNome
            // 
            this.tbNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNome.Location = new System.Drawing.Point(80, 105);
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
            this.tbNome.TabIndex = 29;
            // 
            // FrmCdC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(523, 415);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.tbLivello);
            this.Controls.Add(this.cbAnnoScolastico);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudNumCattedreFatto);
            this.Controls.Add(this.nudNumCattedreDiritto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbAbilitazioni);
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
        private Krypton.Toolkit.KryptonButton btSalva;
        private Krypton.Toolkit.KryptonButton kryptonButtonLogOut;
        private Krypton.Toolkit.KryptonTextBox tbLivello;
        private Krypton.Toolkit.KryptonTextBox tbNome;
    }
}