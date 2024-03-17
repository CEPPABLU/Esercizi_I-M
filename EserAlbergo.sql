DROP TABLE IF EXISTS Recensione;
DROP TABLE IF EXISTS Prenotazione;
DROP TABLE IF EXISTS Cliente;
DROP TABLE IF EXISTS Camera;
DROP TABLE IF EXISTS Dipendente;
DROP TABLE IF EXISTS Facilities;
DROP TABLE IF EXISTS Albergo;

CREATE TABLE Albergo(
	albergoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(200) NOT NULL,
	indirizzo VARCHAR(200) NOT NULL,
	UNIQUE(nome,indirizzo),
	stelle_albergo INT NOT NULL CHECK (stelle_albergo BETWEEN 1 AND 5)
);

CREATE TABLE Facilities (
	facilitiesID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(200) NOT NULL CHECK (nome IN('Piscina','Palestra','Spa')),
	descrizione VARCHAR(250) NOT NULL,
	orari TEXT NOT NULL, 
	albergoRIF INT NOT NULL,
	FOREIGN KEY(albergoRIF) REFERENCES Albergo (albergoID) ON DELETE CASCADE,
	UNIQUE(albergoRIF,facilitiesID)
);

CREATE TABLE Dipendente (
	dipendenteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(200) NOT NULL,
	cognome VARCHAR(200) NOT NULL,
	posizione VARCHAR(100) NOT NULL CHECK (posizione IN ('receptionist', 'personale di pulizia', 'manager')),
	telefono VARCHAR(30) NOT NULL,
	albergoRIF INT NOT NULL,
	FOREIGN KEY(albergoRIF) REFERENCES Albergo (albergoID) ON DELETE CASCADE,
	UNIQUE(albergoRIF, dipendenteID)
);

CREATE TABLE Camera (
	cameraID INT PRIMARY KEY IDENTITY(1,1),
	num_un INT NOT NULL,
	tipo VARCHAR(200) NOT NULL,
	cap_max INT NOT NULL CHECK ((cap_max >= 0) AND (cap_max<10)),
	tariffa DECIMAL(10,2) NOT NULL,
	albergoRIF INT NOT NULL,
	FOREIGN KEY(albergoRIF) REFERENCES Albergo (albergoID) ON DELETE CASCADE,
	UNIQUE(albergoRIF,num_un)
);

CREATE TABLE Cliente (
	clienteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(200) NOT NULL,
	cognome VARCHAR(200) NOT NULL,
	telefono VARCHAR(200) NOT NULL,
	-- Possibilità di inserire il Cod_Fis
);

CREATE TABLE Prenotazione (
	prenotazioneID INT PRIMARY KEY IDENTITY(1,1),
	data_checkin DATE NOT NULL,
	data_checkout DATE NOT NULL,
	CHECK (data_checkin < data_checkout),
	clienteRIF INT,
	cameraRIF INT NOT NULL,
	FOREIGN KEY(clienteRIF) REFERENCES Cliente (clienteID) ON DELETE SET NULL,
	FOREIGN KEY(cameraRIF) REFERENCES Camera (cameraID) ON DELETE CASCADE,
	UNIQUE(data_checkin, data_checkout, cameraRIF, clienteRIF)
	-- Risolviamo con un processo
);

CREATE TABLE Recensione(
	recensioneID INT PRIMARY KEY IDENTITY(1,1),
	valutazione INT CHECK (valutazione BETWEEN 1 AND 5),
	descrizione TEXT,
	prenotazioneRIF INT NOT NULL,
	FOREIGN KEY (prenotazioneRIF) REFERENCES Prenotazione(prenotazioneID) ON DELETE CASCADE
	-- Verificare se la recensione può essere inserita a fine del soggiorno (checkout riempito)
);

INSERT INTO Albergo(nome, indirizzo, stelle_albergo) VALUES
	('Hotel Vilòn', 'Via Francesco De Sanctis, 8', 5),
	('J.K. Place Roma', 'Via di Monte Oro 30', 3),
	('Portrait Roma', 'Via di Priscilla 42', 4),
	('The Pantheon Iconic Rome Hotel', 'Via Salita de Crescenzi', 1);

INSERT INTO Facilities(nome, descrizione, orari, albergoRIF) VALUES
	('Piscina', 'Piscina con lettini e ombrelloni', '10:00:00', 1),
	('Palestra', 'Palestra attrezzata con macchinari per esercizi cardio e pesistica', '08:00:00', 3), 
	('Spa', 'Spa con sala sensitiva', '09:00:00', 4),
	('Spa', 'Spa con sala sensitiva', '09:00:00', 2);
	

