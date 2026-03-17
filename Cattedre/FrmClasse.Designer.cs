namespace Cattedre
{
    partial class FrmClasse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClasse));
            this.btSalva = new System.Windows.Forms.Button();
            this.btAnnulla = new System.Windows.Forms.Button();
            this.tbSezione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAnno = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCoordinatore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIndirizzo = new System.Windows.Forms.ComboBox();
            this.cbClasseArticolataCon = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbAnnoScolastico = new System.Windows.Forms.ComboBox();
            this.cbDipartimento = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnno)).BeginInit();
            this.SuspendLayout();
            // 
            // btSalva
            // 
            this.btSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSalva.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSalva.Location = new System.Drawing.Point(180, 376);
            this.btSalva.Margin = new System.Windows.Forms.Padding(2);
            this.btSalva.Name = "btSalva";
            this.btSalva.Size = new System.Drawing.Size(142, 27);
            this.btSalva.TabIndex = 31;
            this.btSalva.Text = "Salva";
            this.btSalva.UseVisualStyleBackColor = true;
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAnnulla.Location = new System.Drawing.Point(26, 376);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(142, 27);
            this.btAnnulla.TabIndex = 30;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbSezione
            // 
            this.tbSezione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSezione.Location = new System.Drawing.Point(132, 65);
            this.tbSezione.Margin = new System.Windows.Forms.Padding(2);
            this.tbSezione.MaxLength = 3;
            this.tbSezione.Name = "tbSezione";
            this.tbSezione.Size = new System.Drawing.Size(190, 20);
            this.tbSezione.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 173);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Classe articolata con:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Sezione:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Anno:";
            // 
            // nudAnno
            // 
            this.nudAnno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAnno.Location = new System.Drawing.Point(132, 14);
            this.nudAnno.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudAnno.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnno.Name = "nudAnno";
            this.nudAnno.Size = new System.Drawing.Size(190, 20);
            this.nudAnno.TabIndex = 33;
            this.nudAnno.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnno.ValueChanged += new System.EventHandler(this.nudAnno_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Coordinatore:";
            // 
            // cbCoordinatore
            // 
            this.cbCoordinatore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCoordinatore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoordinatore.FormattingEnabled = true;
            this.cbCoordinatore.Location = new System.Drawing.Point(132, 324);
            this.cbCoordinatore.Name = "cbCoordinatore";
            this.cbCoordinatore.Size = new System.Drawing.Size(190, 21);
            this.cbCoordinatore.TabIndex = 35;
            this.cbCoordinatore.DropDown += new System.EventHandler(this.cbCoordinatore_DropDown);
            this.cbCoordinatore.SelectedIndexChanged += new System.EventHandler(this.cbCoordinatore_SelectedIndexChanged);
            this.cbCoordinatore.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbCoordinatore_Format);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Indirizzo:";
            // 
            // cbIndirizzo
            // 
            this.cbIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIndirizzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndirizzo.FormattingEnabled = true;
            this.cbIndirizzo.Location = new System.Drawing.Point(132, 220);
            this.cbIndirizzo.Name = "cbIndirizzo";
            this.cbIndirizzo.Size = new System.Drawing.Size(190, 21);
            this.cbIndirizzo.TabIndex = 37;
            // 
            // cbClasseArticolataCon
            // 
            this.cbClasseArticolataCon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbClasseArticolataCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasseArticolataCon.Enabled = false;
            this.cbClasseArticolataCon.FormattingEnabled = true;
            this.cbClasseArticolataCon.Location = new System.Drawing.Point(132, 168);
            this.cbClasseArticolataCon.Name = "cbClasseArticolataCon";
            this.cbClasseArticolataCon.Size = new System.Drawing.Size(190, 21);
            this.cbClasseArticolataCon.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "AnnoScolastico:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Dipartimento";
            // 
            // cbAnnoScolastico
            // 
            this.cbAnnoScolastico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAnnoScolastico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnnoScolastico.FormattingEnabled = true;
            this.cbAnnoScolastico.Location = new System.Drawing.Point(132, 116);
            this.cbAnnoScolastico.Name = "cbAnnoScolastico";
            this.cbAnnoScolastico.Size = new System.Drawing.Size(190, 21);
            this.cbAnnoScolastico.TabIndex = 41;
            this.cbAnnoScolastico.SelectedIndexChanged += new System.EventHandler(this.cbAnnoScolastico_SelectedIndexChanged);
            // 
            // cbDipartimento
            // 
            this.cbDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDipartimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDipartimento.FormattingEnabled = true;
            this.cbDipartimento.Location = new System.Drawing.Point(132, 272);
            this.cbDipartimento.Name = "cbDipartimento";
            this.cbDipartimento.Size = new System.Drawing.Size(190, 21);
            this.cbDipartimento.TabIndex = 42;
            // 
            // FrmClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 424);
            this.Controls.Add(this.cbDipartimento);
            this.Controls.Add(this.cbAnnoScolastico);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbClasseArticolataCon);
            this.Controls.Add(this.cbIndirizzo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCoordinatore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudAnno);
            this.Controls.Add(this.btSalva);
            this.Controls.Add(this.btAnnulla);
            this.Controls.Add(this.tbSezione);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmClasse";
            this.Text = "FrmClasse";
            this.Load += new System.EventHandler(this.FrmClasse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btSalva;
        private System.Windows.Forms.Button btAnnulla;
        private System.Windows.Forms.TextBox tbSezione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudAnno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCoordinatore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbIndirizzo;
        private System.Windows.Forms.ComboBox cbClasseArticolataCon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbAnnoScolastico;
        private System.Windows.Forms.ComboBox cbDipartimento;
    }
}