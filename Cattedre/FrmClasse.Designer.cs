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
            ((System.ComponentModel.ISupportInitialize)(this.nudAnno)).BeginInit();
            this.SuspendLayout();
            // 
            // btSalva
            // 
            this.btSalva.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSalva.Location = new System.Drawing.Point(155, 202);
            this.btSalva.Margin = new System.Windows.Forms.Padding(2);
            this.btSalva.Name = "btSalva";
            this.btSalva.Size = new System.Drawing.Size(56, 19);
            this.btSalva.TabIndex = 31;
            this.btSalva.Text = "Salva";
            this.btSalva.UseVisualStyleBackColor = true;
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // btAnnulla
            // 
            this.btAnnulla.Location = new System.Drawing.Point(56, 202);
            this.btAnnulla.Margin = new System.Windows.Forms.Padding(2);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(56, 19);
            this.btAnnulla.TabIndex = 30;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            this.btAnnulla.Click += new System.EventHandler(this.btAnnulla_Click);
            // 
            // tbSezione
            // 
            this.tbSezione.Location = new System.Drawing.Point(132, 49);
            this.tbSezione.Margin = new System.Windows.Forms.Padding(2);
            this.tbSezione.MaxLength = 3;
            this.tbSezione.Name = "tbSezione";
            this.tbSezione.Size = new System.Drawing.Size(126, 20);
            this.tbSezione.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Classe articolata con:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Sezione:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Anno:";
            // 
            // nudAnno
            // 
            this.nudAnno.Location = new System.Drawing.Point(132, 12);
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
            this.nudAnno.ReadOnly = true;
            this.nudAnno.Size = new System.Drawing.Size(37, 20);
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
            this.label5.Location = new System.Drawing.Point(21, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Coordinatore:";
            // 
            // cbCoordinatore
            // 
            this.cbCoordinatore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoordinatore.FormattingEnabled = true;
            this.cbCoordinatore.Location = new System.Drawing.Point(132, 121);
            this.cbCoordinatore.Name = "cbCoordinatore";
            this.cbCoordinatore.Size = new System.Drawing.Size(121, 21);
            this.cbCoordinatore.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Indirizzo:";
            // 
            // cbIndirizzo
            // 
            this.cbIndirizzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndirizzo.FormattingEnabled = true;
            this.cbIndirizzo.Location = new System.Drawing.Point(132, 161);
            this.cbIndirizzo.Name = "cbIndirizzo";
            this.cbIndirizzo.Size = new System.Drawing.Size(121, 21);
            this.cbIndirizzo.TabIndex = 37;
            // 
            // cbClasseArticolataCon
            // 
            this.cbClasseArticolataCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasseArticolataCon.FormattingEnabled = true;
            this.cbClasseArticolataCon.Location = new System.Drawing.Point(132, 83);
            this.cbClasseArticolataCon.Name = "cbClasseArticolataCon";
            this.cbClasseArticolataCon.Size = new System.Drawing.Size(52, 21);
            this.cbClasseArticolataCon.TabIndex = 38;
            // 
            // FrmClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 232);
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
    }
}