USE [RoboArena]
GO

/****** Object:  StoredProcedure [dbo].[Create_Match]    Script Date: 2017-07-17 5:17:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Create_Match]
(
@seed INT
)
AS
BEGIN 
    INSERT INTO dbo.Match(Seed, Status)
    OUTPUT INSERTED.ID
	VALUES (@seed, 0)
END 
GO


