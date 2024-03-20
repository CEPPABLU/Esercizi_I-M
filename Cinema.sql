DROP TABLE IF EXISTS Employee;
DROP TABLE IF EXISTS Review;
DROP TABLE IF EXISTS Ticket;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Showtime;
DROP TABLE IF EXISTS Movie;
DROP TABLE IF EXISTS Theater;
DROP TABLE IF EXISTS Cinema;

CREATE TABLE Cinema (
CinemaID INT PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
Address VARCHAR(255) NOT NULL,
Phone VARCHAR(20)
);
CREATE TABLE Theater (
TheaterID INT PRIMARY KEY,
CinemaID INT,
Name VARCHAR(50) NOT NULL,
Capacity INT NOT NULL,
ScreenType VARCHAR(50),
FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);
CREATE TABLE Movie (
MovieID INT PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
Director VARCHAR(100),
ReleaseDate DATE,
DurationMinutes INT,
Rating VARCHAR(5)
);
CREATE TABLE Showtime (
ShowtimeID INT PRIMARY KEY,
MovieID INT,
TheaterID INT,
ShowDateTime DATETIME NOT NULL,
Price DECIMAL(5,2) NOT NULL,
FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
FOREIGN KEY (TheaterID) REFERENCES Theater(TheaterID)
);
CREATE TABLE Customer (
CustomerID INT PRIMARY KEY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Email VARCHAR(100),
PhoneNumber VARCHAR(20)
);
CREATE TABLE Ticket (
TicketID INT PRIMARY KEY,
ShowtimeID INT,
SeatNumber VARCHAR(10) NOT NULL,
PurchasedDateTime DATETIME NOT NULL,
CustomerID INT,
FOREIGN KEY (ShowtimeID) REFERENCES Showtime(ShowtimeID),
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);
CREATE TABLE Review (
ReviewID INT PRIMARY KEY,
MovieID INT,
CustomerID INT,
ReviewText TEXT,
Rating INT CHECK (Rating >= 1 AND Rating <= 5),
ReviewDate DATETIME NOT NULL,
FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);
CREATE TABLE Employee (
EmployeeID INT PRIMARY KEY,
CinemaID INT,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Position VARCHAR(50),
HireDate DATE,
FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);

INSERT INTO Cinema (CinemaID, Name, Address, Phone)
VALUES
(1, 'Cinema Paradiso', 'Via Roma 123', '06 1234567'),
(2, 'Cinema inferno', 'Via Napoli 222', '+ 06 8574635');
 
INSERT INTO Theater (TheaterID, CinemaID, Name, Capacity, ScreenType)
VALUES
(1, 1, 'Sala 1', 100, '2D'),
(2, 1, 'Sala 2', 80, '3D'),
(3, 2, 'Sala 3', 150, 'IMAX'),
(4, 2, 'Sala 4', 120, '2D');
 
INSERT INTO Movie (MovieID, Title, Director, ReleaseDate, DurationMinutes, Rating)
VALUES
(1, 'The Shawshank Redemption', 'Frank Darabont', '1994-09-23', 142, '4'),
(2, 'Inception', 'Christopher Nolan', '2010-07-16', 148, '4'),
(3, 'Pulp Fiction', 'Quentin Tarantino', '1994-10-14', 154, '5');
 
INSERT INTO Showtime (ShowtimeID, MovieID, TheaterID, ShowDateTime, Price)
VALUES
(1, 1, 1, '2024-03-2 18:00:00', 10.00),
(2, 2, 3, '2024-03-2 20:00:00', 12.50),
(3, 3, 2, '2024-03-2 19:30:00', 11.00);
 
INSERT INTO Customer (CustomerID, FirstName, LastName, Email, PhoneNumber)
VALUES
(1, 'Mario', 'Rossi', 'mrossi@example.com', '3334657889'),
(2, 'Valerio', 'Bianchi', 'valbianch@example.com', '336970699'),
(3, 'Pippo', 'Franco', 'pippo@example.com', '336970699'),
(4, 'Filippo', 'Franco', 'filippo@example.com', '336970699');
 
INSERT INTO Ticket (TicketID, ShowtimeID, SeatNumber, PurchasedDateTime, CustomerID)
VALUES
(1, 1, 'A1', '2024-03-01 15:30:00', 1),
(2, 2, 'B5', '2024-03-01 10:45:00', 2),
(3, 2, 'B7', '2024-03-01 10:46:00', 3),
(4, 3, 'B9', '2024-03-01 10:46:00', 4);
 
INSERT INTO Review (ReviewID, MovieID, CustomerID, ReviewText, Rating, ReviewDate)
VALUES
(1, 1, 1, 'Bellissimo film,uno dei migliori!', 5, '2024-03-01 09:15:00'),
(2, 2, 2, 'Film dell''anno.', 4, '2024-03-01 22:30:00');
 
INSERT INTO Employee (EmployeeID, CinemaID, FirstName, LastName, Position, HireDate)
VALUES
(1, 1, 'Franco', 'Rossi', 'Manager', '2020-01-15'),
(2, 2, 'Luca', 'Gialli', 'Cassiere', '2022-03-01');

DROP VIEW FilmsInProgrammation;
CREATE VIEW FilmsInProgrammation AS
	SELECT Movie.Title, ShowDateTime, DurationMinutes, Rating  FROM Movie
	JOIN Showtime ON Movie.MovieID = Showtime.MovieID

