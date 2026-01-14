USE [master]
GO

/****** 1. ADIM: Veritabanı Kontrolü ve Oluşturma ******/
-- Veritabanı yoksa oluşturur, varsa hata vermeden geçer.
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Gorsel')
BEGIN
    CREATE DATABASE [Gorsel]
END
GO

USE [Gorsel]
GO

/****** 2. ADIM: Kullanıcı Tablosunu Oluşturma (tblUser) ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[tblUser](
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](50) NOT NULL,
        [Surname] [nvarchar](50) NOT NULL,
        [PlateNumber] [nvarchar](20) NOT NULL,
        [Password] [nvarchar](200) NOT NULL,
        CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED ([ID] ASC),
        CONSTRAINT [UQ_PlateNumber] UNIQUE NONCLUSTERED ([PlateNumber] ASC)
    )
END
GO

/****** 3. ADIM: Park İşlemleri Tablosunu Oluşturma (tblParkIslemleri) ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblParkIslemleri]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[tblParkIslemleri](
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [KatNumarasi] [int] NOT NULL,
        [ParkYeriNumarasi] [int] NOT NULL,
        [UserID] [int] NOT NULL,
        [GirisSaati] [datetime] NULL DEFAULT (getdate()),
        [CikisSaati] [datetime] NULL,
        [Durum] [bit] NULL DEFAULT ((1)),
        CONSTRAINT [PK_tblParkIslemleri] PRIMARY KEY CLUSTERED ([ID] ASC)
    )
END
GO

/****** 4. ADIM: Tablolar Arası İlişkiler (Foreign Key) ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblParkIslemleri_tblUser]'))
BEGIN
    ALTER TABLE [dbo].[tblParkIslemleri] WITH CHECK ADD CONSTRAINT [FK_tblParkIslemleri_tblUser] FOREIGN KEY([UserID])
    REFERENCES [dbo].[tblUser] ([ID])
    
    ALTER TABLE [dbo].[tblParkIslemleri] CHECK CONSTRAINT [FK_tblParkIslemleri_tblUser]
END
GO
