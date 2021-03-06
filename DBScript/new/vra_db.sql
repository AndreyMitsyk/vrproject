USE [vra_db]
GO
/****** Object:  Table [dbo].[Nation]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nation](
	[NatID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](25) NOT NULL,
 CONSTRAINT [pk_Nation_NatID] PRIMARY KEY CLUSTERED 
(
	[NatID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uk_Nation_Value] UNIQUE NONCLUSTERED 
(
	[Value] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Nation] ON
INSERT [dbo].[Nation] ([NatID], [Value]) VALUES (4, N'Голландец')
INSERT [dbo].[Nation] ([NatID], [Value]) VALUES (3, N'Итальянец')
INSERT [dbo].[Nation] ([NatID], [Value]) VALUES (2, N'Немец')
INSERT [dbo].[Nation] ([NatID], [Value]) VALUES (1, N'Русский')
SET IDENTITY_INSERT [dbo].[Nation] OFF
/****** Object:  Table [dbo].[Artist]    Script Date: 05/24/2015 13:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Artist](
	[Name] [varchar](50) NOT NULL,
	[BirthYear] [numeric](4, 0) NULL,
	[DeceaseYear] [numeric](4, 0) NULL,
	[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	[NatID] [int] NULL,
 CONSTRAINT [XPKArtist] PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1Artist] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Artist] ON
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Андрей Рублев', CAST(1360 AS Numeric(4, 0)), CAST(1428 AS Numeric(4, 0)), 1, 1)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Альбрехт Альтдорфер', CAST(1480 AS Numeric(4, 0)), CAST(1538 AS Numeric(4, 0)), 2, 2)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Джованни Беллини', CAST(1430 AS Numeric(4, 0)), CAST(1516 AS Numeric(4, 0)), 3, 3)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Ян ван Эйк', CAST(1387 AS Numeric(4, 0)), CAST(1441 AS Numeric(4, 0)), 4, 4)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Сандро Боттичелли', CAST(1445 AS Numeric(4, 0)), CAST(1510 AS Numeric(4, 0)), 5, 3)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Леонардо да Винчи', CAST(1452 AS Numeric(4, 0)), CAST(1519 AS Numeric(4, 0)), 6, 3)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Джорджо Барбарелли', CAST(1476 AS Numeric(4, 0)), CAST(1510 AS Numeric(4, 0)), 7, 3)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Микеланджело Буонарроти', CAST(1475 AS Numeric(4, 0)), CAST(1564 AS Numeric(4, 0)), 8, 3)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Пьетро Перуджино', CAST(1446 AS Numeric(4, 0)), CAST(1524 AS Numeric(4, 0)), 9, 3)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Ерун Антонисон ван Акен', CAST(1450 AS Numeric(4, 0)), CAST(1516 AS Numeric(4, 0)), 10, 4)
INSERT [dbo].[Artist] ([Name], [BirthYear], [DeceaseYear], [ArtistID], [NatID]) VALUES (N'Рафаэль Санти', CAST(1483 AS Numeric(4, 0)), CAST(1520 AS Numeric(4, 0)), 11, 3)
SET IDENTITY_INSERT [dbo].[Artist] OFF
/****** Object:  Table [dbo].[Work]    Script Date: 05/24/2015 13:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Work](
	[Title] [varchar](50) NOT NULL,
	[Copy] [varchar](8) NULL,
	[Description] [varchar](100) NULL,
	[ArtistID] [int] NOT NULL,
	[WorkID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [XPKWork] PRIMARY KEY CLUSTERED 
(
	[WorkID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1Work] UNIQUE NONCLUSTERED 
(
	[Title] ASC,
	[Copy] ASC,
	[ArtistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Work] ON
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Троица', N'Копия', N'', 1, 1)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Битва Александра Македонского', N'Копия', N'', 2, 2)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'История Сусанны', N'Копия', N'', 2, 3)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Прощание Святого Флореана', N'Копия', N'', 2, 4)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Пир богов', N'Копия', N'', 3, 5)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Портрет четы Арнольфини', N'Копия', N'', 4, 6)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Рождение Венеры', N'Копия', N'', 5, 7)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Рождество', N'Копия', N'', 5, 8)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Весна', N'Копия', N'', 5, 9)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Благовещение', N'Копия', N'', 6, 10)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Дама с горностаем', N'Копия', N'', 6, 11)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Мадонна Литта', N'Копия', N'', 6, 12)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Мадонна в гроте', N'Копия', N'', 6, 13)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Тайная вечеря', N'Копия', N'', 6, 14)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Джоконда', N'Копия', N'', 6, 15)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Юдифь', N'Копия', N'', 7, 16)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Спящая Венера', N'Копия', N'', 7, 17)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Сотворение Адама', N'Копия', N'', 8, 18)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Страшный суд', N'Копия', N'', 8, 19)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Святое семейство', N'Копия', N'', 8, 20)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Сикстинская Капелла', N'Копия', N'', 8, 21)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Иисус вручает Святому Петру ключи', N'Копия', N'', 9, 22)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Блудный сын', N'Копия', N'', 10, 23)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Корабль дураков', N'Копия', N'', 10, 24)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Несение креста', N'Копия', N'', 10, 25)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Сад радостей земных', N'Копия', N'', 10, 26)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Дама с единорогом', N'Копия', N'', 11, 27)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Мадонна Бельведерская', N'Копия', N'', 11, 28)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Святой Михаил и дракон', N'Копия', N'', 11, 29)
INSERT [dbo].[Work] ([Title], [Copy], [Description], [ArtistID], [WorkID]) VALUES (N'Папа Лев X с кардиналами', N'Копия', N'', 11, 30)
SET IDENTITY_INSERT [dbo].[Work] OFF
/****** Object:  View [dbo].[ArtistWorkNet]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ArtistWorkNet]
AS
SELECT     dbo.[Work].WorkID, dbo.Artist.Name, dbo.[Work].Title, dbo.[Work].Copy, dbo.Trans.AcquisitionPrice, dbo.Trans.SalesPrice, 
                      dbo.Trans.SalesPrice - dbo.Trans.AcquisitionPrice AS NetPrice
FROM         dbo.Trans INNER JOIN
                      dbo.[Work] ON dbo.Trans.WorkID = dbo.[Work].WorkID INNER JOIN
                      dbo.Artist ON dbo.[Work].ArtistID = dbo.Artist.ArtistID
GO
/****** Object:  View [dbo].[ArtistNet]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ArtistNet](Name,TotalNet)
AS
SELECT ArtistWorkNet.Name,sum(NetPrice)
	FROM ArtistWorkNet
		GROUP BY Name
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[HouseNumber] [varchar](5) NULL,
	[Street] [varchar](50) NULL,
	[City] [varchar](35) NULL,
	[Region] [varchar](30) NULL,
	[ZipPostalCode] [varchar](6) NULL,
	[Country] [varchar](50) NULL,
	[PhoneNumber] [varchar](8) NULL,
	[AreaCode] [varchar](4) NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [XPKCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1Customer] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (1, N'Рыжков Николай Вадимович', N'', N'', N'', N'', N'', N'', N'', N'', N'Silverseeker@mail.ru')
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (2, N'Гершкович Рюрик Ермолаевич', N'', N'', N'', N'', N'', N'', N'', N'', N'Kagazil@mail.ru')
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (3, N'Юханцев Борислав Евстафиевич', N'', N'', N'', N'', N'', N'', N'', N'', N'Jugami@mail.ru')
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (4, N'Царицын Артем Епифанович', N'', N'', N'', N'', N'', N'', N'', N'', N'Coidi@mail.ru')
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (5, N'Ярмоненко Николай Михеевич', N'', N'', N'', N'', N'', N'', N'', N'', N'Nann@mail.ru')
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (6, N'Лоскутников Рубен Денисович', N'', N'', N'', N'', N'', N'', N'', N'', N'Dounris@mail.ru')
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (7, N'Касьяненко Сергей Ефремович', N'', N'', N'', N'', N'', N'', N'', N'', N'Arak@mail.ru')
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (8, N'Ванин Ким Мечиславович', N'', N'', N'', N'', N'', N'', N'', N'', N'Adriejurus@mail.ru')
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (9, N'Калошин Максим Ипатиевич', N'', N'', N'', N'', N'', N'', N'', N'', N'Granizar@mail.ru')
INSERT [dbo].[Customer] ([CustomerID], [Name], [HouseNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [PhoneNumber], [AreaCode], [Email]) VALUES (10, N'Сиянгулов Лука Ефремович', N'', N'', N'', N'', N'', N'', N'', N'', N'Centririn@mail.ru')
SET IDENTITY_INSERT [dbo].[Customer] OFF
/****** Object:  Table [dbo].[Trans]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trans](
	[DateAcquired] [datetime] NOT NULL,
	[AcquisitionPrice] [numeric](9, 2) NULL,
	[PurchaseDate] [datetime] NULL,
	[SalesPrice] [numeric](9, 2) NULL,
	[AskingPrice] [numeric](9, 2) NULL,
	[CustomerID] [int] NULL,
	[WorkID] [int] NOT NULL,
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [XPKTrans] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1Trans] UNIQUE NONCLUSTERED 
(
	[DateAcquired] ASC,
	[WorkID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Trans] ON
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A23E00000000 AS DateTime), CAST(203000.00 AS Numeric(9, 2)), NULL, NULL, CAST(406000.00 AS Numeric(9, 2)), NULL, 1, 1)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A36500000000 AS DateTime), CAST(218000.00 AS Numeric(9, 2)), NULL, NULL, CAST(436000.00 AS Numeric(9, 2)), NULL, 2, 2)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x00009FD900000000 AS DateTime), CAST(356000.00 AS Numeric(9, 2)), CAST(0x0000A18200000000 AS DateTime), CAST(400000.00 AS Numeric(9, 2)), CAST(712000.00 AS Numeric(9, 2)), 5, 3, 3)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A13000000000 AS DateTime), CAST(325000.00 AS Numeric(9, 2)), NULL, NULL, CAST(650000.00 AS Numeric(9, 2)), NULL, 4, 4)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A16C00000000 AS DateTime), CAST(205000.00 AS Numeric(9, 2)), CAST(0x0000A2DA00000000 AS DateTime), CAST(250000.00 AS Numeric(9, 2)), CAST(410000.00 AS Numeric(9, 2)), 9, 5, 5)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A2A100000000 AS DateTime), CAST(162000.00 AS Numeric(9, 2)), NULL, NULL, CAST(324000.00 AS Numeric(9, 2)), NULL, 6, 6)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A02100000000 AS DateTime), CAST(485000.00 AS Numeric(9, 2)), NULL, NULL, CAST(970000.00 AS Numeric(9, 2)), NULL, 7, 7)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A2CF00000000 AS DateTime), CAST(103000.00 AS Numeric(9, 2)), NULL, NULL, CAST(206000.00 AS Numeric(9, 2)), NULL, 8, 8)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x00009FF100000000 AS DateTime), CAST(226000.00 AS Numeric(9, 2)), CAST(0x0000A1F900000000 AS DateTime), CAST(300000.00 AS Numeric(9, 2)), CAST(452000.00 AS Numeric(9, 2)), 7, 9, 9)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A06B00000000 AS DateTime), CAST(483000.00 AS Numeric(9, 2)), CAST(0x0000A1D400000000 AS DateTime), CAST(500000.00 AS Numeric(9, 2)), CAST(966000.00 AS Numeric(9, 2)), 9, 10, 10)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A05500000000 AS DateTime), CAST(226000.00 AS Numeric(9, 2)), NULL, NULL, CAST(452000.00 AS Numeric(9, 2)), NULL, 11, 11)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A32100000000 AS DateTime), CAST(316000.00 AS Numeric(9, 2)), NULL, NULL, CAST(632000.00 AS Numeric(9, 2)), NULL, 12, 12)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A06E00000000 AS DateTime), CAST(212000.00 AS Numeric(9, 2)), NULL, NULL, CAST(424000.00 AS Numeric(9, 2)), NULL, 13, 13)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A29000000000 AS DateTime), CAST(296000.00 AS Numeric(9, 2)), NULL, NULL, CAST(592000.00 AS Numeric(9, 2)), NULL, 14, 14)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A10700000000 AS DateTime), CAST(403000.00 AS Numeric(9, 2)), CAST(0x0000A21A00000000 AS DateTime), CAST(450000.00 AS Numeric(9, 2)), CAST(806000.00 AS Numeric(9, 2)), 2, 15, 15)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A29A00000000 AS DateTime), CAST(208000.00 AS Numeric(9, 2)), CAST(0x0000A3C100000000 AS DateTime), CAST(230000.00 AS Numeric(9, 2)), CAST(416000.00 AS Numeric(9, 2)), 10, 16, 16)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A32300000000 AS DateTime), CAST(133000.00 AS Numeric(9, 2)), NULL, NULL, CAST(266000.00 AS Numeric(9, 2)), NULL, 17, 17)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A1B900000000 AS DateTime), CAST(185000.00 AS Numeric(9, 2)), NULL, NULL, CAST(370000.00 AS Numeric(9, 2)), NULL, 18, 18)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A14000000000 AS DateTime), CAST(212000.00 AS Numeric(9, 2)), CAST(0x0000A3A500000000 AS DateTime), CAST(240000.00 AS Numeric(9, 2)), CAST(424000.00 AS Numeric(9, 2)), 2, 19, 19)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A32D00000000 AS DateTime), CAST(124000.00 AS Numeric(9, 2)), NULL, NULL, CAST(248000.00 AS Numeric(9, 2)), NULL, 20, 20)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A1EB00000000 AS DateTime), CAST(147000.00 AS Numeric(9, 2)), NULL, NULL, CAST(294000.00 AS Numeric(9, 2)), NULL, 21, 21)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A14B00000000 AS DateTime), CAST(341000.00 AS Numeric(9, 2)), NULL, NULL, CAST(682000.00 AS Numeric(9, 2)), NULL, 22, 22)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A06E00000000 AS DateTime), CAST(126000.00 AS Numeric(9, 2)), CAST(0x0000A26F00000000 AS DateTime), CAST(150000.00 AS Numeric(9, 2)), CAST(252000.00 AS Numeric(9, 2)), 1, 23, 23)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A1B100000000 AS DateTime), CAST(476000.00 AS Numeric(9, 2)), CAST(0x0000A2ED00000000 AS DateTime), CAST(500000.00 AS Numeric(9, 2)), CAST(952000.00 AS Numeric(9, 2)), 9, 24, 24)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A34C00000000 AS DateTime), CAST(388000.00 AS Numeric(9, 2)), CAST(0x0000A3D900000000 AS DateTime), CAST(400000.00 AS Numeric(9, 2)), CAST(776000.00 AS Numeric(9, 2)), 7, 25, 25)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A38F00000000 AS DateTime), CAST(445000.00 AS Numeric(9, 2)), NULL, NULL, CAST(890000.00 AS Numeric(9, 2)), NULL, 26, 26)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A0B900000000 AS DateTime), CAST(199000.00 AS Numeric(9, 2)), NULL, NULL, CAST(398000.00 AS Numeric(9, 2)), NULL, 27, 27)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A0C400000000 AS DateTime), CAST(158000.00 AS Numeric(9, 2)), NULL, NULL, CAST(316000.00 AS Numeric(9, 2)), NULL, 28, 28)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A39300000000 AS DateTime), CAST(299000.00 AS Numeric(9, 2)), NULL, NULL, CAST(598000.00 AS Numeric(9, 2)), NULL, 29, 29)
INSERT [dbo].[Trans] ([DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID], [TransactionID]) VALUES (CAST(0x0000A01600000000 AS DateTime), CAST(410000.00 AS Numeric(9, 2)), NULL, NULL, CAST(820000.00 AS Numeric(9, 2)), NULL, 30, 30)
SET IDENTITY_INSERT [dbo].[Trans] OFF
/****** Object:  Trigger [SetAskingPrice]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[SetAskingPrice] ON [dbo].[Trans]
FOR INSERT
AS
DECLARE
	@WorkID as int,
	@TransID as int,
	@aqPrice as money,
	@sumNetPrice as money,
	@countPriorRows as int,
	@newPrice as money		
SELECT	@WorkID = WorkID, @aqPrice = AcquisitionPrice,
	@TransID = TransactionID
FROM	inserted
SELECT * FROM	TRANS T
WHERE		T.WorkID = @WorkID
Set @countPriorRows = @@rowCount - 1
Set @newPrice = 2 * @aqPrice
If @countPriorRows > 0
BEGIN
SELECT		@sumNetPrice = SUM(NetPrice)
FROM		ArtistWorkNet AW
WHERE		AW.WorkID = @WorkID
GROUP BY	AW.WorkID
If @newPrice < (@sumNetPrice / @countPriorRows) + @aqPrice
	Set @newPrice = (@sumNetPrice / @countPriorRows) + @aqPrice
END
UPDATE	TRANS
SET	AskingPrice = @newPrice
WHERE	TransactionID = @TransID
GO
/****** Object:  Trigger [RemoveDupTrans]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[RemoveDupTrans] ON [dbo].[Trans]
FOR INSERT
AS
DECLARE	@WorkID as int,
		@TransID as Int
SELECT	@WorkID = WorkID, @TransID = TransactionID
FROM	inserted
DELETE	FROM TRANS
WHERE	WorkID = @WorkID
		AND CustomerID is null
		AND TransactionID <> @TransID
GO
/****** Object:  View [dbo].[WorkNet]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[WorkNet](Name,Title,Copy,TotalNet)
AS
SELECT ArtistWorkNet.Name,ArtistWorkNet.Title,ArtistWorkNet.Copy,sum(NetPrice)
	FROM ArtistWorkNet
		GROUP BY Name, Title, Copy
GO
/****** Object:  View [dbo].[CustomerPhone]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CustomerPhone]
AS
SELECT     Name, '(' + AreaCode + ')' + PhoneNumber AS Phone
FROM         dbo.Customer
GO
/****** Object:  View [dbo].[BasicCustomerData]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BasicCustomerData]
AS
SELECT     Name, AreaCode, PhoneNumber
FROM         dbo.Customer
GO
/****** Object:  Table [dbo].[Customer_Artist_Int]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Artist_Int](
	[CustomerID] [int] NOT NULL,
	[ArtistID] [int] NOT NULL,
 CONSTRAINT [XPKCustomer_Artist_Int] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC,
	[ArtistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (1, 4)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (1, 8)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (2, 2)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (2, 11)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (3, 6)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (3, 7)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (4, 9)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (5, 3)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (6, 9)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (7, 1)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (8, 3)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (8, 7)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (8, 10)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (9, 4)
INSERT [dbo].[Customer_Artist_Int] ([CustomerID], [ArtistID]) VALUES (10, 7)
/****** Object:  View [dbo].[WorksInGallery]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[WorksInGallery]
AS
SELECT     dbo.Trans.AskingPrice, dbo.[Work].Title, dbo.Artist.Name, dbo.[Work].WorkID, dbo.[Work].Copy, dbo.[Work].Description
FROM         dbo.Trans INNER JOIN
                      dbo.[Work] ON dbo.Trans.WorkID = dbo.[Work].WorkID INNER JOIN
                      dbo.Artist ON dbo.[Work].ArtistID = dbo.Artist.ArtistID
WHERE     (dbo.Trans.CustomerID IS NULL)
GO
/****** Object:  StoredProcedure [dbo].[Add_WORK]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_WORK]
	(
	@ArtistID int,
	@Title Varchar(25),
	@Copy Varchar(8),
	@Description varchar(100),
	@AcquisitionPrice Numeric(6,2)
	)
AS
	DECLARE @rowcount as int
	DECLARE @WorkID as int
	SELECT @rowcount = Count(*)
	FROM ARTIST A
	WHERE A.ArtistID = @ArtistID
IF @rowcount = 0
	BEGIN
		Print 'Нет художника с ID = ' + Str(@ArtistID)
		Print 'Обработка прервана.'
		return
	END
	SELECT @rowcount = Count(*)
	FROM WORK W
	WHERE	W.ArtistID = @ArtistID and
			W.Title = @Title and
			W.Copy = @Copy
	IF @rowcount = 0
		INSERT INTO WORK (Title, Copy, Description, ArtistID)
		VALUES (@Title, @Copy, @Description, @ArtistID)
	SELECT @WorkID = W.WorkID
	FROM WORK W
	WHERE	W.ArtistID = @ArtistID and
			W.Title = @Title and
			W.Copy = @Copy
	INSERT INTO TRANS (DateAcquired, AcquisitionPrice, WorkID)
	VALUES (GetDate(), @AcquisitionPrice, @WorkID)
RETURN
GO
/****** Object:  View [dbo].[CustomerInterests]    Script Date: 05/24/2015 13:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CustomerInterests]
AS
SELECT     dbo.Artist.Name AS Artist, dbo.Customer.Name AS Customer
FROM         dbo.Customer_Artist_Int INNER JOIN
                      dbo.Customer ON dbo.Customer_Artist_Int.CustomerID = dbo.Customer.CustomerID INNER JOIN
                      dbo.Artist ON dbo.Customer_Artist_Int.ArtistID = dbo.Artist.ArtistID
GO
/****** Object:  Check [CheckingBirthYear]    Script Date: 05/24/2015 13:09:40 ******/
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [CheckingBirthYear] CHECK  (([BirthYear]<[DeceaseYear]))
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [CheckingBirthYear]
GO
/****** Object:  Check [CheckingDatePurchase]    Script Date: 05/24/2015 13:09:41 ******/
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [CheckingDatePurchase] CHECK  (([DateAcquired]<[PurchaseDate]))
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [CheckingDatePurchase]
GO
/****** Object:  Check [CheckingSalesPrice]    Script Date: 05/24/2015 13:09:41 ******/
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [CheckingSalesPrice] CHECK  (([SalesPrice]>=(30000) AND [SalesPrice]<=(1500000)))
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [CheckingSalesPrice]
GO
/****** Object:  ForeignKey [Создает]    Script Date: 05/24/2015 13:09:40 ******/
ALTER TABLE [dbo].[Work]  WITH CHECK ADD  CONSTRAINT [Создает] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Work] CHECK CONSTRAINT [Создает]
GO
/****** Object:  ForeignKey [R]    Script Date: 05/24/2015 13:09:40 ******/
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [R] FOREIGN KEY([NatID])
REFERENCES [dbo].[Nation] ([NatID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [R]
GO
/****** Object:  ForeignKey [R_6]    Script Date: 05/24/2015 13:09:41 ******/
ALTER TABLE [dbo].[Customer_Artist_Int]  WITH CHECK ADD  CONSTRAINT [R_6] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer_Artist_Int] CHECK CONSTRAINT [R_6]
GO
/****** Object:  ForeignKey [Интересуется]    Script Date: 05/24/2015 13:09:41 ******/
ALTER TABLE [dbo].[Customer_Artist_Int]  WITH CHECK ADD  CONSTRAINT [Интересуется] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer_Artist_Int] CHECK CONSTRAINT [Интересуется]
GO
/****** Object:  ForeignKey [Приобретает]    Script Date: 05/24/2015 13:09:41 ******/
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [Приобретает] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [Приобретает]
GO
/****** Object:  ForeignKey [Приобретается]    Script Date: 05/24/2015 13:09:41 ******/
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [Приобретается] FOREIGN KEY([WorkID])
REFERENCES [dbo].[Work] ([WorkID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [Приобретается]
GO
