/*    user type       */
SET IDENTITY_INSERT [Role] ON
GO

INSERT INTO [Role] ([Id],[Name],UpdateUser,UpdateTime) VALUES (1,N'平台管理员','',getdate())
INSERT INTO [Role] ([Id],[Name],UpdateUser,UpdateTime) VALUES (2,N'客户管理员','',getdate())
INSERT INTO [Role] ([Id],[Name],UpdateUser,UpdateTime) VALUES (3,N'咨询人员','',getdate())
INSERT INTO [Role] ([Id],[Name],UpdateUser,UpdateTime) VALUES (4,N'工程人员','',getdate())
INSERT INTO [Role] ([Id],[Name],UpdateUser,UpdateTime) VALUES (5,N'商务人员','',getdate())
GO

SET IDENTITY_INSERT [Role] OFF
GO


/* Data for the `dbo.User` table  (Records 1 - 1) */
SET IDENTITY_INSERT [User] ON
GO

INSERT INTO [dbo].[User] ([Id], [Name], RealName, UserType, Password, PasswordToken, PasswordTokenDate, Comment, Title, Telephone, Email, [Status], [UpdateUser], [UpdateTime])
VALUES (1, N'PlatformAdmin', N'平台管理员',1, N'161ebd7d45089b3446ee4e0d86dbcf92', '',null,'1',1,'1','yu-phil.cui@schneider-electric.com', 1, N'PlatformAdmin', '20120101')
GO

SET IDENTITY_INSERT [User] OFF
GO

INSERT INTO UserCustomer(UserId, HierarchyId,UpdateUser, UpdateTime)
Values(1,0,'',getdate())
GO


INSERT INTO UserRole(UserId,RoleId)
Values(1,1)
GO

