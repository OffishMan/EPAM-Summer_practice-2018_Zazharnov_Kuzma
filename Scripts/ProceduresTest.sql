USE EpamSummerPractice
GO

CREATE PROCEDURE CreatePerson  @name nvarchar(20), @surname nvarchar(30), @date_Of_Birth date, @age int, @city nvarchar(20), @street nvarchar(20), @house_number nvarchar(5)
AS
INSERT INTO People
VALUES (@name, @surname, @date_Of_Birth, @age, @city, @street, @house_number)
SELECT SCOPE_IDENTITY()

CREATE PROCEDURE CreateMedal @title nvarchar(50), @material nvarchar(10)
AS
INSERT INTO Medals
VALUES (@title, @material)
SELECT SCOPE_IDENTITY()

CREATE PROCEDURE UpdatePerson  @id int, @name nvarchar(20), @surname nvarchar(30), @date_Of_Birth date, @age int, @city nvarchar(20), @street nvarchar(20), @house_number nvarchar(5)
AS
UPDATE People SET Name = @name, Surname = @surname, Date_of_birth = @date_Of_Birth, Age = @age, City = @city, Street = @street, House_number = @house_number 
WHERE ID = @id

CREATE PROCEDURE UpdateMedal @id int, @title nvarchar(50), @material nvarchar(10)
AS
UPDATE Medals SET Title = @title, Material = @material
WHERE ID = @id

CREATE PROCEDURE CreateReward @idP int, @idM int
AS
INSERT INTO Rewards
VALUES (@IDp, @IDm)

CREATE PROCEDURE RemoveReward @idP int, @idM int
AS
DELETE FROM Rewards WHERE Person_ID = @idP AND Medal_ID = @idM

CREATE PROCEDURE RemovePerson @id int
AS
DELETE FROM People WHERE ID = @id

/*
CREATE PROCEDURE RemoveMedal @id int
AS
IF (SELECT COUNT(Person_ID) FROM Rewards WHERE Medal_ID = @id) < 1
BEGIN
	DELETE FROM Medals WHERE ID = @id
	SELECT 1
END
ELSE SELECT 0
*/

CREATE PROCEDURE RemoveMedal @id int
AS
DELETE FROM Medals WHERE ID = @id

CREATE PROCEDURE ShowAllMedals 
AS
SELECT * FROM Medals

CREATE PROCEDURE ShowAllPeople
AS
SELECT * FROM People

CREATE PROCEDURE ShowAllRewards
AS
SELECT People.Name, People.Surname, Medals.Material, Medals.Title FROM People 
JOIN Rewards ON People.ID = Rewards.Person_ID
JOIN Medals ON Medals.ID = Rewards.Medal_ID

CREATE PROCEDURE ShowAllIdInRewards
AS
SELECT * FROM Rewards

CREATE PROCEDURE ReturnMedalID @title nvarchar(50)
AS
SELECT ID from Medals 
WHERE @title = Title
GO

CREATE PROCEDURE ReturnPersonID @name nvarchar(20), @surname nvarchar(30), @date_Of_Birth date
AS
SELECT ID from People 
WHERE (@name = Name AND @surname = Surname AND @date_Of_Birth = Date_of_birth)
GO

CREATE PROCEDURE ReturnPersonByID @id int
AS
SELECT * FROM People WHERE ID = @id

CREATE PROCEDURE ReturnMedalByID @id int
AS
SELECT * FROM Medals WHERE ID = @id

CREATE PROCEDURE FindRewardByMedalID @id int
AS
SELECT * FROM Rewards WHERE Medal_ID = @id

CREATE PROCEDURE FindRewardByPersonID @id int
AS
SELECT * FROM Rewards WHERE Person_ID = @id
/*
CREATE PROCEDURE ReturnRewardedByMedal @title nvarchar(50)
AS
DECLARE
@id AS INT
EXEC ReturnMedalID @title
SELECT @id = SCOPE_IDENTITY()
GO
*/