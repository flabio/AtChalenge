USE [AtChalenge]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 12/2/2023 07:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[IdComment] [int] IDENTITY(1,1) NOT NULL,
	[Descrption] [text] NOT NULL,
	[IdMovie] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Created_at] [smalldatetime] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[IdComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 12/2/2023 07:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[IdGender] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[IdGender] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 12/2/2023 07:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[IdMovie] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [ntext] NOT NULL,
	[Duration] [nvarchar](50) NOT NULL,
	[MovieYear] [nvarchar](10) NOT NULL,
	[DatePublication] [date] NOT NULL,
	[IdGender] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Created_at] [smalldatetime] NULL,
	[ImagenPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[IdMovie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1, N'Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen', 1, 1, CAST(N'2023-02-09T14:11:00' AS SmallDateTime))
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (2, N'Es un hecho establecido hace demasiado tiempo que un lector se distraerá con el contenido del texto de un sitio mientras que mira su diseño.', 1, 1, CAST(N'2023-02-09T14:11:00' AS SmallDateTime))
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1002, N'sdksdskd', 1, 1, NULL)
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1003, N'test 1', 1, 1, NULL)
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1004, N'djdsjsdj', 1, 1, NULL)
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1005, N'sdkjsdjds', 1, 1, NULL)
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1006, N'chakira', 1, 1, NULL)
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1007, N'dskds', 2, 1, NULL)
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1008, N'test de waknda', 3, 1, NULL)
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1009, N'Golang es una excelente pelicula', 8, 1, NULL)
INSERT [dbo].[Comment] ([IdComment], [Descrption], [IdMovie], [IsActive], [Created_at]) VALUES (1010, N'ok', 2, 1, NULL)
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([IdGender], [Name], [IsActive]) VALUES (1, N'action', 1)
INSERT [dbo].[Gender] ([IdGender], [Name], [IsActive]) VALUES (2, N'comedia', 1)
INSERT [dbo].[Gender] ([IdGender], [Name], [IsActive]) VALUES (3, N'Aventura', 1)
INSERT [dbo].[Gender] ([IdGender], [Name], [IsActive]) VALUES (1002, N'Animación', 1)
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([IdMovie], [Name], [Description], [Duration], [MovieYear], [DatePublication], [IdGender], [IsActive], [Created_at], [ImagenPath]) VALUES (1, N'El asalto', N'Al contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio.', N'2:30 ', N'2022', CAST(N'2023-02-09' AS Date), 1, 1, CAST(N'2023-02-09T14:02:00' AS SmallDateTime), N'https://localhost:7252/Archivos/medium-cover.jpg')
INSERT [dbo].[Movie] ([IdMovie], [Name], [Description], [Duration], [MovieYear], [DatePublication], [IdGender], [IsActive], [Created_at], [ImagenPath]) VALUES (2, N'American Raiders Battle Fire', N'Al contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio.', N'2:30 ', N'2022', CAST(N'2023-01-09' AS Date), 3, 1, CAST(N'2023-02-09T14:02:00' AS SmallDateTime), N'https://localhost:7252/Archivos/medium-cover_2.jpg')
INSERT [dbo].[Movie] ([IdMovie], [Name], [Description], [Duration], [MovieYear], [DatePublication], [IdGender], [IsActive], [Created_at], [ImagenPath]) VALUES (3, N'Black Panther: Wakanda Forever', N'Al contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio.', N'1:30', N'2023', CAST(N'2023-02-09' AS Date), 3, 1, CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'https://localhost:7252/Archivos/medium-cover_3.jpg')
INSERT [dbo].[Movie] ([IdMovie], [Name], [Description], [Duration], [MovieYear], [DatePublication], [IdGender], [IsActive], [Created_at], [ImagenPath]) VALUES (6, N'Legión de superhéroes', N'Al contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio.', N'2:30', N'2023', CAST(N'2023-02-09' AS Date), 1, 1, CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'https://localhost:7252/Archivos/medium-cover_4.jpg')
INSERT [dbo].[Movie] ([IdMovie], [Name], [Description], [Duration], [MovieYear], [DatePublication], [IdGender], [IsActive], [Created_at], [ImagenPath]) VALUES (7, N'El Laboratorio de Dexter: Viaje al Ego', N'Al contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio.', N'2:30', N'2023', CAST(N'2023-02-09' AS Date), 1002, 1, CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'https://localhost:7252/Archivos/medium-cover_7.jpg')
INSERT [dbo].[Movie] ([IdMovie], [Name], [Description], [Duration], [MovieYear], [DatePublication], [IdGender], [IsActive], [Created_at], [ImagenPath]) VALUES (8, N'Golang', N'es un lenguaAl contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio.', N'2:30', N'2023', CAST(N'2023-02-09' AS Date), 2, 1, CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'https://localhost:7252/Archivos/golang-gopher-2.jpg')
INSERT [dbo].[Movie] ([IdMovie], [Name], [Description], [Duration], [MovieYear], [DatePublication], [IdGender], [IsActive], [Created_at], [ImagenPath]) VALUES (9, N'El gato con botas: El último deseo', N'Al contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio.', N'3:45', N'2023', CAST(N'2023-02-09' AS Date), 1002, 1, CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'https://localhost:7252/Archivos/medium-cover_6.jpg')
INSERT [dbo].[Movie] ([IdMovie], [Name], [Description], [Duration], [MovieYear], [DatePublication], [IdGender], [IsActive], [Created_at], [ImagenPath]) VALUES (10, N'Vecinos', N'Al contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio.', N'3:45', N'2023', CAST(N'2023-02-09' AS Date), 2, 1, CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'https://localhost:7252/Archivos/medium-cover_5.jpg')
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Movie] FOREIGN KEY([IdMovie])
REFERENCES [dbo].[Movie] ([IdMovie])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Movie]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Gender] FOREIGN KEY([IdGender])
REFERENCES [dbo].[Gender] ([IdGender])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Gender]
GO
