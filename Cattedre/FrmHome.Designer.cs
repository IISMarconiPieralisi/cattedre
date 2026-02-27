namespace Cattedre
{
    partial class FrmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnCarUtente = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNominativo = new System.Windows.Forms.Label();
            this.btLogout = new System.Windows.Forms.Button();
            this.btVaiACattedre = new System.Windows.Forms.Button();
            this.btClassi = new System.Windows.Forms.Button();
            this.btUtenti = new System.Windows.Forms.Button();
            this.btDiscipline = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cDCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNDIRIZZIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dIPARTIMENTIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dISCIPLINEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLASSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTENTIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cREDITSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.pnCarUtente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panel2.Controls.Add(this.btDiscipline);
            this.panel2.Controls.Add(this.btClassi);
            this.panel2.Controls.Add(this.btUtenti);
            this.panel2.Controls.Add(this.btLogout);
            this.panel2.Controls.Add(this.btVaiACattedre);
            this.panel2.Controls.Add(this.pnCarUtente);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 828);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pnCarUtente
            // 
            this.pnCarUtente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.pnCarUtente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnCarUtente.Controls.Add(this.pictureBox2);
            this.pnCarUtente.Controls.Add(this.lblEmail);
            this.pnCarUtente.Controls.Add(this.lblNominativo);
            this.pnCarUtente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCarUtente.Font = new System.Drawing.Font("Segoe Fluent Icons", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnCarUtente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.pnCarUtente.Location = new System.Drawing.Point(0, 0);
            this.pnCarUtente.Name = "pnCarUtente";
            this.pnCarUtente.Size = new System.Drawing.Size(333, 171);
            this.pnCarUtente.TabIndex = 29;
            this.pnCarUtente.Paint += new System.Windows.Forms.PaintEventHandler(this.pnCarUtente_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::Cattedre.Properties.Resources.user_account_management_logo_user_icon_11562867145a56rus2zwu;
            this.pictureBox2.Location = new System.Drawing.Point(23, 7);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmail.Font = new System.Drawing.Font("Segoe Fluent Icons", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(71)))), ((int)(((byte)(112)))));
            this.lblEmail.Location = new System.Drawing.Point(19, 113);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(293, 27);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "nomecognome@iismarconipieralisi.it";
            // 
            // lblNominativo
            // 
            this.lblNominativo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNominativo.AutoSize = true;
            this.lblNominativo.Font = new System.Drawing.Font("Segoe Fluent Icons", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNominativo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(71)))), ((int)(((byte)(112)))));
            this.lblNominativo.Location = new System.Drawing.Point(19, 68);
            this.lblNominativo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNominativo.Name = "lblNominativo";
            this.lblNominativo.Size = new System.Drawing.Size(278, 35);
            this.lblNominativo.TabIndex = 20;
            this.lblNominativo.Text = "NOME e COGNOME";
            // 
            // btLogout
            // 
            this.btLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btLogout.FlatAppearance.BorderSize = 0;
            this.btLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(191)))), ((int)(((byte)(36)))));
            this.btLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogout.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogout.ForeColor = System.Drawing.Color.White;
            this.btLogout.Location = new System.Drawing.Point(0, 786);
            this.btLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(333, 42);
            this.btLogout.TabIndex = 3;
            this.btLogout.Text = "Logout";
            this.btLogout.UseVisualStyleBackColor = false;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            // 
            // btVaiACattedre
            // 
            this.btVaiACattedre.BackColor = System.Drawing.Color.SkyBlue;
            this.btVaiACattedre.Dock = System.Windows.Forms.DockStyle.Top;
            this.btVaiACattedre.FlatAppearance.BorderSize = 0;
            this.btVaiACattedre.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btVaiACattedre.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.btVaiACattedre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(225)))), ((int)(((byte)(245)))));
            this.btVaiACattedre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVaiACattedre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVaiACattedre.ForeColor = System.Drawing.Color.White;
            this.btVaiACattedre.Location = new System.Drawing.Point(0, 171);
            this.btVaiACattedre.Margin = new System.Windows.Forms.Padding(2);
            this.btVaiACattedre.Name = "btVaiACattedre";
            this.btVaiACattedre.Size = new System.Drawing.Size(333, 57);
            this.btVaiACattedre.TabIndex = 0;
            this.btVaiACattedre.Text = "Cattedre";
            this.btVaiACattedre.UseVisualStyleBackColor = false;
            this.btVaiACattedre.Click += new System.EventHandler(this.btVaiACattedre_Click);
            // 
            // btClassi
            // 
            this.btClassi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btClassi.FlatAppearance.BorderSize = 0;
            this.btClassi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btClassi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(185)))));
            this.btClassi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClassi.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClassi.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btClassi.Location = new System.Drawing.Point(0, 278);
            this.btClassi.Name = "btClassi";
            this.btClassi.Size = new System.Drawing.Size(333, 50);
            this.btClassi.TabIndex = 28;
            this.btClassi.Text = "Classi";
            this.btClassi.UseVisualStyleBackColor = true;
            this.btClassi.Click += new System.EventHandler(this.cLASSIToolStripMenuItem_Click);
            // 
            // btUtenti
            // 
            this.btUtenti.Dock = System.Windows.Forms.DockStyle.Top;
            this.btUtenti.FlatAppearance.BorderSize = 0;
            this.btUtenti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btUtenti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(185)))));
            this.btUtenti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUtenti.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUtenti.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btUtenti.Location = new System.Drawing.Point(0, 228);
            this.btUtenti.Name = "btUtenti";
            this.btUtenti.Size = new System.Drawing.Size(333, 50);
            this.btUtenti.TabIndex = 27;
            this.btUtenti.Text = "Utenti";
            this.btUtenti.UseVisualStyleBackColor = true;
            this.btUtenti.Click += new System.EventHandler(this.uTENTIToolStripMenuItem_Click);
            // 
            // btDiscipline
            // 
            this.btDiscipline.Dock = System.Windows.Forms.DockStyle.Top;
            this.btDiscipline.FlatAppearance.BorderSize = 0;
            this.btDiscipline.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btDiscipline.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(185)))));
            this.btDiscipline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDiscipline.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDiscipline.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btDiscipline.Location = new System.Drawing.Point(0, 328);
            this.btDiscipline.Name = "btDiscipline";
            this.btDiscipline.Size = new System.Drawing.Size(333, 50);
            this.btDiscipline.TabIndex = 26;
            this.btDiscipline.Text = "Discipline";
            this.btDiscipline.UseVisualStyleBackColor = true;
            this.btDiscipline.Click += new System.EventHandler(this.dISCIPLINEToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opzioniToolStripMenuItem,
            this.cDCToolStripMenuItem,
            this.iNDIRIZZIToolStripMenuItem,
            this.dIPARTIMENTIToolStripMenuItem,
            this.dISCIPLINEToolStripMenuItem,
            this.cLASSIToolStripMenuItem,
            this.uTENTIToolStripMenuItem,
            this.cREDITSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1706, 29);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opzioniToolStripMenuItem
            // 
            this.opzioniToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.opzioniToolStripMenuItem.Name = "opzioniToolStripMenuItem";
            this.opzioniToolStripMenuItem.Size = new System.Drawing.Size(76, 25);
            this.opzioniToolStripMenuItem.Text = "Opzioni";
            // 
            // cDCToolStripMenuItem
            // 
            this.cDCToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cDCToolStripMenuItem.Name = "cDCToolStripMenuItem";
            this.cDCToolStripMenuItem.Size = new System.Drawing.Size(53, 25);
            this.cDCToolStripMenuItem.Text = "CDC";
            this.cDCToolStripMenuItem.Click += new System.EventHandler(this.cDCToolStripMenuItem_Click);
            // 
            // iNDIRIZZIToolStripMenuItem
            // 
            this.iNDIRIZZIToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iNDIRIZZIToolStripMenuItem.Name = "iNDIRIZZIToolStripMenuItem";
            this.iNDIRIZZIToolStripMenuItem.Size = new System.Drawing.Size(76, 25);
            this.iNDIRIZZIToolStripMenuItem.Text = "Indirizzi";
            this.iNDIRIZZIToolStripMenuItem.Click += new System.EventHandler(this.iNDIRIZZIToolStripMenuItem_Click);
            // 
            // dIPARTIMENTIToolStripMenuItem
            // 
            this.dIPARTIMENTIToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dIPARTIMENTIToolStripMenuItem.Name = "dIPARTIMENTIToolStripMenuItem";
            this.dIPARTIMENTIToolStripMenuItem.Size = new System.Drawing.Size(109, 25);
            this.dIPARTIMENTIToolStripMenuItem.Text = "Dipartimenti";
            this.dIPARTIMENTIToolStripMenuItem.Click += new System.EventHandler(this.dIPARTIMENTIToolStripMenuItem_Click);
            // 
            // dISCIPLINEToolStripMenuItem
            // 
            this.dISCIPLINEToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dISCIPLINEToolStripMenuItem.Name = "dISCIPLINEToolStripMenuItem";
            this.dISCIPLINEToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.dISCIPLINEToolStripMenuItem.Text = "Discipline";
            this.dISCIPLINEToolStripMenuItem.Click += new System.EventHandler(this.dISCIPLINEToolStripMenuItem_Click);
            // 
            // cLASSIToolStripMenuItem
            // 
            this.cLASSIToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cLASSIToolStripMenuItem.Name = "cLASSIToolStripMenuItem";
            this.cLASSIToolStripMenuItem.Size = new System.Drawing.Size(62, 25);
            this.cLASSIToolStripMenuItem.Text = "Classi";
            this.cLASSIToolStripMenuItem.Click += new System.EventHandler(this.cLASSIToolStripMenuItem_Click);
            // 
            // uTENTIToolStripMenuItem
            // 
            this.uTENTIToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uTENTIToolStripMenuItem.Name = "uTENTIToolStripMenuItem";
            this.uTENTIToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.uTENTIToolStripMenuItem.Text = "Utenti";
            this.uTENTIToolStripMenuItem.Click += new System.EventHandler(this.uTENTIToolStripMenuItem_Click);
            // 
            // cREDITSToolStripMenuItem
            // 
            this.cREDITSToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cREDITSToolStripMenuItem.Name = "cREDITSToolStripMenuItem";
            this.cREDITSToolStripMenuItem.Size = new System.Drawing.Size(61, 25);
            this.cREDITSToolStripMenuItem.Text = "Credit";
            this.cREDITSToolStripMenuItem.Click += new System.EventHandler(this.cREDITSToolStripMenuItem_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1706, 857);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmHome";
            this.Text = "Cattedre";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHome_FormClosing);
            this.Load += new System.EventHandler(this.FrmHomeUpdate_Load);
            this.panel2.ResumeLayout(false);
            this.pnCarUtente.ResumeLayout(false);
            this.pnCarUtente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btVaiACattedre;
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.Label lblNominativo;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cDCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNDIRIZZIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dIPARTIMENTIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dISCIPLINEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLASSIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uTENTIToolStripMenuItem;
        private System.Windows.Forms.Button btDiscipline;
        private System.Windows.Forms.Button btClassi;
        private System.Windows.Forms.Button btUtenti;
        private System.Windows.Forms.ToolStripMenuItem cREDITSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opzioniToolStripMenuItem;
        private System.Windows.Forms.Panel pnCarUtente;
    }
}