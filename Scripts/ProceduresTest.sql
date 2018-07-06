USE SummerPractice
GO

CREATE PROCEDURE return_Medal_ID @title nvarchar(50)
AS
SELECT ID from Medals 
WHERE @title = Title
RETURN
GO

CREATE PROCEDURE return_Person_ID @name nvarchar(20), @surname nvarchar(30), @date_Of_Birth date
AS
SELECT ID from People 
WHERE (@name = Name AND @surname = Surname AND @date_Of_Birth = Date_of_birth)
RETURN
GO

CREATE PROCEDURE return_Rewarded_by_Medal @title nvarchar(50)
AS
DECLARE
@id AS INT
EXEC return_Medal_ID @title
SELECT @id = SCOPE_IDENTITY()
RETURN
GO