INSERT INTO Dipendente (nome, cognome, posizione, telefono, albergoRIF) VALUES
	('Mario', 'Rossi', 'Manager', '3471234567', 3),
	('Anna', 'Verdi', 'Receptionist', '3338765432', 2),
	('Luca', 'Bianchi', 'Personale di Pulizia', '3929876543', 1),
	('Chiara', 'Gialli', 'Receptionist', '3481234569', 4),
	('Francesco', 'Neri', 'Manager', '3357896541', 1),
	('Elena', 'Rossi', 'Personale di Pulizia', '3569874321', 2),
	('Marco', 'Bianchi', 'Manager', '3931236540', 4),
	('Sofia', 'Verdi', 'Receptionist', '3498762354', 1);

INSERT INTO Camera (num_un, tipo, cap_max, tariffa, albergoRIF) VALUES
	(40, 'Singola', 1, 50.00, 2),
	(41, 'Doppia', 2, 75.00, 3),
	(42, 'Doppia Superior', 2, 90.00, 4),
	(43, 'Singola con Letto Matrimoniale', 1, 60.00, 1),
	(44, 'Tripla', 3, 100.00, 3),
	(45, 'Doppia con Letto King Size', 2, 85.00, 1),
	(46, 'Singola Comfort', 1, 55.00, 2),
	(47, 'Doppia Standard', 2, 70.00, 4),
	(48, 'Suite', 4, 120.00, 2),
	(49, 'Doppia con Balcone', 2, 80.00, 3),
	(50, 'Singola Economy', 1, 45.00, 1),
	(51, 'Tripla Standard', 3, 95.00, 4),
	(52, 'Doppia Deluxe', 2, 100.00, 2),
	(53, 'Suite Familiare', 4, 130.00, 3),
	(54, 'Doppia Vista Mare', 2, 95.00, 2),
	(55, 'Singola Business', 1, 65.00, 1),
	(56, 'Tripla Superior', 3, 110.00, 2),
	(57, 'Doppia con Terrazzo', 2, 88.00, 3),
	(58, 'Suite Presidenziale', 4, 150.00, 4);

INSERT INTO Cliente VALUES
	('John', 'Smith', '123-456-7890'),
	('Jane', 'Doe', '987-654-3210'),
	('Michael', 'Brown', '555-123-4567'),
	('Emily', 'Jones', '888-765-4321'),
	('David', 'Williams', '222-333-4444'),
	('Jennifer', 'Miller', '444-555-6666'),
	('Charles', 'Garcia', '333-222-1111'),
	('Sarah', 'Johnson', '111-000-9999'),
	('Andrew', 'Robinson', '777-888-5555'),
	('Margaret', 'Lewis', '666-999-8888'),
	('Daniel', 'Clark', '555-000-7777'),
	('Kristen', 'Walker', '444-999-6666'),
	('Joseph', 'Allen', '333-888-5555'),
	('Jessica', 'Hernandez', '222-777-4444'),
	('James', 'Moore', '111-666-3333'),
	('Ashley', 'Wilson', '777-555-2222'),
	('Christopher', 'Taylor', '666-444-1111'),
	('Stephanie', 'Thomas', '555-333-0000'),
	('William', 'Martin', '444-222-9999'),
	('Angela', 'Lopez', '333-111-8888'),
	('Brandon', 'Lee', '222-000-7777'),
	('Nicole', 'Harris', '111-999-6666'),
	('Alexander', 'Young', '777-888-5555'),
	('Victoria', 'Scott', '666-777-4444'),
	('Benjamin', 'Adams', '555-666-3333'),
	('Emily', 'Alexander', '444-555-2222'),
	('Olivia', 'Nelson', '333-444-1111'),
	('Matthew', 'Baker', '222-333-0000'),
	('Hannah', 'Hall', '111-222-9999');

INSERT INTO Prenotazione (data_checkin, data_checkout, clienteRIF, cameraRIF) VALUES
	('2024-02-19', '2024-02-27', 1, 2),
	('2023-03-26', '2023-03-31', 2, 2),
	('2008-12-31', '2009-01-10', 3, 1),  
	('2024-03-25', '2024-03-30', 4, 3),  
	('2024-03-19', '2024-03-24', 5, 4),  
	('2024-03-17', '2024-03-31', 6, 2),  
	('2024-03-23', '2024-03-28', 7, 1),  
	('2024-03-17', '2024-03-22', 8, 5),  
	('2024-03-20', '2024-03-25', 9, 3),  
	('2024-03-24', '2024-03-29', 10, 4); 

