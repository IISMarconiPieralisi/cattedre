using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cattedre
{
    public partial class UcDisciplina : UserControl
    {
        public UcDisciplina(ClsDisciplinaDL clsDisciplinaDL, string nomeCompleto)
        {
            InitializeComponent();
            string nomeTagliato = clsDisciplinaDL.Nome;

            AggiornaLabel(nomeTagliato, lbldisciplina);

            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this, nomeCompleto);
            toolTip.SetToolTip(lbldisciplina, nomeCompleto);
        }

        private void AggiornaLabel(string nuovoTesto, Label label1) // Per allineare la label al centro
        {
            label1.Text = nuovoTesto;
            Size textSize = TextRenderer.MeasureText(nuovoTesto, label1.Font);
            label1.Width = textSize.Width;
            label1.Left = (this.Width / 2) - (label1.Width / 2);
        }
    }
}
