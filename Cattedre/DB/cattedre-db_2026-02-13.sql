-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Creato il: Feb 13, 2026 alle 20:22
-- Versione del server: 8.2.0
-- Versione PHP: 8.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cattedre`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `afferire`
--

CREATE TABLE `afferire` (
  `ID` int NOT NULL,
  `IDdipartimento` int UNSIGNED DEFAULT NULL,
  `IDutente` int UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `afferire`
--

INSERT INTO `afferire` (`ID`, `IDdipartimento`, `IDutente`) VALUES
(1, 1, 2),
(4, 3, 8),
(6, 1, 4),
(7, 1, 1),
(8, 3, 6),
(9, 3, 5);

-- --------------------------------------------------------

--
-- Struttura della tabella `anniscolastici`
--

CREATE TABLE `anniscolastici` (
  `ID` int UNSIGNED NOT NULL,
  `sigla` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `datainizio` date NOT NULL,
  `datafine` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `anniscolastici`
--

INSERT INTO `anniscolastici` (`ID`, `sigla`, `datainizio`, `datafine`) VALUES
(1, '24-25', '2024-09-11', '2025-06-07'),
(7, '25-26', '2025-09-15', '2026-06-06');

-- --------------------------------------------------------

--
-- Struttura della tabella `appartenere`
--

CREATE TABLE `appartenere` (
  `IDindirizzo` int UNSIGNED DEFAULT NULL,
  `IDdisciplina` int UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `assegnare`
--

CREATE TABLE `assegnare` (
  `ID` int UNSIGNED NOT NULL,
  `dal` date DEFAULT NULL,
  `al` date DEFAULT NULL,
  `oreSpeciali` int NOT NULL,
  `IDannoscolastico` int UNSIGNED DEFAULT NULL,
  `IDutente` int UNSIGNED DEFAULT NULL,
  `IDdisciplina` int UNSIGNED DEFAULT NULL,
  `IDclasse` int UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `assegnare`
--

INSERT INTO `assegnare` (`ID`, `dal`, `al`, `oreSpeciali`, `IDannoscolastico`, `IDutente`, `IDdisciplina`, `IDclasse`) VALUES
(1, '2024-09-11', '2025-06-07', 0, 1, 1, 1, 1),
(3, '2024-09-11', '2025-06-07', 0, 1, 5, 2, 1),
(4, '2024-09-11', '2025-06-07', 0, 1, 2, 19, 4),
(5, '2024-09-11', '2025-06-07', 0, 1, 1, 23, 7),
(6, NULL, NULL, 8, 7, 9, 36, NULL),
(7, NULL, NULL, 2, 7, 5, 36, NULL);

-- --------------------------------------------------------

--
-- Struttura della tabella `classi`
--

CREATE TABLE `classi` (
  `ID` int UNSIGNED NOT NULL,
  `sigla` char(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `anno` tinyint UNSIGNED NOT NULL,
  `sezione` char(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `classeArticolataCon` int UNSIGNED DEFAULT NULL,
  `IDutente` int UNSIGNED DEFAULT NULL COMMENT 'coordinatore di classe ',
  `IDindirizzo` int UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `classi`
--

INSERT INTO `classi` (`ID`, `sigla`, `anno`, `sezione`, `classeArticolataCon`, `IDutente`, `IDindirizzo`) VALUES
(1, '4BM', 4, 'BM', NULL, 4, 1),
(2, '2MP', 2, 'MP', NULL, 6, 4),
(4, '3BM', 3, 'BM', NULL, 2, 1),
(5, '4FM', 4, 'FM', NULL, 7, 2),
(7, '5BM', 5, 'BM', NULL, 1, 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `classidiconcorso`
--

CREATE TABLE `classidiconcorso` (
  `ID` int UNSIGNED NOT NULL,
  `nome` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `livello` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `abilitazioniRichieste` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `classidiconcorso`
--

INSERT INTO `classidiconcorso` (`ID`, `nome`, `livello`, `abilitazioniRichieste`) VALUES
(1, 'Scienze e Tecnologie Informatiche', 'A41', 'Laurea in Informatica, Ingegneria informatica, Scienze dell\'informazione'),
(2, 'Matematica', 'A26', 'Laurea in Matematica, Fisica, Ingegneria'),
(7, 'Laboratorio Scienze e Tecnologie Informatiche', 'B16', 'Diploma di istituto tecnico superiore');

-- --------------------------------------------------------

--
-- Struttura della tabella `contratti`
--

CREATE TABLE `contratti` (
  `ID` int UNSIGNED NOT NULL,
  `tipoContratto` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `monteOre` smallint NOT NULL,
  `datainizio` date NOT NULL,
  `datafine` date DEFAULT NULL,
  `IDutente` int UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `contratti`
--

INSERT INTO `contratti` (`ID`, `tipoContratto`, `monteOre`, `datainizio`, `datafine`, `IDutente`) VALUES
(1, 'D', 12, '2025-09-15', '2026-06-06', 6),
(2, 'I', 18, '2025-09-15', NULL, 5);

-- --------------------------------------------------------

--
-- Struttura della tabella `dipartimenti`
--

CREATE TABLE `dipartimenti` (
  `ID` int UNSIGNED NOT NULL,
  `nome` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `IDutente` int UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `dipartimenti`
--

INSERT INTO `dipartimenti` (`ID`, `nome`, `IDutente`) VALUES
(1, 'Informatica', 5),
(2, 'Matematica', NULL),
(3, 'Elettronica e Automazione', 8);

-- --------------------------------------------------------

--
-- Struttura della tabella `discipline`
--

CREATE TABLE `discipline` (
  `ID` int UNSIGNED NOT NULL,
  `nome` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `anno` tinyint UNSIGNED NOT NULL,
  `oreLaboratorio` tinyint UNSIGNED NOT NULL,
  `oreTeoria` tinyint UNSIGNED NOT NULL,
  `disciplinaSpeciale` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `IDdipartimento` int UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `discipline`
--

INSERT INTO `discipline` (`ID`, `nome`, `anno`, `oreLaboratorio`, `oreTeoria`, `disciplinaSpeciale`, `IDdipartimento`) VALUES
(1, 'Matematica', 3, 0, 4, '', 2),
(2, 'Informatica', 4, 3, 3, NULL, 1),
(9, 'Sistemi', 4, 2, 2, NULL, 1),
(10, 'TPSIT', 4, 1, 1, NULL, 1),
(11, 'AI', 4, 1, 0, NULL, 1),
(12, 'GPOI', 5, 0, 3, NULL, 1),
(13, 'Telecomunicazioni', 4, 2, 1, NULL, 1),
(14, 'TPSEE', 4, 3, 1, NULL, 3),
(15, 'Elettr/Elettrot', 4, 2, 3, NULL, 3),
(16, 'Sistemi automatici', 4, 2, 3, NULL, 3),
(17, 'Energie rinnovabili', 4, 2, 0, NULL, 3),
(18, 'Robotica industriale', 4, 2, 0, NULL, 3),
(19, 'Informatica', 3, 3, 3, '', 1),
(20, 'Sistemi', 3, 2, 2, NULL, 1),
(21, 'TPSIT', 3, 1, 2, NULL, 1),
(22, 'Telecomunicazioni', 3, 2, 1, NULL, 1),
(23, 'Informatica', 5, 4, 2, NULL, 1),
(24, 'Sistemi', 5, 3, 1, NULL, 1),
(25, 'TPSIT', 5, 2, 1, NULL, 1),
(26, 'AI', 5, 1, 0, NULL, 1),
(36, 'Potenziamento B16', 0, 18, 0, 'potenziamento', 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `indirizzi`
--

CREATE TABLE `indirizzi` (
  `ID` int UNSIGNED NOT NULL,
  `nome` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `indirizzi`
--

INSERT INTO `indirizzi` (`ID`, `nome`) VALUES
(1, 'Informatica'),
(2, 'Elettronica'),
(3, 'Meccatronica'),
(4, 'Moda'),
(5, 'MAT');

-- --------------------------------------------------------

--
-- Struttura della tabella `richiedere`
--

CREATE TABLE `richiedere` (
  `ID` int NOT NULL,
  `IDutente` int UNSIGNED DEFAULT NULL,
  `IDclasseDiConcorso` int UNSIGNED DEFAULT NULL,
  `IDdisciplina` int UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `richiedere`
--

INSERT INTO `richiedere` (`ID`, `IDutente`, `IDclasseDiConcorso`, `IDdisciplina`) VALUES
(1, 1, 2, 1),
(2, 2, 1, 2),
(3, 5, 1, 2),
(4, 9, 7, 36),
(5, 9, 7, 2),
(6, 6, 1, NULL),
(7, 6, 7, NULL),
(8, 5, 1, NULL);

-- --------------------------------------------------------

--
-- Struttura della tabella `utenti`
--

CREATE TABLE `utenti` (
  `ID` int UNSIGNED NOT NULL,
  `email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `cognome` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nome` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `tipoUtente` char(1) CHARACTER SET armscii8 COLLATE armscii8_general_ci NOT NULL COMMENT 'P=Preside, A=Amministratore, D=Docente, C=Coordinatore del dipartimento ',
  `tipoDocente` char(1) CHARACTER SET armscii8 COLLATE armscii8_general_ci DEFAULT NULL,
  `colore` char(9) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `token` char(248) COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `utenti`
--

INSERT INTO `utenti` (`ID`, `email`, `password`, `cognome`, `nome`, `tipoUtente`, `tipoDocente`, `colore`, `token`) VALUES
(1, 'mario.rossi@iismarconipieralisi.it', 'marros00!', 'Rossi', 'Mario', 'D', 'T', '', NULL),
(2, 'luigi.bianchi@iismarconipieralisi.it\r\n', 'luibia00!', 'Bianchi', 'Luigi', 'D', 'L', '', NULL),
(3, 'mariarita.fiordelmondo@iismarconipieralisi.it', 'marfio00!', 'Fiordelmondo', 'Maria Rita', 'P', NULL, '', NULL),
(4, 'marco.aquilanti@iismarconipieralisi.it', 'maraqu00!', 'Aquilanti', 'Marco', 'D', 'L', '', NULL),
(5, 'Marcello.Pigini@iismarconipieralisi.it', 'Pigini', 'Pigini', 'Marcello', 'C', 'L', '000000064', NULL),
(6, 'carmelo.grigi@iismarconipieralisi.it', 'cargri00!', 'Grigi', 'Carmelo', 'D', 'T', '', NULL),
(7, 'simone.neri@iismarconipieralisi.it', 'simner00!', 'Neri', 'Simone', 'D', 'T', '', NULL),
(8, 'alessandro.savore@iismarconipieralisi.it', 'alesav00!', 'Savore', 'Alessandro', 'C', 'T', '', NULL),
(9, 'vittorio.alfieri@iismarconipieralisi.it', 'vitalf00!', 'Alfieri', 'Vittorio', 'A', 'L', '', NULL);

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `afferire`
--
ALTER TABLE `afferire`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IDdipartimento` (`IDdipartimento`) USING BTREE,
  ADD KEY `IDutente` (`IDutente`) USING BTREE;

