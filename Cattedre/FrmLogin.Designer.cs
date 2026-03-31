namespace Cattedre
{
    partial class FrmLogin
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbNomeUtente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblInserisciNomeUtente = new System.Windows.Forms.Label();
            this.lblInserisciPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.btLogin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btLoginGoogle = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(283, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(283, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Email:";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(290, 251);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(219, 15);
            this.tbPassword.TabIndex = 11;
            this.tbPassword.Text = "Pigini";
            this.tbPassword.Click += new System.EventHandler(this.tbPassword_Click);
            // 
            // tbNomeUtente
            // 
            this.tbNomeUtente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNomeUtente.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNomeUtente.Location = new System.Drawing.Point(290, 168);
            this.tbNomeUtente.Margin = new System.Windows.Forms.Padding(2);
            this.tbNomeUtente.Name = "tbNomeUtente";
            this.tbNomeUtente.Size = new System.Drawing.Size(241, 15);
            this.tbNomeUtente.TabIndex = 10;
            this.tbNomeUtente.Text = "marcello.pigini@iismarconipieralisi.it";
            this.tbNomeUtente.Click += new System.EventHandler(this.tbNomeUtente_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Location = new System.Drawing.Point(290, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 2);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(75)))), ((int)(((byte)(155)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 431);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(250, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(309, 116);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // lblInserisciNomeUtente
            // 
            this.lblInserisciNomeUtente.AutoSize = true;
            this.lblInserisciNomeUtente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblInserisciNomeUtente.ForeColor = System.Drawing.Color.Red;
            this.lblInserisciNomeUtente.Location = new System.Drawing.Point(287, 191);
            this.lblInserisciNomeUtente.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblInserisciNomeUtente.Name = "lblInserisciNomeUtente";
            this.lblInserisciNomeUtente.Size = new System.Drawing.Size(127, 15);
            this.lblInserisciNomeUtente.TabIndex = 17;
            this.lblInserisciNomeUtente.Text = "Inserisci nome utente!";
            this.lblInserisciNomeUtente.Visible = false;
            // 
            // lblInserisciPassword
            // 
            this.lblInserisciPassword.AutoSize = true;
            this.lblInserisciPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblInserisciPassword.ForeColor = System.Drawing.Color.Red;
            this.lblInserisciPassword.Location = new System.Drawing.Point(290, 271);
            this.lblInserisciPassword.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblInserisciPassword.Name = "lblInserisciPassword";
            this.lblInserisciPassword.Size = new System.Drawing.Size(111, 15);
            this.lblInserisciPassword.TabIndex = 18;
            this.lblInserisciPassword.Text = "Inserisci password!";
            this.lblInserisciPassword.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(362, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Oppure:";
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.ButtonSpecs.FormClose.Image = ((System.Drawing.Image)(resources.GetObject("kryptonPalette1.ButtonSpecs.FormClose.Image")));
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImagePressed = ((System.Drawing.Image)(resources.GetObject("kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImagePressed")));
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImageTracking = ((System.Drawing.Image)(resources.GetObject("kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImageTracking")));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Border.Width = 0;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 14;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            // 
            // btLogin
            // 
            this.btLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLogin.Location = new System.Drawing.Point(330, 307);
            this.btLogin.Name = "btLogin";
            this.btLogin.OverrideDefault.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLogin.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLogin.OverrideDefault.Back.ColorAngle = 45F;
            this.btLogin.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btLogin.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btLogin.OverrideDefault.Border.ColorAngle = 45F;
            this.btLogin.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLogin.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btLogin.OverrideDefault.Border.Rounding = 20;
            this.btLogin.OverrideDefault.Border.Width = 1;
            this.btLogin.Size = new System.Drawing.Size(120, 38);
            this.btLogin.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StateCommon.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StateCommon.Back.ColorAngle = 45F;
            this.btLogin.StateCommon.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StateCommon.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StateCommon.Border.ColorAngle = 45F;
            this.btLogin.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLogin.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btLogin.StateCommon.Border.Rounding = 20;
            this.btLogin.StateCommon.Border.Width = 1;
            this.btLogin.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btLogin.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btLogin.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin.StateNormal.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLogin.StateNormal.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StateNormal.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLogin.StatePressed.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLogin.StatePressed.Back.ColorAngle = 135F;
            this.btLogin.StatePressed.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StatePressed.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLogin.StatePressed.Border.ColorAngle = 135F;
            this.btLogin.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLogin.StatePressed.Border.Rounding = 20;
            this.btLogin.StatePressed.Border.Width = 1;
            this.btLogin.StateTracking.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLogin.StateTracking.Back.ColorAngle = 45F;
            this.btLogin.StateTracking.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btLogin.StateTracking.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.btLogin.StateTracking.Border.ColorAngle = 45F;
            this.btLogin.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLogin.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btLogin.StateTracking.Border.Rounding = 20;
            this.btLogin.StateTracking.Border.Width = 1;
            this.btLogin.TabIndex = 21;
            this.btLogin.Values.Text = "Login";
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btLoginGoogle
            // 
            this.btLoginGoogle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLoginGoogle.Location = new System.Drawing.Point(315, 368);
            this.btLoginGoogle.Name = "btLoginGoogle";
            this.btLoginGoogle.OverrideDefault.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLoginGoogle.OverrideDefault.Back.ColorAngle = 45F;
            this.btLoginGoogle.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btLoginGoogle.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btLoginGoogle.OverrideDefault.Border.ColorAngle = 45F;
            this.btLoginGoogle.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLoginGoogle.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btLoginGoogle.OverrideDefault.Border.Rounding = 20;
            this.btLoginGoogle.OverrideDefault.Border.Width = 1;
            this.btLoginGoogle.Size = new System.Drawing.Size(170, 38);
            this.btLoginGoogle.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StateCommon.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StateCommon.Back.ColorAngle = 45F;
            this.btLoginGoogle.StateCommon.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StateCommon.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StateCommon.Border.ColorAngle = 45F;
            this.btLoginGoogle.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLoginGoogle.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btLoginGoogle.StateCommon.Border.Rounding = 20;
            this.btLoginGoogle.StateCommon.Border.Width = 1;
            this.btLoginGoogle.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btLoginGoogle.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btLoginGoogle.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLoginGoogle.StateNormal.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLoginGoogle.StateNormal.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StateNormal.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLoginGoogle.StatePressed.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLoginGoogle.StatePressed.Back.ColorAngle = 135F;
            this.btLoginGoogle.StatePressed.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StatePressed.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLoginGoogle.StatePressed.Border.ColorAngle = 135F;
            this.btLoginGoogle.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLoginGoogle.StatePressed.Border.Rounding = 20;
            this.btLoginGoogle.StatePressed.Border.Width = 1;
            this.btLoginGoogle.StateTracking.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btLoginGoogle.StateTracking.Back.ColorAngle = 45F;
            this.btLoginGoogle.StateTracking.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btLoginGoogle.StateTracking.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.btLoginGoogle.StateTracking.Border.ColorAngle = 45F;
            this.btLoginGoogle.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btLoginGoogle.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btLoginGoogle.StateTracking.Border.Rounding = 20;
            this.btLoginGoogle.StateTracking.Border.Width = 1;
            this.btLoginGoogle.TabIndex = 22;
            this.btLoginGoogle.Values.Text = "Login con Google";
            this.btLoginGoogle.Click += new System.EventHandler(this.btLoginGoogle_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Location = new System.Drawing.Point(287, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 2);
            this.panel2.TabIndex = 23;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(559, 431);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btLoginGoogle);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblInserisciPassword);
            this.Controls.Add(this.lblInserisciNomeUtente);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbNomeUtente);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmLogin";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbNomeUtente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblInserisciNomeUtente;
        private System.Windows.Forms.Label lblInserisciPassword;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btLogin;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btLoginGoogle;
        private System.Windows.Forms.Panel panel2;
    }
}

