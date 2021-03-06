USE [master]
GO
/****** Object:  Database [Hotel]    Script Date: 07/18/2018 09:11:46 ******/
CREATE DATABASE [Hotel] ON  PRIMARY 
( NAME = N'Hotel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Hotel.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Hotel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Hotel_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Hotel] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hotel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hotel] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Hotel] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Hotel] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Hotel] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Hotel] SET ARITHABORT OFF
GO
ALTER DATABASE [Hotel] SET AUTO_CLOSE ON
GO
ALTER DATABASE [Hotel] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Hotel] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Hotel] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Hotel] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Hotel] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Hotel] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Hotel] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Hotel] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Hotel] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Hotel] SET  ENABLE_BROKER
GO
ALTER DATABASE [Hotel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Hotel] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Hotel] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Hotel] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Hotel] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Hotel] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Hotel] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Hotel] SET  READ_WRITE
GO
ALTER DATABASE [Hotel] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Hotel] SET  MULTI_USER
GO
ALTER DATABASE [Hotel] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Hotel] SET DB_CHAINING OFF
GO
USE [Hotel]
GO
/****** Object:  Table [dbo].[tHotel]    Script Date: 07/18/2018 09:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tHotel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NULL,
	[adresa] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tSobe]    Script Date: 07/18/2018 09:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tSobe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hotelId] [int] NULL,
	[brojSobe] [int] NULL,
	[opisSobe] [varchar](50) NULL,
	[tipSobe] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[pUnosHotela]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pUnosHotela]( @naziv varchar(50), @adresa varchar(50))
AS
BEGIN
insert into dbo.tHotel(naziv, adresa) values(@naziv, @adresa)
END
GO
/****** Object:  StoredProcedure [dbo].[pBrisanjeHotela]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pBrisanjeHotela](@id int)
AS
BEGIN
DELETE FROM tHotel 
WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[pIspravakHotela]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pIspravakHotela](@id int, @naziv varchar(50), @adresa varchar(50))
AS
BEGIN
Update tHotel 
set naziv = @naziv, adresa = @adresa
WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[pPrikazSvihHotela]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pPrikazSvihHotela]
AS
BEGIN
Select * from tHotel
END
GO
/****** Object:  Table [dbo].[tGosti]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tGosti](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sobeId] [int] NULL,
	[ime] [varchar](50) NULL,
	[prezime] [varchar](50) NULL,
	[spol] [varchar](1) NULL,
	[datumRođenja] [date] NULL,
	[datumDolaska] [date] NULL,
	[datumOdlaska] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[pUnosSobe]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pUnosSobe](@hotelID int,@brojSobe int, @opisSobe varchar(50), @tipSobe varchar(50) )
AS

 BEGIN
IF @brojSobe not in (select brojSobe from tSobe where hotelId = @hotelID) 
BEGIN
INSERT INTO tSobe(hotelId, brojSobe, opisSobe, tipSobe)Values(@hotelID, @brojSobe, @opisSobe, @tipSobe) 
END
 END
GO
/****** Object:  StoredProcedure [dbo].[pIspravakSoba]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pIspravakSoba](@id int, @hotelId int, @brojSobe int, @opisSobe varchar(50), @tipSobe varchar(50))
AS
BEGIN
Update tSobe 
set hotelId = @hotelId, brojSobe = @brojSobe, opisSobe = @opisSobe, tipSobe = @tipSobe
WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[pBrisanjeSoba]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pBrisanjeSoba](@id int, @hotelId int)
AS
BEGIN
DELETE FROM tSobe 
WHERE id = @id AND
hotelId = @hotelId
END
GO
/****** Object:  StoredProcedure [dbo].[pPrikazSvihSoba]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pPrikazSvihSoba](@hotelId int)
AS
BEGIN
Select h.naziv 'Hotel',
       s.id 'Id', 
       s.brojSobe 'Broj sobe', 
       s.opisSobe 'Opis sobe', 
       s.tipSobe 'Tip sobe' 
       FROM  tSobe s INNER JOIN tHotel h ON h.id = s.hotelId 
       WHERE s.hotelId = @hotelId  
END
GO
/****** Object:  StoredProcedure [dbo].[pUnosGosta]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pUnosGosta]( @sobaId int, @ime varchar(50), @prezime varchar(50),
                            @spol varchar(1), @datumRodjenja date, @datumDolaska date, @datumOdlaska date )
AS



 BEGIN
 IF @sobaId not in (select sobeId from tGosti where sobeId = @sobaId and
                           @datumDolaska >= datumDolaska AND @datumDolaska <= datumOdlaska)
    
 BEGIN   
INSERT INTO tGosti(sobeId, ime, prezime, spol, datumRođenja, datumDolaska, datumOdlaska)Values(@sobaId, @ime, @prezime, @spol, @datumRodjenja, @datumDolaska, @datumOdlaska) 
 END
 END
GO
/****** Object:  StoredProcedure [dbo].[pPrikazGosta]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pPrikazGosta]
AS
BEGIN
Select  
        g.id 'ID gosta',
        h.naziv 'Hotel',
        s.brojSobe 'Broj sobe', 
        g.ime 'Ime',
        g.prezime 'Prezime',
        g.spol 'Spol',
        g.datumRođenja 'Datum rođenja',
        g.datumDolaska 'Datum dolaska',
        g.datumOdlaska 'Datum odlaska'
        FROM  tSobe s INNER JOIN tHotel h ON h.id = s.hotelId   
                      INNER JOIN tGosti g ON s.Id = g.sobeId
END
GO
/****** Object:  StoredProcedure [dbo].[pIspravakGOSTA]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pIspravakGOSTA](@id int, @hotelId int, @sobaId int, @ime varchar(50), @prezime varchar(50),
@spol varchar(1), @datumRođenja date, @datumDolaska date, @datumOdlaska date)
AS
BEGIN

Update tSobe  set hotelId = hotelId where id = @sobaId 

Update tGosti 
set sobeId = @sobaId, ime = @ime, prezime = @prezime, spol = @spol, datumRođenja = @datumRođenja, datumDolaska = @datumDolaska, datumOdlaska = @datumOdlaska
WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[pBrisanjeGosta]    Script Date: 07/18/2018 09:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pBrisanjeGosta](@id int, @sobaId int)
AS
BEGIN
DELETE FROM tGosti 
WHERE id = @id AND
sobeId = @sobaId
END
GO
/****** Object:  ForeignKey [FK__tSobe__tipSobe__060DEAE8]    Script Date: 07/18/2018 09:11:48 ******/
ALTER TABLE [dbo].[tSobe]  WITH CHECK ADD FOREIGN KEY([hotelId])
REFERENCES [dbo].[tHotel] ([id])
GO
/****** Object:  ForeignKey [FK__tGosti__sobeId__0AD2A005]    Script Date: 07/18/2018 09:12:00 ******/
ALTER TABLE [dbo].[tGosti]  WITH CHECK ADD FOREIGN KEY([sobeId])
REFERENCES [dbo].[tSobe] ([id])
GO
