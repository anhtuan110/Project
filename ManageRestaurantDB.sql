USE [master]
GO
/****** Object:  Database [QuanLyNhaHang]    Script Date: 8/18/2023 6:43:31 PM ******/
CREATE DATABASE [QuanLyNhaHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyNhaHang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QuanLyNhaHang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyNhaHang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QuanLyNhaHang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyNhaHang] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyNhaHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyNhaHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyNhaHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyNhaHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyNhaHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyNhaHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyNhaHang] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyNhaHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyNhaHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyNhaHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyNhaHang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyNhaHang] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyNhaHang] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyNhaHang', N'ON'
GO
ALTER DATABASE [QuanLyNhaHang] SET QUERY_STORE = OFF
GO
USE [QuanLyNhaHang]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 8/18/2023 6:43:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 8/18/2023 6:43:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NOT NULL,
	[idTable] [int] NOT NULL,
	discount [float] default 0,
	totalBill [money] default 0,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 8/18/2023 6:43:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 8/18/2023 6:43:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[Price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 8/18/2023 6:43:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 8/18/2023 6:43:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Accounts] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'admin', N'Admin', N'admin', 1)
INSERT [dbo].[Accounts] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'nhanvien1', N'Nhan Vien', N' nhanvien@123', 2)
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (2, CAST(N'2023-08-18' AS Date), CAST(N'2023-08-18' AS Date), 1, 1)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (3, CAST(N'2023-08-17' AS Date), CAST(N'2023-08-17' AS Date), 2, 2)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (4, CAST(N'2023-08-17' AS Date), CAST(N'2023-08-17' AS Date), 3, 2)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status]) VALUES (5, CAST(N'2023-08-18' AS Date), CAST(N'2023-08-18' AS Date), 2, 2)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (20, 2, 2, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (22, 2, 6, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (23, 2, 7, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (24, 2, 52, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (25, 2, 34, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (26, 2, 50, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (27, 3, 15, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (28, 3, 26, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (29, 3, 37, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (30, 4, 16, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (31, 4, 15, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (32, 4, 35, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (33, 4, 38, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (34, 5, 13, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (35, 5, 38, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (36, 5, 37, 2)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (1, N'Gà viên chiên', 1, 30000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (2, N'Khoai tây chiên', 1, 30000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (3, N'Ngô chiên', 1, 30000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (4, N'Hamburger', 1, 45000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (5, N'Hot dog', 1, 35000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (6, N'Xúc Xích', 1, 10000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (7, N'Trà Sữa', 2, 35000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (11, N'Beer Tiger', 2, 15000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (13, N'Beer Ha Noi', 2, 13000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (14, N'Beer Heineken', 2, 15000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (15, N'Bia Sai Gon', 2, 13000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (16, N'CoCa', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (18, N'Red Bull', 2, 15000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (19, N'Pepsi', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (20, N'Sting', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (21, N'Mirinda', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (22, N'7Up', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (23, N'Cappuccino', 2, 40000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (24, N'Cà phê đen', 2, 30000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (25, N'Cà phê sữa', 2, 35000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (26, N'Cà phê phin', 2, 40000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (27, N'Nước ép táo', 2, 35000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (28, N'Nước cam', 2, 35000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (30, N'Nước chanh', 2, 15000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (31, N'Chả mực', 3, 150000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (32, N'Mực ống nhồi thịt', 3, 250000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (33, N'Mực hấp', 3, 200000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (34, N'Dê tái chanh', 3, 300000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (35, N'Gà rang lá chanh', 3, 200000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (36, N'Gà hấp muối', 3, 200000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (37, N'Gà rang muối', 3, 250000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (38, N'Bò hầm tiêu đen', 3, 290000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (40, N'Bò sốt tiêu đen', 3, 250000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (41, N'Gỏi tôm', 4, 70000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (42, N'Salad', 4, 45000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (43, N'Gỏi tai heo', 4, 50000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (44, N'Súp cua', 5, 60000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (45, N'Súp gà', 5, 50000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (46, N'Súp bí đỏ', 5, 40000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (47, N'Súp lươn', 5, 60000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (48, N'Súp nấm', 5, 45000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (49, N'Súp chay', 5, 40000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (50, N'Chè hạt sen', 6, 30000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (51, N'Chè dừa dầm', 6, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (52, N'Bánh chuối nướng', 6, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [Price]) VALUES (53, N'Chè vải hạt sen', 6, 35000)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (1, N'Đồ ăn nhanh')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (2, N'Đồ ăn')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (3, N'Món chính')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (4, N'Khai vị')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (5, N'Món súp')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (6, N'Tráng miệng')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1, N'Table1', N'Occupied')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (2, N'Table2', N'Booked')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (3, N'Table3', N'Available')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (4, N'Table4', N'Available')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (5, N'Table5', N'Available')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (6, N'Table6', N'Available')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (7, N'Table7', N'Available')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT (N'Group 6') FOR [DisplayName]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((0)) FOR [PassWord]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Trống') FOR [status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableFood] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[FoodCategory] ([id])
GO
USE [master]
GO
ALTER DATABASE [QuanLyNhaHang] SET  READ_WRITE 
GO
