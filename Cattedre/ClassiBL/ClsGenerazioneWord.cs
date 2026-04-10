using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
            try
            {
                List<ClsAssegnareDL> assegnare = ClsAssegnareBL.PopolaAssegnazioniAnnoScolasticoDipartimento(dipartimento.ID, anno.ID);
                List<ClsAssegnareDL>assegnarePot = ClsAssegnareBL.PopolaAssegnazioniAnnoScolasticoDipartimentoPotenziamento(dipartimento.ID, anno.ID);
                List<ClsClasseDiConcorsoDL> cdc = ClsClasseDiConcorsoBL.CaricaCDCperDisciplina(dipartimento.ID);
                List<ClsDisciplinaDL> discipline = ClsGestireBL.DisciplineDelDipartimento(dipartimento.ID);
                List<ClsDotareDL> Dotare = ClsDotareBL.CaricaDotare();
                List<ClsClasseDL> classi = ClsClasseBL.CaricaClassiDipartimento(dipartimento.ID, anno.ID);

               
                GenerateFileWord(anno,dipartimento, cdc, Docenti, assegnare,assegnarePot, discipline, classi, Dotare, filePath);
            }catch(Exception ex)
            {
                throw new Exception("Errore Durante il Caricamento del file: " + ex.Message);
            }
           
        }

        public static void GenerateFileWord(ClsAnnoScolasticoDL annoScolastico,ClsDipartimentoDL dipartimento, List<ClsClasseDiConcorsoDL> listClassiConcorso,
                                            List<ClsUtenteDL> listDocenti,List<ClsAssegnareDL> listAssegnazioni,List<ClsAssegnareDL> listAssegnazioniSpeciali, List<ClsDisciplinaDL> listDiscipline,
                                            List<ClsClasseDL> listClassi,List<ClsDotareDL> listDotare,string outputPath)
        {
            try
            {
                using (DocX doc = DocX.Create(outputPath))
                {
                    doc.PageWidth = 595f;
                    doc.PageHeight = 842f;
                    doc.MarginTop = 36f;
                    doc.MarginBottom = 36f;
                    doc.MarginLeft = 36f;
                    doc.MarginRight = 36f;
                    //conto le righe, per gesitire al meglio le spaziature alla fine di ogni classe di concorso
                    int i = 0;
                    foreach (ClsClasseDiConcorsoDL cdc in listClassiConcorso)
                    {
                        ClsDotareDL dotazione = listDotare
                            .FirstOrDefault(d => d.IdClasseDiConcorso == cdc.ID);
                        InserisciIntestazioneCDC(doc, cdc, dotazione);

                        var DocentiFiltrati = ClsRichiedereBL.RilevaUtentiCDC(cdc.ID); //metodi per trovare gli utanti con quella  CDC

                        if (DocentiFiltrati.Count <= 0){    i++;    continue;
                        }
                        //ciclo gli utenti con quella classe di concorso 
                        foreach (ClsUtenteDL docente in DocentiFiltrati)
                        {
                            var assegnazioneSpeciale = listAssegnazioniSpeciali.FirstOrDefault(a => a.IDUtente == docente.ID);
                            InserisciDocente(doc, docente, listAssegnazioni, assegnazioneSpeciale, listDiscipline, listClassi);
                        }

                        // Aggiunge il pagebreak solo se NON è l'ultimo elemento
                        if (i < listClassiConcorso.Count - 1)
                        {
                            Paragraph pageBreak = doc.InsertParagraph();
                            pageBreak.InsertPageBreakAfterSelf();
                        }
                        i++;
                    }
                    //aggiunta piè di pagina e intersezione
                    AggiuntaIntestazionePieDiPagina(doc, annoScolastico, dipartimento);
                    try
                    {
                        doc.Save();
                    }catch
                    {
                        throw new Exception("il file risulta aperto");
                    }
                }
         
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
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

        private static void InserisciDocente(DocX doc,ClsUtenteDL docente,List<ClsAssegnareDL> assegnazioni,ClsAssegnareDL assegnazioneSpec, List<ClsDisciplinaDL> listDiscipline,
                                                List<ClsClasseDL> listClassi)
        {
            // Filtro le liste in modo tale da usare delle liste pulite 
            List<ClsAssegnareDL> assegnazioniDocente = assegnazioni.Where(a => a.IDUtente == docente.ID).ToList();
            if (assegnazioneSpec != null) assegnazioniDocente.Add(assegnazioneSpec);
            List<ClsRichiedereDL> richiesteDocente = ClsRichiedereBL.CaricaClassiRichiedereUtente(docente.ID);
            List<ClsDisciplinaDL> listDisciplineDocente = listDiscipline.Where(d => assegnazioniDocente.Any(r => r.IDDisciplina == d.ID)).ToList();
            List<ClsClasseDL> listClassiDocente = listClassi.Where(c => assegnazioniDocente.Any(r => r.IDClasse == c.ID)).ToList();
            if (listClassiDocente.Count <= 0) return;
            // Intestazione docente
            var pNome = doc.InsertParagraph();
            pNome.SpacingBefore(12);
            pNome.Append($"Prof. {docente.Cognome.ToUpper()} {docente.Nome.ToUpper()}")
                 .Bold()
                 .UnderlineStyle(UnderlineStyle.singleLine)
                 .Font(FontName).FontSize(FontSize).Color(Xceed.Drawing.Color.Red);
            pNome.SpacingAfter(4);
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

        private static void InserisciTabella(DocX doc, List<ClsAssegnareDL> assegnazioni,List<ClsDisciplinaDL> listDiscipline,
            List<ClsClasseDL> listClassi, ClsUtenteDL Docente)
        {

            // Monte ore dal contratto
            ClsContrattoDL contratto = ClsContrattoBL.cercaContratto(Docente.ID);
            int monteOre = contratto?.MonteOre ?? 0;
            int OreEffettive = 0;
            int numRighe = assegnazioni.Count + 2; 
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
            for (int i = 0; i < assegnazioni.Count; i++)
            {
                ClsAssegnareDL assegnazione = assegnazioni[i];
                if (assegnazione == null) continue;

                ClsDisciplinaDL disciplina = listDiscipline.FirstOrDefault(d =>d != null &&d.ID == assegnazione.IDDisciplina &&
                                              (!string.IsNullOrWhiteSpace(d.DisciplinaSpeciale) || assegnazione.IDClasse > 0));

                if (disciplina == null)
                    continue;
                ClsClasseDL classe = listClassi.FirstOrDefault(c => c != null && c.ID == assegnazione.IDClasse);

                int ore;
                if (!string.IsNullOrWhiteSpace(disciplina.DisciplinaSpeciale))
                    ore = assegnazione.OreSpeciali;
                else
                    ore = Docente.TipoDocente == 'L' ? disciplina.OreLaboratorio : disciplina.OreTeoria;

                string nomeMateria = disciplina.Nome ?? "N/D";
                string nomeClasse = classe != null ? $"{classe.Anno}{classe.Sezione}" : string.Empty;
                //sommo le ore cosi da mostrare la somma delle ore alla fine
                OreEffettive += ore;
                ImpostaRigaDati(tabella.Rows[i + 1], ore, nomeMateria, nomeClasse);
            }

            ImpostaRigaTotale(tabella.Rows[numRighe - 1],$"{OreEffettive}/{monteOre}");
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
             .FontSize(FontSize+2)
             .Color(Xceed.Drawing.Color.Black);

            // Vai a capo nello stesso paragrafo
            p.AppendLine();

            // Codice + Nome CDC – nero
            p.Append($"{cdc.Livello} {cdc.Nome.ToUpper()}")
             .Bold()
             .Font(FontName)
             .FontSize(FontSize+2)
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
            p.SpacingAfter(5);
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
            var bordo = new Border(Xceed.Document.NET.BorderStyle.Tcbs_single, BorderSize.one, 0, Xceed.Drawing.Color.Black);
            cella.SetBorder(TableCellBorderType.Top, bordo);
            cella.SetBorder(TableCellBorderType.Bottom, bordo);
            cella.SetBorder(TableCellBorderType.Left, bordo);
            cella.SetBorder(TableCellBorderType.Right, bordo);
        }
        public static void AggiuntaIntestazionePieDiPagina(DocX doc, ClsAnnoScolasticoDL anno, ClsDipartimentoDL dip)
        {
            doc.AddHeaders();
            Header header = doc.Headers.Odd;

            Paragraph headerLine1 = header.InsertParagraph();
            headerLine1.Append("I.I.S. \"Marconi Pieralisi\" - Jesi")
                       .Font(FontName)
                       .FontSize(FontSize+1)
                       .Bold();
            headerLine1.Alignment = Alignment.center;

            // Riga 2: CATTEDRE ANNO SCOLASTICO 
            Paragraph headerLine2 = header.InsertParagraph();
            headerLine2.Append($"CATTEDRE ANNO SCOLASTICO {anno.Sigla}")
                       .Font(FontName)
                       .FontSize(FontSize-1)
                       .Bold();
            headerLine2.Alignment = Alignment.center;

            // Riga 3: Dipartimento (se fornito)
            if (dip!=null)
            {
                Paragraph headerLine3 = header.InsertParagraph();
                headerLine3.Append($"Dipartimento: {dip.Nome}")
                        .Font(FontName)
                       .FontSize(FontSize - 1).SpacingAfter(5);
                headerLine3.Alignment = Alignment.center;
            }
            //  PIÈ DI PAGINA 
            doc.AddFooters();
            Footer footer = doc.Footers.Odd;

            Paragraph footerParagraph = footer.InsertParagraph();
            footerParagraph.Alignment = Alignment.center;

            footerParagraph.AppendPageNumber(PageNumberFormat.normal);
        }

        internal static string GestisciPercorsoFile(ClsAnnoScolasticoDL anno, ClsDipartimentoDL dipartimento)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = $"Cattedre { dipartimento.Nome}As{ anno.Sigla}";
            // Impostazioni opzionali
            saveFileDialog1.Filter = "Documento Word (*.docx)|*.docx|Tutti i file (*.*)|*.*";
            saveFileDialog1.Title = "Scegli dove salvare il file";
            saveFileDialog1.DefaultExt = "docx";

            // Apertura del pannello e verifica del risultato
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                return  saveFileDialog1.FileName;
            return string.Empty;
        }
    }
    #endregion
}