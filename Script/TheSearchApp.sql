USE [master]
GO
/****** Object:  Database [TheSearchApp]    Script Date: 14-Nov-21 19:25:39 ******/
CREATE DATABASE [TheSearchApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TheSearchApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TheSearchApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TheSearchApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TheSearchApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TheSearchApp] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TheSearchApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TheSearchApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TheSearchApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TheSearchApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TheSearchApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TheSearchApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [TheSearchApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TheSearchApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TheSearchApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TheSearchApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TheSearchApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TheSearchApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TheSearchApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TheSearchApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TheSearchApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TheSearchApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TheSearchApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TheSearchApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TheSearchApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TheSearchApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TheSearchApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TheSearchApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TheSearchApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TheSearchApp] SET RECOVERY FULL 
GO
ALTER DATABASE [TheSearchApp] SET  MULTI_USER 
GO
ALTER DATABASE [TheSearchApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TheSearchApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TheSearchApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TheSearchApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TheSearchApp] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TheSearchApp', N'ON'
GO
ALTER DATABASE [TheSearchApp] SET QUERY_STORE = OFF
GO
USE [TheSearchApp]
GO
/****** Object:  Table [dbo].[SearchHistory]    Script Date: 14-Nov-21 19:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchHistory](
	[SearchId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NULL,
	[SearchCategory] [varchar](50) NULL,
	[SearchCriteria] [varchar](1000) NULL,
	[APIRequest] [varchar](max) NULL,
	[APIResponse] [varchar](max) NULL,
	[RequestDate] [datetime] NULL,
 CONSTRAINT [PK_SearchHistory] PRIMARY KEY CLUSTERED 
(
	[SearchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [TheSearchApp] SET  READ_WRITE 
GO