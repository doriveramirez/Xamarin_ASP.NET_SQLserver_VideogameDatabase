create database VideogamesDB
GO
USE [VideogamesDB]
GO
/****** Object:  User [admin]    Script Date: 10/12/2019 16:41:00 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [pepe]    Script Date: 10/12/2019 16:41:00 ******/
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
/****** Object:  Table [dbo].[Company]    Script Date: 10/12/2019 16:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [nchar](38) NOT NULL,
	[Nombre] [nchar](50) NULL,
	[FechaFundacion] [date] NULL,
	[NumeroUsuarios] [int] NULL,
	[Imagen] [image] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distribuidora]    Script Date: 10/12/2019 16:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distribuidora](
	[Id] [nchar](36) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[NumeroJuegosPublicados] [int] NOT NULL,
	[Imagen] [image] NULL,
 CONSTRAINT [PK_Distribuidora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/12/2019 16:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [nchar](38) NOT NULL,
	[Nombre] [nchar](50) NULL,
	[FechaNac] [date] NULL,
	[Dni] [nchar](9) NULL,
	[Password] [nchar](20) NULL,
	[Usuario] [nchar](20) NULL,
	[CompanyID] [nchar](38) NULL,
	[Imagen] [image] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videojuego]    Script Date: 10/12/2019 16:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videojuego](
	[Id] [nchar](38) NOT NULL,
	[Nombre] [nchar](50) NULL,
	[FechaPublicacion] [date] NULL,
	[VentasGenerados] [int] NULL,
	[NumeroPlataformasDisponibles] [int] NULL,
	[UsuarioID] [nchar](38) NULL,
	[DistribuidoraID] [nchar](36) NULL,
	[Imagen] [image] NULL,
 CONSTRAINT [PK_Videojuego] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Company]
GO
ALTER TABLE [dbo].[Videojuego]  WITH CHECK ADD  CONSTRAINT [FK_Videojuego_Distribuidora] FOREIGN KEY([DistribuidoraID])
REFERENCES [dbo].[Distribuidora] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Videojuego] CHECK CONSTRAINT [FK_Videojuego_Distribuidora]
GO
ALTER TABLE [dbo].[Videojuego]  WITH CHECK ADD  CONSTRAINT [FK_Videojuego_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Videojuego] CHECK CONSTRAINT [FK_Videojuego_Usuario]
GO
