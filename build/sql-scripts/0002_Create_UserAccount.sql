USE [LetMeRate]
GO

/****** Object:  Table [dbo].[UserAccount]    Script Date: 07/26/2011 20:02:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserAccount](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Password] [nvarchar](512) NOT NULL,
	[PasswordSalt] [nvarchar](512) NOT NULL,
	[Key] [nvarchar](256) NOT NULL,
	[RateOutOf] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserAccount] ADD  CONSTRAINT [DF_UserAccount_Enabled]  DEFAULT ((0)) FOR [Enabled]
GO


