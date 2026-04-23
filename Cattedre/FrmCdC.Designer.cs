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
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonButtonLogOut = new Krypton.Toolkit.KryptonButton();
            this.btSalva = new Krypton.Toolkit.KryptonButton();
            this.tbLivello = new Krypton.Toolkit.KryptonTextBox();
            this.tbNome = new Krypton.Toolkit.KryptonTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 125);
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
            this.label2.Location = new System.Drawing.Point(14, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Codice:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 69);
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
            this.rtbAbilitazioni.Location = new System.Drawing.Point(184, 123);
            this.rtbAbilitazioni.Margin = new System.Windows.Forms.Padding(2);
            this.rtbAbilitazioni.Name = "rtbAbilitazioni";
            this.rtbAbilitazioni.Size = new System.Drawing.Size(295, 84);
            this.rtbAbilitazioni.TabIndex = 2;
            this.rtbAbilitazioni.Text = "";
            this.rtbAbilitazioni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbAbilitazioni_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.kryptonButtonLogOut);
            this.panel1.Controls.Add(this.btSalva);
            this.panel1.Location = new System.Drawing.Point(12, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 57);
            this.panel1.TabIndex = 27;
            // 
            // kryptonButtonLogOut
            // 
            this.kryptonButtonLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonButtonLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonButtonLogOut.Location = new System.Drawing.Point(5, 13);
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
            this.kryptonButtonLogOut.TabIndex = 4;
            this.kryptonButtonLogOut.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButtonLogOut.Values.Text = "Annulla";
            this.kryptonButtonLogOut.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // btSalva
            // 
            this.btSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSalva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalva.Location = new System.Drawing.Point(310, 12);
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
            this.btSalva.TabIndex = 3;
            this.btSalva.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btSalva.Values.Text = "Salva";
            this.btSalva.Click += new System.EventHandler(this.btSava_Click);
            // 
            // tbLivello
            // 
            this.tbLivello.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLivello.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbLivello.Location = new System.Drawing.Point(184, 21);
            this.tbLivello.MaxLength = 8;
            this.tbLivello.Name = "tbLivello";
            this.tbLivello.Size = new System.Drawing.Size(292, 29);
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
            this.tbLivello.TabIndex = 0;
            this.tbLivello.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLivello_KeyDown);
            // 
            // tbNome
            // 
            this.tbNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNome.Location = new System.Drawing.Point(184, 68);
            this.tbNome.MaxLength = 150;
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(292, 29);
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
            this.tbNome.TabIndex = 1;
            this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
            // 
            // FrmCdC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(518, 299);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.tbLivello);
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbAbilitazioni;
        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonButton btSalva;
        private Krypton.Toolkit.KryptonButton kryptonButtonLogOut;
        private Krypton.Toolkit.KryptonTextBox tbLivello;
        private Krypton.Toolkit.KryptonTextBox tbNome;
    }
}