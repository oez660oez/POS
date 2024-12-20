USE [master]
GO
/****** Object:  Database [myIceShop]    Script Date: 2024/11/25 上午 03:36:26 ******/
CREATE DATABASE [myIceShop]
GO
ALTER DATABASE [myIceShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [myIceShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [myIceShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [myIceShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [myIceShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [myIceShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [myIceShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [myIceShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [myIceShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [myIceShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [myIceShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [myIceShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [myIceShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [myIceShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [myIceShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [myIceShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [myIceShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [myIceShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [myIceShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [myIceShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [myIceShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [myIceShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [myIceShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [myIceShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [myIceShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [myIceShop] SET  MULTI_USER 
GO
ALTER DATABASE [myIceShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [myIceShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [myIceShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [myIceShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [myIceShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [myIceShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'myIceShop', N'ON'
GO
ALTER DATABASE [myIceShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [myIceShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200)
GO
USE [myIceShop]
GO
/****** Object:  Table [dbo].[AddIngredient]    Script Date: 2024/11/25 上午 03:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddIngredient](
	[AddIngredientId] [int] IDENTITY(1,1) NOT NULL,
	[CustomizationId] [int] NOT NULL,
	[AddIngredientName] [nvarchar](50) NOT NULL,
	[AddIngredientPrice] [int] NOT NULL,
 CONSTRAINT [PK_AddIngredient] PRIMARY KEY CLUSTERED 
(
	[AddIngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clock]    Script Date: 2024/11/25 上午 03:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clock](
	[CustomerId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ClockStartTime] [datetime] NULL,
	[ClockEndTime] [datetime] NULL,
 CONSTRAINT [PK_Clock] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2024/11/25 上午 03:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
	[Birth] [date] NULL,
	[MaritalStatus] [bit] NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[UserAuthority] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customization]    Script Date: 2024/11/25 上午 03:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customization](
	[CustomizationId] [int] NOT NULL,
	[CustomizationType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customization] PRIMARY KEY CLUSTERED 
(
	[CustomizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flavor]    Script Date: 2024/11/25 上午 03:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flavor](
	[FlavorId] [int] IDENTITY(1,1) NOT NULL,
	[CustomizationId] [int] NULL,
	[FlavorName] [nvarchar](50) NULL,
	[FlavorPrice] [int] NULL,
 CONSTRAINT [PK_Flavor] PRIMARY KEY CLUSTERED 
(
	[FlavorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2024/11/25 上午 03:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderNumber] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [int] NULL,
	[BagOption] [bit] NULL,
	[DiningOption] [nvarchar](10) NULL,
	[OrderStatus] [bit] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 2024/11/25 上午 03:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [int] NULL,
	[Quantity] [int] NULL,
	[Flavor] [nvarchar](50) NULL,
	[AddIngredients] [nvarchar](50) NULL,
 CONSTRAINT [PK__OrderIte__57ED06810AC0DA78] PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2024/11/25 上午 03:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[UnitPrice] [int] NULL,
	[ProductCategory] [int] NULL,
	[ProductThumbnails] [nvarchar](50) NULL,
	[ProductImage] [nvarchar](50) NULL,
	[ProductInStockImage] [nvarchar](50) NULL,
	[ProductDescribe] [nvarchar](50) NULL,
	[CustomizationId] [int] NULL,
	[Inventory] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sweetness]    Script Date: 2024/11/25 上午 03:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sweetness](
	[SweetnessId] [int] IDENTITY(1,1) NOT NULL,
	[CustomizationId] [int] NULL,
	[SweetnessLevel] [nvarchar](10) NULL,
 CONSTRAINT [PK_Sweetness] PRIMARY KEY CLUSTERED 
(
	[SweetnessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AddIngredient] ON 

INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (1, 2, N'珍珠+10', 10)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (2, 2, N'布丁+10', 10)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (3, 2, N'湯圓+10', 10)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (4, 2, N'雙圓+10', 10)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (5, 2, N'紅豆+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (6, 2, N'綠豆+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (7, 2, N'彎豆+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (8, 2, N'薏仁+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (9, 2, N'花生+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (10, 2, N'芋頭+20', 20)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (11, 2, N'芋泥+25', 25)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (12, 2, N'奶酪+30', 30)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (13, 2, N'香蕉+40', 40)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (14, 2, N'西瓜+40', 40)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (15, 2, N'芒果+40', 40)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (16, 2, N'草莓+40', 40)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (17, 1, N'珍珠+10', 10)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (18, 1, N'布丁+10', 10)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (19, 1, N'湯圓+10', 10)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (20, 1, N'雙圓+10', 10)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (21, 1, N'紅豆+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (22, 1, N'綠豆+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (23, 1, N'彎豆+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (24, 1, N'薏仁+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (25, 1, N'花生+15', 15)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (26, 1, N'芋頭+20', 20)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (27, 1, N'芋泥+25', 25)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (28, 1, N'奶酪+30', 30)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (29, 1, N'香蕉+40', 40)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (30, 1, N'西瓜+40', 40)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (31, 1, N'芒果+40', 40)
INSERT [dbo].[AddIngredient] ([AddIngredientId], [CustomizationId], [AddIngredientName], [AddIngredientPrice]) VALUES (32, 1, N'草莓+40', 40)
SET IDENTITY_INSERT [dbo].[AddIngredient] OFF
GO
INSERT [dbo].[Clock] ([CustomerId], [Name], [ClockStartTime], [ClockEndTime]) VALUES (4, N'蝦霸', CAST(N'2024-08-17T23:45:12.210' AS DateTime), CAST(N'2024-08-17T23:45:31.033' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (3, N'泡芙阿姨', N'068459123', N'台東縣台東市正氣北路', N'MrsPuff@yagoo.com.us', CAST(N'1990-07-19' AS Date), 1, N'MrsPuff', N'SB7W743f', 3)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (4, N'蝦霸', N'087263154', N'新竹縣湖口鄉中正路一段七號', N'Haruhikage@yahoo.jp.com', CAST(N'2004-11-18' AS Date), 0, N'Lobster', N'DA6rU5zh', 2)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (6, N'飛行荷蘭人', N'096824516', N'桃園市楊梅區豐興街', N'SoyoRin@gmail.com', CAST(N'1995-08-09' AS Date), 0, N'FlyingDutchman', N'v5K5whnb', 1)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (7, N'海綿寶寶', N'07-8694264', N'新北市板橋區重慶路', N'Spongbob@gmail.com', CAST(N'1985-01-26' AS Date), 1, N'Spongbob', N'NKfb5uyM', 2)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (9, N'章魚哥', N'03-4862156', N'新北市汐止區仁愛路310號', N'SquidWard@gmail.com', CAST(N'2013-10-06' AS Date), 0, N'SquidWard', N'3bHsYDRH', 2)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (10, N'蟹老闆', N'06-9821354', N'基隆市仁愛區仁一路313號', N'MrKrab@google.com', CAST(N'2008-11-30' AS Date), 1, N'MrKrab', N'gBUnF3xqZ', 1)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (11, N'珊迪', N'091536487', N'新北市貢寮區東興街351號', N'Sandy@hotmail.com', CAST(N'1983-03-13' AS Date), 0, N'Sandy', N'kxrupN4xi', 3)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (12, N'皮老闆', N'072548791', N'宜蘭縣頭城鎮青雲路三段', N'Sheldon@gmail.com', CAST(N'1975-08-31' AS Date), 1, N'Plankton', N'BsnYZM5vP', 1)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (13, N'凱倫', N'049632587', N'彰化縣員林市大同路一段', N'Karen@yahoo.com.us', CAST(N'1968-06-04' AS Date), 1, N'Karen', N'ufa1gWAML', 2)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (14, N'珍珍', N'094562157', N'彰化縣員林市仁愛里13鄰', N'Pearl@outlook.com', CAST(N'1987-04-01' AS Date), 0, N'Pearl', N'saja4bnTJ', 3)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (15, N'明蒂', N'078542156', N'彰化縣員林市員鹿路103巷', N'MingDee@outlook.com', CAST(N'2007-06-17' AS Date), 0, N'Mindy', N'jbH3f1rWy', 3)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (16, N'海神王', N'032154876', N'彰化縣彰化市中山路二段', N'SeaKing@outlook.com', CAST(N'1960-03-21' AS Date), 1, N'SeaKing', N'sAKno7QjD', 1)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (40, N'Star Butterfly', N'058712345', N'台中市太平區太平路475號', N'ButterFly@hotmail.com', CAST(N'2015-07-09' AS Date), 1, N'StarButterfly', N'rxa7mPgvj', 3)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (41, N'Marco Ubaldo Diaz', N'078951354', N'台中市南屯區五福街185號', N'Marco@yahoo.com.us', CAST(N'2008-02-20' AS Date), 1, N'MarcoDiaz', N'bC6vYKX0a', 3)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (42, N'SpongBob', N'085649712', N'高雄市鹽埕區富野路', N'Spong@hotmail.com', CAST(N'1990-07-20' AS Date), 1, N'Spong', N'YQjT8z9NV', 2)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (43, N'章魚大帥哥', N'0512346985', N'高雄市三民區春陽街', N'SquidWard@yahoo.com.us', CAST(N'2013-06-12' AS Date), 0, N'Squid', N'5f0sgwTk1', 3)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (44, N'PatrickStar', N'0912348796', N'台南市永康區埔園街', N'PatrickStar@gmail.com', CAST(N'1995-08-17' AS Date), 1, N'Patrick2048', N'SpongbobPatrick', 3)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Phone], [Address], [Email], [Birth], [MaritalStatus], [Username], [Password], [UserAuthority]) VALUES (45, N'SouthParkKyle', N'082659874', N'高雄市鳳山區鳳山國小', N'SouthPark@gmail.com', CAST(N'1989-10-17' AS Date), 1, N'Kyle', N'Y7cJQAYNX', 3)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Customization] ([CustomizationId], [CustomizationType]) VALUES (1, N'冰磚口味+加料')
INSERT [dbo].[Customization] ([CustomizationId], [CustomizationType]) VALUES (2, N'加料')
INSERT [dbo].[Customization] ([CustomizationId], [CustomizationType]) VALUES (3, N'甜度')
GO
SET IDENTITY_INSERT [dbo].[Flavor] ON 

INSERT [dbo].[Flavor] ([FlavorId], [CustomizationId], [FlavorName], [FlavorPrice]) VALUES (1, 1, N'牛奶冰磚', 0)
INSERT [dbo].[Flavor] ([FlavorId], [CustomizationId], [FlavorName], [FlavorPrice]) VALUES (2, 1, N'巧克力冰磚+5', 5)
INSERT [dbo].[Flavor] ([FlavorId], [CustomizationId], [FlavorName], [FlavorPrice]) VALUES (3, 1, N'抹茶冰磚+5', 5)
SET IDENTITY_INSERT [dbo].[Flavor] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderNumber], [CustomerId], [UserName], [OrderDate], [TotalAmount], [BagOption], [DiningOption], [OrderStatus]) VALUES (10, 3, N'泡芙阿姨', CAST(N'2024-08-12T00:39:00.957' AS DateTime), 1672, 1, N'外帶', 0)
INSERT [dbo].[Order] ([OrderNumber], [CustomerId], [UserName], [OrderDate], [TotalAmount], [BagOption], [DiningOption], [OrderStatus]) VALUES (14, 43, N'章魚大帥哥', CAST(N'2024-08-16T22:38:20.393' AS DateTime), 357, 1, N'外帶', 0)
INSERT [dbo].[Order] ([OrderNumber], [CustomerId], [UserName], [OrderDate], [TotalAmount], [BagOption], [DiningOption], [OrderStatus]) VALUES (15, 3, N'泡芙阿姨', CAST(N'2024-08-17T22:05:08.087' AS DateTime), 752, 1, N'外帶', 0)
INSERT [dbo].[Order] ([OrderNumber], [CustomerId], [UserName], [OrderDate], [TotalAmount], [BagOption], [DiningOption], [OrderStatus]) VALUES (16, 44, N'PatrickStar', CAST(N'2024-08-17T22:21:43.913' AS DateTime), 912, 1, N'外帶', 1)
INSERT [dbo].[Order] ([OrderNumber], [CustomerId], [UserName], [OrderDate], [TotalAmount], [BagOption], [DiningOption], [OrderStatus]) VALUES (17, 3, N'泡芙阿姨', CAST(N'2024-11-25T02:59:23.800' AS DateTime), 100, 0, N'內用', 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItem] ON 

INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1015, 10, 8, 140, 3, N'', N'西瓜+40, 芋頭+20, 芋泥+25')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1016, 10, 10, 115, 1, N'', N'西瓜+40, 芋頭+20')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1017, 10, 10, 95, 3, N'', N'湯圓+10, 彎豆+15, 薏仁+15')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1018, 10, 20, 215, 2, N'', N'芋頭+20, 西瓜+40, 芒果+40')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1019, 10, 22, 45, 2, N'微糖', N'')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1020, 10, 23, 55, 4, N'半糖', N'')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1021, 10, 23, 55, 2, N'正常糖', N'')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1036, 14, 20, 155, 2, N'', N'芒果+40')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1037, 14, 22, 45, 1, N'正常糖', N'')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1038, 15, 20, 215, 2, N'', N'芋頭+20, 西瓜+40, 芒果+40')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1039, 15, 18, 90, 1, N'', N'')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1040, 15, 2, 70, 2, N'牛奶冰磚', N'')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1041, 15, 22, 45, 2, N'半糖', N'')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1042, 16, 4, 100, 2, N'抹茶冰磚+5', N'雙圓+10, 彎豆+15')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1043, 16, 15, 120, 1, N'', N'花生+15, 香蕉+40')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1044, 16, 17, 130, 2, N'', N'香蕉+40, 芋頭+20')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1045, 16, 17, 110, 1, N'', N'草莓+40')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1046, 16, 22, 45, 2, N'微糖', N'')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1047, 16, 20, 130, 1, N'', N'彎豆+15')
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderNumber], [ProductId], [Price], [Quantity], [Flavor], [AddIngredients]) VALUES (1048, 17, 19, 100, 1, N'牛奶冰磚', N'')
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (1, N'原味牛奶綿綿冰', 55, 1, N'原味牛奶綿綿冰.png', N'原味牛奶綿綿冰.png', N'原味牛奶綿綿冰.png', N'本產品含煉乳。', 1, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (2, N'巧克力脆片綿綿冰', 70, 1, N'巧克力脆片綿綿冰.png', N'巧克力脆片綿綿冰.png', N'巧克力脆片綿綿冰.png', N'本產品含煉乳、巧克力冰磚、巧克力脆片、巧克力醬。', 1, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (3, N'脆花生綿綿冰', 70, 1, N'脆花生綿綿冰.png', N'脆花生綿綿冰.png', N'脆花生綿綿冰.png', N'本產品含煉乳，花生冰磚+脆花生。', 1, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (4, N'草莓果醬綿綿冰', 70, 1, N'草莓果醬綿綿冰.png', N'草莓果醬綿綿冰.png', N'草莓果醬綿綿冰.png', N'本產品含煉乳、草莓果醬。', 1, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (5, N'泰奶奶的綿綿冰', 90, 1, N'泰奶奶的綿綿冰.png', N'泰奶奶的綿綿冰.png', N'泰奶奶的綿綿冰.png', N'本產品含煉乳、泰式奶茶冰磚、鮮奶酪、巧克力脆片', 1, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (6, N'新鮮百香果水果綿綿冰', 100, 1, N'新鮮百香果水果綿綿冰.png', N'新鮮百香果水果綿綿冰.png', N'新鮮百香果水果綿綿冰.png', N'本產品含煉乳、新鮮綜合水果、新鮮百香果', 1, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (7, N'黑砂糖刨冰', 35, 2, N'黑砂糖刨冰.png', N'黑砂糖刨冰.png', N'黑砂糖刨冰.png', N'本產品不含煉乳。', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (8, N'綠豆牛奶刨冰', 55, 2, N'綠豆牛奶刨冰.png', N'綠豆牛奶刨冰.png', N'綠豆牛奶刨冰.png', N'本產品含煉乳。', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (9, N'薏仁牛奶刨冰', 55, 2, N'薏仁牛奶刨冰.png', N'薏仁牛奶刨冰.png', N'薏仁牛奶刨冰.png', N'本產品含煉乳。', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (10, N'巧克力牛奶刨冰', 55, 2, N'巧克力牛奶刨冰.png', N'巧克力牛奶刨冰.png', N'巧克力牛奶刨冰.png', N'本產品含煉乳、巧克力醬。', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (11, N'招牌八寶刨冰', 60, 2, N'招牌八寶刨冰.png', N'招牌八寶刨冰.png', N'招牌八寶刨冰.png', N'本產品不含煉乳、芋頭', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (12, N'芋頭牛奶刨冰', 65, 2, N'芋頭牛奶刨冰.png', N'芋頭牛奶刨冰.png', N'芋頭牛奶刨冰.png', N'本產品含煉乳。', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (13, N'宇治金時刨冰', 70, 2, N'宇治金時刨冰.png', N'宇治金時刨冰.png', N'宇治金時刨冰.png', N'本產品含煉乳、抹茶刨冰。', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (14, N'原味嫩仙草', 35, 3, N'原味嫩仙草.png', N'原味嫩仙草.png', N'原味嫩仙草.png', N'甜度固定。附日本進口奶油球，只限冷品，不可加熱。', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (15, N'招牌嫩仙草', 65, 3, N'招牌嫩仙草.png', N'招牌嫩仙草.png', N'招牌嫩仙草.png', N'本產品含煉乳、黑糖刨冰、嫩仙草、紅豆、雙圓、珍珠、香草冰淇淋', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (16, N'綜合嫩仙草', 65, 3, N'綜合嫩仙草.png', N'綜合嫩仙草.png', N'綜合嫩仙草.png', N'本產品含煉乳、黑糖刨冰、嫩仙草、紅豆、薏仁、雙圓', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (17, N'芋頭嫩仙草', 70, 3, N'芋頭嫩仙草.png', N'芋頭嫩仙草.png', N'芋頭嫩仙草.png', N'本產品含煉乳、黑糖刨冰、嫩仙草、紅豆、芋頭、彎豆、雙圓', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (18, N'新鮮芒果西瓜刨冰', 90, 4, N'季節限定_新鮮芒果西瓜刨冰.png', N'季節限定_新鮮芒果西瓜刨冰.png', N'季節限定_新鮮芒果西瓜刨冰.png', N'本產品含煉乳。(冬季會以新鮮急速冷凍愛文芒果替代)', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (19, N'新鮮芒果香蕉綿綿冰', 100, 4, N'季節限定_新鮮芒果香蕉綿綿冰.png', N'季節限定_新鮮芒果香蕉綿綿冰.png', N'季節限定_新鮮芒果香蕉綿綿冰.png', N'本產品含煉乳。(冬季會以新鮮急速冷凍愛文芒果替代)', 1, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (20, N'新鮮草莓水果刨冰', 115, 4, N'季節限定_新鮮草莓水果刨冰.png', N'季節限定_新鮮草莓水果刨冰.png', N'季節限定_新鮮草莓水果刨冰.png', N'本產品含黑糖、草莓果醬、煉乳。', 2, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (21, N'新鮮草莓巧克力脆片綿綿冰', 120, 4, N'季節限定_新鮮草莓巧克力脆片綿綿冰.png', N'季節限定_新鮮草莓巧克力脆片綿綿冰.png', N'季節限定_新鮮草莓巧克力脆片綿綿冰.png', N'本產品含煉乳、巧克力口味冰磚、巧克力醬、巧克力脆片。', 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (22, N'新鮮西瓜汁', 45, 5, N'新鮮西瓜汁.png', N'新鮮西瓜汁.png', N'新鮮西瓜汁.png', N'500cc，285大卡', 3, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [UnitPrice], [ProductCategory], [ProductThumbnails], [ProductImage], [ProductInStockImage], [ProductDescribe], [CustomizationId], [Inventory]) VALUES (23, N'恐龍可可', 55, 5, N'恐龍可可.png', N'恐龍可可.png', N'恐龍可可.png', N'500cc 甜度不可調整，美祿原物料使用。', 3, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Sweetness] ON 

INSERT [dbo].[Sweetness] ([SweetnessId], [CustomizationId], [SweetnessLevel]) VALUES (1, 3, N'正常糖')
INSERT [dbo].[Sweetness] ([SweetnessId], [CustomizationId], [SweetnessLevel]) VALUES (2, 3, N'微糖')
INSERT [dbo].[Sweetness] ([SweetnessId], [CustomizationId], [SweetnessLevel]) VALUES (3, 3, N'半糖')
SET IDENTITY_INSERT [dbo].[Sweetness] OFF
GO
/****** Object:  Index [FK_Sweetness_CustomizationId]    Script Date: 2024/11/25 上午 03:36:26 ******/
CREATE NONCLUSTERED INDEX [FK_Sweetness_CustomizationId] ON [dbo].[Sweetness]
(
	[SweetnessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AddIngredient]  WITH CHECK ADD  CONSTRAINT [FK_AddIngredient_Customization] FOREIGN KEY([CustomizationId])
REFERENCES [dbo].[Customization] ([CustomizationId])
GO
ALTER TABLE [dbo].[AddIngredient] CHECK CONSTRAINT [FK_AddIngredient_Customization]
GO
ALTER TABLE [dbo].[Flavor]  WITH CHECK ADD  CONSTRAINT [FK_Flavor_Customization] FOREIGN KEY([CustomizationId])
REFERENCES [dbo].[Customization] ([CustomizationId])
GO
ALTER TABLE [dbo].[Flavor] CHECK CONSTRAINT [FK_Flavor_Customization]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Order] FOREIGN KEY([OrderNumber])
REFERENCES [dbo].[Order] ([OrderNumber])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Order]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_OrderNumber] FOREIGN KEY([OrderNumber])
REFERENCES [dbo].[Order] ([OrderNumber])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_OrderNumber]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_ProductId]
GO
ALTER TABLE [dbo].[Sweetness]  WITH CHECK ADD  CONSTRAINT [FK_Sweetness_Customization] FOREIGN KEY([CustomizationId])
REFERENCES [dbo].[Customization] ([CustomizationId])
GO
ALTER TABLE [dbo].[Sweetness] CHECK CONSTRAINT [FK_Sweetness_Customization]
GO
USE [master]
GO
ALTER DATABASE [myIceShop] SET  READ_WRITE 
GO
