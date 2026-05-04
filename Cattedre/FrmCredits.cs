using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Cattedre
{
    public partial class FrmCredits : Form
    {
        private static readonly string[] AllForms = {
            "DataBase","Login","Home","Form A.s","Form Cattedre","Form CDC",
            "Form Classe","Form Contratto","Form Dipartimento","Form Disciplina",
            "Form Indirizzo","Form Utenti","Grafica","Credits"
        };

        private static readonly Color[] AccentColors = {
            Color.FromArgb(83,74,183),
            Color.FromArgb(15,110,86),
            Color.FromArgb(24,95,165),
            Color.FromArgb(153,60,29),
            Color.FromArgb(133,79,11),
            Color.FromArgb(153,53,86)
        };

        private List<ClsPersona> _persone;
        private FlowLayoutPanel _flow;
        private Panel _scroll;
        private Panel _sidebar;

        public FrmCredits()
        {
            InitializeComponent();
            this.Text = "Credits — Progetto Prof. Pigini & Alfieri";
            this.BackColor = Color.FromArgb(245, 245, 243);
            this.Size = new Size(1280, 800);
            this.MinimumSize = new Size(900, 600);
        }

        private void FrmCredits_Load(object sender, EventArgs e)
        {
            _persone = new List<ClsPersona>
            {
                new ClsPersona("Brutti",     "Luca",    new[]{"Home","Login","Grafica","DataBase","Form Dipartimento","Credits","Form Cattedre"}),
                new ClsPersona("Scotichini", "Matteo",  new[]{"DataBase","Form CDC","Form Indirizzo","Form Disciplina"}),
                new ClsPersona("Pierigè",    "Samuel",  new[]{"DataBase","Form Cattedre","Form Utenti","Login","Home","Form Classe"}),
                new ClsPersona("Vagnini",    "Natan",   new[]{"Form Cattedre","Home","Form Disciplina","DataBase","Form CDC"}),
                new ClsPersona("Tornari",    "Lorenzo", new[]{"Form Disciplina","Form A.s","Form Classe"}),
                new ClsPersona("Ercoli",     "Mattia",  new[]{"DataBase","Form CDC","Form Indirizzo","Form Dipartimento",
                    "Form Utenti","Form Contratto","Form Cattedre","Form Disciplina","Form A.s","Form Classe","Grafica","Home","Login"}),
            };

            BuildUI();
        }

        private void BuildUI()
        {
            this.Controls.Clear();
            this.SuspendLayout();

            // ── Sidebar destra (disclaimer) ───────────────────────────────────
            _sidebar = new Panel
            {
                Dock = DockStyle.Right,
                Width = 250,                                  // aumentato da 220 a 250
                BackColor = Color.FromArgb(245, 245, 243),
                Padding = new Padding(12, 20, 12, 12),
            };
            BuildSidebar();
            this.Controls.Add(_sidebar);

            // ── Scroll + cards (Fill) ─────────────────────────────────────────
            _scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(245, 245, 243),
            };

            _flow = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(16, 14, 16, 16),
                Dock = DockStyle.Top,
            };

            for (int i = 0; i < _persone.Count; i++)
                _flow.Controls.Add(BuildStudentCard(_persone[i], i));

            _scroll.Controls.Add(_flow);
            this.Controls.Add(_scroll);

            // ── Stats (Top) ───────────────────────────────────────────────────
            BuildStatsBar();

            // ── Header (Top — ultima = visivamente prima) ─────────────────────
            BuildHeader();

            this.ResumeLayout();
            this.BeginInvoke((Action)RefreshCardSizes);
        }

        // ── Sidebar con disclaimer in giallo ──────────────────────────────────
        private void BuildSidebar()
        {
            // separatore verticale sinistro
            _sidebar.Paint += (s, pe) =>
                pe.Graphics.DrawLine(new Pen(Color.FromArgb(30, 0, 0, 0)),
                    0, 0, 0, _sidebar.Height);

            // box disclaimer — MODIFICATO: colori gialli
            var box = new Panel
            {
                BackColor = Color.FromArgb(255, 251, 200),   // giallo chiaro
                Dock = DockStyle.None,
                Width = 224,                                  // aumentato da 196
                AutoSize = false,
                Location = new Point(12, 20),
                Padding = new Padding(12, 12, 12, 12),
            };

            var icon = new Label
            {
                Text = "ℹ",
                Font = new Font("Segoe UI", 16f),
                ForeColor = Color.FromArgb(133, 100, 0),     // oro scuro
                AutoSize = true,
                Location = new Point(12, 10),
            };

            var title = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 72, 0),      // marrone dorato
                AutoSize = true,
                Location = new Point(38, 13),
            };

            var body = new Label
            {
                Text = "Il numero di form realizzate non quantifica il lavoro complessivo svolto da ogni studente.",
                Font = new Font("Segoe UI", 9f, FontStyle.Italic),
                ForeColor = Color.FromArgb(80, 55, 0),       // testo scuro leggibile
                AutoSize = false,
                Width = 200,                                  // aumentato da 172
                Height = 90,
                Location = new Point(12, 44),
            };

            box.Controls.Add(icon);
            box.Controls.Add(title);
            box.Controls.Add(body);
            box.Height = 148;
            // NON applicare ApplyRoundRegion al box — evita il clipping dei controlli interni
            // ApplyRoundRegion(box, 8);  ← rimosso

            _sidebar.Controls.Add(box);
        }

        private void RefreshCardSizes()
        {
            SetCardWidths();
            this.BeginInvoke((Action)FixCardHeights);
        }

        private void SetCardWidths()
        {
            int availW = _scroll.ClientSize.Width - 48;
            int cardW = Math.Max(380, (availW - 12) / 2);
            _flow.Width = _scroll.ClientSize.Width;

            foreach (Control c in _flow.Controls)
            {
                if (!(c is Panel card)) continue;
                card.Width = cardW;

                foreach (Control child in card.Controls)
                    if (child is FlowLayoutPanel tf)
                        tf.Width = cardW - 24;

                ApplyRoundRegion(card, 10);
            }
        }

        private void FixCardHeights()
        {
            foreach (Control c in _flow.Controls)
            {
                if (!(c is Panel card)) continue;

                FlowLayoutPanel tagFlow = null;
                foreach (Control child in card.Controls)
                    if (child is FlowLayoutPanel f) { tagFlow = f; break; }

                if (tagFlow == null) continue;

                int newH = tagFlow.Location.Y + tagFlow.Height + 18;
                card.Height = Math.Max(160, newH);

                foreach (Control child in card.Controls)
                    if (child is Panel stripe && stripe.Width == 5)
                        stripe.Height = card.Height;

                ApplyRoundRegion(card, 10);
            }
        }

        // ── Header ────────────────────────────────────────────────────────────
        private void BuildHeader()
        {
            var header = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.White };
            header.Paint += (s, pe) =>
                pe.Graphics.DrawLine(new Pen(Color.FromArgb(28, 0, 0, 0)),
                    0, header.Height - 1, header.Width, header.Height - 1);

            header.Controls.Add(new Label
            {
                Text = "Credits — Progetto assegnato dai Prof. Pigini & Alfieri, a.s. 24/25 – 25/26",
                Font = new Font("Segoe UI", 13f),
                ForeColor = Color.FromArgb(25, 25, 25),
                AutoSize = true,
                Location = new Point(24, 12)
            });
            header.Controls.Add(new Label
            {
                Text = "Studenti della classe 5BM coinvolti nel progetto, a.s. 25/26",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(120, 120, 110),
                AutoSize = true,
                Location = new Point(24, 42)
            });

            this.Controls.Add(header);
        }

        // ── Stats bar ─────────────────────────────────────────────────────────
        private void BuildStatsBar()
        {
            int avgPct = (int)Math.Round(
                _persone.Average(p => (double)p.FormsFatte.Count / AllForms.Length * 100));

            var stats = new (string Label, string Value)[] {
                ("Studenti",        _persone.Count.ToString()),
                ("Moduli totali",   AllForms.Length.ToString()),
                ("Assegnazioni",    _persone.Sum(p => p.FormsFatte.Count).ToString()),
                ("Copertura media", avgPct + "%"),
            };

            var bar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = Color.FromArgb(245, 245, 243),
                Padding = new Padding(16, 12, 16, 8)
            };
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            for (int i = 0; i < 4; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));

            for (int i = 0; i < stats.Length; i++)
            {
                var (label, value) = stats[i];
                var sc = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    Margin = new Padding(0, 0, i < 3 ? 10 : 0, 0)
                };
                ApplyRoundRegion(sc, 8);

                var inner = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    RowCount = 2,
                    ColumnCount = 1,
                    BackColor = Color.Transparent,
                    Padding = new Padding(10, 8, 8, 4)
                };
                inner.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
                inner.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
                inner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

                inner.Controls.Add(new Label
                {
                    Text = label.ToUpper(),
                    Font = new Font("Segoe UI", 7.5f),
                    ForeColor = Color.FromArgb(130, 130, 120),
                    Dock = DockStyle.Fill,
                    AutoSize = false
                }, 0, 0);
                inner.Controls.Add(new Label
                {
                    Text = value,
                    Font = new Font("Segoe UI", 20f),
                    ForeColor = Color.FromArgb(25, 25, 25),
                    Dock = DockStyle.Fill,
                    AutoSize = false
                }, 0, 1);

                sc.Controls.Add(inner);
                table.Controls.Add(sc, i, 0);
            }

            bar.Controls.Add(table);
            this.Controls.Add(bar);
        }

        // ── Card studente ─────────────────────────────────────────────────────
        private Panel BuildStudentCard(ClsPersona p, int index)
        {
            Color accent = AccentColors[index % AccentColors.Length];
            Color lightAccent = Lighten(accent, 0.88f);
            Color darkAccent = Darken(accent, 0.15f);

            int done = p.FormsFatte.Count;
            int total = AllForms.Length;
            int pct = (int)Math.Round(done / (double)total * 100);
            string ini = p.Cognome[0].ToString() + p.Nome[0].ToString();

            var card = new Panel
            {
                Width = 900,
                Height = 200,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 12, 12)
            };
            ApplyRoundRegion(card, 10);

            // striscia sinistra
            var stripe = new Panel { Width = 5, Height = 200, BackColor = accent, Location = Point.Empty };
            card.Controls.Add(stripe);

            // avatar
            var av = new Panel { Width = 44, Height = 44, BackColor = accent, Location = new Point(18, 16) };
            ApplyRoundRegion(av, 22);
            string avIni = ini;
            av.Paint += (s, pe) => {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var fmt = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                pe.Graphics.DrawString(avIni, new Font("Segoe UI", 14f), Brushes.White, new RectangleF(0, 0, 44, 44), fmt);
            };
            card.Controls.Add(av);

            card.Controls.Add(new Label
            {
                Text = p.Cognome + " " + p.Nome,
                Font = new Font("Segoe UI", 12f),
                ForeColor = Color.FromArgb(25, 25, 25),
                Location = new Point(70, 14),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = $"{done} su {total} moduli completati",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(120, 120, 110),
                Location = new Point(71, 40),
                AutoSize = true
            });

            // donut
            const int donutSz = 90;
            var donut = new PictureBox
            {
                Width = donutSz,
                Height = donutSz,
                Location = new Point(16, 74),
                BackColor = Color.Transparent
            };
            int pctD = pct; Color accD = accent; Color liD = lightAccent;
            donut.Paint += (s, pe) => DrawDonut(pe.Graphics, pctD, accD, liD, donutSz);
            card.Controls.Add(donut);

            var pctLbl = new Label
            {
                Text = pct + "%",
                Font = new Font("Segoe UI", 9f),
                ForeColor = accent,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            card.Controls.Add(pctLbl);
            pctLbl.Location = new Point(
                16 + (donutSz - pctLbl.Width) / 2,
                74 + (donutSz - pctLbl.Height) / 2);

            // tag — MODIFICATO: font e padding ridotti per mostrare tutti i moduli su più righe
            int tagY = 74 + donutSz + 10;
            var tagFlow = new FlowLayoutPanel
            {
                Width = 556,
                AutoSize = true,
                Location = new Point(16, tagY),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,                         // va a capo automaticamente
                BackColor = Color.Transparent,
            };

            foreach (var form in p.FormsFatte)
            {
                tagFlow.Controls.Add(new Label
                {
                    Text = form,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 7.5f),       // ridotto da 8.5 a 7.5 per più spazio
                    ForeColor = darkAccent,
                    BackColor = lightAccent,
                    Padding = new Padding(5, 3, 5, 3),       // ridotto da 7,4 a 5,3
                    Margin = new Padding(0, 0, 4, 5),        // ridotto da 6,6 a 4,5
                });
            }
            card.Controls.Add(tagFlow);

            return card;
        }

        // ── Donut GDI+ ────────────────────────────────────────────────────────
        private static void DrawDonut(Graphics g, int pct, Color accent, Color light, int size)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            const int margin = 7, thickness = 13;
            var rect = new Rectangle(margin, margin, size - margin * 2, size - margin * 2);

            using (var pen = new Pen(light, thickness) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                g.DrawArc(pen, rect, -90, 360);

            float sweep = 360f * pct / 100f;
            if (sweep > 0.5f)
                using (var pen = new Pen(accent, thickness) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                    g.DrawArc(pen, rect, -90, sweep);
        }

        // ── Utilità ───────────────────────────────────────────────────────────
        private static Color Lighten(Color c, float t) => Color.FromArgb(
            Clamp((int)(c.R + (255 - c.R) * t)), Clamp((int)(c.G + (255 - c.G) * t)), Clamp((int)(c.B + (255 - c.B) * t)));

        private static Color Darken(Color c, float t) => Color.FromArgb(
            Clamp((int)(c.R * (1 - t))), Clamp((int)(c.G * (1 - t))), Clamp((int)(c.B * (1 - t))));

        private static int Clamp(int v) => Math.Max(0, Math.Min(255, v));

        private static void ApplyRoundRegion(Control ctrl, int radius)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
            var path = new GraphicsPath();
            int d = radius * 2, w = ctrl.Width, h = ctrl.Height;
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(w - d, 0, d, d, 270, 90);
            path.AddArc(w - d, h - d, d, d, 0, 90);
            path.AddArc(0, h - d, d, d, 90, 90);
            path.CloseAllFigures();
            ctrl.Region = new Region(path);
        }
    }
}