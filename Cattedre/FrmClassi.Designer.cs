namespace Cattedre
{
    partial class FrmClassi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClassi));
            this.cbAnnoClasse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvClassi = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSigla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAnno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSezione = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClasseArticolataCon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNomeCoordinatore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndirizzo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clDipartimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAnnoScolastico = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbIndirizzi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tplAnniScolastici = new System.Windows.Forms.TableLayoutPanel();
            this.btRipristina = new Krypton.Toolkit.KryptonButton();
            this.brModifica = new Krypton.Toolkit.KryptonButton();
            this.btElimina = new Krypton.Toolkit.KryptonButton();
            this.btInserisci = new Krypton.Toolkit.KryptonButton();
            this.btCerca = new Krypton.Toolkit.KryptonButton();
            this.btClasseSuccessiva = new Krypton.Toolkit.KryptonButton();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbAnnoClasse
            // 
            this.cbAnnoClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnnoClasse.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAnnoClasse.FormattingEnabled = true;
            this.cbAnnoClasse.Location = new System.Drawing.Point(23, 67);
            this.cbAnnoClasse.Name = "cbAnnoClasse";
            this.cbAnnoClasse.Size = new System.Drawing.Size(83, 25);
            this.cbAnnoClasse.TabIndex = 5;
            this.cbAnnoClasse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAnnoClasse_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filtra per anno:";
            // 
            // lvClassi
            // 
            this.lvClassi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvClassi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chSigla,
            this.chAnno,
            this.chSezione,
            this.chClasseArticolataCon,
            this.chNomeCoordinatore,
            this.chIndirizzo,
            this.clDipartimento,
            this.chAnnoScolastico});
            this.lvClassi.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClassi.FullRowSelect = true;
            this.lvClassi.HideSelection = false;
            this.lvClassi.Location = new System.Drawing.Point(24, 102);
            this.lvClassi.Name = "lvClassi";
            this.lvClassi.Size = new System.Drawing.Size(1378, 437);
            this.lvClassi.TabIndex = 0;
            this.lvClassi.UseCompatibleStateImageBehavior = false;
            this.lvClassi.View = System.Windows.Forms.View.Details;
            this.lvClassi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvClassi_KeyDown);
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 50;
            // 
            // chSigla
            // 
            this.chSigla.DisplayIndex = 2;
            this.chSigla.Text = "Sigla";
            // 
            // chAnno
            // 
            this.chAnno.DisplayIndex = 3;
            this.chAnno.Text = "Anno";
            // 
            // chSezione
            // 
            this.chSezione.DisplayIndex = 4;
            this.chSezione.Text = "Sezione";
            // 
            // chClasseArticolataCon
            // 
            this.chClasseArticolataCon.DisplayIndex = 5;
            this.chClasseArticolataCon.Text = "Articolata Con";
            this.chClasseArticolataCon.Width = 83;
            // 
            // chNomeCoordinatore
            // 
            this.chNomeCoordinatore.DisplayIndex = 6;
            this.chNomeCoordinatore.Text = "Nome Coordinatore";
            this.chNomeCoordinatore.Width = 171;
            // 
            // chIndirizzo
            // 
            this.chIndirizzo.DisplayIndex = 7;
            this.chIndirizzo.Text = "Indirizzo";
            this.chIndirizzo.Width = 102;
            // 
            // clDipartimento
            // 
            this.clDipartimento.DisplayIndex = 8;
            this.clDipartimento.Text = "Dipartimento";
            this.clDipartimento.Width = 150;
            // 
            // chAnnoScolastico
            // 
            this.chAnnoScolastico.DisplayIndex = 1;
            this.chAnnoScolastico.Text = "Anno scolastico";
            this.chAnnoScolastico.Width = 122;
            // 
            // cbIndirizzi
            // 
            this.cbIndirizzi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndirizzi.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIndirizzi.FormattingEnabled = true;
            this.cbIndirizzi.Location = new System.Drawing.Point(216, 67);
            this.cbIndirizzi.Name = "cbIndirizzi";
            this.cbIndirizzi.Size = new System.Drawing.Size(181, 25);
            this.cbIndirizzi.TabIndex = 6;
            this.cbIndirizzi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbIndirizzi_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Filtra per Indirizzi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Filtra per anno scolastico:";
            // 
            // tplAnniScolastici
            // 
            this.tplAnniScolastici.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplAnniScolastici.ColumnCount = 2;
            this.tplAnniScolastici.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.45055F));
            this.tplAnniScolastici.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.54945F));
            this.tplAnniScolastici.Location = new System.Drawing.Point(668, 47);
            this.tplAnniScolastici.Name = "tplAnniScolastici";
            this.tplAnniScolastici.RowCount = 1;
            this.tplAnniScolastici.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplAnniScolastici.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplAnniScolastici.Size = new System.Drawing.Size(229, 36);
            this.tplAnniScolastici.TabIndex = 7;
            // 
            // btRipristina
            // 
            this.btRipristina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRipristina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRipristina.Location = new System.Drawing.Point(1129, 54);
            this.btRipristina.Name = "btRipristina";
            this.btRipristina.OverrideDefault.Back.Color1 = System.Drawing.Color.DarkRed;
            this.btRipristina.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.btRipristina.OverrideDefault.Back.ColorAngle = 45F;
            this.btRipristina.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.btRipristina.OverrideDefault.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btRipristina.OverrideDefault.Border.ColorAngle = 45F;
            this.btRipristina.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btRipristina.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btRipristina.OverrideDefault.Border.Rounding = 20F;
            this.btRipristina.OverrideDefault.Border.Width = 1;
            this.btRipristina.Size = new System.Drawing.Size(96, 32);
            this.btRipristina.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.btRipristina.StateCommon.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btRipristina.StateCommon.Back.ColorAngle = 45F;
            this.btRipristina.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.btRipristina.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btRipristina.StateCommon.Border.ColorAngle = 45F;
            this.btRipristina.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btRipristina.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btRipristina.StateCommon.Border.Rounding = 20F;
            this.btRipristina.StateCommon.Border.Width = 1;
            this.btRipristina.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btRipristina.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btRipristina.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRipristina.StateNormal.Back.Color1 = System.Drawing.Color.Red;
            this.btRipristina.StateNormal.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btRipristina.StateNormal.Border.Color1 = System.Drawing.Color.DarkRed;
            this.btRipristina.StateNormal.Border.Color2 = System.Drawing.Color.Red;
            this.btRipristina.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btRipristina.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.btRipristina.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.btRipristina.StatePressed.Back.ColorAngle = 135F;
            this.btRipristina.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.btRipristina.StatePressed.Border.Color2 = System.Drawing.Color.Red;
            this.btRipristina.StatePressed.Border.ColorAngle = 135F;
            this.btRipristina.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btRipristina.StatePressed.Border.Rounding = 20F;
            this.btRipristina.StatePressed.Border.Width = 1;
            this.btRipristina.StateTracking.Back.Color1 = System.Drawing.Color.Red;
            this.btRipristina.StateTracking.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btRipristina.StateTracking.Back.ColorAngle = 45F;
            this.btRipristina.StateTracking.Border.Color1 = System.Drawing.Color.DarkRed;
            this.btRipristina.StateTracking.Border.Color2 = System.Drawing.Color.Red;
            this.btRipristina.StateTracking.Border.ColorAngle = 45F;
            this.btRipristina.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btRipristina.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btRipristina.StateTracking.Border.Rounding = 20F;
            this.btRipristina.StateTracking.Border.Width = 1;
            this.btRipristina.TabIndex = 45;
            this.btRipristina.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btRipristina.Values.Text = "Annulla";
            this.btRipristina.Click += new System.EventHandler(this.btRipristina_Click);
            // 
            // brModifica
            // 
            this.brModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.brModifica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brModifica.Location = new System.Drawing.Point(1408, 197);
            this.brModifica.Name = "brModifica";
            this.brModifica.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.brModifica.OverrideDefault.Back.Color2 = System.Drawing.Color.Yellow;
            this.brModifica.OverrideDefault.Back.ColorAngle = 45F;
            this.brModifica.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.brModifica.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.brModifica.OverrideDefault.Border.ColorAngle = 45F;
            this.brModifica.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.brModifica.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.brModifica.OverrideDefault.Border.Rounding = 20F;
            this.brModifica.OverrideDefault.Border.Width = 1;
            this.brModifica.Size = new System.Drawing.Size(109, 36);
            this.brModifica.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.brModifica.StateCommon.Back.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.brModifica.StateCommon.Back.ColorAngle = 45F;
            this.brModifica.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.brModifica.StateCommon.Border.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.brModifica.StateCommon.Border.ColorAngle = 45F;
            this.brModifica.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.brModifica.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.brModifica.StateCommon.Border.Rounding = 20F;
            this.brModifica.StateCommon.Border.Width = 1;
            this.brModifica.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.brModifica.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.brModifica.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brModifica.StateNormal.Back.Color1 = System.Drawing.Color.Orange;
            this.brModifica.StateNormal.Back.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.brModifica.StateNormal.Border.Color1 = System.Drawing.Color.Orange;
            this.brModifica.StateNormal.Border.Color2 = System.Drawing.Color.DarkOrange;
            this.brModifica.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.brModifica.StatePressed.Back.Color1 = System.Drawing.Color.Orange;
            this.brModifica.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.brModifica.StatePressed.Back.ColorAngle = 135F;
            this.brModifica.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.brModifica.StatePressed.Border.Color2 = System.Drawing.Color.DarkOrange;
            this.brModifica.StatePressed.Border.ColorAngle = 135F;
            this.brModifica.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.brModifica.StatePressed.Border.Rounding = 20F;
            this.brModifica.StatePressed.Border.Width = 1;
            this.brModifica.StateTracking.Back.Color1 = System.Drawing.Color.Orange;
            this.brModifica.StateTracking.Back.Color2 = System.Drawing.Color.DarkOrange;
            this.brModifica.StateTracking.Back.ColorAngle = 45F;
            this.brModifica.StateTracking.Border.Color1 = System.Drawing.Color.DarkOrange;
            this.brModifica.StateTracking.Border.Color2 = System.Drawing.Color.Orange;
            this.brModifica.StateTracking.Border.ColorAngle = 45F;
            this.brModifica.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.brModifica.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.brModifica.StateTracking.Border.Rounding = 20F;
            this.brModifica.StateTracking.Border.Width = 1;
            this.brModifica.TabIndex = 48;
            this.brModifica.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.brModifica.Values.Text = "Modifica";
            this.brModifica.Click += new System.EventHandler(this.brModifica_Click);
            // 
            // btElimina
            // 
            this.btElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btElimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btElimina.Location = new System.Drawing.Point(1408, 260);
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
            this.btElimina.TabIndex = 47;
            this.btElimina.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btElimina.Values.Text = "Elimina";
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInserisci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btInserisci.Location = new System.Drawing.Point(1408, 138);
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
            this.btInserisci.TabIndex = 46;
            this.btInserisci.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btInserisci.Values.Text = "Inserisci";
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // btCerca
            // 
            this.btCerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCerca.Location = new System.Drawing.Point(1038, 54);
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
            this.btCerca.Size = new System.Drawing.Size(85, 32);
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
            this.btCerca.TabIndex = 49;
            this.btCerca.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btCerca.Values.Text = "Cerca";
            this.btCerca.Click += new System.EventHandler(this.btCerca_Click);
            // 
            // btClasseSuccessiva
            // 
            this.btClasseSuccessiva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClasseSuccessiva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btClasseSuccessiva.Location = new System.Drawing.Point(1408, 324);
            this.btClasseSuccessiva.Name = "btClasseSuccessiva";
            this.btClasseSuccessiva.OverrideDefault.Back.Color1 = System.Drawing.Color.Purple;
            this.btClasseSuccessiva.OverrideDefault.Back.Color2 = System.Drawing.Color.BlueViolet;
            this.btClasseSuccessiva.OverrideDefault.Back.ColorAngle = 45F;
            this.btClasseSuccessiva.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btClasseSuccessiva.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btClasseSuccessiva.OverrideDefault.Border.ColorAngle = 45F;
            this.btClasseSuccessiva.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btClasseSuccessiva.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btClasseSuccessiva.OverrideDefault.Border.Rounding = 20F;
            this.btClasseSuccessiva.OverrideDefault.Border.Width = 1;
            this.btClasseSuccessiva.Size = new System.Drawing.Size(109, 59);
            this.btClasseSuccessiva.StateCommon.Back.Color1 = System.Drawing.Color.Purple;
            this.btClasseSuccessiva.StateCommon.Back.Color2 = System.Drawing.Color.Fuchsia;
            this.btClasseSuccessiva.StateCommon.Back.ColorAngle = 45F;
            this.btClasseSuccessiva.StateCommon.Border.Color1 = System.Drawing.Color.MediumPurple;
            this.btClasseSuccessiva.StateCommon.Border.Color2 = System.Drawing.Color.Plum;
            this.btClasseSuccessiva.StateCommon.Border.ColorAngle = 45F;
            this.btClasseSuccessiva.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btClasseSuccessiva.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btClasseSuccessiva.StateCommon.Border.Rounding = 20F;
            this.btClasseSuccessiva.StateCommon.Border.Width = 1;
            this.btClasseSuccessiva.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btClasseSuccessiva.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btClasseSuccessiva.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClasseSuccessiva.StateNormal.Back.Color1 = System.Drawing.Color.DarkOrchid;
            this.btClasseSuccessiva.StateNormal.Back.Color2 = System.Drawing.Color.Violet;
            this.btClasseSuccessiva.StateNormal.Border.Color1 = System.Drawing.Color.Orchid;
            this.btClasseSuccessiva.StateNormal.Border.Color2 = System.Drawing.Color.BlueViolet;
            this.btClasseSuccessiva.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btClasseSuccessiva.StatePressed.Back.Color1 = System.Drawing.Color.Purple;
            this.btClasseSuccessiva.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btClasseSuccessiva.StatePressed.Back.ColorAngle = 135F;
            this.btClasseSuccessiva.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btClasseSuccessiva.StatePressed.Border.Color2 = System.Drawing.Color.Purple;
            this.btClasseSuccessiva.StatePressed.Border.ColorAngle = 135F;
            this.btClasseSuccessiva.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btClasseSuccessiva.StatePressed.Border.Rounding = 20F;
            this.btClasseSuccessiva.StatePressed.Border.Width = 1;
            this.btClasseSuccessiva.StateTracking.Back.Color1 = System.Drawing.Color.BlueViolet;
            this.btClasseSuccessiva.StateTracking.Back.Color2 = System.Drawing.Color.Violet;
            this.btClasseSuccessiva.StateTracking.Back.ColorAngle = 45F;
            this.btClasseSuccessiva.StateTracking.Border.Color1 = System.Drawing.Color.MediumOrchid;
            this.btClasseSuccessiva.StateTracking.Border.Color2 = System.Drawing.Color.Violet;
            this.btClasseSuccessiva.StateTracking.Border.ColorAngle = 45F;
            this.btClasseSuccessiva.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btClasseSuccessiva.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btClasseSuccessiva.StateTracking.Border.Rounding = 20F;
            this.btClasseSuccessiva.StateTracking.Border.Width = 1;
            this.btClasseSuccessiva.TabIndex = 50;
            this.btClasseSuccessiva.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btClasseSuccessiva.Values.Text = "Crea classi \r\nsuccessive";
            this.btClasseSuccessiva.Click += new System.EventHandler(this.btClasseSuccessiva_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 51;
            this.label4.Text = "Classi:";
            // 
            // FrmClassi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 519);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btClasseSuccessiva);
            this.Controls.Add(this.btCerca);
            this.Controls.Add(this.brModifica);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.btRipristina);
            this.Controls.Add(this.tplAnniScolastici);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbIndirizzi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAnnoClasse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvClassi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmClassi";
            this.ShowInTaskbar = false;
            this.Text = "FrmClassi";
            this.Load += new System.EventHandler(this.FrmClassi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAnnoClasse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvClassi;
        private System.Windows.Forms.ColumnHeader chSigla;
        private System.Windows.Forms.ColumnHeader chAnno;
        private System.Windows.Forms.ColumnHeader chSezione;
        private System.Windows.Forms.ColumnHeader chClasseArticolataCon;
        private System.Windows.Forms.ColumnHeader chNomeCoordinatore;
        private System.Windows.Forms.ColumnHeader chIndirizzo;
        private System.Windows.Forms.ComboBox cbIndirizzi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader clDipartimento;
        private System.Windows.Forms.ColumnHeader chAnnoScolastico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tplAnniScolastici;
        private System.Windows.Forms.ColumnHeader chID;
        private Krypton.Toolkit.KryptonButton btRipristina;
        private Krypton.Toolkit.KryptonButton brModifica;
        private Krypton.Toolkit.KryptonButton btElimina;
        private Krypton.Toolkit.KryptonButton btInserisci;
        private Krypton.Toolkit.KryptonButton btCerca;
        private Krypton.Toolkit.KryptonButton btClasseSuccessiva;
        private System.Windows.Forms.Label label4;
    }
}