
SET IDENTITY_INSERT Hierarchy ON
INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES
(1,-1,'Schneider','Schneider',1,'Schneider',NULL,1,'/1/',1,'I',GETDATE())
SET IDENTITY_INSERT Hierarchy OFF


INSERT INTO CUSTOMER(HierarchyId,Address,Manager,Telephone,Email,StartTime)
VALUES
(1, 'address','Hai Zhu', '111111','hai.zhu@schneider-electric.com',Getdate())

