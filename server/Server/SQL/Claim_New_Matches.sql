USE [RoboArena]
GO

/****** Object:  StoredProcedure [dbo].[Claim_New_Matches]    Script Date: 2017-07-17 5:51:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Claim_New_Matches]
AS
BEGIN
	UPDATE dbo.Match
	SET Status = 1
    OUTPUT INSERTED.*
	WHERE Status = 0
END 
GO


