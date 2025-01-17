USE [ShaTask]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 2/24/2022 6:06:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](200) NOT NULL,
	[CityID] [int] NOT NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cashier]    Script Date: 2/24/2022 6:06:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cashier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CashierName] [nvarchar](200) NOT NULL,
	[BranchID] [int] NOT NULL,
 CONSTRAINT [PK_Cashier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2/24/2022 6:06:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 2/24/2022 6:06:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceHeaderID] [bigint] NOT NULL,
	[ItemName] [nvarchar](200) NOT NULL,
	[ItemCount] [float] NOT NULL,
	[ItemPrice] [float] NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceHeader]    Script Date: 2/24/2022 6:06:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceHeader](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](200) NOT NULL,
	[Invoicedate] [datetime] NOT NULL,
	[CashierID] [int] NULL,
	[BranchID] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceHeader] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

GO
INSERT [dbo].[Branches] ([ID], [BranchName], [CityID]) VALUES (2, N'فرع الحي السابع', 1)
GO
INSERT [dbo].[Branches] ([ID], [BranchName], [CityID]) VALUES (3, N'فرع عباس العقاد', 1)
GO
INSERT [dbo].[Branches] ([ID], [BranchName], [CityID]) VALUES (4, N'فرع التجمع الاول', 2)
GO
INSERT [dbo].[Branches] ([ID], [BranchName], [CityID]) VALUES (5, N'فرع سموحه', 5)
GO
INSERT [dbo].[Branches] ([ID], [BranchName], [CityID]) VALUES (6, N'فرع الشروق', 3)
GO
INSERT [dbo].[Branches] ([ID], [BranchName], [CityID]) VALUES (7, N'فرع العبور', 4)
GO
SET IDENTITY_INSERT [dbo].[Branches] OFF
GO
SET IDENTITY_INSERT [dbo].[Cashier] ON 

GO
INSERT [dbo].[Cashier] ([ID], [CashierName], [BranchID]) VALUES (1, N'محمد احمد', 2)
GO
INSERT [dbo].[Cashier] ([ID], [CashierName], [BranchID]) VALUES (2, N'محمود احمد محمد', 3)
GO
INSERT [dbo].[Cashier] ([ID], [CashierName], [BranchID]) VALUES (3, N'مصطفي عبد السميع', 2)
GO
INSERT [dbo].[Cashier] ([ID], [CashierName], [BranchID]) VALUES (4, N'احمد عبد الرحمن', 6)
GO
INSERT [dbo].[Cashier] ([ID], [CashierName], [BranchID]) VALUES (5, N'ساره عبد الله', 4)
GO
SET IDENTITY_INSERT [dbo].[Cashier] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

GO
INSERT [dbo].[Cities] ([ID], [CityName]) VALUES (1, N'القاهرة - مدينة نصر')
GO
INSERT [dbo].[Cities] ([ID], [CityName]) VALUES (2, N'القاهرة - القاهرة الجديدة ')
GO
INSERT [dbo].[Cities] ([ID], [CityName]) VALUES (3, N'القاهرة - الشروق ')
GO
INSERT [dbo].[Cities] ([ID], [CityName]) VALUES (4, N'القاهرة - العبور ')
GO
INSERT [dbo].[Cities] ([ID], [CityName]) VALUES (5, N'الاسكندرية - سموحة')
GO
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetails] ON 

GO
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceHeaderID], [ItemName], [ItemCount], [ItemPrice]) VALUES (2, 2, N'بيبسي 1 لتر', 2, 20)
GO
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceHeaderID], [ItemName], [ItemCount], [ItemPrice]) VALUES (3, 2, N'ساندوتش برجر', 2, 50)
GO
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceHeaderID], [ItemName], [ItemCount], [ItemPrice]) VALUES (4, 2, N'ايس كريم', 1, 10)
GO
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceHeaderID], [ItemName], [ItemCount], [ItemPrice]) VALUES (6, 3, N'سفن اب كانز', 1, 5)
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceHeader] ON 

GO
INSERT [dbo].[InvoiceHeader] ([ID], [CustomerName], [Invoicedate], [CashierID], [BranchID]) VALUES (2, N'محمد عبد الله', CAST(N'2022-02-22T00:00:00.000' AS DateTime), 1, 2)
GO
INSERT [dbo].[InvoiceHeader] ([ID], [CustomerName], [Invoicedate], [CashierID], [BranchID]) VALUES (3, N'محمود احمد', CAST(N'2022-02-23T00:00:00.000' AS DateTime), 2, 3)
GO
SET IDENTITY_INSERT [dbo].[InvoiceHeader] OFF
GO
ALTER TABLE [dbo].[Branches] ADD  CONSTRAINT [DF_Branches_BranchName]  DEFAULT ('') FOR [BranchName]
GO
ALTER TABLE [dbo].[Cashier] ADD  CONSTRAINT [DF_Cashier_CashierName]  DEFAULT ('') FOR [CashierName]
GO
ALTER TABLE [dbo].[Cashier] ADD  CONSTRAINT [DF_Cashier_BranchID]  DEFAULT ((0)) FOR [BranchID]
GO
ALTER TABLE [dbo].[Cities] ADD  CONSTRAINT [DF_Cities_CityName]  DEFAULT ('') FOR [CityName]
GO
ALTER TABLE [dbo].[InvoiceDetails] ADD  CONSTRAINT [DF_InvoiceDetails_ItemName]  DEFAULT ('') FOR [ItemName]
GO
ALTER TABLE [dbo].[InvoiceDetails] ADD  CONSTRAINT [DF_InvoiceDetails_ItemCount]  DEFAULT ((0)) FOR [ItemCount]
GO
ALTER TABLE [dbo].[InvoiceDetails] ADD  CONSTRAINT [DF_InvoiceDetails_ItemPrice]  DEFAULT ((0)) FOR [ItemPrice]
GO
ALTER TABLE [dbo].[InvoiceHeader] ADD  CONSTRAINT [DF_InvoiceHeader_CustomerName]  DEFAULT ('') FOR [CustomerName]
GO
ALTER TABLE [dbo].[InvoiceHeader] ADD  CONSTRAINT [DF_InvoiceHeader_Invoicedate]  DEFAULT (getdate()) FOR [Invoicedate]
GO
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Cities] FOREIGN KEY([CityID])
REFERENCES [dbo].[Cities] ([ID])
GO
ALTER TABLE [dbo].[Branches] CHECK CONSTRAINT [FK_Branches_Cities]
GO
ALTER TABLE [dbo].[Cashier]  WITH CHECK ADD  CONSTRAINT [FK_Cashier_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([ID])
GO
ALTER TABLE [dbo].[Cashier] CHECK CONSTRAINT [FK_Cashier_Branches]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_InvoiceHeader] FOREIGN KEY([InvoiceHeaderID])
REFERENCES [dbo].[InvoiceHeader] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_InvoiceHeader]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([ID])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_Branches]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_Cashier] FOREIGN KEY([CashierID])
REFERENCES [dbo].[Cashier] ([ID])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_Cashier]
GO
