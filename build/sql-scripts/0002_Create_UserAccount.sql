USE [LetMeRate]

CREATE TABLE [dbo].[UserAccount](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Password] [nvarchar](512) NOT NULL,
	[PasswordSalt] [nvarchar](512) NOT NULL,
	[Key] [nvarchar](256) NOT NULL,
	[RateOutOf] [int] NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO