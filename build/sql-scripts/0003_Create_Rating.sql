USE [LetMeRate]

CREATE TABLE [dbo].[Rating](
	[Id] [uniqueidentifier] NOT NULL,
	[UserAccountId] [uniqueidentifier] NOT NULL,
	[Rating] [int] NOT NULL,
	[CustomParams] [nvarchar](2048) NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_UserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccount] ([Id])
GO

ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_UserAccount]
GO