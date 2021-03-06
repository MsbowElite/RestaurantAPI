USE [RestaurantAPI]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[OwnerId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Active] [bit] NOT NULL,
	[MenuOption] [tinyint] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyAdministrators]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyAdministrators](
	[CompanyId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CompanyAdministrators] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyClients]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyClients](
	[CompanyId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CompanyClients] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyDeliverers]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyDeliverers](
	[CompanyId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CompanyDeliverers] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dish]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dish](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CompanyDishes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DishCalendar]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DishCalendar](
	[DishId] [uniqueidentifier] NOT NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[Date] [date] NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_DishCalendar] PRIMARY KEY CLUSTERED 
(
	[DishId] ASC,
	[CompanyId] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DishIngredients]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DishIngredients](
	[DisheId] [uniqueidentifier] NOT NULL,
	[IngredientId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_DisheIngredients] PRIMARY KEY CLUSTERED 
(
	[DisheId] ASC,
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](max) NULL,
	[OwnerId] [uniqueidentifier] NULL,
	[CompanyId] [uniqueidentifier] NULL,
	[Latitude] [decimal](18, 2) NULL,
	[Longitude] [decimal](18, 2) NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupClients]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupClients](
	[GroupId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_GroupClients] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](400) NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](400) NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CompanyMenus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuDishes]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuDishes](
	[MenuId] [uniqueidentifier] NOT NULL,
	[DisheId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CompanyMenuDishes] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC,
	[DisheId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CompanyMenuDishes_CompanyDishId_CompanyMenuId] UNIQUE NONCLUSTERED 
(
	[DisheId] ASC,
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [nvarchar](20) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](100) NULL,
	[Username] [nvarchar](22) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [nvarchar](20) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeeklyMenus]    Script Date: 11/10/2019 7:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeeklyMenus](
	[WeekDay] [tinyint] NOT NULL,
	[CompanyMenusId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_WeeklyMenus_1] PRIMARY KEY CLUSTERED 
(
	[WeekDay] ASC,
	[CompanyMenusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF_Companies_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF_Companies_OwnerId]  DEFAULT (newid()) FOR [OwnerId]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF__Companies__Activ__14270015]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF__Companies__MenuO__2739D489]  DEFAULT (CONVERT([tinyint],(0))) FOR [MenuOption]
GO
ALTER TABLE [dbo].[Dish] ADD  CONSTRAINT [DF_CompanyDishes_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Groups_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Ingredient] ADD  CONSTRAINT [DF_Ingredients_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_CompanyMenus_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Companies_Users_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Companies_Users_OwnerId]
GO
ALTER TABLE [dbo].[CompanyAdministrators]  WITH CHECK ADD  CONSTRAINT [FK_CompanyAdministrators_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyAdministrators] CHECK CONSTRAINT [FK_CompanyAdministrators_Companies_CompanyId]
GO
ALTER TABLE [dbo].[CompanyAdministrators]  WITH CHECK ADD  CONSTRAINT [FK_CompanyAdministrators_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyAdministrators] CHECK CONSTRAINT [FK_CompanyAdministrators_Users_UserId]
GO
ALTER TABLE [dbo].[CompanyClients]  WITH CHECK ADD  CONSTRAINT [FK_CompanyClients_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyClients] CHECK CONSTRAINT [FK_CompanyClients_Companies_CompanyId]
GO
ALTER TABLE [dbo].[CompanyClients]  WITH CHECK ADD  CONSTRAINT [FK_CompanyClients_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyClients] CHECK CONSTRAINT [FK_CompanyClients_Users_UserId]
GO
ALTER TABLE [dbo].[CompanyDeliverers]  WITH CHECK ADD  CONSTRAINT [FK_CompanyDeliverers_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyDeliverers] CHECK CONSTRAINT [FK_CompanyDeliverers_Companies_CompanyId]
GO
ALTER TABLE [dbo].[CompanyDeliverers]  WITH CHECK ADD  CONSTRAINT [FK_CompanyDeliverers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyDeliverers] CHECK CONSTRAINT [FK_CompanyDeliverers_Users_UserId]
GO
ALTER TABLE [dbo].[Dish]  WITH CHECK ADD  CONSTRAINT [FK_CompanyDishes_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Dish] CHECK CONSTRAINT [FK_CompanyDishes_Companies_CompanyId]
GO
ALTER TABLE [dbo].[DishCalendar]  WITH CHECK ADD  CONSTRAINT [FK_DishCalendar_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[DishCalendar] CHECK CONSTRAINT [FK_DishCalendar_Company]
GO
ALTER TABLE [dbo].[DishCalendar]  WITH CHECK ADD  CONSTRAINT [FK_DishCalendar_Dish] FOREIGN KEY([DishId])
REFERENCES [dbo].[Dish] ([Id])
GO
ALTER TABLE [dbo].[DishCalendar] CHECK CONSTRAINT [FK_DishCalendar_Dish]
GO
ALTER TABLE [dbo].[DishIngredients]  WITH CHECK ADD  CONSTRAINT [FK_DisheIngredients_CompanyDishes] FOREIGN KEY([DisheId])
REFERENCES [dbo].[Dish] ([Id])
GO
ALTER TABLE [dbo].[DishIngredients] CHECK CONSTRAINT [FK_DisheIngredients_CompanyDishes]
GO
ALTER TABLE [dbo].[DishIngredients]  WITH CHECK ADD  CONSTRAINT [FK_DisheIngredients_Ingredients] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredient] ([Id])
GO
ALTER TABLE [dbo].[DishIngredients] CHECK CONSTRAINT [FK_DisheIngredients_Ingredients]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Groups_Companies_CompanyId]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Users_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Groups_Users_OwnerId]
GO
ALTER TABLE [dbo].[GroupClients]  WITH CHECK ADD  CONSTRAINT [FK_GroupClients_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupClients] CHECK CONSTRAINT [FK_GroupClients_Groups_GroupId]
GO
ALTER TABLE [dbo].[GroupClients]  WITH CHECK ADD  CONSTRAINT [FK_GroupClients_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupClients] CHECK CONSTRAINT [FK_GroupClients_Users_UserId]
GO
ALTER TABLE [dbo].[Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_Ingredients_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Ingredient] CHECK CONSTRAINT [FK_Ingredients_Companies]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_CompanyMenus_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_CompanyMenus_Companies]
GO
ALTER TABLE [dbo].[MenuDishes]  WITH CHECK ADD  CONSTRAINT [FK_CompanyMenuDishes_CompanyDishes_CompanyDishId] FOREIGN KEY([DisheId])
REFERENCES [dbo].[Dish] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MenuDishes] CHECK CONSTRAINT [FK_CompanyMenuDishes_CompanyDishes_CompanyDishId]
GO
ALTER TABLE [dbo].[MenuDishes]  WITH CHECK ADD  CONSTRAINT [FK_CompanyMenuDishes_CompanyMenus_CompanyMenuId] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menu] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MenuDishes] CHECK CONSTRAINT [FK_CompanyMenuDishes_CompanyMenus_CompanyMenuId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[WeeklyMenus]  WITH CHECK ADD  CONSTRAINT [FK_WeeklyMenus_CompanyMenus_CompanyMenusId] FOREIGN KEY([CompanyMenusId])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[WeeklyMenus] CHECK CONSTRAINT [FK_WeeklyMenus_CompanyMenus_CompanyMenusId]
GO
