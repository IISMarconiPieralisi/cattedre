namespace Cattedre
{
    partial class FrmAnnoScolastico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnnoScolastico));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbSigla = new System.Windows.Forms.MaskedTextBox();
            this.dtpDataInizio = new System.Windows.Forms.DateTimePicker();
            this.dtpDataFine = new System.Windows.Forms.DateTimePicker();
            this.btAnnulla = new Krypton.Toolkit.KryptonButton();
            this.btSalva = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sigla:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data inizio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data fine:";
            // 
            // mtbSigla
            // 
            this.mtbSigla.Enabled = false;
            this.mtbSigla.Location = new System.Drawing.Point(108, 115);
            this.mtbSigla.Mask = "00-00";
            this.mtbSigla.Name = "mtbSigla";
            this.mtbSigla.Size = new System.Drawing.Size(40, 20);
            this.mtbSigla.TabIndex = 2;
            this.mtbSigla.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbSigla_MaskInputRejected);
            // 
            // dtpDataInizio
            // 
            this.dtpDataInizio.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataInizio.Location = new System.Drawing.Point(108, 21);
            this.dtpDataInizio.Name = "dtpDataInizio";
            this.dtpDataInizio.Size = new System.Drawing.Size(200, 22);
            this.dtpDataInizio.TabIndex = 0;
            this.dtpDataInizio.ValueChanged += new System.EventHandler(this.dtpDataInizio_ValueChanged);
            this.dtpDataInizio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDataInizio_KeyDown);
            // 
            // dtpDataFine
            // 
            this.dtpDataFine.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataFine.Location = new System.Drawing.Point(108, 69);
            this.dtpDataFine.Name = "dtpDataFine";
            this.dtpDataFine.Size = new System.Drawing.Size(200, 22);
            this.dtpDataFine.TabIndex = 1;
            this.dtpDataFine.ValueChanged += new System.EventHandler(this.dtpDataFine_ValueChanged);
            this.dtpDataFine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDataFine_KeyDown);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btAnnulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnnulla.Location = new System.Drawing.Point(15, 180);
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
            this.btAnnulla.Size = new System.Drawing.Size(111, 32);
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
            this.btSalva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btSalva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalva.Location = new System.Drawing.Point(191, 181);
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
            this.btSalva.Size = new System.Drawing.Size(117, 33);
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
            // FrmAnnoScolastico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 224);
            this.Controls.Add(this.btAnnulla);
            this.Controls.Add(this.btSalva);
            this.Controls.Add(this.dtpDataFine);
            this.Controls.Add(this.dtpDataInizio);
            this.Controls.Add(this.mtbSigla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAnnoScolastico";
            this.Text = "Anno Scolastico";
            this.Load += new System.EventHandler(this.FrmAnnoScolastico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbSigla;
        private System.Windows.Forms.DateTimePicker dtpDataInizio;
        private System.Windows.Forms.DateTimePicker dtpDataFine;
        private Krypton.Toolkit.KryptonButton btAnnulla;
        private Krypton.Toolkit.KryptonButton btSalva;
    }
}