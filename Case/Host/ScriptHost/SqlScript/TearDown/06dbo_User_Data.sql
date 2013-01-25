
/*    user type       */
SET IDENTITY_INSERT [UserType] ON
GO

INSERT INTO [UserType] ([Id],[Name]) VALUES (1,N'平台管理员')
INSERT INTO [UserType] ([Id],[Name]) VALUES (2,N'客户管理员')
INSERT INTO [UserType] ([Id],[Name]) VALUES (3,N'咨询人员')
INSERT INTO [UserType] ([Id],[Name]) VALUES (4,N'工程人员')
INSERT INTO [UserType] ([Id],[Name]) VALUES (5,N'商务人员')
GO

SET IDENTITY_INSERT [UserType] OFF
GO


/* Data for the `dbo.User` table  (Records 1 - 1) */
SET IDENTITY_INSERT [User] ON
GO

INSERT INTO [dbo].[User] ([Id], [Name], RealName, UserType, Password, Comment, Title, Telephone, Email, [Status], [UpdateUser], [UpdateTime])
VALUES (1, N'PlatformAdmin', N'平台管理员',1, N'161ebd7d45089b3446ee4e0d86dbcf92', '','','1212','', 1, N'PlatformAdmin', '20120101')
GO

SET IDENTITY_INSERT [User] OFF
GO

INSERT INTO UserCustomer(UserId, HierarchyId)
Values(1,0)