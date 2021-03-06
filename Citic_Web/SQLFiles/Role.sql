USE [Citic_Pledge_Manage_ZF]
GO
/****** Object:  Table [dbo].[tb_Role]    Script Date: 01/17/2014 13:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[RoleDesc] [varchar](200) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Role] ON
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (1, N'超级管理员', N'具有分配和变更权限的功能')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (2, N'管理员', N'负责普通权限')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (3, N'业务经理', N'')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (4, N'市场经理', N'')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (5, N'市场专员', N'')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (6, N'品牌专员', N'')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (7, N'调配专员', N'')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (8, N'银行', N'')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (9, N'厂家', N'')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (10, N'监管员', N'')
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (22, N'办事处', NULL)
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (23, N'管理中心', NULL)
INSERT [dbo].[tb_Role] ([RoleId], [RoleName], [RoleDesc]) VALUES (24, N'办事处风控专员', N'负责风控表单的填写，如若想修改其添加过的表单则需要向上级提出申请。')
SET IDENTITY_INSERT [dbo].[tb_Role] OFF
