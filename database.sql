USE [master]
GO
/****** Object:  Database [ProjectNCT]    Script Date: 4/18/2020 3:04:53 PM ******/
CREATE DATABASE [ProjectNCT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectNCT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.AKAKSHUKI\MSSQL\DATA\ProjectNCT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectNCT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.AKAKSHUKI\MSSQL\DATA\ProjectNCT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProjectNCT] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectNCT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectNCT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectNCT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectNCT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectNCT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectNCT] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectNCT] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProjectNCT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectNCT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectNCT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectNCT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectNCT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectNCT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectNCT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectNCT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectNCT] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProjectNCT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectNCT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectNCT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectNCT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectNCT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectNCT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectNCT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectNCT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectNCT] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectNCT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectNCT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectNCT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectNCT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectNCT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectNCT] SET QUERY_STORE = OFF
GO
USE [ProjectNCT]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CateName] [nvarchar](500) NOT NULL,
	[ID_root] [int] NULL,
 CONSTRAINT [PK_ThemeMusic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoryUser]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[MusicID] [int] NOT NULL,
 CONSTRAINT [PK_HistoryUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LyricsMusic]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LyricsMusic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LMusicDetail] [nvarchar](max) NOT NULL,
	[MusicID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[WaitApproval] [bit] NOT NULL,
	[NotApproved] [bit] NOT NULL,
	[NewNotice] [bit] NOT NULL,
	[LMusicDayCreate] [datetime] NOT NULL,
 CONSTRAINT [PK_LyricsMusic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Music]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Music](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MusicName] [nvarchar](1000) NOT NULL,
	[UserID] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[MusicDownloadAllowed] [bit] NOT NULL,
	[MusicView] [int] NOT NULL,
	[SongOrMV] [bit] NOT NULL,
	[MusicImage] [nvarchar](500) NULL,
	[MusicDayCreate] [datetime] NOT NULL,
	[MusicNameUnsigned] [nvarchar](1000) NULL,
	[MusicRelated] [int] NULL,
 CONSTRAINT [PK_Music] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderVip]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderVip](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[PVipID] [int] NULL,
	[PaymentID] [int] NOT NULL,
	[OrdPrice] [int] NULL,
	[OrdDayCreate] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderVip] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageVip]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageVip](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PVipName] [nvarchar](200) NOT NULL,
	[PVipMonths] [int] NOT NULL,
	[PVipPrice] [int] NOT NULL,
 CONSTRAINT [PK_PackageVip] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partner]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partner](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PartnerName] [nvarchar](200) NOT NULL,
	[PartnerImage] [nvarchar](500) NOT NULL,
	[PartnerLink] [nvarchar](1000) NOT NULL,
	[PartnerActive] [bit] NOT NULL,
	[PartnerDayCreate] [datetime] NOT NULL,
 CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlaylistName] [nvarchar](500) NOT NULL,
	[UserID] [int] NOT NULL,
	[CateID] [int] NULL,
	[PlaylistImage] [nvarchar](500) NULL,
	[PlaylistDescription] [nvarchar](3000) NULL,
 CONSTRAINT [PK_PlaylistUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistMusic]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistMusic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlaylistID] [int] NOT NULL,
	[MusicID] [int] NOT NULL,
 CONSTRAINT [PK_MusicPlaylistUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quality]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quality](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QualityName] [nvarchar](50) NOT NULL,
	[QualityVip] [bit] NOT NULL,
 CONSTRAINT [PK_Quality] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QualityMusic]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QualityMusic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MusicID] [int] NOT NULL,
	[MusicFile] [nvarchar](500) NOT NULL,
	[QualityID] [int] NOT NULL,
	[QMusicApproved] [bit] NOT NULL,
	[NewFile] [bit] NOT NULL,
 CONSTRAINT [PK_QualityMusic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rank]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rank](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RMusicName] [nvarchar](200) NOT NULL,
	[RMusicStart] [date] NOT NULL,
	[RMusicEnd] [date] NOT NULL,
	[CateID] [int] NOT NULL,
	[SongOrMusic] [bit] NOT NULL,
	[OldWeekRankId] [int] NOT NULL,
 CONSTRAINT [PK_RankMusic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RankMusic]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RankMusic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RankID] [int] NOT NULL,
	[MusicID] [int] NOT NULL,
	[RMusicGrade] [int] NOT NULL,
 CONSTRAINT [PK_RankMusic_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SingerMusic]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SingerMusic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MusicID] [int] NOT NULL,
	[SingerID] [int] NOT NULL,
 CONSTRAINT [PK_SingerMusic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](500) NOT NULL,
	[UserDOB] [date] NULL,
	[UserGender] [bit] NULL,
	[UserVIP] [bit] NOT NULL,
	[UserEmail] [nvarchar](100) NULL,
	[UserPwd] [varchar](20) NULL,
	[UserImage] [nvarchar](500) NULL,
	[UserDescription] [nvarchar](max) NULL,
	[UserNameUnsigned] [nvarchar](500) NULL,
	[UserDayCreate] [datetime] NOT NULL,
	[RoleID] [int] NOT NULL,
	[UserActive] [bit] NOT NULL,
	[DayVipEnd] [datetime] NULL,
	[TokenUser] [nvarchar](20) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ViewMusic]    Script Date: 4/18/2020 3:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViewMusic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MusicID] [int] NOT NULL,
	[ViewDayCreate] [datetime] NOT NULL,
 CONSTRAINT [PK_ViewMusic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Quality] ON 

