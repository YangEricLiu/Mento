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
VALUES (1, N'demo', N'Demo',1, N'5f4dcc3b5aa765d61d8327deb882cf99', '','','','', 1, N'Demo', '20120101')
GO

SET IDENTITY_INSERT [User] OFF
GO

INSERT INTO UserCustomer(UserId, HierarchyId)
Values(1,1)