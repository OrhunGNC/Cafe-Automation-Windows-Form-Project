USE [master]
GO
/****** Object:  Database [Cafe]    Script Date: 2.09.2023 21:42:51 ******/
CREATE DATABASE [Cafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLKODLAB\MSSQL\DATA\Cafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLKODLAB\MSSQL\DATA\Cafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Cafe] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cafe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cafe] SET RECOVERY FULL 
GO
ALTER DATABASE [Cafe] SET  MULTI_USER 
GO
ALTER DATABASE [Cafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cafe', N'ON'
GO
ALTER DATABASE [Cafe] SET QUERY_STORE = ON
GO
ALTER DATABASE [Cafe] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Cafe]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 2.09.2023 21:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[musteriNo] [int] IDENTITY(1,1) NOT NULL,
	[musteriAdSoyad] [varchar](50) NULL,
	[musteriKAdi] [varchar](50) NULL,
	[musteriSifre] [varchar](50) NULL,
	[musteriBakiye] [money] NULL,
	[musteriTelefonNo] [varchar](11) NULL,
 CONSTRAINT [PK_Musteriler] PRIMARY KEY CLUSTERED 
(
	[musteriNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparisler]    Script Date: 2.09.2023 21:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparisler](
	[siparisNo] [int] IDENTITY(1,1) NOT NULL,
	[urunAdi] [varchar](50) NULL,
	[siparisUcret] [money] NULL,
	[siparisAdet] [int] NULL,
	[musteriNo] [int] NULL,
	[yoneticiNo] [int] NULL,
 CONSTRAINT [PK_Siparisler] PRIMARY KEY CLUSTERED 
(
	[siparisNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 2.09.2023 21:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[urunNo] [int] IDENTITY(1,1) NOT NULL,
	[urunIsim] [varchar](50) NULL,
	[urunKategori] [varchar](50) NULL,
	[urunFiyat] [money] NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[urunNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yoneticiler]    Script Date: 2.09.2023 21:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yoneticiler](
	[yoneticiNo] [int] IDENTITY(1,1) NOT NULL,
	[yoneticiAdSoyad] [varchar](50) NULL,
	[yoneticiKAdi] [varchar](50) NULL,
	[yoneticiSifre] [varchar](50) NULL,
	[yoneticiYas] [int] NULL,
	[yoneticiUnvan] [varchar](50) NULL,
	[yoneticiMaas] [money] NULL,
 CONSTRAINT [PK_Yoneticiler] PRIMARY KEY CLUSTERED 
(
	[yoneticiNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Musteriler] ON 

INSERT [dbo].[Musteriler] ([musteriNo], [musteriAdSoyad], [musteriKAdi], [musteriSifre], [musteriBakiye], [musteriTelefonNo]) VALUES (1, N'dasf', N'customer', N'1234', 3500.0000, N'0555')
SET IDENTITY_INSERT [dbo].[Musteriler] OFF
GO
SET IDENTITY_INSERT [dbo].[Siparisler] ON 

INSERT [dbo].[Siparisler] ([siparisNo], [urunAdi], [siparisUcret], [siparisAdet], [musteriNo], [yoneticiNo]) VALUES (1, N'CheeseCake', 550000.0000, 1, 1, 1)
INSERT [dbo].[Siparisler] ([siparisNo], [urunAdi], [siparisUcret], [siparisAdet], [musteriNo], [yoneticiNo]) VALUES (2, N'Pasta', 750000.0000, 2, 1, 1)
INSERT [dbo].[Siparisler] ([siparisNo], [urunAdi], [siparisUcret], [siparisAdet], [musteriNo], [yoneticiNo]) VALUES (3, N'Kahve', 620000.0000, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Siparisler] OFF
GO
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([urunNo], [urunIsim], [urunKategori], [urunFiyat]) VALUES (1, N'Kahve', N'Sicak İçecek', 62.0000)
INSERT [dbo].[Urunler] ([urunNo], [urunIsim], [urunKategori], [urunFiyat]) VALUES (2, N'CheeseCake', N'Tatlı', 55.0000)
INSERT [dbo].[Urunler] ([urunNo], [urunIsim], [urunKategori], [urunFiyat]) VALUES (3, N'Çay', N'Sicak İçecek', 20.0000)
INSERT [dbo].[Urunler] ([urunNo], [urunIsim], [urunKategori], [urunFiyat]) VALUES (4, N'Limonata', N'Soğuk İçecek', 50.0000)
INSERT [dbo].[Urunler] ([urunNo], [urunIsim], [urunKategori], [urunFiyat]) VALUES (5, N'Pasta', N'Tatlı', 75.0000)
INSERT [dbo].[Urunler] ([urunNo], [urunIsim], [urunKategori], [urunFiyat]) VALUES (6, N'Su', N'İçecek', 10.0000)
SET IDENTITY_INSERT [dbo].[Urunler] OFF
GO
SET IDENTITY_INSERT [dbo].[Yoneticiler] ON 

INSERT [dbo].[Yoneticiler] ([yoneticiNo], [yoneticiAdSoyad], [yoneticiKAdi], [yoneticiSifre], [yoneticiYas], [yoneticiUnvan], [yoneticiMaas]) VALUES (1, N'fkdhlaj', N'admin', N'1234', 22, N'CEO', 45000.0000)
SET IDENTITY_INSERT [dbo].[Yoneticiler] OFF
GO
ALTER TABLE [dbo].[Siparisler]  WITH CHECK ADD  CONSTRAINT [FK_Siparisler_Musteriler] FOREIGN KEY([musteriNo])
REFERENCES [dbo].[Musteriler] ([musteriNo])
GO
ALTER TABLE [dbo].[Siparisler] CHECK CONSTRAINT [FK_Siparisler_Musteriler]
GO
ALTER TABLE [dbo].[Siparisler]  WITH CHECK ADD  CONSTRAINT [FK_Siparisler_Yoneticiler] FOREIGN KEY([yoneticiNo])
REFERENCES [dbo].[Yoneticiler] ([yoneticiNo])
GO
ALTER TABLE [dbo].[Siparisler] CHECK CONSTRAINT [FK_Siparisler_Yoneticiler]
GO
USE [master]
GO
ALTER DATABASE [Cafe] SET  READ_WRITE 
GO
