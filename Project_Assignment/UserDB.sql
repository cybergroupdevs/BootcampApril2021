
use UserDB;
CREATE TABLE [dbo].[UserInfo](
[Id] [int] IDENTITY(1,1) NOT NULL,
[FirstName] [varchar](255) NULL,
[LastName] [varchar](255) NULL,
[Age] [int] NULL,
[Address] [varchar](255) NULL
PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
use UserDB;
Select * From UserInfo;