--
-- Indici per le tabelle `anniscolastici`
--
ALTER TABLE `anniscolastici`
  ADD PRIMARY KEY (`ID`);

--
-- Indici per le tabelle `appartenere`
--
ALTER TABLE `appartenere`
  ADD UNIQUE KEY `IDindirizzo` (`IDindirizzo`,`IDdisciplina`),
  ADD KEY `IDdisciplinaAppartenere` (`IDdisciplina`);

--
-- Indici per le tabelle `assegnare`
--
ALTER TABLE `assegnare`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IDannoscolastico` (`IDannoscolastico`) USING BTREE,
  ADD KEY `IDutente` (`IDutente`) USING BTREE,
  ADD KEY `IDclasse` (`IDclasse`) USING BTREE,
  ADD KEY `IDdisciplina` (`IDdisciplina`) USING BTREE;

--
-- Indici per le tabelle `classi`
--
ALTER TABLE `classi`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `classeArticolataCon` (`classeArticolataCon`,`IDutente`),
  ADD KEY `IDutenteClassi` (`IDutente`),
  ADD KEY `IDindirizzo` (`IDindirizzo`) USING BTREE;

--
-- Indici per le tabelle `classidiconcorso`
--
ALTER TABLE `classidiconcorso`
  ADD PRIMARY KEY (`ID`);

--
-- Indici per le tabelle `contratti`
--
ALTER TABLE `contratti`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `IDutente` (`IDutente`);

--
-- Indici per le tabelle `dipartimenti`
--
ALTER TABLE `dipartimenti`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `IDutente` (`IDutente`);

--
-- Indici per le tabelle `discipline`
--
ALTER TABLE `discipline`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IDdipartimento` (`IDdipartimento`) USING BTREE;