INSERT INTO Recensione (valutazione, descrizione, prenotazioneRIF) VALUES
	(3, 'Posto brutto', 3),
	(4, 'Posto bellissimo', 8),
	(5, 'Posto fantasmagorico', 5),
	(1, 'Posto orrendo', 3);

--SELECT * FROM Albergo;
--SELECT * FROM Facilities;
--SELECT * FROM Dipendente;
--SELECT * FROM Camera;
--SELECT * FROM Prenotazione;
--SELECT * FROM Cliente;
--SELECT * FROM Recensione;

--SELECT * 
--	FROM Cliente
--	JOIN Prenotazione ON Cliente.clienteID = Prenotazione.clienteRIF
--	JOIN Camera ON Prenotazione.cameraRIF = Camera.cameraID
--	JOIN Albergo ON Camera.albergoRIF = Albergo.albergoID
--	--WHERE cognome = 'Smith';
----
--CREATE VIEW albergoConRelativiClienti AS
--	SELECT al.nome AS 'Albergo', Cliente.nome + ' ' + Cliente.cognome AS 'Nominativo'
--		FROM Albergo al
--		JOIN Camera ON al.albergoID = Camera.albergoRIF
--		JOIN Prenotazione ON camera.cameraID = Prenotazione.cameraRIF
--		JOIN Cliente ON Prenotazione.clienteRIF = Cliente.clienteID; 
--		--WHERE cognome = 'Smith';

--CREATE VIEW albergoGeneraleRelativiClienti AS
--	SELECT al.*, Cliente.nome + ' ' + Cliente.cognome AS 'Nominativo'
--		FROM Albergo al
--		JOIN Camera ON al.albergoID = Camera.albergoRIF
--		JOIN Prenotazione ON camera.cameraID = Prenotazione.cameraRIF
--		JOIN Cliente ON Prenotazione.clienteRIF = Cliente.clienteID; 


--SELECT * FROM albergoConRelativiClienti;
--SELECT * FROM albergoGeneraleRelativiClienti;

-- Voglio una view che mi visualizzi il nome dell'albergo e la media delle valutazioni
DROP VIEW MediaRecensioneAlberghi;
CREATE VIEW MediaRecensioneAlberghi AS 
	Select *
		FROM Recensione
		JOIN Prenotazione ON Recensione.prenotazioneRIF = Prenotazione.prenotazioneID
		JOIN Camera ON Prenotazione.cameraRIF = Camera.cameraID
		JOIN Albergo ON Camera.albergoRIF = Albergo.albergoID;

DROP VIEW MediaRecensioneAlberghiVal;
CREATE VIEW MediaRecensioneAlberghiVal AS 
	Select *
		FROM Albergo
		JOIN Camera ON Albergo.albergoID = Camera.albergoRIF
		JOIN Prenotazione ON Camera.cameraID = Prenotazione.cameraRIF
		JOIN Recensione ON Prenotazione.prenotazioneID = Recensione.prenotazioneRIF
		JOIN Cliente ON Prenotazione.clienteRIF = Cliente.clienteID;

SELECT * FROM MediaRecensioneAlberghi;
SELECT * FROM MediaRecensioneAlberghiVal;

--Sull'esercizio degli alberghi, permettere la prenotazione solo tramite SP ed evitare che la prenotazione ne sovrasti una già attiva su una stanza.

	
SELECT * FROM Albergo
	JOIN Camera ON Albergo.albergoID = Camera.albergoRIF
	JOIN Prenotazione ON Camera.cameraID = Prenotazione.cameraRIF;

DECLARE @dataIngresso DATE ='2024-03-18'
DECLARE @dataUscita DATE ='2024-03-22'
DECLARE @cameraRIF INT = 1
DECLARE @contatore INT = 0


SELECT @contatore = COUNT(*)
	FROM Prenotazione 
	WHERE (data_checkin <= @dataIngresso AND data_checkin >= @dataUscita)
		OR(data_checkin <= @dataUscita AND data_checkout >= @dataUscita);

IF @contatore > 0 
	BEGIN
		PRINT 'Non possibile inserimento (disse il robot)'
	END
	BEGIN
		PRINT 'Inserimento effettuato'
	END
END





CREATE PROCEDURE CheckStanze
	@data_checkin DATE,
	@data_checkout DATE,
	@clienteRIF INT,
	@cameraRIF INT,