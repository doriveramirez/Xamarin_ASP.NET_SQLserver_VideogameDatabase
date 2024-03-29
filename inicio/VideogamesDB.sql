create database VideogamesDB
GO
USE [VideogamesDB]
GO
/****** Object:  User [admin]    Script Date: 12/12/2019 16:44:23 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [DESKTOP-3T6TSJI\AlumnadoTarde]    Script Date: 12/12/2019 16:44:23 ******/
CREATE USER [DESKTOP-3T6TSJI\AlumnadoTarde] FOR LOGIN [DESKTOP-3T6TSJI\AlumnadoTarde] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [pepe]    Script Date: 12/12/2019 16:44:23 ******/
CREATE USER [pepe] FOR LOGIN [pepe] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [admin]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [admin]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 12/12/2019 16:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [nchar](38) NOT NULL,
	[Name] [nchar](50) NULL,
	[FoundationDate] [date] NULL,
	[NumberOfUsers] [int] NULL,
	[Picture] [image] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distribuidora]    Script Date: 12/12/2019 16:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distribuidora](
	[Id] [nchar](36) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[NumberOfGamePublished] [int] NOT NULL,
	[Picture] [image] NULL,
 CONSTRAINT [PK_Distribuidora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Platforms]    Script Date: 12/12/2019 16:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platforms](
	[Id] [nchar](32) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[ReleaseDate] [date] NULL,
	[Description] [nvarchar](255) NULL,
	[SoldUnits] [int] NULL,
 CONSTRAINT [PK_Platforms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 12/12/2019 16:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[Id] [nchar](32) NOT NULL,
	[Played] [bit] NULL,
	[Mark] [int] NULL,
	[Description] [nvarchar](255) NULL,
	[UserID] [nchar](38) NOT NULL,
	[VideogameID] [nchar](38) NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/12/2019 16:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [nchar](38) NOT NULL,
	[Name] [nchar](50) NULL,
	[Birthday] [date] NULL,
	[Dni] [nchar](9) NULL,
	[Password] [nchar](20) NULL,
	[Username] [nchar](20) NULL,
	[CompanyID] [nchar](38) NULL,
	[Picture] [image] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videogame_Platforms]    Script Date: 12/12/2019 16:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videogame_Platforms](
	[PlatformID] [nchar](32) NOT NULL,
	[VideogameID] [nchar](38) NOT NULL,
 CONSTRAINT [PK_Videogame_Platforms] PRIMARY KEY CLUSTERED 
(
	[PlatformID] ASC,
	[VideogameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videojuego]    Script Date: 12/12/2019 16:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videojuego](
	[Id] [nchar](38) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ReleaseDate] [date] NULL,
	[SoldUnits] [int] NULL,
	[NumberOfAvailablePlatforms] [int] NULL,
	[UserID] [nchar](38) NULL,
	[DistributorID] [nchar](36) NULL,
	[Picture] [image] NULL,
 CONSTRAINT [PK_Videojuego] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Usuario] FOREIGN KEY([UserID])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Usuario]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Videojuego] FOREIGN KEY([VideogameID])
REFERENCES [dbo].[Videojuego] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Videojuego]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Company]
GO
ALTER TABLE [dbo].[Videogame_Platforms]  WITH CHECK ADD  CONSTRAINT [FK_Videogame_Platforms_Platforms] FOREIGN KEY([PlatformID])
REFERENCES [dbo].[Platforms] ([Id])
GO
ALTER TABLE [dbo].[Videogame_Platforms] CHECK CONSTRAINT [FK_Videogame_Platforms_Platforms]
GO
ALTER TABLE [dbo].[Videogame_Platforms]  WITH CHECK ADD  CONSTRAINT [FK_Videogame_Platforms_Videojuego] FOREIGN KEY([VideogameID])
REFERENCES [dbo].[Videojuego] ([Id])
GO
ALTER TABLE [dbo].[Videogame_Platforms] CHECK CONSTRAINT [FK_Videogame_Platforms_Videojuego]
GO
ALTER TABLE [dbo].[Videojuego]  WITH CHECK ADD  CONSTRAINT [FK_Videojuego_Distribuidora] FOREIGN KEY([DistributorID])
REFERENCES [dbo].[Distribuidora] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Videojuego] CHECK CONSTRAINT [FK_Videojuego_Distribuidora]
GO
ALTER TABLE [dbo].[Videojuego]  WITH CHECK ADD  CONSTRAINT [FK_Videojuego_Usuario] FOREIGN KEY([UserID])
REFERENCES [dbo].[Usuario] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Videojuego] CHECK CONSTRAINT [FK_Videojuego_Usuario]
GO