--
-- Indici per le tabelle `indirizzi`
--
ALTER TABLE `indirizzi`
  ADD PRIMARY KEY (`ID`);

--
-- Indici per le tabelle `richiedere`
--
ALTER TABLE `richiedere`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IDdisciplia` (`IDdisciplina`) USING BTREE,
  ADD KEY `IDutente` (`IDutente`) USING BTREE,
  ADD KEY `IDclasseDiConcorso` (`IDclasseDiConcorso`) USING BTREE;

--
-- Indici per le tabelle `utenti`
--
ALTER TABLE `utenti`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `afferire`
--
ALTER TABLE `afferire`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT per la tabella `anniscolastici`
--
ALTER TABLE `anniscolastici`
  MODIFY `ID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `assegnare`
--
ALTER TABLE `assegnare`
  MODIFY `ID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `classi`
--
ALTER TABLE `classi`
  MODIFY `ID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `classidiconcorso`
--
ALTER TABLE `classidiconcorso`
  MODIFY `ID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `contratti`
--
ALTER TABLE `contratti`
  MODIFY `ID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT per la tabella `dipartimenti`
--
ALTER TABLE `dipartimenti`
  MODIFY `ID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT per la tabella `discipline`
--
ALTER TABLE `discipline`
  MODIFY `ID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT per la tabella `indirizzi`
