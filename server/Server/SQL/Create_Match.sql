CREATE PROCEDURE dbo.Create_Match
(
@seed INT
)
AS
BEGIN 
    INSERT INTO dbo.Match(Seed)
    OUTPUT INSERTED.ID
	VALUES (@seed)
END 