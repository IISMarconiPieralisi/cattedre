namespace Cattedre
{
    partial class FrmCredits
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
            System.Windows.Forms.ColumnHeader chCognome;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chlogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAnnoScolastico = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCattedre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCdc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClasse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chContratti = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDipartimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDisciplina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndirizzi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUtenti = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGrafica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCredits = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            chCognome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // chCognome
            // 
            chCognome.Text = "Cognome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Progetto assegnato dai Prof.Pigini e Alfieri as24/25 - 25/26";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sono stati coinvolti i seguenti studenti della 5BM as25/26";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            chCognome,
            this.chNome,
            this.chDB,
            this.chlogin,
            this.chHome,
            this.chAnnoScolastico,
            this.chCattedre,
            this.chCdc,
            this.chClasse,
            this.chContratti,
            this.chDipartimento,
            this.chDisciplina,
            this.chIndirizzi,
            this.chUtenti,
            this.chGrafica,
            this.chCredits});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 75);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1178, 404);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            // 
            // chDB
            // 
            this.chDB.Text = "DataBase";
            // 
            // chlogin
            // 
            this.chlogin.Text = "Login";
            // 
            // chHome
            // 
            this.chHome.Text = "Home";
            // 
            // chAnnoScolastico
            // 
            this.chAnnoScolastico.Text = "Form A.s";
            // 
            // chCattedre
            // 
            this.chCattedre.Text = "Form Cattedre";
            this.chCattedre.Width = 86;
            // 
            // chCdc
            // 
            this.chCdc.Text = "Form CDC";
            // 
            // chClasse
            // 
            this.chClasse.Text = "Form Classe";
            this.chClasse.Width = 81;
            // 
            // chContratti
            // 
            this.chContratti.Text = "Form Contratto";
            this.chContratti.Width = 86;
            // 
            // chDipartimento
            // 
            this.chDipartimento.Text = "Form Dipartimento";
            this.chDipartimento.Width = 111;
            // 
            // chDisciplina
            // 
            this.chDisciplina.Text = "Form Disciplina ";
            this.chDisciplina.Width = 98;
            // 
            // chIndirizzi
            // 
            this.chIndirizzi.Text = "Form Indirizzo";
            this.chIndirizzi.Width = 85;
            // 
            // chUtenti
            // 
            this.chUtenti.Text = "Form Utenti";
            this.chUtenti.Width = 78;
            // 
            // chGrafica
            // 
            this.chGrafica.Text = "Grafica";
            // 
            // chCredits
            // 
            this.chCredits.Text = "Credits";
            // 
            // FrmCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 661);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCredits";
            this.Text = "Credits";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCredits_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chDB;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chlogin;
        private System.Windows.Forms.ColumnHeader chHome;
        private System.Windows.Forms.ColumnHeader chAnnoScolastico;
        private System.Windows.Forms.ColumnHeader chCattedre;
        private System.Windows.Forms.ColumnHeader chCdc;
        private System.Windows.Forms.ColumnHeader chClasse;
        private System.Windows.Forms.ColumnHeader chContratti;
        private System.Windows.Forms.ColumnHeader chDipartimento;
        private System.Windows.Forms.ColumnHeader chDisciplina;
        private System.Windows.Forms.ColumnHeader chIndirizzi;
        private System.Windows.Forms.ColumnHeader chUtenti;
        private System.Windows.Forms.ColumnHeader chGrafica;
        private System.Windows.Forms.ColumnHeader chCredits;
    }
}