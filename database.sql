USE [SEP2020]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/8/2020 1:03:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Role] [varchar](50) NULL,
	[Check_active] [varchar](50) NULL,
	[ms_id] [varchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Teaching_Name] [nvarchar](50) NULL,
	[Lecture_Code] [nvarchar](50) NULL,
	[Degree] [nvarchar](50) NULL,
	[Falcuty_id] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Article]    Script Date: 3/8/2020 1:03:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Article](
	[id] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[conten] [nvarchar](500) NOT NULL,
	[date] [date] NULL,
	[author] [varchar](50) NOT NULL,
	[photo] [image] NULL,
	[id_semester] [int] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 3/8/2020 1:03:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RearchItem]    Script Date: 3/8/2020 1:03:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RearchItem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaNCKH] [nvarchar](50) NULL,
	[CT] [nvarchar](200) NULL,
	[unit] [nvarchar](50) NULL,
	[exchange] [int] NULL,
	[about] [nvarchar](500) NULL,
	[Category_id] [int] NOT NULL,
 CONSTRAINT [PK_RếarchItem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Research]    Script Date: 3/8/2020 1:03:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Research](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Explain] [nvarchar](500) NULL,
	[Quantity] [int] NULL,
	[Note] [nvarchar](200) NULL,
	[Semester_id] [int] NOT NULL,
	[Item_id] [int] NOT NULL,
	[Account_id] [int] NOT NULL,
 CONSTRAINT [PK_Research] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ResearchCategory]    Script Date: 3/8/2020 1:03:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResearchCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [int] NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_ResearchCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semester]    Script Date: 3/8/2020 1:03:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[id_semester] [int] IDENTITY(1,1) NOT NULL,
	[namesemester] [nvarchar](50) NOT NULL,
	[start_date] [date] NULL,
	[end_date] [date] NULL,
	[Account_id] [int] NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[id_semester] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Faculty] FOREIGN KEY([Falcuty_id])
REFERENCES [dbo].[Faculty] ([id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Faculty]
GO
ALTER TABLE [dbo].[RearchItem]  WITH CHECK ADD  CONSTRAINT [FK_RearchItem_ResearchCategory] FOREIGN KEY([Category_id])
REFERENCES [dbo].[ResearchCategory] ([id])
GO
ALTER TABLE [dbo].[RearchItem] CHECK CONSTRAINT [FK_RearchItem_ResearchCategory]
GO
ALTER TABLE [dbo].[Research]  WITH CHECK ADD  CONSTRAINT [FK_Research_Account] FOREIGN KEY([Account_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Research] CHECK CONSTRAINT [FK_Research_Account]
GO
ALTER TABLE [dbo].[Research]  WITH CHECK ADD  CONSTRAINT [FK_Research_RearchItem] FOREIGN KEY([Item_id])
REFERENCES [dbo].[RearchItem] ([id])
GO
ALTER TABLE [dbo].[Research] CHECK CONSTRAINT [FK_Research_RearchItem]
GO
ALTER TABLE [dbo].[Research]  WITH CHECK ADD  CONSTRAINT [FK_Research_Semester] FOREIGN KEY([Semester_id])
REFERENCES [dbo].[Semester] ([id_semester])
GO
ALTER TABLE [dbo].[Research] CHECK CONSTRAINT [FK_Research_Semester]
GO
