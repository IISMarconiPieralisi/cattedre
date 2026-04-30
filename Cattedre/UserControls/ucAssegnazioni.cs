using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.Configuration;

namespace Cattedre
{
    public partial class UcAssegnazioni : UserControl
    {
        private long _iddocth = 0;
        private long _iddoclab = 0;

        private static long _clipboardIDDocente = 0;
        private static string _clipboardTipo = ""; // "T" o "L"

        public long IDdocTh => _iddocth;
        public long IDdocLab => _iddoclab;

        public DataTable DocentiData { get; set; }

        public class ProfessoreItem
        {
            public int ID { get; set; }
            public string NomeCompleto { get; set; }
            public Color Colore { get; set; }
            public override string ToString() => NomeCompleto;
        }

        static ClsUtenteDL docente = new ClsUtenteDL();
        public FrmCattedre frmCattedre = new FrmCattedre(docente);

        public UcAssegnazioni(ClsDisciplinaDL clsDisciplinaDL, ClsClasseDL clsClasseDL, ClsUtenteDL docente)
        {
            InitializeComponent();

        }

        public UcAssegnazioni()
        {
            InitializeComponent();

          
        }

        #region Colori Professori

        public void ImpostaColoriCombo(ComboBox cb)
        {
            cb.DrawMode = DrawMode.OwnerDrawFixed;
            cb.ItemHeight = 24;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DrawItem -= DisegnaItemUtente; // evita duplicati se chiamato più volte
            cb.DrawItem += DisegnaItemUtente;
            cb.SelectedIndexChanged += (sender, e) => cb.Invalidate();
        }

        private void DisegnaItemUtente(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox cb = (ComboBox)sender;
            ClsUtenteDL utente = (ClsUtenteDL)cb.Items[e.Index];

            if (utente.ID == 0)
            {
                using (SolidBrush brush = new SolidBrush(Color.White))
                    e.Graphics.FillRectangle(brush, e.Bounds);
                return;
            }

            Color colore = ParseColoreDB(utente.Colore);

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color sfondo = (isSelected && cb.DroppedDown)
                ? ControlPaint.Dark(colore, 0.1f)
                : colore;

            using (SolidBrush brushSfondo = new SolidBrush(sfondo))
                e.Graphics.FillRectangle(brushSfondo, e.Bounds);

            Color coloreTesto = IsColoreChiaro(colore) ? Color.Black : Color.White;

            using (SolidBrush brushTesto = new SolidBrush(coloreTesto))
            {
                StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center };

                string nomeCorto = string.IsNullOrEmpty(utente.Nome) ? "" :
                                  (utente.Nome.Length > 3 ? utente.Nome.Substring(0, 3) + "." : utente.Nome);
                string testoDaMostrare = $"{utente.Cognome} {nomeCorto}";

                e.Graphics.DrawString(testoDaMostrare, e.Font, brushTesto, e.Bounds, sf);
            }
        }