INSERT [dbo].[Quality] ([ID], [QualityName], [QualityVip]) VALUES (1, N'215kp', 0)
INSERT [dbo].[Quality] ([ID], [QualityName], [QualityVip]) VALUES (2, N'320kp', 1)
INSERT [dbo].[Quality] ([ID], [QualityName], [QualityVip]) VALUES (3, N'320mp', 0)
INSERT [dbo].[Quality] ([ID], [QualityName], [QualityVip]) VALUES (4, N'640mp', 1)
SET IDENTITY_INSERT [dbo].[Quality] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (2, N'singer')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (3, N'client')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [UserDOB], [UserGender], [UserVIP], [UserEmail], [UserPwd], [UserImage], [UserDescription], [UserNameUnsigned], [UserDayCreate], [RoleID], [UserActive], [DayVipEnd], [TokenUser]) VALUES (1, N'admin', CAST(N'1999-02-02' AS Date), 1, 0, N'admin', N'123', NULL, NULL, N'admin', CAST(N'2020-04-18T15:04:04.363' AS DateTime), 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[LyricsMusic] ADD  CONSTRAINT [DF_LyricsMusic_WaitApproval]  DEFAULT ((1)) FOR [WaitApproval]
GO
ALTER TABLE [dbo].[LyricsMusic] ADD  CONSTRAINT [DF_LyricsMusic_NotApproved]  DEFAULT ((0)) FOR [NotApproved]
GO
ALTER TABLE [dbo].[LyricsMusic] ADD  CONSTRAINT [DF_LyricsMusic_NewNotice]  DEFAULT ((1)) FOR [NewNotice]
GO
ALTER TABLE [dbo].[LyricsMusic] ADD  CONSTRAINT [DF_LyricsMusic_MLyricsDayCreate]  DEFAULT (getdate()) FOR [LMusicDayCreate]
GO
ALTER TABLE [dbo].[Music] ADD  CONSTRAINT [DF_Music_MusicDownloadAllowed]  DEFAULT ((1)) FOR [MusicDownloadAllowed]
GO
ALTER TABLE [dbo].[Music] ADD  CONSTRAINT [DF_Music_MusicView]  DEFAULT ((0)) FOR [MusicView]
GO
ALTER TABLE [dbo].[Music] ADD  CONSTRAINT [DF_Music_MusicDayCreate]  DEFAULT (getdate()) FOR [MusicDayCreate]
GO
ALTER TABLE [dbo].[OrderVip] ADD  CONSTRAINT [DF_OrderVip_OrdDayCreate]  DEFAULT (getdate()) FOR [OrdDayCreate]
GO
ALTER TABLE [dbo].[Partner] ADD  CONSTRAINT [DF_Partner_PartnerActive]  DEFAULT ((1)) FOR [PartnerActive]
GO
ALTER TABLE [dbo].[Partner] ADD  CONSTRAINT [DF_Partner_PartnerDayCreate]  DEFAULT (getdate()) FOR [PartnerDayCreate]
GO
ALTER TABLE [dbo].[QualityMusic] ADD  CONSTRAINT [DF_QualityMusic_QMusicApproved]  DEFAULT ((0)) FOR [QMusicApproved]
GO
ALTER TABLE [dbo].[QualityMusic] ADD  CONSTRAINT [DF_QualityMusic_NewFile]  DEFAULT ((1)) FOR [NewFile]
GO
ALTER TABLE [dbo].[Rank] ADD  CONSTRAINT [DF_Rank_OldWeekRankId]  DEFAULT ((0)) FOR [OldWeekRankId]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UserVIP]  DEFAULT ((0)) FOR [UserVIP]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_DayCreate]  DEFAULT (getdate()) FOR [UserDayCreate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UserActive]  DEFAULT ((1)) FOR [UserActive]
GO
ALTER TABLE [dbo].[ViewMusic] ADD  CONSTRAINT [DF_ViewMusic_ViewDayCreate]  DEFAULT (getdate()) FOR [ViewDayCreate]
GO
ALTER TABLE [dbo].[HistoryUser]  WITH CHECK ADD  CONSTRAINT [FK_HistoryUser_Music] FOREIGN KEY([MusicID])
REFERENCES [dbo].[Music] ([ID])
GO
ALTER TABLE [dbo].[HistoryUser] CHECK CONSTRAINT [FK_HistoryUser_Music]
GO
ALTER TABLE [dbo].[LyricsMusic]  WITH CHECK ADD  CONSTRAINT [FK_LyricsMusic_Music] FOREIGN KEY([MusicID])
REFERENCES [dbo].[Music] ([ID])
GO
ALTER TABLE [dbo].[LyricsMusic] CHECK CONSTRAINT [FK_LyricsMusic_Music]
GO
ALTER TABLE [dbo].[Music]  WITH CHECK ADD  CONSTRAINT [FK_Music_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Music] CHECK CONSTRAINT [FK_Music_User]
GO
ALTER TABLE [dbo].[OrderVip]  WITH CHECK ADD  CONSTRAINT [FK_OrderVip_PackageVip] FOREIGN KEY([PVipID])
REFERENCES [dbo].[PackageVip] ([ID])
GO
ALTER TABLE [dbo].[OrderVip] CHECK CONSTRAINT [FK_OrderVip_PackageVip]
GO
ALTER TABLE [dbo].[OrderVip]  WITH CHECK ADD  CONSTRAINT [FK_OrderVip_Payment] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment] ([ID])
GO
ALTER TABLE [dbo].[OrderVip] CHECK CONSTRAINT [FK_OrderVip_Payment]
GO
ALTER TABLE [dbo].[OrderVip]  WITH CHECK ADD  CONSTRAINT [FK_OrderVip_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[OrderVip] CHECK CONSTRAINT [FK_OrderVip_User]
GO
ALTER TABLE [dbo].[PlaylistMusic]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistMusic_Music] FOREIGN KEY([MusicID])
REFERENCES [dbo].[Music] ([ID])
GO
ALTER TABLE [dbo].[PlaylistMusic] CHECK CONSTRAINT [FK_PlaylistMusic_Music]
GO
ALTER TABLE [dbo].[QualityMusic]  WITH CHECK ADD  CONSTRAINT [FK_QualityMusic_Quality] FOREIGN KEY([QualityID])
REFERENCES [dbo].[Quality] ([ID])
GO
ALTER TABLE [dbo].[QualityMusic] CHECK CONSTRAINT [FK_QualityMusic_Quality]
GO
ALTER TABLE [dbo].[Rank]  WITH CHECK ADD  CONSTRAINT [FK_RankMusic_Category] FOREIGN KEY([CateID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Rank] CHECK CONSTRAINT [FK_RankMusic_Category]
GO
ALTER TABLE [dbo].[RankMusic]  WITH CHECK ADD  CONSTRAINT [FK_RankMusic_Music] FOREIGN KEY([MusicID])
REFERENCES [dbo].[Music] ([ID])
GO
ALTER TABLE [dbo].[RankMusic] CHECK CONSTRAINT [FK_RankMusic_Music]
GO
ALTER TABLE [dbo].[SingerMusic]  WITH CHECK ADD  CONSTRAINT [FK_SingerMusic_User] FOREIGN KEY([SingerID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[SingerMusic] CHECK CONSTRAINT [FK_SingerMusic_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [ProjectNCT] SET  READ_WRITE 
GO
