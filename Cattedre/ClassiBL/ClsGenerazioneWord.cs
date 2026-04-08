using System;
using System.Collections.Generic;
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
        public static void PreparazioneCreazioneFile(ClsAnnoScolasticoDL anno, ClsDipartimentoDL dipartimento,string filePath)
        {
            List<ClsUtenteDL> Docenti/*metodo prendere utente di quel dipartimento*/;
            List<ClsAssegnareDL> assegnare = ClsAssegnareBL.PopolaAssegnazioni();
            List<ClsClasseDiConcorsoDL> cdc = ClsClasseDiConcorsoBL.CaricaCDCperDisciplina(dipartimento.ID);
            List<ClsDisciplinaDL> discipline = ClsGestireBL.DisciplineDelDipartimento(dipartimento.ID);
            List<ClsDotareDL> listDotare = ClsDotareBL.CaricaDotare();
        }

        public static void GenerateFileWord(ClsAnnoScolasticoDL annoScolastico,List<ClsClasseDiConcorsoDL> listClassiConcorso,
                                            List<ClsUtenteDL> listDocenti,List<ClsAssegnareDL> listAssegnazioni,List<ClsDisciplinaDL> listDiscipline,
                                            List<ClsClasseDL> listClassi,List<ClsDotareDL> listDotare,string outputPath)
        {
            using (DocX doc = DocX.Create(outputPath))
            {
                doc.PageWidth = 595f;
                doc.PageHeight = 842f;
                doc.MarginTop = 36f;
                doc.MarginBottom = 36f;
                doc.MarginLeft = 36f;
                doc.MarginRight = 36f;

                foreach (ClsClasseDiConcorsoDL cdc in listClassiConcorso)
                {
                    ClsDotareDL dotazione = listDotare
                        .FirstOrDefault(d => d.IdClasseDiConcorso == cdc.ID);

                    InserisciIntestazioneConcorso(doc, cdc, dotazione);

                    foreach (ClsUtenteDL docente in listDocenti)
                    {
                        // Filtro assegnazioni del singolo docente
                        List<ClsAssegnareDL> assegnazioniDocente = listAssegnazioni
                            .Where(a => a.IDUtente == docente.ID)
                            .ToList();
                        InserisciDocente(doc, docente, assegnazioniDocente, listDiscipline, listClassi);
                    }
                    InserisciNotaFinale(doc, cdc.Livello, listAssegnazioni, listDiscipline, listClassi);

                }

                doc.Save();
            }
        }
        private static void InserisciIntestazioneConcorso(
            DocX doc, ClsClasseDiConcorsoDL cdc, ClsDotareDL dot)
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

            if (dot != null && dot.Id > 0)
            {
                var pR = doc.InsertParagraph();
                pR.SpacingAfter(4);
                pR.Append($"{dot.NumcattedreDiritto} cattedre")
                  .Bold().Font(FontName).FontSize(10);
            }
        }

        private static void InserisciDocente(DocX doc,ClsUtenteDL docente,List<ClsAssegnareDL> assegnazioni,List<ClsDisciplinaDL> listDiscipline,
                                                List<ClsClasseDL> listClassi)
        {
            // Carica le discipline abilitate per questo docente tramite ClsRichiedereBL
            List<ClsRichiedereDL> richiesteDocente = ClsRichiedereBL.CaricaClassiRichiedereUtente(docente.ID);

            // Ricava le sole discipline di questo docente
            List<ClsDisciplinaDL> listDisciplineDocente = listDiscipline
            .Where(d => richiesteDocente.Any(r => r.IDdisciplina == d.ID))
            .ToList();

            // Filtra le assegnazioni solo per le discipline abilitate del docente
            List<ClsAssegnareDL> assegnazioniDocente = assegnazioni
                .Where(a => richiesteDocente.Any(r => r.IDdisciplina == a.IDDisciplina))
                .ToList();
            // Intestazione docente
            var pNome = doc.InsertParagraph();
            pNome.SpacingBefore(6);
            pNome.Append($"Docente {docente.Cognome} {docente.Nome}")
                 .Bold().Italic()
                 .UnderlineStyle(UnderlineStyle.singleLine)
                 .Font(FontName).FontSize(10);

            // Monte ore dal contratto
            ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(docente.ID);
            string monteOre = contratto?.MonteOre.ToString() ?? "0";

            InserisciTabella(doc, assegnazioniDocente, listDisciplineDocente, listClassi, monteOre);
        }

        private static void InserisciNotaFinale( DocX doc, string titolo, List<ClsAssegnareDL> assegnazioni,
            List<ClsDisciplinaDL> listDiscipline,
            List<ClsClasseDL> listClassi
            )
        {
            var pTitolo = doc.InsertParagraph();
            pTitolo.SpacingBefore(8);
            pTitolo.Append(titolo)
                   .Bold().Italic()
                   .UnderlineStyle(UnderlineStyle.singleLine)
                   .Font(FontName).FontSize(10);

           // InserisciTabella(doc, assegnazioni, listDiscipline, listClassi, totale);
        }

        private static void InserisciTabella(DocX doc,List<ClsAssegnareDL> assegnazioni,List<ClsDisciplinaDL> listDiscipline,List<ClsClasseDL> listClassi,
            string totale)
        {
            int numRighe = assegnazioni.Count + 2; // intestazione + dati + totale
            var tabella = doc.InsertTable(numRighe, 3);

            tabella.Design = TableDesign.None;
            tabella.AutoFit = AutoFit.Window;

            foreach (var row in tabella.Rows)
            {
                row.Cells[0].Width = 10f;   // n. Ore
                row.Cells[1].Width = 72f;   // Materia di Insegnamento
                row.Cells[2].Width = 18f;   // Classi
            }

            ImpostaRigaIntestazione(tabella.Rows[0]);

            for (int i = 0; i < assegnazioni.Count; i++)
            {
                ClsAssegnareDL assegnazione = assegnazioni[i];

                ClsDisciplinaDL disciplina = listDiscipline
                    .FirstOrDefault(d => d.ID == assegnazione.IDDisciplina);

                ClsClasseDL classe = listClassi
                    .FirstOrDefault(c => c.ID == assegnazione.IDClasse);

                string nomeMateria = disciplina?.Nome ?? "N/D";
                string nomeClasse = classe?.Sezione ?? "N/D";

                // evidenziata/barrato: puoi aggiungere logica qui in futuro
                ImpostaRigaDati(tabella.Rows[i + 1],
                    assegnazione.OreSpeciali, nomeMateria, nomeClasse,
                    evidenziata: false,
                    barrato: false);
            }

            ImpostaRigaTotale(tabella.Rows[numRighe - 1], totale);

            doc.InsertParagraph().SpacingAfter(4);
        }
        #region elementi grafici
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
            int ore, string materia, string classe,
            bool evidenziata = false, bool barrato = false)
        {
            string[] testi = { ore.ToString(), materia, classe };
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
    #endregion
}