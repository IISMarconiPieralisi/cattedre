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

        public long IDdocTh => _iddocth;
        public long IDdocLab => _iddoclab;

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

        private void ImpostaComboBox(ComboBox cb)
        {
            cb.DrawMode = DrawMode.OwnerDrawFixed;
            cb.ItemHeight = 24;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DrawItem -= DisegnaItem; // ✅ evita duplicati se chiamato più volte
            cb.DrawItem += DisegnaItem;
            cb.SelectedIndexChanged += (sender, e) => cb.Invalidate();
        }

        private void DisegnaItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox cb = (ComboBox)sender;
            ProfessoreItem prof = (ProfessoreItem)cb.Items[e.Index];

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color sfondo = (isSelected && cb.DroppedDown)
                ? ControlPaint.Dark(prof.Colore, 0.1f)
                : prof.Colore;

            using (SolidBrush brushSfondo = new SolidBrush(sfondo))
                e.Graphics.FillRectangle(brushSfondo, e.Bounds);

            Color coloreTesto = IsColoreChiaro(prof.Colore) ? Color.Black : Color.White;

            using (SolidBrush brushTesto = new SolidBrush(coloreTesto))
            {
                StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(prof.NomeCompleto, e.Font, brushTesto, e.Bounds, sf);
            }

            if (isSelected && cb.DroppedDown)
            {
                using (Pen pen = new Pen(Color.White, 1))
                    e.Graphics.DrawRectangle(pen,
                        e.Bounds.X, e.Bounds.Y,
                        e.Bounds.Width - 1, e.Bounds.Height - 1);
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

                if (coloreDB.StartsWith("#"))
                    return ColorTranslator.FromHtml(coloreDB);

                if (long.TryParse(coloreDB, out long val))
                {
                    int r = (int)((val >> 16) & 0xFF);
                    int g = (int)((val >> 8) & 0xFF);
                    int b = (int)(val & 0xFF);
                    return Color.FromArgb(r, g, b);
                }
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
            if (cbDocentiTeorici.SelectedItem is ProfessoreItem prof)
                _iddocth = prof.ID;
            else
                _iddocth = 0;
        }

        private void cbDocentiItip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDocentiItip.SelectedItem is ProfessoreItem prof)
                _iddoclab = prof.ID;
            else
                _iddoclab = 0;
        }

        // CaricaProfessori chiamata UNA SOLA VOLTA, nel Load
        private void UcAssegnazioni_Load(object sender, EventArgs e)
        {
            
        }

        public void CaricaDocentiColorati(DataTable docenti)
        {
            cbDocentiTeorici.DataSource = null;
            cbDocentiItip.DataSource = null;
            cbDocentiTeorici.Items.Clear();
            cbDocentiItip.Items.Clear();

            ImpostaComboBox(cbDocentiTeorici);
            ImpostaComboBox(cbDocentiItip);

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

        }

        private void tsmiCopia_Click(object sender, EventArgs e)
        {

        }

        private void tsmiIncolla_Click(object sender, EventArgs e)
        {

        }
    }


}
    