--
ALTER TABLE `indirizzi`
  MODIFY `ID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `richiedere`
--
ALTER TABLE `richiedere`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT per la tabella `utenti`
--
ALTER TABLE `utenti`
  MODIFY `ID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `afferire`
--
ALTER TABLE `afferire`
  ADD CONSTRAINT `IDdipartimentoAfferire` FOREIGN KEY (`IDdipartimento`) REFERENCES `dipartimenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `IDutenteAfferire` FOREIGN KEY (`IDutente`) REFERENCES `utenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `appartenere`
--
ALTER TABLE `appartenere`
  ADD CONSTRAINT `IDdisciplinaAppartenere` FOREIGN KEY (`IDdisciplina`) REFERENCES `discipline` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `IDindirizzoAppartenere` FOREIGN KEY (`IDindirizzo`) REFERENCES `indirizzi` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `assegnare`
--
ALTER TABLE `assegnare`
  ADD CONSTRAINT `IDannoScolatiscoAssegnare` FOREIGN KEY (`IDannoscolastico`) REFERENCES `anniscolastici` (`ID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `IDclasseAssegnare` FOREIGN KEY (`IDclasse`) REFERENCES `classi` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `IDdisciplinaAssegnare` FOREIGN KEY (`IDdisciplina`) REFERENCES `discipline` (`ID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `IDutenteAssegnare` FOREIGN KEY (`IDutente`) REFERENCES `utenti` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Limiti per la tabella `classi`
--
ALTER TABLE `classi`
  ADD CONSTRAINT `classeArticolata` FOREIGN KEY (`classeArticolataCon`) REFERENCES `classi` (`ID`) ON UPDATE CASCADE,
  ADD CONSTRAINT `IDindirizzoClasse` FOREIGN KEY (`IDindirizzo`) REFERENCES `indirizzi` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `IDutenteClassi` FOREIGN KEY (`IDutente`) REFERENCES `utenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `contratti`
--
ALTER TABLE `contratti`
  ADD CONSTRAINT `IDutenteContratti` FOREIGN KEY (`IDutente`) REFERENCES `utenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `dipartimenti`
--
ALTER TABLE `dipartimenti`
  ADD CONSTRAINT `IDutenteDipartimenti` FOREIGN KEY (`IDutente`) REFERENCES `utenti` (`ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Limiti per la tabella `discipline`
--
ALTER TABLE `discipline`
  ADD CONSTRAINT `IDdipartimentoDiscipline` FOREIGN KEY (`IDdipartimento`) REFERENCES `dipartimenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `richiedere`
--
ALTER TABLE `richiedere`
  ADD CONSTRAINT `IDclasseDiConcorsoRichiedere` FOREIGN KEY (`IDclasseDiConcorso`) REFERENCES `classidiconcorso` (`ID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `IDdisciplinaRichiedere` FOREIGN KEY (`IDdisciplina`) REFERENCES `discipline` (`ID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `IDutenteRichiedere` FOREIGN KEY (`IDutente`) REFERENCES `utenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
