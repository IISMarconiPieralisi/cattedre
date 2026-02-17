namespace Cattedre
{
    partial class FrmContratto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContratto));
            this.label1 = new System.Windows.Forms.Label();
            this.rbDeterminato = new System.Windows.Forms.RadioButton();
            this.rbIndeterminato = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMonteOre = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDataInizio = new System.Windows.Forms.DateTimePicker();
            this.dtpDataFine = new System.Windows.Forms.DateTimePicker();
            this.btAnnulla = new System.Windows.Forms.Button();
            this.btSalva = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbUtente = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonteOre)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            // 
            // rbDeterminato
            // 
            this.rbDeterminato.AutoSize = true;
            this.rbDeterminato.Location = new System.Drawing.Point(87, 35);
            this.rbDeterminato.Name = "rbDeterminato";
            this.rbDeterminato.Size = new System.Drawing.Size(80, 17);
            this.rbDeterminato.TabIndex = 1;
            this.rbDeterminato.TabStop = true;
            this.rbDeterminato.Text = "determinato";
            this.rbDeterminato.UseVisualStyleBackColor = true;
            this.rbDeterminato.CheckedChanged += new System.EventHandler(this.rbDeterminato_CheckedChanged);
            // 
            // rbIndeterminato
            // 
            this.rbIndeterminato.AutoSize = true;
            this.rbIndeterminato.Location = new System.Drawing.Point(209, 35);
            this.rbIndeterminato.Name = "rbIndeterminato";
            this.rbIndeterminato.Size = new System.Drawing.Size(88, 17);
            this.rbIndeterminato.TabIndex = 2;
            this.rbIndeterminato.TabStop = true;
            this.rbIndeterminato.Text = "indeterminato";
            this.rbIndeterminato.UseVisualStyleBackColor = true;
            this.rbIndeterminato.CheckedChanged += new System.EventHandler(this.rbIndeterminato_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monte ore:";
            // 
            // nudMonteOre
            // 
            this.nudMonteOre.Location = new System.Drawing.Point(96, 84);
            this.nudMonteOre.Name = "nudMonteOre";
            this.nudMonteOre.Size = new System.Drawing.Size(45, 20);
            this.nudMonteOre.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data inizio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data fine:";
            // 
            // dtpDataInizio
            // 
            this.dtpDataInizio.Location = new System.Drawing.Point(97, 131);
            this.dtpDataInizio.Name = "dtpDataInizio";
            this.dtpDataInizio.Size = new System.Drawing.Size(200, 20);
            this.dtpDataInizio.TabIndex = 7;
            // 
            // dtpDataFine
            // 
            this.dtpDataFine.Location = new System.Drawing.Point(97, 178);
            this.dtpDataFine.Name = "dtpDataFine";
            this.dtpDataFine.Size = new System.Drawing.Size(200, 20);
            this.dtpDataFine.TabIndex = 8;
            // 
            // btAnnulla
            // 
            this.btAnnulla.Location = new System.Drawing.Point(35, 294);
            this.btAnnulla.Name = "btAnnulla";
            this.btAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btAnnulla.TabIndex = 9;
            this.btAnnulla.Text = "Annulla";
            this.btAnnulla.UseVisualStyleBackColor = true;
            // 
            // btSalva
            // 
            this.btSalva.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSalva.Location = new System.Drawing.Point(153, 294);
            this.btSalva.Name = "btSalva";
            this.btSalva.Size = new System.Drawing.Size(75, 23);
            this.btSalva.TabIndex = 10;
            this.btSalva.Text = "Salva";
            this.btSalva.UseVisualStyleBackColor = true;
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Utente:";
            // 
            // cbUtente
            // 
            this.cbUtente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUtente.FormattingEnabled = true;
            this.cbUtente.Location = new System.Drawing.Point(97, 229);
            this.cbUtente.Name = "cbUtente";
            this.cbUtente.Size = new System.Drawing.Size(200, 21);
            this.cbUtente.TabIndex = 12;
            // 
            // FrmContratto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 350);
            this.Controls.Add(this.cbUtente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btSalva);
            this.Controls.Add(this.btAnnulla);
            this.Controls.Add(this.dtpDataFine);
            this.Controls.Add(this.dtpDataInizio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudMonteOre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbIndeterminato);
            this.Controls.Add(this.rbDeterminato);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmContratto";
            this.Text = "Contratto";
            this.Load += new System.EventHandler(this.FrmContratto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonteOre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDeterminato;
        private System.Windows.Forms.RadioButton rbIndeterminato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMonteOre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDataInizio;
        private System.Windows.Forms.DateTimePicker dtpDataFine;
        private System.Windows.Forms.Button btAnnulla;
        private System.Windows.Forms.Button btSalva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbUtente;
    }
}