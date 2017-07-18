USE [RoboArena]
GO

/****** Object:  Table [dbo].[Match]    Script Date: 2017-07-17 5:14:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Match](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Seed] [int] NOT NULL,
	[Status] [tinyint] NOT NULL
) ON [PRIMARY]
GO


