namespace Cattedre
{
    partial class FrmDisciplina
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisciplina));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudOreTeoria = new System.Windows.Forms.NumericUpDown();
            this.nudOreLab = new System.Windows.Forms.NumericUpDown();
            this.pnRB = new System.Windows.Forms.Panel();
            this.rbQuinto = new System.Windows.Forms.RadioButton();
            this.rbQuarto = new System.Windows.Forms.RadioButton();
            this.rbTerzo = new System.Windows.Forms.RadioButton();
            this.rbSecondo = new System.Windows.Forms.RadioButton();
            this.rbPrimo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDisciplinaSucessiva = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAnnoSuc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAnnulla = new Krypton.Toolkit.KryptonButton();
            this.btSalva = new Krypton.Toolkit.KryptonButton();
            this.tbNome = new Krypton.Toolkit.KryptonTextBox();
            this.tbDisciplinaSpeciale = new Krypton.Toolkit.KryptonTextBox();
            this.cbDisciplinaSpeciale = new Krypton.Toolkit.KryptonCheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnDisciplina = new System.Windows.Forms.Panel();
            this.cbAnnoFine = new System.Windows.Forms.ComboBox();
            this.cbAnnoInizio = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clbCdcs = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.clbIndirizzi = new System.Windows.Forms.CheckedListBox();
            this.clbDipartimenti = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.frmDisciplinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudOreTeoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOreLab)).BeginInit();
            this.pnRB.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnDisciplina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frmDisciplinaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Anno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(339, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ore laboratorio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ore teoria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome:";
            // 
            // nudOreTeoria
            // 
            this.nudOreTeoria.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudOreTeoria.Location = new System.Drawing.Point(205, 124);
            this.nudOreTeoria.Margin = new System.Windows.Forms.Padding(4);
            this.nudOreTeoria.Name = "nudOreTeoria";
            this.nudOreTeoria.Size = new System.Drawing.Size(112, 23);
            this.nudOreTeoria.TabIndex = 1;
            this.nudOreTeoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudOreTeoria_KeyDown);
            // 
            // nudOreLab
            // 
            this.nudOreLab.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudOreLab.Location = new System.Drawing.Point(467, 124);
            this.nudOreLab.Margin = new System.Windows.Forms.Padding(4);
            this.nudOreLab.Name = "nudOreLab";
            this.nudOreLab.Size = new System.Drawing.Size(104, 23);
            this.nudOreLab.TabIndex = 2;
            this.nudOreLab.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudOreLab_KeyDown);
            // 
            // pnRB
            // 
            this.pnRB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnRB.Controls.Add(this.rbQuinto);
            this.pnRB.Controls.Add(this.rbQuarto);
            this.pnRB.Controls.Add(this.rbTerzo);
            this.pnRB.Controls.Add(this.rbSecondo);
            this.pnRB.Controls.Add(this.rbPrimo);
            this.pnRB.Location = new System.Drawing.Point(205, 209);
            this.pnRB.Margin = new System.Windows.Forms.Padding(4);
            this.pnRB.Name = "pnRB";
            this.pnRB.Size = new System.Drawing.Size(366, 44);
            this.pnRB.TabIndex = 4;
            // 
            // rbQuinto
            // 
            this.rbQuinto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbQuinto.AutoSize = true;
            this.rbQuinto.Location = new System.Drawing.Point(310, 13);
            this.rbQuinto.Margin = new System.Windows.Forms.Padding(4);
            this.rbQuinto.Name = "rbQuinto";
            this.rbQuinto.Size = new System.Drawing.Size(38, 21);
            this.rbQuinto.TabIndex = 7;
            this.rbQuinto.TabStop = true;
            this.rbQuinto.Text = "5°";
            this.rbQuinto.UseVisualStyleBackColor = true;
            this.rbQuinto.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            this.rbQuinto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnno_KeyDown);
            // 
            // rbQuarto
            // 
            this.rbQuarto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbQuarto.AutoSize = true;
            this.rbQuarto.Location = new System.Drawing.Point(243, 13);
            this.rbQuarto.Margin = new System.Windows.Forms.Padding(4);
            this.rbQuarto.Name = "rbQuarto";
            this.rbQuarto.Size = new System.Drawing.Size(38, 21);
            this.rbQuarto.TabIndex = 6;
            this.rbQuarto.TabStop = true;
            this.rbQuarto.Text = "4°";
            this.rbQuarto.UseVisualStyleBackColor = true;
            this.rbQuarto.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            this.rbQuarto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnno_KeyDown);
            // 
            // rbTerzo
            // 
            this.rbTerzo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.rbTerzo.AutoSize = true;
            this.rbTerzo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTerzo.Location = new System.Drawing.Point(161, 13);
            this.rbTerzo.Margin = new System.Windows.Forms.Padding(4);
            this.rbTerzo.Name = "rbTerzo";
            this.rbTerzo.Size = new System.Drawing.Size(38, 21);
            this.rbTerzo.TabIndex = 5;
            this.rbTerzo.TabStop = true;
            this.rbTerzo.Text = "3°";
            this.rbTerzo.UseVisualStyleBackColor = true;
            this.rbTerzo.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            this.rbTerzo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnno_KeyDown);
            // 
            // rbSecondo
            // 
            this.rbSecondo.AutoSize = true;
            this.rbSecondo.Location = new System.Drawing.Point(78, 13);
            this.rbSecondo.Margin = new System.Windows.Forms.Padding(4);
            this.rbSecondo.Name = "rbSecondo";
            this.rbSecondo.Size = new System.Drawing.Size(38, 21);
            this.rbSecondo.TabIndex = 4;
            this.rbSecondo.TabStop = true;
            this.rbSecondo.Text = "2°";
            this.rbSecondo.UseVisualStyleBackColor = true;
            this.rbSecondo.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            this.rbSecondo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnno_KeyDown);
            // 
            // rbPrimo
            // 
            this.rbPrimo.AutoSize = true;
            this.rbPrimo.Location = new System.Drawing.Point(11, 13);
            this.rbPrimo.Margin = new System.Windows.Forms.Padding(4);
            this.rbPrimo.Name = "rbPrimo";
            this.rbPrimo.Size = new System.Drawing.Size(38, 21);
            this.rbPrimo.TabIndex = 3;
            this.rbPrimo.TabStop = true;
            this.rbPrimo.Text = "1°";
            this.rbPrimo.UseVisualStyleBackColor = true;
            this.rbPrimo.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            this.rbPrimo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAnno_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 678);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 17);
            this.label8.TabIndex = 36;
            this.label8.Text = "Disciplina successiva: ";
            // 
            // cbDisciplinaSucessiva
            // 
            this.cbDisciplinaSucessiva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDisciplinaSucessiva.Enabled = false;
            this.cbDisciplinaSucessiva.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDisciplinaSucessiva.FormattingEnabled = true;
            this.cbDisciplinaSucessiva.Location = new System.Drawing.Point(211, 672);
            this.cbDisciplinaSucessiva.Margin = new System.Windows.Forms.Padding(4);
            this.cbDisciplinaSucessiva.Name = "cbDisciplinaSucessiva";
            this.cbDisciplinaSucessiva.Size = new System.Drawing.Size(241, 25);
            this.cbDisciplinaSucessiva.TabIndex = 11;
            this.cbDisciplinaSucessiva.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDisciplinaSucessiva_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 736);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Disciplina speciale:";
            // 
            // lblAnnoSuc
            // 
            this.lblAnnoSuc.AutoSize = true;
            this.lblAnnoSuc.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnoSuc.Location = new System.Drawing.Point(184, 678);
            this.lblAnnoSuc.Name = "lblAnnoSuc";
            this.lblAnnoSuc.Size = new System.Drawing.Size(20, 17);
            this.lblAnnoSuc.TabIndex = 40;
            this.lblAnnoSuc.Text = "5°";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btAnnulla);
            this.panel1.Controls.Add(this.btSalva);
            this.panel1.Location = new System.Drawing.Point(35, 765);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 52);
            this.panel1.TabIndex = 10;
            // 
            // btAnnulla
            // 
            this.btAnnulla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btAnnulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnnulla.Location = new System.Drawing.Point(-2, 11);
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
            this.btAnnulla.TabIndex = 14;
            this.btAnnulla.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btAnnulla.Values.Text = "Annulla";
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // btSalva
            // 
            this.btSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSalva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalva.Location = new System.Drawing.Point(344, 10);
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
            this.btSalva.Size = new System.Drawing.Size(151, 33);
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
            this.btSalva.TabIndex = 13;
            this.btSalva.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btSalva.Values.Text = "Salva";
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // tbNome
            // 
            this.tbNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNome.Location = new System.Drawing.Point(205, 57);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(247, 29);
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
            this.tbNome.TabIndex = 0;
            this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
            // 
            // tbDisciplinaSpeciale
            // 
            this.tbDisciplinaSpeciale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisciplinaSpeciale.Enabled = false;
            this.tbDisciplinaSpeciale.Location = new System.Drawing.Point(211, 720);
            this.tbDisciplinaSpeciale.Name = "tbDisciplinaSpeciale";
            this.tbDisciplinaSpeciale.Size = new System.Drawing.Size(241, 29);
            this.tbDisciplinaSpeciale.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbDisciplinaSpeciale.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbDisciplinaSpeciale.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbDisciplinaSpeciale.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbDisciplinaSpeciale.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbDisciplinaSpeciale.StateCommon.Border.Rounding = 20F;
            this.tbDisciplinaSpeciale.StateCommon.Border.Width = 1;
            this.tbDisciplinaSpeciale.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.tbDisciplinaSpeciale.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDisciplinaSpeciale.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbDisciplinaSpeciale.TabIndex = 12;
            this.tbDisciplinaSpeciale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDisciplinaSpeciale_KeyDown);
            // 
            // cbDisciplinaSpeciale
            // 
            this.cbDisciplinaSpeciale.Location = new System.Drawing.Point(205, 92);
            this.cbDisciplinaSpeciale.Name = "cbDisciplinaSpeciale";
            this.cbDisciplinaSpeciale.Size = new System.Drawing.Size(124, 25);
            this.cbDisciplinaSpeciale.TabIndex = 45;
            this.cbDisciplinaSpeciale.Values.Text = "Disciplina Speciale";
            this.cbDisciplinaSpeciale.CheckedChanged += new System.EventHandler(this.cbDisciplinaSpeciale_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(255, 32);
            this.label10.TabIndex = 46;
            this.label10.Text = "Gestisci disciplina:";
            // 
            // pnDisciplina
            // 
            this.pnDisciplina.Controls.Add(this.cbAnnoFine);
            this.pnDisciplina.Controls.Add(this.cbAnnoInizio);
            this.pnDisciplina.Controls.Add(this.label11);
            this.pnDisciplina.Controls.Add(this.label12);
            this.pnDisciplina.Controls.Add(this.label10);
            this.pnDisciplina.Controls.Add(this.panel1);
            this.pnDisciplina.Controls.Add(this.label1);
            this.pnDisciplina.Controls.Add(this.cbDisciplinaSpeciale);
            this.pnDisciplina.Controls.Add(this.label2);
            this.pnDisciplina.Controls.Add(this.tbDisciplinaSpeciale);
            this.pnDisciplina.Controls.Add(this.label3);
            this.pnDisciplina.Controls.Add(this.tbNome);
            this.pnDisciplina.Controls.Add(this.label4);
            this.pnDisciplina.Controls.Add(this.label5);
            this.pnDisciplina.Controls.Add(this.label6);
            this.pnDisciplina.Controls.Add(this.nudOreTeoria);
            this.pnDisciplina.Controls.Add(this.clbCdcs);
            this.pnDisciplina.Controls.Add(this.nudOreLab);
            this.pnDisciplina.Controls.Add(this.lblAnnoSuc);
            this.pnDisciplina.Controls.Add(this.pnRB);
            this.pnDisciplina.Controls.Add(this.label9);
            this.pnDisciplina.Controls.Add(this.clbIndirizzi);
            this.pnDisciplina.Controls.Add(this.clbDipartimenti);
            this.pnDisciplina.Controls.Add(this.label7);
            this.pnDisciplina.Controls.Add(this.cbDisciplinaSucessiva);
            this.pnDisciplina.Controls.Add(this.label8);
            this.pnDisciplina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDisciplina.Location = new System.Drawing.Point(0, 0);
            this.pnDisciplina.Name = "pnDisciplina";
            this.pnDisciplina.Size = new System.Drawing.Size(596, 833);
            this.pnDisciplina.TabIndex = 47;
            // 
            // cbAnnoFine
            // 
            this.cbAnnoFine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnnoFine.Enabled = false;
            this.cbAnnoFine.FormattingEnabled = true;
            this.cbAnnoFine.Location = new System.Drawing.Point(467, 168);
            this.cbAnnoFine.Name = "cbAnnoFine";
            this.cbAnnoFine.Size = new System.Drawing.Size(104, 25);
            this.cbAnnoFine.TabIndex = 54;
            // 
            // cbAnnoInizio
            // 
            this.cbAnnoInizio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnnoInizio.FormattingEnabled = true;
            this.cbAnnoInizio.Location = new System.Drawing.Point(205, 168);
            this.cbAnnoInizio.Name = "cbAnnoInizio";
            this.cbAnnoInizio.Size = new System.Drawing.Size(112, 25);
            this.cbAnnoInizio.TabIndex = 53;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 16);
            this.label11.TabIndex = 51;
            this.label11.Text = "Anno di inizio:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(339, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 17);
            this.label12.TabIndex = 52;
            this.label12.Text = "Anno di fine:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 551);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 16);
            this.label6.TabIndex = 42;
            this.label6.Text = "Classi di concorso:";
            // 
            // clbCdcs
            // 
            this.clbCdcs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCdcs.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbCdcs.FormattingEnabled = true;
            this.clbCdcs.Location = new System.Drawing.Point(205, 537);
            this.clbCdcs.Margin = new System.Windows.Forms.Padding(4);
            this.clbCdcs.Name = "clbCdcs";
            this.clbCdcs.Size = new System.Drawing.Size(366, 112);
            this.clbCdcs.TabIndex = 10;
            this.clbCdcs.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCdcs_ItemCheck);
            this.clbCdcs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clbCdcs_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 412);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "Dipartimenti:";
            // 
            // clbIndirizzi
            // 
            this.clbIndirizzi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbIndirizzi.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbIndirizzi.FormattingEnabled = true;
            this.clbIndirizzi.Location = new System.Drawing.Point(205, 271);
            this.clbIndirizzi.Margin = new System.Windows.Forms.Padding(4);
            this.clbIndirizzi.Name = "clbIndirizzi";
            this.clbIndirizzi.Size = new System.Drawing.Size(366, 112);
            this.clbIndirizzi.TabIndex = 8;
            this.clbIndirizzi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clbIndirizzi_KeyDown);
            // 
            // clbDipartimenti
            // 
            this.clbDipartimenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbDipartimenti.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbDipartimenti.FormattingEnabled = true;
            this.clbDipartimenti.Location = new System.Drawing.Point(205, 404);
            this.clbDipartimenti.Margin = new System.Windows.Forms.Padding(4);
            this.clbDipartimenti.Name = "clbDipartimenti";
            this.clbDipartimenti.Size = new System.Drawing.Size(366, 112);
            this.clbDipartimenti.TabIndex = 9;
            this.clbDipartimenti.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbDipartimenti_ItemCheck);
            this.clbDipartimenti.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clbDipartimenti_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 271);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "Indirizzi:";
            // 
            // frmDisciplinaBindingSource
            // 
            this.frmDisciplinaBindingSource.DataSource = typeof(Cattedre.FrmDisciplina);
            // 
            // FrmDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 833);
            this.Controls.Add(this.pnDisciplina);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDisciplina";
            this.Text = "Disciplina";
            this.Load += new System.EventHandler(this.FrmDisciplina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudOreTeoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOreLab)).EndInit();
            this.pnRB.ResumeLayout(false);
            this.pnRB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnDisciplina.ResumeLayout(false);
            this.pnDisciplina.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frmDisciplinaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudOreTeoria;
        private System.Windows.Forms.NumericUpDown nudOreLab;
        private System.Windows.Forms.Panel pnRB;
        private System.Windows.Forms.RadioButton rbQuinto;
        private System.Windows.Forms.RadioButton rbQuarto;
        private System.Windows.Forms.RadioButton rbTerzo;
        private System.Windows.Forms.RadioButton rbSecondo;
        private System.Windows.Forms.RadioButton rbPrimo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDisciplinaSucessiva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAnnoSuc;
        private System.Windows.Forms.BindingSource frmDisciplinaBindingSource;
        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonTextBox tbNome;
        private Krypton.Toolkit.KryptonTextBox tbDisciplinaSpeciale;
        private Krypton.Toolkit.KryptonButton btAnnulla;
        private Krypton.Toolkit.KryptonButton btSalva;
        private Krypton.Toolkit.KryptonCheckBox cbDisciplinaSpeciale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnDisciplina;
        private System.Windows.Forms.ComboBox cbAnnoFine;
        private System.Windows.Forms.ComboBox cbAnnoInizio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox clbCdcs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox clbIndirizzi;
        private System.Windows.Forms.CheckedListBox clbDipartimenti;
        private System.Windows.Forms.Label label7;
    }
}