namespace Cattedre
{
    partial class FrmCdCs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCdCs));
            this.lvCdCs = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAnnoScolastico = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCodice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAbilitazioniRichieste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumCattedreDiritto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumCattedreDiFatto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btInserisci = new Krypton.Toolkit.KryptonButton();
            this.kryptonButtonElimina = new Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btModifica = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // lvCdCs
            // 
            this.lvCdCs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCdCs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chAnnoScolastico,
            this.chCodice,
            this.chNome,
            this.chAbilitazioniRichieste,
            this.chNumCattedreDiritto,
            this.chNumCattedreDiFatto});
            this.lvCdCs.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCdCs.FullRowSelect = true;
            this.lvCdCs.HideSelection = false;
            this.lvCdCs.Location = new System.Drawing.Point(50, 45);
            this.lvCdCs.Margin = new System.Windows.Forms.Padding(2);
            this.lvCdCs.Name = "lvCdCs";
            this.lvCdCs.Size = new System.Drawing.Size(1380, 471);
            this.lvCdCs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCdCs.TabIndex = 1;
            this.lvCdCs.UseCompatibleStateImageBehavior = false;
            this.lvCdCs.View = System.Windows.Forms.View.Details;
            this.lvCdCs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvCdCs_KeyDown);
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 50;
            // 
            // chAnnoScolastico
            // 
            this.chAnnoScolastico.Text = "A.S.";
            // 
            // chCodice
            // 
            this.chCodice.Text = "Codice";
            this.chCodice.Width = 90;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 300;
            // 
            // chAbilitazioniRichieste
            // 
            this.chAbilitazioniRichieste.Text = "Abilitazioni Richieste";
            this.chAbilitazioniRichieste.Width = 650;
            // 
            // chNumCattedreDiritto
            // 
            this.chNumCattedreDiritto.Text = "Cattedre Di Diritto";
            this.chNumCattedreDiritto.Width = 120;
            // 
            // chNumCattedreDiFatto
            // 
            this.chNumCattedreDiFatto.Text = "Cattedre Di Fatto";
            this.chNumCattedreDiFatto.Width = 120;
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInserisci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btInserisci.Location = new System.Drawing.Point(1435, 73);
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
            this.btInserisci.TabIndex = 24;
            this.btInserisci.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btInserisci.Values.Text = "Inserisci";
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // kryptonButtonElimina
            // 
            this.kryptonButtonElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButtonElimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonButtonElimina.Location = new System.Drawing.Point(1435, 175);
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
            this.kryptonButtonElimina.Size = new System.Drawing.Size(109, 36);
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
            this.kryptonButtonElimina.TabIndex = 29;
            this.kryptonButtonElimina.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButtonElimina.Values.Text = "Elimina";
            this.kryptonButtonElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Classi di Concorso:";
            // 
            // btModifica
            // 
            this.btModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModifica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModifica.Location = new System.Drawing.Point(1435, 124);
            this.btModifica.Name = "btModifica";
            this.btModifica.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btModifica.OverrideDefault.Back.Color2 = System.Drawing.Color.Yellow;
            this.btModifica.OverrideDefault.Back.ColorAngle = 45F;
            this.btModifica.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btModifica.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btModifica.OverrideDefault.Border.ColorAngle = 45F;
            this.btModifica.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btModifica.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btModifica.OverrideDefault.Border.Rounding = 20F;
            this.btModifica.OverrideDefault.Border.Width = 1;
            this.btModifica.Size = new System.Drawing.Size(109, 36);
            this.btModifica.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btModifica.StateCommon.Back.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.btModifica.StateCommon.Back.ColorAngle = 45F;
            this.btModifica.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btModifica.StateCommon.Border.Color2 = System.Drawing.Color.DarkGoldenrod;
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
            this.btModifica.TabIndex = 34;
            this.btModifica.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btModifica.Values.Text = "Modifica";
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // FrmCdCs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1551, 555);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kryptonButtonElimina);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.lvCdCs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FrmCdCs";
            this.ShowInTaskbar = false;
            this.Text = "Classi di concorso";
            this.Load += new System.EventHandler(this.FrmCdCs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvCdCs;
        private System.Windows.Forms.ColumnHeader chCodice;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chAbilitazioniRichieste;
        private System.Windows.Forms.ColumnHeader chNumCattedreDiritto;
        private System.Windows.Forms.ColumnHeader chNumCattedreDiFatto;
        private System.Windows.Forms.ColumnHeader chAnnoScolastico;
        private System.Windows.Forms.ColumnHeader chID;
        private Krypton.Toolkit.KryptonButton btInserisci;
        private Krypton.Toolkit.KryptonButton kryptonButtonElimina;
        private System.Windows.Forms.Label label1;
        private Krypton.Toolkit.KryptonButton btModifica;
    }
}