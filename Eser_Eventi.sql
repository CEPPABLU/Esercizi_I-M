DROP TABLE IF EXISTS Risorsa;
DROP TABLE IF EXISTS Partecipante;
DROP TABLE IF EXISTS Evento;

CREATE TABLE Evento(
	eventoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL,
	descrizione TEXT NOT NULL,
	capacita INT NOT NULL,
	data_ora DATETIME NOT NULL,
	luogo VARCHAR(50) NOT NULL,
	UNIQUE(data_ora, luogo)
);

CREATE TABLE Partecipante(
	partecipanteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL,
	contatto VARCHAR(50) NOT NULL,
	biglietto VARCHAR(16) NOT NULL,
	eventoRIF INT NOT NULL,
	FOREIGN KEY (eventoRIF) REFERENCES Evento(eventoID),
	UNIQUE(biglietto,eventoRIF),
	deleted DATETIME
);

CREATE TABLE Risorsa(
	risorsaID INT PRIMARY KEY IDENTITY(1,1),
	tipo VARCHAR(250) NOT NULL,	-- vari tipi tra attrezzatura, cibo, bevande, ecc
	quantita INT NOT NULL,
	costo DECIMAL(5,2) NOT NULL,
	fornitore VARCHAR(250) NOT NULL,
	eventoRIF INT NOT NULL,
	FOREIGN KEY (eventoRIF) REFERENCES Evento(eventoID),
	deleted DATETIME
);

Select * From Evento