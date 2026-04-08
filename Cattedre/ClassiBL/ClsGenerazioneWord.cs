using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Cattedre
{
    public static class ClsGenerazioneWord
    {
        private static readonly Xceed.Drawing.Color GialloEvidenziazione = Xceed.Drawing.Color.Yellow;
        private static readonly Xceed.Drawing.Color GrigioIntestazione = Xceed.Drawing.Color.GrayText;
        private const string FontName = "Arial";
        private const double FontSize = 9;


        public static void PreparazioneCreazioneFile(ClsAnnoScolasticoDL anno,ClsDipartimentoDL dipartimento)
        {
            List<ClsUtenteDL> Docenti/*metodo prendere utente di quel dipartimento*/;
            List<ClsAssegnareDL> assegnare = ClsAssegnareBL.PopolaAssegnazioni();
            List<ClsClasseDiConcorsoDL> cdc = ClsClasseDiConcorsoBL.CaricaCDCperDisciplina(dipartimento.ID);
           // List<ClsDisciplinaDL> discipline =ClsGestireBL.
        }
        public static void GenerateFileWord(ClsAnnoScolasticoDL As, List<ClsClasseDiConcorsoDL>  listClassiConcorso,List<ClsUtenteDL> listDocenti,
                                            List<ClsAssegnareDL> listAssegnazioni, List<ClsDisciplinaDL> listDiscipline,     
                                            List<ClsClasseDL>listClassi,List<ClsDotareDL>listDotare,
                                            List<ClsContrattoDL>listContratti,string outputPath)
        {
            using (DocX doc = DocX.Create(outputPath))
            {
                doc.PageWidth = 595f;
                doc.PageHeight = 842f;
                doc.MarginTop = 36f;
                doc.MarginBottom = 36f;
                doc.MarginLeft = 36f;
                doc.MarginRight = 36f;
                foreach (var CDC in listClassiConcorso)
                {
                    ClsDotareDL dotCDC = listDotare.FirstOrDefault(p => p.IdClasseDiConcorso == CDC.ID);
                    InserisciIntestazioneConcorso(doc,CDC, dotCDC);
                }

                // ── CICLO DOCENTI di questa classe di concorso ────────────────
                // TODO: var docentiClasse = listDocenti
                //           .Where(u => listAssegnazioni
                //               .Any(a => a.IDdisciplina == /* disciplina della classe */
                //                      && a.IDutente == u.ID))
                //           .ToList();
                //
                // TODO: foreach (var docente in docentiClasse)
                // {
                // TODO: var righeDocente = listAssegnazioni
                //           .Where(a => a.IDutente == docente.ID)
                //           .ToList();

                //InserisciDocente(
                //    doc,
                //    cognome:  /* TODO: docente.cognome */ "",
                //    nome:     /* TODO: docente.nome    */ "",
                //    totaleOre:/* TODO: contratto.monteOre  (join su listContratti dove IDutente == docente.ID)
                //                           oppure somma delle ore da listAssegnazioni */ "",
                //    righe: BuildRigheDocente(
                //              /* TODO: righeDocente, listDiscipline, listClassi */
                //              )
                //);
                // }  // fine foreach docenti

                // ── NOTE FINALI (ore potenziamento residue) ───────────────────
                // TODO: se esistono ore residue per questa classe di concorso:
                // InserisciNotaFinale(
                //     doc,
                //     titolo: $"ORE POTENZIAMENTO RESIDUE {classeConcorso.livello} (da distribuire ai docenti interessati)",
                //     righe:  BuildRighePotenziamento(/* ore residue */),
                //     totale: /* ore residue totali */
                // );

                // }  // fine foreach classeConcorso

                doc.Save();
            }

                // Pagina A4 con margini stretti (~1.27 cm)
              

            // ── CICLO PRINCIPALE: una sezione per ogni classe di concorso ─────
            // TODO: foreach (var classeConcorso in listClassiConcorso)
            // {
           
        }

        // ─────────────────────────────────────────────────────────────────────
        //  COSTRUZIONE RIGHE TABELLA DAL DB
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Trasforma le assegnazioni del docente in righe pronte per la tabella.
        /// Compila i TODO con i join sulle tue liste.
        /// </summary>
        private static List<(string ore, string materia, string classe, bool evidenziata, bool barrato)>
            BuildRigheDocente(/* TODO: List<ClsAssegnareDL> assegnazioni,
                                       List<ClsDisciplineDL> discipline,
                                       List<ClsClassiDL> classi */)
        {
            var result = new List<(string, string, string, bool, bool)>();

            // TODO: foreach (var assegnazione in assegnazioni)
            // {
            //     var disciplina = discipline.FirstOrDefault(d => d.ID == assegnazione.IDdisciplina);
            //     var classe     = classi.FirstOrDefault(c => c.ID == assegnazione.IDclasse);
            //
            //     result.Add((
            //         ore:         /* TODO: assegnazione.oreSpeciali.ToString()
            //                               oppure disciplina.oreTeoria.ToString() */ "",
            //         materia:     /* TODO: disciplina.nome */ "",
            //         classe:      /* TODO: $"{classe.anno}^{classe.sezione}" */ "",
            //         evidenziata: /* TODO: tua logica — es. disciplina.nome == "INTELLIGENZA ARTIFICIALE" */ false,
            //         barrato:     /* TODO: tua logica — es. potenziamento animatore digitale */ false
            //     ));
            // }

            return result;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  GRAFICA: INTESTAZIONE CLASSE DI CONCORSO
        // ─────────────────────────────────────────────────────────────────────

        private static void InserisciIntestazioneConcorso(DocX doc,
            ClsClasseDiConcorsoDL cdc, ClsDotareDL dot)
        {
            var p1 = doc.InsertParagraph();
            p1.SpacingBefore(10);
            p1.Append("CLASSE DI CONCORSO:")
              .Bold().Font(FontName).FontSize(11)
              .CapsStyle(CapsStyle.smallCaps);

            var p2 = doc.InsertParagraph();
            p2.Append($"{cdc.Livello} - {cdc.Nome}")
              .Bold().Font(FontName).FontSize(11)
              .CapsStyle(CapsStyle.smallCaps);

            if (dot!=null && dot.Id>0)
            {
                var pR = doc.InsertParagraph();
                pR.SpacingAfter(4);
                pR.Append($"{dot.NumcattedreDiritto} cattedre" /* + {oreResiduo} h residue"*/)
                  .Bold().Font(FontName).FontSize(10);
            }
        }

        private static void InserisciDocente(DocX doc,
            string cognome, string nome, string totaleOre,
            List<(string ore, string materia, string classe, bool evidenziata, bool barrato)> righe)
        {
            var pNome = doc.InsertParagraph();
            pNome.SpacingBefore(6);
            pNome.Append($"Docenter {cognome} {nome}")
                 .Bold().Italic()
                 .UnderlineStyle(UnderlineStyle.singleLine)
                 .Font(FontName).FontSize(10);

            InserisciTabella(doc, righe, totaleOre);
        }
        private static void InserisciNotaFinale(DocX doc, string titolo,
            List<(string ore, string materia, string classe, bool evidenziata, bool barrato)> righe,
            string totale)
        {
            var pTitolo = doc.InsertParagraph();
            pTitolo.SpacingBefore(8);
            pTitolo.Append(titolo)
                   .Bold().Italic()
                   .UnderlineStyle(UnderlineStyle.singleLine)
                   .Font(FontName).FontSize(10);

            InserisciTabella(doc, righe, totale);
        }

        private static void InserisciTabella(DocX doc,
            List<(string ore, string materia, string classe, bool evidenziata, bool barrato)> righe,
            string totale)
        {
            int numRighe = righe.Count + 2; // intestazione + dati + totale
            var tabella = doc.InsertTable(numRighe, 3);

            tabella.Design = TableDesign.None;
            tabella.AutoFit = AutoFit.Window;

            foreach (var row in tabella.Rows)
            {
                row.Cells[0].Width = 10f;  // n. Ore
                row.Cells[1].Width = 72f;  // Materia di Insegnamento
                row.Cells[2].Width = 18f;  // Classi
            }

            ImpostaRigaIntestazione(tabella.Rows[0]);

            for (int i = 0; i < righe.Count; i++)
            {
                var (ore, materia, classe, evidenziata, barrato) = righe[i];
                ImpostaRigaDati(tabella.Rows[i + 1], ore, materia, classe, evidenziata, barrato);
            }

            ImpostaRigaTotale(tabella.Rows[numRighe - 1], totale);

            doc.InsertParagraph().SpacingAfter(4);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  HELPERS GRAFICI  (non toccare)
        // ─────────────────────────────────────────────────────────────────────

        private static void ImpostaRigaIntestazione(Row riga)
        {
            string[] testi = { "n. Ore", "Materia di Insegnamento", "Classi" };
            for (int c = 0; c < 3; c++)
            {
                var cella = riga.Cells[c];
                cella.FillColor = GrigioIntestazione;
                ImpostaBordi(cella);
                cella.Paragraphs[0]
                     .Append(testi[c])
                     .Bold().Italic()
                     .Font(FontName).FontSize(FontSize);
            }
        }

        private static void ImpostaRigaDati(Row riga,
            string ore, string materia, string classe,
            bool evidenziata = false, bool barrato = false)
        {
            string[] testi = { ore, materia, classe };
            for (int c = 0; c < 3; c++)
            {
                var cella = riga.Cells[c];
                ImpostaBordi(cella);

                if (evidenziata) cella.FillColor = GialloEvidenziazione;

                var fmt = cella.Paragraphs[0]
                               .Append(testi[c])
                               .Font(FontName).FontSize(FontSize);

                if (evidenziata) fmt.Highlight(Highlight.yellow);
                if (barrato) fmt.StrikeThrough(StrikeThrough.strike);
            }
        }

        private static void ImpostaRigaTotale(Row riga, string totale)
        {
            string[] testi = { totale, "Totale", "" };
            for (int c = 0; c < 3; c++)
            {
                var cella = riga.Cells[c];
                ImpostaBordi(cella);
                cella.Paragraphs[0]
                     .Append(testi[c])
                     .Bold()
                     .Font(FontName).FontSize(FontSize);
            }
        }

        private static void ImpostaBordi(Cell cella)
        {
            var bordo = new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, Xceed.Drawing.Color.Black);
            cella.SetBorder(TableCellBorderType.Top, bordo);
            cella.SetBorder(TableCellBorderType.Bottom, bordo);
            cella.SetBorder(TableCellBorderType.Left, bordo);
            cella.SetBorder(TableCellBorderType.Right, bordo);
        }
    }
}

