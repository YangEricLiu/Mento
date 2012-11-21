SET IDENTITY_INSERT Hierarchy ON
INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(2,-1,'Mento','Mento',1,'Mento',NULL,1,'/2/',1,'Mento',GETDATE())
SET IDENTITY_INSERT Hierarchy OFF