DROP VIEW AvaibleSeatsForShow;
CREATE VIEW AvaibleSeatsForShow AS 
	SELECT Showtime.ShowtimeID,Showtime.MovieID,Showtime.Price,Theater.Capacity AS
	TotalSeats, Theater.Capacity - COUNT(Ticket.TicketID) AS 
	AvaibleSeats
	FROM Showtime 
	JOIN Theater ON Showtime.TheaterID = Theater.TheaterID
	LEFT JOIN Ticket ON Showtime.ShowtimeID = Ticket.ShowtimeID 
	GROUP BY Showtime.ShowtimeID,Showtime.MovieID,Showtime.TheaterID,Showtime.ShowDateTime,Showtime.Price,Theater.Capacity

DROP VIEW TotalEarningsPerMovie;
CREATE VIEW TotalEarningsPerMovie AS 
	SELECT Title, SUM(Price) AS 'Incasso totale'
	FROM Movie 
	JOIN Showtime ON Movie.MovieID = ShowTime.MovieID
	JOIN Ticket ON ShowTime.ShowtimeID = Ticket.ShowtimeID
	GROUP BY Title;
	
DROP VIEW RecentReviews;
CREATE VIEW RecentReviews AS
		SELECT Movie.Title, Review.Rating, ReviewText, ReviewDate 
		FROM Movie
		JOIN Review ON Movie.MovieID = Review.MovieID;

-- View per vedere i film in programmazione
SELECT * FROM FilmsInProgrammation;

-- View per gli incassi dei film
SELECT * FROM TotalEarningsPerMovie;
-- View per vedere le recensioni
SELECT * FROM RecentReviews
		ORDER BY ReviewDate DESC;

--View per vedere i posti liberi
SELECT * FROM AvaibleSeatsForShow;

--SP 
DROP PROCEDURE IF EXISTS PurchaseTicket;
CREATE PROCEDURE PurchaseTicket
	@ticketId INT,
	@showTimeId INT,
	@seatNumberValue VARCHAR(10),
	@customerId INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			SELECT ShowtimeID, SeatNumber FROM Ticket WHERE ShowtimeID = @showTimeId AND SeatNumber = @seatNumberValue
				IF @@ROWCOUNT > 0
					THROW 50002, 'Ticket già venduto', 1
				ELSE
					INSERT INTO Ticket (TicketID, ShowtimeID, SeatNumber, PurchasedDateTime, CustomerID) VALUES
						(@ticketId, @showTimeId, @seatNumberValue, CURRENT_TIMESTAMP, @customerId);

				PRINT 'Venduto'
		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION

		PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()

	END CATCH
END;

EXEC PurchaseTicket @ticketId = 7, @showTimeId = 2, @seatNumberValue = 'C10', @customerId = 5;
SELECT * FROM Ticket
SELECT * FROM Customer

-- SP UpdateMovieSchedule
--TODO

-- SP InsertNewMovie

DROP PROCEDURE IF EXISTS InsertNewMovie;
CREATE PROCEDURE InsertNewMovie
	@movieId INT,
	@titleValue VARCHAR(255),
	@directorValue VARCHAR(100),
	@releaseDateValue DATE,
	@durationMinutesValue INT,
	@ratingValue VARCHAR(5)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			SELECT Title, Director FROM Movie WHERE Title = @titleValue AND Director = @directorValue
				IF @@ROWCOUNT > 0
					THROW 50002, 'Film già presente', 1
				ELSE
					INSERT INTO Movie (MovieID, Title, Director, ReleaseDate, DurationMinutes, Rating) VALUES
						(@movieId, @titleValue, @directorValue, @releaseDateValue, @durationMinutesValue, @ratingValue);

				PRINT 'Nuovo film inserito'
		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION

		PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()

	END CATCH
END;

EXEC InsertNewMovie @movieId = 5, @titleValue = 'Rocco e i suoi fratelli', @directorValue = 'Luchino Visconti', @releaseDateValue = '1960-07-16',
		@durationMinutesValue = 170, @ratingValue = 5;
SELECT * FROM Movie;
--SP SubmitReview

DROP PROCEDURE IF EXISTS SubmitReview;
CREATE PROCEDURE SubmitReview
	@reviewId INT,
	@movieId INT,
	@customerId INT,
	@reviewTextValue TEXT,
	@ratingValue INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			SELECT TicketID, CustomerID 
			FROM Ticket 
			JOIN Showtime ON Ticket.ShowtimeID = Showtime.ShowtimeID 
			WHERE Ticket.CustomerID = @CustomerID AND Showtime.MovieID = @MovieID
				IF @@ROWCOUNT = 0
					THROW 50002, 'Cliente non presente', 1
				ELSE
					INSERT INTO Review(ReviewID, MovieID, CustomerID, ReviewText, Rating, ReviewDate) VALUES
						(@reviewId, @movieId, @customerId, @reviewTextValue, @ratingValue, CURRENT_TIMESTAMP)

					PRINT 'Biglietto aggiunto'
		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION

		PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()

	END CATCH
END;

EXEC SubmitReview @reviewId = 6, @movieId = 3, @customerId = 2, @reviewTextValue = 'Bello bello', @ratingValue = 4;
SELECT * FROM Review;