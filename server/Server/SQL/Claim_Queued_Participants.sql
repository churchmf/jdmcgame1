USE [RoboArena]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Claim_Queued_Participants]
AS
BEGIN
	DELETE FROM MatchQueue OUTPUT DELETED.*
END 
GO

