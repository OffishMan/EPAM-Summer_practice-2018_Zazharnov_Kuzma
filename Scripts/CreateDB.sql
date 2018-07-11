USE Practice
GO

CREATE TABLE [dbo].[Medals](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Material] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Medals] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 06.07.2018 22:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[Date_of_birth] [datetime] NOT NULL,
	[Age] [int] NOT NULL,
	[City] [nvarchar](20) NOT NULL,
	[Street] [nvarchar](20) NOT NULL,
	[House_number] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rewards]    Script Date: 06.07.2018 22:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rewards](
	[Person_ID] [int] NOT NULL,
	[Medal_ID] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Rewards]  WITH CHECK ADD  CONSTRAINT [FK_Rewards_Medals] FOREIGN KEY([Medal_ID])
REFERENCES [dbo].[Medals] ([ID])
--ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rewards] CHECK CONSTRAINT [FK_Rewards_Medals]
GO
ALTER TABLE [dbo].[Rewards]  WITH CHECK ADD  CONSTRAINT [FK_Rewards_People] FOREIGN KEY([Person_ID])
REFERENCES [dbo].[People] ([ID])
--ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rewards] CHECK CONSTRAINT [FK_Rewards_People]
GO
USE [master]
GO
ALTER DATABASE [SummerPractice] SET  READ_WRITE 
GO
