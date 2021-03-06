USE [master]
GO
/****** Object:  Database [OnlineShop1]    Script Date: 7/13/2020 1:02:17 PM ******/
CREATE DATABASE [OnlineShop1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineShop', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\\OnlineShop1.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OnlineShop_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\\OnlineShop1_0.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OnlineShop1] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineShop1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineShop1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineShop1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineShop1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineShop1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineShop1] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineShop1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineShop1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineShop1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineShop1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineShop1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineShop1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineShop1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineShop1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineShop1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineShop1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OnlineShop1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineShop1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineShop1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineShop1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineShop1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineShop1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnlineShop1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineShop1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineShop1] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineShop1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineShop1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineShop1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineShop1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [OnlineShop1] SET DELAYED_DURABILITY = DISABLED 
GO
USE [OnlineShop1]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 7/13/2020 1:02:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BankName] [nchar](10) NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cooker]    Script Date: 7/13/2020 1:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cooker](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[VendorId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Cooker] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 7/13/2020 1:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Manager](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](32) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/13/2020 1:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[VendorID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL CONSTRAINT [DF_Order_Quantity1]  DEFAULT ((0)),
	[Quantity] [int] NOT NULL CONSTRAINT [DF_Order_Quantity]  DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Order_CreatedDate]  DEFAULT (getdate()),
	[PaymentMethod] [int] NOT NULL CONSTRAINT [DF_Order_PaymentStatus1]  DEFAULT ((0)),
	[PaymentStatus] [int] NOT NULL CONSTRAINT [DF_Order_PaymentStatus]  DEFAULT ((0)),
	[FoodStatus] [int] NOT NULL CONSTRAINT [DF_Order_FoodStatus]  DEFAULT ((0)),
	[Status] [bit] NOT NULL CONSTRAINT [DF_Order_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/13/2020 1:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Image] [nvarchar](250) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL CONSTRAINT [DF_Product_Price]  DEFAULT ((0)),
	[Quantity] [int] NOT NULL CONSTRAINT [DF_Product_Quantity]  DEFAULT ((0)),
	[VendorID] [bigint] NOT NULL,
	[DisplayOrder] [int] NOT NULL CONSTRAINT [DF_Product_DisplayOrder]  DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Product_CreatedDate]  DEFAULT (getdate()),
	[Status] [bit] NOT NULL CONSTRAINT [DF_Product_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 7/13/2020 1:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Balance] [bigint] NOT NULL CONSTRAINT [DF_User_Balance]  DEFAULT ((0)),
	[Phone] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserBank]    Script Date: 7/13/2020 1:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBank](
	[UserID] [bigint] NOT NULL,
	[BankName] [nchar](255) NOT NULL,
	[STK] [nchar](30) NOT NULL,
	[Pass] [nchar](30) NOT NULL,
 CONSTRAINT [PK_UserBank] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[BankName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 7/13/2020 1:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendor](
	[VendorID] [bigint] IDENTITY(1,1) NOT NULL,
	[VendorAccount] [varchar](50) NULL,
	[VendorPassword] [varchar](50) NULL,
	[VendorName] [varchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[DisplayOrder] [int] NULL CONSTRAINT [DF_Vendor_DisplayOrder]  DEFAULT ((0)),
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[VendorAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [OnlineShop1] SET  READ_WRITE 
GO
