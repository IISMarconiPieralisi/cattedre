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
        private const string FontName = "Calibri";
        private const double FontSize = 12;
        public static void PreparazioneCreazioneFile(ClsAnnoScolasticoDL anno, ClsDipartimentoDL dipartimento,string filePath)
        {
            List<ClsUtenteDL> Docenti = ClsUtenteBL.OttieniUtentiDipartimento(dipartimento.ID)/*metodo prendere utente di quel dipartimento*/;
            List<ClsAssegnareDL> assegnare = ClsAssegnareBL.PopolaAssegnazioni();
            List<ClsClasseDiConcorsoDL> cdc = ClsClasseDiConcorsoBL.CaricaCDCperDisciplina(dipartimento.ID);
            List<ClsDisciplinaDL> discipline = ClsGestireBL.DisciplineDelDipartimento(dipartimento.ID);
            List<ClsDotareDL> Dotare = ClsDotareBL.CaricaDotare();
            List<ClsClasseDL> classi = ClsClasseBL.CaricaClassiDipartimento(dipartimento.ID, anno.ID);

            filePath += $"\\Cattedre.Docx";
            GenerateFileWord(anno, cdc, Docenti, assegnare, discipline,classi,Dotare,filePath);
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
                    InserisciIntestazioneCDC(doc, cdc, dotazione);
                    var DocentiFiltrati = ClsRichiedereBL.RilevaUtentiCDC(cdc.ID);

                    foreach (ClsUtenteDL docente in DocentiFiltrati)
                    {
                        InserisciDocente(doc, docente, listAssegnazioni, listDiscipline, listClassi);
                    }
                    //InserisciNotaFinale(doc, cdc.Livello, listAssegnazioni, listDiscipline, listClassi);
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
            // Filtro le liste in modo tale da usare delle liste pulite 
            List<ClsAssegnareDL> assegnazioniDocente = assegnazioni.Where(a => a.IDUtente == docente.ID).ToList();
            List<ClsRichiedereDL> richiesteDocente = ClsRichiedereBL.CaricaClassiRichiedereUtente(docente.ID);
            List<ClsDisciplinaDL> listDisciplineDocente = listDiscipline.Where(d => assegnazioniDocente.Any(r => r.IDDisciplina == d.ID)).ToList();
            List<ClsClasseDL> listClassiDocente = listClassi.Where(c => assegnazioniDocente.Any(r => r.IDClasse == c.ID)).ToList();
            if (listClassiDocente.Count <= 0) return;
            // Intestazione docente
            var pNome = doc.InsertParagraph();
            pNome.SpacingBefore(6);
            pNome.Append($"Docente {docente.Cognome} {docente.Nome}")
                 .Bold().Italic()
                 .UnderlineStyle(UnderlineStyle.singleLine)
                 .Font(FontName).FontSize(10);
            InserisciTabella(doc, assegnazioniDocente, listDisciplineDocente, listClassiDocente, docente);
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

           //InserisciTabella(doc, assegnazioni, listDiscipline, listClassi, totale);
        }

        private static void InserisciTabella(DocX doc,List<ClsAssegnareDL> assegnazioni,List<ClsDisciplinaDL> listDiscipline,List<ClsClasseDL> listClassi,
            ClsUtenteDL Docente)
        {
            // Monte ore dal contratto
            ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(Docente.ID);
            int monteOre = (contratto == null) ? 0 : contratto.MonteOre;

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
                    .FirstOrDefault(d =>d!=null && d.ID == assegnazione.IDDisciplina && (!string.IsNullOrWhiteSpace(d.DisciplinaSpeciale) || assegnazione.IDClasse>0));

                ClsClasseDL classe = listClassi
                    .FirstOrDefault(c => c.ID == assegnazione.IDClasse);
                int Ore = (!string.IsNullOrWhiteSpace(disciplina.DisciplinaSpeciale)) 
                    ? assegnazione.OreSpeciali :
                    (Docente.TipoDocente=='L')?disciplina.OreLaboratorio:disciplina.OreTeoria;
                string nomeMateria = disciplina?.Nome ?? "N/D";
                string nomeClasse = (classe==null)?"N/D":$"{classe.Anno}{classe.Sezione}";

                // evidenziata/barrato: puoi aggiungere logica qui in futuro
                ImpostaRigaDati(tabella.Rows[i + 1], Ore
                    , nomeMateria, nomeClasse,
                    evidenziata: false,
                    barrato: false);
            }

            ImpostaRigaTotale(tabella.Rows[numRighe - 1], monteOre.ToString());

            doc.InsertParagraph().SpacingAfter(4);
        }
        private static void InserisciIntestazioneCDC(DocX doc, ClsClasseDiConcorsoDL cdc, ClsDotareDL dotazione)
        {
            Paragraph p = doc.InsertParagraph();
            p.Alignment = Alignment.center;

            // "CLASSE DI CONCORSO:" – nero
            p.Append("CLASSE DI CONCORSO:")
             .Bold()
             .Font(FontName)
             .FontSize(FontSize)
             .Color(Xceed.Drawing.Color.Black);

            // Vai a capo nello stesso paragrafo
            p.AppendLine();

            // Codice + Nome CDC – nero
            p.Append($"{cdc.Livello} {cdc.Nome.ToUpper()}")
             .Bold()
             .Font(FontName)
             .FontSize(FontSize)
             .Color(Xceed.Drawing.Color.Black);

            // Cattedre + ore residue – rosso
            if (dotazione != null)
            {
                p.AppendLine();
                p.Append($"{dotazione.NumcattedreDiritto} cattedre + h residue")
                 .Bold()
                 .Font(FontName)
                 .FontSize(FontSize)
                 .Color(Xceed.Drawing.Color.Red);
            }

            // Nessuna spaziatura
            p.SpacingBefore(0);
            p.SpacingAfter(0);
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