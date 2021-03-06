USE [vra_db]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 05/24/2015 08:22:33 ******/
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
/****** Object:  View [dbo].[CustomerPhone]    Script Date: 05/24/2015 08:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CustomerPhone]
AS
SELECT     Name, '(' + AreaCode + ')' + PhoneNumber AS Phone
FROM         dbo.Customer
GO
/****** Object:  View [dbo].[BasicCustomerData]    Script Date: 05/24/2015 08:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BasicCustomerData]
AS
SELECT     Name, AreaCode, PhoneNumber
FROM         dbo.Customer
GO
/****** Object:  Table [dbo].[Trans]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  Table [dbo].[Work]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  Table [dbo].[Nation]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  Table [dbo].[Artist]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  View [dbo].[ArtistWorkNet]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  View [dbo].[ArtistNet]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  Table [dbo].[Customer_Artist_Int]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  View [dbo].[CustomerInterests]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  View [dbo].[WorkNet]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  View [dbo].[WorksInGallery]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  StoredProcedure [dbo].[Add_WORK]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  Trigger [SetAskingPrice]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  Trigger [RemoveDupTrans]    Script Date: 05/24/2015 08:22:34 ******/
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
/****** Object:  Check [CheckingBirthYear]    Script Date: 05/24/2015 08:22:34 ******/
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [CheckingBirthYear] CHECK  (([BirthYear]<[DeceaseYear]))
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [CheckingBirthYear]
GO
/****** Object:  Check [CheckingDatePurchase]    Script Date: 05/24/2015 08:22:34 ******/
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [CheckingDatePurchase] CHECK  (([DateAcquired]<[PurchaseDate]))
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [CheckingDatePurchase]
GO
/****** Object:  Check [CheckingSalesPrice]    Script Date: 05/24/2015 08:22:34 ******/
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [CheckingSalesPrice] CHECK  (([SalesPrice]>=(30000) AND [SalesPrice]<=(1500000)))
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [CheckingSalesPrice]
GO
/****** Object:  ForeignKey [Создает]    Script Date: 05/24/2015 08:22:34 ******/
ALTER TABLE [dbo].[Work]  WITH CHECK ADD  CONSTRAINT [Создает] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Work] CHECK CONSTRAINT [Создает]
GO
/****** Object:  ForeignKey [R]    Script Date: 05/24/2015 08:22:34 ******/
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [R] FOREIGN KEY([NatID])
REFERENCES [dbo].[Nation] ([NatID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [R]
GO
/****** Object:  ForeignKey [R_6]    Script Date: 05/24/2015 08:22:34 ******/
ALTER TABLE [dbo].[Customer_Artist_Int]  WITH CHECK ADD  CONSTRAINT [R_6] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer_Artist_Int] CHECK CONSTRAINT [R_6]
GO
/****** Object:  ForeignKey [Интересуется]    Script Date: 05/24/2015 08:22:34 ******/
ALTER TABLE [dbo].[Customer_Artist_Int]  WITH CHECK ADD  CONSTRAINT [Интересуется] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer_Artist_Int] CHECK CONSTRAINT [Интересуется]
GO
/****** Object:  ForeignKey [Приобретает]    Script Date: 05/24/2015 08:22:34 ******/
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [Приобретает] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [Приобретает]
GO
/****** Object:  ForeignKey [Приобретается]    Script Date: 05/24/2015 08:22:34 ******/
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [Приобретается] FOREIGN KEY([WorkID])
REFERENCES [dbo].[Work] ([WorkID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [Приобретается]
GO