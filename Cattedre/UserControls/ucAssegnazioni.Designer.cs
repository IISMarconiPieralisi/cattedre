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
            this.components = new System.ComponentModel.Container();
            this.cbDocentiTeorici = new System.Windows.Forms.ComboBox();
            this.cmDocente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTaglia = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopia = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIncolla = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDocentiItip = new System.Windows.Forms.ComboBox();
            this.lblOreTeoria = new System.Windows.Forms.Label();
            this.lblOreLaboratorio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmDocente.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDocentiTeorici
            // 
            this.cbDocentiTeorici.ContextMenuStrip = this.cmDocente;
            this.cbDocentiTeorici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocentiTeorici.FormattingEnabled = true;
            this.cbDocentiTeorici.Location = new System.Drawing.Point(5, 19);
            this.cbDocentiTeorici.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbDocentiTeorici.Name = "cbDocentiTeorici";
            this.cbDocentiTeorici.Size = new System.Drawing.Size(111, 21);
            this.cbDocentiTeorici.TabIndex = 0;
            this.cbDocentiTeorici.SelectedIndexChanged += new System.EventHandler(this.cbDocentiTeorici_SelectedIndexChanged);
            // 
            // cmDocente
            // 
            this.cmDocente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTaglia,
            this.tsmiCopia,
            this.tsmiIncolla});
            this.cmDocente.Name = "cmDocente";
            this.cmDocente.Size = new System.Drawing.Size(160, 70);
            // 
            // tsmiTaglia
            // 
            this.tsmiTaglia.Image = global::Cattedre.Properties.Resources.taglia;
            this.tsmiTaglia.Name = "tsmiTaglia";
            this.tsmiTaglia.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmiTaglia.Size = new System.Drawing.Size(159, 22);
            this.tsmiTaglia.Text = "Taglia";
            this.tsmiTaglia.Click += new System.EventHandler(this.tsmiTaglia_Click);
            // 
            // tsmiCopia
            // 
            this.tsmiCopia.Image = global::Cattedre.Properties.Resources.copia;
            this.tsmiCopia.Name = "tsmiCopia";
            this.tsmiCopia.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiCopia.Size = new System.Drawing.Size(159, 22);
            this.tsmiCopia.Text = "Copia";
            this.tsmiCopia.Click += new System.EventHandler(this.tsmiCopia_Click);
            // 
            // tsmiIncolla
            // 
            this.tsmiIncolla.Image = global::Cattedre.Properties.Resources.incolla;
            this.tsmiIncolla.Name = "tsmiIncolla";
            this.tsmiIncolla.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmiIncolla.Size = new System.Drawing.Size(159, 22);
            this.tsmiIncolla.Text = "Incolla";
            this.tsmiIncolla.Click += new System.EventHandler(this.tsmiIncolla_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Teorici:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "ITP:";
            // 
            // cbDocentiItip
            // 
            this.cbDocentiItip.ContextMenuStrip = this.cmDocente;
            this.cbDocentiItip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocentiItip.FormattingEnabled = true;
            this.cbDocentiItip.Location = new System.Drawing.Point(5, 64);
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
            this.lblOreTeoria.Location = new System.Drawing.Point(124, 24);
            this.lblOreTeoria.Name = "lblOreTeoria";
            this.lblOreTeoria.Size = new System.Drawing.Size(17, 16);
            this.lblOreTeoria.TabIndex = 16;
            this.lblOreTeoria.Text = "...";
            // 
            // lblOreLaboratorio
            // 
            this.lblOreLaboratorio.AutoSize = true;
            this.lblOreLaboratorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOreLaboratorio.Location = new System.Drawing.Point(124, 69);
            this.lblOreLaboratorio.Name = "lblOreLaboratorio";
            this.lblOreLaboratorio.Size = new System.Drawing.Size(17, 16);
            this.lblOreLaboratorio.TabIndex = 17;
            this.lblOreLaboratorio.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(134, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "h";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(134, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "h";
            // 
            // UcAssegnazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOreLaboratorio);
            this.Controls.Add(this.lblOreTeoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDocentiItip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDocentiTeorici);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "UcAssegnazioni";
            this.Size = new System.Drawing.Size(163, 94);
            this.Load += new System.EventHandler(this.UcAssegnazioni_Load);
            this.cmDocente.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbDocentiTeorici;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbDocentiItip;
        public System.Windows.Forms.Label lblOreTeoria;
        public System.Windows.Forms.Label lblOreLaboratorio;
        private System.Windows.Forms.ContextMenuStrip cmDocente;
        private System.Windows.Forms.ToolStripMenuItem tsmiTaglia;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopia;
        private System.Windows.Forms.ToolStripMenuItem tsmiIncolla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
