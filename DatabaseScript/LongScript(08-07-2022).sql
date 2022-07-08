USE [master]
GO
/****** Object:  Database [EventSchedule]    Script Date: 07/08/2022 10:02:16 ******/
CREATE DATABASE [EventSchedule] ON  PRIMARY 
( NAME = N'EventSchedule', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQL2008EXP\MSSQL\DATA\EventSchedule.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EventSchedule_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQL2008EXP\MSSQL\DATA\EventSchedule_log.LDF' , SIZE = 20096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EventSchedule] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EventSchedule].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EventSchedule] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [EventSchedule] SET ANSI_NULLS OFF
GO
ALTER DATABASE [EventSchedule] SET ANSI_PADDING OFF
GO
ALTER DATABASE [EventSchedule] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [EventSchedule] SET ARITHABORT OFF
GO
ALTER DATABASE [EventSchedule] SET AUTO_CLOSE ON
GO
ALTER DATABASE [EventSchedule] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [EventSchedule] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [EventSchedule] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [EventSchedule] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [EventSchedule] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [EventSchedule] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [EventSchedule] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [EventSchedule] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [EventSchedule] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [EventSchedule] SET  ENABLE_BROKER
GO
ALTER DATABASE [EventSchedule] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [EventSchedule] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [EventSchedule] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [EventSchedule] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [EventSchedule] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [EventSchedule] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [EventSchedule] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [EventSchedule] SET  READ_WRITE
GO
ALTER DATABASE [EventSchedule] SET RECOVERY SIMPLE
GO
ALTER DATABASE [EventSchedule] SET  MULTI_USER
GO
ALTER DATABASE [EventSchedule] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [EventSchedule] SET DB_CHAINING OFF
GO
USE [EventSchedule]
GO
/****** Object:  Table [dbo].[tblLocation]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLocation](
	[location_id] [int] IDENTITY(1,1) NOT NULL,
	[location_detail] [nvarchar](max) NULL,
	[location_status] [char](10) NULL,
 CONSTRAINT [PK__tblLocat__771831EA145C0A3F] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblLocation] ON
INSERT [dbo].[tblLocation] ([location_id], [location_detail], [location_status]) VALUES (1, N'In FPTU', N'open      ')
INSERT [dbo].[tblLocation] ([location_id], [location_detail], [location_status]) VALUES (2, N'At the main hall', N'open      ')
INSERT [dbo].[tblLocation] ([location_id], [location_detail], [location_status]) VALUES (3, N'At room 121', N'close     ')
SET IDENTITY_INSERT [dbo].[tblLocation] OFF
/****** Object:  Table [dbo].[tblUser]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[users_id] [int] IDENTITY(1,1) NOT NULL,
	[users_name] [nvarchar](50) NULL,
	[users_phone] [nvarchar](10) NULL,
	[users_address] [nvarchar](100) NULL,
	[users_email] [nvarchar](100) NULL,
 CONSTRAINT [PK__tblUser__EAA7D14B1BFD2C07] PRIMARY KEY CLUSTERED 
(
	[users_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (1, N'Test', N'9882', N'TpHCM', N'Test@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (2, N'Phu', N'234332232', N'TPHCM', N'phu@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (3, N'Hanh', N'544554455', N'TPHCM', N'hanh@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (4, N'Tan', N'344344334', N'TPHCM', N'tan@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (5, N'Duc', N'234343434', N'TPHCM', N'duc@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (6, N'Nhan', N'232322323', N'TPHCM', N'nhan@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (7, N'Hong', N'233223232', N'TPHCM', N'hong@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (8, N'Hoang', N'456645454', N'TPHCM', N'hoang@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (9, N'Hien', N'222222222', N'HN', N'hien@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (12, N'lan', N'533443434', N'tphcm', N'lan@gmail.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (13, N'longphuc', N'757747474', N'tphcm', N'longthse150882@fpt.edu.vn')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (223, N'Testin', N'1226', N'HN', N'Test@email.com')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_phone], [users_address], [users_email]) VALUES (2203, N'UpdateUser', N'123212', N'TPHCM', N'Update@gmail.com ')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
/****** Object:  Table [dbo].[tblCategory]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblCateg__D54EE9B4014935CB] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON
INSERT [dbo].[tblCategory] ([category_id], [category_name]) VALUES (1, N'Business Events')
INSERT [dbo].[tblCategory] ([category_id], [category_name]) VALUES (2, N'Gaming Events')
INSERT [dbo].[tblCategory] ([category_id], [category_name]) VALUES (3, N'Academy Event')
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
/****** Object:  Table [dbo].[tblAdmin]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdmin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[admin_name] [nvarchar](100) NULL,
	[admin_phone] [nvarchar](10) NULL,
	[admin_email] [nvarchar](100) NULL,
	[admin_password] [nvarchar](100) NULL,
	[admin_role] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblClub__BCAD3DD90EA330E9] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblAdmin] ON
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (1, N'TestWebSurge', N'031232331', N'admin@gmail.com', N'1', N'admin')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (2, N'Club test', N'091232123 ', N'Test@gmail.com ', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (3, N'F Live Music', N'0930012148', N'fsharp.fpthcm@gmail.com', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (4, N'FPT football', N'0934215443', N'ffc.fptuhcm@gmail.com', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (5, N'Fstyle hiphop', N'0364652434', N'fptstyle.fpthcm@gmail.com', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (6, N'Multimedia Entertainment', N'0916111237', N'mec.fptuhcmc@gmail.com', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (7, N'FPT basketball', N'0945125844', N'fbc.fptuhcm@gmail.com', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (8, N'FPT Traditional Instruments', N'0967777929', N'fti.fptuhcm@gmail.com', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (9, N'FPTU Public Speaking', N'0945125847', N'fps.fptuhcm@gmail.com ', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (10, N'FPT Vovinam', N'0954812547', N'fvcvovinamclub@gmail.com', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (11, N'Japan Style', N'0548454745', N'jsc.fptuhcm@gmail.com', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (12, N'string', N'string    ', N'string   ', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (13, N'TestUpdate2', N'09322121  ', N'Test@gmail.com', N'1', N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (14, NULL, NULL, NULL, NULL, N'club')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role]) VALUES (15, N'noTestADD', N'0911919292', N'Add@gmail.com', N'123', N'club')
SET IDENTITY_INSERT [dbo].[tblAdmin] OFF
/****** Object:  Table [dbo].[tblEvent]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEvent](
	[event_id] [int] IDENTITY(1,1) NOT NULL,
	[event_name] [nvarchar](50) NULL,
	[event_content] [nvarchar](max) NULL,
	[event_start] [datetime] NULL,
	[created_by] [nvarchar](20) NULL,
	[event_code] [char](1) NULL,
	[event_status] [bit] NULL,
	[payment_status] [bit] NULL,
	[category_id] [int] NULL,
	[location_id] [int] NULL,
	[admin_id] [int] NULL,
	[event_end] [datetime] NULL,
 CONSTRAINT [PK__tblEvent__2370F7270519C6AF] PRIMARY KEY CLUSTERED 
(
	[event_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblEvent] ON
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (2, N'Event Cosplay Japan', N'Are you new to code? Then you come to the right place, in here we invite all those student who want to learn code, who join this event will be seeing a lot of our coding product(games, big project for big company),...', CAST(0x0000AF7200000000 AS DateTime), N'kien', N'2', 1, 1, 3, 1, 1, CAST(0x0000AF8600000000 AS DateTime))
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (3, N'The ultimate fighter', N'Welcome to vovinam, we present to you the ultimate fighter. In here we gather all those FPTU student to fight each other and win the final prize of 1 million vnd, in here you could compete with other student with different streng, skills,...Join now if you want to become the Ultimate Fighter', CAST(0x0000AF2100000000 AS DateTime), N'phu', N'3', 1, 1, 2, 1, 10, CAST(0x0000AF2200000000 AS DateTime))
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (4, N'Cosplay', N'Are you a weebs? Do you want to find out more about japan, do you want to be your dream character? Then you have come to the right place, in here we cosplay as our favorite character from various anime. We also have a contest which who cosplay the most beautifull will receive a big price, join now', CAST(0x0000AED000000000 AS DateTime), N'hanh', N'4', 1, 1, 3, 1, 11, NULL)
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (5, N'Hardware Cons ', N'Are you a hardware enthusiast? Then we got you corver, join out events now to find out more about hardware, and if you want to be more advances', CAST(0x0000AECF00000000 AS DateTime), N'long', N'5', 1, 1, 3, 1, 12, NULL)
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (6, N'Fieldtrip to vinh long ', N'Do you want to find out more about other country culture? Are you a students who want to learn more about history? Then join us in the adventure down to vinh long', CAST(0x0000B0CB00000000 AS DateTime), N'lang', N'6', 1, 1, 1, 1, 2, NULL)
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (7, N'Music Events ', N'Are you in love with music? Do you want to show your music talents to other people? Then this is the right place for you, join now and register your song so that you can perform it live on stage', CAST(0x0000AF5E00000000 AS DateTime), N'tan', N'7', 1, 1, 3, 1, 1, NULL)
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (8, N'The golden Kick ', N'This is a football competetion for those football lover, you will train and compete with other player, and the winner team will receive a grand price', CAST(0x0000B23900000000 AS DateTime), N'bao', N'8', 1, 1, 2, 1, 1, NULL)
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (11, N'Test', NULL, NULL, NULL, NULL, 1, 1, NULL, 1, 1, NULL)
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (12, N'Themtay', NULL, NULL, NULL, NULL, 1, 1, NULL, 1, 1, NULL)
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [created_by], [event_code], [event_status], [payment_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (13, N'TestKhoanTrang ', NULL, NULL, NULL, NULL, 1, 1, NULL, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[tblEvent] OFF
/****** Object:  Table [dbo].[tblVideo]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVideo](
	[video_id] [int] IDENTITY(1,1) NOT NULL,
	[video_url] [nvarchar](max) NULL,
	[event_id] [int] NULL,
	[video_name] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblVideo__E8F11E1007020F21] PRIMARY KEY CLUSTERED 
(
	[video_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblVideo] ON
INSERT [dbo].[tblVideo] ([video_id], [video_url], [event_id], [video_name]) VALUES (1, N'https://firebasestorage.googleapis.com/v0/b/testfirebase-a9644.appspot.com/o/Videos%2FQAvfpKyc?alt=media&token=3c6eeec0-f792-4607-8a5c-aa856567a869', 3, N'QAvfpKyc')
INSERT [dbo].[tblVideo] ([video_id], [video_url], [event_id], [video_name]) VALUES (2, N'https://firebasestorage.googleapis.com/v0/b/testfirebase-a9644.appspot.com/o/Videos%2FQAvfpKyc?alt=media&token=3c6eeec0-f792-4607-8a5c-aa856567a869', 2, N'testvideo')
INSERT [dbo].[tblVideo] ([video_id], [video_url], [event_id], [video_name]) VALUES (3, N'https://firebasestorage.googleapis.com/v0/b/testfirebase-a9644.appspot.com/o/Videos%2FQAvfpKyc?alt=media&token=3c6eeec0-f792-4607-8a5c-aa856567a869', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblVideo] OFF
/****** Object:  Table [dbo].[tblPayment]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPayment](
	[payment_url] [nvarchar](max) NULL,
	[payment_fee] [int] NULL,
	[payment_detail] [nvarchar](max) NULL,
	[event_id] [int] NULL,
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__tblPayme__ED1FC9EA182C9B23] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblPayment] ON
INSERT [dbo].[tblPayment] ([payment_url], [payment_fee], [payment_detail], [event_id], [payment_id]) VALUES (N'long', 50000, N'thanh toan cho event abc', 2, 4)
INSERT [dbo].[tblPayment] ([payment_url], [payment_fee], [payment_detail], [event_id], [payment_id]) VALUES (N'phuc', 50000, N'thanh toan cho gi do', 3, 5)
SET IDENTITY_INSERT [dbo].[tblPayment] OFF
/****** Object:  Table [dbo].[tblEventParticipated]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEventParticipated](
	[event_id] [int] NOT NULL,
	[users_id] [int] NOT NULL,
	[date_participated] [datetime] NULL,
	[payment_status] [bit] NULL,
	[users_status] [bit] NULL,
 CONSTRAINT [PK__tblEvent__8DDA8A3308EA5793] PRIMARY KEY CLUSTERED 
(
	[event_id] ASC,
	[users_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (2, 1, CAST(0x0000AF2100000000 AS DateTime), 1, 1)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (11, 1, CAST(0x0000AE1000000000 AS DateTime), 0, 0)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (11, 2, CAST(0x0000AF4900000000 AS DateTime), 0, 1)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (11, 3, CAST(0x0000AEB2010E6E47 AS DateTime), 1, 1)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (11, 6, CAST(0x0000AEB3007664D9 AS DateTime), 1, 1)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (11, 9, CAST(0x0000AEC000E8675A AS DateTime), NULL, NULL)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (11, 223, CAST(0x000007E400000000 AS DateTime), 0, 0)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (12, 1, CAST(0x0000AF2A00000000 AS DateTime), 1, 1)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (12, 2, CAST(0x0000AF3500000000 AS DateTime), 0, NULL)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (13, 1, CAST(0x0000AE1000000000 AS DateTime), 1, 1)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (13, 2, CAST(0x0000AE1000000000 AS DateTime), 0, NULL)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (13, 3, CAST(0x0000AE1000000000 AS DateTime), 1, NULL)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (13, 4, CAST(0x0000AE1000000000 AS DateTime), 1, NULL)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (13, 7, CAST(0x0000AEB3007D6717 AS DateTime), 1, NULL)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (13, 8, CAST(0x0000AEB3007D6717 AS DateTime), 0, NULL)
/****** Object:  Table [dbo].[tblImage]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblImage](
	[image_id] [int] IDENTITY(1,1) NOT NULL,
	[image_url] [nvarchar](max) NULL,
	[event_id] [int] NULL,
	[image_name] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblImage__DC9AC955108B795B] PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblImage] ON
INSERT [dbo].[tblImage] ([image_id], [image_url], [event_id], [image_name]) VALUES (1, N'https://cdn.phunusuckhoe.vn/ctvseo_ladang/huong-dan-cach-che-bien-ca-rot-cho-be-an-dam-kieu-nhat-dung-chuan.jpg', NULL, NULL)
INSERT [dbo].[tblImage] ([image_id], [image_url], [event_id], [image_name]) VALUES (2, N'https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2022/02/health_benefits_carrots_732x549_thumb-732x549.jpg', 2, N'testImage')
INSERT [dbo].[tblImage] ([image_id], [image_url], [event_id], [image_name]) VALUES (3, N'https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2022/02/health_benefits_carrots_732x549_thumb-732x549.jpg', NULL, N'testImage')
INSERT [dbo].[tblImage] ([image_id], [image_url], [event_id], [image_name]) VALUES (4, N'https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2022/02/health_benefits_carrots_732x549_thumb-732x549.jpg', NULL, NULL)
INSERT [dbo].[tblImage] ([image_id], [image_url], [event_id], [image_name]) VALUES (5, N'https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2022/02/health_benefits_carrots_732x549_thumb-732x549.jpg', NULL, NULL)
INSERT [dbo].[tblImage] ([image_id], [image_url], [event_id], [image_name]) VALUES (6, N'https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2022/02/health_benefits_carrots_732x549_thumb-732x549.jpg', 11, NULL)
INSERT [dbo].[tblImage] ([image_id], [image_url], [event_id], [image_name]) VALUES (12, N'https://upload.wikimedia.org/wikipedia/commons/0/06/Tr%C3%BAc_Anh_%E2%80%93_M%E1%BA%AFt_bi%E1%BA%BFc_BTS_%282%29.png', 11, NULL)
INSERT [dbo].[tblImage] ([image_id], [image_url], [event_id], [image_name]) VALUES (13, N'https://firebasestorage.googleapis.com/v0/b/testfirebase-a9644.appspot.com/o/Images%2FHA948FgL?alt=media&token=38cc14c7-26ae-4ee3-82b7-2aac5c08e1a6', 3, N'HA948FgL')
SET IDENTITY_INSERT [dbo].[tblImage] OFF
/****** Object:  Table [dbo].[tblFeedback]    Script Date: 07/08/2022 10:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFeedback](
	[feedback_id] [int] IDENTITY(1,1) NOT NULL,
	[comment] [nvarchar](max) NULL,
	[rating] [int] NULL,
	[created_time] [date] NULL,
	[event_id] [int] NULL,
	[users_id] [int] NULL,
 CONSTRAINT [PK__tblFeedb__7A6B2B8C0CBAE877] PRIMARY KEY CLUSTERED 
(
	[feedback_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblFeedback] ON
INSERT [dbo].[tblFeedback] ([feedback_id], [comment], [rating], [created_time], [event_id], [users_id]) VALUES (2, N'Su kien hayn''t', 1, CAST(0x6B430B00 AS Date), 13, 2)
INSERT [dbo].[tblFeedback] ([feedback_id], [comment], [rating], [created_time], [event_id], [users_id]) VALUES (4, N'Test fucnton', 5, CAST(0x0E440B00 AS Date), 13, 4)
INSERT [dbo].[tblFeedback] ([feedback_id], [comment], [rating], [created_time], [event_id], [users_id]) VALUES (13, N'SU kien de test cua ban nhu cut', 1, CAST(0x0E440B00 AS Date), 13, 3)
INSERT [dbo].[tblFeedback] ([feedback_id], [comment], [rating], [created_time], [event_id], [users_id]) VALUES (14, N'SU kien TEST FUCNTION', 1, CAST(0x0E440B00 AS Date), 13, 8)
INSERT [dbo].[tblFeedback] ([feedback_id], [comment], [rating], [created_time], [event_id], [users_id]) VALUES (16, N'Test Feedback', 5, CAST(0x24440B00 AS Date), 13, 8)
SET IDENTITY_INSERT [dbo].[tblFeedback] OFF
/****** Object:  ForeignKey [FK_tblEvent_tblAdmin]    Script Date: 07/08/2022 10:02:16 ******/
ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD  CONSTRAINT [FK_tblEvent_tblAdmin] FOREIGN KEY([admin_id])
REFERENCES [dbo].[tblAdmin] ([admin_id])
GO
ALTER TABLE [dbo].[tblEvent] CHECK CONSTRAINT [FK_tblEvent_tblAdmin]
GO
/****** Object:  ForeignKey [FK_tblEvent_tblCategory]    Script Date: 07/08/2022 10:02:16 ******/
ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD  CONSTRAINT [FK_tblEvent_tblCategory] FOREIGN KEY([category_id])
REFERENCES [dbo].[tblCategory] ([category_id])
GO
ALTER TABLE [dbo].[tblEvent] CHECK CONSTRAINT [FK_tblEvent_tblCategory]
GO
/****** Object:  ForeignKey [FK_tblEvent_tblLocation]    Script Date: 07/08/2022 10:02:16 ******/
ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD  CONSTRAINT [FK_tblEvent_tblLocation] FOREIGN KEY([location_id])
REFERENCES [dbo].[tblLocation] ([location_id])
GO
ALTER TABLE [dbo].[tblEvent] CHECK CONSTRAINT [FK_tblEvent_tblLocation]
GO
/****** Object:  ForeignKey [FK_tblVideo_tblEvent]    Script Date: 07/08/2022 10:02:16 ******/
ALTER TABLE [dbo].[tblVideo]  WITH CHECK ADD  CONSTRAINT [FK_tblVideo_tblEvent] FOREIGN KEY([event_id])
REFERENCES [dbo].[tblEvent] ([event_id])
GO
ALTER TABLE [dbo].[tblVideo] CHECK CONSTRAINT [FK_tblVideo_tblEvent]
GO
/****** Object:  ForeignKey [FK_tblPayment_tblEvent]    Script Date: 07/08/2022 10:02:16 ******/
ALTER TABLE [dbo].[tblPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblPayment_tblEvent] FOREIGN KEY([event_id])
REFERENCES [dbo].[tblEvent] ([event_id])
GO
ALTER TABLE [dbo].[tblPayment] CHECK CONSTRAINT [FK_tblPayment_tblEvent]
GO
/****** Object:  ForeignKey [FK_tblEventParticipated_tblEvent]    Script Date: 07/08/2022 10:02:16 ******/
ALTER TABLE [dbo].[tblEventParticipated]  WITH CHECK ADD  CONSTRAINT [FK_tblEventParticipated_tblEvent] FOREIGN KEY([event_id])
REFERENCES [dbo].[tblEvent] ([event_id])
GO
ALTER TABLE [dbo].[tblEventParticipated] CHECK CONSTRAINT [FK_tblEventParticipated_tblEvent]
GO
/****** Object:  ForeignKey [FK_tblEventParticipated_tblUser]    Script Date: 07/08/2022 10:02:16 ******/
ALTER TABLE [dbo].[tblEventParticipated]  WITH CHECK ADD  CONSTRAINT [FK_tblEventParticipated_tblUser] FOREIGN KEY([users_id])
REFERENCES [dbo].[tblUser] ([users_id])
GO
ALTER TABLE [dbo].[tblEventParticipated] CHECK CONSTRAINT [FK_tblEventParticipated_tblUser]
GO
/****** Object:  ForeignKey [FK_tblImage_tblEvent]    Script Date: 07/08/2022 10:02:16 ******/
ALTER TABLE [dbo].[tblImage]  WITH CHECK ADD  CONSTRAINT [FK_tblImage_tblEvent] FOREIGN KEY([event_id])
REFERENCES [dbo].[tblEvent] ([event_id])
GO
ALTER TABLE [dbo].[tblImage] CHECK CONSTRAINT [FK_tblImage_tblEvent]
GO
/****** Object:  ForeignKey [FK_tblFeedback_tblEventParticipated]    Script Date: 07/08/2022 10:02:16 ******/
ALTER TABLE [dbo].[tblFeedback]  WITH CHECK ADD  CONSTRAINT [FK_tblFeedback_tblEventParticipated] FOREIGN KEY([event_id], [users_id])
REFERENCES [dbo].[tblEventParticipated] ([event_id], [users_id])
GO
ALTER TABLE [dbo].[tblFeedback] CHECK CONSTRAINT [FK_tblFeedback_tblEventParticipated]
GO
