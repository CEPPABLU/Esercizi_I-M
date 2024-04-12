use Eser_ESa
DROP TABLE IF EXISTS Sistema_Oggetto
DROP TABLE IF EXISTS OggettoCeleste
DROP TABLE IF EXISTS Sistema

CREATE TABLE OggettoCeleste(
	oggettoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	codice VARCHAR(250) NOT NULL DEFAULT NEWID(),
	dataScoperta DATE NOT NULL,
	scopritore VARCHAR(250) NOT NULL,
	tipologia VARCHAR(250) NOT NULL,
	distanza DECIMAL(18,6) NOT NULL,
	angoloPolare DECIMAL (10,8) NOT NULL,
	distanzaRadiale DECIMAL (18,6) NOT NULL
);

CREATE TABLE Sistema(
	sistemaID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) NOT NULL DEFAULT NEWID(),
	nome VARCHAR(250) NOT NULL,
	tipo VARCHAR(250) NOT NULL CHECK (tipo IN ('Sistema planetario','Costellazione','Galassia'))
);

CREATE TABLE Sistema_Oggetto(
	sistemaRIF INT NOT NULL,
	oggettoRIF INT NOT NULL, 
	FOREIGN KEY (sistemaRIF) REFERENCES Sistema(sistemaID),
	FOREIGN KEY (oggettoRIF) REFERENCES OggettoCeleste(oggettoID),
	PRIMARY KEY(sistemaRIF, oggettoRIF)
);

INSERT INTO OggettoCeleste (nome, dataScoperta, scopritore, tipologia, distanza, angoloPolare, distanzaRadiale) VALUES
		('Terra','2024/03/20', 'Pippo', 'Sferica', 0.12, 5.17, 10.10),
		('Giove', '2024/03/20', 'Pappo', 'Gassosa', 0.55, 6.33, 18.24);

INSERT INTO Sistema (nome, tipo) VALUES 
		('Sistema Solare', 'Sistema planetario'),
		('Via Lattea', 'Galassia');

INSERT INTO Sistema_Oggetto (sistemaRIF, oggettoRIF) VALUES 
		(1 , 4),
		(2 , 5);

SELECT * FROM OggettoCeleste
SELECT * FROM Sistema
SELECT * FROM Sistema_Oggetto

SELECT * FROM OggettoCeleste JOIN Sistema_Oggetto ON OggettoCeleste.oggettoID = Sistema_Oggetto.oggettoRIF 