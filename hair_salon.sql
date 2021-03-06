USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 2/26/2016 10:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stylists]    Script Date: 2/26/2016 10:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (17, N'bunny', 9)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (18, N'bunny', 10)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name]) VALUES (9, N'test')
INSERT [dbo].[stylists] ([id], [name]) VALUES (10, N'test2')
SET IDENTITY_INSERT [dbo].[stylists] OFF
