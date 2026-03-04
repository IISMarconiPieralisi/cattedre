namespace Cattedre
{
    partial class FrmCattedre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCattedre));
            this.pnlClassi = new System.Windows.Forms.Panel();
            this.btGeneraASsucc = new System.Windows.Forms.Button();
            this.cbAnniScolastici = new System.Windows.Forms.ComboBox();
            this.cbDipartimenti = new System.Windows.Forms.ComboBox();
            this.pnlDipartimento = new System.Windows.Forms.Panel();
            this.pnlInfoNumCattedre = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlOreDoc = new System.Windows.Forms.Panel();
            this.pnlAnnullaSalva = new System.Windows.Forms.Panel();
            this.btSalva = new System.Windows.Forms.Button();
            this.btAnnulla = new System.Windows.Forms.Button();
            this.pnlClassi.SuspendLayout();
            this.pnlDipartimento.SuspendLayout();
            this.pnlAnnullaSalva.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClassi
            // 
            this.pnlClassi.Controls.Add(this.btGeneraASsucc);
            this.pnlClassi.Controls.Add(this.cbAnniScolastici);
            this.pnlClassi.Controls.Add(this.cbDipartimenti);
            this.pnlClassi.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlClassi.Location = new System.Drawing.Point(0, 0);
            this.pnlClassi.Name = "pnlClassi";
            this.pnlClassi.Size = new System.Drawing.Size(169, 739);
            this.pnlClassi.TabIndex = 0;
            // 
            // btGeneraASsucc
            // 
            this.btGeneraASsucc.Location = new System.Drawing.Point(76, 35);
            this.btGeneraASsucc.Name = "btGeneraASsucc";
            this.btGeneraASsucc.Size = new System.Drawing.Size(80, 23);
            this.btGeneraASsucc.TabIndex = 6;
            this.btGeneraASsucc.Text = "Genera";
            this.btGeneraASsucc.UseVisualStyleBackColor = true;
            // 
            // cbAnniScolastici
            // 
            this.cbAnniScolastici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnniScolastici.FormattingEnabled = true;
            this.cbAnniScolastici.Location = new System.Drawing.Point(11, 37);
            this.cbAnniScolastici.Name = "cbAnniScolastici";
            this.cbAnniScolastici.Size = new System.Drawing.Size(59, 21);
            this.cbAnniScolastici.TabIndex = 6;
            // 
            // cbDipartimenti
            // 
            this.cbDipartimenti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDipartimenti.FormattingEnabled = true;
            this.cbDipartimenti.Location = new System.Drawing.Point(11, 11);
            this.cbDipartimenti.Margin = new System.Windows.Forms.Padding(2);
            this.cbDipartimenti.Name = "cbDipartimenti";
            this.cbDipartimenti.Size = new System.Drawing.Size(145, 21);
            this.cbDipartimenti.TabIndex = 1;
            this.cbDipartimenti.SelectedIndexChanged += new System.EventHandler(this.btCaricaDipartimento_Click_1);
            // 
            // pnlDipartimento
            // 
            this.pnlDipartimento.AutoScroll = true;
            this.pnlDipartimento.BackColor = System.Drawing.Color.Transparent;
            this.pnlDipartimento.Controls.Add(this.pnlInfoNumCattedre);
            this.pnlDipartimento.Controls.Add(this.splitter1);
            this.pnlDipartimento.Controls.Add(this.pnlOreDoc);
            this.pnlDipartimento.Controls.Add(this.pnlAnnullaSalva);
            this.pnlDipartimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDipartimento.Location = new System.Drawing.Point(169, 0);
            this.pnlDipartimento.Name = "pnlDipartimento";
            this.pnlDipartimento.Size = new System.Drawing.Size(1307, 739);
            this.pnlDipartimento.TabIndex = 1;
            // 
            // pnlInfoNumCattedre
            // 
            this.pnlInfoNumCattedre.BackColor = System.Drawing.SystemColors.Control;
            this.pnlInfoNumCattedre.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInfoNumCattedre.Location = new System.Drawing.Point(869, 0);
            this.pnlInfoNumCattedre.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInfoNumCattedre.Name = "pnlInfoNumCattedre";
            this.pnlInfoNumCattedre.Size = new System.Drawing.Size(235, 739);
            this.pnlInfoNumCattedre.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(1104, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 739);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // pnlOreDoc
            // 
            this.pnlOreDoc.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOreDoc.Location = new System.Drawing.Point(1107, 0);
            this.pnlOreDoc.Name = "pnlOreDoc";
            this.pnlOreDoc.Size = new System.Drawing.Size(200, 739);
            this.pnlOreDoc.TabIndex = 4;
            // 
            // pnlAnnullaSalva
            // 
            this.pnlAnnullaSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAnnullaSalva.Controls.Add(this.btSalva);
            this.pnlAnnullaSalva.Controls.Add(this.btAnnulla);
            this.pnlAnnullaSalva.Location = new System.Drawing.Point(1051, 665);
            this.pnlAnnullaSalva.Name = "pnlAnnullaSalva";
            this.pnlAnnullaSalva.Size = new System.Drawing.Size(256, 74);
            this.pnlAnnullaSalva.TabIndex = 3;
            // 
            // btSalva
            // 
            this.btSalva.Location = new System.Drawing.Point(140, 17);
            this.btSalva.Name = "btSalva";
            this.btSalva.Size = new System.Drawing.Size(88, 41);
            this.btSalva.TabIndex = 1;
            this.btSalva.Text = "Salva";
            this.btSalva.UseVisualStyleBackColor = true;
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Location = new System.Drawing.Point(17, 18);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(88, 41);
            this.btAnnulla.TabIndex = 0;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // FrmCattedre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 739);
            this.Controls.Add(this.pnlDipartimento);
            this.Controls.Add(this.pnlClassi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCattedre";
            this.Text = "Cattedre";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCattedre_Load);
            this.Shown += new System.EventHandler(this.FrmCattedre_Shown);
            this.pnlClassi.ResumeLayout(false);
            this.pnlDipartimento.ResumeLayout(false);
            this.pnlAnnullaSalva.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlClassi;
        private System.Windows.Forms.Panel pnlDipartimento;
        private System.Windows.Forms.Panel pnlInfoNumCattedre;
        private System.Windows.Forms.Panel pnlAnnullaSalva;
        private System.Windows.Forms.Button btSalva;
        private System.Windows.Forms.Button btAnnulla;
        private System.Windows.Forms.ComboBox cbDipartimenti;
        private System.Windows.Forms.Panel pnlOreDoc;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox cbAnniScolastici;
        private System.Windows.Forms.Button btGeneraASsucc;
    }
}