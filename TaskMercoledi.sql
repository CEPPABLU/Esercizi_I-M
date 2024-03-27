DROP TABLE IF EXISTS Ordine_Prodotto;
DROP TABLE IF EXISTS Ordine;
DROP TABLE IF EXISTS Variazione;
DROP TABLE IF EXISTS Prodotto;
DROP TABLE IF EXISTS Categoria;
DROP TABLE IF EXISTS Utente;

use task_mercoledi;

CREATE TABLE Utente (
utenteID INT PRIMARY KEY IDENTITY(1,1),
nominativo VARCHAR (250) NOT NULL,
email VARCHAR(250) NOT NULL,
passwordUtente VARCHAR (250) NOT NULL,
UNIQUE (email, passwordUtente),
deleted DATETIME
);
CREATE TABLE Categoria(
categoriaID INT PRIMARY KEY IDENTITY (1,1),
nome VARCHAR (250) NOT NULL,
deleted DATETIME
);
CREATE TABLE Prodotto (
prodottoID INT PRIMARY KEY IDENTITY (1,1),
marca VARCHAR (250) NOT NULL,
descrizione VARCHAR (250) NOT NULL,
image VARCHAR(250),
categoriaRIF INT NOT NULL,
FOREIGN KEY (categoriaRIF) REFERENCES Categoria(categoriaID),
deleted DATETIME
);
CREATE TABLE Variazione (
variazioneID INT PRIMARY KEY IDENTITY (1,1),
colore VARCHAR(250) NOT NULL,
taglia VARCHAR (250) NOT NULL,
quantitaStock INT NOT NULL,
isDisponibile BIT DEFAULT 0,
prezzo DECIMAL (5,2) NOT NULL,
prezzoOF DECIMAL (5,2) ,
dataInScon DATETIME,
dataFinScon DATETIME ,
prodottoRIF INT NOT NULL,
FOREIGN KEY (prodottoRIF) REFERENCES Prodotto(prodottoID),
deleted DATETIME
);
CREATE TABLE Ordine (
ordineID INT PRIMARY KEY IDENTITY (1,1),
quantitaOrd INT NOT NULL,
dataOrd DATETIME NOT NULL,
utenteRIF INT NOT NULL,
FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID),
deleted DATETIME,
);
CREATE TABLE Ordine_Prodotto (
prodottoRIF INT NOT NULL,
utenteRIF INT NOT NULL,
variazioneRIF INT NOT NULL,
FOREIGN KEY (prodottoRIF) REFERENCES Prodotto(prodottoID),
FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID),
FOREIGN KEY (variazioneRIF) REFERENCES Variazione(variazioneID)
);

SELECT * FROM Utente;