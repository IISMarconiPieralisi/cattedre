namespace Cattedre
{
    partial class UcAssegnazioni
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbDocentiTeorici = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDocentiItip = new System.Windows.Forms.ComboBox();
            this.lblOreTeoria = new System.Windows.Forms.Label();
            this.lblOreLaboratorio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbDocentiTeorici
            // 
            this.cbDocentiTeorici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocentiTeorici.FormattingEnabled = true;
            this.cbDocentiTeorici.Location = new System.Drawing.Point(5, 18);
            this.cbDocentiTeorici.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbDocentiTeorici.Name = "cbDocentiTeorici";
            this.cbDocentiTeorici.Size = new System.Drawing.Size(111, 21);
            this.cbDocentiTeorici.TabIndex = 0;
            this.cbDocentiTeorici.SelectedIndexChanged += new System.EventHandler(this.cbDocentiTeorici_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Teorici:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(175, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "ITP:";
            // 
            // cbDocentiItip
            // 
            this.cbDocentiItip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocentiItip.FormattingEnabled = true;
            this.cbDocentiItip.Location = new System.Drawing.Point(5, 61);
            this.cbDocentiItip.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbDocentiItip.Name = "cbDocentiItip";
            this.cbDocentiItip.Size = new System.Drawing.Size(111, 21);
            this.cbDocentiItip.TabIndex = 12;
            this.cbDocentiItip.SelectedIndexChanged += new System.EventHandler(this.cbDocentiItip_SelectedIndexChanged);
            // 
            // lblOreTeoria
            // 
            this.lblOreTeoria.AutoSize = true;
            this.lblOreTeoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreTeoria.Location = new System.Drawing.Point(153, 23);
            this.lblOreTeoria.Name = "lblOreTeoria";
            this.lblOreTeoria.Size = new System.Drawing.Size(17, 16);
            this.lblOreTeoria.TabIndex = 16;
            this.lblOreTeoria.Text = "...";
            // 
            // lblOreLaboratorio
            // 
            this.lblOreLaboratorio.AutoSize = true;
            this.lblOreLaboratorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreLaboratorio.Location = new System.Drawing.Point(153, 66);
            this.lblOreLaboratorio.Name = "lblOreLaboratorio";
            this.lblOreLaboratorio.Size = new System.Drawing.Size(17, 16);
            this.lblOreLaboratorio.TabIndex = 17;
            this.lblOreLaboratorio.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(175, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "H";
            // 
            // UcAssegnazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblOreLaboratorio);
            this.Controls.Add(this.lblOreTeoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDocentiItip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDocentiTeorici);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "UcAssegnazioni";
            this.Size = new System.Drawing.Size(214, 94);
            this.Load += new System.EventHandler(this.UcAssegnazioni_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbDocentiTeorici;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbDocentiItip;
        public System.Windows.Forms.Label lblOreTeoria;
        public System.Windows.Forms.Label lblOreLaboratorio;
        private System.Windows.Forms.Label label5;
    }
}
