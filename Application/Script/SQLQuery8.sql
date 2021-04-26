USE [UsersData]
GO

/****** Object:  Table [dbo].[Logininfo]    Script Date: 25-04-2021 22:17:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Logininfo](
	[ID] [nvarchar](10) NOT NULL,
	[EmailId] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Logininfo] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [Logininfo]
ALTER COLUMN [EmailId] nvarchar(100);

ALTER TABLE Logininfo
DROP COLUMN EmailId;