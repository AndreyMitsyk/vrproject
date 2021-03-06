USE [vra_db]
GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 08/01/2013 20:56:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[AreaCode] [varchar](4) NULL,
	[PhoneNumber] [varchar](8) NULL,
	[Street] [varchar](30) NULL,
	[City] [varchar](35) NULL,
	[Region] [varchar](30) NULL,
	[ZipPostalCode] [varchar](6) NULL,
	[Country] [varchar](50) NULL,
	[HouseNumber] [varchar](5) NULL,
 CONSTRAINT [XPKCUSTOMER] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1CUSTOMER] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CUSTOMER] ON
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (2, N'Аликс Венс               ', N'vance@black-mesa.bm                               ', N'095 ', N'37-74-38', NULL, N'Мадрид                             ', NULL, N'653287', N'Испания                                           ', N'39/9 ')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (3, N'Гордон Фримен            ', N'freeman@city-17.su                                ', N'495 ', N'4493-443', NULL, N'Москва                             ', N'Московская область            ', N'47-377', N'Россия                                            ', N'12   ')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (4, N'Барни Колхаун            ', N'calhoun@hl2.ru                                    ', N'495 ', N'334-443 ', NULL, N'Москва                             ', N'Московская область            ', N'1-4917', N'Россия                                            ', N'74-3 ')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (5, N'Адриан Шепард            ', N'spephard@usam.com                                 ', N'770 ', N'1-34-344', NULL, N'Симферопль                         ', NULL, N'265-32', N'Украина                                           ', N'52   ')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (6, N'Доктор Розенберг         ', N'rosen@bm.hl2                                      ', N'773 ', N'443-44-3', NULL, N'Нюрнберг                           ', NULL, N'74-174', N'Германия                                          ', N'44   ')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (7, N'Исаак Кляйнер 2          ', N'kl@fmfm.ru                                        ', N'559 ', N'994-334 ', NULL, N'Берлин                             ', NULL, N'374-31', N'Германия                                          ', N'98   ')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (8, N'Илай Венс 2              ', N'vance_eli@black-mesa.com                          ', N'309 ', N'175039  ', N'ffg                           ', N'Нью-Йорк                           ', N'                              ', N'220493', N'США                                               ', N'69   ')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (9, N'Эрне Магнуссон           ', N'magnum@black-mesa.com                             ', N'309 ', N'49-39-20', NULL, N'Нью-Йорк                           ', NULL, N'491974', N'США                                               ', N'54/23')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (10, N'Джудит Моссман           ', N'mossman@mail-bm.ru                                ', N'303 ', N'49-30-49', NULL, N'Лос-Анжелес                        ', NULL, N'1-4973', N'США                                               ', NULL)
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (11, N'Одесса Габидж            ', N'Cubbage_O@hl2.ru                                  ', N'772 ', N'17-49-39', NULL, N'Париж                              ', NULL, N'1-84-1', N'Франция                                           ', NULL)
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (12, N'Уоллес Брин              ', N'Breen@aliance.hl2                                 ', N'49  ', N'17-49-33', NULL, N'Стокгольм                          ', NULL, N'1747-1', N'Швеция                                            ', NULL)
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (13, N'Сэм Фишер                ', N'FisherSam@te.com                                  ', N'49  ', N'17-49-33', NULL, N'Стокгольм                          ', NULL, N'3-4-7-', N'Швеция                                            ', NULL)
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (14, N'Томми Версетти           ', N'Versetti@vice.city                                ', N'932 ', N'17-6434 ', NULL, N'Иваново                            ', N'Ивановская область            ', N'47737-', N'Россия                                            ', N'72   ')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (15, N'Дюк Нюкем                ', N'DukeNuker@game.ru                                 ', N'932 ', N'17-64-29', NULL, N'Иваново                            ', N'Ивановская область            ', N'1294-3', N'Россия                                            ', N'29   ')
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (16, N'Джон О''Нейл              ', N'ONailJ@chicago.org                                ', N'399 ', N'114-443 ', NULL, N'Рим                                ', NULL, N'3717-5', N'Итальлия                                          ', NULL)
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (17, N'Адам Дженсен             ', N'Jansen@deus-ex-hr.com                             ', N'33  ', N'1943-443', NULL, N'Брюссель                           ', NULL, N'499743', N'Бельгия                                           ', NULL)
INSERT [dbo].[CUSTOMER] ([CustomerID], [Name], [Email], [AreaCode], [PhoneNumber], [Street], [City], [Region], [ZipPostalCode], [Country], [HouseNumber]) VALUES (18, N'Эдвард Эдвардс           ', N'edward@mail.ru                                    ', N'493 ', N'295011  ', N'Лежневская                    ', N'Иваново                            ', N'Ивановская область            ', N'153456', N'Россия                                            ', N'152  ')
SET IDENTITY_INSERT [dbo].[CUSTOMER] OFF
/****** Object:  View [dbo].[CustomerPhone]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CustomerPhone](Name,Phone)
AS
SELECT CUSTOMER.Name,'(' + AreaCode + ') ' + PhoneNumber
	FROM CUSTOMER
GO
/****** Object:  View [dbo].[BasicCustomerData]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- VIEWS -- 

CREATE VIEW [dbo].[BasicCustomerData](Name,AreaCode,PhoneNumber)
AS
SELECT CUSTOMER.Name, CUSTOMER.AreaCode, CUSTOMER.PhoneNumber
	FROM CUSTOMER
GO
/****** Object:  Table [dbo].[TRANS]    Script Date: 08/01/2013 20:56:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRANS](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[DateAcquired] [datetime] NULL,
	[AcquisitionPrice] [numeric](8, 2) NULL,
	[PurchaseDate] [datetime] NULL,
	[SalesPrice] [numeric](8, 2) NULL,
	[AskingPrice] [numeric](8, 2) NULL,
	[CustomerID] [int] NULL,
	[WorkID] [int] NOT NULL,
 CONSTRAINT [XPKTRANS] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1TRANS] UNIQUE NONCLUSTERED 
(
	[DateAcquired] ASC,
	[WorkID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TRANS] ON
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (1, CAST(0x0000A00500000000 AS DateTime), CAST(70000.00 AS Numeric(8, 2)), NULL, NULL, CAST(90000.00 AS Numeric(8, 2)), NULL, 1)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (2, CAST(0x0000A00D00000000 AS DateTime), CAST(200000.00 AS Numeric(8, 2)), NULL, NULL, CAST(300000.00 AS Numeric(8, 2)), NULL, 2)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (3, CAST(0x0000A01700000000 AS DateTime), CAST(199000.00 AS Numeric(8, 2)), NULL, NULL, CAST(300000.00 AS Numeric(8, 2)), NULL, 3)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (4, CAST(0x0000A017015AC638 AS DateTime), CAST(200000.00 AS Numeric(8, 2)), NULL, NULL, CAST(300000.00 AS Numeric(8, 2)), NULL, 4)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (5, CAST(0x0000A00700000000 AS DateTime), CAST(70000.00 AS Numeric(8, 2)), NULL, NULL, CAST(80000.00 AS Numeric(8, 2)), NULL, 5)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (6, CAST(0x0000A00600000000 AS DateTime), CAST(200000.00 AS Numeric(8, 2)), CAST(0x0000A01600000000 AS DateTime), CAST(209000.00 AS Numeric(8, 2)), CAST(210000.00 AS Numeric(8, 2)), 8, 6)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (7, CAST(0x0000A01700000000 AS DateTime), CAST(71000.00 AS Numeric(8, 2)), NULL, NULL, CAST(72000.00 AS Numeric(8, 2)), NULL, 7)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (8, CAST(0x0000A00600000000 AS DateTime), CAST(220000.00 AS Numeric(8, 2)), NULL, NULL, CAST(230000.00 AS Numeric(8, 2)), NULL, 8)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (9, CAST(0x0000A00400000000 AS DateTime), CAST(166000.00 AS Numeric(8, 2)), CAST(0x0000A01300000000 AS DateTime), CAST(160000.00 AS Numeric(8, 2)), CAST(162000.00 AS Numeric(8, 2)), 14, 9)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (10, CAST(0x0000A00800000000 AS DateTime), CAST(100000.00 AS Numeric(8, 2)), NULL, NULL, CAST(150000.00 AS Numeric(8, 2)), NULL, 10)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (11, CAST(0x0000A01700000000 AS DateTime), CAST(73000.00 AS Numeric(8, 2)), NULL, NULL, CAST(74000.00 AS Numeric(8, 2)), NULL, 11)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (12, CAST(0x0000A00E00000000 AS DateTime), CAST(700000.00 AS Numeric(8, 2)), CAST(0x0000A01300000000 AS DateTime), CAST(79000.00 AS Numeric(8, 2)), CAST(80000.00 AS Numeric(8, 2)), 6, 12)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (13, CAST(0x0000A01700000000 AS DateTime), CAST(40000.00 AS Numeric(8, 2)), NULL, NULL, CAST(50000.00 AS Numeric(8, 2)), NULL, 13)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (14, CAST(0x0000A00700000000 AS DateTime), CAST(70000.00 AS Numeric(8, 2)), NULL, NULL, CAST(71000.00 AS Numeric(8, 2)), NULL, 14)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (15, CAST(0x0000A00F00000000 AS DateTime), CAST(80000.00 AS Numeric(8, 2)), CAST(0x0000A01600000000 AS DateTime), CAST(82000.00 AS Numeric(8, 2)), CAST(81000.00 AS Numeric(8, 2)), 6, 15)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (16, CAST(0x0000A00C00000000 AS DateTime), CAST(443100.00 AS Numeric(8, 2)), NULL, NULL, CAST(450500.00 AS Numeric(8, 2)), NULL, 16)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (17, CAST(0x0000A00900000000 AS DateTime), CAST(201000.00 AS Numeric(8, 2)), NULL, NULL, CAST(210000.00 AS Numeric(8, 2)), NULL, 17)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (18, CAST(0x0000A00C00000000 AS DateTime), CAST(77000.00 AS Numeric(8, 2)), NULL, NULL, CAST(78000.00 AS Numeric(8, 2)), NULL, 18)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (19, CAST(0x0000A00600000000 AS DateTime), CAST(700000.00 AS Numeric(8, 2)), CAST(0x0000A01600000000 AS DateTime), CAST(80000.00 AS Numeric(8, 2)), CAST(900000.00 AS Numeric(8, 2)), 9, 19)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (20, CAST(0x0000A05300C39B48 AS DateTime), NULL, NULL, NULL, NULL, NULL, 21)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (21, CAST(0x0000A02C00000000 AS DateTime), CAST(90000.00 AS Numeric(8, 2)), NULL, NULL, NULL, NULL, 23)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (22, CAST(0x0000A15900000000 AS DateTime), CAST(100000.00 AS Numeric(8, 2)), NULL, NULL, NULL, NULL, 24)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (23, CAST(0x0000A15900000000 AS DateTime), CAST(100000.00 AS Numeric(8, 2)), NULL, NULL, NULL, NULL, 25)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (24, CAST(0x0000A15900000000 AS DateTime), CAST(34000.00 AS Numeric(8, 2)), CAST(0x0000A15A00000000 AS DateTime), CAST(350000.00 AS Numeric(8, 2)), NULL, 18, 26)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (25, CAST(0x0000A15900000000 AS DateTime), CAST(500000.00 AS Numeric(8, 2)), NULL, CAST(500000.00 AS Numeric(8, 2)), NULL, 2, 27)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (26, CAST(0x0000A15900000000 AS DateTime), CAST(12000.00 AS Numeric(8, 2)), NULL, NULL, NULL, NULL, 28)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (27, CAST(0x0000A15A00000000 AS DateTime), CAST(100000.00 AS Numeric(8, 2)), NULL, NULL, CAST(200000.00 AS Numeric(8, 2)), NULL, 3)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (28, CAST(0x0000A15A00000000 AS DateTime), CAST(234567.00 AS Numeric(8, 2)), NULL, NULL, NULL, NULL, 29)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (29, CAST(0x0000A15A00000000 AS DateTime), CAST(30000.00 AS Numeric(8, 2)), NULL, NULL, NULL, NULL, 30)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (30, CAST(0x0000A15A00000000 AS DateTime), CAST(50000.00 AS Numeric(8, 2)), NULL, NULL, NULL, NULL, 31)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (31, CAST(0x0000A1B100000000 AS DateTime), CAST(300000.00 AS Numeric(8, 2)), NULL, NULL, CAST(350000.00 AS Numeric(8, 2)), NULL, 32)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (32, CAST(0x0000A1F700000000 AS DateTime), NULL, NULL, NULL, NULL, NULL, 33)
INSERT [dbo].[TRANS] ([TransactionID], [DateAcquired], [AcquisitionPrice], [PurchaseDate], [SalesPrice], [AskingPrice], [CustomerID], [WorkID]) VALUES (33, CAST(0x0000A20001277FA2 AS DateTime), NULL, NULL, NULL, NULL, NULL, 34)
SET IDENTITY_INSERT [dbo].[TRANS] OFF
/****** Object:  Table [dbo].[WORK]    Script Date: 08/01/2013 20:56:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WORK](
	[WorkID] [int] IDENTITY(1,1) NOT NULL,
	[ArtistID] [int] NOT NULL,
	[Title] [varchar](25) NOT NULL,
	[Copy] [varchar](8) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [XPKWORK] PRIMARY KEY CLUSTERED 
(
	[WorkID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1WORK] UNIQUE NONCLUSTERED 
(
	[Title] ASC,
	[Copy] ASC,
	[ArtistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[WORK] ON
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (1, 3, N'Vi Vida', N'77', N'темная')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (2, 1, N'The Tilled Field', N'99/d', N'Хорошее качество')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (3, 1, N'La Lecon de Ski', N'2/7', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (4, 1, N'La Lecon de Ski', N'4/7', N'Старая')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (5, 9, N'Venus and Mars', N'47/49', N'Светлая')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (6, 9, N'The Birth of Venus', N'27/170', N'Не проверена')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (7, 9, N'Primavera', N'7/50', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (8, 10, N'Coronation of the Virgin', N'5/9', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (9, 10, N'Wedding of the Virgin', N'1/10', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (10, 10, N'Mond Crucifixion', N'20/21', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (11, 10, N'Saint George and…', N'2/3', N'… the Dragon')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (12, 11, N'The Last Judgment', N'20/30', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (13, 12, N'Portrait of a Man and', N'2/40', N'... Woman')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (14, 12, N'Madonna and Child', N'2/41', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (15, 12, N'Barbadori Altarpiece', N'12/27', N'Очень старая')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (16, 12, N'Annunciation I', N'1/2', N'Незначительные повреждения')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (17, 12, N'The Saints Funeral', N'2/200', N'Несколько царапин')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (18, 12, N'Nativity', N'25/30', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (19, 12, N'Coronation 2', N'12/34', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (21, 9, N'fgfg', N'оригинал', NULL)
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (23, 8, N'Подсолнухи', N'оригинал', N'оригинал')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (24, 17, N'Запорожцы', N'З-01-02 ', N'1880-1891')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (25, 17, N'Бурлаки на Волге', N'Оригинал', N'ыыыы')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (26, 17, N'Морозова', N'', N'')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (27, 1, N'Сударь', N'', N'')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (28, 2, N'Багира', N'', N'')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (29, 4, N'Сюрприз', N'', N'')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (30, 8, N'Мишки на севере', N'12/23', N'')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (31, 8, N'Манэ', N'', N'')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (32, 18, N'Сосновый бор', N'оригинал', N'художник-передвижник')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (33, 9, N'ыва', N'', N'')
INSERT [dbo].[WORK] ([WorkID], [ArtistID], [Title], [Copy], [Description]) VALUES (34, 8, N'AAAA', N'', N'')
SET IDENTITY_INSERT [dbo].[WORK] OFF
/****** Object:  Table [dbo].[Nation]    Script Date: 08/01/2013 20:56:24 ******/
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
INSERT [dbo].[Nation] ([NatID], [Value]) VALUES (1, N'Испанец')
INSERT [dbo].[Nation] ([NatID], [Value]) VALUES (2, N'Итальянец')
INSERT [dbo].[Nation] ([NatID], [Value]) VALUES (3, N'Русский')
INSERT [dbo].[Nation] ([NatID], [Value]) VALUES (4, N'Француз')
SET IDENTITY_INSERT [dbo].[Nation] OFF
/****** Object:  Table [dbo].[ARTIST]    Script Date: 08/01/2013 20:56:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ARTIST](
	[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[BirthYear] [numeric](4, 0) NULL,
	[DeceaseYear] [numeric](4, 0) NULL,
	[NatID] [int] NULL,
 CONSTRAINT [XPKARTIST] PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1ARTIST] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ARTIST] ON
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (1, N'Miro                     ', CAST(1893 AS Numeric(4, 0)), CAST(1983 AS Numeric(4, 0)), 1)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (2, N'Kandinsky                ', CAST(1866 AS Numeric(4, 0)), CAST(1944 AS Numeric(4, 0)), 3)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (3, N'Frings                   ', CAST(1929 AS Numeric(4, 0)), CAST(2011 AS Numeric(4, 0)), 1)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (4, N'Klee                     ', CAST(1879 AS Numeric(4, 0)), CAST(1940 AS Numeric(4, 0)), 1)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (5, N'Moos                     ', CAST(1120 AS Numeric(4, 0)), NULL, 1)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (6, N'Tobey                    ', CAST(1890 AS Numeric(4, 0)), CAST(1976 AS Numeric(4, 0)), 1)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (7, N'Matisse                  ', CAST(1869 AS Numeric(4, 0)), CAST(1954 AS Numeric(4, 0)), 1)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (8, N'Chagall                  ', CAST(1887 AS Numeric(4, 0)), CAST(1985 AS Numeric(4, 0)), 1)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (9, N'Alessandro Botticelli    ', CAST(1445 AS Numeric(4, 0)), CAST(1510 AS Numeric(4, 0)), 2)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (10, N'Raffaello Santi          ', CAST(1483 AS Numeric(4, 0)), CAST(1520 AS Numeric(4, 0)), 2)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (11, N'Michelangelo             ', CAST(1475 AS Numeric(4, 0)), CAST(1564 AS Numeric(4, 0)), 2)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (12, N'Filippo Lippi            ', CAST(1406 AS Numeric(4, 0)), CAST(1469 AS Numeric(4, 0)), 2)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (13, N'Filippino Lippi          ', CAST(1457 AS Numeric(4, 0)), CAST(1504 AS Numeric(4, 0)), 2)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (14, N'Mariotto Albertinell     ', CAST(1474 AS Numeric(4, 0)), CAST(1515 AS Numeric(4, 0)), 2)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (15, N'Piero della Francesca    ', CAST(1420 AS Numeric(4, 0)), CAST(1492 AS Numeric(4, 0)), 2)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (16, N'Luca Signorelli          ', CAST(1450 AS Numeric(4, 0)), CAST(1523 AS Numeric(4, 0)), 2)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (17, N'Илья Репин               ', CAST(1845 AS Numeric(4, 0)), CAST(1935 AS Numeric(4, 0)), 3)
INSERT [dbo].[ARTIST] ([ArtistID], [Name], [BirthYear], [DeceaseYear], [NatID]) VALUES (18, N'Шишкин                   ', CAST(1813 AS Numeric(4, 0)), CAST(1890 AS Numeric(4, 0)), 3)
SET IDENTITY_INSERT [dbo].[ARTIST] OFF
/****** Object:  View [dbo].[ArtistWorkNet]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ArtistWorkNet](WorkID,Name,Title,Copy,AcquisitionPrice,SalesPrice,NetPrice)
AS
SELECT WORK.WorkID, ARTIST.Name, WORK.Title, WORK.Copy, TRANS.AcquisitionPrice, TRANS.SalesPrice, SalesPrice - AcquisitionPrice
	FROM WORK,ARTIST,TRANS
		WHERE TRANS.WorkID = WORK.WorkID
AND
WORK.ArtistID = ARTIST.ArtistID
GO
/****** Object:  View [dbo].[ArtistNet]    Script Date: 08/01/2013 20:56:27 ******/
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
/****** Object:  Table [dbo].[CUSTOMER_ARTIST_INT]    Script Date: 08/01/2013 20:56:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER_ARTIST_INT](
	[CustomerID] [int] NOT NULL,
	[ArtistID] [int] NOT NULL,
 CONSTRAINT [XPKCUSTOMER_ARTIST_INT] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC,
	[ArtistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (2, 5)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (3, 12)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (3, 13)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (4, 6)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (5, 1)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (5, 2)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (5, 12)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (6, 6)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (6, 8)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (7, 5)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (7, 7)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (8, 12)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (8, 15)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (8, 16)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (9, 5)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (9, 9)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (10, 9)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (10, 10)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (11, 3)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (11, 8)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (12, 12)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (12, 13)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (12, 14)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (13, 3)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (13, 4)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (14, 6)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (14, 7)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (15, 10)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (15, 11)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (16, 12)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (16, 13)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (17, 10)
INSERT [dbo].[CUSTOMER_ARTIST_INT] ([CustomerID], [ArtistID]) VALUES (17, 12)
/****** Object:  View [dbo].[CustomerInterests]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CustomerInterests](Artist,Customer)
AS
SELECT ARTIST.Name,CUSTOMER.Name
	FROM ARTIST,CUSTOMER,CUSTOMER_ARTIST_INT
		WHERE CUSTOMER.CustomerID = CUSTOMER_ARTIST_INT.CustomerID
AND
CUSTOMER_ARTIST_INT.ArtistID = ARTIST.ArtistID
GO
/****** Object:  View [dbo].[CustomerInterestrs]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- VIEWS FOR PROGRAM --

CREATE VIEW [dbo].[CustomerInterestrs] AS
	SELECT C.Name as Customer, A.Name as Artist
	FROM CUSTOMER C
		JOIN CUSTOMER_ARTIST_INT CI
		ON C.CustomerID = CI.CustomerID
		JOIN ARTIST A
		ON CI.ArtistID = A.ArtistID;
GO
/****** Object:  View [dbo].[WorkNet]    Script Date: 08/01/2013 20:56:27 ******/
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
/****** Object:  View [dbo].[WORK_VIEW]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[WORK_VIEW] AS
	select WORK.WorkID, ARTIST.Name, WORK.Title, WORK.Copy, WORK.Description
	from WORK
		 inner join ARTIST
		 on WORK.ArtistID = ARTIST.ArtistID
GO
/****** Object:  View [dbo].[WorksInGallery]    Script Date: 03.05.2015 15:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[WorksInGallery]
AS
SELECT        dbo.TRANS.AskingPrice, dbo.[WORK].Title, dbo.ARTIST.Name, dbo.[WORK].WorkID, dbo.[WORK].Copy, dbo.[WORK].Description
FROM            dbo.TRANS INNER JOIN
                         dbo.[WORK] ON dbo.TRANS.WorkID = dbo.[WORK].WorkID INNER JOIN
                         dbo.ARTIST ON dbo.[WORK].ArtistID = dbo.ARTIST.ArtistID
WHERE        (dbo.TRANS.CustomerID IS NULL)
GO
/****** Object:  View [dbo].[TRANS_VIEW]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TRANS_VIEW] AS
SELECT TRANS.TransactionID, TRANS.WorkID, WORK.Title AS WorkTitle, WORK.Copy AS WorkCopy,
	   TRANS.CustomerID, Customer.Name AS CustomerName, CUSTOMER.PhoneNumber AS CustomerPhoneNumber,
	   TRANS.DateAcquired, TRANS.AcquisitionPrice, TRANS.PurchaseDate, TRANS.SalesPrice, TRANS.AskingPrice
FROM   TRANS
		left join WORK on TRANS.WorkID = WORK.WorkID
		left join CUSTOMER on TRANS.CustomerID = CUSTOMER.CustomerID
GO
/****** Object:  View [dbo].[trans_dates]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[trans_dates] as Select distinct DateAcquired from 	TRANS union Select distinct PurchaseDate from TRANS
GO
/****** Object:  StoredProcedure [dbo].[Add_WORK]    Script Date: 08/01/2013 20:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_WORK]
	(
	@ArtistID int, /*Художник должен уже присутствовать
					в базе данных */
	@Title char(25),
	@Copy char(8),
	@Description varchar(1000),
	@AcquisitionPrice Numeric(6,2)
	)
	
