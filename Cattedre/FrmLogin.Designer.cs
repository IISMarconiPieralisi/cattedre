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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbNomeUtente = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btLogin = new System.Windows.Forms.Button();
            this.lblInserisciNomeUtente = new System.Windows.Forms.Label();
            this.lblInserisciPassword = new System.Windows.Forms.Label();
            this.btLoginGoogle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Email:";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(297, 214);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(219, 15);
            this.tbPassword.TabIndex = 11;
            this.tbPassword.Text = "vitalf00!";
            this.tbPassword.Click += new System.EventHandler(this.tbPassword_Click);
            // 
            // tbNomeUtente
            // 
            this.tbNomeUtente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNomeUtente.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNomeUtente.Location = new System.Drawing.Point(288, 154);
            this.tbNomeUtente.Margin = new System.Windows.Forms.Padding(2);
            this.tbNomeUtente.Name = "tbNomeUtente";
            this.tbNomeUtente.Size = new System.Drawing.Size(241, 15);
            this.tbNomeUtente.TabIndex = 10;
            this.tbNomeUtente.Text = "vittorio.alfieri@iismarconipieralisi.it";
            this.tbNomeUtente.Click += new System.EventHandler(this.tbNomeUtente_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Location = new System.Drawing.Point(300, 229);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 2);
            this.panel2.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Location = new System.Drawing.Point(291, 169);
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
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(364, 266);
            this.btLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(76, 22);
            this.btLogin.TabIndex = 16;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // lblInserisciNomeUtente
            // 
            this.lblInserisciNomeUtente.AutoSize = true;
            this.lblInserisciNomeUtente.ForeColor = System.Drawing.Color.Red;
            this.lblInserisciNomeUtente.Location = new System.Drawing.Point(297, 174);
            this.lblInserisciNomeUtente.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblInserisciNomeUtente.Name = "lblInserisciNomeUtente";
            this.lblInserisciNomeUtente.Size = new System.Drawing.Size(110, 13);
            this.lblInserisciNomeUtente.TabIndex = 17;
            this.lblInserisciNomeUtente.Text = "Inserisci nome utente!";
            this.lblInserisciNomeUtente.Visible = false;
            // 
            // lblInserisciPassword
            // 
            this.lblInserisciPassword.AutoSize = true;
            this.lblInserisciPassword.ForeColor = System.Drawing.Color.Red;
            this.lblInserisciPassword.Location = new System.Drawing.Point(297, 234);
            this.lblInserisciPassword.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblInserisciPassword.Name = "lblInserisciPassword";
            this.lblInserisciPassword.Size = new System.Drawing.Size(96, 13);
            this.lblInserisciPassword.TabIndex = 18;
            this.lblInserisciPassword.Text = "Inserisci password!";
            this.lblInserisciPassword.Visible = false;
            // 
            // btLoginGoogle
            // 
            this.btLoginGoogle.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLoginGoogle.Location = new System.Drawing.Point(288, 361);
            this.btLoginGoogle.Margin = new System.Windows.Forms.Padding(2);
            this.btLoginGoogle.Name = "btLoginGoogle";
            this.btLoginGoogle.Size = new System.Drawing.Size(238, 37);
            this.btLoginGoogle.TabIndex = 19;
            this.btLoginGoogle.Text = "Login con google";
            this.btLoginGoogle.UseVisualStyleBackColor = true;
            this.btLoginGoogle.Click += new System.EventHandler(this.btLoginGoogle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(360, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "Oppure:";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 431);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btLoginGoogle);
            this.Controls.Add(this.lblInserisciPassword);
            this.Controls.Add(this.lblInserisciNomeUtente);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbNomeUtente);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Label lblInserisciNomeUtente;
        private System.Windows.Forms.Label lblInserisciPassword;
        private System.Windows.Forms.Button btLoginGoogle;
        private System.Windows.Forms.Label label3;
    }
}

