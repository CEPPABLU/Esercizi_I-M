USE eser_merc03

CREATE TABLE Prodotto(
	prodottoID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) NOT NULL DEFAULT NEWID(),
	nome VARCHAR(250) NOT NULL,
	descrizione TEXT,
	prezzo DECIMAL(10,2) NOT NULL CHECK (prezzo >= 0),
	quantita INTEGER DEFAULT 0 CHECK (quantita >= 0),
	categoria VARCHAR(250) NOT NULL,
	data_creazione DATE
);

ALTER TABLE Prodotto
ADD DEFAULT GETDATE() FOR data_creazione

SELECT * FROM Prodotto;