/* Хранимая процедура, регистрирующая приобретение галереей
произведения. Если произведение никогда раньше не появлялось
в галерее, в таблицу WORK добавляется новая строка.
В противном случае используется существующая строка. Далее
добавляется строка в таблицу TRANSACTION, а столбец
DateAcquired в ней устанавливается раынвм системной дате */

AS

	DECLARE @rowcount as int
	DECLARE @WorkID as int
	
/* Сначала следует убедиться, что ArtistID имеет допустимое
значение */
	SELECT @rowcount = Count(*) 
	FROM ARTIST A
	WHERE A.ArtistID = @ArtistID
	
IF @rowcount = 0
/* Нет такого художника */
	BEGIN
		Print 'Нет художника с ID = ' + Str(@ArtistID)
		Print 'Обработка прервана.'
		return
	END
		
/* Теперь смотрим, есть ли это произведение в базе данных */
	SELECT @rowcount = Count(*)
	FROM WORK W
	WHERE W.ArtistID = @ArtistID and
		W.Title = @Title and
		W.Copy = @Copy
			
	IF @rowcount = 0
		/* Произведения нет в базе, записываем его */
		INSERT INTO WORK (Title, Copy, Description, ArtistID)
		VALUES (@Title, @Copy, @Description, @ArtistID)
		
