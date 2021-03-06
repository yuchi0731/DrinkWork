USE [master]
GO
/****** Object:  Database [DrinkOrderSystem]    Script Date: 2021/9/17 下午 07:30:14 ******/
CREATE DATABASE [DrinkOrderSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DrinkOrderSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DrinkOrderSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DrinkOrderSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DrinkOrderSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DrinkOrderSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DrinkOrderSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DrinkOrderSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DrinkOrderSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DrinkOrderSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DrinkOrderSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DrinkOrderSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [DrinkOrderSystem] SET  MULTI_USER 
GO
ALTER DATABASE [DrinkOrderSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DrinkOrderSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DrinkOrderSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DrinkOrderSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DrinkOrderSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DrinkOrderSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DrinkOrderSystem', N'ON'
GO
ALTER DATABASE [DrinkOrderSystem] SET QUERY_STORE = OFF
GO
USE [DrinkOrderSystem]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2021/9/17 下午 07:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Picture] [nvarchar](100) NULL,
 CONSTRAINT [PK_Categories_1] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 2021/9/17 下午 07:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailsID] [uniqueidentifier] NOT NULL,
	[OrderNumber] [nvarchar](100) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[OrderTime] [datetime] NOT NULL,
	[OrderEndTime] [datetime] NOT NULL,
	[RequiredTime] [datetime] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[UnitPrice] [decimal](18, 0) NOT NULL,
	[Toppings] [nvarchar](100) NULL,
	[ToppingsUnitPrice] [decimal](18, 0) NULL,
	[Suger] [nvarchar](50) NOT NULL,
	[Ice] [nvarchar](50) NOT NULL,
	[SupplierName] [nvarchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
	[SubtotalAmount] [decimal](18, 0) NOT NULL,
	[OtherRequest] [nvarchar](max) NULL,
	[Established] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderList]    Script Date: 2021/9/17 下午 07:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderList](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [nvarchar](100) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[OrderTime] [datetime] NOT NULL,
	[OrderEndTime] [datetime] NOT NULL,
	[RequiredTime] [datetime] NOT NULL,
	[SupplierName] [nvarchar](100) NOT NULL,
	[TotalPrice] [decimal](18, 0) NOT NULL,
	[TotalCups] [int] NOT NULL,
	[Established] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderList] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2021/9/17 下午 07:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[SupplierName] [nvarchar](100) NOT NULL,
	[UnitPrice] [decimal](18, 0) NOT NULL,
	[UnitsMaxOrder] [int] NULL,
	[Discount] [real] NULL,
	[CategoryName] [nvarchar](50) NULL,
	[Picture] [nvarchar](100) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 2021/9/17 下午 07:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [uniqueidentifier] NOT NULL,
	[SupplierName] [nvarchar](100) NOT NULL,
	[ContactFirstName] [nvarchar](50) NOT NULL,
	[ContactLastName] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[ContactTitle] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[SupplierWebPage] [nvarchar](max) NULL,
	[OtherService] [nvarchar](max) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Toppings]    Script Date: 2021/9/17 下午 07:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toppings](
	[ToppingsID] [int] IDENTITY(1,1) NOT NULL,
	[ToppingsName] [nvarchar](100) NOT NULL,
	[UnitPrice] [decimal](18, 0) NOT NULL,
	[Picture] [nvarchar](100) NULL,
 CONSTRAINT [PK_Toppings_1] PRIMARY KEY CLUSTERED 
(
	[ToppingsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 2021/9/17 下午 07:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[UserID] [uniqueidentifier] NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2021/9/17 下午 07:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Account] [varchar](50) NOT NULL,
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [nvarchar](20) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[ext] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[JobGrade] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ResponseSuppliers] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[Photo] [nvarchar](100) NULL,
 CONSTRAINT [PK_UsersInfo_1] PRIMARY KEY CLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (1, N'Tea', N'Tea', NULL)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (2, N'MilkTea', N'MilkTea', NULL)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (5, N'Juice', N'Juice', NULL)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (6, N'
Smoothie', N'
Smoothie', NULL)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (7, N'Yakult', N'Yakult', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'2f0fd31a-2f44-4494-baab-0861f4cabdcf', N'Odr10779091611022021', N'MawSweet', CAST(N'2021-09-16T11:03:10.703' AS DateTime), CAST(N'2021-09-23T11:03:00.000' AS DateTime), CAST(N'2021-09-25T11:03:00.000' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'寒天', CAST(5 AS Decimal(18, 0)), N'無糖', N'微冰', N'WhiteAlley', 3, CAST(135 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'a1c70b89-0301-443b-a0c7-0b043932079a', N'Odr10779091613532021', N'MawSweet', CAST(N'2021-09-16T13:53:16.957' AS DateTime), CAST(N'2021-09-17T13:06:00.000' AS DateTime), CAST(N'2021-09-24T13:53:00.000' AS DateTime), N'BubbleTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'半糖', N'去冰', N'Fiftylan', 3, CAST(150 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'a77e37da-7ade-4d5e-97e0-25ba8e041584', N'Odr00000000000042021', N'LueQuen', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'半糖', N'去冰', N'WhiteAlley', 1, CAST(50 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'c31a3a56-dc68-4c97-808f-2b070cd7fac0', N'Odr10779091612372021', N'MawSweet', CAST(N'2021-09-16T12:38:10.880' AS DateTime), CAST(N'2021-09-18T12:37:00.000' AS DateTime), CAST(N'2021-09-30T12:37:00.000' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'不加料', CAST(0 AS Decimal(18, 0)), N'無糖', N'去冰', N'WhiteAlley', 4, CAST(160 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'0bb85dc5-9ac8-4ac0-8640-309a4370e2ee', N'Odr00000000000022021', N'BpbMa', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), N'Springbudgreentea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'半糖', N'去冰', N'WhiteAlley', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Established')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'1a3ef339-fcc4-47f7-a0a3-3cd384d804c7', N'Odr00000000000042021', N'MeryLee', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'Springbudgreentea
', CAST(40 AS Decimal(18, 0)), N'不加料', NULL, N'半糖', N'去冰', N'WhiteAlley', 5, CAST(200 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'7d3bbf43-4a05-4649-8e3a-41bb112027ac', N'Odr10779091612322021', N'MawSweet', CAST(N'2021-09-16T12:33:01.683' AS DateTime), CAST(N'2021-09-17T12:32:00.000' AS DateTime), CAST(N'2021-09-25T12:32:00.000' AS DateTime), N'YakultGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'少冰', N'WhiteAlley', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'46175693-39fe-4d4a-840e-429941179de2', N'Order10779091501012021', N'MawSweet', CAST(N'2021-09-15T01:02:01.473' AS DateTime), CAST(N'2021-09-24T01:01:00.000' AS DateTime), CAST(N'2021-10-01T01:01:00.000' AS DateTime), N'GreenTea', CAST(40 AS Decimal(18, 0)), N'椰果', CAST(10 AS Decimal(18, 0)), N'半糖', N'少冰', N'MilkShop', 3, CAST(135 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'516e3536-0736-416a-b32a-467cf66a417b', N'Odr00000000000042021', N'LueQuen', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'不加料', NULL, N'半糖', N'去冰', N'WhiteAlley', 3, CAST(120 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'237f7854-f959-4680-a43f-4756c95a3c98', N'Odr1077_091735', N'MawSweet', CAST(N'2021-09-17T15:35:40.307' AS DateTime), CAST(N'2021-09-30T15:35:00.000' AS DateTime), CAST(N'2021-10-08T15:35:00.000' AS DateTime), N'BubbleTea', CAST(55 AS Decimal(18, 0)), N'不加料', CAST(0 AS Decimal(18, 0)), N'微糖', N'微冰', N'Fiftylan', 2, CAST(110 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'cd832353-f092-40dd-82b0-4c00b0cdf6ab', N'Odr1077_091735', N'MawSweet', CAST(N'2021-09-17T15:35:40.307' AS DateTime), CAST(N'2021-09-30T15:35:00.000' AS DateTime), CAST(N'2021-10-08T15:35:00.000' AS DateTime), N'FourSeasonsGreenTea', CAST(40 AS Decimal(18, 0)), N'不加料', CAST(0 AS Decimal(18, 0)), N'微糖', N'微冰', N'Fiftylan', 1, CAST(40 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'e691b218-1f72-4fac-a853-4e7b62a1d2ab', N'Odr00000000000052021', N'MeryLee', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'MilkTea', CAST(50 AS Decimal(18, 0)), N'不加料', NULL, N'半糖', N'去冰', N'Milkshop', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'0785f784-779b-4d4d-8c75-58cf9a7785f1', N'Odr1077_091735', N'MawSweet', CAST(N'2021-09-17T15:35:40.307' AS DateTime), CAST(N'2021-09-30T15:35:00.000' AS DateTime), CAST(N'2021-10-08T15:35:00.000' AS DateTime), N'BubbleTea', CAST(55 AS Decimal(18, 0)), N'不加料', CAST(0 AS Decimal(18, 0)), N'微糖', N'微冰', N'Fiftylan', 2, CAST(110 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'72ff82ee-cae1-435f-9127-613d554ad4a2', N'Odr10779091613532021', N'MawSweet', CAST(N'2021-09-16T13:53:16.957' AS DateTime), CAST(N'2021-09-17T13:06:00.000' AS DateTime), CAST(N'2021-09-24T13:53:00.000' AS DateTime), N'BubbleTea', CAST(55 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'無糖', N'微冰', N'Fiftylan', 3, CAST(195 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'99a614b9-e268-4ac0-9308-61f019780efc', N'Odr00000000000052021', N'BpbMa', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'Springbudgreentea
', CAST(40 AS Decimal(18, 0)), N'不加料', NULL, N'半糖', N'去冰', N'Milkshop', 2, CAST(80 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'd2696878-0980-451a-a0aa-645adc5e0398', N'Order10779091501322021', N'MawSweet', CAST(N'2021-09-15T01:33:09.397' AS DateTime), CAST(N'2021-10-20T01:32:00.000' AS DateTime), CAST(N'2021-10-02T01:32:00.000' AS DateTime), N'PassionGreenTea', CAST(40 AS Decimal(18, 0)), N'寒天', CAST(5 AS Decimal(18, 0)), N'半糖', N'去冰', N'WhiteAlley', 4, CAST(180 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'60bdbe73-31aa-4364-9cad-67a9c12ab31f', N'Order10779091501532021', N'MawSweet', CAST(N'2021-09-15T01:54:28.513' AS DateTime), CAST(N'2021-09-15T02:10:00.000' AS DateTime), CAST(N'2021-10-13T01:53:00.000' AS DateTime), N'PlumGreenTea', CAST(40 AS Decimal(18, 0)), N'椰果', CAST(10 AS Decimal(18, 0)), N'半糖', N'少冰', N'Fiftylan', 5, CAST(200 AS Decimal(18, 0)), NULL, N'Established')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'05781531-f435-4e8c-bfdd-692d27c3eb69', N'Order10779091501312021', N'MawSweet', CAST(N'2021-09-15T01:33:09.397' AS DateTime), CAST(N'2021-10-20T01:32:00.000' AS DateTime), CAST(N'2021-10-02T01:32:00.000' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'寒天', CAST(5 AS Decimal(18, 0)), N'半糖', N'微冰', N'WhiteAlley', 1, CAST(45 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'65bd65ea-d177-4d71-8a5c-6a144d1fcee3', N'Order10779091501512021', N'MawSweet', CAST(N'2021-09-15T01:54:28.513' AS DateTime), CAST(N'2021-09-15T02:10:00.000' AS DateTime), CAST(N'2021-10-13T01:53:00.000' AS DateTime), N'BubbleTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'半糖', N'微冰', N'Fiftylan', 4, CAST(200 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'1008fac1-3240-4bb2-90bd-6af9aab4f684', N'Order10779091501512021', N'MawSweet', CAST(N'2021-09-15T01:54:28.513' AS DateTime), CAST(N'2021-09-15T02:10:00.000' AS DateTime), CAST(N'2021-10-13T01:53:00.000' AS DateTime), N'PlumGreenTea', CAST(40 AS Decimal(18, 0)), N'寒天', CAST(5 AS Decimal(18, 0)), N'微糖', N'微冰', N'Fiftylan', 2, CAST(90 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'c24c09c1-3d0c-41f6-8bc7-6eda9858829a', N'Odr10779091510592021', N'MawSweet', CAST(N'2021-09-15T11:01:28.960' AS DateTime), CAST(N'2021-09-15T11:12:00.000' AS DateTime), CAST(N'2021-09-16T11:01:00.000' AS DateTime), N'BubbleTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'微冰', N'Fiftylan', 4, CAST(200 AS Decimal(18, 0)), NULL, N'Established')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'816ce3db-d961-474d-a2e3-77708eff39d3', N'Odr10779091613522021', N'MawSweet', CAST(N'2021-09-16T13:53:16.957' AS DateTime), CAST(N'2021-09-17T13:06:00.000' AS DateTime), CAST(N'2021-09-24T13:53:00.000' AS DateTime), N'PlumGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'微冰', N'Fiftylan', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'c4236b01-879a-4444-a22a-78290fc6e02c', N'Odr10779091511122021', N'MawSweet', CAST(N'2021-09-15T11:13:11.443' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), N'GreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'微冰', N'MilkShop', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'd64bc42a-7ac2-4d39-91f1-898fb51834ee', N'Odr10779091609122021', N'MawSweet', CAST(N'2021-09-16T09:13:23.947' AS DateTime), CAST(N'2021-09-16T09:28:00.000' AS DateTime), CAST(N'2021-09-16T15:00:00.000' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'無糖', N'微冰', N'WhiteAlley', 2, CAST(0 AS Decimal(18, 0)), NULL, N'Established')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'7836fdc7-91bc-4508-a43d-8a1000aa2086', N'Order10779091500402021', N'MawSweet', CAST(N'2021-09-15T00:41:47.110' AS DateTime), CAST(N'2021-09-16T00:41:00.000' AS DateTime), CAST(N'2021-09-23T00:41:00.000' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'椰果', CAST(10 AS Decimal(18, 0)), N'微糖', N'微冰', N'WhiteAlley', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Established')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'7163ba36-9427-4d44-85d7-8b4c599bfbbe', N'Odr10779091511122021', N'MawSweet', CAST(N'2021-09-15T11:13:11.443' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), N'MilkTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'微冰', N'MilkShop', 3, CAST(150 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'9b5b828d-c67b-4cc7-ad83-92313dbd287a', N'Odr10779091510592021', N'MawSweet', CAST(N'2021-09-15T11:01:28.960' AS DateTime), CAST(N'2021-09-15T11:12:00.000' AS DateTime), CAST(N'2021-09-16T11:01:00.000' AS DateTime), N'PlumGreenTea', CAST(40 AS Decimal(18, 0)), N'寒天', CAST(5 AS Decimal(18, 0)), N'微糖', N'微冰', N'Fiftylan', 1, CAST(45 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'922d1ba9-6cac-42cc-ac1b-996e98dc6025', N'Odr10779091715252021', N'MawSweet', CAST(N'2021-09-17T15:25:09.673' AS DateTime), CAST(N'2021-09-29T15:25:00.000' AS DateTime), CAST(N'2021-10-08T15:25:00.000' AS DateTime), N'PassionGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'無糖', N'微冰', N'WhiteAlley', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'a310b5d3-859a-4aed-9432-9d83c6b7baa5', N'Odr00000000000012021', N'ZeoLin', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'不加料', NULL, N'微糖', N'微冰', N'WhiteAlley', 1, CAST(40 AS Decimal(18, 0)), NULL, N'Established')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'f1a5e804-ad62-4daa-b7e5-a58a8cbe83a5', N'Odr00000000000042021', N'MawSweet', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'微冰', N'WhiteAlley', 2, CAST(100 AS Decimal(18, 0)), N'', N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'8fc648e7-d554-495f-89e1-a81e7da9830e', N'Order10779091501532021', N'MawSweet', CAST(N'2021-09-15T01:54:28.513' AS DateTime), CAST(N'2021-09-15T02:10:00.000' AS DateTime), CAST(N'2021-10-13T01:53:00.000' AS DateTime), N'BubbleTea', CAST(40 AS Decimal(18, 0)), N'寒天', CAST(5 AS Decimal(18, 0)), N'微糖', N'正常冰', N'Fiftylan', 2, CAST(90 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'9537c5fe-7525-426f-a787-a9cc69477f22', N'Odr10779091609592021', N'MawSweet', CAST(N'2021-09-16T09:59:39.000' AS DateTime), CAST(N'2021-09-21T09:59:00.000' AS DateTime), CAST(N'2021-10-08T09:59:00.000' AS DateTime), N'GreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'無糖', N'去冰', N'MilkShop', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'1413a204-8f66-4fd1-85da-a9d816c12c2e', N'Odr10779091715242021', N'MawSweet', CAST(N'2021-09-17T15:25:09.673' AS DateTime), CAST(N'2021-09-29T15:25:00.000' AS DateTime), CAST(N'2021-10-08T15:25:00.000' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'無糖', N'微冰', N'WhiteAlley', 1, CAST(50 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'6c3e912b-7f0b-4e58-a906-aa07e6699973', N'Odr00000000000012021', N'BpbMa', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), N'Springbudgreentea
', CAST(40 AS Decimal(18, 0)), N'不加料', NULL, N'微糖', N'正常冰', N'WhiteAlley', 2, CAST(80 AS Decimal(18, 0)), NULL, N'Established')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'9098b4fd-0ede-4623-9a35-b00cca99a87e', N'Odr00000000000042021', N'MawSweet', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'無糖', N'微冰', N'WhiteAlley', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'0bf4e83b-60bf-4c34-8f1a-b1ddeec48b44', N'Odr10779091611032021', N'MawSweet', CAST(N'2021-09-16T11:03:10.703' AS DateTime), CAST(N'2021-09-23T11:03:00.000' AS DateTime), CAST(N'2021-09-25T11:03:00.000' AS DateTime), N'PassionGreenTea', CAST(40 AS Decimal(18, 0)), N'寒天', CAST(5 AS Decimal(18, 0)), N'半糖', N'去冰', N'WhiteAlley', 3, CAST(135 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'ab2d0e20-c5ae-49d3-b081-b4bb7291f981', N'Odr10779091613532021', N'generaluser', CAST(N'2021-09-16T13:53:16.957' AS DateTime), CAST(N'2021-09-17T13:06:00.000' AS DateTime), CAST(N'2021-09-24T13:53:00.000' AS DateTime), N'BubbleTea', CAST(55 AS Decimal(18, 0)), N'不加料', CAST(0 AS Decimal(18, 0)), N'無糖', N'去冰', N'Fiftylan', 2, CAST(110 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'cc828f20-9473-4abf-971a-b589092faa3e', N'Odr10779091611262021', N'MawSweet', CAST(N'2021-09-16T11:26:27.067' AS DateTime), CAST(N'2021-09-16T11:37:00.000' AS DateTime), CAST(N'2021-09-17T11:26:00.000' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'微冰', N'WhiteAlley', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'07c5e2f5-2bc6-479a-8a64-b6b61c8b73b4', N'Odr10779091511122021', N'MawSweet', CAST(N'2021-09-15T11:13:11.443' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), N'MilkTea', CAST(50 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'正常冰', N'MilkShop', 2, CAST(120 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'1f86c5bb-7698-447f-bf93-b77694a462a6', N'Odr00000000000042021', N'MawSweet', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'正常冰', N'WhiteAlley', 5, CAST(250 AS Decimal(18, 0)), N'', N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'76b2ed09-014f-4904-ba7e-b8e31e28bc84', N'Odr10779091611052021', N'MawSweet', CAST(N'2021-09-16T11:05:23.567' AS DateTime), CAST(N'2021-09-16T11:22:00.000' AS DateTime), CAST(N'2021-09-17T11:09:00.000' AS DateTime), N'MilkTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'微糖', N'少冰', N'MilkShop', 4, CAST(160 AS Decimal(18, 0)), NULL, N'Established')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'c83a48aa-2340-499a-a7f2-bda268ec7563', N'Odr10779091609292021', N'MawSweet', CAST(N'2021-09-16T09:29:48.260' AS DateTime), CAST(N'2021-09-23T09:29:00.000' AS DateTime), CAST(N'2021-09-24T09:29:00.000' AS DateTime), N'GreenTea', CAST(40 AS Decimal(18, 0)), N'不加料', CAST(0 AS Decimal(18, 0)), N'少糖', N'正常冰', N'MilkShop', 2, CAST(80 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'ae578ea1-685b-4813-afb5-c47444bf7125', N'Odr10779091610062021', N'MawSweet', CAST(N'2021-09-16T10:06:40.177' AS DateTime), CAST(N'2021-09-17T10:06:00.000' AS DateTime), CAST(N'2021-09-24T10:06:00.000' AS DateTime), N'GreenTea', CAST(40 AS Decimal(18, 0)), N'不加料', CAST(0 AS Decimal(18, 0)), N'微糖', N'少冰', N'MilkShop', 2, CAST(80 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'ec34adb1-ab81-453c-a8be-c875be4cbb4d', N'Odr10779091611262021', N'MawSweet', CAST(N'2021-09-16T11:26:27.067' AS DateTime), CAST(N'2021-09-16T11:37:00.000' AS DateTime), CAST(N'2021-09-17T11:26:00.000' AS DateTime), N'MilkTea', CAST(40 AS Decimal(18, 0)), N'椰果', CAST(10 AS Decimal(18, 0)), N'半糖', N'少冰', N'WhiteAlley', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'ec2e063f-59dd-4eeb-8b89-dd1740899d1c', N'Odr10779091603572021', N'MawSweet', CAST(N'2021-09-16T03:57:22.573' AS DateTime), CAST(N'2021-09-17T03:56:00.000' AS DateTime), CAST(N'2021-09-30T03:56:00.000' AS DateTime), N'JasmineGreenTea2', CAST(40 AS Decimal(18, 0)), N'寒天', CAST(5 AS Decimal(18, 0)), N'微糖', N'微冰', N'WhiteAlley', 2, CAST(90 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'9aa233bf-1d0b-49dc-9372-e1fb365e4cf5', N'Odr00000000000032021', N'MawSweet', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), N'JasmineGreenTea', CAST(40 AS Decimal(18, 0)), N'不加料', NULL, N'無糖', N'正常冰', N'WhiteAlley', 2, CAST(80 AS Decimal(18, 0)), NULL, N'Fail')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'b6d2040d-29a0-4efa-a452-e424751d698c', N'Odr10779091610062021', N'MawSweet', CAST(N'2021-09-16T10:06:40.177' AS DateTime), CAST(N'2021-09-17T10:06:00.000' AS DateTime), CAST(N'2021-09-24T10:06:00.000' AS DateTime), N'GreenTea', CAST(40 AS Decimal(18, 0)), N'不加料', CAST(0 AS Decimal(18, 0)), N'微糖', N'少冰', N'MilkShop', 3, CAST(120 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'6ed953cf-8dd8-4ad8-82ec-e71e3e038104', N'Order10779091501012021', N'MawSweet', CAST(N'2021-09-15T01:02:01.813' AS DateTime), CAST(N'2021-09-24T01:01:00.000' AS DateTime), CAST(N'2021-10-01T01:01:00.000' AS DateTime), N'GreenTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'無糖', N'正常冰', N'MilkShop', 2, CAST(100 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'aea0c2dc-be76-40d8-9ecb-e8839a7fcfae', N'Order10779091501512021', N'MawSweet', CAST(N'2021-09-15T01:54:28.513' AS DateTime), CAST(N'2021-09-15T02:10:00.000' AS DateTime), CAST(N'2021-10-13T01:53:00.000' AS DateTime), N'BubbleTea', CAST(40 AS Decimal(18, 0)), N'珍珠', CAST(10 AS Decimal(18, 0)), N'無糖', N'正常冰', N'Fiftylan', 4, CAST(200 AS Decimal(18, 0)), NULL, N'Inprogress')
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [ProductName], [UnitPrice], [Toppings], [ToppingsUnitPrice], [Suger], [Ice], [SupplierName], [Quantity], [SubtotalAmount], [OtherRequest], [Established]) VALUES (N'3a49dfd8-0fbe-4001-9304-eda62f7f5490', N'Odr10779091511122021', N'MawSweet', CAST(N'2021-09-15T11:13:11.443' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), N'GreenTea', CAST(40 AS Decimal(18, 0)), N'寒天', CAST(5 AS Decimal(18, 0)), N'無糖', N'正常冰', N'MilkShop', 2, CAST(90 AS Decimal(18, 0)), NULL, N'Inprogress')
GO
SET IDENTITY_INSERT [dbo].[OrderList] ON 

INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (3, N'Odr00000000000012021', N'BpbMa', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), N'WhiteAlley', CAST(120 AS Decimal(18, 0)), 3, N'Fail')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (5, N'Odr00000000000022021', N'BpbMa', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), N'WhiteAlley', CAST(100 AS Decimal(18, 0)), 2, N'Established')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (7, N'Odr00000000000032021', N'MawSweet', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-09-15T11:49:04.653' AS DateTime), N'WhiteAlley', CAST(80 AS Decimal(18, 0)), 2, N'Fail')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (9, N'Odr00000000000042021', N'LueQuen', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'WhiteAlley', CAST(820 AS Decimal(18, 0)), 18, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (10, N'Odr00000000000052021', N'MeryLee', CAST(N'2021-09-01T15:49:04.653' AS DateTime), CAST(N'2021-09-21T15:49:04.653' AS DateTime), CAST(N'2021-09-30T15:49:04.653' AS DateTime), N'Milkshop', CAST(180 AS Decimal(18, 0)), 4, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (13, N'Order10779091500402021', N'MawSweet', CAST(N'2021-09-15T00:41:47.887' AS DateTime), CAST(N'2021-09-16T00:41:00.000' AS DateTime), CAST(N'2021-09-23T00:41:00.000' AS DateTime), N'WhiteAlley', CAST(100 AS Decimal(18, 0)), 2, N'Established')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (14, N'Order10779091501012021', N'MawSweet', CAST(N'2021-09-15T01:02:02.133' AS DateTime), CAST(N'2021-09-24T01:01:00.000' AS DateTime), CAST(N'2021-10-01T01:01:00.000' AS DateTime), N'MilkShop', CAST(235 AS Decimal(18, 0)), 5, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (15, N'Order10779091501322021', N'MawSweet', CAST(N'2021-09-15T01:33:09.397' AS DateTime), CAST(N'2021-10-20T01:32:00.000' AS DateTime), CAST(N'2021-10-02T01:32:00.000' AS DateTime), N'WhiteAlley', CAST(225 AS Decimal(18, 0)), 4, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (16, N'Order10779091501532021', N'MawSweet', CAST(N'2021-09-15T01:54:28.513' AS DateTime), CAST(N'2021-09-15T02:10:00.000' AS DateTime), CAST(N'2021-10-13T01:53:00.000' AS DateTime), N'Fiftylan', CAST(290 AS Decimal(18, 0)), 7, N'Established')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (17, N'Odr10779091510592021', N'MawSweet', CAST(N'2021-09-15T11:01:28.960' AS DateTime), CAST(N'2021-09-15T11:12:00.000' AS DateTime), CAST(N'2021-09-16T11:01:00.000' AS DateTime), N'Fiftylan', CAST(245 AS Decimal(18, 0)), 5, N'Established')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (21, N'Odr10779091511122021', N'MawSweet', CAST(N'2021-09-15T11:13:11.443' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), CAST(N'2021-09-23T11:13:00.000' AS DateTime), N'MilkShop', CAST(460 AS Decimal(18, 0)), 9, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (22, N'Odr10779091603572021', N'MawSweet', CAST(N'2021-09-16T03:57:22.573' AS DateTime), CAST(N'2021-09-17T03:56:00.000' AS DateTime), CAST(N'2021-09-30T03:56:00.000' AS DateTime), N'WhiteAlley', CAST(90 AS Decimal(18, 0)), 2, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (23, N'Odr10779091609122021', N'MawSweet', CAST(N'2021-09-16T09:13:23.947' AS DateTime), CAST(N'2021-09-16T09:28:00.000' AS DateTime), CAST(N'2021-09-16T15:00:00.000' AS DateTime), N'WhiteAlley', CAST(0 AS Decimal(18, 0)), 2, N'Established')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (24, N'Odr10779091609292021', N'MawSweet', CAST(N'2021-09-16T09:29:48.260' AS DateTime), CAST(N'2021-09-23T09:29:00.000' AS DateTime), CAST(N'2021-09-24T09:29:00.000' AS DateTime), N'MilkShop', CAST(80 AS Decimal(18, 0)), 2, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (25, N'Odr10779091609592021', N'MawSweet', CAST(N'2021-09-16T09:59:39.000' AS DateTime), CAST(N'2021-09-21T09:59:00.000' AS DateTime), CAST(N'2021-10-08T09:59:00.000' AS DateTime), N'MilkShop', CAST(100 AS Decimal(18, 0)), 2, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (26, N'Odr10779091610062021', N'MawSweet', CAST(N'2021-09-16T10:06:40.177' AS DateTime), CAST(N'2021-09-17T10:06:00.000' AS DateTime), CAST(N'2021-09-24T10:06:00.000' AS DateTime), N'MilkShop', CAST(200 AS Decimal(18, 0)), 3, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (27, N'Odr10779091611032021', N'MawSweet', CAST(N'2021-09-16T11:03:10.703' AS DateTime), CAST(N'2021-09-23T11:03:00.000' AS DateTime), CAST(N'2021-09-25T11:03:00.000' AS DateTime), N'WhiteAlley', CAST(270 AS Decimal(18, 0)), 3, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (28, N'Odr10779091611052021', N'MawSweet', CAST(N'2021-09-16T11:05:23.567' AS DateTime), CAST(N'2021-09-16T11:22:00.000' AS DateTime), CAST(N'2021-09-17T11:09:00.000' AS DateTime), N'MilkShop', CAST(160 AS Decimal(18, 0)), 4, N'Established')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (29, N'Odr10779091611262021', N'MawSweet', CAST(N'2021-09-16T11:26:27.067' AS DateTime), CAST(N'2021-09-16T11:37:00.000' AS DateTime), CAST(N'2021-09-17T11:26:00.000' AS DateTime), N'WhiteAlley', CAST(200 AS Decimal(18, 0)), 4, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (30, N'Odr10779091612322021', N'MawSweet', CAST(N'2021-09-16T12:33:01.683' AS DateTime), CAST(N'2021-09-17T12:32:00.000' AS DateTime), CAST(N'2021-09-25T12:32:00.000' AS DateTime), N'WhiteAlley', CAST(100 AS Decimal(18, 0)), 2, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (31, N'Odr10779091612372021', N'MawSweet', CAST(N'2021-09-16T12:38:10.880' AS DateTime), CAST(N'2021-09-18T12:37:00.000' AS DateTime), CAST(N'2021-09-30T12:37:00.000' AS DateTime), N'WhiteAlley', CAST(160 AS Decimal(18, 0)), 4, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (32, N'Odr10779091613532021', N'MawSweet', CAST(N'2021-09-16T13:53:16.957' AS DateTime), CAST(N'2021-09-17T13:06:00.000' AS DateTime), CAST(N'2021-09-24T13:53:00.000' AS DateTime), N'Fiftylan', CAST(455 AS Decimal(18, 0)), 8, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (33, N'Odr10779091715252021', N'MawSweet', CAST(N'2021-09-17T15:25:09.673' AS DateTime), CAST(N'2021-09-29T15:25:00.000' AS DateTime), CAST(N'2021-10-08T15:25:00.000' AS DateTime), N'WhiteAlley', CAST(150 AS Decimal(18, 0)), 2, N'Inprogress')
INSERT [dbo].[OrderList] ([OrderID], [OrderNumber], [Account], [OrderTime], [OrderEndTime], [RequiredTime], [SupplierName], [TotalPrice], [TotalCups], [Established]) VALUES (34, N'Odr1077_091735', N'MawSweet', CAST(N'2021-09-17T15:35:40.307' AS DateTime), CAST(N'2021-09-30T15:35:00.000' AS DateTime), CAST(N'2021-10-08T15:35:00.000' AS DateTime), N'Fiftylan', CAST(260 AS Decimal(18, 0)), 5, N'Inprogress')
SET IDENTITY_INSERT [dbo].[OrderList] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (1, N'JasmineGreenTea', N'WhiteAlley', CAST(40 AS Decimal(18, 0)), 100, NULL, N'Tea', N'20210916033952839287713.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (6, N'PassionGreenTea', N'WhiteAlley', CAST(40 AS Decimal(18, 0)), 100, NULL, N'Tea', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (8, N'GreenTea', N'MilkShop', CAST(40 AS Decimal(18, 0)), 100, NULL, N'Tea', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (9, N'MilkTea', N'MilkShop', CAST(50 AS Decimal(18, 0)), 100, NULL, N'MilkTea', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (10, N'BubbleTea', N'Fiftylan', CAST(55 AS Decimal(18, 0)), 100, NULL, N'MilkTea', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (11, N'FourSeasonsGreenTea', N'Fiftylan', CAST(40 AS Decimal(18, 0)), 100, NULL, N'Tea', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (13, N'YakultGreenTea', N'WhiteAlley', CAST(40 AS Decimal(18, 0)), 100, NULL, N'Juice', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (14, N'GrapefruitJuice', N'WhiteAlley', CAST(40 AS Decimal(18, 0)), 100, NULL, N'Juice', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (15, N'YakultGreenTea', N'MilkShop', CAST(45 AS Decimal(18, 0)), 100, NULL, N'Yakult', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (16, N'Mung bean milk', N'MilkShop', CAST(50 AS Decimal(18, 0)), 100, NULL, N'
Smoothie', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (17, N'BubbleTea', N'Fiftylan', CAST(55 AS Decimal(18, 0)), 100, NULL, N'MilkTea', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (20, N'MilkTea', N'Fiftylan', CAST(45 AS Decimal(18, 0)), 100, NULL, N'MilkTea', N'DefaultPictrue_product.png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierName], [UnitPrice], [UnitsMaxOrder], [Discount], [CategoryName], [Picture]) VALUES (22, N'MilkTea', N'WhiteAlley', CAST(45 AS Decimal(18, 0)), NULL, NULL, N'MilkTea', N'20210916042201517233282.png')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[Suppliers] ([SupplierID], [SupplierName], [ContactFirstName], [ContactLastName], [Contact], [ContactTitle], [Phone], [Email], [SupplierWebPage], [OtherService]) VALUES (N'85e0a2fd-e16b-48f4-8d0b-46b6543f52c9', N'Fiftylan', N'Lee', N'Wang', N'phone', N'Manager', N'0912345678', N'Lee@gmail.com', NULL, NULL)
INSERT [dbo].[Suppliers] ([SupplierID], [SupplierName], [ContactFirstName], [ContactLastName], [Contact], [ContactTitle], [Phone], [Email], [SupplierWebPage], [OtherService]) VALUES (N'0870dff5-2e4b-46fe-95ac-b7f53314537c', N'MilkShop', N'Mina', N'Ran', N'email', N'Manager', N'0912345678', N'Mina@gmail.com', NULL, NULL)
INSERT [dbo].[Suppliers] ([SupplierID], [SupplierName], [ContactFirstName], [ContactLastName], [Contact], [ContactTitle], [Phone], [Email], [SupplierWebPage], [OtherService]) VALUES (N'e1b6580b-cf0f-41bd-a897-ca38c4cd18bc', N'WhiteAlley', N'Xiaoming', N'Bai', N'phone', N'DistrictManager', N'0912345678', N'Xiaoming@gmail.com', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Toppings] ON 

INSERT [dbo].[Toppings] ([ToppingsID], [ToppingsName], [UnitPrice], [Picture]) VALUES (1, N'Bubble', CAST(10 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Toppings] ([ToppingsID], [ToppingsName], [UnitPrice], [Picture]) VALUES (2, N'Grassjelly
', CAST(5 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Toppings] ([ToppingsID], [ToppingsName], [UnitPrice], [Picture]) VALUES (3, N'Coffeejelly', CAST(10 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Toppings] ([ToppingsID], [ToppingsName], [UnitPrice], [Picture]) VALUES (4, N'Coconutjelly', CAST(10 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Toppings] ([ToppingsID], [ToppingsName], [UnitPrice], [Picture]) VALUES (5, N'Pudding', CAST(15 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Toppings] ([ToppingsID], [ToppingsName], [UnitPrice], [Picture]) VALUES (6, N'Aloe', CAST(10 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Toppings] ([ToppingsID], [ToppingsName], [UnitPrice], [Picture]) VALUES (7, N'Taroballs', CAST(10 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Toppings] ([ToppingsID], [ToppingsName], [UnitPrice], [Picture]) VALUES (8, N'Konjacjelly', CAST(5 AS Decimal(18, 0)), NULL)
SET IDENTITY_INSERT [dbo].[Toppings] OFF
GO
INSERT [dbo].[UserAccount] ([UserID], [Account], [Password]) VALUES (N'd8f87369-35ee-4c80-9946-463ea4d0592e', N'LueQuen', N'123456789')
INSERT [dbo].[UserAccount] ([UserID], [Account], [Password]) VALUES (N'3bc86f28-71f5-4c09-9514-64c803bff669', N'MawSweet', N'123456789')
INSERT [dbo].[UserAccount] ([UserID], [Account], [Password]) VALUES (N'78abdf4a-50a1-46e7-bc43-88ecf18e8fe0', N'admin090403', N'123456789')
INSERT [dbo].[UserAccount] ([UserID], [Account], [Password]) VALUES (N'85d2bcb5-9ecf-4178-b88b-a51d6077bbc9', N'generaluser', N'123456789')
INSERT [dbo].[UserAccount] ([UserID], [Account], [Password]) VALUES (N'b9175f77-a235-47bc-9378-a949b6c299be', N'MeryLee', N'123456789')
INSERT [dbo].[UserAccount] ([UserID], [Account], [Password]) VALUES (N'1ee24b98-0702-43e3-ab22-b1ff6f7baa4b', N'admin', N'123456789')
INSERT [dbo].[UserAccount] ([UserID], [Account], [Password]) VALUES (N'7dc57c2d-8c59-4b09-94a2-bc1ac1eaec40', N'BpbMa', N'123456789')
INSERT [dbo].[UserAccount] ([UserID], [Account], [Password]) VALUES (N'34280aa2-c6d2-4268-8647-bf3acd6eac93', N'ZeoLin', N'123456789')
INSERT [dbo].[UserAccount] ([UserID], [Account], [Password]) VALUES (N'239545b8-6787-4ab8-a405-c7e8106cf464', N'admin090402', N'123456789')
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([Account], [EmployeeID], [DepartmentID], [Department], [FirstName], [LastName], [Contact], [Email], [ext], [Phone], [JobGrade], [Description], [ResponseSuppliers], [CreateDate], [LastModified], [Photo]) VALUES (N'admin', 12, N'1234', N'111', N'Olf', N'admin', N'分機', N'Ken@gmail.com', N'4416', N'0919251482', 1, NULL, NULL, CAST(N'2021-09-14T22:08:45.750' AS DateTime), CAST(N'2021-09-14T22:08:45.750' AS DateTime), N'DefaultPhoto_admin.png')
INSERT [dbo].[UserInfo] ([Account], [EmployeeID], [DepartmentID], [Department], [FirstName], [LastName], [Contact], [Email], [ext], [Phone], [JobGrade], [Description], [ResponseSuppliers], [CreateDate], [LastModified], [Photo]) VALUES (N'BpbMa', 4, N'18792', N'C94', N'Bob', N'Ma', N'電話', N'BobMa@doc.com', N'2194', N'0998654624', 0, NULL, NULL, CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-09-12T15:49:04.653' AS DateTime), N'DefaultPhoto_user.png')
INSERT [dbo].[UserInfo] ([Account], [EmployeeID], [DepartmentID], [Department], [FirstName], [LastName], [Contact], [Email], [ext], [Phone], [JobGrade], [Description], [ResponseSuppliers], [CreateDate], [LastModified], [Photo]) VALUES (N'generaluser', 13, N'165', N'A61', N'PinPin', N'Lo', N'分機', N'PinPin@gmail.com', N'4416', N'0919251482', 0, N'', N'', CAST(N'2021-09-16T04:14:31.920' AS DateTime), CAST(N'2021-09-16T09:07:15.797' AS DateTime), N'20210916090714302592210.png')
INSERT [dbo].[UserInfo] ([Account], [EmployeeID], [DepartmentID], [Department], [FirstName], [LastName], [Contact], [Email], [ext], [Phone], [JobGrade], [Description], [ResponseSuppliers], [CreateDate], [LastModified], [Photo]) VALUES (N'LueQuen', 3, N'9999', N'A28', N'Lue', N'Ouen', N'電話', N'LueLue@dos.com', N'2249', N'0912345698', 0, N'', N'', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-09-16T14:02:11.223' AS DateTime), N'DefaultPhoto_user.png')
INSERT [dbo].[UserInfo] ([Account], [EmployeeID], [DepartmentID], [Department], [FirstName], [LastName], [Contact], [Email], [ext], [Phone], [JobGrade], [Description], [ResponseSuppliers], [CreateDate], [LastModified], [Photo]) VALUES (N'MawSweet', 6, N'10779', N'Z10', N'Maw', N'Sweet', N'Email', N'MawSweet@dos.com', N'1077', N'0912355647', 1, NULL, NULL, CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-09-15T15:49:04.653' AS DateTime), N'DefaultPhoto_admin.png')
INSERT [dbo].[UserInfo] ([Account], [EmployeeID], [DepartmentID], [Department], [FirstName], [LastName], [Contact], [Email], [ext], [Phone], [JobGrade], [Description], [ResponseSuppliers], [CreateDate], [LastModified], [Photo]) VALUES (N'MeryLee', 2, N'99992', N'A28', N'Mery', N'Lee', N'Email', N'MeryLee@dos.com', N'2248', N'0912345678', 0, N'', N'', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-09-16T09:33:23.463' AS DateTime), N'20210916034139029254543.png')
INSERT [dbo].[UserInfo] ([Account], [EmployeeID], [DepartmentID], [Department], [FirstName], [LastName], [Contact], [Email], [ext], [Phone], [JobGrade], [Description], [ResponseSuppliers], [CreateDate], [LastModified], [Photo]) VALUES (N'ZeoLin', 7, N'10891', N'Z11', N'Zeo', N'Lin', N'Email', N'ZeoLin@dos.com', N'1107', N'0946448131', 2, N'', N'', CAST(N'2021-08-24T15:49:04.653' AS DateTime), CAST(N'2021-09-16T04:11:56.660' AS DateTime), N'20210916041150757867927.png')
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
GO
USE [master]
GO
ALTER DATABASE [DrinkOrderSystem] SET  READ_WRITE 
GO
