namespace Cattedre
{
    partial class FrmUtenti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtenti));
            this.lvUtenti = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCognome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTipoUtente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTipoContratto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMonteOre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataInzio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataFine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbContratto = new System.Windows.Forms.GroupBox();
            this.rbIndireterminato = new System.Windows.Forms.RadioButton();
            this.rbDeterminato = new System.Windows.Forms.RadioButton();
            this.gBtipoDocente = new System.Windows.Forms.GroupBox();
            this.rbPratico = new System.Windows.Forms.RadioButton();
            this.rdTeorico = new System.Windows.Forms.RadioButton();
            this.gbTipiUtenti = new System.Windows.Forms.GroupBox();
            this.cbDocente = new System.Windows.Forms.CheckBox();
            this.cbCoordinatore = new System.Windows.Forms.CheckBox();
            this.cbAmminstratore = new System.Windows.Forms.CheckBox();
            this.cbPreside = new System.Windows.Forms.CheckBox();
            this.tbRicerca = new Krypton.Toolkit.KryptonTextBox();
            this.btAnnullaFiltra = new Krypton.Toolkit.KryptonButton();
            this.btModifica = new Krypton.Toolkit.KryptonButton();
            this.btElimina = new Krypton.Toolkit.KryptonButton();
            this.btInserisci = new Krypton.Toolkit.KryptonButton();
            this.btCerca = new Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btCattedreUtente = new System.Windows.Forms.Button();
            this.gbContratto.SuspendLayout();
            this.gBtipoDocente.SuspendLayout();
            this.gbTipiUtenti.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvUtenti
            // 
            this.lvUtenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUtenti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chCognome,
            this.chNome,
            this.chEmail,
            this.chTipoUtente,
            this.chTipoContratto,
            this.chMonteOre,
            this.chDataInzio,
            this.chDataFine});
            this.lvUtenti.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvUtenti.FullRowSelect = true;
            this.lvUtenti.HideSelection = false;
            this.lvUtenti.Location = new System.Drawing.Point(12, 123);
            this.lvUtenti.Name = "lvUtenti";
            this.lvUtenti.Size = new System.Drawing.Size(1215, 599);
            this.lvUtenti.TabIndex = 0;
            this.lvUtenti.UseCompatibleStateImageBehavior = false;
            this.lvUtenti.View = System.Windows.Forms.View.Details;
            this.lvUtenti.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvUtenti_KeyDown);
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 50;
            // 
            // chCognome
            // 
            this.chCognome.Text = "Cognome";
            this.chCognome.Width = 100;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 100;
            // 
            // chEmail
            // 
            this.chEmail.Text = "Email";
            this.chEmail.Width = 240;
            // 
            // chTipoUtente
            // 
            this.chTipoUtente.Text = "Tipo Utente";
            this.chTipoUtente.Width = 220;
            // 
            // chTipoContratto
            // 
            this.chTipoContratto.Text = "Tipo Contratto";
            this.chTipoContratto.Width = 120;
            // 
            // chMonteOre
            // 
            this.chMonteOre.Text = "Monte ore";
            this.chMonteOre.Width = 88;
            // 
            // chDataInzio
            // 
            this.chDataInzio.Text = "Data Inizio";
            this.chDataInzio.Width = 90;
            // 
            // chDataFine
            // 
            this.chDataFine.Text = "Data Fine";
            this.chDataFine.Width = 90;
            // 
            // gbContratto
            // 
            this.gbContratto.Controls.Add(this.rbIndireterminato);
            this.gbContratto.Controls.Add(this.rbDeterminato);
            this.gbContratto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbContratto.Location = new System.Drawing.Point(650, 55);
            this.gbContratto.Name = "gbContratto";
            this.gbContratto.Size = new System.Drawing.Size(258, 47);
            this.gbContratto.TabIndex = 6;
            this.gbContratto.TabStop = false;
            this.gbContratto.Text = "Contratto";
            // 
            // rbIndireterminato
            // 
            this.rbIndireterminato.AutoSize = true;
            this.rbIndireterminato.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIndireterminato.Location = new System.Drawing.Point(134, 19);
            this.rbIndireterminato.Name = "rbIndireterminato";
            this.rbIndireterminato.Size = new System.Drawing.Size(118, 21);
            this.rbIndireterminato.TabIndex = 1;
            this.rbIndireterminato.TabStop = true;
            this.rbIndireterminato.Text = "Indeterminato";
            this.rbIndireterminato.UseVisualStyleBackColor = true;
            this.rbIndireterminato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbTipoContratto_KeyDown);
            // 
            // rbDeterminato
            // 
            this.rbDeterminato.AutoSize = true;
            this.rbDeterminato.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDeterminato.Location = new System.Drawing.Point(7, 20);
            this.rbDeterminato.Name = "rbDeterminato";
            this.rbDeterminato.Size = new System.Drawing.Size(108, 21);
            this.rbDeterminato.TabIndex = 0;
            this.rbDeterminato.TabStop = true;
            this.rbDeterminato.Text = "Determinato";
            this.rbDeterminato.UseVisualStyleBackColor = true;
            this.rbDeterminato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbTipoContratto_KeyDown);
            // 
            // gBtipoDocente
            // 
            this.gBtipoDocente.Controls.Add(this.rbPratico);
            this.gBtipoDocente.Controls.Add(this.rdTeorico);
            this.gBtipoDocente.Enabled = false;
            this.gBtipoDocente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBtipoDocente.Location = new System.Drawing.Point(440, 55);
            this.gBtipoDocente.Name = "gBtipoDocente";
            this.gBtipoDocente.Size = new System.Drawing.Size(210, 47);
            this.gBtipoDocente.TabIndex = 5;
            this.gBtipoDocente.TabStop = false;
            this.gBtipoDocente.Text = "Docente";
            // 
            // rbPratico
            // 
            this.rbPratico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPratico.AutoSize = true;
            this.rbPratico.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPratico.Location = new System.Drawing.Point(102, 19);
            this.rbPratico.Name = "rbPratico";
            this.rbPratico.Size = new System.Drawing.Size(102, 21);
            this.rbPratico.TabIndex = 1;
            this.rbPratico.TabStop = true;
            this.rbPratico.Text = "Laboratorio";
            this.rbPratico.UseVisualStyleBackColor = true;
            this.rbPratico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbTipoDocente_KeyDown);
            // 
            // rdTeorico
            // 
            this.rdTeorico.AutoSize = true;
            this.rdTeorico.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTeorico.Location = new System.Drawing.Point(7, 20);
            this.rdTeorico.Name = "rdTeorico";
            this.rdTeorico.Size = new System.Drawing.Size(72, 21);
            this.rdTeorico.TabIndex = 0;
            this.rdTeorico.TabStop = true;
            this.rdTeorico.Text = "Teorico";
            this.rdTeorico.UseVisualStyleBackColor = true;
            this.rdTeorico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbTipoDocente_KeyDown);
            // 
            // gbTipiUtenti
            // 
            this.gbTipiUtenti.Controls.Add(this.cbDocente);
            this.gbTipiUtenti.Controls.Add(this.cbCoordinatore);
            this.gbTipiUtenti.Controls.Add(this.cbAmminstratore);
            this.gbTipiUtenti.Controls.Add(this.cbPreside);
            this.gbTipiUtenti.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipiUtenti.Location = new System.Drawing.Point(12, 55);
            this.gbTipiUtenti.Name = "gbTipiUtenti";
            this.gbTipiUtenti.Size = new System.Drawing.Size(432, 47);
            this.gbTipiUtenti.TabIndex = 4;
            this.gbTipiUtenti.TabStop = false;
            this.gbTipiUtenti.Text = "Utente";
            // 
            // cbDocente
            // 
            this.cbDocente.AutoSize = true;
            this.cbDocente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDocente.Location = new System.Drawing.Point(339, 20);
            this.cbDocente.Name = "cbDocente";
            this.cbDocente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbDocente.Size = new System.Drawing.Size(83, 21);
            this.cbDocente.TabIndex = 7;
            this.cbDocente.Text = "Docente";
            this.cbDocente.UseVisualStyleBackColor = true;
            this.cbDocente.CheckedChanged += new System.EventHandler(this.cbDocenteCordinatore_CheckedChanged);
            this.cbDocente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenericCheckBox_KeyDown);
            // 
            // cbCoordinatore
            // 
            this.cbCoordinatore.AutoSize = true;
            this.cbCoordinatore.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCoordinatore.Location = new System.Drawing.Point(217, 20);
            this.cbCoordinatore.Name = "cbCoordinatore";
            this.cbCoordinatore.Size = new System.Drawing.Size(115, 21);
            this.cbCoordinatore.TabIndex = 6;
            this.cbCoordinatore.Text = "Coordinatore";
            this.cbCoordinatore.UseVisualStyleBackColor = true;
            this.cbCoordinatore.CheckedChanged += new System.EventHandler(this.cbDocenteCordinatore_CheckedChanged);
            this.cbCoordinatore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenericCheckBox_KeyDown);
            // 
            // cbAmminstratore
            // 
            this.cbAmminstratore.AutoSize = true;
            this.cbAmminstratore.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAmminstratore.Location = new System.Drawing.Point(85, 20);
            this.cbAmminstratore.Name = "cbAmminstratore";
            this.cbAmminstratore.Size = new System.Drawing.Size(125, 21);
            this.cbAmminstratore.TabIndex = 5;
            this.cbAmminstratore.Text = "Amministratore";
            this.cbAmminstratore.UseVisualStyleBackColor = true;
            this.cbAmminstratore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenericCheckBox_KeyDown);
            // 
            // cbPreside
            // 
            this.cbPreside.AutoSize = true;
            this.cbPreside.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPreside.Location = new System.Drawing.Point(6, 21);
            this.cbPreside.Name = "cbPreside";
            this.cbPreside.Size = new System.Drawing.Size(72, 21);
            this.cbPreside.TabIndex = 4;
            this.cbPreside.Text = "Preside";
            this.cbPreside.UseVisualStyleBackColor = true;
            this.cbPreside.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenericCheckBox_KeyDown);
            // 
            // tbRicerca
            // 
            this.tbRicerca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRicerca.Location = new System.Drawing.Point(914, 63);
            this.tbRicerca.Name = "tbRicerca";
            this.tbRicerca.Size = new System.Drawing.Size(198, 31);
            this.tbRicerca.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.tbRicerca.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.tbRicerca.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbRicerca.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tbRicerca.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.tbRicerca.StateCommon.Border.Rounding = 20F;
            this.tbRicerca.StateCommon.Border.Width = 1;
            this.tbRicerca.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.tbRicerca.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRicerca.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tbRicerca.StateNormal.Content.Color1 = System.Drawing.Color.Gray;
            this.tbRicerca.TabIndex = 30;
            this.tbRicerca.Text = "cognome nome";
            this.tbRicerca.Enter += new System.EventHandler(this.tbRicerca_Enter);
            this.tbRicerca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRicerca_KeyDown);
            this.tbRicerca.Leave += new System.EventHandler(this.tbRicerca_Leave);
            // 
            // btAnnullaFiltra
            // 
            this.btAnnullaFiltra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAnnullaFiltra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnnullaFiltra.Location = new System.Drawing.Point(1118, 63);
            this.btAnnullaFiltra.Name = "btAnnullaFiltra";
            this.btAnnullaFiltra.OverrideDefault.Back.Color1 = System.Drawing.Color.DarkRed;
            this.btAnnullaFiltra.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.OverrideDefault.Back.ColorAngle = 45F;
            this.btAnnullaFiltra.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.OverrideDefault.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnullaFiltra.OverrideDefault.Border.ColorAngle = 45F;
            this.btAnnullaFiltra.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnullaFiltra.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btAnnullaFiltra.OverrideDefault.Border.Rounding = 20F;
            this.btAnnullaFiltra.OverrideDefault.Border.Width = 1;
            this.btAnnullaFiltra.Size = new System.Drawing.Size(109, 32);
            this.btAnnullaFiltra.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.StateCommon.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnullaFiltra.StateCommon.Back.ColorAngle = 45F;
            this.btAnnullaFiltra.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnullaFiltra.StateCommon.Border.ColorAngle = 45F;
            this.btAnnullaFiltra.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnullaFiltra.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btAnnullaFiltra.StateCommon.Border.Rounding = 20F;
            this.btAnnullaFiltra.StateCommon.Border.Width = 1;
            this.btAnnullaFiltra.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btAnnullaFiltra.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btAnnullaFiltra.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAnnullaFiltra.StateNormal.Back.Color1 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.StateNormal.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnullaFiltra.StateNormal.Border.Color1 = System.Drawing.Color.DarkRed;
            this.btAnnullaFiltra.StateNormal.Border.Color2 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnullaFiltra.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.StatePressed.Back.Color2 = System.Drawing.Color.Yellow;
            this.btAnnullaFiltra.StatePressed.Back.ColorAngle = 135F;
            this.btAnnullaFiltra.StatePressed.Border.Color1 = System.Drawing.Color.Yellow;
            this.btAnnullaFiltra.StatePressed.Border.Color2 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.StatePressed.Border.ColorAngle = 135F;
            this.btAnnullaFiltra.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnullaFiltra.StatePressed.Border.Rounding = 20F;
            this.btAnnullaFiltra.StatePressed.Border.Width = 1;
            this.btAnnullaFiltra.StateTracking.Back.Color1 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.StateTracking.Back.Color2 = System.Drawing.Color.DarkRed;
            this.btAnnullaFiltra.StateTracking.Back.ColorAngle = 45F;
            this.btAnnullaFiltra.StateTracking.Border.Color1 = System.Drawing.Color.DarkRed;
            this.btAnnullaFiltra.StateTracking.Border.Color2 = System.Drawing.Color.Red;
            this.btAnnullaFiltra.StateTracking.Border.ColorAngle = 45F;
            this.btAnnullaFiltra.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btAnnullaFiltra.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btAnnullaFiltra.StateTracking.Border.Rounding = 20F;
            this.btAnnullaFiltra.StateTracking.Border.Width = 1;
            this.btAnnullaFiltra.TabIndex = 35;
            this.btAnnullaFiltra.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btAnnullaFiltra.Values.Text = "Annulla";
            this.btAnnullaFiltra.Click += new System.EventHandler(this.btAnnullaFiltra_Click);
            // 
            // btModifica
            // 
            this.btModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModifica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModifica.Location = new System.Drawing.Point(1233, 204);
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
            this.btModifica.TabIndex = 41;
            this.btModifica.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btModifica.Values.Text = "Modifica";
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // btElimina
            // 
            this.btElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btElimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btElimina.Location = new System.Drawing.Point(1233, 255);
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
            this.btElimina.TabIndex = 40;
            this.btElimina.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btElimina.Values.Text = "Elimina";
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // btInserisci
            // 
            this.btInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInserisci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btInserisci.Location = new System.Drawing.Point(1233, 152);
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
            this.btInserisci.TabIndex = 39;
            this.btInserisci.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btInserisci.Values.Text = "Inserisci";
            this.btInserisci.Click += new System.EventHandler(this.btInserisci_Click);
            // 
            // btCerca
            // 
            this.btCerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCerca.Location = new System.Drawing.Point(1233, 63);
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
            this.btCerca.Size = new System.Drawing.Size(109, 32);
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
            this.btCerca.TabIndex = 42;
            this.btCerca.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btCerca.Values.Text = "Cerca";
            this.btCerca.Click += new System.EventHandler(this.btFiltro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 43;
            this.label1.Text = "Utenti:";
            // 
            // btCattedreUtente
            // 
            this.btCattedreUtente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCattedreUtente.Location = new System.Drawing.Point(1233, 306);
            this.btCattedreUtente.Name = "btCattedreUtente";
            this.btCattedreUtente.Size = new System.Drawing.Size(109, 30);
            this.btCattedreUtente.TabIndex = 44;
            this.btCattedreUtente.Text = "Cattedre";
            this.btCattedreUtente.UseVisualStyleBackColor = true;
            this.btCattedreUtente.Click += new System.EventHandler(this.btCattedreUtente_Click);
            // 
            // FrmUtenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 745);
            this.Controls.Add(this.btCattedreUtente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbContratto);
            this.Controls.Add(this.btCerca);
            this.Controls.Add(this.btModifica);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btInserisci);
            this.Controls.Add(this.btAnnullaFiltra);
            this.Controls.Add(this.tbRicerca);
            this.Controls.Add(this.gBtipoDocente);
            this.Controls.Add(this.gbTipiUtenti);
            this.Controls.Add(this.lvUtenti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUtenti";
            this.ShowInTaskbar = false;
            this.Text = "Utenti";
            this.Load += new System.EventHandler(this.FrmUtenti_Load);
            this.gbContratto.ResumeLayout(false);
            this.gbContratto.PerformLayout();
            this.gBtipoDocente.ResumeLayout(false);
            this.gBtipoDocente.PerformLayout();
            this.gbTipiUtenti.ResumeLayout(false);
            this.gbTipiUtenti.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUtenti;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chCognome;
        private System.Windows.Forms.ColumnHeader chEmail;
        private System.Windows.Forms.ColumnHeader chTipoUtente;
        private System.Windows.Forms.ColumnHeader chTipoContratto;
        private System.Windows.Forms.ColumnHeader chMonteOre;
        private System.Windows.Forms.ColumnHeader chDataInzio;
        private System.Windows.Forms.ColumnHeader chDataFine;
        private System.Windows.Forms.GroupBox gbContratto;
        private System.Windows.Forms.RadioButton rbIndireterminato;
        private System.Windows.Forms.RadioButton rbDeterminato;
        private System.Windows.Forms.GroupBox gBtipoDocente;
        private System.Windows.Forms.RadioButton rbPratico;
        private System.Windows.Forms.RadioButton rdTeorico;
        private System.Windows.Forms.GroupBox gbTipiUtenti;
        private System.Windows.Forms.CheckBox cbDocente;
        private System.Windows.Forms.CheckBox cbCoordinatore;
        private System.Windows.Forms.CheckBox cbAmminstratore;
        private System.Windows.Forms.CheckBox cbPreside;
        private System.Windows.Forms.ColumnHeader chID;
        private Krypton.Toolkit.KryptonTextBox tbRicerca;
        private Krypton.Toolkit.KryptonButton btAnnullaFiltra;
        private Krypton.Toolkit.KryptonButton btModifica;
        private Krypton.Toolkit.KryptonButton btElimina;
        private Krypton.Toolkit.KryptonButton btInserisci;
        private Krypton.Toolkit.KryptonButton btCerca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCattedreUtente;
    }
}