        // Converte il campo colore del DB (es. "000000064" oppure "#FF5733") in Color
        public static Color ParseColoreDB(string coloreDB)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(coloreDB))
                    return Color.LightGray;
                coloreDB = coloreDB.Trim();
                return FrmUtente.OttieniColore(coloreDB);
                
            }
            catch { }

            return Color.LightGray;
        }

        private bool IsColoreChiaro(Color c)
        {
            double lum = (0.299 * c.R + 0.587 * c.G + 0.114 * c.B) / 255;
            return lum > 0.5;
        }


        #endregion
        // FIX: ora salva l'ID reale del professore, non l'indice
        private void cbDocentiTeorici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDocentiTeorici.SelectedItem is ClsUtenteDL utente)
            {
                _iddocth = utente.ID;

                // Cerca tipoContratto nel DataTable
                var riga = DocentiData?.AsEnumerable()
                    .FirstOrDefault(r => r["IDutente"] != DBNull.Value &&
                                         Convert.ToInt64(r["IDutente"]) == utente.ID);

                string tipoContratto = (riga == null || riga["tipoContratto"] == DBNull.Value) ? ""
                       : riga["tipoContratto"].ToString();

                lblDocentiNonDiRuoloTEORICI.Visible = tipoContratto == "D";
            }
            else
            {
                _iddocth = 0;
                lblDocentiNonDiRuoloTEORICI.Visible = false;
            }
        }

        private void cbDocentiItip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDocentiItip.SelectedItem is ClsUtenteDL utente)
            {
                _iddoclab = utente.ID;

                var riga = DocentiData?.AsEnumerable()
                    .FirstOrDefault(r => r["IDutente"] != DBNull.Value &&
                                         Convert.ToInt64(r["IDutente"]) == utente.ID);

                string tipoContratto = (riga == null || riga["tipoContratto"] == DBNull.Value) ? ""
                       : riga["tipoContratto"].ToString();

                lblDocentiNonDiRuoloITP.Visible = tipoContratto == "D";
            }
            else
            {
                _iddoclab = 0;
                lblDocentiNonDiRuoloITP.Visible = false;
            }
        }

        // CaricaProfessori chiamata UNA SOLA VOLTA, nel Load
        private void UcAssegnazioni_Load(object sender, EventArgs e)
        {
            // Disabilita lo scrolling con la rotellina per entrambe le combo box
            DisabilitaScrollRotella(cbDocentiTeorici);
            DisabilitaScrollRotella(cbDocentiItip);
        }

        private void DisabilitaScrollRotella(ComboBox cb)
        {
            cb.MouseWheel += (s, ev) => ((HandledMouseEventArgs)ev).Handled = true;
        }
        public void CaricaDocentiColorati(DataTable docenti)
        {
            cbDocentiTeorici.DataSource = null;
            cbDocentiItip.DataSource = null;
            cbDocentiTeorici.Items.Clear();
            cbDocentiItip.Items.Clear();

            ImpostaColoriCombo(cbDocentiTeorici);
            ImpostaColoriCombo(cbDocentiItip);

            cbDocentiTeorici.Items.AddRange(
                ClsAssegnareBL.FiltraDocentiPerComboBox(docenti, "T").ToArray());
            cbDocentiItip.Items.AddRange(
                ClsAssegnareBL.FiltraDocentiPerComboBox(docenti, "L").ToArray());
        }

        //preseleziona i docenti nella combo (utile quando riapri una riga esistente)
        public void ImpostaDocentiSelezionati(long idDocenteTeorico, long idDocenteLab)
        {
            SelezionaInCombo(cbDocentiTeorici, idDocenteTeorico);
            SelezionaInCombo(cbDocentiItip, idDocenteLab);
        }

        private void SelezionaInCombo(ComboBox cb, long idDocente)
        {
            if (idDocente <= 0) return;

            foreach (var item in cb.Items)
            {
                if (item is ProfessoreItem prof && prof.ID == idDocente)
                {
                    cb.SelectedItem = item;
                    return;
                }
            }
        }

        private void tsmiTaglia_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip cm = (ContextMenuStrip)tsmi.GetCurrentParent();
            Control cb = cm.SourceControl;

            if (cb.Name == cbDocentiTeorici.Name && cbDocentiTeorici.SelectedItem is ClsUtenteDL ut && ut.ID > 0)
            {
                _clipboardIDDocente = ut.ID;
                _clipboardTipo = "T";
                cbDocentiTeorici.SelectedIndex = 0; // deseleziona (voce vuota)
            }
            else if (cb.Name == cbDocentiItip.Name && cbDocentiItip.SelectedItem is ClsUtenteDL ul && ul.ID > 0)
            {
                _clipboardIDDocente = ul.ID;
                _clipboardTipo = "L";
                cbDocentiItip.SelectedIndex = 0;
            }
        }

        private void tsmiCopia_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip cm = (ContextMenuStrip)tsmi.GetCurrentParent();
            Control cb = cm.SourceControl;

            if (cb.Name == cbDocentiTeorici.Name && cbDocentiTeorici.SelectedItem is ClsUtenteDL ut && ut.ID > 0)
            {
                _clipboardIDDocente = ut.ID;
                _clipboardTipo = "T";
            }
            else if (cb.Name == cbDocentiItip.Name && cbDocentiItip.SelectedItem is ClsUtenteDL ul && ul.ID > 0)
            {
                _clipboardIDDocente = ul.ID;
                _clipboardTipo = "L";
            }
        }

        private void tsmiIncolla_Click(object sender, EventArgs e)
        {
            if (_clipboardIDDocente <= 0) return;

            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip cm = (ContextMenuStrip)tsmi.GetCurrentParent();
            Control cb = cm.SourceControl;

            ComboBox target = cb.Name == cbDocentiTeorici.Name ? cbDocentiTeorici : cbDocentiItip;

            // cerca il docente nella combo di destinazione e lo seleziona
            foreach (var item in target.Items)
            {
                if (item is ClsUtenteDL u && u.ID == _clipboardIDDocente)
                {
                    target.SelectedItem = item;
                    return;
                }
            }

            MessageBox.Show("Il docente non è disponibile in questa lista.", "Incolla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }


}
    
