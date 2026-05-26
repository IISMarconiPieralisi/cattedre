namespace Cattedre
{
    partial class FrmCattedreUtente
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
            this.lvCattedreUtente = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClasse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDisciplina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOreSpeciali = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOreTot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cbAnniScolastici = new System.Windows.Forms.ComboBox();
            this.btElimina = new Krypton.Toolkit.KryptonButton();
            this.lblDocente = new System.Windows.Forms.Label();
            this.lblTotaleOre = new System.Windows.Forms.Label();
            this.lblOreTot = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvCattedreUtente
            // 
            this.lvCattedreUtente.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chClasse,
            this.chDisciplina,
            this.chOreSpeciali,
            this.chOre,
            this.chOreTot});
            this.lvCattedreUtente.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCattedreUtente.FullRowSelect = true;
            this.lvCattedreUtente.HideSelection = false;
            this.lvCattedreUtente.Location = new System.Drawing.Point(12, 85);
            this.lvCattedreUtente.Name = "lvCattedreUtente";
            this.lvCattedreUtente.Size = new System.Drawing.Size(406, 237);
            this.lvCattedreUtente.TabIndex = 0;
            this.lvCattedreUtente.UseCompatibleStateImageBehavior = false;
            this.lvCattedreUtente.View = System.Windows.Forms.View.Details;
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 36;
            // 
            // chClasse
            // 
            this.chClasse.Text = "Classe";
            // 
            // chDisciplina
            // 
            this.chDisciplina.Text = "Disciplina";
            this.chDisciplina.Width = 102;
            // 
            // chOreSpeciali
            // 
            this.chOreSpeciali.Text = "Ore Speciali";
            this.chOreSpeciali.Width = 71;
            // 
            // chOre
            // 
            this.chOre.Text = "Ore";
            this.chOre.Width = 73;
            // 
            // chOreTot
            // 
            this.chOreTot.Text = "Ore Tot";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Anno Scolastico:";
            // 
            // cbAnniScolastici
            // 
            this.cbAnniScolastici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnniScolastici.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAnniScolastici.FormattingEnabled = true;
            this.cbAnniScolastici.Location = new System.Drawing.Point(131, 26);
            this.cbAnniScolastici.Name = "cbAnniScolastici";
            this.cbAnniScolastici.Size = new System.Drawing.Size(60, 25);
            this.cbAnniScolastici.TabIndex = 3;
            this.cbAnniScolastici.SelectedIndexChanged += new System.EventHandler(this.cbAnniScolastici_SelectedIndexChanged);
            // 
            // btElimina
            // 
            this.btElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btElimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btElimina.Location = new System.Drawing.Point(428, 85);
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
            this.btElimina.TabIndex = 41;
            this.btElimina.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btElimina.Values.Text = "Elimina";
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // lblDocente
            // 
            this.lblDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocente.Location = new System.Drawing.Point(227, 29);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(190, 23);
            this.lblDocente.TabIndex = 42;
            this.lblDocente.Text = "label2";
            this.lblDocente.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotaleOre
            // 
            this.lblTotaleOre.AutoSize = true;
            this.lblTotaleOre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotaleOre.Location = new System.Drawing.Point(297, 332);
            this.lblTotaleOre.Name = "lblTotaleOre";
            this.lblTotaleOre.Size = new System.Drawing.Size(95, 20);
            this.lblTotaleOre.TabIndex = 43;
            this.lblTotaleOre.Text = "Totale ore:";
            // 
            // lblOreTot
            // 
            this.lblOreTot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOreTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreTot.Location = new System.Drawing.Point(387, 335);
            this.lblOreTot.Name = "lblOreTot";
            this.lblOreTot.Size = new System.Drawing.Size(30, 20);
            this.lblOreTot.TabIndex = 44;
            this.lblOreTot.Text = "00";
            this.lblOreTot.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmCattedreUtente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 361);
            this.Controls.Add(this.lblOreTot);
            this.Controls.Add(this.lblTotaleOre);
            this.Controls.Add(this.lblDocente);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.cbAnniScolastici);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCattedreUtente);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(565, 400);
            this.Name = "FrmCattedreUtente";
            this.Text = "Cattedre Utente";
            this.Load += new System.EventHandler(this.FrmCattedreUtente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvCattedreUtente;
        private System.Windows.Forms.ColumnHeader chClasse;
        private System.Windows.Forms.ColumnHeader chDisciplina;
        private System.Windows.Forms.ColumnHeader chOreSpeciali;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAnniScolastici;
        private System.Windows.Forms.ColumnHeader chOre;
        private System.Windows.Forms.ColumnHeader chOreTot;
        private System.Windows.Forms.ColumnHeader chID;
        private Krypton.Toolkit.KryptonButton btElimina;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.Label lblTotaleOre;
        private System.Windows.Forms.Label lblOreTot;
    }
}