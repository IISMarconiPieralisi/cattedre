namespace Cattedre
{
    partial class FrmDipartimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDipartimento));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCoordinatore = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSalvaDipartimento = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.tbNomeDipartimento = new Krypton.Toolkit.KryptonTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Coordinatore:";
            // 
            // cbCoordinatore
            // 
            this.cbCoordinatore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCoordinatore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoordinatore.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCoordinatore.FormattingEnabled = true;
            this.cbCoordinatore.Location = new System.Drawing.Point(118, 77);
            this.cbCoordinatore.Name = "cbCoordinatore";
            this.cbCoordinatore.Size = new System.Drawing.Size(173, 25);
            this.cbCoordinatore.TabIndex = 1;
            this.cbCoordinatore.SelectionChangeCommitted += new System.EventHandler(this.cbCoordinatore_SelectionChangeCommitted);
            this.cbCoordinatore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCoordinatore_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btSalvaDipartimento);
            this.panel1.Controls.Add(this.kryptonButton1);
            this.panel1.Location = new System.Drawing.Point(15, 145);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 62);
            this.panel1.TabIndex = 12;
            // 
            // btSalvaDipartimento
            // 
            this.btSalvaDipartimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btSalvaDipartimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalvaDipartimento.Location = new System.Drawing.Point(138, 16);
            this.btSalvaDipartimento.Name = "btSalvaDipartimento";
            this.btSalvaDipartimento.OverrideDefault.Back.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalvaDipartimento.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btSalvaDipartimento.OverrideDefault.Back.ColorAngle = 45F;
            this.btSalvaDipartimento.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btSalvaDipartimento.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btSalvaDipartimento.OverrideDefault.Border.ColorAngle = 45F;
            this.btSalvaDipartimento.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalvaDipartimento.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btSalvaDipartimento.OverrideDefault.Border.Rounding = 20F;
            this.btSalvaDipartimento.OverrideDefault.Border.Width = 1;
            this.btSalvaDipartimento.Size = new System.Drawing.Size(117, 33);
            this.btSalvaDipartimento.StateCommon.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.btSalvaDipartimento.StateCommon.Back.Color2 = System.Drawing.Color.YellowGreen;
            this.btSalvaDipartimento.StateCommon.Back.ColorAngle = 45F;
            this.btSalvaDipartimento.StateCommon.Border.Color1 = System.Drawing.Color.ForestGreen;
            this.btSalvaDipartimento.StateCommon.Border.Color2 = System.Drawing.Color.YellowGreen;
            this.btSalvaDipartimento.StateCommon.Border.ColorAngle = 45F;
            this.btSalvaDipartimento.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalvaDipartimento.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btSalvaDipartimento.StateCommon.Border.Rounding = 20F;
            this.btSalvaDipartimento.StateCommon.Border.Width = 1;
            this.btSalvaDipartimento.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btSalvaDipartimento.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btSalvaDipartimento.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvaDipartimento.StateNormal.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.btSalvaDipartimento.StateNormal.Back.Color2 = System.Drawing.Color.YellowGreen;
            this.btSalvaDipartimento.StateNormal.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalvaDipartimento.StateNormal.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalvaDipartimento.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalvaDipartimento.StatePressed.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.btSalvaDipartimento.StatePressed.Back.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalvaDipartimento.StatePressed.Back.ColorAngle = 135F;
            this.btSalvaDipartimento.StatePressed.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalvaDipartimento.StatePressed.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalvaDipartimento.StatePressed.Border.ColorAngle = 135F;
            this.btSalvaDipartimento.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalvaDipartimento.StatePressed.Border.Rounding = 20F;
            this.btSalvaDipartimento.StatePressed.Border.Width = 1;
            this.btSalvaDipartimento.StateTracking.Back.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalvaDipartimento.StateTracking.Back.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalvaDipartimento.StateTracking.Back.ColorAngle = 45F;
            this.btSalvaDipartimento.StateTracking.Border.Color1 = System.Drawing.Color.YellowGreen;
            this.btSalvaDipartimento.StateTracking.Border.Color2 = System.Drawing.Color.ForestGreen;
            this.btSalvaDipartimento.StateTracking.Border.ColorAngle = 45F;
            this.btSalvaDipartimento.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btSalvaDipartimento.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btSalvaDipartimento.StateTracking.Border.Rounding = 20F;
            this.btSalvaDipartimento.StateTracking.Border.Width = 1;
            this.btSalvaDipartimento.TabIndex = 2;
            this.btSalvaDipartimento.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btSalvaDipartimento.Values.Text = "Salva";
            this.btSalvaDipartimento.Click += new System.EventHandler(this.btSalvaDipartimento_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonButton1.Location = new System.Drawing.Point(10, 16);
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
            this.kryptonButton1.Size = new System.Drawing.Size(111, 32);
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
            this.kryptonButton1.TabIndex = 3;
            this.kryptonButton1.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton1.Values.Text = "Annulla";
            this.kryptonButton1.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbNomeDipartimento
            // 
            this.tbNomeDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNomeDipartimento.Location = new System.Drawing.Point(118, 12);
            this.tbNomeDipartimento.Name = "tbNomeDipartimento";
            this.tbNomeDipartimento.Size = new System.Drawing.Size(173, 29);
            this.tbNomeDipartimento.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbNomeDipartimento.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbNomeDipartimento.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbNomeDipartimento.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbNomeDipartimento.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbNomeDipartimento.StateCommon.Border.Rounding = 20F;
            this.tbNomeDipartimento.StateCommon.Border.Width = 1;
            this.tbNomeDipartimento.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.tbNomeDipartimento.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNomeDipartimento.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbNomeDipartimento.TabIndex = 0;
            this.tbNomeDipartimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNomeDipartimento_KeyDown);
            // 
            // FrmDipartimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 218);
            this.Controls.Add(this.tbNomeDipartimento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbCoordinatore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDipartimento";
            this.Text = "Dipartimento";
            this.Load += new System.EventHandler(this.FrmDipartimento_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCoordinatore;
        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonTextBox tbNomeDipartimento;
        private Krypton.Toolkit.KryptonButton btSalvaDipartimento;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}