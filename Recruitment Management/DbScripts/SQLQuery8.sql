USE [Rms]
GO

/****** Object:  Table [dbo].[RmsInfo]    Script Date: 26-04-2021 11:14:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RmsInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CName] [varchar](100) NOT NULL,
	[Designation] [varchar](100) NOT NULL,
	[DRole] [varchar](300) NOT NULL,
	[Availabile] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


