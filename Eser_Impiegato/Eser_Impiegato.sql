DROP TABLE IF EXISTS Impiegato;
DROP TABLE IF EXISTS Reparto;
DROP TABLE IF EXISTS Citta_residenza;
DROP TABLE IF EXISTS Provincia_residenza;

use Eser_Impiegati

CREATE TABLE Impiegato(
	impiegatoId INT PRIMARY KEY IDENTITY (1,1),
	matricola VARCHAR(250) NOT NULL UNIQUE,
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	data_nascita DATE NOT NULL,
	ruolo VARCHAR(250) NOT NULL,
	reparto VARCHAR(250) NOT NULL,
	indirizzo_residenza VARCHAR(250) NOT NULL,
	citta_residenza VARCHAR(250) NOT NULL,
	provincia_residenza VARCHAR(250) NOT NULL
);

CREATE TABLE Reparto(
	RepartoID INT PRIMARY KEY IDENTITY (1,1),
	nome_reparto VARCHAR (250) NOT NULL
)
 
CREATE TABLE Provincia_residenza(
	provincia_residenzaID INT PRIMARY KEY IDENTITY (1,1),
	nome_provincia VARCHAR(250) NOT NULL,
	sigla VARCHAR(2) NOT NULL
);

CREATE TABLE Citta_residenza(
	citta_residenzaID INT PRIMARY KEY IDENTITY (1,1),
	nome_citta VARCHAR(250) NOT NULL,
	provinciaRIF INT NOT NULL,
	FOREIGN KEY (provinciaRIF) REFERENCES Provincia_residenza(provincia_residenzaID) ON DELETE CASCADE
); 

-- Inserimento di dati nella tabella Impiegato
INSERT INTO Impiegato (matricola, nome, cognome, data_nascita, ruolo, reparto, indirizzo_residenza, citta_residenza, provincia_residenza) VALUES 
('001', 'Francesco', 'Franceschulli', '1995-10-20', 'Assistente', 'Vendite', 'Via Palma 4', 'Milano', 'MI'),
('002', 'Luisa', 'Alessi', '2000-11-22', 'Analista', 'Marketing', 'Via Verdi 2', 'Roma', 'RM'),
('003', 'Luigi', 'Verdi', '1992-03-25', 'Sviluppatore', 'Produzione', 'Via Napoli 3', 'Napoli', 'NA'),
('004', 'Giulia', 'Rosa', '1988-07-10', 'HR Specialist', 'Risorse Umane', 'Via Torino 4', 'Torino', 'TO');

INSERT INTO Provincia_residenza (nome_provincia, sigla) VALUES 
('Milano', 'MI'),
('Roma', 'RM'),
('Napoli', 'NA'),
('Torino', 'TO');

INSERT INTO Citta_residenza (nome_citta, provinciaRIF) VALUES 
('Milano', 1), -- Milano, provincia di Milano
('Roma', 2), -- Roma, provincia di Roma
('Napoli', 3), -- Napoli, provincia di Napoli
('Torino', 4); -- Torino, provincia di Torino


INSERT INTO Reparto (nome_reparto) VALUES 
('Vendite'),
('Marketing'),
('Risorse Umane'),
('Produzione');

SELECT * FROM Impiegato;
SELECT * FROM Reparto;
SELECT * FROM Provincia_residenza;
SELECT * FROM Citta_residenza;