/* Получаем значение суррогатного ключа WorkID */
	SELECT @WorkID = W.WorkID
	FROM WORK W
	WHERE W.ArtistID = @ArtistID and
		W.Title = @Title and
		W.Copy = @Copy
			
/* Вставляем новую строку в таблицу TRANSACTION */
	INSERT INTO TRANS (DateAcquired, AcquisitionPrice, WorkID)
	VALUES (GetDate(), @AcquisitionPrice, @WorkID)
		
RETURN
GO
/****** Object:  View [dbo].[acquired_dynamics]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[acquired_dynamics] as Select trans.DateAcquired as 	acqDate, COUNT(Trans.DateAcquired) as acqCount from TRANS group 	by trans.DateAcquired
GO
/****** Object:  View [dbo].[purchase_dynamics]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[purchase_dynamics] as Select trans.PurchaseDate as 	purDate, COUNT(Trans.PurchaseDate) as purCount from TRANS group 	by trans.PurchaseDate
GO
/****** Object:  View [dbo].[purAcqDyn]    Script Date: 08/01/2013 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[purAcqDyn] as select * from trans_dates left join 	purchase_dynamics on trans_dates.DateAcquired = 	purchase_dynamics.purDate left join acquired_dynamics on 	trans_dates.DateAcquired = acquired_dynamics.acqDate
GO
/****** Object:  Check [BirthYearValidate]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[ARTIST]  WITH CHECK ADD  CONSTRAINT [BirthYearValidate] CHECK  (([BirthYear]<[DeceaseYear]))
GO
ALTER TABLE [dbo].[ARTIST] CHECK CONSTRAINT [BirthYearValidate]
GO
/****** Object:  Check [ValidBirthYear]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[ARTIST]  WITH CHECK ADD  CONSTRAINT [ValidBirthYear] CHECK  (([BirthYear] like '[1-2][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[ARTIST] CHECK CONSTRAINT [ValidBirthYear]
GO
/****** Object:  Check [ValidDeathYear]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[ARTIST]  WITH CHECK ADD  CONSTRAINT [ValidDeathYear] CHECK  (([DeceaseYear] like '[1-2][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[ARTIST] CHECK CONSTRAINT [ValidDeathYear]
GO
/****** Object:  Check [SalesPriceRange]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[TRANS]  WITH CHECK ADD  CONSTRAINT [SalesPriceRange] CHECK  (([SalesPrice]>=(30000) AND [SalesPrice]<=(1500000)))
GO
ALTER TABLE [dbo].[TRANS] CHECK CONSTRAINT [SalesPriceRange]
GO
/****** Object:  Check [ValidTransDate]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[TRANS]  WITH CHECK ADD  CONSTRAINT [ValidTransDate] CHECK  (([DateAcquired]<=[PurchaseDate]))
GO
ALTER TABLE [dbo].[TRANS] CHECK CONSTRAINT [ValidTransDate]
GO
/****** Object:  ForeignKey [R]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[ARTIST]  WITH CHECK ADD  CONSTRAINT [R] FOREIGN KEY([NatID])
REFERENCES [dbo].[Nation] ([NatID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ARTIST] CHECK CONSTRAINT [R]
GO
/****** Object:  ForeignKey [R_6]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[CUSTOMER_ARTIST_INT]  WITH CHECK ADD  CONSTRAINT [R_6] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CUSTOMER] ([CustomerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CUSTOMER_ARTIST_INT] CHECK CONSTRAINT [R_6]
GO
/****** Object:  ForeignKey [using]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[CUSTOMER_ARTIST_INT]  WITH CHECK ADD  CONSTRAINT [using] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[ARTIST] ([ArtistID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CUSTOMER_ARTIST_INT] CHECK CONSTRAINT [using]
GO
/****** Object:  ForeignKey [R_1]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[TRANS]  WITH CHECK ADD  CONSTRAINT [R_1] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CUSTOMER] ([CustomerID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TRANS] CHECK CONSTRAINT [R_1]
GO
/****** Object:  ForeignKey [R_2]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[TRANS]  WITH CHECK ADD  CONSTRAINT [R_2] FOREIGN KEY([WorkID])
REFERENCES [dbo].[WORK] ([WorkID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TRANS] CHECK CONSTRAINT [R_2]
GO
/****** Object:  ForeignKey [R_3]    Script Date: 08/01/2013 20:56:24 ******/
ALTER TABLE [dbo].[WORK]  WITH CHECK ADD  CONSTRAINT [R_3] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[ARTIST] ([ArtistID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[WORK] CHECK CONSTRAINT [R_3]
GO
