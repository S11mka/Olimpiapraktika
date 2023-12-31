USE [simak]
GO
/****** Object:  Table [dbo].[Lekarstva]    Script Date: 23.11.2023 13:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lekarstva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Manufacturer] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lekarstva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 23.11.2023 13:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 23.11.2023 13:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Lekarstva] ON 

INSERT [dbo].[Lekarstva] ([Id], [Name], [Price], [Manufacturer]) VALUES (1, N'Аспирин', 100, N'Байер')
INSERT [dbo].[Lekarstva] ([Id], [Name], [Price], [Manufacturer]) VALUES (2, N'Нурофен', 150, N'Рекитт Бенкизер')
INSERT [dbo].[Lekarstva] ([Id], [Name], [Price], [Manufacturer]) VALUES (4, N'Панадол', 120, N'ГлаксоСмитКляйн')
INSERT [dbo].[Lekarstva] ([Id], [Name], [Price], [Manufacturer]) VALUES (5, N'Но-шпа', 150, N'Россия')
INSERT [dbo].[Lekarstva] ([Id], [Name], [Price], [Manufacturer]) VALUES (7, N'd', 5, N'dd')
INSERT [dbo].[Lekarstva] ([Id], [Name], [Price], [Manufacturer]) VALUES (8, N'qwe', 12, N'eqwt')
INSERT [dbo].[Lekarstva] ([Id], [Name], [Price], [Manufacturer]) VALUES (13, N'Ибупрофен', 15, N'голова')
INSERT [dbo].[Lekarstva] ([Id], [Name], [Price], [Manufacturer]) VALUES (14, N'q', 1, N'q')
SET IDENTITY_INSERT [dbo].[Lekarstva] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Role]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Role]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [Password], [IdRole]) VALUES (3, N'admin', N'123', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [IdRole]) VALUES (4, N'user', N'123', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
