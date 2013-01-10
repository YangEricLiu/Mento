SET IDENTITY_INSERT Hierarchy ON
INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(1,-1,'Mento','自动化测试',1,'Mento',NULL,1,'/1/',1,'Mento',GETDATE())
SET IDENTITY_INSERT Hierarchy OFF

SET IDENTITY_INSERT Customer ON
INSERT INTO Customer(HierarchyId,Address,Manager,Telephone,Email,StartTime)
VALUES(1,'beijing','auto','01000000','111@11@.11',GETDATE())
SET IDENTITY_INSERT Customer OFF

SET IDENTITY_INSERT [User] ON
INSERT INTO [User](Id,Name,RealName,UserType,Password,Comment,Title,Telephone,Email,Status,UpdateUser,UpdateTime)
VALUES(1,'AutoCustomer','Auto',2,'123456qq','auto','auto','0100000','11@11.11',1,'AutoCustomer',GETDATE())
SET IDENTITY_INSERT [User] OFF

SET IDENTITY_INSERT UserCustomer ON
INSERT INTO UserCustomer(Id,UserId,HierarchyId)
VALUES(1,1,1)
SET IDENTITY_INSERT UserCustomer OFF



--------------------------------Tag------
---------