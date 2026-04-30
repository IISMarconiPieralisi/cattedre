using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cattedre
{
    public partial class FrmCredits : Form
    {
        public FrmCredits()
        {
            InitializeComponent();
        }



        private void PopolaListViewConX(List<ClsPersona> persone)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            // Prendo i testi delle colonne dalla ListView (Designer)
            // Le prime 2 colonne devono essere Cognome e Nome
            var colonneForm = listView1.Columns
                .Cast<ColumnHeader>()
                .Skip(2)
                .Select(c => c.Text)
                .ToList();

            foreach (var p in persone)
            {
                var item = new ListViewItem(p.Cognome); // colonna 0
                item.SubItems.Add(p.Nome);              // colonna 1

                // aggiungo un subitem per ogni colonna-form
                foreach (var colName in colonneForm)
                {
                    item.SubItems.Add(p.FormsFatte.Contains(colName) ? "X" : "");
                }

                listView1.Items.Add(item);
            }

            listView1.EndUpdate();
        }


         private void listView1_SelectedIndexChanged(object sender, EventArgs e)
         {

         }

        private void FrmCredits_Load(object sender, EventArgs e)
        {


            // Se la ListView è già fatta dal Designer, assicurati solo che sia in Details
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            var persone = new List<ClsPersona>
            {
                // todo aggiungere nomi reali 
            new ClsPersona("Brutti", "Luca", new[] { "Home", "Login", "Grafica","DataBase","Form Dipartimento","Credits","Form Cattedre"}),
            new ClsPersona("Scotichini", "Matteo", new[] {"DataBase", "Form CDC", "Form Indirizzo", "Form Disciplina "}),
            new ClsPersona("Pierigè", "Samuel", new[] { "DataBase","Form Cattedre", "Form Utenti","Login","Home", "Form Classe"}),
            new ClsPersona("Vagnini", "Natan", new[] { "Form Cattedre","Home", "Form Disciplina ","DataBase" ,"Form CDC"}),
            new ClsPersona("Tornari", "Lorenzo", new[] { "Form Disciplina ", "Form A.s", "Form Classe" }),
            new ClsPersona("Ercoli", "Mattia", new[] { "DataBase", "Form CDC", "Form Indirizzo", "Form Dipartimento",
                "Form Utenti", "Form Contratto","Form Cattedre","Form Disciplina ", "Form A.s", "Form Classe","Grafica","Home", "Login" }),

            };

            PopolaListViewConX(persone);
        }
    }
}
