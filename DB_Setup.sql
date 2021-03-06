USE [StudentEnrollment]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/23/2021 3:28:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 1/23/2021 3:28:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](5) NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 1/23/2021 3:28:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[StudentEnrollmentDetail]    Script Date: 1/23/2021 3:28:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentEnrollmentDetail] 
AS
	SELECT
		e.EnrollmentId,
		s.StudentId,
		s.FirstName,
		s.LastName,
		c.CourseId,
		c.CourseCode
	FROM
		Enrollment e
		INNER JOIN Student s ON e.StudentId = s.StudentId
		INNER JOIN Course c  ON e.CourseId = c.CourseId
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [CourseCode], [Description]) VALUES (1, N'AF', N'Accounting & Finance')
INSERT [dbo].[Course] ([CourseId], [CourseCode], [Description]) VALUES (2, N'ME', N'Aeronautical & Manufacturing Engineering')
INSERT [dbo].[Course] ([CourseId], [CourseCode], [Description]) VALUES (3, N'AF', N'Agriculture & Forestry')
INSERT [dbo].[Course] ([CourseId], [CourseCode], [Description]) VALUES (4, N'AS', N'American Studies')
INSERT [dbo].[Course] ([CourseId], [CourseCode], [Description]) VALUES (5, N'APSY', N'Anatomy & Physiology')
INSERT [dbo].[Course] ([CourseId], [CourseCode], [Description]) VALUES (6, N'ANT', N'Anthropology')
INSERT [dbo].[Course] ([CourseId], [CourseCode], [Description]) VALUES (7, N'ARC', N'Archaeology')
INSERT [dbo].[Course] ([CourseId], [CourseCode], [Description]) VALUES (8, N'ARCH', N'Architecture')
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Enrollment] ON 

INSERT [dbo].[Enrollment] ([EnrollmentId], [StudentId], [CourseId]) VALUES (1, 1, 1)
INSERT [dbo].[Enrollment] ([EnrollmentId], [StudentId], [CourseId]) VALUES (2, 2, 1)
INSERT [dbo].[Enrollment] ([EnrollmentId], [StudentId], [CourseId]) VALUES (3, 3, 1)
INSERT [dbo].[Enrollment] ([EnrollmentId], [StudentId], [CourseId]) VALUES (4, 1, 2)
INSERT [dbo].[Enrollment] ([EnrollmentId], [StudentId], [CourseId]) VALUES (5, 2, 2)
INSERT [dbo].[Enrollment] ([EnrollmentId], [StudentId], [CourseId]) VALUES (6, 3, 2)
INSERT [dbo].[Enrollment] ([EnrollmentId], [StudentId], [CourseId]) VALUES (7, 4, 2)
INSERT [dbo].[Enrollment] ([EnrollmentId], [StudentId], [CourseId]) VALUES (8, 5, 3)
INSERT [dbo].[Enrollment] ([EnrollmentId], [StudentId], [CourseId]) VALUES (9, 6, 4)
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentId], [FirstName], [LastName]) VALUES (1, N'Millard', N'Lamb')
INSERT [dbo].[Student] ([StudentId], [FirstName], [LastName]) VALUES (2, N'Gayle', N'Reid')
INSERT [dbo].[Student] ([StudentId], [FirstName], [LastName]) VALUES (3, N'Quinton', N'Beltran')
INSERT [dbo].[Student] ([StudentId], [FirstName], [LastName]) VALUES (4, N'Eusebio', N'Moyer')
INSERT [dbo].[Student] ([StudentId], [FirstName], [LastName]) VALUES (5, N'Imelda', N'Shea')
INSERT [dbo].[Student] ([StudentId], [FirstName], [LastName]) VALUES (6, N'Ellsworth', N'Fletcher')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
/****** Object:  StoredProcedure [dbo].[ViewEnrollmentDetail]    Script Date: 1/23/2021 3:28:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ViewEnrollmentDetail] AS
BEGIN
	SELECT
		EnrollmentId,
		StudentId,
		FirstName,
		LastName,
		CourseId,
		CourseCode
	FROM
		StudentEnrollmentDetail
END
GO
