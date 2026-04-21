namespace Cattedre
{
    partial class FrmDotazione
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbAnnoScolastico = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCattedreDiFatto = new System.Windows.Forms.NumericUpDown();
            this.nudCattedreDiDiritto = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAnnulla = new Krypton.Toolkit.KryptonButton();
            this.btSalva = new Krypton.Toolkit.KryptonButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCDC = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCattedreDiFatto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCattedreDiDiritto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "A.S.";
            // 
            // cbAnnoScolastico
            // 
            this.cbAnnoScolastico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnnoScolastico.FormattingEnabled = true;
            this.cbAnnoScolastico.Location = new System.Drawing.Point(173, 29);
            this.cbAnnoScolastico.Name = "cbAnnoScolastico";
            this.cbAnnoScolastico.Size = new System.Drawing.Size(121, 21);
            this.cbAnnoScolastico.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Num cattedre di fatto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Num cattedre di diritto:";
            // 
            // nudCattedreDiFatto
            // 
            this.nudCattedreDiFatto.Location = new System.Drawing.Point(174, 134);
            this.nudCattedreDiFatto.Name = "nudCattedreDiFatto";
            this.nudCattedreDiFatto.Size = new System.Drawing.Size(120, 20);
            this.nudCattedreDiFatto.TabIndex = 16;
            // 
            // nudCattedreDiDiritto
            // 
            this.nudCattedreDiDiritto.Location = new System.Drawing.Point(174, 172);
            this.nudCattedreDiDiritto.Name = "nudCattedreDiDiritto";
            this.nudCattedreDiDiritto.Size = new System.Drawing.Size(120, 20);
            this.nudCattedreDiDiritto.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btAnnulla);
            this.panel1.Controls.Add(this.btSalva);
            this.panel1.Location = new System.Drawing.Point(14, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 57);
            this.panel1.TabIndex = 28;
            // 
            // btAnnulla
            // 
            this.btAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btAnnulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnnulla.Location = new System.Drawing.Point(5, 13);
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
            this.btAnnulla.Size = new System.Drawing.Size(152, 32);
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
            this.btAnnulla.TabIndex = 4;
            this.btAnnulla.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btAnnulla.Values.Text = "Annulla";
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
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
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Classe di concorso:";
            // 
            // cbCDC
            // 
            this.cbCDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCDC.FormattingEnabled = true;
            this.cbCDC.Location = new System.Drawing.Point(173, 86);
            this.cbCDC.Name = "cbCDC";
            this.cbCDC.Size = new System.Drawing.Size(121, 21);
            this.cbCDC.TabIndex = 30;
            // 
            // FrmDotazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 324);
            this.Controls.Add(this.cbCDC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nudCattedreDiDiritto);
            this.Controls.Add(this.nudCattedreDiFatto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAnnoScolastico);
            this.Controls.Add(this.label2);
            this.Name = "FrmDotazione";
            this.Text = "Dotazione";
            this.Load += new System.EventHandler(this.FrmDotazione_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCattedreDiFatto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCattedreDiDiritto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAnnoScolastico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCattedreDiFatto;
        private System.Windows.Forms.NumericUpDown nudCattedreDiDiritto;
        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonButton btAnnulla;
        private Krypton.Toolkit.KryptonButton btSalva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCDC;
    }
}