namespace Cattedre
{
    partial class FrmIndirizzi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIndirizzi));
            this.lvIndirizzi = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonButtonModifica = new Krypton.Toolkit.KryptonButton();
            this.kryptonButtonElimina = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.tbRicerca = new Krypton.Toolkit.KryptonTextBox();
            this.btAnnulla = new Krypton.Toolkit.KryptonButton();
            this.btCerca = new Krypton.Toolkit.KryptonButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvIndirizzi
            // 
            this.lvIndirizzi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvIndirizzi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chNome});
            this.lvIndirizzi.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvIndirizzi.FullRowSelect = true;
            this.lvIndirizzi.HideSelection = false;
            this.lvIndirizzi.Location = new System.Drawing.Point(41, 95);
            this.lvIndirizzi.Name = "lvIndirizzi";
            this.lvIndirizzi.Size = new System.Drawing.Size(807, 314);
            this.lvIndirizzi.TabIndex = 14;
            this.lvIndirizzi.UseCompatibleStateImageBehavior = false;
            this.lvIndirizzi.View = System.Windows.Forms.View.Details;
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 50;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 184;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nome:";
            // 
            // kryptonButtonModifica
            // 
            this.kryptonButtonModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButtonModifica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonButtonModifica.Location = new System.Drawing.Point(854, 170);
            this.kryptonButtonModifica.Name = "kryptonButtonModifica";
            this.kryptonButtonModifica.OverrideDefault.Back.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButtonModifica.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.kryptonButtonModifica.OverrideDefault.Back.ColorAngle = 45F;
            this.kryptonButtonModifica.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonModifica.OverrideDefault.Border.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonModifica.OverrideDefault.Border.ColorAngle = 45F;
            this.kryptonButtonModifica.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonModifica.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButtonModifica.OverrideDefault.Border.Rounding = 20F;
            this.kryptonButtonModifica.OverrideDefault.Border.Width = 1;
            this.kryptonButtonModifica.Size = new System.Drawing.Size(94, 36);
            this.kryptonButtonModifica.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonModifica.StateCommon.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonModifica.StateCommon.Back.ColorAngle = 45F;
            this.kryptonButtonModifica.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonModifica.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonModifica.StateCommon.Border.ColorAngle = 45F;
            this.kryptonButtonModifica.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonModifica.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButtonModifica.StateCommon.Border.Rounding = 20F;
            this.kryptonButtonModifica.StateCommon.Border.Width = 1;
            this.kryptonButtonModifica.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButtonModifica.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButtonModifica.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonModifica.StateNormal.Back.Color1 = System.Drawing.Color.Orange;
            this.kryptonButtonModifica.StateNormal.Back.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.kryptonButtonModifica.StateNormal.Border.Color1 = System.Drawing.Color.Orange;
            this.kryptonButtonModifica.StateNormal.Border.Color2 = System.Drawing.Color.DarkOrange;
            this.kryptonButtonModifica.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonModifica.StatePressed.Back.Color1 = System.Drawing.Color.Orange;
            this.kryptonButtonModifica.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.kryptonButtonModifica.StatePressed.Back.ColorAngle = 135F;
            this.kryptonButtonModifica.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.kryptonButtonModifica.StatePressed.Border.Color2 = System.Drawing.Color.DarkOrange;
            this.kryptonButtonModifica.StatePressed.Border.ColorAngle = 135F;
            this.kryptonButtonModifica.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonModifica.StatePressed.Border.Rounding = 20F;
            this.kryptonButtonModifica.StatePressed.Border.Width = 1;
            this.kryptonButtonModifica.StateTracking.Back.Color1 = System.Drawing.Color.Orange;
            this.kryptonButtonModifica.StateTracking.Back.Color2 = System.Drawing.Color.DarkOrange;
            this.kryptonButtonModifica.StateTracking.Back.ColorAngle = 45F;
            this.kryptonButtonModifica.StateTracking.Border.Color1 = System.Drawing.Color.DarkOrange;
            this.kryptonButtonModifica.StateTracking.Border.Color2 = System.Drawing.Color.Orange;
            this.kryptonButtonModifica.StateTracking.Border.ColorAngle = 45F;
            this.kryptonButtonModifica.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonModifica.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButtonModifica.StateTracking.Border.Rounding = 20F;
            this.kryptonButtonModifica.StateTracking.Border.Width = 1;
            this.kryptonButtonModifica.TabIndex = 33;
            this.kryptonButtonModifica.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButtonModifica.Values.Text = "Modifica";
            this.kryptonButtonModifica.Click += new System.EventHandler(this.brModifica_Click);
            // 
            // kryptonButtonElimina
            // 
            this.kryptonButtonElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButtonElimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonButtonElimina.Location = new System.Drawing.Point(854, 221);
            this.kryptonButtonElimina.Name = "kryptonButtonElimina";
            this.kryptonButtonElimina.OverrideDefault.Back.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButtonElimina.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.OverrideDefault.Back.ColorAngle = 45F;
            this.kryptonButtonElimina.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.OverrideDefault.Border.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonElimina.OverrideDefault.Border.ColorAngle = 45F;
            this.kryptonButtonElimina.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonElimina.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButtonElimina.OverrideDefault.Border.Rounding = 20F;
            this.kryptonButtonElimina.OverrideDefault.Border.Width = 1;
            this.kryptonButtonElimina.Size = new System.Drawing.Size(94, 36);
            this.kryptonButtonElimina.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.StateCommon.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonElimina.StateCommon.Back.ColorAngle = 45F;
            this.kryptonButtonElimina.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonElimina.StateCommon.Border.ColorAngle = 45F;
            this.kryptonButtonElimina.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonElimina.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButtonElimina.StateCommon.Border.Rounding = 20F;
            this.kryptonButtonElimina.StateCommon.Border.Width = 1;
            this.kryptonButtonElimina.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButtonElimina.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButtonElimina.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonElimina.StateNormal.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.StateNormal.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonElimina.StateNormal.Border.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButtonElimina.StateNormal.Border.Color2 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonElimina.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.kryptonButtonElimina.StatePressed.Back.ColorAngle = 135F;
            this.kryptonButtonElimina.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.kryptonButtonElimina.StatePressed.Border.Color2 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.StatePressed.Border.ColorAngle = 135F;
            this.kryptonButtonElimina.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonElimina.StatePressed.Border.Rounding = 20F;
            this.kryptonButtonElimina.StatePressed.Border.Width = 1;
            this.kryptonButtonElimina.StateTracking.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.StateTracking.Back.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButtonElimina.StateTracking.Back.ColorAngle = 45F;
            this.kryptonButtonElimina.StateTracking.Border.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButtonElimina.StateTracking.Border.Color2 = System.Drawing.Color.Red;
            this.kryptonButtonElimina.StateTracking.Border.ColorAngle = 45F;
            this.kryptonButtonElimina.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButtonElimina.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButtonElimina.StateTracking.Border.Rounding = 20F;
            this.kryptonButtonElimina.StateTracking.Border.Width = 1;
            this.kryptonButtonElimina.TabIndex = 32;
            this.kryptonButtonElimina.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButtonElimina.Values.Text = "Elimina";
            this.kryptonButtonElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonButton1.Location = new System.Drawing.Point(854, 119);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.OverrideDefault.Back.Color1 = System.Drawing.Color.YellowGreen;
            this.kryptonButton1.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.kryptonButton1.OverrideDefault.Back.ColorAngle = 45F;
            this.kryptonButton1.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.kryptonButton1.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.kryptonButton1.OverrideDefault.Border.ColorAngle = 45F;
            this.kryptonButton1.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButton1.OverrideDefault.Border.Rounding = 20F;
            this.kryptonButton1.OverrideDefault.Border.Width = 1;
            this.kryptonButton1.Size = new System.Drawing.Size(94, 36);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.YellowGreen;
            this.kryptonButton1.StateCommon.Back.ColorAngle = 45F;
            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.ForestGreen;
            this.kryptonButton1.StateCommon.Border.Color2 = System.Drawing.Color.YellowGreen;
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
            this.kryptonButton1.StateNormal.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.kryptonButton1.StateNormal.Back.Color2 = System.Drawing.Color.YellowGreen;
            this.kryptonButton1.StateNormal.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.kryptonButton1.StateNormal.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.kryptonButton1.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StatePressed.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.kryptonButton1.StatePressed.Back.Color2 = System.Drawing.Color.ForestGreen;
            this.kryptonButton1.StatePressed.Back.ColorAngle = 135F;
            this.kryptonButton1.StatePressed.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.kryptonButton1.StatePressed.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.kryptonButton1.StatePressed.Border.ColorAngle = 135F;
            this.kryptonButton1.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StatePressed.Border.Rounding = 20F;
            this.kryptonButton1.StatePressed.Border.Width = 1;
            this.kryptonButton1.StateTracking.Back.Color1 = System.Drawing.Color.YellowGreen;
            this.kryptonButton1.StateTracking.Back.Color2 = System.Drawing.Color.ForestGreen;
            this.kryptonButton1.StateTracking.Back.ColorAngle = 45F;
            this.kryptonButton1.StateTracking.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.kryptonButton1.StateTracking.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.kryptonButton1.StateTracking.Border.ColorAngle = 45F;
            this.kryptonButton1.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonButton1.StateTracking.Border.Rounding = 20F;
            this.kryptonButton1.StateTracking.Border.Width = 1;
            this.kryptonButton1.TabIndex = 31;
            this.kryptonButton1.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton1.Values.Text = "Inserisci";
            this.kryptonButton1.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // tbRicerca
            // 
            this.tbRicerca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRicerca.Location = new System.Drawing.Point(104, 45);
            this.tbRicerca.Name = "tbRicerca";
            this.tbRicerca.Size = new System.Drawing.Size(357, 29);
            this.tbRicerca.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbRicerca.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbRicerca.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbRicerca.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbRicerca.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbRicerca.StateCommon.Border.Rounding = 20F;
            this.tbRicerca.StateCommon.Border.Width = 1;
            this.tbRicerca.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.tbRicerca.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRicerca.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbRicerca.TabIndex = 34;
            this.tbRicerca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRicerca_KeyDown);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAnnulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnnulla.Location = new System.Drawing.Point(467, 42);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.OverrideDefault.Back.Color1 = System.Drawing.Color.DarkRed;
            this.btAnnulla.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.btAnnulla.OverrideDefault.Back.ColorAngle = 45F;
            this.btAnnulla.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.btAnnulla.OverrideDefault.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnulla.OverrideDefault.Border.ColorAngle = 45F;
            this.btAnnulla.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnulla.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btAnnulla.OverrideDefault.Border.Rounding = 20F;
            this.btAnnulla.OverrideDefault.Border.Width = 1;
            this.btAnnulla.Size = new System.Drawing.Size(94, 32);
            this.btAnnulla.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.btAnnulla.StateCommon.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnulla.StateCommon.Back.ColorAngle = 45F;
            this.btAnnulla.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.btAnnulla.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnulla.StateCommon.Border.ColorAngle = 45F;
            this.btAnnulla.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnulla.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btAnnulla.StateCommon.Border.Rounding = 20F;
            this.btAnnulla.StateCommon.Border.Width = 1;
            this.btAnnulla.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btAnnulla.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btAnnulla.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAnnulla.StateNormal.Back.Color1 = System.Drawing.Color.Red;
            this.btAnnulla.StateNormal.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnulla.StateNormal.Border.Color1 = System.Drawing.Color.DarkRed;
            this.btAnnulla.StateNormal.Border.Color2 = System.Drawing.Color.Red;
            this.btAnnulla.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnulla.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.btAnnulla.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.btAnnulla.StatePressed.Back.ColorAngle = 135F;
            this.btAnnulla.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.btAnnulla.StatePressed.Border.Color2 = System.Drawing.Color.Red;
            this.btAnnulla.StatePressed.Border.ColorAngle = 135F;
            this.btAnnulla.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnulla.StatePressed.Border.Rounding = 20F;
            this.btAnnulla.StatePressed.Border.Width = 1;
            this.btAnnulla.StateTracking.Back.Color1 = System.Drawing.Color.Red;
            this.btAnnulla.StateTracking.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnulla.StateTracking.Back.ColorAngle = 45F;
            this.btAnnulla.StateTracking.Border.Color1 = System.Drawing.Color.DarkRed;
            this.btAnnulla.StateTracking.Border.Color2 = System.Drawing.Color.Red;
            this.btAnnulla.StateTracking.Border.ColorAngle = 45F;
            this.btAnnulla.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnulla.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btAnnulla.StateTracking.Border.Rounding = 20F;
            this.btAnnulla.StateTracking.Border.Width = 1;
            this.btAnnulla.TabIndex = 35;
            this.btAnnulla.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btAnnulla.Values.Text = "Annulla";
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // btCerca
            // 
            this.btCerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCerca.Location = new System.Drawing.Point(854, 48);
            this.btCerca.Name = "btCerca";
            this.btCerca.OverrideDefault.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btCerca.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btCerca.OverrideDefault.Back.ColorAngle = 45F;
            this.btCerca.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btCerca.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btCerca.OverrideDefault.Border.ColorAngle = 45F;
            this.btCerca.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btCerca.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btCerca.OverrideDefault.Border.Rounding = 20F;
            this.btCerca.OverrideDefault.Border.Width = 1;
            this.btCerca.Size = new System.Drawing.Size(94, 32);
            this.btCerca.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StateCommon.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StateCommon.Back.ColorAngle = 45F;
            this.btCerca.StateCommon.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StateCommon.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StateCommon.Border.ColorAngle = 45F;
            this.btCerca.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btCerca.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btCerca.StateCommon.Border.Rounding = 20F;
            this.btCerca.StateCommon.Border.Width = 1;
            this.btCerca.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btCerca.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btCerca.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerca.StateNormal.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btCerca.StateNormal.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StateNormal.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btCerca.StatePressed.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btCerca.StatePressed.Back.ColorAngle = 135F;
            this.btCerca.StatePressed.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StatePressed.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btCerca.StatePressed.Border.ColorAngle = 135F;
            this.btCerca.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btCerca.StatePressed.Border.Rounding = 20F;
            this.btCerca.StatePressed.Border.Width = 1;
            this.btCerca.StateTracking.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btCerca.StateTracking.Back.ColorAngle = 45F;
            this.btCerca.StateTracking.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btCerca.StateTracking.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.btCerca.StateTracking.Border.ColorAngle = 45F;
            this.btCerca.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btCerca.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btCerca.StateTracking.Border.Rounding = 20F;
            this.btCerca.StateTracking.Border.Width = 1;
            this.btCerca.TabIndex = 36;
            this.btCerca.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btCerca.Values.Text = "Cerca";
            this.btCerca.Click += new System.EventHandler(this.btCerca_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 37;
            this.label2.Text = "Indirizzi:";
            // 
            // FrmIndirizzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 467);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCerca);
            this.Controls.Add(this.btAnnulla);
            this.Controls.Add(this.tbRicerca);
            this.Controls.Add(this.kryptonButtonModifica);
            this.Controls.Add(this.kryptonButtonElimina);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvIndirizzi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmIndirizzi";
            this.ShowInTaskbar = false;
            this.Text = "Indirizzi";
            this.Load += new System.EventHandler(this.FrmIndirizzi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvIndirizzi;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader chID;
        private Krypton.Toolkit.KryptonButton kryptonButtonModifica;
        private Krypton.Toolkit.KryptonButton kryptonButtonElimina;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonTextBox tbRicerca;
        private Krypton.Toolkit.KryptonButton btAnnulla;
        private Krypton.Toolkit.KryptonButton btCerca;
        private System.Windows.Forms.Label label2;
    }
}