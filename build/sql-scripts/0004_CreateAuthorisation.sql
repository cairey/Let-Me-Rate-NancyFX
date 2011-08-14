USE [LetMeRate]
GO


CREATE TABLE [dbo].[Authorisation](
	[Id] [uniqueidentifier] NOT NULL,
	[UserAccountId] [uniqueidentifier] NOT NULL,
	[IPAddress] [varchar](39) NOT NULL,
	[TokenKey] [nvarchar](50) NOT NULL,
	[TokenExpiry] [datetime] NOT NULL,
 CONSTRAINT [PK_Authorisation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Authorisation]  WITH CHECK ADD  CONSTRAINT [FK_Authorisation_UserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccount] ([Id])
GO

ALTER TABLE [dbo].[Authorisation] CHECK CONSTRAINT [FK_Authorisation_UserAccount]
GO