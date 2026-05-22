# Cattedre



## Getting started

To make it easy for you to get started with GitLab, here's a list of recommended next steps.

Already a pro? Just edit this README.md and make it your own. Want to make it easy? [Use the template at the bottom](#editing-this-readme)!

## Add your files

- [ ] [Create](https://docs.gitlab.com/ee/user/project/repository/web_editor.html#create-a-file) or [upload](https://docs.gitlab.com/ee/user/project/repository/web_editor.html#upload-a-file) files
- [ ] [Add files using the command line](https://docs.gitlab.com/ee/gitlab-basics/add-file.html#add-a-file-using-the-command-line) or push an existing Git repository with the following command:

```
cd existing_repo
git remote add origin https://gitlab.com/progettocattedre/cattedre.git
git branch -M main
git push -uf origin main
```

## Integrate with your tools

- [ ] [Set up project integrations](https://gitlab.com/progettocattedre/cattedre/-/settings/integrations)

## Collaborate with your team

- [ ] [Invite team members and collaborators](https://docs.gitlab.com/ee/user/project/members/)
- [ ] [Create a new merge request](https://docs.gitlab.com/ee/user/project/merge_requests/creating_merge_requests.html)
- [ ] [Automatically close issues from merge requests](https://docs.gitlab.com/ee/user/project/issues/managing_issues.html#closing-issues-automatically)
- [ ] [Enable merge request approvals](https://docs.gitlab.com/ee/user/project/merge_requests/approvals/)
- [ ] [Set auto-merge](https://docs.gitlab.com/ee/user/project/merge_requests/merge_when_pipeline_succeeds.html)

## Test and Deploy

Use the built-in continuous integration in GitLab.

- [ ] [Get started with GitLab CI/CD](https://docs.gitlab.com/ee/ci/quick_start/)
- [ ] [Analyze your code for known vulnerabilities with Static Application Security Testing (SAST)](https://docs.gitlab.com/ee/user/application_security/sast/)
- [ ] [Deploy to Kubernetes, Amazon EC2, or Amazon ECS using Auto Deploy](https://docs.gitlab.com/ee/topics/autodevops/requirements.html)
- [ ] [Use pull-based deployments for improved Kubernetes management](https://docs.gitlab.com/ee/user/clusters/agent/)
- [ ] [Set up protected environments](https://docs.gitlab.com/ee/ci/environments/protected_environments.html)

***


Applicazione desktop per la **gestione delle cattedre dei docenti** nelle istituzioni scolastiche. Permette di organizzare, visualizzare e aggiornare l'assegnazione delle cattedre al corpo docente, centralizzando le informazioni in un database locale.

---

## 1. Installazione e Utilizzo

### Prerequisiti

- **Sistema operativo:** Windows (10 o superiore)
- **Runtime:** .NET Framework compatibile con Visual Studio 2017 (v15.x)
- **Database:** SQLite (incluso, nessuna installazione separata necessaria)

### Installazione tramite Setup

1. Scaricare il file `Setup1.msi` dalla sezione Release del repository.
2. Eseguire il file MSI e seguire la procedura guidata di installazione.
3. Avviare l'applicazione dal menu Start o dal collegamento creato sul desktop.

### Compilazione da sorgente

```bash
# Clonare il repository
git clone https://github.com/IISMarconiPieralisi/cattedre.git
cd cattedre

# Aprire la solution con Visual Studio 2017 o superiore
start Cattedre.sln

# Compilare in modalità Release
# Build → Build Solution (Ctrl+Shift+B)
```

L'eseguibile compilato si troverà in `Cattedre/bin/Release/`.

### Primo avvio

All'avvio, l'applicazione crea automaticamente il database SQLite locale (`*.sqlite`) nella directory dell'eseguibile. Non è necessaria alcuna configurazione aggiuntiva.

---

## 2. Informazioni Tecniche e Contributi

### Architettura

Il progetto segue un'architettura a livelli separata in cartelle distinte:

| Layer | Cartella | Descrizione |
|-------|----------|-------------|----------------------|
| Data Layer | `ClassiDL/` | Accesso al database SQLite |
| Business Layer | `ClassiBL/` | Logica applicativa |
| Presentation | Form WinForms | Interfaccia utente |

### Tecnologie utilizzate

- **Linguaggio:** C#
- **Framework:** .NET 4.7.2 / Windows Forms
- **Libraries** MySqlConnector, Krypton
- **Database:** SQLite
- **IDE:** Visual Studio 2017+
- **Installer:** Visual Studio Deployment Project (`.vdproj` → `.msi`)

### Documentazione

Al momento non è disponibile una wiki esterna. Il codice sorgente è documentato internamente. Per approfondimenti sull'architettura DL/BL, fare riferimento ai file nelle cartelle `ClassiDL/` e `ClassiBL/`.

### Licenza

Questo progetto è distribuito sotto licenza **Apache 2.0**.  
Vedere il file [LICENSE](LICENSE) per i termini completi.

```
Copyright [anno] - Progetto Cattedre

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0
```

### Contributi

Questo è un progetto personale e **non accetta contributi esterni**. Il repository è mantenuto privatamente dall'autore.

### Ringraziamenti

- [SQLite](https://www.sqlite.org/) — motore di database embedded
- [Microsoft .NET / WinForms](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/) — framework applicativo

---

## 3. Spiegazione dell'Utilizzo
**Login (FrmLogin)**
All'avvio dell'applicazione viene presentata la schermata di login. L'utente può accedere in due modi:

Login manuale: inserendo email e password nei rispettivi campi di testo e premendo il pulsante Login (oppure Invio, essendo impostato come pulsante predefinito). Se uno dei campi è vuoto, il campo in questione viene evidenziato in rosso con un messaggio di avviso.
Login con Google: premendo il pulsante Login con Google, il sistema apre il browser per l'autenticazione OAuth 2.0. Se l'email Google è registrata nel sistema, l'accesso viene completato automaticamente e la foto profilo viene scaricata e mostrata in home.

In base al tipo di utente che si è loggato (Admin, Coordinatore del dip., Doc, Preside) i permessi saranno diversi.
Dopo un login riuscito, il token precedente dell'utente viene cancellato e viene aperta la schermata principale (FrmHome).

**Home (FrmHome)**
La schermata principale è un contenitore MDI con una barra laterale sinistra e un pannello centrale di navigazione.
Barra laterale: mostra nome, cognome, email e foto profilo (tonda, con bordo) dell'utente loggato. 
I pulsanti di navigazione visibili variano in base al ruolo:
- Amministratore:Menu strip completo in alto
- Coordinatore: Cattedre, Utenti, Classi, Discipline
- Docente: Utenti del suo dipartimento (senza permessi per le operazioni CRUD)
- Preside: Cattedre, Utenti, Classi, Discipline (solo visualizzazione)

La barra laterale è ridimensionabile tramite uno splitter: se compressa, i pulsanti mostrano solo l'icona; se espansa, mostrano icona e testo.
Pannello centrale: all'avvio mostra un messaggio di benvenuto con un pulsante centrale per accedere direttamente alla schermata delle cattedre.
Ogni sezione del menu apre il form corrispondente all'interno del pannello destro, sostituendo il form precedente senza aprire finestre aggiuntive. 
Il pulsante Logout esegue la disconnessione, cancella il token Google salvato sul disco e chiude l'applicazione.



**Gestione Cattedre (FrmCattedre)**
È la schermata operativa centrale del software, accessibile da Coordinatore, Amministratore e Preside. 
Il layout è una griglia dinamica con:
- Asse orizzontale (ucDisciplina): una colonna per ogni disciplina del dipartimento selezionato.
- Asse verticale (ucClasse): una riga per ogni classe del dipartimento.
- Celle di incrocio (UcAssegnazioni): ogni cella contiene due ComboBox per selezionare il docente teorico (T) e il docente ITP (L) per quella disciplina in quella classe. Le ore di teoria e laboratorio sono mostrate in etichetta. Se una disciplina non ha ore di laboratorio, la ComboBox ITP viene nascosta automaticamente.

Selettori in alto:
- ComboBox Dipartimento: seleziona il dipartimento da visualizzare. Per il Coordinatore è preimpostato sul proprio dipartimento e non è modificabile. Preside e Amministratore possono scorrere tra tutti i dipartimenti.
- ComboBox Anno Scolastico: seleziona l'anno. All'apertura viene selezionato automaticamente l'anno scolastico corrente.

Pannello docenti (destra):
Mostra per ogni docente del dipartimento una riga (UcOreDoc) con:
- Nome del docente.
- Ore di cattedra da contratto.
- Ore effettive calcolate in tempo reale sommando tutte le assegnazioni correnti (incluse quelle in altri dipartimenti).
- Ore di potenziamento (campo numerico modificabile solo dal Coordinatore e solo se il docente è abilitato alla CDC di potenziamento).
- Ore totali (effettive + potenziamento).

Il colore del nome e delle ore segnala lo stato del docente: rosso se le ore totali sono inferiori al monte ore contrattuale, arancione se lo superano, nero se coincidono esattamente. 
I docenti sono raggruppati per tipologia (Teorici / Pratici) con un'intestazione per ciascuna CDC che indica: cattedre di fatto, di diritto e stato (COPERTE / SCOPERTE / SOVRAFFOLLATE).ù

Salvataggio: ogni modifica a una ComboBox di assegnazione viene salvata immediatamente nel database senza necessità di premere un pulsante di salvataggio esplicito.

Pulsante Genera Anno Successivo: disponibile solo per il Coordinatore. Prima di procedere assicurarsi che:
- esista l'anno scolastico per l'anno successivo
- esistano le classi per l'anno successivo.
Se non esistono ancora assegnazioni per l'anno successivo, dopo la conferma, verranno copiate le assegnazioni dell'anno corrente come base di partenza per l'anno seguente.
Se esistono già, verrà chiesto se si vogliono sovrascrivere le assegnazioni.

Pulsante Genera Word: disponibile per il Coordinatore. Chiede un percorso di salvataggio e genera un file .docx con il quadro completo delle cattedre del dipartimento per l'anno selezionato, nel formato previsto per la dirigenza. Al termine viene proposta l'apertura automatica del file.
Scroll: la griglia supporta scorrimento verticale tramite rotellina e scorrimento orizzontale tenendo premuto Shift + rotellina, oppure tramite la barra di scorrimento orizzontale in fondo.

**Elenco Utenti (FrmUtenti)**
Accessibile da Amministratore e Coordinatore (con accesso limitato per il Coordinatore al proprio dipartimento). 
Mostra una ListView degli utenti con: ID, Cognome, Nome, Email, Ruolo, Tipo Contratto, Monte Ore, Data Inizio Contratto, Data Fine Contratto.

Filtri disponibili:
- Tipo utente: Preside, Amministratore, Docente, Coordinatore (checkbox).
- Tipo contratto: Determinato / Indeterminato (radio button).
- Tipo docente: Teorico / Laboratorio (radio button).

Ricerca per cognome e nome (campo testo con placeholder).
I filtri si applicano premendo Cerca o Invio; si azzerano con Annulla Filtri o Esc.

Operazioni:
- Inserisci: apre FrmUtente per creare un nuovo utente con tutti i dati collegati (contratto, afferenze a dipartimento, classi di concorso abilitate).
- Modifica: precarica FrmUtente con i dati esistenti. Se vengono rimosse classi di concorso, le relative assegnazioni nelle cattedre vengono cancellate automaticamente.
- Elimina: rimuove l'utente e lo dissocia dal dipartimento se era coordinatore.
- Cattedre Utente: apre FrmCattedreUtente per visualizzare le cattedre assegnate all'utente selezionato.

**Dettaglio Utente (FrmUtente)**
Form articolata per la gestione completa di un utente. 

Sezioni principali:
- Dati anagrafici: nome, cognome, email, ruolo (Preside, Amministratore, Docente, Coordinatore), tipo docente (Teorico/Laboratorio).
- Contratto: tipo (Determinato/Indeterminato), monte ore settimanale, date di inizio e fine.
- Afferenza al dipartimento: selezione del dipartimento di appartenenza. Se il ruolo è Coordinatore, questo campo indica il dipartimento che coordina.
- Classi di Concorso abilitate: lista delle CDC per cui il docente è abilitato all'insegnamento, usate per filtrare le assegnazioni nelle cattedre.

I campi obbligatori vengono validati prima del salvataggio. La form si comporta in modo adattivo: per Preside e Amministratore alcuni campi (contratto, CDC, dipartimento) vengono nascosti o disabilitati.

**Cattedre Assegnate a un Utente (FrmCattedreUtente)**
Aperta da FrmUtenti premendo Cattedre Utente. 
Mostra in una ListView le assegnazioni del docente selezionato per un dato anno scolastico, con le colonne: ID assegnazione, Classe, Disciplina, Ore Speciali, Ore Effettive, Totale.

Un ComboBox permette di cambiare l'anno scolastico visualizzato. All'apertura viene selezionato automaticamente l'anno scolastico corrente.
Il pulsante Elimina (visibile solo per Coordinatore e Amministratore) rimuove l'assegnazione selezionata dopo conferma.



**Elenco Classi (FrmClassi)**
Accessibile da Amministratore e Coordinatore. 
Mostra le classi scolastiche con sigla, anno, indirizzo e anno scolastico. Operazioni standard: Inserisci, Modifica, Elimina.
Un'altra operazione è Genera classe anno successivo, dove una volta selezionata una classe dalla listview e aver cliccato il bottone in questione, verrà creata la stessa classe con l'anno incrementato di uno (es. da 1BM a 2BM) e in riferimento all'anno scolastico successivo.
Se si vogliono generare più classi contemporaneamente, è possibile farlo selezionando dalla listview il primo elemento, tenere premuto Ctrl + Shift e selezionare l'ultimo elemento. Dopodiché cliccare il bottone Genera. (ATTENZIONE: non selezionare le classi 5 perché non esisteranno più nell'anno successivo)

**Dettaglio Classe (FrmClasse)**
Permette di definire una classe specificando: sigla (es. 3AI), numero d'anno (1–5), indirizzo di appartenenza e anno scolastico. Sono presenti controlli di validazione per evitare duplicati o valori mancanti.



**Elenco Discipline (FrmDiscipline)**
Accessibile da Amministratore e Coordinatore.
Mostra le discipline con nome, ore di teoria, ore di laboratorio, anno scolastico e indirizzo di appartenenza. Supporta filtri per anno e indirizzo. Operazioni standard: Inserisci, Modifica, Elimina.

**Dettaglio Disciplina (FrmDisciplina)**
Form per creare o modificare una disciplina. 
I campi principali sono:
- Nome della disciplina.
- Ore di Teoria e Ore di Laboratorio per ciascun anno scolastico.
- Indirizzo di appartenenza (uno o più, tramite lista di selezione).
- Classi di Concorso associate (teoriche e pratiche), che determinano quali docenti potranno essere assegnati.
- Ore di Potenziamento configurabili per CDC.

La form valida che la somma delle ore sia coerente con il monte ore previsto.



**Elenco Classi di Concorso (FrmCdCs)**
Accessibile dall'Amministratore. 
Mostra una ListView con le classi di concorso registrate (ID, Livello, Nome, Abilitazioni richieste).

Inserisci / Modifica / Elimina funzionano con lo stesso schema degli altri form master.
È presente una barra di ricerca per filtrare per sigla (campo mascherato) e/o per nome. Il pulsante Pulisci azzera i filtri.
I tasti Invio e Canc sulla ListView attivano rispettivamente Modifica ed Elimina.

**Dettaglio Classe di Concorso (FrmCdC)**
Form di dettaglio per una classe di concorso. 
Contiene:
- Livello: sigla della classe di concorso (es. A-41).
- Nome: denominazione estesa.
- Abilitazioni Richieste: campo di testo libero (RichTextBox) per descrivere i titoli necessari (es. Laurea in Informatica). Il doppio Invio rapido sposta il fuoco al pulsante Salva.

**Dotazione Organica per Classe di Concorso (FrmDotazioni)**
Accessibile dall'Amministratore. 
Mostra la dotazione organica (numero di cattedre di diritto e di fatto) per ogni classe di concorso e anno scolastico. Operazioni standard: Inserisci, Modifica, Elimina.

**Dettaglio Dotazione (FrmDotazione)**
Permette di specificare, per una combinazione Classe di Concorso + Anno Scolastico, il numero di cattedre di diritto (organico previsto) e di fatto (docenti effettivamente assegnati). Questi valori vengono usati in FrmCattedre per segnalare lo stato di copertura delle cattedre.



**Elenco Dipartimenti (FrmDipartimenti)**
Accessibile da Amministratore.
Mostra la lista dei dipartimenti con ID, nome e coordinatore. Operazioni standard: Inserisci, Modifica, Elimina con conferma. Tasti Invio e Canc attivi sulla ListView.

**Dettaglio Dipartimento (FrmDipartimento)**
Permette di inserire o modificare il nome di un dipartimento. Il coordinatore viene assegnato separatamente tramite FrmUtente.



**Elenco Indirizzi (FrmIndirizzi)**
Accessibile da Amministratore.
Gestione degli indirizzi di studio (es. Informatica e Telecomunicazioni, Elettronica). ListView con ID e nome. Operazioni standard: Inserisci, Modifica, Elimina.

**Dettaglio Indirizzo (FrmIndirizzo)**
Form minimale con un campo testo per il nome dell'indirizzo. Salva o annulla.



**Elenco Anni Scolastici (FrmAnniScolastici)**
Accessibile dall'Amministratore tramite il menu strip. 
Mostra una ListView con tutti gli anni scolastici registrati, con le colonne: ID, Sigla (es. 24-25), Data Inizio, Data Fine.

Inserisci: apre FrmAnnoScolastico in modalità nuovo inserimento.
Modifica: apre FrmAnnoScolastico precompilato con i dati dell'anno selezionato. Richiede che sia selezionata una riga.
Elimina: chiede conferma e rimuove l'anno scolastico selezionato.
I tasti Invio e Canc sulla ListView simulano rispettivamente Modifica ed Elimina.

**Dettaglio Anno Scolastico (FrmAnnoScolastico)**
Form di dettaglio per inserire o modificare un anno scolastico. Contiene:

Sigla: campo mascherato (es. 24-25), aggiornata automaticamente al variare delle date.
Data Inizio / Data Fine: due DateTimePicker. La data di fine deve essere di un anno esatto successiva alla data di inizio; altrimenti viene mostrato un avviso e la data viene corretta automaticamente.
Viene inoltre verificato che la data di inizio sia successiva alla fine dell'anno scolastico già registrato più recente, per evitare sovrapposizioni.
Salva / Annulla: confermano o annullano l'operazione. La navigazione tra campi è possibile con Invio.



**Crediti (FrmAnnoScolastico)**
Schermata informativa che mostra i nomi degli autori del progetto e le tecnologie utilizzate. Non contiene funzionalità operative.