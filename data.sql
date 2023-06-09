USE [PRN_project]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 3/20/2023 2:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 3/20/2023 2:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](10) NULL,
	[BirthDate] [datetime] NULL,
	[HireDate] [datetime] NULL,
	[Phone] [varchar](15) NULL,
	[DepartmentID] [int] NULL,
	[UserName] [nvarchar](30) NULL,
	[Password] [nvarchar](30) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 3/20/2023 2:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](30) NULL,
	[Password] [nvarchar](30) NULL,
	[DepartmentID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salary]    Script Date: 3/20/2023 2:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary](
	[SalaryID] [int] IDENTITY(1,1) NOT NULL,
	[Bonus] [int] NULL,
	[EmployeeID] [int] NOT NULL,
	[HardSalary] [int] NULL,
 CONSTRAINT [PK_Salary] PRIMARY KEY CLUSTERED 
(
	[SalaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 3/20/2023 2:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Status] [nvarchar](10) NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (1, N'IT')
INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (2, N'Graphic Design')
INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (3, N'AI')
INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (4, N'IB')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [FullName], [Gender], [BirthDate], [HireDate], [Phone], [DepartmentID], [UserName], [Password]) VALUES (1, N'Dang Phu Hai', N'Male', CAST(N'2002-09-04T00:00:00.000' AS DateTime), CAST(N'2020-12-02T00:00:00.000' AS DateTime), N'0862700409', 1, N'haidp', N'123')
INSERT [dbo].[Employees] ([EmployeeID], [FullName], [Gender], [BirthDate], [HireDate], [Phone], [DepartmentID], [UserName], [Password]) VALUES (2, N'Nguyen Chi Thanh', N'Female', CAST(N'2002-01-01T00:00:00.000' AS DateTime), CAST(N'2020-12-21T00:00:00.000' AS DateTime), N'0862700512', 2, N'thanhnc', N'123')
INSERT [dbo].[Employees] ([EmployeeID], [FullName], [Gender], [BirthDate], [HireDate], [Phone], [DepartmentID], [UserName], [Password]) VALUES (3, N'Nguyen Truong Son', N'Female', CAST(N'2002-02-02T00:00:00.000' AS DateTime), CAST(N'2020-02-24T00:00:00.000' AS DateTime), N'0862700654', 2, N'sonnt', N'123')
INSERT [dbo].[Employees] ([EmployeeID], [FullName], [Gender], [BirthDate], [HireDate], [Phone], [DepartmentID], [UserName], [Password]) VALUES (4, N'Tran Gia Bao', N'Male', CAST(N'2002-03-03T00:00:00.000' AS DateTime), CAST(N'2020-04-21T00:00:00.000' AS DateTime), N'0862700444', 2, N'baotg', N'123')
INSERT [dbo].[Employees] ([EmployeeID], [FullName], [Gender], [BirthDate], [HireDate], [Phone], [DepartmentID], [UserName], [Password]) VALUES (5, N'Vu Thi Ha', N'Female', CAST(N'2002-04-04T00:00:00.000' AS DateTime), CAST(N'2020-04-21T00:00:00.000' AS DateTime), N'0862700121', 1, N'hant', N'123')
INSERT [dbo].[Employees] ([EmployeeID], [FullName], [Gender], [BirthDate], [HireDate], [Phone], [DepartmentID], [UserName], [Password]) VALUES (10, N'Alex', N'Male', CAST(N'2002-07-12T22:58:50.000' AS DateTime), CAST(N'2023-03-08T22:58:50.210' AS DateTime), N'0877328724', 3, N'alex', N'123')
INSERT [dbo].[Employees] ([EmployeeID], [FullName], [Gender], [BirthDate], [HireDate], [Phone], [DepartmentID], [UserName], [Password]) VALUES (11, N'Julian', N'Female', CAST(N'2002-03-16T00:00:00.000' AS DateTime), CAST(N'2022-05-12T22:01:18.000' AS DateTime), N'0832665458', 4, N'julia', N'abc')
INSERT [dbo].[Employees] ([EmployeeID], [FullName], [Gender], [BirthDate], [HireDate], [Phone], [DepartmentID], [UserName], [Password]) VALUES (12, N'Miama', N'Female', CAST(N'2002-02-22T00:00:00.000' AS DateTime), CAST(N'2022-03-23T00:00:00.000' AS DateTime), N'0834677223', 3, N'miama', N'abc')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Manager] ON 

INSERT [dbo].[Manager] ([AccountID], [UserName], [Password], [DepartmentID]) VALUES (1, N'hai', N'123', 1)
INSERT [dbo].[Manager] ([AccountID], [UserName], [Password], [DepartmentID]) VALUES (2, N'thanh', N'123', 2)
SET IDENTITY_INSERT [dbo].[Manager] OFF
GO
SET IDENTITY_INSERT [dbo].[Salary] ON 

INSERT [dbo].[Salary] ([SalaryID], [Bonus], [EmployeeID], [HardSalary]) VALUES (1, 30, 1, 110)
INSERT [dbo].[Salary] ([SalaryID], [Bonus], [EmployeeID], [HardSalary]) VALUES (2, 50, 2, 120)
INSERT [dbo].[Salary] ([SalaryID], [Bonus], [EmployeeID], [HardSalary]) VALUES (3, 25, 3, 110)
INSERT [dbo].[Salary] ([SalaryID], [Bonus], [EmployeeID], [HardSalary]) VALUES (4, 22, 4, 140)
INSERT [dbo].[Salary] ([SalaryID], [Bonus], [EmployeeID], [HardSalary]) VALUES (5, 30, 5, 100)
INSERT [dbo].[Salary] ([SalaryID], [Bonus], [EmployeeID], [HardSalary]) VALUES (8, 50, 10, 83)
SET IDENTITY_INSERT [dbo].[Salary] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (3, 3, N'Degisn', N'Degisn phone', N'doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (5, 5, N'Code', N'Develop software', N'doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (10, 3, N'BA', N'BA with COD team', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (12, 2, N'Code c#', N'CRUD', N'Done')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (14, 4, N'Tester', N'Test AOK app', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (15, 2, N'Lamda', N'Lamda team', N'Done')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (16, 1, N'Marketting', N'lam ma', N'doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (17, 2, N'', N'', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (18, 3, N'', N'', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (19, 4, N'', N'', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (20, 3, N'', N'', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (21, 3, N'', N'', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (22, 2, N'', N'', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (23, 5, N'', N'', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (24, 5, N'', N'', N'Doing')
INSERT [dbo].[Task] ([TaskID], [EmployeeID], [Title], [Description], [Status]) VALUES (25, 1, N'ac', N'ac', N'Doing')
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments]
GO
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD  CONSTRAINT [FK_Salary_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Salary] CHECK CONSTRAINT [FK_Salary_Employees]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Employees]
GO
